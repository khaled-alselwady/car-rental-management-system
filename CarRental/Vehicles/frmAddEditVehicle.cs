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
using System.Xml.Linq;
using TheArtOfDevHtmlRenderer.Adapters;

namespace CarRental.Vehicles
{
    public partial class frmAddEditVehicle : Form
    {
        public Action<int?> GetVehicleIDByDelegate;
        public Action RefreshVehicleInfo;

        public enum enMode { AddNew, Update };
        private enMode _Mode = enMode.AddNew;

        private int? _VehicleID = null;
        private clsVehicle _Vehicle;

        public frmAddEditVehicle()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditVehicle(int? VehicleID)
        {
            InitializeComponent();

            _VehicleID = VehicleID;
            _Mode = enMode.Update;
        }

        private void _FillMakesComboBox()
        {
            DataTable dtMakes = clsMake.GetAllMakesName();

            foreach (DataRow Make in dtMakes.Rows)
            {
                cbMake.Items.Add(Make["Make"].ToString());
            }
        }

        private void _FillModelsComboBox()
        {
            DataTable dtModels = clsModel.GetAllModelsName();

            foreach (DataRow Model in dtModels.Rows)
            {
                cbModel.Items.Add(Model["ModelName"].ToString());
            }
        }

        private void _FillSubModelsComboBox()
        {
            DataTable dtSubModels = clsSubModel.GetAllSubModelsName();

            foreach (DataRow SubModel in dtSubModels.Rows)
            {
                cbSubModel.Items.Add(SubModel["SubModelName"].ToString());
            }
        }

        private void _FillBodiesComboBox()
        {
            DataTable dtBodies = clsBody.GetAllBodiesName();

            foreach (DataRow Body in dtBodies.Rows)
            {
                cbBody.Items.Add(Body["BodyName"].ToString());
            }
        }

        private void _FillDriveTypesComboBox()
        {
            DataTable dtDriveTypes = clsDriveType.GetAllDriveTypesName();

            foreach (DataRow DriveType in dtDriveTypes.Rows)
            {
                cbDriverType.Items.Add(DriveType["DriveTypeName"].ToString());
            }
        }

        private void _FillFuelTypesComboBox()
        {
            DataTable dtFuelTypes = clsFuelType.GetAllFuelTypesName();

            foreach (DataRow FuelType in dtFuelTypes.Rows)
            {
                cbFuelType.Items.Add(FuelType["FuelTypeName"].ToString());
            }
        }

        private void _ResetFields()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Text = "";
                }

