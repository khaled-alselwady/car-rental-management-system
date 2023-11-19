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

namespace CarRental.People.UserControls
{
    public partial class ucPersonCard : UserControl
    {

        private int _PersonID = -1;
        private clsPerson _Person;

        public int PersonID => _PersonID;
        public clsPerson PersonInfo => _Person;

        public ucPersonCard()
        {
            InitializeComponent();
        }

        private void _FillPersonInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            lblFullName.Text = _Person.Name;
            lblDateOfBirth.Text = clsFormat.DateToShort(_Person.DateOfBirth);
            lblGender.Text = _Person.GenderName;
            lblAddress.Text = _Person.Address;
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblCountry.Text = _Person.CountryInfo.CountryName;
            lblCreatedAt.Text = _Person.CreatedAt.ToString("dd/MMM/yyyy hh:mm tt");
            lblUpdatedAt.Text = _Person.UpdatedAt.ToString("dd/MMM/yyyy hh:mm tt");
        }

        public void Reset()
        {
            _PersonID = -1;
            _Person = null;

            lblPersonID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblGender.Text = "[????]";
            lblAddress.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblCountry.Text = "[????]";
            lblCreatedAt.Text = "[????]";
            lblUpdatedAt.Text = "[????]";
        }

        public void LoadPersonInfo(int PersonID)
        {
            _PersonID = PersonID;

            if (PersonID == -1)
            {
                MessageBox.Show("There is no person with id = -1", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show($"There is no person with id = {PersonID}", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillPersonInfo();



        }

    }
}
