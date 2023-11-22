using CarRental.GlobalClasses;
using CarRental.Vehicles.UserControls;
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
using static CarRental.Vehicles.UserControls.ucVehicleCardWithFilter;

namespace CarRental.Vehicles
{
    public partial class frmVehicleMaintenance : Form
    {
        public Action RefreshInfoInDGV;

        private int _MaintenanceID = -1;

        private int _SelectedVehicleID = -1;

        public frmVehicleMaintenance()
        {
            InitializeComponent();

            dtpMaintenanceDate.MinDate = DateTime.Now;
        }

        public frmVehicleMaintenance(int VehicleID)
        {
            InitializeComponent();

            ucVehicleCardWithFilter1.LoadVehicleInfo(VehicleID);
            ucVehicleCardWithFilter1.FilterEnabled = false;

            dtpMaintenanceDate.MinDate = DateTime.Now;
        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCost_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCost.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCost, "Fees cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCost, null);

            };


            if (!clsValidation.IsNumber(txtCost.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCost, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtCost, null);
            };
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDescription, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtDescription, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucVehicleCardWithFilter1_OnVehicleSelected(object sender, VehicleSelectedEventArgs e)
        {
            _SelectedVehicleID = e.VehicleID;

            if (_SelectedVehicleID == -1)
            {
                btnSave.Enabled = false;
                llShowVehicleMaintenanceHistory.Enabled = false;
                lblVehicleID.Text = "[????]";
                return;
            }

            btnSave.Enabled = true;
            llShowVehicleMaintenanceHistory.Enabled = true;

            lblVehicleID.Text = _SelectedVehicleID.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to maintain the vehicle?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            _MaintenanceID = ucVehicleCardWithFilter1.SelectedVehicleInfo.
                Maintenance(txtDescription.Text.Trim(), dtpMaintenanceDate.Value,
                            Convert.ToSingle(txtCost.Text.Trim()));

            if (_MaintenanceID == -1)
            {
                MessageBox.Show("Failed to maintain vehicle", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblMaintenanceID.Text = _MaintenanceID.ToString();
            MessageBox.Show("Vehicle Maintained Successfully with ID = " + _MaintenanceID.ToString(),
                "Vehicle Maintained", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnSave.Enabled = false;
            ucVehicleCardWithFilter1.FilterEnabled = false;
            txtCost.Enabled = false;
            txtDescription.Enabled = false;

            RefreshInfoInDGV?.Invoke();
        }

        private void frmVehicleMaintenance_Activated(object sender, EventArgs e)
        {
            ucVehicleCardWithFilter1.FilterFocus();
        }

        private void llShowVehicleMaintenanceHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowVehicleMaintenanceHistory ShowVehicleMaintenanceHistory = new frmShowVehicleMaintenanceHistory(_SelectedVehicleID);
            ShowVehicleMaintenanceHistory.Show();
        }
    }
}
