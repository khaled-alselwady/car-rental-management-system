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
using static CarRental_Business.clsPerson;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace CarRental.Vehicles
{
    public partial class frmListVehicles : Form
    {
        private DataTable _dtAllVehicles;

        public frmListVehicles()
        {
            InitializeComponent();
        }

        private void _FillMakesComboBox()
        {
            cbMake.Items.Add("All");

            DataTable dtMakes = clsMake.GetAllMakesName();

            foreach (DataRow Make in dtMakes.Rows)
            {
                cbMake.Items.Add(Make["Make"].ToString());
            }
        }

        private void _FillModelsComboBox()
        {
            cbModel.Items.Add("All");

            DataTable dtModels = clsModel.GetAllModelsName();

            foreach (DataRow Model in dtModels.Rows)
            {
                cbModel.Items.Add(Model["ModelName"].ToString());
            }
        }

        private void _FillDriveTypesComboBox()
        {
            cbDriverType.Items.Add("All");

            DataTable dtDriveTypes = clsDriveType.GetAllDriveTypesName();

            foreach (DataRow DriveType in dtDriveTypes.Rows)
            {
                cbDriverType.Items.Add(DriveType["DriveTypeName"].ToString());
            }
        }

        private void _FillFuelTypesComboBox()
        {
            cbFuelType.Items.Add("All");

            DataTable dtFuelTypes = clsFuelType.GetAllFuelTypesName();

            foreach (DataRow FuelType in dtFuelTypes.Rows)
            {
                cbFuelType.Items.Add(FuelType["FuelTypeName"].ToString());
            }
        }

        private void _FillYearComboBox()
        {
            cbYear.Items.Add("All");

            for (short year = 1950; year <= DateTime.Now.Year; year++)
            {
                cbYear.Items.Add(year.ToString());
            }
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Vehicle ID":
                    return "VehicleID";

                case "Vehicle Name":
                    return "VehicleName";

                case "Make":
                    return "Make";

                case "Model":
                    return "ModelName";

                case "Plate Number":
                    return "PlateNumber";

                case "Year":
                    return "Year";

                case "Fuel Type":
                    return "FuelTypeName";

                case "Drive Type":
                    return "DriveTypeName";

                case "Is Available":
                    return "IsAvailableForRent";

                default:
                    return "None";
            }
        }

        private void _RefreshVehiclesList()
        {
            _dtAllVehicles = clsVehicle.GetAllVehicles();
            dgvVehiclesList.DataSource = _dtAllVehicles;
            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

            if (dgvVehiclesList.Rows.Count > 0)
            {
                dgvVehiclesList.Columns[0].HeaderText = "Vehicle ID";
                dgvVehiclesList.Columns[0].Width = 110;

                dgvVehiclesList.Columns[1].HeaderText = "Vehicle Name";
                dgvVehiclesList.Columns[1].Width = 200;

                dgvVehiclesList.Columns[2].HeaderText = "Make";
                dgvVehiclesList.Columns[2].Width = 120;

                dgvVehiclesList.Columns[3].HeaderText = "Model";
                dgvVehiclesList.Columns[3].Width = 120;

                dgvVehiclesList.Columns[4].HeaderText = "Plate Number";
                dgvVehiclesList.Columns[4].Width = 130;

                dgvVehiclesList.Columns[5].HeaderText = "Year";
                dgvVehiclesList.Columns[5].Width = 60;

                dgvVehiclesList.Columns[6].HeaderText = "Fuel Type";
                dgvVehiclesList.Columns[6].Width = 105;

                dgvVehiclesList.Columns[7].HeaderText = "Drive Type";
                dgvVehiclesList.Columns[7].Width = 108;

                dgvVehiclesList.Columns[8].HeaderText = "Mileage";
                dgvVehiclesList.Columns[8].Width = 70;

                dgvVehiclesList.Columns[9].HeaderText = "Rental Price/Day";
                dgvVehiclesList.Columns[9].Width = 160;

                dgvVehiclesList.Columns[10].HeaderText = "Is Available";
                dgvVehiclesList.Columns[10].Width = 110;
            }
        }

        private int _GetVehicleIDFromDGV()
        {
            return (int)dgvVehiclesList.CurrentRow.Cells["VehicleID"].Value;
        }

        private void frmListVehicles_Load(object sender, EventArgs e)
        {
            _RefreshVehiclesList();

            _FillMakesComboBox();
            _FillModelsComboBox();
            _FillDriveTypesComboBox();
            _FillFuelTypesComboBox();
            _FillYearComboBox();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") && (cbFilter.Text != "Make") &&
                                (cbFilter.Text != "Model") && (cbFilter.Text != "Year") &&
                                (cbFilter.Text != "Fuel Type") && (cbFilter.Text != "Drive Type") &&
                                (cbFilter.Text != "Is Available For Rent");

            cbMake.Visible = (cbFilter.Text == "Make");

            cbModel.Visible = (cbFilter.Text == "Model");

            cbYear.Visible = (cbFilter.Text == "Year");

            cbFuelType.Visible = (cbFilter.Text == "Fuel Type");

            cbDriverType.Visible = (cbFilter.Text == "Drive Type");

            cbIsAvailableForRent.Visible = (cbFilter.Text == "Is Available For Rent");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

            if (cbMake.Visible)
            {
                cbMake.SelectedIndex = 0;
            }

            if (cbModel.Visible)
            {
                cbModel.SelectedIndex = 0;
            }

            if (cbYear.Visible)
            {
                cbYear.SelectedIndex = 0;
            }

            if (cbFuelType.Visible)
            {
                cbFuelType.SelectedIndex = 0;
            }

            if (cbDriverType.Visible)
            {
                cbDriverType.SelectedIndex = 0;
            }

            if (cbIsAvailableForRent.Visible)
            {
                cbIsAvailableForRent.SelectedIndex = 0;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Vehicle ID")
            {
                // search with numbers
                _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllVehicles.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Vehicle ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void cbMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbMake.Text == "All")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "Make", cbMake.Text);

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbModel.Text == "All")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "ModelName", cbModel.Text);

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbYear.Text == "All")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "Year", cbYear.Text);

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbFuelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbFuelType.Text == "All")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "FuelTypeName", cbFuelType.Text);

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbDriverType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbDriverType.Text == "All")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] like '{1}%'", "DriveTypeName", cbDriverType.Text);

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void cbIsAvailableForRent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dtAllVehicles.Rows.Count == 0)
            {
                return;
            }

            if (cbIsAvailableForRent.Text == "All")
            {
                _dtAllVehicles.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();

                return;
            }

            _dtAllVehicles.DefaultView.RowFilter =
                string.Format("[{0}] = {1}", "IsAvailableForRent", (cbIsAvailableForRent.Text == "Yes"));

            lblNumberOfRecords.Text = dgvVehiclesList.Rows.Count.ToString();
        }

        private void ShowVehicleDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails(_GetVehicleIDFromDGV());
            ShowVehicleDetails.ShowDialog();

            _RefreshVehiclesList();
        }

        private void EditVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle EditVehicle = new frmAddEditVehicle(_GetVehicleIDFromDGV());
            EditVehicle.RefreshVehicleInfo += _RefreshVehiclesList;
            EditVehicle.Show();
        }

        private void DeleteVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this vehicle?", "Confirm", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsVehicle.DeleteVehicle(_GetVehicleIDFromDGV()))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _RefreshVehiclesList();
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddNewVehicle_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle AddVehicle = new frmAddEditVehicle();
            AddVehicle.RefreshVehicleInfo += _RefreshVehiclesList;
            AddVehicle.Show();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            DeleteVehicleToolStripMenuItem.Enabled = (bool)dgvVehiclesList.CurrentRow.Cells["IsAvailableForRent"].Value;
        }

        private void dgvVehiclesList_DoubleClick(object sender, EventArgs e)
        {
            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails(_GetVehicleIDFromDGV());
            ShowVehicleDetails.ShowDialog();

            _RefreshVehiclesList();
        }

        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            frmVehicleMaintenance Maintenance = new frmVehicleMaintenance();
            Maintenance.Show();
        }

        private void MaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicleMaintenance Maintenance = new frmVehicleMaintenance((int)dgvVehiclesList.CurrentRow.Cells["VehicleID"].Value);
            Maintenance.Show();
        }

        private void ShowMaintenanceHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleMaintenanceHistory ShowVehicleMaintenanceHistory = new frmShowVehicleMaintenanceHistory(_GetVehicleIDFromDGV());
            ShowVehicleMaintenanceHistory.Show();

            _RefreshVehiclesList();
        }
    }
}
