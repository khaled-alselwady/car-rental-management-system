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
    public partial class frmShowTransactionDetailsWithBookingAndReturn : Form
    {
        public frmShowTransactionDetailsWithBookingAndReturn(int? TransactionID)
        {
            InitializeComponent();

            ucTransactionCardWithBookingAndReturn1.
                LoadTransactionWithBookingAndReturnInfo(TransactionID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
