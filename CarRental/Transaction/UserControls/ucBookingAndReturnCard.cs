using CarRental_Business;
using System.Windows.Forms;

namespace CarRental.Transaction.UserControls
{
    public partial class ucBookingAndReturnCard : UserControl
    {
        public int? BookingID => ucBookingCard1.BookingID;
        public int? ReturnID => ucReturnCard1.ReturnID;

        public clsBooking BookingInfo => ucBookingCard1.BookingInfo;
        public clsReturn ReturnInfo => ucReturnCard1.ReturnInfo;

        public ucBookingAndReturnCard()
        {
            InitializeComponent();
        }

        public void LoadBookingAndReturnInfo(int? BookingID, int? ReturnID)
        {
            ucBookingCard1.LoadBookingInfo(BookingID);
            ucReturnCard1.LoadReturnInfo(ReturnID);
        }

        public void Clear()
        {
            ucBookingCard1.Reset();
            ucReturnCard1.Reset();
        }

    }
}
