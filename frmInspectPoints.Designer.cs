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
            this.lblStations = new System.Windows.Forms.Label();
            this.lblObservationType = new System.Windows.Forms.Label();
            this.cmbObservationType = new System.Windows.Forms.ComboBox();
            this.dgvObservations = new System.Windows.Forms.DataGridView();
            this.lblDuplicates = new System.Windows.Forms.Label();
            this.pointNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localEastingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localNorthingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localElevationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.longitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latitudeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elevationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.networkLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.riverMileDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointUseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monumentationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pointBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStations
            // 
            this.dgvStations.AllowUserToAddRows = false;
            this.dgvStations.AllowUserToDeleteRows = false;
            this.dgvStations.AllowUserToOrderColumns = true;
            this.dgvStations.AutoGenerateColumns = false;
            this.dgvStations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pointNameDataGridViewTextBoxColumn,
            this.localEastingDataGridViewTextBoxColumn,
            this.localNorthingDataGridViewTextBoxColumn,
            this.localElevationDataGridViewTextBoxColumn,
            this.featureCodeDataGridViewTextBoxColumn,
            this.longitudeDataGridViewTextBoxColumn,
            this.latitudeDataGridViewTextBoxColumn,
            this.elevationDataGridViewTextBoxColumn,
            this.networkLevelDataGridViewTextBoxColumn,
            this.riverMileDataGridViewTextBoxColumn,
            this.pointUseDataGridViewTextBoxColumn,
            this.monumentationDataGridViewTextBoxColumn});
            this.dgvStations.DataSource = this.pointBindingSource;
            this.dgvStations.Location = new System.Drawing.Point(12, 34);
            this.dgvStations.MultiSelect = false;
            this.dgvStations.Name = "dgvStations";
            this.dgvStations.ReadOnly = true;
            this.dgvStations.Size = new System.Drawing.Size(808, 204);
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
            // lblStations
            // 
            this.lblStations.AutoSize = true;
            this.lblStations.Location = new System.Drawing.Point(12, 18);
            this.lblStations.Name = "lblStations";
            this.lblStations.Size = new System.Drawing.Size(45, 13);
            this.lblStations.TabIndex = 7;
            this.lblStations.Text = "Stations";
            // 
            // lblObservationType
            // 
            this.lblObservationType.AutoSize = true;
            this.lblObservationType.Location = new System.Drawing.Point(12, 257);
            this.lblObservationType.Name = "lblObservationType";
            this.lblObservationType.Size = new System.Drawing.Size(91, 13);
            this.lblObservationType.TabIndex = 8;
            this.lblObservationType.Text = "Observation Type";
            // 
            // cmbObservationType
            // 
            this.cmbObservationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbObservationType.FormattingEnabled = true;
            this.cmbObservationType.Location = new System.Drawing.Point(109, 254);
            this.cmbObservationType.Name = "cmbObservationType";
            this.cmbObservationType.Size = new System.Drawing.Size(121, 21);
            this.cmbObservationType.TabIndex = 9;
            this.cmbObservationType.SelectedIndexChanged += new System.EventHandler(this.cmbObservationType_SelectedIndexChanged);
            // 
            // dgvObservations
            // 
            this.dgvObservations.AllowUserToAddRows = false;
            this.dgvObservations.AllowUserToDeleteRows = false;
            this.dgvObservations.AllowUserToOrderColumns = true;
            this.dgvObservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvObservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObservations.Location = new System.Drawing.Point(12, 281);
            this.dgvObservations.Name = "dgvObservations";
            this.dgvObservations.ReadOnly = true;
            this.dgvObservations.Size = new System.Drawing.Size(607, 200);
            this.dgvObservations.TabIndex = 10;
            // 
            // lblDuplicates
            // 
            this.lblDuplicates.AutoSize = true;
            this.lblDuplicates.Location = new System.Drawing.Point(275, 257);
            this.lblDuplicates.Name = "lblDuplicates";
            this.lblDuplicates.Size = new System.Drawing.Size(125, 13);
            this.lblDuplicates.TabIndex = 11;
            this.lblDuplicates.Text = "Duplicates at this station:";
            // 
            // pointNameDataGridViewTextBoxColumn
            // 
            this.pointNameDataGridViewTextBoxColumn.DataPropertyName = "PointName";
            this.pointNameDataGridViewTextBoxColumn.HeaderText = "PointName";
            this.pointNameDataGridViewTextBoxColumn.Name = "pointNameDataGridViewTextBoxColumn";
            this.pointNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointNameDataGridViewTextBoxColumn.Width = 84;
            // 
            // localEastingDataGridViewTextBoxColumn
            // 
            this.localEastingDataGridViewTextBoxColumn.DataPropertyName = "LocalEasting";
            this.localEastingDataGridViewTextBoxColumn.HeaderText = "LocalEasting";
            this.localEastingDataGridViewTextBoxColumn.Name = "localEastingDataGridViewTextBoxColumn";
            this.localEastingDataGridViewTextBoxColumn.ReadOnly = true;
            this.localEastingDataGridViewTextBoxColumn.Width = 93;
            // 
            // localNorthingDataGridViewTextBoxColumn
            // 
            this.localNorthingDataGridViewTextBoxColumn.DataPropertyName = "LocalNorthing";
            this.localNorthingDataGridViewTextBoxColumn.HeaderText = "LocalNorthing";
            this.localNorthingDataGridViewTextBoxColumn.Name = "localNorthingDataGridViewTextBoxColumn";
            this.localNorthingDataGridViewTextBoxColumn.ReadOnly = true;
            this.localNorthingDataGridViewTextBoxColumn.Width = 98;
            // 
            // localElevationDataGridViewTextBoxColumn
            // 
            this.localElevationDataGridViewTextBoxColumn.DataPropertyName = "LocalElevation";
            this.localElevationDataGridViewTextBoxColumn.HeaderText = "LocalElevation";
            this.localElevationDataGridViewTextBoxColumn.Name = "localElevationDataGridViewTextBoxColumn";
            this.localElevationDataGridViewTextBoxColumn.ReadOnly = true;
            this.localElevationDataGridViewTextBoxColumn.Width = 102;
            // 
            // featureCodeDataGridViewTextBoxColumn
            // 
            this.featureCodeDataGridViewTextBoxColumn.DataPropertyName = "FeatureCode";
            this.featureCodeDataGridViewTextBoxColumn.HeaderText = "FeatureCode";
            this.featureCodeDataGridViewTextBoxColumn.Name = "featureCodeDataGridViewTextBoxColumn";
            this.featureCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.featureCodeDataGridViewTextBoxColumn.Width = 93;
            // 
            // longitudeDataGridViewTextBoxColumn
            // 
            this.longitudeDataGridViewTextBoxColumn.DataPropertyName = "Longitude";
            this.longitudeDataGridViewTextBoxColumn.HeaderText = "Longitude";
            this.longitudeDataGridViewTextBoxColumn.Name = "longitudeDataGridViewTextBoxColumn";
            this.longitudeDataGridViewTextBoxColumn.ReadOnly = true;
            this.longitudeDataGridViewTextBoxColumn.Width = 79;
            // 
            // latitudeDataGridViewTextBoxColumn
            // 
            this.latitudeDataGridViewTextBoxColumn.DataPropertyName = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.HeaderText = "Latitude";
            this.latitudeDataGridViewTextBoxColumn.Name = "latitudeDataGridViewTextBoxColumn";
            this.latitudeDataGridViewTextBoxColumn.ReadOnly = true;
            this.latitudeDataGridViewTextBoxColumn.Width = 70;
            // 
            // elevationDataGridViewTextBoxColumn
            // 
            this.elevationDataGridViewTextBoxColumn.DataPropertyName = "Elevation";
            this.elevationDataGridViewTextBoxColumn.HeaderText = "Elevation";
            this.elevationDataGridViewTextBoxColumn.Name = "elevationDataGridViewTextBoxColumn";
            this.elevationDataGridViewTextBoxColumn.ReadOnly = true;
            this.elevationDataGridViewTextBoxColumn.Width = 76;
            // 
            // networkLevelDataGridViewTextBoxColumn
            // 
            this.networkLevelDataGridViewTextBoxColumn.DataPropertyName = "NetworkLevel";
            this.networkLevelDataGridViewTextBoxColumn.HeaderText = "NetworkLevel";
            this.networkLevelDataGridViewTextBoxColumn.Name = "networkLevelDataGridViewTextBoxColumn";
            this.networkLevelDataGridViewTextBoxColumn.ReadOnly = true;
            this.networkLevelDataGridViewTextBoxColumn.Width = 98;
            // 
            // riverMileDataGridViewTextBoxColumn
            // 
            this.riverMileDataGridViewTextBoxColumn.DataPropertyName = "RiverMile";
            this.riverMileDataGridViewTextBoxColumn.HeaderText = "RiverMile";
            this.riverMileDataGridViewTextBoxColumn.Name = "riverMileDataGridViewTextBoxColumn";
            this.riverMileDataGridViewTextBoxColumn.ReadOnly = true;
            this.riverMileDataGridViewTextBoxColumn.Width = 76;
            // 
            // pointUseDataGridViewTextBoxColumn
            // 
            this.pointUseDataGridViewTextBoxColumn.DataPropertyName = "PointUse";
            this.pointUseDataGridViewTextBoxColumn.HeaderText = "PointUse";
            this.pointUseDataGridViewTextBoxColumn.Name = "pointUseDataGridViewTextBoxColumn";
            this.pointUseDataGridViewTextBoxColumn.ReadOnly = true;
            this.pointUseDataGridViewTextBoxColumn.Width = 75;
            // 
            // monumentationDataGridViewTextBoxColumn
            // 
            this.monumentationDataGridViewTextBoxColumn.DataPropertyName = "Monumentation";
            this.monumentationDataGridViewTextBoxColumn.HeaderText = "Monumentation";
            this.monumentationDataGridViewTextBoxColumn.Name = "monumentationDataGridViewTextBoxColumn";
            this.monumentationDataGridViewTextBoxColumn.ReadOnly = true;
            this.monumentationDataGridViewTextBoxColumn.Width = 105;
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
            this.Controls.Add(this.lblDuplicates);
            this.Controls.Add(this.dgvObservations);
            this.Controls.Add(this.cmbObservationType);
            this.Controls.Add(this.lblObservationType);
            this.Controls.Add(this.lblStations);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvStations);
            this.MaximumSize = new System.Drawing.Size(848, 557);
            this.MinimizeBox = false;
            this.Name = "frmInspectPoints";
            this.ShowIcon = false;
            this.Text = "Inspect Points";
            this.Load += new System.EventHandler(this.frmInspectPoints_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pointBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStations;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStations;
        private System.Windows.Forms.Label lblObservationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localEastingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localNorthingDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localElevationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn longitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn latitudeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn elevationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn networkLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn riverMileDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pointUseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn monumentationDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pointBindingSource;
        private System.Windows.Forms.ComboBox cmbObservationType;
        private System.Windows.Forms.DataGridView dgvObservations;
        private System.Windows.Forms.Label lblDuplicates;
    }
}