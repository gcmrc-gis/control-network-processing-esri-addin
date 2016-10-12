namespace control_network_processing
{
    partial class frmInspectPoints
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
            this.components = new System.ComponentModel.Container();
            this.dgvStations = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgvTerrestrialPoints = new System.Windows.Forms.DataGridView();
            this.lblStations = new System.Windows.Forms.Label();
            this.lblTerrrestrialPoints = new System.Windows.Forms.Label();
            this.lblGPS_Observations = new System.Windows.Forms.Label();
            this.dgvGPS_Observations = new System.Windows.Forms.DataGridView();
            this.fromStationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toStationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gPSObservationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.instrumentPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backsightPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.foresightPointDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sideShotBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pointNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localEastingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localNorthingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localElevationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elevationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerrestrialPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPS_Observations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPSObservationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideShotBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStations
            // 
            this.dgvStations.AutoGenerateColumns = false;
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointNameDataGridViewTextBoxColumn,
            this.localEastingDataGridViewTextBoxColumn,
            this.localNorthingDataGridViewTextBoxColumn,
            this.localElevationDataGridViewTextBoxColumn,
            this.featureCodeDataGridViewTextBoxColumn,
            this.longitudeDataGridViewTextBoxColumn,
            this.latitudeDataGridViewTextBoxColumn,
            this.elevationDataGridViewTextBoxColumn});
            this.dgvStations.DataSource = this.pointBindingSource;
            this.dgvStations.Location = new System.Drawing.Point(12, 37);
            this.dgvStations.MultiSelect = false;
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.Size = new System.Drawing.Size(808, 150);
            this.dgvStations.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(745, 484);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvTerrestrialPoints
            // 
            this.dgvTerrestrialPoints.AutoGenerateColumns = false;
            this.dgvTerrestrialPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTerrestrialPoints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.instrumentPointDataGridViewTextBoxColumn,
            this.backsightPointDataGridViewTextBoxColumn,
            this.foresightPointDataGridViewTextBoxColumn});
            this.dgvTerrestrialPoints.DataSource = this.sideShotBindingSource;
            this.dgvTerrestrialPoints.Location = new System.Drawing.Point(12, 215);
            this.dgvTerrestrialPoints.Name = "dgvTerrestrialPoints";
            this.dgvTerrestrialPoints.Size = new System.Drawing.Size(397, 263);
            this.dgvTerrestrialPoints.TabIndex = 6;
            // 
            // lblStations
            // 
            this.lblStations.AutoSize = true;
            this.lblStations.Location = new System.Drawing.Point(12, 21);
            this.lblStations.Name = "lblStations";
            this.lblStations.Size = new System.Drawing.Size(45, 13);
            this.lblStations.TabIndex = 7;
            this.lblStations.Text = "Stations";
            // 
            // lblTerrrestrialPoints
            // 
            this.lblTerrrestrialPoints.AutoSize = true;
            this.lblTerrrestrialPoints.Location = new System.Drawing.Point(12, 199);
            this.lblTerrrestrialPoints.Name = "lblTerrrestrialPoints";
            this.lblTerrrestrialPoints.Size = new System.Drawing.Size(85, 13);
            this.lblTerrrestrialPoints.TabIndex = 8;
            this.lblTerrrestrialPoints.Text = "Terrestrial Points";
            // 
            // lblGPS_Observations
            // 
            this.lblGPS_Observations.AutoSize = true;
            this.lblGPS_Observations.Location = new System.Drawing.Point(431, 196);
            this.lblGPS_Observations.Name = "lblGPS_Observations";
            this.lblGPS_Observations.Size = new System.Drawing.Size(94, 13);
            this.lblGPS_Observations.TabIndex = 10;
            this.lblGPS_Observations.Text = "GPS Observations";
            // 
            // dgvGPS_Observations
            // 
            this.dgvGPS_Observations.AutoGenerateColumns = false;
            this.dgvGPS_Observations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGPS_Observations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fromStationDataGridViewTextBoxColumn,
            this.toStationDataGridViewTextBoxColumn});
            this.dgvGPS_Observations.DataSource = this.gPSObservationBindingSource;
            this.dgvGPS_Observations.Location = new System.Drawing.Point(431, 215);
            this.dgvGPS_Observations.Name = "dgvGPS_Observations";
            this.dgvGPS_Observations.Size = new System.Drawing.Size(389, 263);
            this.dgvGPS_Observations.TabIndex = 9;
            // 
            // fromStationDataGridViewTextBoxColumn
            // 
            this.fromStationDataGridViewTextBoxColumn.DataPropertyName = "FromStation";
            this.fromStationDataGridViewTextBoxColumn.HeaderText = "FromStation";
            this.fromStationDataGridViewTextBoxColumn.Name = "fromStationDataGridViewTextBoxColumn";
            this.fromStationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toStationDataGridViewTextBoxColumn
            // 
            this.toStationDataGridViewTextBoxColumn.DataPropertyName = "ToStation";
            this.toStationDataGridViewTextBoxColumn.HeaderText = "ToStation";
            this.toStationDataGridViewTextBoxColumn.Name = "toStationDataGridViewTextBoxColumn";
            this.toStationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gPSObservationBindingSource
            // 
            this.gPSObservationBindingSource.DataSource = typeof(control_network_processing.GPS_Observation);
            // 
            // instrumentPointDataGridViewTextBoxColumn
            // 
            this.instrumentPointDataGridViewTextBoxColumn.DataPropertyName = "InstrumentPoint";
            this.instrumentPointDataGridViewTextBoxColumn.HeaderText = "InstrumentPoint";
            this.instrumentPointDataGridViewTextBoxColumn.Name = "instrumentPointDataGridViewTextBoxColumn";
            this.instrumentPointDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // backsightPointDataGridViewTextBoxColumn
            // 
            this.backsightPointDataGridViewTextBoxColumn.DataPropertyName = "BacksightPoint";
            this.backsightPointDataGridViewTextBoxColumn.HeaderText = "BacksightPoint";
            this.backsightPointDataGridViewTextBoxColumn.Name = "backsightPointDataGridViewTextBoxColumn";
            this.backsightPointDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // foresightPointDataGridViewTextBoxColumn
            // 
            this.foresightPointDataGridViewTextBoxColumn.DataPropertyName = "ForesightPoint";
            this.foresightPointDataGridViewTextBoxColumn.HeaderText = "ForesightPoint";
            this.foresightPointDataGridViewTextBoxColumn.Name = "foresightPointDataGridViewTextBoxColumn";
            this.foresightPointDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sideShotBindingSource
            // 
            this.sideShotBindingSource.DataSource = typeof(control_network_processing.SideShot);
            // 
            // pointNameDataGridViewTextBoxColumn
            // 
            this.pointNameDataGridViewTextBoxColumn.DataPropertyName = "PointName";
            this.pointNameDataGridViewTextBoxColumn.HeaderText = "PointName";
            this.pointNameDataGridViewTextBoxColumn.Name = "pointNameDataGridViewTextBoxColumn";
            this.pointNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localEastingDataGridViewTextBoxColumn
            // 
            this.localEastingDataGridViewTextBoxColumn.DataPropertyName = "LocalEasting";
            this.localEastingDataGridViewTextBoxColumn.HeaderText = "LocalEasting";
            this.localEastingDataGridViewTextBoxColumn.Name = "localEastingDataGridViewTextBoxColumn";
            this.localEastingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localNorthingDataGridViewTextBoxColumn
            // 
            this.localNorthingDataGridViewTextBoxColumn.DataPropertyName = "LocalNorthing";
            this.localNorthingDataGridViewTextBoxColumn.HeaderText = "LocalNorthing";
            this.localNorthingDataGridViewTextBoxColumn.Name = "localNorthingDataGridViewTextBoxColumn";
            this.localNorthingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localElevationDataGridViewTextBoxColumn
            // 
            this.localElevationDataGridViewTextBoxColumn.DataPropertyName = "LocalElevation";
            this.localElevationDataGridViewTextBoxColumn.HeaderText = "LocalElevation";
            this.localElevationDataGridViewTextBoxColumn.Name = "localElevationDataGridViewTextBoxColumn";
            this.localElevationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // featureCodeDataGridViewTextBoxColumn
            // 
            this.featureCodeDataGridViewTextBoxColumn.DataPropertyName = "FeatureCode";
            this.featureCodeDataGridViewTextBoxColumn.HeaderText = "FeatureCode";
            this.featureCodeDataGridViewTextBoxColumn.Name = "featureCodeDataGridViewTextBoxColumn";
            this.featureCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // longitudeDataGridViewTextBoxColumn
            // 
            this.longitudeDataGridViewTextBoxColumn.DataPropertyName = "Longitude";
            this.longitudeDataGridViewTextBoxColumn.HeaderText = "Longitude";
            this.longitudeDataGridViewTextBoxColumn.Name = "longitudeDataGridViewTextBoxColumn";
            this.longitudeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // latitudeDataGridViewTextBoxColumn
            // 
            this.latitudeDataGridViewTextBoxColumn.DataPropertyName = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.HeaderText = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.Name = "latitudeDataGridViewTextBoxColumn";
            this.latitudeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // elevationDataGridViewTextBoxColumn
            // 
            this.elevationDataGridViewTextBoxColumn.DataPropertyName = "Elevation";
            this.elevationDataGridViewTextBoxColumn.HeaderText = "Elevation";
            this.elevationDataGridViewTextBoxColumn.Name = "elevationDataGridViewTextBoxColumn";
            this.elevationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pointBindingSource
            // 
            this.pointBindingSource.DataSource = typeof(control_network_processing.Point);
            // 
            // frmInspectPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(832, 519);
            this.Controls.Add(this.lblGPS_Observations);
            this.Controls.Add(this.dgvGPS_Observations);
            this.Controls.Add(this.lblTerrrestrialPoints);
            this.Controls.Add(this.lblStations);
            this.Controls.Add(this.dgvTerrestrialPoints);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvStations);
            this.MaximumSize = new System.Drawing.Size(848, 557);
            this.MinimizeBox = false;
            this.Name = "frmInspectPoints";
            this.ShowIcon = false;
            this.Text = "Inspect Points";
            this.Load += new System.EventHandler(this.frmInspectPoints_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTerrestrialPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPS_Observations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPSObservationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sideShotBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localEastingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localNorthingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localElevationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn elevationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pointBindingSource;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvTerrestrialPoints;
        private System.Windows.Forms.Label lblStations;
        private System.Windows.Forms.Label lblTerrrestrialPoints;
        private System.Windows.Forms.Label lblGPS_Observations;
        private System.Windows.Forms.DataGridViewTextBoxColumn instrumentPointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn backsightPointDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn foresightPointDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sideShotBindingSource;
        private System.Windows.Forms.DataGridView dgvGPS_Observations;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromStationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toStationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource gPSObservationBindingSource;
    }
}