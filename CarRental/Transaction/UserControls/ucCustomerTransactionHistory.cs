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
    public partial class ucCustomerTransactionHistory : UserControl
    {
        private DataTable _dtAllTransactionHistory;

        private int? _CustomerID = null;

        public ucCustomerTransactionHistory()
        {
            InitializeComponent();
        }

        private void _RefreshTransactionHistoryList()
        {
            _dtAllTransactionHistory = clsTransaction.GetAllRentalTransactionByCustomerID(_CustomerID);
            dgvTransactionHistoryList.DataSource = _dtAllTransactionHistory;

            lblNumberOfRecords.Text = dgvTransactionHistoryList.Rows.Count.ToString();

            if (dgvTransactionHistoryList.Rows.Count > 0)
            {
                dgvTransactionHistoryList.Columns[0].HeaderText = "Transaction ID";
                dgvTransactionHistoryList.Columns[0].Width = 140;

                dgvTransactionHistoryList.Columns[1].HeaderText = "Customer Name";
                dgvTransactionHistoryList.Columns[1].Width = 190;

                dgvTransactionHistoryList.Columns[2].HeaderText = "Customer ID";
                dgvTransactionHistoryList.Columns[2].Width = 125;

                dgvTransactionHistoryList.Columns[3].HeaderText = "Booking ID";
                dgvTransactionHistoryList.Columns[3].Width = 125;

                dgvTransactionHistoryList.Columns[4].HeaderText = "Return ID";
                dgvTransactionHistoryList.Columns[4].Width = 125;

                dgvTransactionHistoryList.Columns[5].HeaderText = "Actual Total Due Amount";
                dgvTransactionHistoryList.Columns[5].Width = 220;

                dgvTransactionHistoryList.Columns[6].HeaderText = "Total Remaining";
                dgvTransactionHistoryList.Columns[6].Width = 160;

                dgvTransactionHistoryList.Columns[7].HeaderText = "Total Refunded Amount";
                dgvTransactionHistoryList.Columns[7].Width = 210;

                dgvTransactionHistoryList.Columns[8].HeaderText = "Transaction Type";
                dgvTransactionHistoryList.Columns[8].Width = 180;

                dgvTransactionHistoryList.Columns[9].HeaderText = "Transaction Date";
                dgvTransactionHistoryList.Columns[9].Width = 180;

                dgvTransactionHistoryList.Columns[10].HeaderText = "Updated Transaction Date";
                dgvTransactionHistoryList.Columns[10].Width = 230;
            }
        }

        private int _GetTransactionIDFromDGV()
        {
            return (int)dgvTransactionHistoryList.CurrentRow.Cells["TransactionID"].Value;
        }

        public void LoadCustomerTransactionHistoryInfo(int? CustomerID)
        {
            this._CustomerID = CustomerID;
            _RefreshTransactionHistoryList();
        }

        public void Clear()
        {
            _dtAllTransactionHistory.Clear();
        }

        private void ShowTransactionDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowTransactionDetailsWithBookingAndReturn ShowTransactionDetailsWithBookingAndReturn =
                 new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionIDFromDGV());

            ShowTransactionDetailsWithBookingAndReturn.ShowDialog();

            _RefreshTransactionHistoryList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvTransactionHistoryList.Rows.Count > 0);
        }

        private void dgvTransactionHistoryList_DoubleClick(object sender, EventArgs e)
        {
            frmShowTransactionDetailsWithBookingAndReturn ShowTransactionDetailsWithBookingAndReturn =
                 new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionIDFromDGV());

            ShowTransactionDetailsWithBookingAndReturn.ShowDialog();

            _RefreshTransactionHistoryList();
        }
    }
}
