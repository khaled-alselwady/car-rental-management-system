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

namespace CarRental.Customers.UserControls
{
    public partial class ucCustomerCardWithFilter : UserControl
    {
        public ucCustomerCardWithFilter()
        {
            InitializeComponent();
        }

        #region Declare Event
        public class CustomerSelectedEventArgs : EventArgs
        {
            public int? CustomerID { get; }

            public CustomerSelectedEventArgs(int? customerID)
            {
                this.CustomerID = customerID;
            }
        }

        public event EventHandler<CustomerSelectedEventArgs> OnCustomerSelected;

        public void RaiseOnCustomerSelected(int? CustomerID)
        {
            RaiseOnCustomerSelected(new CustomerSelectedEventArgs(CustomerID));
        }

        protected virtual void RaiseOnCustomerSelected(CustomerSelectedEventArgs e)
        {
            OnCustomerSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowAddCustomerButton = true;
        public bool ShowAddMemberButton
        {
            get => _ShowAddCustomerButton;

            set
            {
                _ShowAddCustomerButton = value;
                btnAddNew.Visible = _ShowAddCustomerButton;
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

        public int? CustomerID => ucCustomerCard1.CustomerID;
        public clsCustomer SelectedCustomerInfo => ucCustomerCard1.CustomerInfo;

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

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we don't continue because the form is not valid
                MessageBox.Show("Some fields are not valid!, put the mouse over the red icon(s) to see the Error",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            LoadCustomerInfo(int.Parse(txtFilterValue.Text.Trim()));
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

        private void ucCustomerCardWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }

        public void LoadCustomerInfo(int? CustomerID)
        {
            txtFilterValue.Text = CustomerID.ToString();
            ucCustomerCard1.LoadCustomerInfo(CustomerID);
           
            if (OnCustomerSelected != null)
            {
                // Raise the event with a parameter
                RaiseOnCustomerSelected(ucCustomerCard1.CustomerID);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer AddNewCustomer = new frmAddEditCustomer();
            AddNewCustomer.GetCustomerIDByDelegate += LoadCustomerInfo;
            AddNewCustomer.Show();
        }

        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }

        public void Clear()
        {
            ucCustomerCard1.Reset();
        }
    }
}
