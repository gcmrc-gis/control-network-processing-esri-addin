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

            foreach (Tuple<int, int> tRiverMile in Definitions.lTraverseRiverMiles)
            {
                cblTraverseRiverMiles.Items.Add(String.Format("RM: {0} to {1} : O Points", tRiverMile.Item1, tRiverMile.Item2));
            }

        }

        private void btnOpenSurveyFile_Click(object sender, EventArgs e)
        {
            FileDialog pFileDialog = new System.Windows.Forms.OpenFileDialog();
            pFileDialog.Filter = "asc files (*.asc)|*.asc|All files (*.*)|*.*";
            pFileDialog.InitialDirectory = @"U:\projects\survey\control-network\data\raw";
            DialogResult pResult = pFileDialog.ShowDialog();
            if (pResult == DialogResult.OK)
            {
                string sFilePath = pFileDialog.FileName;
                if (System.IO.File.Exists(sFilePath))
                {
                    txtSurveyFile.Text = sFilePath;
                    _Survey = new Survey(sFilePath, "");

                    //TODO: show things to the user
                    int iGPS_Duplicates = _Survey.FindDuplicates(_Survey.GPS_Observations);
                    int iTerrestrialDuplicates = _Survey.FindDuplicates(_Survey.TerrestrialObservations);
                    lblStations.Text = String.Format("Stations: {0}", _Survey.Stations.Keys.Count);
                    lblGPS_Observations.Text = String.Format("GPS Observations: {0} with {1} duplicates", _Survey.GPS_Observations.Count, iGPS_Duplicates);
                    lblTerrestrialObservations.Text = String.Format("Terrestrial Observations: {0} with {1} duplicates", _Survey.TerrestrialObservations.Count, iTerrestrialDuplicates);

                    //TODO:spatial filters
                    //TODO: push down all of the network type, observation type, etc. currently done when creating a GIS object
                    //and make that a method for Sideshot and GPS_Observation
                }
            }
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
                string sDummy = "dummy";
            }
        }
    }
}
