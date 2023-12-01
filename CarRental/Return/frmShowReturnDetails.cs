using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Return
{
    public partial class frmShowReturnDetails : Form
    {
        public frmShowReturnDetails(int? ReturnID)
        {
            InitializeComponent();

            ucReturnCardWithCustomerAndVehicle1.LoadReturnWithCustomerAndVehicleInfo(ReturnID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
