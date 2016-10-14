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
    public partial class frmControlNetworkProcessing : Form
    {
        private Survey _Survey;

        public frmControlNetworkProcessing()
        {
            InitializeComponent();
        }

        private void btnOpenSurveyFile_Click(object sender, EventArgs e)
        {
            FileDialog pFileDialog = new System.Windows.Forms.OpenFileDialog();
            pFileDialog.Filter = "asc files (*.asc)|*.asc|All files (*.*)|*.*";
            pFileDialog.InitialDirectory = @"U:\projects\survey\control-network\data\raw";
            DialogResult pResult = pFileDialog.ShowDialog();

            Cursor.Current = Cursors.WaitCursor;

            if (pResult == DialogResult.OK)
            {
                string sFilePath = pFileDialog.FileName;
                if (System.IO.File.Exists(sFilePath))
                {
                    txtSurveyFile.Text = sFilePath;
                    _Survey = new Survey(sFilePath, "");

                    //TODO:spatial filters
                    dgvRiverSections.Rows.Clear();

                    foreach (Tuple<int, int> tRiverMile in Definitions.lTraverseRiverMiles)
                    {
                        List<SideShot> lTerrestrialObservations = _Survey.SummarizeRiverSection(tRiverMile);
                        int iTerrestrialDuplicates = _Survey.FindDuplicates(lTerrestrialObservations);
                        List<GPS_Observation> lGPS_Observations = _Survey.SummarizeRiverSection(tRiverMile,
                                                                                                _Survey.Stations);

                        int iGPSDuplicates = _Survey.FindDuplicates(lGPS_Observations);
                        dgvRiverSections.Rows.Add(String.Format("RM: {0} to {1}", tRiverMile.Item1, tRiverMile.Item2),
                                                    lGPS_Observations.Count,
                                                    iGPSDuplicates,
                                                    lTerrestrialObservations.Count,
                                                    iTerrestrialDuplicates,
                                                    false);
                    }

                    //TODO: push down all of the network type, observation type, etc. currently done when creating a GIS object
                    //and make that a method for Sideshot and GPS_Observation
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //string sTDXF_FilePath = @"U:\projects\survey\control-network\data\raw\2016_0216_TDXF_GCD-BAC.asc";//NA2011_primary TDXF.asc";//
            if (String.IsNullOrEmpty(txtSurveyFile.Text) == false)
            {
                string sTrimbleFilePath = txtSurveyFile.Text;
                if (System.IO.File.Exists(sTrimbleFilePath))
                {

                }
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmInspectPoints frm = new frmInspectPoints(_Survey);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(String.Format("ERROR: {0}", ex.Message));
            }
        }

        private void dgvRiverSections_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (dgvRiverSections.Rows.Count > 0)
                {
                    if (dgvRiverSections.CurrentCell.RowIndex >= 0)
                    {
                        if ((bool)dgvRiverSections.Rows[dgvRiverSections.CurrentCell.RowIndex].Cells[5].Value == true)
                        {
                            dgvRiverSections.Rows[dgvRiverSections.CurrentCell.RowIndex].Cells[5].Value = false;
                        }
                        else if ((bool)dgvRiverSections.Rows[dgvRiverSections.CurrentCell.RowIndex].Cells[5].Value == false)
                        {
                            dgvRiverSections.Rows[dgvRiverSections.CurrentCell.RowIndex].Cells[5].Value = true;
                        }
                    }
                }
            }
        }

        //private void cmbRiverSection_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if(cmbRiverSection.SelectedIndex != -1)
        //    {
        //        ComboBoxItem cbItem = (ComboBoxItem)cmbRiverSection.SelectedItem;
        //        List<SideShot> lTerrestrialObservations = _Survey.SummarizeRiverSection((Tuple<int, int>)cbItem.Value);
        //        int iDuplicates = _Survey.FindDuplicates(lTerrestrialObservations);

        //        lblTerrestrialObservations.Text = String.Format("Terrestrial Observations: {0} with {1} duplicates", lTerrestrialObservations.Count, iDuplicates);

        //        List<GPS_Observation> lGPS_Observations = _Survey.SummarizeRiverSection((Tuple<int, int>)cbItem.Value,
        //                                                                                 _Survey.Stations);

        //        iDuplicates = _Survey.FindDuplicates(lGPS_Observations);
        //        lblGPS_Observations.Text = String.Format("GPS Observations: {0} with {1} duplicates", lGPS_Observations.Count, iDuplicates);
        //    }
        //}
    }
}
