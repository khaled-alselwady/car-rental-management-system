namespace CarRental.Transaction.UserControls
{
    partial class ucBookingAndReturnCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcSelectCustomerVehicle = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpBooking = new System.Windows.Forms.TabPage();
            this.ucBookingCard1 = new CarRental.Booking.UserControls.ucBookingCard();
            this.tpReturn = new System.Windows.Forms.TabPage();
            this.ucReturnCard1 = new CarRental.Return.UserControls.ucReturnCard();
            this.tcSelectCustomerVehicle.SuspendLayout();
            this.tpBooking.SuspendLayout();
            this.tpReturn.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSelectCustomerVehicle
            // 
            this.tcSelectCustomerVehicle.Controls.Add(this.tpBooking);
            this.tcSelectCustomerVehicle.Controls.Add(this.tpReturn);
            this.tcSelectCustomerVehicle.ItemSize = new System.Drawing.Size(180, 40);
            this.tcSelectCustomerVehicle.Location = new System.Drawing.Point(2, 2);
            this.tcSelectCustomerVehicle.Margin = new System.Windows.Forms.Padding(2);
            this.tcSelectCustomerVehicle.Name = "tcSelectCustomerVehicle";
            this.tcSelectCustomerVehicle.SelectedIndex = 0;
            this.tcSelectCustomerVehicle.Size = new System.Drawing.Size(793, 298);
            this.tcSelectCustomerVehicle.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcSelectCustomerVehicle.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcSelectCustomerVehicle.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcSelectCustomerVehicle.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcSelectCustomerVehicle.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcSelectCustomerVehicle.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.tcSelectCustomerVehicle.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcSelectCustomerVehicle.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcSelectCustomerVehicle.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcSelectCustomerVehicle.TabButtonIdleState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcSelectCustomerVehicle.TabButtonSelectedState.BorderColor = System.Drawing.Color.Empty;
            this.tcSelectCustomerVehicle.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(37)))), ((int)(((byte)(49)))));
            this.tcSelectCustomerVehicle.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcSelectCustomerVehicle.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcSelectCustomerVehicle.TabButtonSelectedState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(132)))), ((int)(((byte)(255)))));
            this.tcSelectCustomerVehicle.TabButtonSize = new System.Drawing.Size(180, 40);
            this.tcSelectCustomerVehicle.TabIndex = 2;
            this.tcSelectCustomerVehicle.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcSelectCustomerVehicle.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tpBooking
            // 
            this.tpBooking.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpBooking.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpBooking.Controls.Add(this.ucBookingCard1);
            this.tpBooking.Location = new System.Drawing.Point(4, 44);
            this.tpBooking.Margin = new System.Windows.Forms.Padding(2);
            this.tpBooking.Name = "tpBooking";
            this.tpBooking.Padding = new System.Windows.Forms.Padding(2);
            this.tpBooking.Size = new System.Drawing.Size(785, 250);
            this.tpBooking.TabIndex = 0;
            this.tpBooking.Text = "Booking Info";
            // 
            // ucBookingCard1
            // 
            this.ucBookingCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucBookingCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBookingCard1.Location = new System.Drawing.Point(0, 0);
            this.ucBookingCard1.Name = "ucBookingCard1";
            this.ucBookingCard1.Size = new System.Drawing.Size(785, 249);
            this.ucBookingCard1.TabIndex = 0;
            // 
            // tpReturn
            // 
            this.tpReturn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpReturn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpReturn.Controls.Add(this.ucReturnCard1);
            this.tpReturn.Location = new System.Drawing.Point(4, 44);
            this.tpReturn.Margin = new System.Windows.Forms.Padding(2);
            this.tpReturn.Name = "tpReturn";
            this.tpReturn.Padding = new System.Windows.Forms.Padding(2);
            this.tpReturn.Size = new System.Drawing.Size(785, 250);
            this.tpReturn.TabIndex = 1;
            this.tpReturn.Text = "Return Info";
            // 
            // ucReturnCard1
            // 
            this.ucReturnCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucReturnCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucReturnCard1.Location = new System.Drawing.Point(0, 0);
            this.ucReturnCard1.Name = "ucReturnCard1";
            this.ucReturnCard1.Size = new System.Drawing.Size(784, 230);
            this.ucReturnCard1.TabIndex = 0;
            // 
            // ucBookingAndReturnCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tcSelectCustomerVehicle);
            this.Name = "ucBookingAndReturnCard";
            this.Size = new System.Drawing.Size(799, 300);
            this.tcSelectCustomerVehicle.ResumeLayout(false);
            this.tpBooking.ResumeLayout(false);
            this.tpReturn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcSelectCustomerVehicle;
        private System.Windows.Forms.TabPage tpBooking;
        private Booking.UserControls.ucBookingCard ucBookingCard1;
        private System.Windows.Forms.TabPage tpReturn;
        private Return.UserControls.ucReturnCard ucReturnCard1;
    }
}
