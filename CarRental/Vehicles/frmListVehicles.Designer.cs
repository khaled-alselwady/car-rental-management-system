namespace CarRental.Vehicles
{
    partial class frmListVehicles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvVehiclesList = new System.Windows.Forms.DataGridView();
            this.cmsEditProfile = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMake = new System.Windows.Forms.ComboBox();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.cbFuelType = new System.Windows.Forms.ComboBox();
            this.cbDriverType = new System.Windows.Forms.ComboBox();
            this.cbIsAvailableForRent = new System.Windows.Forms.ComboBox();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.ShowVehicleDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.EditVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MaintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnAddNewVehicle = new System.Windows.Forms.Button();
            this.ShowMaintenanceHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiclesList)).BeginInit();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVehiclesList
            // 
            this.dgvVehiclesList.AllowUserToAddRows = false;
            this.dgvVehiclesList.AllowUserToDeleteRows = false;
            this.dgvVehiclesList.AllowUserToResizeRows = false;
            this.dgvVehiclesList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiclesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvVehiclesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiclesList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVehiclesList.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvVehiclesList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvVehiclesList.Location = new System.Drawing.Point(15, 277);
            this.dgvVehiclesList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvVehiclesList.MultiSelect = false;
            this.dgvVehiclesList.Name = "dgvVehiclesList";
            this.dgvVehiclesList.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVehiclesList.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvVehiclesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVehiclesList.Size = new System.Drawing.Size(1340, 467);
            this.dgvVehiclesList.TabIndex = 180;
            this.dgvVehiclesList.TabStop = false;
            this.dgvVehiclesList.DoubleClick += new System.EventHandler(this.dgvVehiclesList_DoubleClick);
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowVehicleDetailsToolStripMenuItem1,
            this.EditVehicleToolStripMenuItem,
            this.DeleteVehicleToolStripMenuItem,
            this.MaintenanceToolStripMenuItem,
            this.ShowMaintenanceHistoryToolStripMenuItem});
            this.cmsEditProfile.Name = "guna2ContextMenuStrip1";
            this.cmsEditProfile.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsEditProfile.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.cmsEditProfile.RenderStyle.ColorTable = null;
            this.cmsEditProfile.RenderStyle.RoundedEdges = true;
            this.cmsEditProfile.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsEditProfile.RenderStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.cmsEditProfile.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEditProfile.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.cmsEditProfile.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsEditProfile.Size = new System.Drawing.Size(283, 194);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(115, 749);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(27, 20);
            this.lblNumberOfRecords.TabIndex = 177;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 749);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 176;
            this.label2.Text = "# Records:";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Vehicle ID",
            "Vehicle Name",
            "Make",
            "Model",
            "Plate Number",
            "Year",
            "Fuel Type",
            "Drive Type",
            "Is Available For Rent"});
            this.cbFilter.Location = new System.Drawing.Point(99, 242);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(205, 28);
            this.cbFilter.TabIndex = 174;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(325, 242);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(356, 26);
            this.txtSearch.TabIndex = 173;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 172;
            this.label1.Text = "Filter By:";
            // 
            // cbMake
            // 
            this.cbMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMake.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMake.FormattingEnabled = true;
            this.cbMake.Location = new System.Drawing.Point(325, 242);
            this.cbMake.Name = "cbMake";
            this.cbMake.Size = new System.Drawing.Size(354, 28);
            this.cbMake.TabIndex = 219;
            this.cbMake.SelectedIndexChanged += new System.EventHandler(this.cbMake_SelectedIndexChanged);
            // 
            // cbModel
            // 
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(325, 242);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(354, 28);
            this.cbModel.TabIndex = 220;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.cbModel_SelectedIndexChanged);
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(325, 242);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(93, 28);
            this.cbYear.TabIndex = 222;
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // cbFuelType
            // 
            this.cbFuelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFuelType.FormattingEnabled = true;
            this.cbFuelType.Location = new System.Drawing.Point(325, 241);
            this.cbFuelType.Name = "cbFuelType";
            this.cbFuelType.Size = new System.Drawing.Size(354, 28);
            this.cbFuelType.TabIndex = 224;
            this.cbFuelType.SelectedIndexChanged += new System.EventHandler(this.cbFuelType_SelectedIndexChanged);
            // 
            // cbDriverType
            // 
            this.cbDriverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDriverType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDriverType.FormattingEnabled = true;
            this.cbDriverType.Location = new System.Drawing.Point(325, 242);
            this.cbDriverType.Name = "cbDriverType";
            this.cbDriverType.Size = new System.Drawing.Size(354, 28);
            this.cbDriverType.TabIndex = 225;
            this.cbDriverType.SelectedIndexChanged += new System.EventHandler(this.cbDriverType_SelectedIndexChanged);
            // 
            // cbIsAvailableForRent
            // 
            this.cbIsAvailableForRent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsAvailableForRent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIsAvailableForRent.FormattingEnabled = true;
            this.cbIsAvailableForRent.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsAvailableForRent.Location = new System.Drawing.Point(325, 242);
            this.cbIsAvailableForRent.Name = "cbIsAvailableForRent";
            this.cbIsAvailableForRent.Size = new System.Drawing.Size(93, 28);
            this.cbIsAvailableForRent.TabIndex = 226;
            this.cbIsAvailableForRent.SelectedIndexChanged += new System.EventHandler(this.cbIsAvailableForRent_SelectedIndexChanged);
            // 
            // btnMaintenance
            // 
            this.btnMaintenance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaintenance.Image = global::CarRental.Properties.Resources.maintenance_vehicle48;
            this.btnMaintenance.Location = new System.Drawing.Point(1208, 215);
            this.btnMaintenance.Name = "btnMaintenance";
            this.btnMaintenance.Size = new System.Drawing.Size(70, 55);
            this.btnMaintenance.TabIndex = 227;
            this.btnMaintenance.UseVisualStyleBackColor = true;
            this.btnMaintenance.Click += new System.EventHandler(this.btnMaintenance_Click);
            // 
            // ShowVehicleDetailsToolStripMenuItem1
            // 
            this.ShowVehicleDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.ShowVehicleDetailsToolStripMenuItem1.Image = global::CarRental.Properties.Resources.vehicle_details32;
            this.ShowVehicleDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowVehicleDetailsToolStripMenuItem1.Name = "ShowVehicleDetailsToolStripMenuItem1";
            this.ShowVehicleDetailsToolStripMenuItem1.Size = new System.Drawing.Size(282, 38);
            this.ShowVehicleDetailsToolStripMenuItem1.Text = "   Show Vehicle Details";
            this.ShowVehicleDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowVehicleDetailsToolStripMenuItem1_Click);
            // 
            // EditVehicleToolStripMenuItem
            // 
            this.EditVehicleToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.EditVehicleToolStripMenuItem.Image = global::CarRental.Properties.Resources.car_Edit32;
            this.EditVehicleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditVehicleToolStripMenuItem.Name = "EditVehicleToolStripMenuItem";
            this.EditVehicleToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.EditVehicleToolStripMenuItem.Text = "   Edit";
            this.EditVehicleToolStripMenuItem.Click += new System.EventHandler(this.EditVehicleToolStripMenuItem_Click);
            // 
            // DeleteVehicleToolStripMenuItem
            // 
            this.DeleteVehicleToolStripMenuItem.Image = global::CarRental.Properties.Resources.car_delete32;
            this.DeleteVehicleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.DeleteVehicleToolStripMenuItem.Name = "DeleteVehicleToolStripMenuItem";
            this.DeleteVehicleToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.DeleteVehicleToolStripMenuItem.Text = "   Delete";
            this.DeleteVehicleToolStripMenuItem.Click += new System.EventHandler(this.DeleteVehicleToolStripMenuItem_Click);
            // 
            // MaintenanceToolStripMenuItem
            // 
            this.MaintenanceToolStripMenuItem.Image = global::CarRental.Properties.Resources.maintenance_vehicle32;
            this.MaintenanceToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem";
            this.MaintenanceToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.MaintenanceToolStripMenuItem.Text = "   Maintenance";
            this.MaintenanceToolStripMenuItem.Click += new System.EventHandler(this.MaintenanceToolStripMenuItem_Click);
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImage.Image = global::CarRental.Properties.Resources.vehilcesList;
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(506, 31);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(306, 189);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 178;
            this.pbImage.TabStop = false;
            // 
            // btnAddNewVehicle
            // 
            this.btnAddNewVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewVehicle.Image = global::CarRental.Properties.Resources.add_car40;
            this.btnAddNewVehicle.Location = new System.Drawing.Point(1284, 215);
            this.btnAddNewVehicle.Name = "btnAddNewVehicle";
            this.btnAddNewVehicle.Size = new System.Drawing.Size(70, 55);
            this.btnAddNewVehicle.TabIndex = 181;
            this.btnAddNewVehicle.UseVisualStyleBackColor = true;
            this.btnAddNewVehicle.Click += new System.EventHandler(this.btnAddNewVehicle_Click);
            // 
            // ShowMaintenanceHistoryToolStripMenuItem
            // 
            this.ShowMaintenanceHistoryToolStripMenuItem.Image = global::CarRental.Properties.Resources.Calendar_32;
            this.ShowMaintenanceHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowMaintenanceHistoryToolStripMenuItem.Name = "ShowMaintenanceHistoryToolStripMenuItem";
            this.ShowMaintenanceHistoryToolStripMenuItem.Size = new System.Drawing.Size(282, 38);
            this.ShowMaintenanceHistoryToolStripMenuItem.Text = "   Show Maintenance History";
            this.ShowMaintenanceHistoryToolStripMenuItem.Click += new System.EventHandler(this.ShowMaintenanceHistoryToolStripMenuItem_Click);
            // 
            // frmListVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1366, 800);
            this.Controls.Add(this.btnMaintenance);
            this.Controls.Add(this.cbIsAvailableForRent);
            this.Controls.Add(this.cbDriverType);
            this.Controls.Add(this.cbFuelType);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.cbMake);
            this.Controls.Add(this.dgvVehiclesList);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnAddNewVehicle);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListVehicles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Manage Vehicles";
            this.Text = "frmListVehicles";
            this.Load += new System.EventHandler(this.frmListVehicles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiclesList)).EndInit();
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVehiclesList;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowVehicleDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem EditVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteVehicleToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnAddNewVehicle;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMake;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbFuelType;
        private System.Windows.Forms.ComboBox cbDriverType;
        private System.Windows.Forms.ComboBox cbIsAvailableForRent;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.ToolStripMenuItem MaintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowMaintenanceHistoryToolStripMenuItem;
    }
}