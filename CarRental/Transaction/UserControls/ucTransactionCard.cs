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

namespace CarRental.Transaction.UserControls
{
    public partial class ucTransactionCard : UserControl
    {
        private int? _TransactionID = null;
        private clsTransaction _Transaction;

        public int? TransactionID => _TransactionID;
        public clsTransaction TransactionInfo => _Transaction;

        public ucTransactionCard()
        {
            InitializeComponent();
        }

        private void _FillTransactionInfo()
        {
            lblTransactionID.Text = _Transaction.TransactionID?.ToString();
            lblBookingID.Text = _Transaction.BookingID?.ToString();
            lblReturnID.Text = _Transaction.ReturnID?.ToString() ?? "Not returned yet";
            lblPaymentDetails.Text = _Transaction.PaymentDetails;
            lblTransactionDate.Text = clsFormat.DateToShort(_Transaction.TransactionDate);
            lblInitialTotalDueAmount.Text = _Transaction.InitialTotalDueAmount?.ToString("N") ?? "N/A";
            lblActualTotalDueAmount.Text = _Transaction.ActualTotalDueAmount?.ToString("N") ?? "N/A";
            lblTotalRemaining.Text = _Transaction.TotalRemaining?.ToString("N") ?? "N/A";
            lblTotalRefundedAmount.Text = _Transaction.TotalRefundedAmount?.ToString("N") ?? "N/A";
            lblUpdatedTransactionDate.Text = (_Transaction.UpdatedTransactionDate.HasValue) ? clsFormat.DateToShort((DateTime)_Transaction.UpdatedTransactionDate) : "N/A";
            lblTransactionType.Text = _Transaction.TransactionTypeName;
        }

        public void Reset()
        {
            _Transaction = null;
            _TransactionID = null;

            lblTransactionID.Text = "[????]";
            lblBookingID.Text = "[????]";
            lblReturnID.Text = "[????]";
            lblPaymentDetails.Text = "[????]";
            lblTransactionDate.Text = "[????]";
            lblInitialTotalDueAmount.Text = "[????]";
            lblActualTotalDueAmount.Text = "[????]";
            lblTotalRemaining.Text = "[????]";
            lblTotalRefundedAmount.Text = "[????]";
            lblUpdatedTransactionDate.Text = "[????]";
            lblTransactionType.Text = "[????]";
        }

        public void LoadTransactionInfo(int? TransactionID)
        {
            _TransactionID = TransactionID;

            if (!_TransactionID.HasValue)
            {
                MessageBox.Show("There is no Transaction", "Missing Transaction",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _Transaction = clsTransaction.FindByTransactionID(_TransactionID);

            if (_Transaction == null)
            {
                MessageBox.Show($"There is no Transaction with ID = {TransactionID}", "Missing Transaction",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                _TransactionID = null;

                return;
            }

            _FillTransactionInfo();
        }
    }
}
