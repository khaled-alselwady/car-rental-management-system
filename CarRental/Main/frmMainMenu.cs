using CarRental.Booking;
using CarRental.Customers;
using CarRental.Dashboard;
using CarRental.GlobalClasses;
using CarRental.Properties;
using CarRental.Return;
using CarRental.Users;
using CarRental.Vehicles;
using CarRental_Business;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Main
{
    public partial class frmMainMenu : Form
    {
        private IconButton _CurrentButton;

        private Form _ActiveForm;

        private Form _frmLoginForm;

        public frmMainMenu(Form frmLoginForm)
        {
            InitializeComponent();

            this._frmLoginForm = frmLoginForm;
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_CurrentButton != (IconButton)btnSender)
                {
                    DisableMenuButton();
                    //Color color = SelectThemeColor();
                    _CurrentButton = (IconButton)btnSender;
                    _CurrentButton.BackColor = Color.WhiteSmoke;
                    _CurrentButton.IconColor = Color.FromArgb(60, 60, 60);
                    _CurrentButton.ForeColor = Color.FromArgb(60, 60, 60);
                    _CurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void DisableMenuButton()
        {
            IconButton iconbutton = new IconButton();

            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(IconButton))
                {
                    iconbutton = (IconButton)previousBtn;

                    previousBtn.BackColor = Color.FromArgb(0, 122, 204);
                    previousBtn.ForeColor = Color.Gainsboro;
                    iconbutton.IconColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (_ActiveForm != null)
                _ActiveForm.Close();

            ActivateButton(btnSender);
            _ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            if (childForm.Tag != null)
            {
                lblTitle.Text = childForm.Tag.ToString();
            }
            else
            {
                lblTitle.Text = childForm.Text;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard(), sender);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListCustomers(), sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListUsers(), sender);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListVehicles(), sender);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListBooking(), sender);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmListReturn(), sender);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form(), sender);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginForm.Show();
            this.Close();
        }

        private void btnSubMenu_Click(object sender, EventArgs e)
        {
            // this method will show the context menu by clicking on the left click instead of the right click

            // Get the location of the button on the screen
            Point location = btnSubMenu.PointToScreen(new Point(0, btnSubMenu.Height));

            // Show the context menu at the calculated location
            cmsEditProfile.Show(location);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowUserDetails ShowUserDetails = new frmShowUserDetails(clsGlobal.CurrentUser.UserID, false);
            ShowUserDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangePassword = new frmChangePassword(clsGlobal.CurrentUser.UserID, false);
            ChangePassword.ShowDialog();
        }

        private void frmMainMenu_Load(object sender, EventArgs e)
        {
            _CurrentButton = btnDashboard;

            _CurrentButton.BackColor = Color.WhiteSmoke;
            _CurrentButton.IconColor = Color.FromArgb(60, 60, 60);
            _CurrentButton.ForeColor = Color.FromArgb(60, 60, 60);
            _CurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            OpenChildForm(new frmDashboard(), _CurrentButton);

            if (clsGlobal.CurrentUser.ImagePath != "")
            {
                pbUserImage.ImageLocation = clsGlobal.CurrentUser.ImagePath;
            }
            else
            {
                if (clsGlobal.CurrentUser.Gender == clsPerson.enGender.Male)
                    pbUserImage.Image = Resources.DefaultMale;
                else
                    pbUserImage.Image = Resources.DefaultFemale;
            }

            lblUsername.Text = clsGlobal.CurrentUser.Username;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginForm.Show();
            this.Close();
        }
    }
}
