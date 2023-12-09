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

namespace CarRental.Login
{
    public partial class frmRestorePasswordUsingSecurityQuestion : Form
    {
        private string _Username;
        private clsUser _User;

        public frmRestorePasswordUsingSecurityQuestion(string username)
        {
            InitializeComponent();

            _Username = username;
        }

        private void _ShowSecurityQuestion()
        {
            _User = clsUser.Find(_Username);

            if (_User == null)
            {
                MessageBox.Show("There is no user with this username!", "Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            if (string.IsNullOrWhiteSpace(_User.SecurityQuestion))
            {
                MessageBox.Show("This user does not have a Security Question!", "Miss Question",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();

                return;
            }

            lblSecurityQuestion.Text = _User.SecurityQuestion;
        }

        private bool _CheckAnswer()
        {
            return (clsGlobal.Decrypt(_User.SecurityAnswer).ToLower() == txtAnswer.Text.Trim().ToLower());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_CheckAnswer())
            {
                MessageBox.Show("Your answer is correct,\nyou can change your password now.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

                frmChangePasswordUsingSecurityQuestion ChangePassword =
                    new frmChangePasswordUsingSecurityQuestion(_Username);

                ChangePassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("Your answer is wrong!",
                    "Wrong Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtAnswer.Focus();
            }
        }

        private void txtAnswer_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAnswer.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAnswer, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtAnswer, null);
            }
        }

        private void frmRestorePasswordUsingSecurityQuestion_Load(object sender, EventArgs e)
        {
            _ShowSecurityQuestion();

            txtAnswer.Focus();
        }
    }
}
