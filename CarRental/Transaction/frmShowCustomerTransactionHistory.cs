using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Transaction
{
    public partial class frmShowCustomerTransactionHistory : Form
    {
        public frmShowCustomerTransactionHistory(int? CustomerID)
        {
            InitializeComponent();

            ucCustomerCard1.LoadCustomerInfo(CustomerID);
            ucCustomerTransactionHistory1.LoadCustomerTransactionHistoryInfo(CustomerID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
