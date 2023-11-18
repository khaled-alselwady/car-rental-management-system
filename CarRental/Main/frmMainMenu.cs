using CarRental.Dashboard;
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

        public frmMainMenu()
        {
            InitializeComponent();
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
            OpenChildForm(new Form(), sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form(), sender);
        }

        private void btnVehicles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form(), sender);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form(), sender);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form(), sender);
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form(), sender);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form(), sender);
        }

        private void btnSubMenu_Click(object sender, EventArgs e)
        {
            // this method will show the context menu by clicking on the left click instead of the right click

            // Get the location of the button on the screen
            Point location = btnSubMenu.PointToScreen(new Point(0, btnSubMenu.Height));

            // Show the context menu at the calculated location
            cmsEditProfile.Show(location);
        }
    }
}
