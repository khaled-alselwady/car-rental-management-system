using CarRental.Booking;
using CarRental.Customers;
using CarRental.Dashboard;
using CarRental.GlobalClasses;
using CarRental.Permissions;
using CarRental.Properties;
using CarRental.Return;
using CarRental.Transaction;
using CarRental.Users;
using CarRental.Vehicles;
using CarRental_Business;
using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Main
{
    public partial class frmMainMenu : Form
    {
        private Guna2Button _CurrentButton;

        private Form _ActiveForm;

        private Form _frmLoginForm;

        public Form frmDeniedMassage = new frmAccessDeniedMessage();

        public frmMainMenu(Form frmLoginForm)
        {
            InitializeComponent();

            this._frmLoginForm = frmLoginForm;
        }

        private void _ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (_CurrentButton != (Guna2Button)btnSender)
                {
                    _DisableMenuButton();
                    //Color color = SelectThemeColor();
                    _CurrentButton = (Guna2Button)btnSender;
                    _CurrentButton.BackColor = Color.WhiteSmoke;
                    //_CurrentButton.IconColor = Color.FromArgb(60, 60, 60);
                    _CurrentButton.ForeColor = Color.FromArgb(60, 60, 60);
                    _CurrentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void _DisableMenuButton()
        {
            Guna2Button iconbutton = new Guna2Button();

            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Guna2Button))
                {
                    iconbutton = (Guna2Button)previousBtn;

                    previousBtn.BackColor = Color.FromArgb(0, 122, 204);
                    previousBtn.ForeColor = Color.Gainsboro;
                    //iconbutton.IconColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Tahoma", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private async void _OpenChildForm(Form childForm, object btnSender)
        {
            await Task.Delay(100);

            if (_ActiveForm != null)
                _ActiveForm.Close();

            _ActivateButton(btnSender);
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

        private void _HandleUserImage()
        {
            if (clsGlobal.CurrentUser.ImagePath != null)
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
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            _OpenChildForm(new frmDashboard(), sender);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageCustomers))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            _OpenChildForm(new frmListCustomers(), sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageUsers))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            _OpenChildForm(new frmListUsers(), sender);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageVehicles))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            _OpenChildForm(new frmListVehicles(), sender);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageBooking))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            _OpenChildForm(new frmListBooking(), sender);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageReturn))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            _OpenChildForm(new frmListReturn(), sender);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccessDenied(clsUser.enPermissions.ManageTransactions))
            {
                frmDeniedMassage.ShowDialog();
                return;
            }

            _OpenChildForm(new frmListTransaction(), sender);
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
            btnDashboard.PerformClick();

            _HandleUserImage();

            lblUsername.Text = clsGlobal.CurrentUser.Username;
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLoginForm.Show();
            this.Close();
        }

        private void MoveImageSlide(object sender)
        {
            Guna2Button Button1 = (Guna2Button)sender;

            pbImgaeSlide.Location = new Point(Button1.Location.X + 130, Button1.Location.Y - 30);
            pbImgaeSlide.SendToBack();
        }

        private void btnLogOut_CheckedChanged(object sender, EventArgs e)
        {
            MoveImageSlide(sender);
        }
    }
}