                if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = 0;
                }
            }

            numaricNumberDoors.Value = 1;
        }

        private void _ResetDefaultValues()
        {
            _FillMakesComboBox();
            _FillModelsComboBox();
            _FillSubModelsComboBox();
            _FillBodiesComboBox();
            _FillDriveTypesComboBox();
            _FillFuelTypesComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Vehicle";
                this.Text = lblTitle.Text;
                _Vehicle = new clsVehicle();
                _ResetFields();
            }
            else
            {
                lblTitle.Text = "Update Vehicle";
                this.Text = lblTitle.Text;
            }
        }

        private void _FillFieldsWithCustomerInfo()
        {
            lblVehicleID.Text = _Vehicle.VehicleID.ToString();
            txtVehicleName.Text = _Vehicle.VehicleName;
            cbMake.SelectedIndex = cbMake.FindString(_Vehicle.MakeInfo.Make);
            cbModel.SelectedIndex = cbModel.FindString(_Vehicle.ModelInfo.ModelName);
            cbDriverType.SelectedIndex = cbDriverType.FindString(_Vehicle.DriverTypeInfo.DriveTypeName);
            cbSubModel.SelectedIndex = cbSubModel.FindString(_Vehicle.SubModelInfo.SubModelName);
            cbBody.SelectedIndex = cbBody.FindString(_Vehicle.BodyInfo.BodyName);
            txtPlateNumber.Text = _Vehicle.PlateNumber;
            txtMileage.Text = _Vehicle.Mileage.ToString();
            txtRentalPricePerDay.Text = _Vehicle.RentalPricePerDay.ToString();
            cbFuelType.SelectedIndex = cbFuelType.FindString(_Vehicle.FuelTypeInfo.FuelTypeName);
            txtEngine.Text = _Vehicle.Engine;
            numaricNumberDoors.Value = _Vehicle.NumberDoors;
            txtYear.Text = _Vehicle.Year.ToString();
            chkIsAvailable.Checked = _Vehicle.IsAvailableForRent;
            pbIsAvailable.Image = _Vehicle.IsAvailableForRent ? Resources.available_car32 : Resources.unavailable_car32;
        }

        private void _LoadData()
        {
            _Vehicle = clsVehicle.Find(_VehicleID);

            if (_Vehicle == null)
            {
                MessageBox.Show("No vehicle with ID = " + _VehicleID, "Vehicle Not Found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();
                return;
            }

            _FillFieldsWithCustomerInfo();

        }

        private void _FillVehicleObjectWithFieldsData()
        {
            _Vehicle.VehicleName = txtVehicleName.Text.Trim();
            _Vehicle.MakeID = clsMake.Find(cbMake.Text).MakeID ?? -1;
            _Vehicle.ModelID = clsModel.Find(cbModel.Text).ModelID ?? -1;
            _Vehicle.SubModelID = clsSubModel.Find(cbSubModel.Text).SubModelID ?? -1;
            _Vehicle.BodyID = clsBody.Find(cbBody.Text).BodyID ?? -1;
            _Vehicle.DriveTypeID = clsDriveType.Find(cbDriverType.Text).DriveTypeID ?? -1;
            _Vehicle.FuelTypeID = clsFuelType.Find(cbFuelType.Text).FuelTypeID ?? -1;
            _Vehicle.Engine = txtEngine.Text.Trim();
            _Vehicle.RentalPricePerDay = Convert.ToSingle(txtRentalPricePerDay.Text.Trim());
            _Vehicle.NumberDoors = (byte)numaricNumberDoors.Value;
            _Vehicle.PlateNumber = txtPlateNumber.Text.Trim();
            _Vehicle.Mileage = int.Parse(txtMileage.Text.Trim());
            _Vehicle.Year = short.Parse(txtYear.Text.Trim());
            _Vehicle.IsAvailableForRent = chkIsAvailable.Checked;
        }

        private void _SaveCustomer()
        {
            _FillVehicleObjectWithFieldsData();

            if (_Vehicle.Save())
            {
                lblTitle.Text = "Update Vehicle";
                lblVehicleID.Text = _Vehicle.VehicleID.ToString();
                this.Text = lblTitle.Text;

                // change form mode to update
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                GetVehicleIDByDelegate?.Invoke(_Vehicle.VehicleID);
                RefreshVehicleInfo?.Invoke();
            }
            else
            {
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnlyNumberInTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(((TextBox)sender), "This field is required!");
            }
            else
            {
                errorProvider1.SetError(((TextBox)sender), null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _SaveCustomer();
        }

        private void frmAddEditVehicle_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }

        private void txtPlateNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlateNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPlateNumber, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPlateNumber, null);
            }

            //Make sure the plate number is not used by another vehicle
            if (_Vehicle.PlateNumber.ToLower() != txtPlateNumber.Text.ToLower() &&
                clsVehicle.DoesPlateNumberExist(txtPlateNumber.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPlateNumber, "Plate Number is used for another vehicle!");
            }
            else
            {
                errorProvider1.SetError(txtPlateNumber, null);
            }
        }

        private void txtYear_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtYear.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtYear, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtYear, null);
            }

            //Make sure the year is less than current year and greater than 1900
            int Year = int.Parse(txtYear.Text.Trim());
            if (Year > DateTime.Now.Year)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtYear, "the year must be less than or equal the current year!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtYear, null);
            }

            if (Year < 1900)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtYear, "the year must be greater than 1900!");
            }
            else
            {
                errorProvider1.SetError(txtYear, null);
            }
        }

        private void chkIsAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsAvailable.Checked)
            {
                pbIsAvailable.Image = Resources.available_car32;
            }
            else
            {
                pbIsAvailable.Image = Resources.unavailable_car32;
            }
        }
    }
}
