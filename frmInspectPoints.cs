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
        private BindingSource _pObservationsBindingSource = new BindingSource();

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

            cmbObservationType.Items.Add(new ComboBoxItem(Survey.CoordinateType.GPS, "GPS"));
            cmbObservationType.Items.Add(new ComboBoxItem(Survey.CoordinateType.TerrObs, "Terrestrial"));
            
        }

        private void dgvStations_SelectionChanged(object sender, EventArgs e)
        {
            //TODO: Consider whether it is best or not to hook this to the underlying database rather than a temporary structure
            if (dgvStations.CurrentCell.RowIndex >= 0)
            {
                Point pStation = (Point)dgvStations.Rows[dgvStations.CurrentCell.RowIndex].DataBoundItem;

                dgvObservations.Rows.Clear();

                if (cmbObservationType.SelectedIndex != -1)
                {
                    ComboBoxItem cbItem = (ComboBoxItem)cmbObservationType.SelectedItem;
                    Survey.CoordinateType eCoordinateType = (Survey.CoordinateType)cbItem.Value;
                    int iDuplicates = 0;

                    switch (eCoordinateType)
                    {
                        case Survey.CoordinateType.GPS:
                            foreach (GPS_Observation pGPS in _Survey.GPS_Observations)
                            {
                                if (String.Compare(pGPS.FromStation, pStation.PointName) == 0)
                                {
                                    _pObservationsBindingSource.Add(pGPS);
                                }
                            }
                            List<GPS_Observation> lGPS_Observations = _pObservationsBindingSource.List.Cast<GPS_Observation>().ToList();
                            iDuplicates = _Survey.FindDuplicates(lGPS_Observations);
                            lblDuplicates.Text = String.Format("Duplicates at this station: {0}", iDuplicates);
                            break;

                        case Survey.CoordinateType.TerrObs:
                            foreach (SideShot pSideShot in _Survey.TerrestrialObservations)
                            {
                                if (String.Compare(pSideShot.InstrumentPoint, pStation.PointName) == 0)
                                {
                                    _pObservationsBindingSource.Add(pSideShot);
                                }
                            }
                            List<SideShot> lTerrestrial_Observations = _pObservationsBindingSource.List.Cast<SideShot>().ToList();
                            iDuplicates = _Survey.FindDuplicates(lTerrestrial_Observations);
                            lblDuplicates.Text = String.Format("Duplicates at this station: {0}", iDuplicates);
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        private void cmbObservationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbObservationType.SelectedIndex != -1)
            {
                ComboBoxItem cbItem = (ComboBoxItem)cmbObservationType.SelectedItem;
                Survey.CoordinateType eCoordinateType = (Survey.CoordinateType)cbItem.Value;              

                switch (eCoordinateType)
                {
                    case Survey.CoordinateType.GPS:
                        _pObservationsBindingSource.DataSource = typeof(control_network_processing.GPS_Observation);
                        break;
                    case Survey.CoordinateType.TerrObs:
                        _pObservationsBindingSource.DataSource = typeof(control_network_processing.SideShot);
                        break;
                    default:
                        break;
                }
                dgvObservations.DataSource = _pObservationsBindingSource;
            }
        }
    }
}
