namespace CarRental.Transaction.UserControls
{
    partial class ucTransactionCardWithBookingAndReturn
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
            this.ucBookingAndReturnCard1 = new CarRental.Transaction.UserControls.ucBookingAndReturnCard();
            this.ucTransactionCard1 = new CarRental.Transaction.UserControls.ucTransactionCard();
            this.SuspendLayout();
            // 
            // ucBookingAndReturnCard1
            // 
            this.ucBookingAndReturnCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucBookingAndReturnCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucBookingAndReturnCard1.Location = new System.Drawing.Point(0, 0);
            this.ucBookingAndReturnCard1.Name = "ucBookingAndReturnCard1";
            this.ucBookingAndReturnCard1.Size = new System.Drawing.Size(799, 304);
            this.ucBookingAndReturnCard1.TabIndex = 0;
            // 
            // ucTransactionCard1
            // 
            this.ucTransactionCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucTransactionCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucTransactionCard1.Location = new System.Drawing.Point(4, 301);
            this.ucTransactionCard1.Name = "ucTransactionCard1";
            this.ucTransactionCard1.Size = new System.Drawing.Size(785, 259);
            this.ucTransactionCard1.TabIndex = 1;
            // 
            // ucTransactionCardWithBookingAndReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ucTransactionCard1);
            this.Controls.Add(this.ucBookingAndReturnCard1);
            this.Name = "ucTransactionCardWithBookingAndReturn";
            this.Size = new System.Drawing.Size(800, 563);
            this.ResumeLayout(false);

        }

        #endregion

        private ucBookingAndReturnCard ucBookingAndReturnCard1;
        private ucTransactionCard ucTransactionCard1;
    }
}
