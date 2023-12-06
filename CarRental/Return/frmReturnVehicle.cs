using CarRental.Booking.UserControls;
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
using System.Web.Util;
using System.Windows.Forms;
using static CarRental.Booking.UserControls.ucBookingCardWithFilter;

namespace CarRental.Return
{
    public partial class frmReturnVehicle : Form
    {
        public Action<int?> GetReturnByDelegate;

        private int? _SelectedBookingID = null;

        private int? _ReturnID = null;
        private clsReturn _Return;

        public frmReturnVehicle()
        {
            InitializeComponent();
        }

        public frmReturnVehicle(int? BookingID)
        {
            InitializeComponent();

            ucBookingCardWithFilter1.LoadBookingInfo(BookingID);
            ucBookingCardWithFilter1.FilterEnabled = false;
        }

        private bool _UpdateMileageOfTheVehicleInDB()
        {
            return ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.
                   UpdateMileage((int)double.Parse(txtMileage.Text.Trim())) ?? false;
        }

        private bool _SetVehicleAvailableForRent()
        {
            return ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.
                SetAvailableForRent() ?? false;
        }

        private int _CalculateActualRentalDays()
        {
            int DiffDays = (dtpActualReturnDate.Value.Date - ucBookingCardWithFilter1.SelectedBookingInfo.RentalStartDate.Date).Days;

            return DiffDays;
        }

        private double _CalculateConsumedMileage()
        {
            double InitialMileage = ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.Mileage ?? 0;
            double FinalMileage = double.Parse(txtMileage.Text.Trim());

            return (FinalMileage) - (InitialMileage);
        }

        private float _CalculateActualTotalDueAmount()
        {
            float RentalPricePerDay = ucBookingCardWithFilter1.SelectedBookingInfo?.RentalPricePerDay ?? 0;
            int ActualRentalDays = _CalculateActualRentalDays();
            float AdditionalCharges = Convert.ToSingle(txtAdditionalCharges.Text.Trim());

            return (ActualRentalDays * RentalPricePerDay) + AdditionalCharges;
        }

        private void _Reset()
        {
            ucBookingCardWithFilter1.FilterEnabled = false;

            txtAdditionalCharges.Enabled = false;
            txtFinalCheckNotes.Enabled = false;
            txtMileage.Enabled = false;

            btnReturn.Enabled = false;

            dtpActualReturnDate.Enabled = false;
        }

        private void _ReturnVehicle()
        {
            _Return = new clsReturn();

            _Return.ActualReturnDate = dtpActualReturnDate.Value;
            _Return.Mileage = int.Parse(txtMileage.Text.Trim());
            _Return.FinalCheckNotes = txtFinalCheckNotes.Text.Trim();
            _Return.AdditionalCharges = Convert.ToSingle(txtAdditionalCharges.Text.Trim());
            _Return.ConsumedMileage = (int)_CalculateConsumedMileage();
            _Return.ActualRentalDays = _CalculateActualRentalDays();
            _Return.ActualTotalDueAmount = _CalculateActualTotalDueAmount();

            if (!_Return.Save())
            {
                MessageBox.Show("Vehicle Returned Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!_Return.UpdateTransaction(ucBookingCardWithFilter1.SelectedBookingInfo?
                .TransactionInfo?.TransactionID))
            {
                MessageBox.Show("Vehicle Returned Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }


            lblReturnID.Text = _Return.ReturnID?.ToString();
            lblActualRentalDays.Text = _Return.ActualRentalDays.ToString();
            lblConsumedMileage.Text = _Return.ConsumedMileage.ToString();
            lblActualTotalDueAmount.Text = _Return.ActualTotalDueAmount.ToString("N");


            MessageBox.Show($"Vehicle Returned Successfully", "Returned",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

            _ReturnID = _Return.ReturnID;

            llShowReturnDetails.Enabled = true;
            llShowUpdateTransactionDetails.Enabled = true;
            

            _Reset();

            _UpdateMileageOfTheVehicleInDB();
            _SetVehicleAvailableForRent();

            GetReturnByDelegate?.Invoke(_Return.ReturnID.Value);
        }

        private void txtFinalCheckNotes_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFinalCheckNotes.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFinalCheckNotes, "This field cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFinalCheckNotes, null);

            }
        }

        private void frmReturnVehicle_Load(object sender, EventArgs e)
        {
            dtpActualReturnDate.MinDate = DateTime.Now;
        }

        private void ucBookingCardWithFilter1_OnBookingSelected(object sender, BookingSelectedEventArgs e)
        {
            _SelectedBookingID = e.BookingID;

            if (!_SelectedBookingID.HasValue)
            {
                btnReturn.Enabled = false;

                return;
            }

            if (ucBookingCardWithFilter1.SelectedBookingInfo.IsBookingReturned)
            {
                MessageBox.Show("This booking has finished and the vehicle is already returned!", "Not Allow",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                btnReturn.Enabled = false;

                return;
            }

            btnReturn.Enabled = true;

            lblActualRentalDays.Text = _CalculateActualRentalDays().ToString();
        }

        private void txtAdditionalCharges_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtAdditionalCharges.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAdditionalCharges, "This field cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtAdditionalCharges, null);

            }


            if (!clsValidation.IsNumber(txtAdditionalCharges.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAdditionalCharges, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtAdditionalCharges, null);
            }
        }

        private void txtMileage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMileage.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMileage, "This field cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMileage, null);

            }


            if (!clsValidation.IsNumber(txtMileage.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMileage, "Invalid Number.");
                return;
            }
            else
            {
                errorProvider1.SetError(txtMileage, null);
            }


            if (_SelectedBookingID.HasValue &&
                double.Parse(txtMileage.Text.Trim()) < ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.Mileage)
            {
                e.Cancel = true;

                errorProvider1.SetError(txtMileage, $"The initial mileage of this car was" +
                    $" {ucBookingCardWithFilter1.SelectedBookingInfo?.VehicleInfo?.Mileage}" +
                    $" \nso you cannot enter the mileage is less that it!");
            }
            else
            {
                errorProvider1.SetError(txtMileage, null);
            }
        }

        private void dtpActualReturnDate_ValueChanged(object sender, EventArgs e)
        {
            if (!_SelectedBookingID.HasValue)
            {
                return;
            }

            lblActualRentalDays.Text = _CalculateActualRentalDays().ToString();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ReturnVehicle();
        }

        private void llShowReturnDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle(_ReturnID);
            ShowReturnDetails.ShowDialog();
        }

        private void llShowUpdateTransactionDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTransactionDetails ShowTransactionDetails = new frmShowTransactionDetails(ucBookingCardWithFilter1.SelectedBookingInfo?.TransactionInfo?.TransactionID);
            ShowTransactionDetails.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
