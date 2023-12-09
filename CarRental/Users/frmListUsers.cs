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
using System.Windows.Controls;
using System.Windows.Forms;

namespace CarRental.Users
{
    public partial class frmListUsers : Form
    {
        private DataTable _dtAllUsers;

        public frmListUsers()
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
                case "User ID":
                    return "UserID";

                case "Name":
                    return "Name";

                case "Username":
                    return "Username";

                case "Gender":
                    return "Gender";

                case "Country":
                    return "Country";

                case "Is Active":
                    return "IsActive";

                default:
                    return "None";
            }
        }

        private void _RefreshUsersList()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dtAllUsers;
            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 125;

                dgvUsersList.Columns[1].HeaderText = "Name";
                dgvUsersList.Columns[1].Width = 190;

                dgvUsersList.Columns[2].HeaderText = "Gender";
                dgvUsersList.Columns[2].Width = 100;

                dgvUsersList.Columns[3].HeaderText = "Date Of Birth";
                dgvUsersList.Columns[3].Width = 130;

                dgvUsersList.Columns[4].HeaderText = "Username";
                dgvUsersList.Columns[4].Width = 150;

                dgvUsersList.Columns[5].HeaderText = "Country";
                dgvUsersList.Columns[5].Width = 100;

                dgvUsersList.Columns[6].HeaderText = "Date Created";
                dgvUsersList.Columns[6].Width = 180;

                dgvUsersList.Columns[7].HeaderText = "Is Active";
                dgvUsersList.Columns[7].Width = 120;
            }
        }

        private int _GetUserIDFromDGV()
        {
            return (int)dgvUsersList.CurrentRow.Cells["UserID"].Value;
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersList();
            _FillCountryComboBox();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Gender") && (cbFilter.Text != "Country") && (cbFilter.Text != "Is Active");

            cbCountry.Visible = (cbFilter.Text == "Country");

            cbGender.Visible = (cbFilter.Text == "Gender");

            cbIsActive.Visible = (cbFilter.Text == "Is Active");

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

            if (cbIsActive.Visible)
            {
                cbIsActive.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "User ID")
            {
                // search with numbers
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "User ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            if (cbGender.Text == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtAllUsers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Gender", cbGender.Text);

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void cbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            if (cbCountry.Text == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtAllUsers.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Country", cbCountry.Text);

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllUsers.Rows.Count == 0)
            {
                return;
            }

            if (cbIsActive.Text == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();

                return;
            }

            _dtAllUsers.DefaultView.RowFilter = 
                string.Format("[{0}] = {1}", "IsActive", (cbIsActive.Text == "Yes"));

            lblNumberOfRecords.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void ShowUserDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(_GetUserIDFromDGV());
            ShowUserDetails.ShowDialog();

            _RefreshUsersList();
        }

        private void EditUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser(_GetUserIDFromDGV());
            EditUser.ShowDialog();

            _RefreshUsersList();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsUser.DeleteUser(_GetUserIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshUsersList();
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(_GetUserIDFromDGV());
            ChangePassword.ShowDialog();

            _RefreshUsersList();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser();
            EditUser.ShowDialog();

            _RefreshUsersList();
        }

        private void dgvUsersList_DoubleClick(object sender, EventArgs e)
        {
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(_GetUserIDFromDGV());
            ShowUserDetails.ShowDialog();

            _RefreshUsersList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            DeleteToolStripMenuItem.Enabled = ((int)dgvUsersList.CurrentRow.Cells["UserID"].Value != clsGlobal.CurrentUser.UserID);
        }
    }
}
