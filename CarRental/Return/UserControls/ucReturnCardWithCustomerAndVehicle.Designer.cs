namespace CarRental.Return.UserControls
{
    partial class ucReturnCardWithCustomerAndVehicle
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
            this.ucReturnCard1 = new CarRental.Return.UserControls.ucReturnCard();
            this.ucSelectedCustomerAndVehicleCard1 = new CarRental.Booking.UserControls.ucSelectedCustomerAndVehicleCard();
            this.SuspendLayout();
            // 
            // ucReturnCard1
            // 
            this.ucReturnCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucReturnCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucReturnCard1.Location = new System.Drawing.Point(7, 462);
            this.ucReturnCard1.Name = "ucReturnCard1";
            this.ucReturnCard1.Size = new System.Drawing.Size(784, 197);
            this.ucReturnCard1.TabIndex = 1;
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
            // ucReturnCardWithCustomerAndVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ucReturnCard1);
            this.Controls.Add(this.ucSelectedCustomerAndVehicleCard1);
            this.Name = "ucReturnCardWithCustomerAndVehicle";
            this.Size = new System.Drawing.Size(797, 661);
            this.ResumeLayout(false);

        }

        #endregion

        private Booking.UserControls.ucSelectedCustomerAndVehicleCard ucSelectedCustomerAndVehicleCard1;
        private ucReturnCard ucReturnCard1;
    }
}
