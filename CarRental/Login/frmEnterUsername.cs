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
    public partial class frmEnterUsername : Form
    {
        public frmEnterUsername()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!clsUser.DoesUserExist(txtUsername.Text.Trim()))
            {
                MessageBox.Show("There is no user with this username!", "Not Found",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtUsername.Focus();

                return;
            }

            this.Close();

            frmRestorePasswordUsingSecurityQuestion RestorePassword = 
                new frmRestorePasswordUsingSecurityQuestion(txtUsername.Text.Trim());

            RestorePassword.ShowDialog();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUsername, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtUsername, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
