using CarRental.Customers.UserControls;
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
    public partial class ucBookingCardWithFilter : UserControl
    {
        public ucBookingCardWithFilter()
        {
            InitializeComponent();
        }

        #region Declare Event
        public class BookingSelectedEventArgs : EventArgs
        {
            public int? BookingID { get; }

            public BookingSelectedEventArgs(int? BookingID)
            {
                this.BookingID = BookingID;
            }
        }

        public event EventHandler<BookingSelectedEventArgs> OnBookingSelected;

        public void RaiseOnBookingSelected(int? BookingID)
        {
            RaiseOnBookingSelected(new BookingSelectedEventArgs(BookingID));
        }

        protected virtual void RaiseOnBookingSelected(BookingSelectedEventArgs e)
        {
            OnBookingSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowAddBookingButton = true;
        public bool ShowAddBookingButton
        {
            get => _ShowAddBookingButton;

            set
            {
                _ShowAddBookingButton = value;
                btnAddNew.Visible = _ShowAddBookingButton;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get => _FilterEnabled;

            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        public int? BookingID => ucBookingCard1.BookingID;
        public clsBooking SelectedBookingInfo => ucBookingCard1.BookingInfo;

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the Error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            LoadBookingInfo(int.Parse(txtFilterValue.Text.Trim()));
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }

        private void ucBookingCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }

        public void LoadBookingInfo(int? BookingID)
        {
            txtFilterValue.Text = BookingID.ToString();
            ucBookingCard1.LoadBookingInfo(BookingID);

            if (OnBookingSelected != null)
            {
                // Raise the event with a parameter
                RaiseOnBookingSelected(ucBookingCard1.BookingID);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddBooking AddNewBooking = new frmAddBooking();
            AddNewBooking.GetBookingIDByDelegate += LoadBookingInfo;
            AddNewBooking.Show();
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        public void Clear()
        {
            ucBookingCard1.Reset();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            // to make sure that the user can enter only numbers
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
