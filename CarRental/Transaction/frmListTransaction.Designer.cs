namespace CarRental.Transaction
{
    partial class frmListTransaction
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
            this.dgvTransactionList = new System.Windows.Forms.DataGridView();
            this.cmsEditProfile = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.ShowTransactionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCustomerDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowVehicleDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowBookingDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowReturnDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TakeOrPayRefundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.cbTransactionType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionList)).BeginInit();
            this.cmsEditProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTransactionList
            // 
            this.dgvTransactionList.AllowUserToAddRows = false;
            this.dgvTransactionList.AllowUserToDeleteRows = false;
            this.dgvTransactionList.AllowUserToResizeRows = false;
            this.dgvTransactionList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactionList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactionList.ContextMenuStrip = this.cmsEditProfile;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactionList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactionList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTransactionList.Location = new System.Drawing.Point(15, 277);
            this.dgvTransactionList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvTransactionList.MultiSelect = false;
            this.dgvTransactionList.Name = "dgvTransactionList";
            this.dgvTransactionList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactionList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactionList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactionList.Size = new System.Drawing.Size(1340, 467);
            this.dgvTransactionList.TabIndex = 189;
            this.dgvTransactionList.TabStop = false;
            this.dgvTransactionList.DoubleClick += new System.EventHandler(this.dgvTransactionList_DoubleClick);
            // 
            // cmsEditProfile
            // 
            this.cmsEditProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cmsEditProfile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsEditProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowTransactionToolStripMenuItem1,
            this.ShowCustomerDetailsToolStripMenuItem,
            this.ShowVehicleDetailsToolStripMenuItem,
            this.ShowBookingDetailsToolStripMenuItem1,
            this.ShowReturnDetailsToolStripMenuItem,
            this.TakeOrPayRefundToolStripMenuItem});
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
            this.cmsEditProfile.Size = new System.Drawing.Size(272, 254);
            this.cmsEditProfile.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEditProfile_Opening);
            // 
            // ShowTransactionToolStripMenuItem1
            // 
            this.ShowTransactionToolStripMenuItem1.Image = global::CarRental.Properties.Resources.Notes_32;
            this.ShowTransactionToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowTransactionToolStripMenuItem1.Name = "ShowTransactionToolStripMenuItem1";
            this.ShowTransactionToolStripMenuItem1.Size = new System.Drawing.Size(271, 38);
            this.ShowTransactionToolStripMenuItem1.Text = "   Show Transaction Details";
            this.ShowTransactionToolStripMenuItem1.Click += new System.EventHandler(this.ShowTransactionToolStripMenuItem1_Click);
            // 
            // ShowCustomerDetailsToolStripMenuItem
            // 
            this.ShowCustomerDetailsToolStripMenuItem.Image = global::CarRental.Properties.Resources.person_details32;
            this.ShowCustomerDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowCustomerDetailsToolStripMenuItem.Name = "ShowCustomerDetailsToolStripMenuItem";
            this.ShowCustomerDetailsToolStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.ShowCustomerDetailsToolStripMenuItem.Text = "   Show Customer Details";
            this.ShowCustomerDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowCustomerDetailsToolStripMenuItem_Click);
            // 
            // ShowVehicleDetailsToolStripMenuItem
            // 
            this.ShowVehicleDetailsToolStripMenuItem.Image = global::CarRental.Properties.Resources.Notes_32;
            this.ShowVehicleDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowVehicleDetailsToolStripMenuItem.Name = "ShowVehicleDetailsToolStripMenuItem";
            this.ShowVehicleDetailsToolStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.ShowVehicleDetailsToolStripMenuItem.Text = "   Show Vehicle Details";
            this.ShowVehicleDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowVehicleDetailsToolStripMenuItem_Click);
            // 
            // ShowBookingDetailsToolStripMenuItem1
            // 
            this.ShowBookingDetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.ShowBookingDetailsToolStripMenuItem1.Image = global::CarRental.Properties.Resources.edit_32;
            this.ShowBookingDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowBookingDetailsToolStripMenuItem1.Name = "ShowBookingDetailsToolStripMenuItem1";
            this.ShowBookingDetailsToolStripMenuItem1.Size = new System.Drawing.Size(271, 38);
            this.ShowBookingDetailsToolStripMenuItem1.Text = "   Show Booking Details";
            this.ShowBookingDetailsToolStripMenuItem1.Click += new System.EventHandler(this.ShowBookingDetailsToolStripMenuItem1_Click);
            // 
            // ShowReturnDetailsToolStripMenuItem
            // 
            this.ShowReturnDetailsToolStripMenuItem.Image = global::CarRental.Properties.Resources.Calendar_32;
            this.ShowReturnDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ShowReturnDetailsToolStripMenuItem.Name = "ShowReturnDetailsToolStripMenuItem";
            this.ShowReturnDetailsToolStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.ShowReturnDetailsToolStripMenuItem.Text = "   Show Return Details";
            this.ShowReturnDetailsToolStripMenuItem.Click += new System.EventHandler(this.ShowReturnDetailsToolStripMenuItem_Click);
            // 
            // TakeOrPayRefundToolStripMenuItem
            // 
            this.TakeOrPayRefundToolStripMenuItem.Enabled = false;
            this.TakeOrPayRefundToolStripMenuItem.Image = global::CarRental.Properties.Resources.Release_Detained_License_32;
            this.TakeOrPayRefundToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TakeOrPayRefundToolStripMenuItem.Name = "TakeOrPayRefundToolStripMenuItem";
            this.TakeOrPayRefundToolStripMenuItem.Size = new System.Drawing.Size(271, 38);
            this.TakeOrPayRefundToolStripMenuItem.Text = "   Take Refund";
            this.TakeOrPayRefundToolStripMenuItem.Click += new System.EventHandler(this.TakeOrPayRefundToolStripMenuItem_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(341, 242);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(146, 26);
            this.dtpDate.TabIndex = 191;
            this.dtpDate.Visible = false;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
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
            "Transaction ID",
            "Booking ID",
            "Customer ID",
            "Customer Name",
            "Return ID",
            "Transaction Type",
            "Transaction Date",
            "Updated Transaction Date"});
            this.cbFilter.Location = new System.Drawing.Point(99, 242);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(231, 28);
            this.cbFilter.TabIndex = 185;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(341, 242);
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
            // pbImage
            // 
            this.pbImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImage.Image = global::CarRental.Properties.Resources.rental_price_per_day321;
            this.pbImage.InitialImage = null;
            this.pbImage.Location = new System.Drawing.Point(506, 31);
            this.pbImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(306, 189);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 188;
            this.pbImage.TabStop = false;
            // 
            // cbTransactionType
            // 
            this.cbTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTransactionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTransactionType.FormattingEnabled = true;
            this.cbTransactionType.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Payment Received",
            "Refund Issued",
            "No Action Taken"});
            this.cbTransactionType.Location = new System.Drawing.Point(341, 242);
            this.cbTransactionType.Name = "cbTransactionType";
            this.cbTransactionType.Size = new System.Drawing.Size(177, 28);
            this.cbTransactionType.TabIndex = 192;
            this.cbTransactionType.SelectedIndexChanged += new System.EventHandler(this.cbTransactionType_SelectedIndexChanged);
            // 
            // frmListTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1366, 800);
            this.Controls.Add(this.cbTransactionType);
            this.Controls.Add(this.dgvTransactionList);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmListTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Manage Transaction";
            this.Text = "frmListTransaction";
            this.Load += new System.EventHandler(this.frmListTransaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactionList)).EndInit();
            this.cmsEditProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTransactionList;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip cmsEditProfile;
        private System.Windows.Forms.ToolStripMenuItem ShowReturnDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowBookingDetailsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ShowCustomerDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowVehicleDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowTransactionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TakeOrPayRefundToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbTransactionType;
    }
}