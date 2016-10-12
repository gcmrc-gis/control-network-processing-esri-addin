using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_network_processing
{
    public class SideShot
    {
        private string _sInstrumentPoint;
        private string _sBacksightPoint;
        private string _sForesightPoint;
        private double? _dHorizontalAngle;
        private double _dHorizontalAngleStandardError;
        private double? _dZenithAngle;
        private double _dZenithAngleStandardError;
        private double? _dSlopeDistance;
        private double _dSlopeDistanceStandardError;
        private double? _dPrismConstant;
        private double _dInstrumentHeight;
        private double? _dTargetHeight;
        private string _sMissingValue;

        public SideShot(string sInstrumentPoint,
                        string sBacksightPoint,
                        string sForesightPoint,
                        double? dHorizontalAngle,
                        double dHorizontalAngleStandardError,
                        double? dZenithAngle,
                        double dZenithAngleStandardError,
                        double? dSlopeDistance,
                        double dSlopeDistanceStandardError,
                        double? dPrismConstant,
                        double dInstrumentHeight,
                        double? dTargetHeight,
                        string sMissingValue)
        {
            _sInstrumentPoint = sInstrumentPoint;
            _sBacksightPoint = sBacksightPoint;
            _sForesightPoint = sForesightPoint;
            _dHorizontalAngle = dHorizontalAngle;
            _dHorizontalAngleStandardError = dHorizontalAngleStandardError;
            _dZenithAngle = dZenithAngle;
            _dZenithAngleStandardError = dZenithAngleStandardError;
            _dSlopeDistance = dSlopeDistance;
            _dSlopeDistanceStandardError = dSlopeDistanceStandardError;
            _dPrismConstant = dPrismConstant;
            _dInstrumentHeight = dInstrumentHeight;
            _dTargetHeight = dTargetHeight;
            _sMissingValue = sMissingValue;
        }

        public string InstrumentPoint { get { return _sInstrumentPoint; } }
        public string BacksightPoint { get { return _sBacksightPoint; } }
        public string ForesightPoint { get { return _sForesightPoint; } }

    }
}
