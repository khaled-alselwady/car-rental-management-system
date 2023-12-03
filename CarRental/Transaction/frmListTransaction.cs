using CarRental.Booking;
using CarRental.Customers;
using CarRental.Return;
using CarRental.Vehicles;
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

namespace CarRental.Transaction
{
    public partial class frmListTransaction : Form
    {
        private DataTable _dtAllTransaction;

        public frmListTransaction()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Transaction ID":
                    return "TransactionID";

                case "Booking ID":
                    return "BookingID";

                case "Customer ID":
                    return "CustomerID";

                case "Customer Name":
                    return "Name";

                case "Return ID":
                    return "ReturnID";

                case "Transaction Type":
                    return "TransactionType";

                case "Transaction Date":
                    return "TransactionDate";

                case "Updated Transaction Date":
                    return "UpdatedTransactionDate";

                default:
                    return "None";
            }
        }

        private void _RefreshTransactionList()
        {
            _dtAllTransaction = clsTransaction.GetAllRentalTransaction();
            dgvTransactionList.DataSource = _dtAllTransaction;
            lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();

            if (dgvTransactionList.Rows.Count > 0)
            {
                dgvTransactionList.Columns[0].HeaderText = "Transaction ID";
                dgvTransactionList.Columns[0].Width = 140;

                dgvTransactionList.Columns[1].HeaderText = "Customer Name";
                dgvTransactionList.Columns[1].Width = 190;

                dgvTransactionList.Columns[2].HeaderText = "Customer ID";
                dgvTransactionList.Columns[2].Width = 125;

                dgvTransactionList.Columns[3].HeaderText = "Booking ID";
                dgvTransactionList.Columns[3].Width = 125;

                dgvTransactionList.Columns[4].HeaderText = "Return ID";
                dgvTransactionList.Columns[4].Width = 125;

                dgvTransactionList.Columns[5].HeaderText = "Actual Total Due Amount";
                dgvTransactionList.Columns[5].Width = 220;

                dgvTransactionList.Columns[6].HeaderText = "Total Remaining";
                dgvTransactionList.Columns[6].Width = 160;

                dgvTransactionList.Columns[7].HeaderText = "Total Refunded Amount";
                dgvTransactionList.Columns[7].Width = 210;

                dgvTransactionList.Columns[8].HeaderText = "Transaction Type";
                dgvTransactionList.Columns[8].Width = 180;

                dgvTransactionList.Columns[9].HeaderText = "Transaction Date";
                dgvTransactionList.Columns[9].Width = 180;

                dgvTransactionList.Columns[10].HeaderText = "Updated Transaction Date";
                dgvTransactionList.Columns[10].Width = 230;
            }
        }

        private int _GetTransactionFromDGV()
        {
            return (int)dgvTransactionList.CurrentRow.Cells["TransactionID"].Value;
        }

        private void frmListTransaction_Load(object sender, EventArgs e)
        {
            _RefreshTransactionList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") &&
                               (cbFilter.Text != "Transaction Date") &&
                               (cbFilter.Text != "Updated Transaction Date") &&
                               (cbFilter.Text != "Transaction Type");

            cbTransactionType.Visible = (cbFilter.Text == "Transaction Type");

            if (cbTransactionType.Visible)
            {
                cbTransactionType.SelectedIndex = 0;
            }

            string FilterName = cbFilter.Text;

            if (FilterName == "Transaction Date" || FilterName == "Updated Transaction Date")
            {
                // refresh
                _dtAllTransaction.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();

                FilterName = _GetRealColumnNameInDB();
                dtpDate.Visible = true;

                if (dgvTransactionList.Rows.Count > 0)
                {
                    dtpDate.Value = (DateTime)dgvTransactionList.CurrentRow.Cells[FilterName].Value;
                }
                else
                {
                    dtpDate.Value = DateTime.Now;
                }
            }
            else
            {
                dtpDate.Visible = false;
            }

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                _dtAllTransaction.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllTransaction.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllTransaction.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text != "Customer Name" &&
                cbFilter.Text != "Transaction Date" &&
                cbFilter.Text != "Updated Transaction Date")
            {
                // search with numbers
                _dtAllTransaction.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllTransaction.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text != "Customer Name" &&
                cbFilter.Text != "Transaction Date" &&
                cbFilter.Text != "Updated Transaction Date")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllTransaction.Rows.Count == 0)
            {
                return;
            }

            if (cbFilter.Text == "Transaction Date")
            {
                _dtAllTransaction.DefaultView.RowFilter =
                        string.Format("[{0}] = #{1}#", "TransactionDate", dtpDate.Value.ToString("yyyy-MM-dd")); // Including # around a date value is a way to inform the DataView that the value being compared is a date
            }
            else
            {
                _dtAllTransaction.DefaultView.RowFilter =
                        string.Format("[{0}] = #{1}#", "UpdatedTransactionDate", dtpDate.Value.ToString("yyyy-MM-dd"));
            }


            lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();
        }

        private void ShowTransactionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowTransactionDetailsWithBookingAndReturn ShowTransactionDetails = new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionFromDGV());
            ShowTransactionDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void ShowCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerDetails ShowCustomerDetails = new frmShowCustomerDetails((int)dgvTransactionList.CurrentRow.Cells["CustomerID"].Value);
            ShowCustomerDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void ShowVehicleDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsTransaction Transaction = clsTransaction.FindByTransactionID(_GetTransactionFromDGV());

            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails(Transaction?.VehicleID);
            ShowVehicleDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle((int)dgvTransactionList.CurrentRow.Cells["BookingID"].Value);
            ShowBookingDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void ShowReturnDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle((int)dgvTransactionList.CurrentRow.Cells["ReturnID"].Value);
            ShowReturnDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void dgvTransactionList_DoubleClick(object sender, EventArgs e)
        {
            frmShowTransactionDetailsWithBookingAndReturn ShowTransactionDetails = new frmShowTransactionDetailsWithBookingAndReturn(_GetTransactionFromDGV());
            ShowTransactionDetails.ShowDialog();

            _RefreshTransactionList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            if (dgvTransactionList.Rows.Count == 0)
            {
                return;
            }

            ShowReturnDetailsToolStripMenuItem.Enabled = (dgvTransactionList.CurrentRow.Cells["ReturnID"].Value != DBNull.Value);

            #region Manage Total Remaining
            if (dgvTransactionList.CurrentRow.Cells["TotalRemaining"].Value == DBNull.Value)
            {
                TakeOrPayRefundToolStripMenuItem.Enabled = false;
                return;
            }

            float? TotalRemaining = Convert.ToSingle(dgvTransactionList.CurrentRow.Cells["TotalRemaining"].Value);

            if (!TotalRemaining.HasValue)
            {
                TakeOrPayRefundToolStripMenuItem.Enabled = false;
                return;
            }

            if (TotalRemaining == 0)
            {
                TakeOrPayRefundToolStripMenuItem.Enabled = false;
                return;
            }

            TakeOrPayRefundToolStripMenuItem.Enabled = true;

            if (TotalRemaining > 0)
            {
                TakeOrPayRefundToolStripMenuItem.Text = "   Issue Refund";
            }
            else
            {
                TakeOrPayRefundToolStripMenuItem.Text = "   Receive Payment";
            }
            #endregion
        }

        private void cbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllTransaction.Rows.Count == 0)
            {
                return;
            }

            if (cbTransactionType.Text == "All")
            {
                _dtAllTransaction.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();

                return;
            }

            _dtAllTransaction.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "TransactionType", cbTransactionType.Text);

            lblNumberOfRecords.Text = dgvTransactionList.Rows.Count.ToString();
        }

        private void TakeOrPayRefundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            float? TotalRemaining = Convert.ToSingle(dgvTransactionList.CurrentRow.Cells["TotalRemaining"].Value);

            if (clsTransaction.UpdateTotalRefundedAmount(_GetTransactionFromDGV(), TotalRemaining))
            {
                MessageBox.Show("Transaction Done Successfully!", "Confirm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _RefreshTransactionList();
            }
            else
            {
                MessageBox.Show("Transaction Failed!", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
