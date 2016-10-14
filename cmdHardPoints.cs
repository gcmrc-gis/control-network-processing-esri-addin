using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace control_network_processing
{
    public class cmdHardPoints : ESRI.ArcGIS.Desktop.AddIns.Button
    {
        public cmdHardPoints()
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
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(String.Format("Error: {0}", ex.Message));
            }
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }
    }

}
