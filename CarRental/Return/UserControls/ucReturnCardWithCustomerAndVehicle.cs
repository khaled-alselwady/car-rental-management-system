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

namespace CarRental.Return.UserControls
{
    public partial class ucReturnCardWithCustomerAndVehicle : UserControl
    {
        public int? ReturnID => ucReturnCard1.ReturnID;
        public clsReturn ReturnInfo => ucReturnCard1.ReturnInfo;

        public int? CustomerID => ucSelectedCustomerAndVehicleCard1.CustomerID;
        public clsCustomer CustomerInfo => ucSelectedCustomerAndVehicleCard1.SelectedCustomerInfo;

        public int? VehicleID => ucSelectedCustomerAndVehicleCard1.VehicleID;
        public clsVehicle VehicleInfo => ucSelectedCustomerAndVehicleCard1.SelectedVehicleInfo;

        public ucReturnCardWithCustomerAndVehicle()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            ucSelectedCustomerAndVehicleCard1.Clear();
            ucReturnCard1.Reset();
        }

        public void LoadReturnWithCustomerAndVehicleInfo(int? ReturnID)
        {
            ucReturnCard1.LoadReturnInfo(ReturnID);

            int? CustomerID = ReturnInfo.TransactionInfo?.CustomerID ?? null;
            int? VehicleID = ReturnInfo.TransactionInfo?.VehicleID ?? null;
            ucSelectedCustomerAndVehicleCard1.LoadCustomerVehicleInfo(CustomerID, VehicleID);                    
        }
    }
}
