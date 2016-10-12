namespace control_network_processing
{
    partial class frmControlNetworkProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOpenSurveyFile = new System.Windows.Forms.Button();
            this.txtSurveyFile = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblTrimbleFile = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grbTrimbleFileInfo = new System.Windows.Forms.GroupBox();
            this.lblStations = new System.Windows.Forms.Label();
            this.lblGPS_Observations = new System.Windows.Forms.Label();
            this.lblTerrestrialObservations = new System.Windows.Forms.Label();
            this.cblTraverseRiverMiles = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.grbTrimbleFileInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenSurveyFile
            // 
            this.btnOpenSurveyFile.Location = new System.Drawing.Point(662, 22);
            this.btnOpenSurveyFile.Name = "btnOpenSurveyFile";
            this.btnOpenSurveyFile.Size = new System.Drawing.Size(25, 25);
            this.btnOpenSurveyFile.TabIndex = 0;
            this.btnOpenSurveyFile.Text = "button1";
            this.btnOpenSurveyFile.UseVisualStyleBackColor = true;
            this.btnOpenSurveyFile.Click += new System.EventHandler(this.btnOpenSurveyFile_Click);
            // 
            // txtSurveyFile
            // 
            this.txtSurveyFile.Location = new System.Drawing.Point(78, 26);
            this.txtSurveyFile.Name = "txtSurveyFile";
            this.txtSurveyFile.Size = new System.Drawing.Size(578, 20);
            this.txtSurveyFile.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(531, 382);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblTrimbleFile
            // 
            this.lblTrimbleFile.AutoSize = true;
            this.lblTrimbleFile.Location = new System.Drawing.Point(12, 28);
            this.lblTrimbleFile.Name = "lblTrimbleFile";
            this.lblTrimbleFile.Size = new System.Drawing.Size(60, 13);
            this.lblTrimbleFile.TabIndex = 3;
            this.lblTrimbleFile.Text = "Trimble File";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(612, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grbTrimbleFileInfo
            // 
            this.grbTrimbleFileInfo.Controls.Add(this.button1);
            this.grbTrimbleFileInfo.Controls.Add(this.lblTerrestrialObservations);
            this.grbTrimbleFileInfo.Controls.Add(this.lblGPS_Observations);
            this.grbTrimbleFileInfo.Controls.Add(this.lblStations);
            this.grbTrimbleFileInfo.Location = new System.Drawing.Point(13, 84);
            this.grbTrimbleFileInfo.Name = "grbTrimbleFileInfo";
            this.grbTrimbleFileInfo.Size = new System.Drawing.Size(674, 140);
            this.grbTrimbleFileInfo.TabIndex = 5;
            this.grbTrimbleFileInfo.TabStop = false;
            this.grbTrimbleFileInfo.Text = "Trimble File Info";
            // 
            // lblStations
            // 
            this.lblStations.AutoSize = true;
            this.lblStations.Location = new System.Drawing.Point(15, 30);
            this.lblStations.Name = "lblStations";
            this.lblStations.Size = new System.Drawing.Size(48, 13);
            this.lblStations.TabIndex = 0;
            this.lblStations.Text = "Stations:";
            // 
            // lblGPS_Observations
            // 
            this.lblGPS_Observations.AutoSize = true;
            this.lblGPS_Observations.Location = new System.Drawing.Point(15, 53);
            this.lblGPS_Observations.Name = "lblGPS_Observations";
            this.lblGPS_Observations.Size = new System.Drawing.Size(94, 13);
            this.lblGPS_Observations.TabIndex = 1;
            this.lblGPS_Observations.Text = "GPS Observations";
            // 
            // lblTerrestrialObservations
            // 
            this.lblTerrestrialObservations.AutoSize = true;
            this.lblTerrestrialObservations.Location = new System.Drawing.Point(15, 76);
            this.lblTerrestrialObservations.Name = "lblTerrestrialObservations";
            this.lblTerrestrialObservations.Size = new System.Drawing.Size(118, 13);
            this.lblTerrestrialObservations.TabIndex = 2;
            this.lblTerrestrialObservations.Text = "Terrestrial Observations";
            // 
            // cblTraverseRiverMiles
            // 
            this.cblTraverseRiverMiles.Enabled = false;
            this.cblTraverseRiverMiles.FormattingEnabled = true;
            this.cblTraverseRiverMiles.Location = new System.Drawing.Point(15, 229);
            this.cblTraverseRiverMiles.Name = "cblTraverseRiverMiles";
            this.cblTraverseRiverMiles.Size = new System.Drawing.Size(208, 184);
            this.cblTraverseRiverMiles.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Inspect Points";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmControlNetworkProcessing
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(699, 417);
            this.Controls.Add(this.cblTraverseRiverMiles);
            this.Controls.Add(this.grbTrimbleFileInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTrimbleFile);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSurveyFile);
            this.Controls.Add(this.btnOpenSurveyFile);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(715, 455);
            this.Name = "frmControlNetworkProcessing";
            this.ShowIcon = false;
            this.Text = "Control Network Processing";
            this.grbTrimbleFileInfo.ResumeLayout(false);
            this.grbTrimbleFileInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenSurveyFile;
        private System.Windows.Forms.TextBox txtSurveyFile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblTrimbleFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grbTrimbleFileInfo;
        private System.Windows.Forms.Label lblStations;
        private System.Windows.Forms.Label lblTerrestrialObservations;
        private System.Windows.Forms.Label lblGPS_Observations;
        private System.Windows.Forms.CheckedListBox cblTraverseRiverMiles;
        private System.Windows.Forms.Button button1;
    }
}