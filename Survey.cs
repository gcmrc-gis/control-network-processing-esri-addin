using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control_network_processing
{
    public class Survey
    {
        private string _sTDXF_FilePath;
        private string _sOutputGDB_Path;

        private Dictionary<string, List<List<string>>> _dOrganizedRecords = new Dictionary<string, List<List<string>>> { };
        private Dictionary<string, string> _dSurveyProperties = new Dictionary<string, string> { };
        private Dictionary<string, Point> _dStations = new Dictionary<string, Point> { };
        private Dictionary<string, Point> _dKeyedInCoordinates = new Dictionary<string, Point> { };
        private List<GPS_Observation> _lGPSObservations = new List<GPS_Observation> { };
        private List<SideShot> _lTerrestrialObservations = new List<SideShot> { };

        private const string sPrimaryName = "Primary";
        private const string sSecondaryName = "Secondary";
        private const string sTertiaryName = "Tertiary";
        private const string sStationsName = "Stations";
        private const string sTraverseName = "Traverse";

        public Survey(string sTDXF_FilePath,
                      string sOutputGDB_Path)
        {
            this._sTDXF_FilePath = sTDXF_FilePath;
            this._sOutputGDB_Path = sOutputGDB_Path;

            if (System.IO.File.Exists(sTDXF_FilePath))
            {
                string sRecords = System.IO.File.ReadAllText(sTDXF_FilePath);
                _dOrganizedRecords = OrganizeDataWithHeaders(sRecords, "=");
                if (_dOrganizedRecords.Keys.Contains("General"))
                {
                    _dSurveyProperties = GetSurveyProperties(_dOrganizedRecords["General"]);    
                }
                if (_dOrganizedRecords.Keys.Contains("Stations") && _dSurveyProperties.Keys.Contains("Separator") && _dSurveyProperties.Keys.Contains("MissingValue"))
                {

                    _dStations = ProcessStationRecords(_dOrganizedRecords["Stations"],
                                                       _dSurveyProperties["Separator"],
                                                       _dSurveyProperties["MissingValue"]);
                }
                if (_dOrganizedRecords.Keys.Contains("Keyed In Coordinates") && _dSurveyProperties.Keys.Contains("Separator") && _dSurveyProperties.Keys.Contains("MissingValue"))
                {

                    _dKeyedInCoordinates = ProcessKeyedInCoordinatesRecords(_dOrganizedRecords["Keyed In Coordinates"],
                                                                            _dSurveyProperties["Separator"],
                                                                            _dSurveyProperties["MissingValue"]);
                }
                if (_dOrganizedRecords.Keys.Contains("Observed Coordinates") && _dSurveyProperties.Keys.Contains("Separator") && _dSurveyProperties.Keys.Contains("MissingValue"))
                {
                    //TODO
                }
                if (_dOrganizedRecords.Keys.Contains("GPS") && _dSurveyProperties.Keys.Contains("Separator") && _dSurveyProperties.Keys.Contains("MissingValue"))
                {
                    _lGPSObservations = ProcessGPS_Records(_dOrganizedRecords["GPS"],
                                                          _dSurveyProperties["Separator"],
                                                          _dSurveyProperties["MissingValue"]);
                }
                if (_dOrganizedRecords.Keys.Contains("Terrestrial") && _dSurveyProperties.Keys.Contains("Separator") && _dSurveyProperties.Keys.Contains("MissingValue"))
                {
                    _lTerrestrialObservations = ProcessTerrestrialRecords(_dOrganizedRecords["Terrestrial"],
                                                                          _dSurveyProperties["Separator"],
                                                                          _dSurveyProperties["MissingValue"],
                                                                          _dStations);
                }
            }
                
            
        }

        enum TrimbleRecordType
        {
            General
        }
        
        public enum CoordinateType
        {
            Station,
            GridCoord,
            LLCoord,
            Vector,
            GPS,
            TerrObs
        }

        public  Dictionary<string, Point> Stations { get { return _dStations; } }
        public  List<GPS_Observation> GPS_Observations { get { return _lGPSObservations; } }
        public  List<SideShot> TerrestrialObservations { get { return _lTerrestrialObservations; } }
        
        private Dictionary<string, List<List<string>>> OrganizeDataWithHeaders(string sRecords,
                                                                               string sSeparator)
        {
            Dictionary<string, List<List<string>>> dHeadersWithData = new Dictionary<string, List<List<string>>> { };
            List<string> lHeaders = GetHeaderDataNames(sRecords);
            List<string> lRecordsDividedByHeader = SplitDataByHeaders(sRecords);
            for (int i = 0; i < lHeaders.Count(); i++)
            {
                dHeadersWithData.Add(lHeaders[i], GetOrganizedRecords(lRecordsDividedByHeader[i + 1], sSeparator));
            }
            return dHeadersWithData;
        }

        private List<string> GetHeaderDataNames(string sRecords)
        {
            var lHeaderMatches = System.Text.RegularExpressions.Regex.Matches(sRecords, @"\[[a-zA-Z\s]+\]");
            List<string> lHeaders = lHeaderMatches.Cast<System.Text.RegularExpressions.Match>().Select(sMatch => sMatch.Value).ToList();
            return (from header in lHeaders select header.Substring(1, header.Length - 2)).ToList();
        }

        private List<string> SplitDataByHeaders(string sRecords)
        {
            return System.Text.RegularExpressions.Regex.Split(sRecords, @"\[[a-zA-Z\s]+\]").ToList();
        }

        private List<List<string>> GetOrganizedRecords(string sRecords,
                                                       string sSeparator)
        {
            List<string> lRecordLines = sRecords.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            List<List<string>> lOrganizedRecords = (from record in lRecordLines select record.Trim().Split(new string[] { sSeparator }, StringSplitOptions.None).ToList()).ToList();
            return lOrganizedRecords;
        }

        private List<string> GetRecordInformation(List<string> lRecord,
                                                  string sRecordsSeparator)
        {
            List<string> lRecordInformation = new List<string> ();
            char[] cSeparator = sRecordsSeparator.ToCharArray();
            if (lRecord.Count >= 2)
            {
                lRecordInformation = lRecord[1].Split(cSeparator).ToList();
            }
            return lRecordInformation;
        }

        private int DetermineWGS_84_Sign(string sValue)
        {
            int sign = 1;
            if (String.IsNullOrEmpty(sValue) == false)
            {
                switch (sValue.ToUpper())
                {
                    case "S":
                    case "W":
                        sign = -1;
                        break;
                    default:
                        break;
                }
            }
            return sign;
        }

        private double? CheckForMissingValue(string sValue,
                                             string sMissingValue)
        {
            return  (sValue != sMissingValue) ? (double?)Convert.ToDouble(sValue) : null;

        }

        private Dictionary<string, string> GetSurveyProperties(List<List<string>> lGeneralRecords)
        {
            Dictionary<string, string> dSurveyProperties = new Dictionary<string,string> {};
            foreach (List<string> lRecord in lGeneralRecords)
            {
                if (lRecord.Count >= 2)
                {
                    dSurveyProperties.Add(lRecord[0], lRecord[1]);
                }
            }
            return dSurveyProperties;
        }

        private Dictionary<string, Point> ProcessStationRecords(List<List<string>> lStationRecords,
                                                                string sRecordsSeparator,
                                                                string sMissingValue)
        {
            Dictionary<string, Point> dStations = new Dictionary<string,Point> {};
            foreach (List<string> lRecord in lStationRecords)
            {
                string sRecordType = lRecord[0];
                List<string> lRecordInformation = GetRecordInformation(lRecord, sRecordsSeparator);

                if (String.Compare(sRecordType, CoordinateType.Station.ToString()) == 0)
                {
                    if (lRecordInformation.Count > 5)
                    {
                        string sStationName = lRecordInformation[2];
                        double dLatitude = (DetermineWGS_84_Sign(RegularExpressions.GetAlphaCharacters(lRecordInformation[3])) * RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[3]));
                        double dLongitude = (DetermineWGS_84_Sign(RegularExpressions.GetAlphaCharacters(lRecordInformation[4])) * RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[4]));
                        double? dElevation = (DetermineWGS_84_Sign(RegularExpressions.GetAlphaCharacters(lRecordInformation[5])) * RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[5], sMissingValue));

                        double dLocalNorthing = Convert.ToDouble(lRecordInformation[6]);
                        double dLocalEasting = Convert.ToDouble(lRecordInformation[7]);
                        double? dLocalElevation = CheckForMissingValue(lRecordInformation[8], sMissingValue);

                        string sFeatureCode = lRecordInformation[lRecordInformation.Count-1];

                        Point pStation = new Point(sStationName,
                                                   dLocalEasting,
                                                   dLocalNorthing,
                                                   dLocalElevation,
                                                   sFeatureCode,
                                                   dLongitude,
                                                   dLatitude,
                                                   dElevation);
                        if (dStations.Keys.Contains(sStationName) == false)
                        {
                            dStations.Add(sStationName, pStation);
                        }
                        else
                        {
                            throw new Exception("the station already exists within the dicationary.");
                        }
                    }
                }
            }
            return dStations;
        }
        
        private Dictionary<string, Point> ProcessKeyedInCoordinatesRecords(List<List<string>> lStationRecords,
                                                                           string sRecordsSeparator,
                                                                           string sMissingValue)
        {
            DeleteAllRecordsFromTable("StagingStations");
            Dictionary<string, Point> dKeyedInStations = new Dictionary<string,Point> {};
            foreach (List<string> lRecord in lStationRecords)
            {
                string sRecordType = lRecord[0];
                List<string> lRecordInformation = GetRecordInformation(lRecord, sRecordsSeparator);

                if (String.Compare(sRecordType, CoordinateType.GridCoord.ToString()) == 0)
                {
                    //System.Diagnostics.Debug.Print(String.Format("{0} : {1}", sRecordType, (String.Join(" : ", lRecordInformation))));
                    string sPointName = lRecordInformation[2];

                    //check for missing northing, easting
                    if (RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[3], sMissingValue) == null || 
                        RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[4], sMissingValue) == null)
                    {
                        System.Diagnostics.Debug.Print(String.Format("LATITUDE AND LONGITUDE NULL: ({0}, {1})", lRecordInformation[3], lRecordInformation[4])); 
                        continue;
                    }

                    double dLocalNorthing = RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[3]);
                    double dLocalEasting = RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[4]);
                    double? dLocalElevation = RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[5], sMissingValue);
                    string sFeatureCode = "GridCoord";

                    if (this._dStations.Keys.Contains(sPointName))
                    {
                        double? dLatitude = this._dStations[sPointName].Latitude;
                        double? dLongitude = this._dStations[sPointName].Longitude;
                        double? dElevation = this._dStations[sPointName].Elevation;

                        Point pGridCoord = new Point(sPointName,
                            dLocalEasting,
                            dLocalNorthing,
                            dLocalElevation,
                            sFeatureCode,
                            dLongitude,
                            dLatitude,
                            dElevation);
                        dKeyedInStations[sPointName] = pGridCoord;
                        Point.StagePoint(pGridCoord);
                    }
                    else
                    {
                        throw new Exception(String.Format("grid coord: {0} could not be found in stations.", sPointName));
                    }
                }
                else if (String.Compare(sRecordType, CoordinateType.LLCoord.ToString()) == 0)
                {
                   // System.Diagnostics.Debug.Print(String.Format("{0} : {1}", sRecordType, (String.Join(" : ", lRecordInformation))));
                    string sPointName = lRecordInformation[2];
                    double? dLatitude = (DetermineWGS_84_Sign(RegularExpressions.GetAlphaCharacters(lRecordInformation[3])) * RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[3], sMissingValue));
                    double? dLongitude = (DetermineWGS_84_Sign(RegularExpressions.GetAlphaCharacters(lRecordInformation[4])) * RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[4], sMissingValue));
                    double? dElevation = (DetermineWGS_84_Sign(RegularExpressions.GetAlphaCharacters(lRecordInformation[5])) * RegularExpressions.GetSignDigitsAndDecimal(lRecordInformation[5], sMissingValue));
                    string sFeatureCode = "LLCoord";

                    if (this._dStations.Keys.Contains(sPointName))
                    {
                        double dLocalEasting = this._dStations[sPointName].LocalEasting;
                        double dLocalNorthing = this._dStations[sPointName].LocalNorthing;
                        double? dLocalElevation = this._dStations[sPointName].LocalElevation;

                        Point pLL_Coord = new Point(sPointName,
                                                    dLocalEasting,
                                                    dLocalNorthing,
                                                    dLocalElevation,
                                                    sFeatureCode,
                                                    dLongitude,
                                                    dLatitude,
                                                    dElevation);
                        dKeyedInStations[sPointName] = pLL_Coord;
                        Point.StagePoint(pLL_Coord);
                    }
                    else
                    {
                        throw new Exception(String.Format("ll coord: {0} could not be found in stations.", sPointName));
                    }
                }                
            }
            return dKeyedInStations;
        }

        private void DeleteAllRecordsFromTable(string sTableName)
        {
            string sStatement = String.Format(@"TRUNCATE TABLE dbo.{0}", sTableName);
            using (System.Data.SqlClient.SqlConnection dbConn = new System.Data.SqlClient.SqlConnection(Logging.sDB_Connection))//TODO:remove this constant
            {
                using (System.Data.SqlClient.SqlCommand dbCommand = new System.Data.SqlClient.SqlCommand(sStatement, dbConn))
                {
                    dbConn.Open();
                    int iResult = dbCommand.ExecuteNonQuery();
                }
            }
        }

        private List<GPS_Observation> ProcessGPS_Records(List<List<string>> lGPS_Records,
                                                         string sRecordsSeparator,
                                                         string sMissingValue)
        {
            DeleteAllRecordsFromTable("StagingGPS_Vectors");
            List<GPS_Observation> lGPS_Observations = new List<GPS_Observation> { };
            foreach (List<string> lRecord in lGPS_Records)
            {
                string sRecordType = lRecord[0];
                List<string> lRecordInformation = GetRecordInformation(lRecord, sRecordsSeparator);

                if (String.Compare(sRecordType, CoordinateType.Vector.ToString()) == 0)
                {
                    //System.Diagnostics.Debug.Print(String.Format("{0} : {1}", sRecordType, (String.Join(" : ", lRecordInformation))));
                    string sFromStation = lRecordInformation[2];
                    string sToStation = lRecordInformation[3];
                    double dECEF_dx = Convert.ToDouble(lRecordInformation[4]);
                    double dECEF_dy = Convert.ToDouble(lRecordInformation[5]);
                    double dECEF_dz = Convert.ToDouble(lRecordInformation[6]);
                    double dCovarianceXX = Convert.ToDouble(lRecordInformation[7]);
                    double dCovarianceXY = Convert.ToDouble(lRecordInformation[8]);
                    double dCovarianceXZ = Convert.ToDouble(lRecordInformation[9]);
                    double dCovarianceYY = Convert.ToDouble(lRecordInformation[10]);
                    double dCovarianceYZ = Convert.ToDouble(lRecordInformation[11]);
                    double dCovarianceZZ = Convert.ToDouble(lRecordInformation[12]);
                    double dFromAntennaHeight = Convert.ToDouble(lRecordInformation[13]);
                    double dToAntennaHeight = Convert.ToDouble(lRecordInformation[14]);
                    string sStatus = lRecordInformation[15];
                    double? dRatio = CheckForMissingValue(lRecordInformation[16], sMissingValue);
                    double dRMS = Convert.ToDouble(lRecordInformation[17]);
                    string sReferenceVariable = lRecordInformation[18];
                    string sStartDate = String.Join(":", lRecordInformation[19], lRecordInformation[20]);
                    DateTime dtStart = DateTime.ParseExact(sStartDate.Substring(0, sStartDate.Length-2), @"%dd %MM %yyyy:%HH %mm %ss", System.Globalization.CultureInfo.InvariantCulture);
                    string sEndDate = String.Join(":", lRecordInformation[21], lRecordInformation[22]);
                    DateTime dtEnd = DateTime.ParseExact(sEndDate.Substring(0, sEndDate.Length - 2), @"%dd %MM %yyyy:%HH %mm %ss", System.Globalization.CultureInfo.InvariantCulture);

                    GPS_Observation pObservation = new GPS_Observation(sFromStation,
                                                                       sToStation,
                                                                       dECEF_dx,
                                                                       dECEF_dy,
                                                                       dECEF_dz,
                                                                       dCovarianceXX,
                                                                       dCovarianceXY,
                                                                       dCovarianceXZ,
                                                                       dCovarianceYY,
                                                                       dCovarianceYZ,
                                                                       dCovarianceZZ,
                                                                       dFromAntennaHeight,
                                                                       dToAntennaHeight,
                                                                       sStatus,
                                                                       dRatio,
                                                                       dRMS,
                                                                       sReferenceVariable,
                                                                       dtStart,
                                                                       dtEnd);
                    lGPS_Observations.Add(pObservation);
                    GPS_Observation.StageGPS_Vector(pObservation);
                }
            }

            return lGPS_Observations;
        }

        private List<SideShot> ProcessTerrestrialRecords(List<List<string>> lGPS_Records,
                                                         string sRecordsSeparator,
                                                         string sMissingValue,
                                                         Dictionary<string, Point> dStations)
        {
            List<SideShot> lTerrestrialObservations = new List<SideShot> { };
            foreach (List<string> lRecord in lGPS_Records)
            {
                string sRecordType = lRecord[0];
                List<string> lRecordInformation = GetRecordInformation(lRecord, sRecordsSeparator);

                if (String.Compare(sRecordType, CoordinateType.TerrObs.ToString()) == 0)
                {
                    //TODO: handle null values
                    //System.Diagnostics.Debug.Print(String.Format("{0} : {1}", sRecordType, (String.Join(" : ", lRecordInformation))));
                    string sInstrumentPoint = lRecordInformation[2];
                    string sBacksightPoint = lRecordInformation[3];
                    string sForesightPoint = lRecordInformation[4];
                    double? dHorizontalAngle = CheckForMissingValue(lRecordInformation[5], sMissingValue);
                    double dHorizontalAngleStandardError = Convert.ToDouble(lRecordInformation[6]);
                    double? dZenithAngle = CheckForMissingValue(lRecordInformation[7], sMissingValue);
                    double dZenithAngleStandardError = Convert.ToDouble(lRecordInformation[8]);
                    double? dSlopeDistance = CheckForMissingValue(lRecordInformation[9], sMissingValue);
                    double dSlopeDistanceStandardError = Convert.ToDouble(lRecordInformation[10]);
                    double? dPrismConstant = CheckForMissingValue(lRecordInformation[11], sMissingValue);
                    double dInstrumentHeight = Convert.ToDouble(lRecordInformation[12]);
                    double? dTargetHeight = CheckForMissingValue(lRecordInformation[13], sMissingValue);
                    SideShot pSideShot = new SideShot(sInstrumentPoint,
                                                      sBacksightPoint,
                                                      sForesightPoint,
                                                      dHorizontalAngle,
                                                      dHorizontalAngleStandardError,
                                                      dZenithAngle,
                                                      dZenithAngleStandardError,
                                                      dSlopeDistance,
                                                      dSlopeDistanceStandardError,
                                                      dPrismConstant,
                                                      dInstrumentHeight,
                                                      dTargetHeight,
                                                      sMissingValue);
                    
                    pSideShot.GetPointInformation(dStations);
                    Point.StagePoint(pSideShot.Point);
                    lTerrestrialObservations.Add(pSideShot);
                }
            }
            return lTerrestrialObservations;
        }

        public int FindDuplicates(List<GPS_Observation> lGPS_Observations)
        {
            int iDuplicates = 0;
            List<Tuple<string, string>> lDuplicates = new List<Tuple<string, string>> { };

            foreach (GPS_Observation pGPS in lGPS_Observations)
            {
                Tuple<string, string> tGPS_Control = new Tuple<string, string>(pGPS.FromStation,
                    pGPS.ToStation);
                if (lDuplicates.Contains(tGPS_Control))
                {
                    iDuplicates += 1;
                }
                else
                {
                    lDuplicates.Add(tGPS_Control);
                }
            }
            return iDuplicates;
        }

        public int FindDuplicates(List<SideShot> lTerrestrialObservations)
        {
            int iDuplicates = 0;
            List<Tuple<string, string, string>> lDuplicates = new List<Tuple<string, string, string>> {};

            foreach (SideShot pSideshot in lTerrestrialObservations)
            {
                Tuple<string, string, string> tTerrestrialControl = new Tuple<string, string, string> (pSideshot.InstrumentPoint,
                                                                                                       pSideshot.BacksightPoint,
                                                                                                       pSideshot.ForesightPoint);
                if (lDuplicates.Contains(tTerrestrialControl))
                {
                    iDuplicates += 1;
                }
                else
                {
                    lDuplicates.Add(tTerrestrialControl);
                }

            }            
            return iDuplicates;
        }

        public enum ControlNetworkLevel
        {
            Primary,
            Secondary,
            Tertiary,
            Unknown
        }

        public static ControlNetworkLevel GetControlLevelNetwork(string sPointName)
        {
            ControlNetworkLevel eControlNetworkLevel = ControlNetworkLevel.Unknown;
            if (String.IsNullOrEmpty(sPointName) == false)
            {
                if (sPointName.Length >= 2)
                {
                    string sControlLevelCharacter = sPointName.Substring(1, 1);

                    switch (sControlLevelCharacter.ToUpper())
                    {
                        case "P":
                            eControlNetworkLevel = ControlNetworkLevel.Primary;
                            break;
                        case "S":
                            eControlNetworkLevel = ControlNetworkLevel.Secondary;
                            break;
                        case "T":
                            eControlNetworkLevel = ControlNetworkLevel.Tertiary;
                            break;
                        default:
                            //throw new Exception("cannot classify control level network of point");
                            Logging.InsertToOddPointsDB(sPointName);
                            break;
                    }
                }
            }
            return eControlNetworkLevel;
        }

        public List<SideShot> SummarizeRiverSection(Tuple<int, int> tRiverMile)
        {
            List<SideShot> lInRiverSection = new List<SideShot> ();
            foreach (SideShot pObservation in this._lTerrestrialObservations)
            {
                if (pObservation.Point.RiverMile >= tRiverMile.Item1 && pObservation.Point.RiverMile <= tRiverMile.Item2)
                {
                    lInRiverSection.Add(pObservation);
                }
            }
            return lInRiverSection;
        }

        public List<GPS_Observation> SummarizeRiverSection(Tuple<int, int> tRiverMile,
                                                           Dictionary<string, Point> dStations)
        {
            List<GPS_Observation> lInRiverSection = new List<GPS_Observation>();
            foreach (GPS_Observation pObservation in this._lGPSObservations)
            {
                Tuple<double, double> tObservationRiverMiles = pObservation.GetRiverMiles(dStations);
                if ((tObservationRiverMiles.Item1 >= tRiverMile.Item1 && tObservationRiverMiles.Item1 <= tRiverMile.Item2) &&
                    (tObservationRiverMiles.Item2 >= tRiverMile.Item1 && tObservationRiverMiles.Item2 <= tRiverMile.Item2))
                {
                    lInRiverSection.Add(pObservation);
                }
            }
            return lInRiverSection;
        }


        private int GetRecordCountInRiverMile(string sTableName, Tuple<int, int> tRiverMile)
        {
            int iRecord = 0;
            string sStatement = String.Format(@"SELECT *
                                                FROM dbo.{0}
                                                WHERE RiverMile > {1} AND RiverMile < {2}", sTableName, tRiverMile.Item1, tRiverMile.Item2);
            using (System.Data.SqlClient.SqlConnection dbConn = new System.Data.SqlClient.SqlConnection(Logging.sDB_Connection))//TODO:Get rid of this hard coded path
            {
                using (System.Data.SqlClient.SqlCommand dbCommand = new System.Data.SqlClient.SqlCommand(sStatement, dbConn))
                {
                    dbConn.Open();
                    System.Data.SqlClient.SqlDataReader dbReader = dbCommand.ExecuteReader();
                    if (dbReader.HasRows == true)
                    {
                        while (dbReader.Read())
                        {
                            iRecord += 1;
                        }
                    }
                }
            }
            return iRecord;
        }

    }
}
