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

namespace CarRental.Customers.UserControls
{
    public partial class ucCustomerCard : UserControl
    {

        private int? _CustomerID = null;
        private clsCustomer _Customer;

        public int? CustomerID => _CustomerID;
        public clsCustomer CustomerInfo => _Customer;

        public ucCustomerCard()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            _CustomerID = null;
            _Customer = null;

            ucPersonCard1.Reset();

            lblCustomerID.Text = "[????]";
            lblDriverLicenseNumber.Text = "[????]";

            llEditCustomerInfo.Enabled = false;
        }

        private void _FillCustomerInfo()
        {
            llEditCustomerInfo.Enabled = true;

            ucPersonCard1.LoadPersonInfo(_Customer.PersonID);

            lblCustomerID.Text = _Customer.CustomerID.ToString();
            lblDriverLicenseNumber.Text = _Customer.DriverLicenseNumber;
        }

        public void LoadCustomerInfo(int? CustomerID)
        {
            _CustomerID = CustomerID;

            if (!_CustomerID.HasValue)
            {
                MessageBox.Show("There is no member", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Customer = clsCustomer.Find(_CustomerID);

            if (_Customer == null)
            {
                MessageBox.Show($"There is no member with id = {CustomerID}", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillCustomerInfo();
        }

        private void llEditCustomerInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditCustomer EditCustomer = new frmAddEditCustomer(_CustomerID);
            EditCustomer.GetCustomerIDByDelegate += LoadCustomerInfo;
            EditCustomer.Show();
        }
    }
}
