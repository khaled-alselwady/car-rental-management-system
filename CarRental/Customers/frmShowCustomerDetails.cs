using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Customers
{
    public partial class frmShowCustomerDetails : Form
    {
        public frmShowCustomerDetails(int CustomerID)
        {
            InitializeComponent();

            ucCustomerCard1.LoadCustomerInfo(CustomerID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
