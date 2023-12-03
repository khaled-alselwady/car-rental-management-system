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
    public partial class frmShowBookingDetailsWithCustomerAndVehicle : Form
    {
        public frmShowBookingDetailsWithCustomerAndVehicle(int? BookingID)
        {
            InitializeComponent();

            ucBookingCardWithCustomerAndVehicle1.LoadBookingWithCustomerAndVehicleInfo(BookingID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
