namespace CarRental.Return
{
    partial class frmListReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmsEditProfile = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.ShowReturnDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowBookingDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCustomerDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowVehicleDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpActualReturnDate = new System.Windows.Forms.DateTimePicker();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnAddNewReturn = new System.Windows.Forms.Button();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReturnList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnList)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.White;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowReturnDetailsToolStripMenuItem,
            this.ShowBookingDetailsToolStripMenuItem1,
            this.ShowCustomerDetailsToolStripMenuItem,
            this.ShowVehicleDetailsToolStripMenuItem});
            this.cmsEditProfile.Name = "guna2ContextMenuStrip1";
            this.cmsEditProfile.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.cmsEditProfile.RenderStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cmsEditProfile.RenderStyle.ColorTable = null;
            this.cmsEditProfile.RenderStyle.RoundedEdges = true;
            this.cmsEditProfile.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.cmsEditProfile.RenderStyle.SelectionBackColor = System.Drawing.Color.Gray;
            this.cmsEditProfile.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.cmsEditProfile.RenderStyle.SeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(118)))), ((int)(((byte)(212)))));
            this.cmsEditProfile.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.cmsEditProfile.Size = new System.Drawing.Size(260, 178);
            // 
            // ShowReturnDetailsToolStripMenuItem
            // 
            this.ShowReturnDetailsToolStripMenuItem.Image = global::CarRental.Properties.Resources.person_details32;
            this.ShowReturnDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowReturnDetailsToolStripMenuItem.Name = "ShowReturnDetailsToolStripMenuItem";
            this.ShowReturnDetailsToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.ShowReturnDetailsToolStripMenuItem.Text = "   Show Return Details";
            this.ShowReturnDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowReturnDetailsToolStripMenuItem_Click);
            // 
            // ShowBookingDetailsToolStripMenuItem1
            // 
            this.ShowBookingDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.ShowBookingDetailsToolStripMenuItem1.Image = global::CarRental.Properties.Resources.person_details32;
            this.ShowBookingDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowBookingDetailsToolStripMenuItem1.Name = "ShowBookingDetailsToolStripMenuItem1";
            this.ShowBookingDetailsToolStripMenuItem1.Size = new System.Drawing.Size(259, 38);
            this.ShowBookingDetailsToolStripMenuItem1.Text = "   Show Booking Details";
            this.ShowBookingDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowBookingDetailsToolStripMenuItem1_Click);
            // 
            // ShowCustomerDetailsToolStripMenuItem
            // 
            this.ShowCustomerDetailsToolStripMenuItem.Image = global::CarRental.Properties.Resources.person_details32;
            this.ShowCustomerDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowCustomerDetailsToolStripMenuItem.Name = "ShowCustomerDetailsToolStripMenuItem";
            this.ShowCustomerDetailsToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.ShowCustomerDetailsToolStripMenuItem.Text = "   Show Customer Details";
            this.ShowCustomerDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowCustomerDetailsToolStripMenuItem_Click);
            // 
            // ShowVehicleDetailsToolStripMenuItem
            // 
            this.ShowVehicleDetailsToolStripMenuItem.Image = global::CarRental.Properties.Resources.person_details32;
            this.ShowVehicleDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowVehicleDetailsToolStripMenuItem.Name = "ShowVehicleDetailsToolStripMenuItem";
            this.ShowVehicleDetailsToolStripMenuItem.Size = new System.Drawing.Size(259, 38);
            this.ShowVehicleDetailsToolStripMenuItem.Text = "   Show Vehicle Details";
            this.ShowVehicleDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowVehicleDetailsToolStripMenuItem_Click);
            // 
            // dtpActualReturnDate
            // 
            this.dtpActualReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActualReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpActualReturnDate.Location = new System.Drawing.Point(349, 242);
            this.dtpActualReturnDate.Name = "dtpActualReturnDate";
            this.dtpActualReturnDate.Size = new System.Drawing.Size(146, 26);
            this.dtpActualReturnDate.TabIndex = 191;
            this.dtpActualReturnDate.Visible = false;
            this.dtpActualReturnDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // pbImage
            // 
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImage.Image = global::CarRental.Properties.Resources.Return;
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(508, 31);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(306, 170);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 188;
            this.pbImage.TabStop = false;
            // 
            // btnAddNewReturn
            // 
            this.btnAddNewReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewReturn.Image = global::CarRental.Properties.Resources.car_return48;
            this.btnAddNewReturn.Location = new System.Drawing.Point(1284, 216);
            this.btnAddNewReturn.Name = "btnAddNewReturn";
            this.btnAddNewReturn.Size = new System.Drawing.Size(70, 55);
            this.btnAddNewReturn.TabIndex = 190;
            this.btnAddNewReturn.UseVisualStyleBackColor = true;
            this.btnAddNewReturn.Click += new System.EventHandler(this.btnAddNewReturn_Click);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(115, 749);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(27, 20);
            this.lblNumberOfRecords.TabIndex = 187;
            this.lblNumberOfRecords.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 749);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 186;
            this.label2.Text = "# Records:";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Return ID",
            "Customer ID",
            "Vehicle ID",
            "Booking ID",
            "Transaction ID",
            "Customer Name",
            "Actual Return Date"});
            this.cbFilter.Location = new System.Drawing.Point(99, 242);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(234, 28);
            this.cbFilter.TabIndex = 185;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(349, 242);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(256, 26);
            this.txtSearch.TabIndex = 184;
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
            this.label1.TabIndex = 183;
            this.label1.Text = "Filter By:";
            // 
            // dgvReturnList
            // 
            this.dgvReturnList.AllowUserToAddRows = false;
            this.dgvReturnList.AllowUserToDeleteRows = false;
            this.dgvReturnList.AllowUserToOrderColumns = true;
            this.dgvReturnList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReturnList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReturnList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvReturnList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvReturnList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReturnList.ColumnHeadersHeight = 40;
            this.dgvReturnList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturnList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReturnList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvReturnList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvReturnList.Location = new System.Drawing.Point(15, 277);
            this.dgvReturnList.Name = "dgvReturnList";
            this.dgvReturnList.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturnList.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvReturnList.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReturnList.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvReturnList.RowTemplate.Height = 33;
            this.dgvReturnList.ShowCellToolTips = false;
            this.dgvReturnList.Size = new System.Drawing.Size(1344, 469);
            this.dgvReturnList.TabIndex = 192;
            this.dgvReturnList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.WetAsphalt;
            this.dgvReturnList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.dgvReturnList.ThemeStyle.AlternatingRowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReturnList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReturnList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReturnList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReturnList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReturnList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.dgvReturnList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.dgvReturnList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReturnList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReturnList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReturnList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReturnList.ThemeStyle.HeaderStyle.Height = 40;
            this.dgvReturnList.ThemeStyle.ReadOnly = true;
            this.dgvReturnList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.dgvReturnList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReturnList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReturnList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvReturnList.ThemeStyle.RowsStyle.Height = 33;
            this.dgvReturnList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(133)))), ((int)(((byte)(147)))));
            this.dgvReturnList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvReturnList.DoubleClick += new System.EventHandler(this.dgvReturnList_DoubleClick);
            // 
            // frmListReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1366, 800);
            this.Controls.Add(this.dgvReturnList);
            this.Controls.Add(this.dtpActualReturnDate);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.btnAddNewReturn);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Manage Return";
            this.Text = "frmListReturn";
            this.Load += new System.EventHandler(this.frmListReturn_Load);
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturnList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowBookingDetailsToolStripMenuItem1;
        private System.Windows.Forms.DateTimePicker dtpActualReturnDate;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnAddNewReturn;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ShowReturnDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowCustomerDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowVehicleDetailsToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2DataGridView dgvReturnList;
    }
}