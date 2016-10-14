using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control_network_processing
{
    public class Point
    {
        //constructor values
        private string _sPointName;
        private double _dLocalEasting;
        private double _dLocalNorthing;
        private double? _dLocalElevation;
        private string _sFeatureCode;
        private double? _dLongitude;
        private double? _dLatitude;
        private double? _dElevation;

        //derived values
        private Survey.ControlNetworkLevel _eControlNetworkLevel;
        private double _dRiverMile; 
        private string _sPointUse;
        private string _sMonumentation;

        //joined values
        private double _dMajorAxis;
        private double _dMinorAxis;
        private string _sOrientation;
        private double _dSigmaX;
        private double _dSigmaY;
        private double _SigmaH;
        private double _dCircularError95Pct;

        public Point(string sPointName,
                     double dLocalEasting,
                     double dLocalNorthing,
                     double? dLocalElevation,
                     string sFeatureCode,
                     double? dLongitude = null,
                     double? dLatitude = null,
                     double? dElevation = null)
        {
            this._sPointName = sPointName;
            this._dLocalEasting = dLocalEasting;
            this._dLocalNorthing = dLocalNorthing;
            this._dLocalElevation = dLocalElevation;
            this._sFeatureCode = sFeatureCode;
            this._dLongitude = dLongitude;
            this._dLatitude = dLatitude;
            this._dElevation = dElevation;
            this._eControlNetworkLevel = Survey.GetControlLevelNetwork(sPointName);
            List<string> lDummy = new List<string> ();
            this._dRiverMile = GetRiverMile(sPointName, lDummy);
            if (sPointName.Length >= 3)
            {
                string sPointCode = sPointName.Substring(2, 1);
                GetPointUseInfo(sPointCode, out _sPointUse, out _sMonumentation);
            }
            else
            {
                Logging.InsertToOddPointsDB(sPointName);
            }
        }

        public string PointName { get { return _sPointName; } }
        public  double LocalEasting { get { return _dLocalEasting; } }
        public  double LocalNorthing { get { return _dLocalNorthing; } }
        public  double? LocalElevation { get { return _dLocalElevation;} }
        public  string FeatureCode { get { return _sFeatureCode; } }
        public double? Longitude { get { return _dLongitude; } }
        public double? Latitude { get { return _dLatitude; } }
        public  double? Elevation { get { return _dElevation; } }

        public Survey.ControlNetworkLevel NetworkLevel { get { return _eControlNetworkLevel; } }
        public double RiverMile { get { return _dRiverMile; } }
        public string PointUse { get { return _sPointUse; } }
        public string Monumentation { get { return _sMonumentation; } }

        private double GetRiverMile(string sPointName, List<string> lExcludePoints)
        {
            double dRiverMile = 0;
            if (lExcludePoints.Contains(sPointName) == false)
            {
                if (sPointName.Length > 4)
                {
                    string sRiverMileInfo = sPointName.Substring(3, sPointName.Length - 4);
                    string sRiverSide = sPointName.Substring(sPointName.Length - 1);
                    bool bContainsDigitsAndDecimal = RegularExpressions.CheckIfContainsDigitsAndDecimal(sPointName);
                    if (bContainsDigitsAndDecimal == true)
                    {
                        dRiverMile = RegularExpressions.GetSignDigitsAndDecimal(sPointName);
                        dRiverMile = Math.Round((dRiverMile / 1000), 3);
                    }
                    else
                    {
                        Logging.InsertToOddPointsDB(sPointName);
                    }
                }
                else
                {
                    Logging.InsertToOddPointsDB(sPointName);
                }
            }
            return dRiverMile;
        }

        private void GetPointUseInfo(string sPointCode, out string sPointUse, out string sMonumentation)
        {
            sPointUse = null; sMonumentation = null;
            string sStatement = String.Format(@"SELECT PointUse, Monumentation
                                                FROM dbo.PointUse
                                                WHERE Code LIKE '{0}'", sPointCode);
            using (System.Data.SqlClient.SqlConnection dbConn = new System.Data.SqlClient.SqlConnection(Logging.sDB_Connection))//TODO:remove this constant
            {
                using (System.Data.SqlClient.SqlCommand dbCommand = new System.Data.SqlClient.SqlCommand(sStatement, dbConn))
                {
                    dbConn.Open();
                    System.Data.SqlClient.SqlDataReader dbReader = dbCommand.ExecuteReader();
                    if (dbReader.HasRows == true)
                    {
                        if (dbReader.Read())
                        {
                            sPointUse = DBNull.Value == dbReader["PointUse"] ? null : dbReader["PointUse"].ToString();
                            sMonumentation = DBNull.Value == dbReader["Monumentation"] ? null : dbReader["Monumentation"].ToString();
                        }
                    }
                }
            }
        }

        public static void StagePoint(Point pPoint)
        {
            string sStatement = @"INSERT INTO dbo.StagingStations(PointName, Northing, Easting, Latitude, 
                                                                   Longitude, EllipseZ, Height, AdjustmentYear, 
                                                                   RiverMile, DatabaseName, PointCode, Network, 
                                                                   PointUse, Monumentation)
                                  VALUES(@PointName, @Northing, @Easting, @Latitude, 
                                          @Longitude, @EllipseZ, @Height, @AdjustmentYear, 
                                          @RiverMile, @DatabaseName, @PointCode, @Network, 
                                          @PointUse, @Monumentation)";
            using (System.Data.SqlClient.SqlConnection dbConn = new System.Data.SqlClient.SqlConnection(Logging.sDB_Connection))//TODO:remove this constant
            {
                using (System.Data.SqlClient.SqlCommand dbCommand = new System.Data.SqlClient.SqlCommand(sStatement, dbConn))
                {
                    dbCommand.Parameters.Add("PointName", System.Data.SqlDbType.NChar).Value = pPoint.PointName;
                    dbCommand.Parameters.Add("Northing", System.Data.SqlDbType.Float).Value = pPoint.LocalNorthing;
                    dbCommand.Parameters.Add("Easting", System.Data.SqlDbType.Float).Value = pPoint.LocalEasting;
                    dbCommand.Parameters.Add("Latitude", System.Data.SqlDbType.Float).Value = pPoint.Latitude == null ? 0.0 : pPoint.Latitude;
                    dbCommand.Parameters.Add("Longitude", System.Data.SqlDbType.Float).Value = pPoint.Longitude == null ? 0.0 : pPoint.Longitude;
                    dbCommand.Parameters.Add("EllipseZ", System.Data.SqlDbType.Float).Value = pPoint.Elevation == null ? 0.0 : pPoint.Elevation;
                    dbCommand.Parameters.Add("Height", System.Data.SqlDbType.Float).Value = pPoint.LocalElevation == null ? 0.0 : pPoint.LocalElevation;
                    //dbCommand.Parameters.Add("MajorAxis", System.Data.SqlDbType.Float).Value = null;
                    //dbCommand.Parameters.Add("MinorAxis", System.Data.SqlDbType.Float).Value = null;
                    //dbCommand.Parameters.Add("Orientation", System.Data.SqlDbType.Text).Value = null;
                    //dbCommand.Parameters.Add("SigmaX", System.Data.SqlDbType.Float).Value = null;
                    //dbCommand.Parameters.Add("SigmaY", System.Data.SqlDbType.Float).Value = null;
                    //dbCommand.Parameters.Add("SigmaH", System.Data.SqlDbType.Float).Value = null;
                    //dbCommand.Parameters.Add("CircularError95Pct", System.Data.SqlDbType.Float).Value = null;
                    dbCommand.Parameters.Add("AdjustmentYear", System.Data.SqlDbType.Int).Value = DateTime.Now.Year;
                    dbCommand.Parameters.Add("RiverMile", System.Data.SqlDbType.Float).Value = pPoint.RiverMile;
                    dbCommand.Parameters.Add("DatabaseName", System.Data.SqlDbType.Text).Value = "Test";
                    dbCommand.Parameters.Add("PointCode", System.Data.SqlDbType.NChar).Value = "123";
                    dbCommand.Parameters.Add("Network", System.Data.SqlDbType.NChar).Value = pPoint.NetworkLevel.ToString();
                    dbCommand.Parameters.Add("PointUse", System.Data.SqlDbType.Text).Value = pPoint.PointUse == null ? "None" : pPoint.PointUse;
                    dbCommand.Parameters.Add("Monumentation", System.Data.SqlDbType.Text).Value = pPoint.Monumentation == null ? "None" : pPoint.Monumentation;

                    dbConn.Open();
                    int iResult = dbCommand.ExecuteNonQuery();
                }
            }


        }
    
    
    } //class end
}
