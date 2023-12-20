namespace CarRental.Booking.UserControls
{
    partial class ucSelectedCustomerAndVehicleWithFilter
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
            this.btnNext = new System.Windows.Forms.Button();
            this.ucCustomerCardWithFilter1 = new CarRental.Customers.UserControls.ucCustomerCardWithFilter();
            this.tpSelectVehicle = new System.Windows.Forms.TabPage();
            this.ucVehicleCardWithFilter1 = new CarRental.Vehicles.UserControls.ucVehicleCardWithFilter();
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
            this.tcSelectCustomerVehicle.Location = new System.Drawing.Point(0, 0);
            this.tcSelectCustomerVehicle.Margin = new System.Windows.Forms.Padding(2);
            this.tcSelectCustomerVehicle.Name = "tcSelectCustomerVehicle";
            this.tcSelectCustomerVehicle.SelectedIndex = 0;
            this.tcSelectCustomerVehicle.Size = new System.Drawing.Size(793, 573);
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
            this.tcSelectCustomerVehicle.TabIndex = 0;
            this.tcSelectCustomerVehicle.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(57)))));
            this.tcSelectCustomerVehicle.TabMenuOrientation = Guna.UI2.WinForms.TabMenuOrientation.HorizontalTop;
            this.tcSelectCustomerVehicle.SelectedIndexChanged += new System.EventHandler(this.tcSelectCustomerVehicle_SelectedIndexChanged);
            // 
            // tpSelectCustomer
            // 
            this.tpSelectCustomer.BackColor = System.Drawing.Color.White;
            this.tpSelectCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpSelectCustomer.Controls.Add(this.btnNext);
            this.tpSelectCustomer.Controls.Add(this.ucCustomerCardWithFilter1);
            this.tpSelectCustomer.Location = new System.Drawing.Point(4, 44);
            this.tpSelectCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.tpSelectCustomer.Name = "tpSelectCustomer";
            this.tpSelectCustomer.Padding = new System.Windows.Forms.Padding(2);
            this.tpSelectCustomer.Size = new System.Drawing.Size(785, 525);
            this.tpSelectCustomer.TabIndex = 0;
            this.tpSelectCustomer.Text = "Select Customer";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNext.Enabled = false;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::CarRental.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(621, 484);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(156, 37);
            this.btnNext.TabIndex = 119;
            this.btnNext.Text = "   Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ucCustomerCardWithFilter1
            // 
            this.ucCustomerCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucCustomerCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucCustomerCardWithFilter1.FilterEnabled = true;
            this.ucCustomerCardWithFilter1.Location = new System.Drawing.Point(18, 4);
            this.ucCustomerCardWithFilter1.Name = "ucCustomerCardWithFilter1";
            this.ucCustomerCardWithFilter1.ShowAddMemberButton = true;
            this.ucCustomerCardWithFilter1.Size = new System.Drawing.Size(725, 483);
            this.ucCustomerCardWithFilter1.TabIndex = 0;
            this.ucCustomerCardWithFilter1.OnCustomerSelected += new System.EventHandler<CarRental.Customers.UserControls.ucCustomerCardWithFilter.CustomerSelectedEventArgs>(this.ucCustomerCardWithFilter1_OnCustomerSelected);
            // 
            // tpSelectVehicle
            // 
            this.tpSelectVehicle.BackColor = System.Drawing.Color.White;
            this.tpSelectVehicle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpSelectVehicle.Controls.Add(this.ucVehicleCardWithFilter1);
            this.tpSelectVehicle.Location = new System.Drawing.Point(4, 44);
            this.tpSelectVehicle.Margin = new System.Windows.Forms.Padding(2);
            this.tpSelectVehicle.Name = "tpSelectVehicle";
            this.tpSelectVehicle.Padding = new System.Windows.Forms.Padding(2);
            this.tpSelectVehicle.Size = new System.Drawing.Size(785, 525);
            this.tpSelectVehicle.TabIndex = 1;
            this.tpSelectVehicle.Text = "Select Vehicle";
            // 
            // ucVehicleCardWithFilter1
            // 
            this.ucVehicleCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucVehicleCardWithFilter1.BackColor = System.Drawing.Color.White;
            this.ucVehicleCardWithFilter1.FilterEnabled = true;
            this.ucVehicleCardWithFilter1.Location = new System.Drawing.Point(5, 6);
            this.ucVehicleCardWithFilter1.Name = "ucVehicleCardWithFilter1";
            this.ucVehicleCardWithFilter1.ShowAddVehicleButton = true;
            this.ucVehicleCardWithFilter1.Size = new System.Drawing.Size(773, 447);
            this.ucVehicleCardWithFilter1.TabIndex = 0;
            this.ucVehicleCardWithFilter1.OnVehicleSelected += new System.EventHandler<CarRental.Vehicles.UserControls.ucVehicleCardWithFilter.VehicleSelectedEventArgs>(this.ucVehicleCardWithFilter1_OnVehicleSelected);
            // 
            // ucSelectedCustomerAndVehicleWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tcSelectCustomerVehicle);
            this.Name = "ucSelectedCustomerAndVehicleWithFilter";
            this.Size = new System.Drawing.Size(795, 574);
            this.tcSelectCustomerVehicle.ResumeLayout(false);
            this.tpSelectCustomer.ResumeLayout(false);
            this.tpSelectVehicle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TabControl tcSelectCustomerVehicle;
        private System.Windows.Forms.TabPage tpSelectCustomer;
        private Customers.UserControls.ucCustomerCardWithFilter ucCustomerCardWithFilter1;
        private System.Windows.Forms.TabPage tpSelectVehicle;
        private Vehicles.UserControls.ucVehicleCardWithFilter ucVehicleCardWithFilter1;
        private System.Windows.Forms.Button btnNext;
    }
}
