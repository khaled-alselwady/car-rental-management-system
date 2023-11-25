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

namespace CarRental.Booking.UserControls
{
    public partial class ucSelectedCustomerAndVehicleCard : UserControl
    {
        public int CustomerID => ucCustomerCard1.CustomerID;
        public int VehicleID => ucVehicleCard1.VehicleID;

        public clsCustomer SelectedCustomerInfo => ucCustomerCard1.CustomerInfo;
        public clsVehicle SelectedVehicleInfo => ucVehicleCard1.VehicleInfo;

        public ucSelectedCustomerAndVehicleCard()
        {
            InitializeComponent();
        }

        public void LoadCustomerVehicleInfo(int CustomerID, int VehicleID)
        {
            ucCustomerCard1.LoadCustomerInfo(CustomerID);
            ucVehicleCard1.LoadVehicleInfo(VehicleID);
        }

        public void Clear()
        {
            ucCustomerCard1.Reset();
            ucVehicleCard1.Reset();
        }
    }
}
