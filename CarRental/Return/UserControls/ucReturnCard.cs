using CarRental.Booking;
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

namespace CarRental.Return.UserControls
{
    public partial class ucReturnCard : UserControl
    {
        private int? _ReturnID = null;
        private clsReturn _Return;

        public int? ReturnID => _ReturnID;
        public clsReturn ReturnInfo => _Return;

        public ucReturnCard()
        {
            InitializeComponent();
        }

        private void _FillReturnInfo()
        {
            llShowBookingInfo.Enabled = true;
            llShowTransactionInfo.Enabled = true;

            lblReturnID.Text = _Return.ReturnID?.ToString();
            lblActualReturnDate.Text = clsFormat.DateToShort(_Return.ActualReturnDate);
            lblActualRentalDays.Text = _Return.ActualRentalDays.ToString();
            lblMileage.Text = _Return.Mileage.ToString();
            lblConsumedMileage.Text = _Return.ConsumedMileage.ToString();
            lblFinalCheckNotes.Text = _Return.FinalCheckNotes;
            lblAdditionalCharges.Text = _Return.AdditionalCharges.ToString("N");
            lblActualTotalDueAmount.Text = _Return.ActualTotalDueAmount.ToString("N");
        }

        public void Reset()
        {
            _ReturnID = null;
            _Return = null;

            lblReturnID.Text = "[????]";
            lblActualReturnDate.Text = "[????]";
            lblActualRentalDays.Text = "[????]";
            lblMileage.Text = "[????]";
            lblConsumedMileage.Text = "[????]";
            lblFinalCheckNotes.Text = "[????]";
            lblAdditionalCharges.Text = "[????]";
            lblActualTotalDueAmount.Text = "[????]";

            llShowBookingInfo.Enabled = false;
            llShowTransactionInfo.Enabled = false;
        }

        public void LoadReturnInfo(int? ReturnID)
        {
            _ReturnID = ReturnID;

            if (!_ReturnID.HasValue)
            {
                MessageBox.Show("There is no return!", "Missing Data",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Return = clsReturn.Find(_ReturnID.Value);

            if (_Return == null)
            {
                MessageBox.Show("There is no return!", "Missing Data",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillReturnInfo();
        }

        private void llShowBookingInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowBookingDetails ShowBookingDetails = new frmShowBookingDetails(ReturnInfo?.TransactionInfo?.BookingID);
            ShowBookingDetails.ShowDialog();
        }

        private void llShowTransactionInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowTransactionDetails ShowTransactionDetails = new frmShowTransactionDetails(ReturnInfo?.TransactionInfo?.TransactionID);
            ShowTransactionDetails.ShowDialog();
        }
    }
}
