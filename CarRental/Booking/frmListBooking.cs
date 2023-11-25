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

namespace CarRental.Booking
{
    public partial class frmListBooking : Form
    {
        private DataTable _dtAllBooking;

        public frmListBooking()
        {
            InitializeComponent();
        }

        private string _GetRealColumnNameInDB()
        {
            switch (cbFilter.Text)
            {
                case "Booking ID":
                    return "BookingID";

                case "Customer ID":
                    return "CustomerID";

                case "Customer Name":
                    return "CustomerName";

                case "Vehicle ID":
                    return "VehicleID";

                case "Start Date":
                    return "RentalStartDate";

                case "End Date":
                    return "RentalEndDate";

                case "Pickup Location":
                    return "PickupLocation";

                case "Drop Off Location":
                    return "DropoffLocation";

                default:
                    return "None";
            }
        }

        private void _RefreshBookingList()
        {
            _dtAllBooking = clsBooking.GetAllRentalBooking();
            dgvBookingList.DataSource = _dtAllBooking;
            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

            if (dgvBookingList.Rows.Count > 0)
            {
                dgvBookingList.Columns[0].HeaderText = "Booking ID";
                dgvBookingList.Columns[0].Width = 125;

                dgvBookingList.Columns[1].HeaderText = "Customer Name";
                dgvBookingList.Columns[1].Width = 190;

                dgvBookingList.Columns[2].HeaderText = "Customer ID";
                dgvBookingList.Columns[2].Width = 125;

                dgvBookingList.Columns[3].HeaderText = "Vehicle ID";
                dgvBookingList.Columns[3].Width = 125;

                dgvBookingList.Columns[4].HeaderText = "Rental Start Date";
                dgvBookingList.Columns[4].Width = 160;

                dgvBookingList.Columns[5].HeaderText = "Rental End Date";
                dgvBookingList.Columns[5].Width = 160;

                dgvBookingList.Columns[6].HeaderText = "Pickup Location";
                dgvBookingList.Columns[6].Width = 160;

                dgvBookingList.Columns[7].HeaderText = "Dropoff Location";
                dgvBookingList.Columns[7].Width = 160;

                dgvBookingList.Columns[8].HeaderText = "Rental Price/Day";
                dgvBookingList.Columns[8].Width = 180;

                dgvBookingList.Columns[9].HeaderText = "Initial Rental Days";
                dgvBookingList.Columns[9].Width = 180;

                dgvBookingList.Columns[10].HeaderText = "Initial Total Due Amount";
                dgvBookingList.Columns[10].Width = 210;
            }
        }

        private int _GetBookingIDFromDGV()
        {
            return (int)dgvBookingList.CurrentRow.Cells["BookingID"].Value;
        }

        private void frmListBooking_Load(object sender, EventArgs e)
        {
            _RefreshBookingList();

            cbFilter.SelectedIndex = 0;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilter.Text != "None") &&
                                (cbFilter.Text != "Start Date") &&
                                (cbFilter.Text != "End Date");

            string FilterName = cbFilter.Text;

            if (FilterName == "Start Date" || FilterName == "End Date")
            {
                // refresh
                _dtAllBooking.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

                FilterName = _GetRealColumnNameInDB();
                dtpDate.Visible = true;

                if (dgvBookingList.Rows.Count > 0)
                {
                    dtpDate.Value = (DateTime)dgvBookingList.CurrentRow.Cells[FilterName].Value;
                }
                else
                {
                    dtpDate.Value = DateTime.Now;
                }
            }
            else
            {
                dtpDate.Visible = false;
            }

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
                _dtAllBooking.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (_dtAllBooking.Rows.Count == 0)
            {
                return;
            }

            string ColumnName = _GetRealColumnNameInDB();

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()) || cbFilter.Text == "None")
            {
                _dtAllBooking.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();

                return;
            }

            if (cbFilter.Text == "Booking ID" || cbFilter.Text == "Customer ID" || cbFilter.Text == "Vehicle ID")
            {
                // search with numbers
                _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] = {1}", ColumnName, txtSearch.Text.Trim());
            }
            else
            {
                // search with string
                _dtAllBooking.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnName, txtSearch.Text.Trim());
            }

            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Booking ID" || cbFilter.Text == "Customer ID" || cbFilter.Text == "Vehicle ID")
            {
                // make sure that the user can only enter the numbers
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (_dtAllBooking.Rows.Count == 0)
            {
                return;
            }

            if (cbFilter.Text == "Start Date")
            {
                _dtAllBooking.DefaultView.RowFilter =
                        string.Format("[{0}] = #{1}#", "RentalStartDate", dtpDate.Value.ToString("yyyy-MM-dd")); // Including # around a date value is a way to inform the DataView that the value being compared is a date
            }
            else
            {
                _dtAllBooking.DefaultView.RowFilter =
                        string.Format("[{0}] = #{1}#", "RentalEndDate", dtpDate.Value.ToString("yyyy-MM-dd"));
            }


            lblNumberOfRecords.Text = dgvBookingList.Rows.Count.ToString();
        }

        private void ShowBookingDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowBookingDetails ShowBookingDetails = new frmShowBookingDetails(_GetBookingIDFromDGV());
            ShowBookingDetails.ShowDialog();

            _RefreshBookingList();
        }

        private void btnAddNewBooking_Click(object sender, EventArgs e)
        {
            frmAddBooking AddBooking = new frmAddBooking();
            AddBooking.RefreshBookingInfo += _RefreshBookingList;
            AddBooking.Show();
        }

        private void cmsEditProfile_Opening(object sender, CancelEventArgs e)
        {
            ShowBookingDetailsToolStripMenuItem1.Enabled = (dgvBookingList.Rows.Count > 0);
        }

        private void dgvBookingList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvBookingList.Rows.Count == 0)
                return;

            frmShowBookingDetails ShowBookingDetails = new frmShowBookingDetails(_GetBookingIDFromDGV());
            ShowBookingDetails.ShowDialog();

            _RefreshBookingList();
        }
    }
}
