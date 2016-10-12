using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace control_network_processing
{
    public class Point
    {
        private string _sPointName;
        private double _dLocalEasting;
        private double _dLocalNorthing;
        private double? _dLocalElevation;
        private string _sFeatureCode;
        private double? _dLongitude;
        private double? _dLatitude;
        private double? _dElevation;

        private ControlNetworkLevel _eControlNetworkLevel;
        private double _dRiverMile; 

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
            this._eControlNetworkLevel = GetControlLevelNetwork(sPointName);
            List<string> lDummy = new List<string> ();
            this._dRiverMile = GetRiverMile(sPointName, lDummy);

        }

        public string PointName { get { return _sPointName; } }
        public  double LocalEasting { get { return _dLocalEasting; } }
        public  double LocalNorthing { get { return _dLocalNorthing; } }
        public  double? LocalElevation { get { return _dLocalElevation;} }
        public  string FeatureCode { get { return _sFeatureCode; } }
        public double? Longitude { get { return _dLongitude; } }
        public double? Latitude { get { return _dLatitude; } }
        public  double? Elevation { get { return _dElevation; } }

        public ControlNetworkLevel NetworkLevel { get { return _eControlNetworkLevel; } }
        public double RiverMile { get { return _dRiverMile; } }

        public enum ControlNetworkLevel
        {
            Primary,
            Secondary,
            Tertiary,
            Unknown
        }

        private ControlNetworkLevel GetControlLevelNetwork(string sPointName)
        {
            ControlNetworkLevel eControlNetworkLevel = ControlNetworkLevel.Unknown;
            if (String.IsNullOrEmpty(sPointName) == false)
            {
                if (sPointName.Length >= 2)
                {
                    string sControlLevelCharacter = sPointName.Substring(1,1);
                    
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
                            Logging.OddPointsLog(Logging.sOddPointsFilePath, sPointName);
                            break;
                    }
                }
            }
            return eControlNetworkLevel;
        }

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
                        Logging.OddPointsLog(Logging.sOddPointsFilePath, sPointName);
                    }
                }
                else
                {
                    Logging.OddPointsLog(Logging.sOddPointsFilePath, sPointName);
                }
            }
            return dRiverMile;
        }

    }



}
