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

namespace CarRental.Users
{
    public partial class frmChangePassword : Form
    {
        private int _UserID = -1;
        private clsUser _User;

        private bool _EditEnabled = false;

        public frmChangePassword(int UserID, bool EditEnabled = true)
        {
            InitializeComponent();

            _UserID = UserID;

            _EditEnabled = EditEnabled;
        }

        private void _ResetFields()
        {
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();

            txtCurrentPassword.Focus();
        }

        private void _ChangePassword()
        {
            if (_User.ChangePassword(txtNewPassword.Text.Trim()))
            {
                MessageBox.Show("Password Changed Successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                _ResetFields();
            }
            else
            {
                MessageBox.Show("An Error Occurred, Password did not change.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).UseSystemPasswordChar = true;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetFields();

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;

            }

            ucUserCard1.LoadUserInfo(_UserID);

            ucUserCard1.EditEnabled = _EditEnabled;
        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtCurrentPassword, "Username cannot be blank");
                return;
            }
            else
            {
                ErrorProvider1.SetError(txtCurrentPassword, null);
            }

            if (_User.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                ErrorProvider1.SetError(txtCurrentPassword, null);
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
            }
            else
            {
                ErrorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                ErrorProvider1.SetError(txtConfirmPassword,
                    "Password Confirmation does not match New Password!");
            }
            else
            {
                ErrorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ChangePassword();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePassword_Activated(object sender, EventArgs e)
        {
            txtCurrentPassword.Focus();
        }
    }
}
