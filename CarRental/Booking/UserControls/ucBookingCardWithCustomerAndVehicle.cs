using CarRental_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Booking.UserControls
{
    public partial class ucBookingCardWithCustomerAndVehicle : UserControl
    {
        public int? BookingID => ucBookingCard1.BookingID;
        public clsBooking BookingInfo => ucBookingCard1.BookingInfo;

        public int? CustomerID => ucSelectedCustomerAndVehicleCard1.CustomerID;
        public clsCustomer CustomerInfo => ucSelectedCustomerAndVehicleCard1.SelectedCustomerInfo;

        public int? VehicleID => ucSelectedCustomerAndVehicleCard1.VehicleID;
        public clsVehicle VehicleInfo => ucSelectedCustomerAndVehicleCard1.SelectedVehicleInfo;

        public ucBookingCardWithCustomerAndVehicle()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            ucSelectedCustomerAndVehicleCard1.Clear();
            ucBookingCard1.Reset();
        }

        public void LoadBookingWithCustomerAndVehicleInfo(int? BookingID)
        {
            ucBookingCard1.LoadBookingInfo(BookingID);

            ucSelectedCustomerAndVehicleCard1.LoadCustomerVehicleInfo(BookingInfo.CustomerID, BookingInfo.VehicleID);
        }

    }
}
