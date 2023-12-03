namespace CarRental.Booking.UserControls
{
    partial class ucBookingCardWithCustomerAndVehicle
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
            this.ucSelectedCustomerAndVehicleCard1 = new CarRental.Booking.UserControls.ucSelectedCustomerAndVehicleCard();
            this.ucBookingCard1 = new CarRental.Booking.UserControls.ucBookingCard();
            this.SuspendLayout();
            // 
            // ucSelectedCustomerAndVehicleCard1
            // 
            this.ucSelectedCustomerAndVehicleCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucSelectedCustomerAndVehicleCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucSelectedCustomerAndVehicleCard1.Location = new System.Drawing.Point(0, 0);
            this.ucSelectedCustomerAndVehicleCard1.Name = "ucSelectedCustomerAndVehicleCard1";
            this.ucSelectedCustomerAndVehicleCard1.Size = new System.Drawing.Size(796, 456);
            this.ucSelectedCustomerAndVehicleCard1.TabIndex = 0;
            // 
            // ucBookingCard1
            // 
            this.ucBookingCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucBookingCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBookingCard1.Location = new System.Drawing.Point(5, 454);
            this.ucBookingCard1.Name = "ucBookingCard1";
            this.ucBookingCard1.Size = new System.Drawing.Size(785, 248);
            this.ucBookingCard1.TabIndex = 1;
            // 
            // ucBookingCardWithCustomerAndVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ucBookingCard1);
            this.Controls.Add(this.ucSelectedCustomerAndVehicleCard1);
            this.Name = "ucBookingCardWithCustomerAndVehicle";
            this.Size = new System.Drawing.Size(794, 702);
            this.ResumeLayout(false);

        }

        #endregion

        private ucSelectedCustomerAndVehicleCard ucSelectedCustomerAndVehicleCard1;
        private ucBookingCard ucBookingCard1;
    }
}
