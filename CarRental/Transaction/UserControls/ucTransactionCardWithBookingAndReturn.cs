using CarRental.Booking.UserControls;
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

namespace CarRental.Transaction.UserControls
{
    public partial class ucTransactionCardWithBookingAndReturn : UserControl
    {
        public int? TransactionID => ucTransactionCard1.TransactionID;
        public clsTransaction TransactionInfo => ucTransactionCard1.TransactionInfo;
        
        public int? BookingID => ucBookingAndReturnCard1.BookingID;
        public clsBooking BookingInfo => ucBookingAndReturnCard1.BookingInfo;

        public int? ReturnID => ucBookingAndReturnCard1.ReturnID;
        public clsReturn ReturnInfo => ucBookingAndReturnCard1.ReturnInfo;

        public ucTransactionCardWithBookingAndReturn()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            ucBookingAndReturnCard1.Clear();
            ucTransactionCard1.Reset();
        }

        public void LoadTransactionWithBookingAndReturnInfo(int? TransactionID)
        {
            ucTransactionCard1.LoadTransactionInfo(TransactionID);

            ucBookingAndReturnCard1.LoadBookingAndReturnInfo(TransactionInfo?.BookingID, TransactionInfo?.ReturnID);
        }

    }
}
