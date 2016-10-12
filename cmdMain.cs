using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace control_network_processing
{
    public class cmdMain : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public cmdMain()
        {
        }

        protected override void OnClick()
        {
            //
            //  TODO: Sample code showing how to access button host
            //
            ArcMap.Application.CurrentTool = null;
            try
            {
                frmControlNetworkProcessing frm = new frmControlNetworkProcessing();
                frm.ShowDialog();
            }    
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(String.Format("Error: {0}", ex.Message));
                string sDummy = "dummy";
            }
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
