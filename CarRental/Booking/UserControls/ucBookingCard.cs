using CarRental.GlobalClasses;
using CarRental.Transaction;
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
        
        public ucBookingCard()
        {
            InitializeComponent();
        }

        private void _FillBookingInfo()
        {
            llTransactionInfo.Enabled = true;

            lblBookingID.Text = _Booking.BookingID?.ToString();
            lblCustomerID.Text = _Booking.CustomerID?.ToString();
            lblVehicleID.Text = _Booking.VehicleID?.ToString();
            lblStartDate.Text = clsFormat.DateToShort(_Booking.RentalStartDate);
            lblEndDate.Text = clsFormat.DateToShort(_Booking.RentalEndDate);
            lblInitialRentalDays.Text = _Booking.InitialRentalDays?.ToString();
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
            lblCustomerID.Text = "[????]";
            lblVehicleID.Text = "[????]";
            lblStartDate.Text = "[????]";
            lblEndDate.Text = "[????]";
            lblInitialRentalDays.Text = "[????]";
            lblInitialTotalDueAmount.Text = "[????]";
            lblPickUpLocation.Text = "[????]";
            lblDropOffLocation.Text = "[????]";

            llTransactionInfo.Enabled = false;
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

            _Booking = clsBooking.Find(_BookingID.Value);

            if (_Booking == null)
            {
                MessageBox.Show($"There is no booking with ID = {BookingID}", "Missing Booking",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _BookingID = null;

                return;
            }

            _FillBookingInfo();
        }

        private void llTransactionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTransactionDetails ShowTransactionDetails = new frmShowTransactionDetails(BookingInfo.TransactionInfo.TransactionID);
            ShowTransactionDetails.ShowDialog();
        }
    }
}
