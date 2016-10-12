using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_network_processing
{
    public class GPS_Observation
    {
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
            _sReferenceVariable = sReferenceVariable;
            _dtStart = dtStart;
            _dtEnd = dtEnd;
        }

        public string FromStation { get { return _sFromStation; } }
        public string ToStation { get { return _sToStation; } }

    }
}
