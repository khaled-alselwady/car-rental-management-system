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
using static CarRental.Customers.UserControls.ucCustomerCardWithFilter;
using static CarRental.Vehicles.UserControls.ucVehicleCardWithFilter;

namespace CarRental.Booking.UserControls
{
    public partial class ucSelectedCustomerAndVehicleWithFilter : UserControl
    {
        public Action<int> SendCustomerID;
        public Action<int> SendVehicleID;

        private int _SelectedCustomerID = -1;
        private int _SelectedVehicleID = -1;

        public int CustomerID => ucCustomerCardWithFilter1.CustomerID;
        public int VehicleID => ucVehicleCardWithFilter1.VehicleID;

        public clsCustomer SelectedCustomerInfo => ucCustomerCardWithFilter1.SelectedCustomerInfo;
        public clsVehicle SelectedVehicleInfo => ucVehicleCardWithFilter1.SelectedVehicleInfo;

        private bool _FilterEnable = false;
        public bool FilterEnable
        {
            get => _FilterEnable;

            set
            {
                _FilterEnable = value;
                ucCustomerCardWithFilter1.FilterEnabled = value;
                ucVehicleCardWithFilter1.FilterEnabled = value;
            }
        }

        public ucSelectedCustomerAndVehicleWithFilter()
        {
            InitializeComponent();
        }

        private bool _IsMemberCorrect()
        {
            if (_SelectedCustomerID == -1)
            {
                tcSelectCustomerVehicle.SelectedTab = tpSelectCustomer;

                MessageBox.Show("You have to select a customer first!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        public void FilterFocus()
        {
            ucCustomerCardWithFilter1.FilterFocus();
        }

        public void LoadCustomerInfo(int CustomerID)
        {
            ucCustomerCardWithFilter1.LoadCustomerInfo(CustomerID);
            ucCustomerCardWithFilter1.FilterEnabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_IsMemberCorrect())
            {
                tcSelectCustomerVehicle.SelectedTab = tpSelectVehicle;
                ucVehicleCardWithFilter1.FilterFocus();
            }
        }

        private void tcSelectCustomerVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage SelectedTabPage = tcSelectCustomerVehicle.SelectedTab;

            if (SelectedTabPage == tpSelectVehicle)
            {
                tcSelectCustomerVehicle.SelectedTab = tpSelectCustomer;

                if (_IsMemberCorrect())
                {
                    ucVehicleCardWithFilter1.FilterFocus();
                    tcSelectCustomerVehicle.SelectedTab = tpSelectVehicle;
                }

            }
        }

        private void ucCustomerCardWithFilter1_OnCustomerSelected(object sender, CustomerSelectedEventArgs e)
        {
            _SelectedCustomerID = e.CustomerID;

            if (_SelectedCustomerID == -1)
            {
                btnNext.Enabled = false;

                SendCustomerID?.Invoke(-1);
                return;
            }

            btnNext.Enabled = true;

            SendCustomerID?.Invoke(ucCustomerCardWithFilter1.CustomerID);
        }

        private void ucVehicleCardWithFilter1_OnVehicleSelected(object sender, VehicleSelectedEventArgs e)
        {
            _SelectedVehicleID = e.VehicleID;

            if (_SelectedVehicleID == -1)
            {
                SendVehicleID?.Invoke(-1); // to disable btnBook in the frmAddBooking
                return;
            }

            if (!ucVehicleCardWithFilter1.SelectedVehicleInfo.IsAvailableForRent)
            {
                MessageBox.Show("This car in NOT available for rent now!", "Not Allowed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            SendVehicleID?.Invoke(ucVehicleCardWithFilter1.VehicleID);
        }
    }
}
