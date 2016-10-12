using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace control_network_processing
{
    public partial class frmInspectPoints : Form
    {
        private Survey _Survey;

        public frmInspectPoints(Survey pSurvey)
        {
            InitializeComponent();

            _Survey = pSurvey;

        }

        private void frmInspectPoints_Load(object sender, EventArgs e)
        {

            foreach (Point pStation in _Survey.Stations.Values)
            {
                pointBindingSource.Add(pStation);
            }

            dgvStations.SelectionChanged += dgvStations_SelectionChanged;

        }

        private void dgvStations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStations.CurrentCell.RowIndex >= 0)
            {
                Point pStation = (Point)dgvStations.Rows[dgvStations.CurrentCell.RowIndex].DataBoundItem;
                sideShotBindingSource.Clear();
                foreach (SideShot pSideShot in _Survey.TerrestrialObservations)
                {
                    if (String.Compare(pSideShot.InstrumentPoint, pStation.PointName) == 0)
                    {
                        sideShotBindingSource.Add(pSideShot);
                    }
                }
                gPSObservationBindingSource.Clear();
                foreach (GPS_Observation pGPS in _Survey.GPS_Observations)
                {
                    if (String.Compare(pGPS.FromStation, pStation.PointName) == 0)
                    {
                        gPSObservationBindingSource.Add(pGPS);
                    }
                }
            }
        }


    }
}
