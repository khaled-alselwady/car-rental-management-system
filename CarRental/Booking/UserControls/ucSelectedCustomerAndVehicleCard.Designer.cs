namespace CarRental.Booking.UserControls
{
    partial class ucSelectedCustomerAndVehicleCard
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
            this.tpSelectCustomer = new System.Windows.Forms.TabPage();
            this.tpSelectVehicle = new System.Windows.Forms.TabPage();
            this.ucCustomerCard1 = new CarRental.Customers.UserControls.ucCustomerCard();
            this.ucVehicleCard1 = new CarRental.Vehicles.UserControls.ucVehicleCard();
            this.tcSelectCustomerVehicle.SuspendLayout();
            this.tpSelectCustomer.SuspendLayout();
            this.tpSelectVehicle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcSelectCustomerVehicle
            // 
            this.tcSelectCustomerVehicle.Controls.Add(this.tpSelectCustomer);
            this.tcSelectCustomerVehicle.Controls.Add(this.tpSelectVehicle);
            this.tcSelectCustomerVehicle.ItemSize = new System.Drawing.Size(180, 40);
            this.tcSelectCustomerVehicle.Location = new System.Drawing.Point(2, 2);
            this.tcSelectCustomerVehicle.Margin = new System.Windows.Forms.Padding(2);
            this.tcSelectCustomerVehicle.Name = "tcSelectCustomerVehicle";
            this.tcSelectCustomerVehicle.SelectedIndex = 0;
            this.tcSelectCustomerVehicle.Size = new System.Drawing.Size(793, 452);
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
            this.tcSelectCustomerVehicle.TabIndex = 1;
            this.tcSelectCustomerVehicle.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcSelectCustomerVehicle.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            // 
            // tpSelectCustomer
            // 
            this.tpSelectCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpSelectCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpSelectCustomer.Controls.Add(this.ucCustomerCard1);
            this.tpSelectCustomer.Location = new System.Drawing.Point(4, 44);
            this.tpSelectCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.tpSelectCustomer.Name = "tpSelectCustomer";
            this.tpSelectCustomer.Padding = new System.Windows.Forms.Padding(2);
            this.tpSelectCustomer.Size = new System.Drawing.Size(785, 404);
            this.tpSelectCustomer.TabIndex = 0;
            this.tpSelectCustomer.Text = "Customer Info";
            // 
            // tpSelectVehicle
            // 
            this.tpSelectVehicle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tpSelectVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpSelectVehicle.Controls.Add(this.ucVehicleCard1);
            this.tpSelectVehicle.Location = new System.Drawing.Point(4, 44);
            this.tpSelectVehicle.Margin = new System.Windows.Forms.Padding(2);
            this.tpSelectVehicle.Name = "tpSelectVehicle";
            this.tpSelectVehicle.Padding = new System.Windows.Forms.Padding(2);
            this.tpSelectVehicle.Size = new System.Drawing.Size(785, 404);
            this.tpSelectVehicle.TabIndex = 1;
            this.tpSelectVehicle.Text = "Vehicle Info";
            // 
            // ucCustomerCard1
            // 
            this.ucCustomerCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucCustomerCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucCustomerCard1.Location = new System.Drawing.Point(20, 2);
            this.ucCustomerCard1.Name = "ucCustomerCard1";
            this.ucCustomerCard1.Size = new System.Drawing.Size(723, 397);
            this.ucCustomerCard1.TabIndex = 0;
            // 
            // ucVehicleCard1
            // 
            this.ucVehicleCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucVehicleCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucVehicleCard1.Location = new System.Drawing.Point(10, 5);
            this.ucVehicleCard1.Name = "ucVehicleCard1";
            this.ucVehicleCard1.Size = new System.Drawing.Size(772, 359);
            this.ucVehicleCard1.TabIndex = 0;
            // 
            // ucSelectedCustomerAndVehicleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.tcSelectCustomerVehicle);
            this.Name = "ucSelectedCustomerAndVehicleCard";
            this.Size = new System.Drawing.Size(796, 456);
            this.tcSelectCustomerVehicle.ResumeLayout(false);
            this.tpSelectCustomer.ResumeLayout(false);
            this.tpSelectVehicle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcSelectCustomerVehicle;
        private System.Windows.Forms.TabPage tpSelectCustomer;
        private System.Windows.Forms.TabPage tpSelectVehicle;
        private Customers.UserControls.ucCustomerCard ucCustomerCard1;
        private Vehicles.UserControls.ucVehicleCard ucVehicleCard1;
    }
}
