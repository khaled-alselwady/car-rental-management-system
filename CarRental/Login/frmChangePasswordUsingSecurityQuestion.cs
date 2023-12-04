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

namespace CarRental.Login
{
    public partial class frmChangePasswordUsingSecurityQuestion : Form
    {
        private string _Username;

        public frmChangePasswordUsingSecurityQuestion(string Username)
        {
            InitializeComponent();

            _Username = Username;
        }

        private void _ChangePassword()
        {
            clsUser User = clsUser.Find(_Username);

            if (User == null)
            {
                MessageBox.Show("There is no user with this username!", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            if (User.ChangePassword(txtNewPassword.Text.Trim()))
            {
                MessageBox.Show("Password Changed Successfully,\nyou can log in now.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnConfirm_Click(object sender, EventArgs e)
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
    }
}
