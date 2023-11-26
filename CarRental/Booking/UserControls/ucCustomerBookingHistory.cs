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
    public partial class ucCustomerBookingHistory : UserControl
    {
        private DataTable _dtAllBookingHistory;

        private int? _CustomerID = null;

        public ucCustomerBookingHistory()
        {
            InitializeComponent();
        }

        private void _RefreshBookingHistoryList()
        {
            _dtAllBookingHistory = clsBooking.GetBookingHistoryByCustomerID(_CustomerID);
            dgvBookingHistoryList.DataSource = _dtAllBookingHistory;

            lblNumberOfRecords.Text = dgvBookingHistoryList.Rows.Count.ToString();

            if (dgvBookingHistoryList.Rows.Count > 0)
            {
                dgvBookingHistoryList.Columns[0].HeaderText = "Booking ID";
                dgvBookingHistoryList.Columns[0].Width = 125;

                dgvBookingHistoryList.Columns[1].HeaderText = "Customer Name";
                dgvBookingHistoryList.Columns[1].Width = 190;

                dgvBookingHistoryList.Columns[2].HeaderText = "Customer ID";
                dgvBookingHistoryList.Columns[2].Width = 125;

                dgvBookingHistoryList.Columns[3].HeaderText = "Vehicle ID";
                dgvBookingHistoryList.Columns[3].Width = 125;

                dgvBookingHistoryList.Columns[4].HeaderText = "Rental Start Date";
                dgvBookingHistoryList.Columns[4].Width = 160;

                dgvBookingHistoryList.Columns[5].HeaderText = "Rental End Date";
                dgvBookingHistoryList.Columns[5].Width = 160;

                dgvBookingHistoryList.Columns[6].HeaderText = "Pickup Location";
                dgvBookingHistoryList.Columns[6].Width = 160;

                dgvBookingHistoryList.Columns[7].HeaderText = "Dropoff Location";
                dgvBookingHistoryList.Columns[7].Width = 160;

                dgvBookingHistoryList.Columns[8].HeaderText = "Rental Price/Day";
                dgvBookingHistoryList.Columns[8].Width = 180;

                dgvBookingHistoryList.Columns[9].HeaderText = "Initial Rental Days";
                dgvBookingHistoryList.Columns[9].Width = 180;

                dgvBookingHistoryList.Columns[10].HeaderText = "Initial Total Due Amount";
                dgvBookingHistoryList.Columns[10].Width = 210;
            }
        }

        private int _GetBookingIDFromDGV()
        {
            return (int)dgvBookingHistoryList.CurrentRow.Cells["BookingID"].Value;
        }

        public void LoadCustomerBookingHistoryInfo(int CustomerID)
        {
            this._CustomerID = CustomerID;
            _RefreshBookingHistoryList();
        }

        public void Clear()
        {
            _dtAllBookingHistory.Clear();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingDetails ShowBookingDetails = new frmShowBookingDetails(_GetBookingIDFromDGV());
            ShowBookingDetails.ShowDialog();

            _RefreshBookingHistoryList();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            ShowBookingDetailsToolStripMenuItem1.Enabled = (dgvBookingHistoryList.Rows.Count > 0);
        }

        private void dgvBookingHistoryList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBookingHistoryList.Rows.Count == 0)
                return;

            frmShowBookingDetails ShowBookingDetails = new frmShowBookingDetails(_GetBookingIDFromDGV());
            ShowBookingDetails.ShowDialog();

            _RefreshBookingHistoryList();
        }
    }
}
