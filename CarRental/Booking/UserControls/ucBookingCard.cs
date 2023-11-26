using CarRental.GlobalClasses;
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
    public partial class ucBookingCard : UserControl
    {
        private int? _BookingID = null;
        private clsBooking _Booking;

        public int? BookingID => _BookingID;
        public clsBooking BookingInfo => _Booking;

        public int? CustomerID => ucSelectedCustomerAndVehicleCard1.CustomerID;
        public clsCustomer CustomerInfo => ucSelectedCustomerAndVehicleCard1.SelectedCustomerInfo;

        public int? VehicleID => ucSelectedCustomerAndVehicleCard1.VehicleID;
        public clsVehicle VehicleInfo => ucSelectedCustomerAndVehicleCard1.SelectedVehicleInfo;

        public ucBookingCard()
        {
            InitializeComponent();
        }

        private void _FillBookingInfo()
        {
            ucSelectedCustomerAndVehicleCard1.LoadCustomerVehicleInfo(_Booking.CustomerID, _Booking.VehicleID);

            lblBookingID.Text = _Booking.BookingID.ToString();
            lblStartDate.Text = clsFormat.DateToShort(_Booking.RentalStartDate);
            lblEndDate.Text = clsFormat.DateToShort(_Booking.RentalEndDate);
            lblInitialRentalDays.Text = _Booking.InitialRentalDays.ToString();
            lblInitialTotalDueAmount.Text = _Booking.InitialTotalDueAmount?.ToString("N");
            lblPickUpLocation.Text = _Booking.PickupLocation;
            lblDropOffLocation.Text = _Booking.DropoffLocation;
            lblInitialCheckNotes.Text = string.IsNullOrWhiteSpace(_Booking.InitialCheckNotes) ? "No Notes" : _Booking.InitialCheckNotes;
        }

        public void Reset()
        {
            _BookingID = null;    
            _Booking = null;

            lblBookingID.Text = "[????]";
            lblStartDate.Text = "[????]";
            lblEndDate.Text = "[????]";
            lblInitialRentalDays.Text = "[????]";
            lblInitialTotalDueAmount.Text = "[????]";
            lblPickUpLocation.Text = "[????]";
            lblDropOffLocation.Text = "[????]";
        }

        public void LoadBookingInfo(int? BookingID)
        {
            _BookingID = BookingID;

            if (!_BookingID.HasValue)
            {
                MessageBox.Show("There is no booking", "Missing Booking",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Booking = clsBooking.Find(_BookingID);

            if (_Booking == null)
            {
                MessageBox.Show($"There is no booking with ID = {BookingID}", "Missing Booking",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _FillBookingInfo();
        }

    }
}
