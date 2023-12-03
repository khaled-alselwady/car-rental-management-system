namespace CarRental.Transaction
{
    partial class frmShowCustomerTransactionHistory
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ucCustomerCard1 = new CarRental.Customers.UserControls.ucCustomerCard();
            this.ucCustomerTransactionHistory1 = new CarRental.Transaction.UserControls.ucCustomerTransactionHistory();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.lblTitle.Location = new System.Drawing.Point(2, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(782, 48);
            this.lblTitle.TabIndex = 177;
            this.lblTitle.Text = "Customer Transaction History";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucCustomerCard1
            // 
            this.ucCustomerCard1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucCustomerCard1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucCustomerCard1.Location = new System.Drawing.Point(29, 69);
            this.ucCustomerCard1.Name = "ucCustomerCard1";
            this.ucCustomerCard1.Size = new System.Drawing.Size(723, 397);
            this.ucCustomerCard1.TabIndex = 178;
            // 
            // ucCustomerTransactionHistory1
            // 
            this.ucCustomerTransactionHistory1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ucCustomerTransactionHistory1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ucCustomerTransactionHistory1.Location = new System.Drawing.Point(5, 472);
            this.ucCustomerTransactionHistory1.Name = "ucCustomerTransactionHistory1";
            this.ucCustomerTransactionHistory1.Size = new System.Drawing.Size(777, 355);
            this.ucCustomerTransactionHistory1.TabIndex = 179;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::CarRental.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(621, 837);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(156, 37);
            this.btnClose.TabIndex = 199;
            this.btnClose.Text = "   Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmShowCustomerTransactionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 879);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucCustomerTransactionHistory1);
            this.Controls.Add(this.ucCustomerCard1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShowCustomerTransactionHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Customer Transaction History";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private Customers.UserControls.ucCustomerCard ucCustomerCard1;
        private UserControls.ucCustomerTransactionHistory ucCustomerTransactionHistory1;
        private System.Windows.Forms.Button btnClose;
    }
}