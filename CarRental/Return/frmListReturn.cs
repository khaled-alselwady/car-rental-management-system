using CarRental.Booking;
using CarRental.Customers;
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

namespace CarRental.Return
{
    public partial class frmListReturn : Form
    {
        private DataTable _dtAllReturn;

        public frmListReturn()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Return ID":
                    return "ReturenID";

                case "Customer ID":
                    return "CustomerID";

                case "Vehicle ID":
                    return "VehicleID";

                case "Booking ID":
                    return "BookingID";

                case "Transaction ID":
                    return "TransactionID";

                case "Customer Name":
                    return "Name";

                case "Actual Return Date":
                    return "ActualReturnDate";

                default:
                    return "None";
            }
        }

        private void _RefreshReturnList()
        {
            _dtAllReturn = clsReturn.GetAllVehicleReturns();
            dgvReturnList.DataSource = _dtAllReturn;
            lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();

            if (dgvReturnList.Rows.Count > 0)
            {
                dgvReturnList.Columns[0].HeaderText = "Return ID";
                dgvReturnList.Columns[0].Width = 115;

                dgvReturnList.Columns[1].HeaderText = "Customer Name";
                dgvReturnList.Columns[1].Width = 190;

                dgvReturnList.Columns[2].HeaderText = "Customer ID";
                dgvReturnList.Columns[2].Width = 130;

                dgvReturnList.Columns[3].HeaderText = "Vehicle ID";
                dgvReturnList.Columns[3].Width = 125;

                dgvReturnList.Columns[4].HeaderText = "Booking ID";
                dgvReturnList.Columns[4].Width = 125;

                dgvReturnList.Columns[5].HeaderText = "Transaction ID";
                dgvReturnList.Columns[5].Width = 140;

                dgvReturnList.Columns[6].HeaderText = "Actual Return Date";
                dgvReturnList.Columns[6].Width = 180;

                dgvReturnList.Columns[7].HeaderText = "Actual Rental Days";
                dgvReturnList.Columns[7].Width = 180;

                dgvReturnList.Columns[8].HeaderText = "Additional Charges";
                dgvReturnList.Columns[8].Width = 180;

                dgvReturnList.Columns[9].HeaderText = "Actual Total Due Amount";
                dgvReturnList.Columns[9].Width = 220;
            }
        }

        private int _GetReturnIDFromDGV()
        {
            return (int)dgvReturnList.CurrentRow.Cells["ReturenID"].Value;
        }

        private void frmListReturn_Load(object sender, EventArgs e)
        {
            _RefreshReturnList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") &&
                                (cbFilter.Text != "Actual Return Date");

            dtpActualReturnDate.Visible = (cbFilter.Text == "Actual Return Date");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                _dtAllReturn.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllReturn.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllReturn.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text != "Actual Return Date" &&
                cbFilter.Text != "Customer Name")
            {
                // search with numbers
                _dtAllReturn.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllReturn.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text != "Actual Return Date" &&
                cbFilter.Text != "Customer Name")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllReturn.Rows.Count == 0)
            {
                return;
            }

            _dtAllReturn.DefaultView.RowFilter =
                    string.Format("[{0}] = #{1}#", "ActualReturnDate",
                    dtpActualReturnDate.Value.ToString("yyyy-MM-dd")); // Including # around a date value is a way to inform the DataView that the value being compared is a date

            lblNumberOfRecords.Text = dgvReturnList.Rows.Count.ToString();
        }

        private void btnAddNewReturn_Click(object sender, EventArgs e)
        {
            frmReturnVehicle ReturnVehicle = new frmReturnVehicle();
            ReturnVehicle.RefreshReturnInfo += _RefreshReturnList;
            ReturnVehicle.Show();
        }

        private void ShowReturnDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle(_GetReturnIDFromDGV());
            ShowReturnDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingDetailsWithCustomerAndVehicle ShowBookingDetails = new frmShowBookingDetailsWithCustomerAndVehicle((int)dgvReturnList.CurrentRow.Cells["BookingID"].Value);
            ShowBookingDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void ShowCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerDetails ShowCustomerDetails = new frmShowCustomerDetails((int)dgvReturnList.CurrentRow.Cells["CustomerID"].Value);
            ShowCustomerDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void ShowVehicleDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails((int)dgvReturnList.CurrentRow.Cells["VehicleID"].Value);
            ShowVehicleDetails.ShowDialog();

            _RefreshReturnList();
        }

        private void dgvReturnList_DoubleClick(object sender, EventArgs e)
        {
            frmShowReturnDetailsWithCustomerAndVehicle ShowReturnDetails = new frmShowReturnDetailsWithCustomerAndVehicle(_GetReturnIDFromDGV());
            ShowReturnDetails.ShowDialog();

            _RefreshReturnList();
        }
    }
}
