using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Booking
{
    public partial class frmShowCustomerBookingHistory : Form
    {
        public frmShowCustomerBookingHistory(int CustomerID)
        {
            InitializeComponent();

            ucCustomerCard1.LoadCustomerInfo(CustomerID);
            ucCustomerBookingHistory1.LoadCustomerBookingHistoryInfo(CustomerID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
