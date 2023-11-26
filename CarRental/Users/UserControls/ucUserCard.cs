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

namespace CarRental.Users.UserControls
{
    public partial class ucUserCard : UserControl
    {
        private int? _UserID = null;
        private clsUser _User;

        public int? UserID => _UserID;
        public clsUser User => _User;

        private bool _EditEnabled = false;

        public bool EditEnabled
        {
            get => _EditEnabled;

            set
            {
                _EditEnabled = value;
                llEditUserInfo.Enabled = value;
            }
        }

        public ucUserCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            _UserID = null;
            _User = null;

            ucPersonCard1.Reset();

            lblUserID.Text = "[????]";
            lblUsername.Text = "[????]";
            lblIsActive.Text = "[????]";

            pbIsActive.Image = Resources.Question_32;

            llEditUserInfo.Enabled = false;
        }

        private void _LoadUserImage()
        {
            if (_User.ImagePath != null)
            {
                if (File.Exists(_User.ImagePath))
                    pbUserImage.ImageLocation = _User.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _User.ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_User.Gender == (byte)clsPerson.enGender.Male)
                    pbUserImage.Image = Resources.DefaultMale;
                else
                    pbUserImage.Image = Resources.DefaultFemale;
            }
        }

        private void _FillUserInfo()
        {
            llEditUserInfo.Enabled = true;

            ucPersonCard1.LoadPersonInfo(_User.PersonID);

            lblUserID.Text = _User.UserID?.ToString();
            lblUsername.Text = _User.Username;
            lblIsActive.Text = _User.IsActive ? "Yes" : "No";
            pbIsActive.Image = _User.IsActive ? Resources.active_user : Resources.inactive_user;

            _LoadUserImage();
        }

        public void LoadUserInfo(int? UserID)
        {
            _UserID = UserID;

            if (!_UserID.HasValue)
            {
                MessageBox.Show("There is no user", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _User = clsUser.Find(_UserID);

            if (_User == null)
            {
                MessageBox.Show($"There is no user with id = {UserID}", "Missing User",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillUserInfo();
        }

        private void llEditUserInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditUser EditUser = new frmAddEditUser(_UserID);
            EditUser.GetUserIDByDelegate += LoadUserInfo;
            EditUser.Show();
        }
    }
}
