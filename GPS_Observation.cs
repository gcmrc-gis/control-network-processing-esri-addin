using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_network_processing
{
    public class GPS_Observation
    {
        //contructor variables
        private string _sFromStation;
        private string _sToStation;
        private double _dECEF_dx;
        private double _dECEF_dy;
        private double _dECEF_dz;
        private double _dCovarianceXX;
        private double _dCovarianceXY;
        private double _dCovarianceXZ;
        private double _dCovarianceYY;
        private double _dCovarianceYZ;
        private double _dCovarianceZZ;
        private double _dFromAntennaHeight;
        private double _dToAntennaHeight;
        private string _sStatus;
        private double? _dRatio;
        private double _dRMS;
        private string _sReferenceVariable;
        private DateTime _dtStart;
        private DateTime _dtEnd;

        //derived variables
        private string _sNetworkTag;
        private Survey.ControlNetworkLevel _eControlNetworkLevel;
        private string _sObservationType;

        public GPS_Observation(string sFromStation,
                               string sToStation,
                               double dECEF_dx,
                               double dECEF_dy,
                               double dECEF_dz,
                               double dCovarianceXX,
                               double dCovarianceXY,
                               double dCovarianceXZ,
                               double dCovarianceYY,
                               double dCovarianceYZ,
                               double dCovarianceZZ,
                               double dFromAntennaHeight,
                               double dToAntennaHeight,
                               string sStatus,
                               double? dRatio,
                               double dRMS,
                               string sReferenceVariable,
                               DateTime dtStart,
                               DateTime dtEnd)
        {
            _sFromStation = sFromStation;
            _sToStation = sToStation;
            _dECEF_dx = dECEF_dx;
            _dECEF_dy = dECEF_dy;
            _dECEF_dz = dECEF_dz;
            _dCovarianceXX = dCovarianceXX;
            _dCovarianceXY = dCovarianceXY;
            _dCovarianceXZ = dCovarianceXZ;
            _dCovarianceYY = dCovarianceYY;
            _dCovarianceYZ = dCovarianceYZ;
            _dCovarianceZZ = dCovarianceZZ;
            _dFromAntennaHeight = dFromAntennaHeight;
            _dToAntennaHeight = dToAntennaHeight;
            _sStatus = sStatus;
            _dRatio = dRatio;
            _dRMS = dRMS;
            _sReferenceVariable = sReferenceVariable;
            _dtStart = dtStart;
            _dtEnd = dtEnd;

            _sNetworkTag = "TGO";
            _eControlNetworkLevel = Survey.GetControlLevelNetwork(sToStation);
            _sObservationType = "GPS";
        }

        public string FromStation { get { return _sFromStation; } }
        public string ToStation { get { return _sToStation; } }
        public double ECEF_dx { get { return _dECEF_dx; } }
        public double ECEF_dy { get { return _dECEF_dy; } }
        public double ECEF_dz { get { return _dECEF_dz; } }
        public double CovarianceXX { get { return _dCovarianceXX; } }
        public double CovarianceXY { get { return _dCovarianceXY; } }
        public double CovarianceXZ { get { return _dCovarianceXZ; } }
        public double CovarianceYY { get { return _dCovarianceYY; } }
        public double CovarianceYZ { get { return _dCovarianceYZ; } }
        public double CovarianceZZ { get { return _dCovarianceZZ; } }
        public double FromAntennaHeight { get { return _dFromAntennaHeight; } }
        public double ToAntennaHeight { get { return _dToAntennaHeight; } }
        public string Status { get { return _sStatus; } }
        public double? Ratio { get { return _dRatio; } }
        public double RMS { get { return _dRMS; } }
        public string ReferenceVariable { get { return _sReferenceVariable; } }
        public DateTime Start { get { return _dtStart; } }
        public DateTime End { get { return _dtEnd; } }

        public string NetworkTag { get { return _sNetworkTag; } }
        public Survey.ControlNetworkLevel NetworkLevel { get { return _eControlNetworkLevel; } }
        public string ObservationType { get { return _sObservationType; } }

        public static void StageGPS_Vector(GPS_Observation pGPS)
        {
            string sStatement = @"INSERT INTO dbo.StagingGPS_Vectors(FromStation, ToStation, NetworkTag, 
                                                                     Network, ObservationType, ECEF_DX, 
                                                                     ECEF_DY, ECEF_DZ, CovarianceXX, 
                                                                     CovarianceXY, CovarianceXZ, CovarianceYY, 
                                                                     CovarianceYZ, CovarianceZZ, FromAntennaHeight, 
                                                                     ToAntennaHeight, Status, Ratio, RMS, 
                                                                     ReferenceVariable, StartTime, EndTime)
                                  VALUES(@FromStation, @ToStation, @NetworkTag, 
                                         @Network, @ObservationType, @ECEF_DX, 
                                         @ECEF_DY, @ECEF_DZ, @CovarianceXX, 
                                         @CovarianceXY, @CovarianceXZ, @CovarianceYY, 
                                         @CovarianceYZ, @CovarianceZZ, @FromAntennaHeight, 
                                         @ToAntennaHeight, @Status, @Ratio, @RMS, 
                                         @ReferenceVariable, @StartTime, @EndTime)";
            using (System.Data.SqlClient.SqlConnection dbConn = new System.Data.SqlClient.SqlConnection(Logging.sDB_Connection))//TODO:remove this constant
            {
                using (System.Data.SqlClient.SqlCommand dbCommand = new System.Data.SqlClient.SqlCommand(sStatement, dbConn))
                {
                    dbCommand.Parameters.Add("FromStation", System.Data.SqlDbType.NChar).Value = pGPS.FromStation;
                    dbCommand.Parameters.Add("ToStation", System.Data.SqlDbType.NChar).Value = pGPS.ToStation;
                    dbCommand.Parameters.Add("NetworkTag", System.Data.SqlDbType.NChar).Value = pGPS._sNetworkTag;
                    dbCommand.Parameters.Add("Network", System.Data.SqlDbType.NChar).Value = pGPS.NetworkLevel.ToString();
                    dbCommand.Parameters.Add("ObservationType", System.Data.SqlDbType.NChar).Value = pGPS.ObservationType;
                    dbCommand.Parameters.Add("ECEF_DX", System.Data.SqlDbType.Float).Value = pGPS.ECEF_dx;
                    dbCommand.Parameters.Add("ECEF_DY", System.Data.SqlDbType.Float).Value = pGPS.ECEF_dy;
                    dbCommand.Parameters.Add("ECEF_DZ", System.Data.SqlDbType.Float).Value = pGPS._dECEF_dz;
                    dbCommand.Parameters.Add("CovarianceXX", System.Data.SqlDbType.Float).Value = pGPS.CovarianceXX;
                    dbCommand.Parameters.Add("CovarianceXY", System.Data.SqlDbType.Float).Value = pGPS.CovarianceXY;
                    dbCommand.Parameters.Add("CovarianceXZ", System.Data.SqlDbType.Float).Value = pGPS.CovarianceXZ;
                    dbCommand.Parameters.Add("CovarianceYY", System.Data.SqlDbType.Float).Value = pGPS.CovarianceYY;
                    dbCommand.Parameters.Add("CovarianceYZ", System.Data.SqlDbType.Float).Value = pGPS.CovarianceYZ;
                    dbCommand.Parameters.Add("CovarianceZZ", System.Data.SqlDbType.Float).Value = pGPS.CovarianceZZ;
                    dbCommand.Parameters.Add("FromAntennaHeight", System.Data.SqlDbType.Float).Value = pGPS.FromAntennaHeight;
                    dbCommand.Parameters.Add("ToAntennaHeight", System.Data.SqlDbType.Float).Value = pGPS.ToAntennaHeight;
                    dbCommand.Parameters.Add("Status", System.Data.SqlDbType.Text).Value = pGPS.Status;
                    dbCommand.Parameters.Add("Ratio", System.Data.SqlDbType.Float).Value = pGPS.Ratio == null ? 0.0 : pGPS.Ratio;
                    dbCommand.Parameters.Add("RMS", System.Data.SqlDbType.Float).Value = pGPS.RMS;
                    dbCommand.Parameters.Add("ReferenceVariable", System.Data.SqlDbType.Text).Value = pGPS.ReferenceVariable;
                    dbCommand.Parameters.Add("StartTime", System.Data.SqlDbType.DateTime).Value = pGPS.Start;
                    dbCommand.Parameters.Add("EndTime", System.Data.SqlDbType.DateTime).Value = pGPS.End;
                    
                    dbConn.Open();
                    int iResult = dbCommand.ExecuteNonQuery();
                }
            }
        }

        public Tuple<double, double> GetRiverMiles(Dictionary<string, Point> dStations)
        {
            if (dStations.Keys.Contains(this.FromStation) && dStations.Keys.Contains(this.ToStation))
            {
                Point pFromStation = dStations[this.FromStation];
                Point pToStation = dStations[this.ToStation];
                return new Tuple<double, double>(pFromStation.RiverMile, pToStation.RiverMile);
            }
            else
            {
                throw new Exception("from and to gps points are not in provided list of stations");
            }
        }


    }//class end
}
