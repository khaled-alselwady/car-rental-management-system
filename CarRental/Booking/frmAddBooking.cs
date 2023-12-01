using CarRental_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Util;
using System.Windows.Forms;

namespace CarRental.Booking
{
    public partial class frmAddBooking : Form
    {
        public Action<int?> GetBookingIDByDelegate;
        public Action RefreshBookingInfo;

        public frmAddBooking()
        {
            InitializeComponent();

        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(((TextBox)sender), "This field is required!");
            }
            else
            {
                errorProvider1.SetError(((TextBox)sender), null);
            }
        }

        private void _UpdateInitialDays()
        {
            dtpEndDate.MinDate = dtpStartDate.Value.AddDays(1);

            int initialDays = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days;
            lblInitialRentalDays.Text = initialDays.ToString();
        }

        private void _LoadData()
        {
            dtpStartDate.MinDate = DateTime.Now;
            dtpEndDate.MinDate = DateTime.Now.AddDays(1);  // The minimum rental period is one day

            int InitialDays = (dtpEndDate.Value.Date - dtpStartDate.Value.Date).Days;
            lblInitialRentalDays.Text = InitialDays.ToString();
        }

        private void frmAddBooking_Load(object sender, EventArgs e)
        {
            _LoadData();

            ucSelectedCustomerAndVehicleWithFilter1.SendCustomerID += _FillBookingInfoOnSelectedCustomer;
            ucSelectedCustomerAndVehicleWithFilter1.SendVehicleID += _FillBookingInfoOnSelectedVehicle;
        }

        private void _FillBookingInfoOnSelectedCustomer(int? CustomerID)
        {
            clsCustomer Customer = clsCustomer.Find(CustomerID);

            if (Customer == null)
            {
                lblCustomerID.Text = "[????]";
                btnBook.Enabled = false;

                return;
            }

            lblCustomerID.Text = Customer.CustomerID.ToString();

            if (ucSelectedCustomerAndVehicleWithFilter1.VehicleID.HasValue)
            {
                // here I already choose the vehicle, so I enable the btnBook
                btnBook.Enabled = true;
            }
        }

        private void _FillBookingInfoOnSelectedVehicle(int? VehicleID)
        {
            clsVehicle Vehicle = clsVehicle.Find(VehicleID);

            if (Vehicle == null)
            {
                btnBook.Enabled = false;
                return;
            }

            lblVehicleID.Text = Vehicle.VehicleID.ToString();
            lblRentalPricePerDay.Text = Vehicle.RentalPricePerDay.ToString("N");
            lblInitialTotalDueAmount.Text = ((Vehicle.RentalPricePerDay) * (int.Parse(lblInitialRentalDays.Text))).ToString("N");

            btnBook.Enabled = true;
        }

        private void _Reset()
        {
            btnBook.Enabled = false;
            ucSelectedCustomerAndVehicleWithFilter1.FilterEnable = false;
            txtPickUpLocation.Enabled = false;
            txtDropOffLocation.Enabled = false;
            txtInitailCheckNotes.Enabled = false;
            txtPaymentDetails.Enabled = false;
            dtpStartDate.Enabled = false;
            dtpEndDate.Enabled = false;
        }

        private void _MakeTransactionThenBooking()
        {
            clsTransaction Transaction = new clsTransaction();

            // Booking Info
            Transaction.CustomerID = ucSelectedCustomerAndVehicleWithFilter1.CustomerID;
            Transaction.VehicleID = ucSelectedCustomerAndVehicleWithFilter1.VehicleID;
            Transaction.RentalStartDate = dtpStartDate.Value;
            Transaction.RentalEndDate = dtpEndDate.Value;
            Transaction.PickupLocation = txtPickUpLocation.Text.Trim();
            Transaction.DropoffLocation = txtDropOffLocation.Text.Trim();
            Transaction.RentalPricePerDay = ucSelectedCustomerAndVehicleWithFilter1.SelectedVehicleInfo.RentalPricePerDay;
            Transaction.InitialCheckNotes = txtInitailCheckNotes.Text.Trim();

            // Transaction Info
            Transaction.PaidInitialTotalDueAmount = Convert.ToSingle(lblInitialTotalDueAmount.Text);
            Transaction.PaymentDetails = txtPaymentDetails.Text.Trim();


            if (!Transaction.Save())
            {
                MessageBox.Show("Vehicle Booked Failed", "Failed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                _Reset();

                return;
            }

            MessageBox.Show($"Vehicle Booked Successfully with Transaction ID = {Transaction.TransactionID.Value}", "Booked",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblBookingID.Text = Transaction.BookingID.Value.ToString();

            _Reset();

            RefreshBookingInfo?.Invoke();
            GetBookingIDByDelegate?.Invoke(Transaction.BookingID.Value);
        }       

        private void frmAddBooking_Activated(object sender, EventArgs e)
        {
            ucSelectedCustomerAndVehicleWithFilter1.FilterFocus();

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {          
            _UpdateInitialDays();

            _FillBookingInfoOnSelectedVehicle(ucSelectedCustomerAndVehicleWithFilter1.VehicleID);
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            _UpdateInitialDays();

            _FillBookingInfoOnSelectedVehicle(ucSelectedCustomerAndVehicleWithFilter1.VehicleID);
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _MakeTransactionThenBooking();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
