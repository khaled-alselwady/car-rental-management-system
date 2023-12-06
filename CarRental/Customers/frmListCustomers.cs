using CarRental.Booking;
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

namespace CarRental.Customers
{
    public partial class frmListCustomers : Form
    {
        private DataTable _dtAllCustomers;

        public frmListCustomers()
        {
            InitializeComponent();
        }

        private void _FillCountryComboBox()
        {
            cbCountry.Items.Add("All");

            DataTable dtCountries = clsCountry.GetAllCountriesName();

            foreach (DataRow Country in dtCountries.Rows)
            {
                cbCountry.Items.Add(Country["CountryName"].ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Customer ID":
                    return "CustomerID";

                case "Name":
                    return "Name";

                case "License Number":
                    return "DriverLicenseNumber";

                case "Gender":
                    return "Gender";

                case "Phone":
                    return "Phone";

                case "Email":
                    return "Email";

                case "Country":
                    return "Country";

                default:
                    return "None";
            }
        }

        private void _RefreshCustomersList()
        {
            _dtAllCustomers = clsCustomer.GetAllCustomers();
            dgvCustomersList.DataSource = _dtAllCustomers;
            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

            if (dgvCustomersList.Rows.Count > 0)
            {
                dgvCustomersList.Columns[0].HeaderText = "Customer ID";
                dgvCustomersList.Columns[0].Width = 125;

                dgvCustomersList.Columns[1].HeaderText = "Name";
                dgvCustomersList.Columns[1].Width = 190;

                dgvCustomersList.Columns[2].HeaderText = "Gender";
                dgvCustomersList.Columns[2].Width = 100;

                dgvCustomersList.Columns[3].HeaderText = "Country";
                dgvCustomersList.Columns[3].Width = 100;

                dgvCustomersList.Columns[4].HeaderText = "Phone";
                dgvCustomersList.Columns[4].Width = 110;

                dgvCustomersList.Columns[5].HeaderText = "Date Of Birth";
                dgvCustomersList.Columns[5].Width = 130;

                dgvCustomersList.Columns[6].HeaderText = "Email";
                dgvCustomersList.Columns[6].Width = 160;

                dgvCustomersList.Columns[7].HeaderText = "License Number";
                dgvCustomersList.Columns[7].Width = 160;

                dgvCustomersList.Columns[8].HeaderText = "Date Created";
                dgvCustomersList.Columns[8].Width = 180;
            }
        }

        private int _GetCustomerIDFromDGV()
        {
            return (int)dgvCustomersList.CurrentRow.Cells["CustomerID"].Value;
        }

        private void frmListCustomers_Load(object sender, EventArgs e)
        {
            _RefreshCustomersList();
            _FillCountryComboBox();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Gender") && (cbFilter.Text != "Country");

            cbCountry.Visible = (cbFilter.Text == "Country");

            cbGender.Visible = (cbFilter.Text == "Gender");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbCountry.Visible)
            {
                cbCountry.SelectedIndex = 0;
            }

            if (cbGender.Visible)
            {
                cbGender.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllCustomers.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllCustomers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Customer ID")
            {
                // search with numbers
                _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllCustomers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Customer ID" || cbFilter.Text == "Phone")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllCustomers.Rows.Count == 0)
            {
                return;
            }

            if (cbGender.Text == "All")
            {
                _dtAllCustomers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

                return;
            }

            _dtAllCustomers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);

            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllCustomers.Rows.Count == 0)
            {
                return;
            }

            if (cbCountry.Text == "All")
            {
                _dtAllCustomers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();

                return;
            }

            _dtAllCustomers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Country", cbCountry.Text);

            lblNumberOfRecords.Text = dgvCustomersList.Rows.Count.ToString();
        }

        private void ShowCustomerDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowCustomerDetails ShowCustomerDetails =
                new frmShowCustomerDetails(_GetCustomerIDFromDGV());

            ShowCustomerDetails.ShowDialog();

            _RefreshCustomersList();
        }

        private void EditCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer EditCustomer = new frmAddEditCustomer(_GetCustomerIDFromDGV());
            EditCustomer.RefreshCustomerInfo += _RefreshCustomersList;
            EditCustomer.ShowDialog();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer AddCustomer = new frmAddEditCustomer();
            AddCustomer.RefreshCustomerInfo += _RefreshCustomersList;
            AddCustomer.ShowDialog();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsCustomer.DeleteCustomer(_GetCustomerIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshCustomersList();
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvCustomersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowCustomerDetails ShowCustomerDetails =
                new frmShowCustomerDetails(_GetCustomerIDFromDGV());

            ShowCustomerDetails.ShowDialog();

            _RefreshCustomersList();
        }

        private void ShowCustomerBookingHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerBookingHistory ShowCustomerBookingHistory =
                new frmShowCustomerBookingHistory(_GetCustomerIDFromDGV());

            ShowCustomerBookingHistory.ShowDialog();

            _RefreshCustomersList();
        }

        private void ShowCustomerTransactionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerTransactionHistory ShowCustomerTransactionHistory =
                new frmShowCustomerTransactionHistory(_GetCustomerIDFromDGV());

            ShowCustomerTransactionHistory.ShowDialog();

            _RefreshCustomersList();
        }
    }
}
