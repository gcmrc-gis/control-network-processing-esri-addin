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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmControlNetworkProcessing));
            this.txtSurveyFile = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblTrimbleFile = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnInspectPoints = new System.Windows.Forms.Button();
            this.dgvRiverSections = new System.Windows.Forms.DataGridView();
            this.colRiverSection = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGPSObservations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGPS_Duplicates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTerrestrialObservations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTerrestrialDuplicates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProcess = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnOpenSurveyFile = new System.Windows.Forms.Button();
            this.btnInpectPoints = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiverSections)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSurveyFile
            // 
            this.txtSurveyFile.Location = new System.Drawing.Point(78, 26);
            this.txtSurveyFile.Name = "txtSurveyFile";
            this.txtSurveyFile.Size = new System.Drawing.Size(589, 20);
            this.txtSurveyFile.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(542, 382);
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
            this.btnCancel.Location = new System.Drawing.Point(623, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnInspectPoints
            // 
            this.btnInspectPoints.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInspectPoints.Location = new System.Drawing.Point(15, 329);
            this.btnInspectPoints.Name = "btnInspectPoints";
            this.btnInspectPoints.Size = new System.Drawing.Size(93, 23);
            this.btnInspectPoints.TabIndex = 3;
            this.btnInspectPoints.Text = "Inspect Points";
            this.btnInspectPoints.UseVisualStyleBackColor = true;
            this.btnInspectPoints.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvRiverSections
            // 
            this.dgvRiverSections.AllowUserToAddRows = false;
            this.dgvRiverSections.AllowUserToDeleteRows = false;
            this.dgvRiverSections.AllowUserToOrderColumns = true;
            this.dgvRiverSections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRiverSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRiverSections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRiverSection,
            this.colGPSObservations,
            this.colGPS_Duplicates,
            this.colTerrestrialObservations,
            this.colTerrestrialDuplicates,
            this.colProcess});
            this.dgvRiverSections.Location = new System.Drawing.Point(15, 63);
            this.dgvRiverSections.MultiSelect = false;
            this.dgvRiverSections.Name = "dgvRiverSections";
            this.dgvRiverSections.ReadOnly = true;
            this.dgvRiverSections.Size = new System.Drawing.Size(683, 260);
            this.dgvRiverSections.TabIndex = 6;
            this.dgvRiverSections.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRiverSections_CellContentClick);
            // 
            // colRiverSection
            // 
            this.colRiverSection.HeaderText = "River Section";
            this.colRiverSection.Name = "colRiverSection";
            this.colRiverSection.ReadOnly = true;
            // 
            // colGPSObservations
            // 
            this.colGPSObservations.HeaderText = "GPS Observations";
            this.colGPSObservations.Name = "colGPSObservations";
            this.colGPSObservations.ReadOnly = true;
            // 
            // colGPS_Duplicates
            // 
            this.colGPS_Duplicates.HeaderText = "GPS Duplicates";
            this.colGPS_Duplicates.Name = "colGPS_Duplicates";
            this.colGPS_Duplicates.ReadOnly = true;
            // 
            // colTerrestrialObservations
            // 
            this.colTerrestrialObservations.HeaderText = "Terrestrial Observations";
            this.colTerrestrialObservations.Name = "colTerrestrialObservations";
            this.colTerrestrialObservations.ReadOnly = true;
            // 
            // colTerrestrialDuplicates
            // 
            this.colTerrestrialDuplicates.HeaderText = "Terrestrial Duplicates";
            this.colTerrestrialDuplicates.Name = "colTerrestrialDuplicates";
            this.colTerrestrialDuplicates.ReadOnly = true;
            // 
            // colProcess
            // 
            this.colProcess.HeaderText = "Process?";
            this.colProcess.Name = "colProcess";
            this.colProcess.ReadOnly = true;
            // 
            // btnOpenSurveyFile
            // 
            this.btnOpenSurveyFile.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenSurveyFile.Image")));
            this.btnOpenSurveyFile.Location = new System.Drawing.Point(673, 23);
            this.btnOpenSurveyFile.Name = "btnOpenSurveyFile";
            this.btnOpenSurveyFile.Size = new System.Drawing.Size(25, 25);
            this.btnOpenSurveyFile.TabIndex = 0;
            this.btnOpenSurveyFile.UseVisualStyleBackColor = true;
            this.btnOpenSurveyFile.Click += new System.EventHandler(this.btnOpenSurveyFile_Click);
            // 
            // btnInpectPoints
            // 
            this.btnInpectPoints.Image = ((System.Drawing.Image)(resources.GetObject("btnInpectPoints.Image")));
            this.btnInpectPoints.Location = new System.Drawing.Point(15, 329);
            this.btnInpectPoints.Name = "btnInpectPoints";
            this.btnInpectPoints.Size = new System.Drawing.Size(91, 23);
            this.btnInpectPoints.TabIndex = 3;
            this.btnInpectPoints.Text = "Inspect Points";
            this.btnInpectPoints.UseVisualStyleBackColor = true;
            this.btnInpectPoints.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmControlNetworkProcessing
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(712, 417);
            this.Controls.Add(this.btnInspectPoints);
            this.Controls.Add(this.dgvRiverSections);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvRiverSections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenSurveyFile;
        private System.Windows.Forms.TextBox txtSurveyFile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblTrimbleFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnInspectPoints;
        private System.Windows.Forms.DataGridView dgvRiverSections;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRiverSection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGPSObservations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGPS_Duplicates;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTerrestrialObservations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTerrestrialDuplicates;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colProcess;
        private System.Windows.Forms.Button btnInpectPoints;
    }
}