using CarRental.GlobalClasses;
using CarRental.Properties;
using CarRental_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Users
{
    public partial class frmAddEditUser : Form
    {
        public Action<int?> GetUserIDByDelegate;

        public enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        private int? _UserID = null;
        private clsUser _User;

        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditUser(int? UserID)
        {
            InitializeComponent();

            _UserID = UserID;
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

        private bool _IsAllItemIsChecked()
        {
            foreach (CheckBox item in gbPermissions.Controls)
            {
                if (item.Tag.ToString() != "-1")
                {
                    if (!item.Checked)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool _DoesNotSelectAnyPermission()
        {
            // return true if there is no permissions selected, otherwise false

            foreach (CheckBox item in gbPermissions.Controls)
            {
                if (item.Checked)
                    return false;
            }

            return true;
        }

        private void _ResetFields()
        {
            txtName.Text = "";
            rbMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtSecurityQuestion.Text = "";
            txtSecurityAnswer.Text = "";
        }

        private void _ResetDefaultValues()
        {
            _FillCountryComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User = new clsUser();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";
            }

            //set default image for the customer
            if (rbMale.Checked)
                pbUserImage.Image = Resources.DefaultMale;
            else
                pbUserImage.Image = Resources.DefaultFemale;

            //hide/show the remove link in case there is no image for the customer
            llRemoveImage.Visible = (pbUserImage.ImageLocation != null);

            //should not allow adding age less than 6 years
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to Jordan
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");
        }

        private void _FillCheckBoxPermissions()
        {
            if (_User.Permissions == -1)
            {
                chkAllPermissions.Checked = true;
                return;
            }

            foreach (CheckBox item in gbPermissions.Controls)
            {
                if (item.Tag.ToString() != "-1")
                {
                    if (((Convert.ToInt32(item.Tag)) & _User.Permissions) == (Convert.ToInt32(item.Tag)))
                    {
                        item.Checked = true;
                    }
                }
            }

        }

        private void _FillFieldsWithUserInfo()
        {
            lblUserID.Text = _User.UserID.ToString();
            txtName.Text = _User.Name;
            txtEmail.Text = _User.Email;
            txtAddress.Text = _User.Address;
            txtPhone.Text = _User.Phone;
            dtpDateOfBirth.Value = _User.DateOfBirth;
            txtUsername.Text = _User.Username;
            txtSecurityQuestion.Text = _User.SecurityQuestion;
            txtSecurityAnswer.Text = clsGlobal.Decrypt(_User.SecurityAnswer);
            cbCountry.SelectedIndex = cbCountry.FindString(_User.CountryInfo.CountryName);

            if (_User.Gender == (byte)clsPerson.enGender.Male)
            {
                rbMale.Checked = true;
                pbUserImage.Image = Resources.DefaultMale;
            }

            else
            {
                rbFemale.Checked = true;
                pbUserImage.Image = Resources.DefaultFemale;
            }

            chkIsActive.Checked = _User.IsActive;

            _FillCheckBoxPermissions();
        }

        private void _LoadData()
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            _FillFieldsWithUserInfo();

            //load person image in case it was set.
            if (_User.ImagePath != null)
                pbUserImage.ImageLocation = _User.ImagePath;

            //hide/show the remove link in case there is no image for the person
            llRemoveImage.Visible = (_User.ImagePath != null);

            // in update mode, I show the change password link label to allow the user to change his password
            panelPassword.Visible = false;
            chkIsActive.Location = new System.Drawing.Point(623, 283);
            llChangePassword.Location = new System.Drawing.Point(676, 321);
            llChangePassword.Visible = true;
        }

        private bool _HandleUserImage()
        {
            // this procedure will handle the person image,
            // it will take care of deleting the old image from the folder
            // in case the image changed, and it will rename the new image with guid and 
            // place it in the images folder.

            // _Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_User.ImagePath != pbUserImage.ImageLocation)
            {

                if (_User.ImagePath != null)
                {
                    // first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_User.ImagePath);
                    }
                    catch (IOException iox)
                    {
                        clsLogError.LogError("IO Exception", iox);
                        return false;
                    }
                    catch (Exception ex)
                    {
                        clsLogError.LogError("General Exception", ex);
                        return false;
                    }
                }

                if (pbUserImage.ImageLocation != null)
                {
                    // then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbUserImage.ImageLocation;

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbUserImage.ImageLocation = SourceImageFile;

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private int _CountPermissions()
        {
            int Permissions = 0;

            if (chkAllPermissions.Checked)
                return -1;


            if (chkManageCustomers.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageCustomers;

            if (chkManageUsers.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageUsers;

            if (chkManageVehicles.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageVehicles;

            if (chkManageBooking.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageBooking;

            if (chkManageReturn.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageReturn;

            if (chkManageTransactions.Checked)
                Permissions += (byte)clsUser.enPermissions.ManageTransactions;

            return Permissions;
        }

        private void _FillUserObjectWithFieldsData()
        {
            _User.Name = txtName.Text.Trim();
            _User.Email = txtEmail.Text.Trim();
            _User.Address = txtAddress.Text.Trim();
            _User.Phone = txtPhone.Text.Trim();
            _User.NationalityCountryID = clsCountry.Find(cbCountry.Text).CountryID;            
            _User.Gender = (rbMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;
            _User.DateOfBirth = dtpDateOfBirth.Value;
            _User.Username = txtUsername.Text.Trim();
            _User.IsActive = chkIsActive.Checked;
            _User.Permissions = _CountPermissions();
            _User.SecurityQuestion = txtSecurityQuestion.Text.Trim();
            _User.SecurityAnswer = clsGlobal.Encrypt(txtSecurityAnswer.Text.Trim());

            if (_Mode == enMode.AddNew)
            {
                _User.Password = clsGlobal.ComputeHash(txtPassword.Text.Trim());
            }

            if (pbUserImage.ImageLocation != null)
                _User.ImagePath = pbUserImage.ImageLocation;
            else
                _User.ImagePath = null;
        }

        private void _SaveUser()
        {
            _FillUserObjectWithFieldsData();

            if (_User.Save())
            {
                lblTitle.Text = "Update User";
                lblUserID.Text = _User.UserID.ToString();
                this.Text = "Update User";

                // change form mode to update
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                GetUserIDByDelegate?.Invoke(_User.UserID);
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void chkAllPermissions_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllPermissions.Checked)
            {
                foreach (CheckBox item in gbPermissions.Controls)
                {
                    item.Checked = true;
                }
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
            {
                chkAllPermissions.Checked = false;
                return;
            }

            if (!_IsAllItemIsChecked())
            {
                chkAllPermissions.Checked = false;
            }
            else
            {
                chkAllPermissions.Checked = true;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_DoesNotSelectAnyPermission())
            {
                MessageBox.Show("You have to select permissions for the user!",
                       "Permissions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!_HandleUserImage())
                return;

            _SaveUser();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
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

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }


            if (txtUsername.Text.Trim().ToLower() != _User.Username.ToLower() &&
                clsUser.DoesUserExist(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "username is used by another user");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!panelPassword.Visible)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (!panelPassword.Visible)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }

            if ((!string.IsNullOrWhiteSpace(txtConfirmPassword.Text.Trim())
                && !string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
                && (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword,
                    "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void txtSecurityQuestion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSecurityAnswer.Text.Trim()))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSecurityQuestion.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSecurityQuestion, "You have to write a question for the answer!");
            }
            else
            {
                errorProvider1.SetError(txtSecurityQuestion, null);
            }

        }

        private void txtSecurityAnswer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSecurityQuestion.Text.Trim()))
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSecurityAnswer.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSecurityAnswer, "You have to write an answer for the question!");
            }
            else
            {
                errorProvider1.SetError(txtSecurityAnswer, null);
            }
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
            if (pbUserImage.ImageLocation == null)
                pbUserImage.Image = Resources.DefaultMale;
        }

        private void rbFemale_Click(object sender, EventArgs e)
        {
            if (pbUserImage.ImageLocation == null)
                pbUserImage.Image = Resources.DefaultFemale;
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbUserImage.ImageLocation = null;

            if (rbMale.Checked)
                pbUserImage.Image = Resources.DefaultMale;
            else
                pbUserImage.Image = Resources.DefaultFemale;

            llRemoveImage.Visible = false;
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                string selectedFilePath = openFileDialog1.FileName;
                pbUserImage.Load(selectedFilePath);
                llRemoveImage.Visible = true;
                // ...
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void llChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(_UserID, false);
            ChangePassword.ShowDialog();
        }
    }
}
