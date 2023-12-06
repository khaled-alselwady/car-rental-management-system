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

namespace CarRental.Vehicles.UserControls
{
    public partial class ucVehicleCard : UserControl
    {
        private int? _VehicleID = null;
        private clsVehicle _Vehicle;

        public int? VehicleID => _VehicleID;
        public clsVehicle VehicleInfo => _Vehicle;

        public ucVehicleCard()
        {
            InitializeComponent();
        }

        private void _FillVehicleInfo()
        {
            llEditVehicleInfo.Enabled = true;
            _VehicleID = _Vehicle.VehicleID;
            lblVehicleID.Text = _Vehicle.VehicleID.ToString();
            lblVehicleName.Text = _Vehicle.VehicleName;
            lblMake.Text = _Vehicle.MakeInfo.Make;
            lblModel.Text = _Vehicle.ModelInfo.ModelName;
            lblDriverType.Text = _Vehicle.DriverTypeInfo.DriveTypeName;
            lblSubModelName.Text = _Vehicle.SubModelInfo.SubModelName;
            lblBody.Text = _Vehicle.BodyInfo.BodyName;
            lblPlateNumber.Text = _Vehicle.PlateNumber;
            lblMileage.Text = _Vehicle.Mileage.ToString();
            lblRentalPricePerDay.Text = _Vehicle.RentalPricePerDay.ToString();
            lblFuelType.Text = _Vehicle.FuelTypeInfo.FuelTypeName;
            lblEngine.Text = _Vehicle.Engine;
            lblNumberDoors.Text = _Vehicle.NumberDoors.ToString();
            lblYear.Text = _Vehicle.Year.ToString();
            lblIsAvailable.Text = _Vehicle.IsAvailableForRent ? "Yes" : "No";
            pbIsAvailable.Image = _Vehicle.IsAvailableForRent ? Resources.available_car32 : Resources.unavailable_car32;
        }

        public void Reset()
        {
            _VehicleID = null;
            _Vehicle = null;

            llEditVehicleInfo.Enabled = false;

            lblVehicleID.Text = "[????]";
            lblVehicleName.Text = "[????]";
            lblMake.Text = "[????]";
            lblModel.Text = "[????]";
            lblDriverType.Text = "[????]";
            lblSubModelName.Text = "[????]";
            lblBody.Text = "[????]";
            lblPlateNumber.Text = "[????]";
            lblMileage.Text = "[????]";
            lblRentalPricePerDay.Text = "[????]";
            lblFuelType.Text = "[????]";
            lblEngine.Text = "[????]";
            lblNumberDoors.Text = "[????]";
            lblYear.Text = "[????]";
            lblIsAvailable.Text = "[????]";

            pbIsAvailable.Image = Resources.Question_32;
        }

        public void LoadVehicleInfo(int? VehicleID)
        {
            _VehicleID = VehicleID;

            if (!VehicleID.HasValue)
            {
                MessageBox.Show("There is no vehicle", "Missing Vehicle",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _Vehicle = clsVehicle.Find(_VehicleID);

            if (_Vehicle == null)
            {
                MessageBox.Show($"There is no vehicle with id = {VehicleID}", "Missing Vehicle",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Reset();

                return;
            }

            _FillVehicleInfo();
        }

        private void llEditVehicleInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditVehicle EditVehicle = new frmAddEditVehicle(_VehicleID);
            EditVehicle.GetVehicleIDByDelegate += LoadVehicleInfo;
            EditVehicle.ShowDialog();
        }
    }
}
