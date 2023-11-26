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
    public partial class ucShowVehicleHistory : UserControl
    {
        private DataTable _dtAllVehicleMaintenanceHistory;

        private int? _VehicleID = null;

        public ucShowVehicleHistory()
        {
            InitializeComponent();
        }

        private void _RefreshMaintenanceHistoryList()
        {
            _dtAllVehicleMaintenanceHistory = clsMaintenance.GetVehicleMaintenanceHistory(_VehicleID);
            dgvVehicleMaintenanceHistoryList.DataSource = _dtAllVehicleMaintenanceHistory;

            lblNumberOfRecords.Text = dgvVehicleMaintenanceHistoryList.Rows.Count.ToString();

            if (dgvVehicleMaintenanceHistoryList.Rows.Count > 0)
            {
                dgvVehicleMaintenanceHistoryList.Columns[0].HeaderText = "Maintenance ID";
                dgvVehicleMaintenanceHistoryList.Columns[0].Width = 150;

                dgvVehicleMaintenanceHistoryList.Columns[1].HeaderText = "Vehicle ID";
                dgvVehicleMaintenanceHistoryList.Columns[1].Width = 110;

                dgvVehicleMaintenanceHistoryList.Columns[2].HeaderText = "Vehicle Name";
                dgvVehicleMaintenanceHistoryList.Columns[2].Width = 200;

                dgvVehicleMaintenanceHistoryList.Columns[3].HeaderText = "Maintenance Date";
                dgvVehicleMaintenanceHistoryList.Columns[3].Width = 170;

                dgvVehicleMaintenanceHistoryList.Columns[4].HeaderText = "Description";
                dgvVehicleMaintenanceHistoryList.Columns[4].Width = 220;

                dgvVehicleMaintenanceHistoryList.Columns[5].HeaderText = "Cost";
                dgvVehicleMaintenanceHistoryList.Columns[5].Width = 80;

                dgvVehicleMaintenanceHistoryList.Columns[6].HeaderText = "Is Available";
                dgvVehicleMaintenanceHistoryList.Columns[6].Width = 110;
            }
        }

        private int _GetMaintenanceIDFromDGV()
        {
            return (int)dgvVehicleMaintenanceHistoryList.CurrentRow.Cells["MaintenanceID"].Value;
        }

        public void LoadVehicleMaintenanceHistoryInfo(int? VehicleID)
        {
            this._VehicleID = VehicleID;
            _RefreshMaintenanceHistoryList();
        }

        public void Clear()
        {
            _dtAllVehicleMaintenanceHistory.Clear();
        }

        private void ShowVehicleDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails((int)dgvVehicleMaintenanceHistoryList.CurrentRow.Cells["VehicleID"].Value);
            ShowVehicleDetails.Show();

            _RefreshMaintenanceHistoryList();
        }

        private void MaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicleMaintenance Maintenance = new frmVehicleMaintenance((int)dgvVehicleMaintenanceHistoryList.CurrentRow.Cells["VehicleID"].Value);
            Maintenance.RefreshInfoInDGV += _RefreshMaintenanceHistoryList;
            Maintenance.Show();
        }

        private void dgvVehicleMaintenanceHistoryList_DoubleClick(object sender, EventArgs e)
        {
            frmShowVehicleDetails ShowVehicleDetails = new frmShowVehicleDetails((int)dgvVehicleMaintenanceHistoryList.CurrentRow.Cells["VehicleID"].Value);
            ShowVehicleDetails.Show();

            _RefreshMaintenanceHistoryList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            cmsEditProfile.Enabled = (dgvVehicleMaintenanceHistoryList.Rows.Count > 0);
        }
    }
}
