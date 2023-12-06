using CarRental.GlobalClasses;
using CarRental.Properties;
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
    public partial class frmAddEditCustomer : Form
    {
        public Action<int?> GetCustomerIDByDelegate;

        public enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        private int? _CustomerID = null;
        private clsCustomer _Customer;

        public frmAddEditCustomer()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditCustomer(int? CustomerID)
        {
            InitializeComponent();

            _CustomerID = CustomerID;
            _Mode = enMode.Update;
        }

        private void _FillCountryComboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountriesName();

            foreach (DataRow Country in dtCountries.Rows)
            {
                cbCountry.Items.Add(Country["CountryName"].ToString());
            }
        }

        private void _ResetFields()
        {
            txtName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtLicenseNo.Text = "";
            cbCountry.SelectedIndex = 0;
        }

        private void _ResetDefaultValues()
        {
            _FillCountryComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Customer";
                this.Text = "Add New Customer";
                _Customer = new clsCustomer();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Customer";
                this.Text = "Update Customer";
            }

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-16);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to Jordan
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");
        }

        private void _FillFieldsWithCustomerInfo()
        {
            lblCustomerID.Text = _Customer.CustomerID.ToString();
            txtName.Text = _Customer.Name;
            txtEmail.Text = _Customer.Email;
            txtAddress.Text = _Customer.Address;
            txtPhone.Text = _Customer.Phone;
            dtpDateOfBirth.Value = _Customer.DateOfBirth;
            txtLicenseNo.Text = _Customer.DriverLicenseNumber;
            rbMale.Checked = (_Customer.Gender == clsPerson.enGender.Male);

            // To show the name of the Belt rank
            cbCountry.SelectedIndex = cbCountry.FindString(_Customer.CountryInfo.CountryName);
        }

        private void _LoadData()
        {
            _Customer = clsCustomer.Find(_CustomerID);

            if (_Customer == null)
            {
                MessageBox.Show("No customer with ID = " + _CustomerID, "Customer Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            _FillFieldsWithCustomerInfo();

        }

        private void _FillCustomerObjectWithFieldsData()
        {
            _Customer.Name = txtName.Text.Trim();
            _Customer.Email = txtEmail.Text.Trim();
            _Customer.Address = txtAddress.Text.Trim();
            _Customer.Phone = txtPhone.Text.Trim();
            _Customer.DriverLicenseNumber = txtLicenseNo.Text.Trim();
            _Customer.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _Customer.DateOfBirth = dtpDateOfBirth.Value;
            _Customer.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID ?? -1;
        }

        private void _SaveCustomer()
        {
            _FillCustomerObjectWithFieldsData();

            if (_Customer.Save())
            {
                lblTitle.Text = "Update Customer";
                lblCustomerID.Text = _Customer.CustomerID.ToString();
                this.Text = "Update Customer";

                // change form mode to update
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                GetCustomerIDByDelegate?.Invoke(_Customer.CustomerID);
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
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

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }

            //validate email format
            if (!clsValidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SaveCustomer();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLicenseNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLicenseNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtLicenseNo, null);
            }

            //Make sure the license number is not used by another customer
            if (_Customer.DriverLicenseNumber.ToLower() != txtLicenseNo.Text.Trim().ToLower() &&
                clsCustomer.DoesDriverLicenseNumberExist(txtLicenseNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtLicenseNo, "License Number is used for another customer!");
            }
            else
            {
                errorProvider1.SetError(txtLicenseNo, null);
            }

        }
    }
}
