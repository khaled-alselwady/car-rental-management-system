using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsTransaction : clsBooking
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? TransactionID { get; set; }
        public int? ReturnID { get; set; }
        public string PaymentDetails { get; set; }
        public float PaidInitialTotalDueAmount { get; set; }
        public float? ActualTotalDueAmount { get; set; }
        public float? TotalRemaining { get; set; }
        public float? TotalRefundedAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime? UpdatedTransactionDate { get; set; }

        public clsReturn ReturnInfo { get; set; }

        public clsTransaction()
        {
            this.TransactionID = null;
            this.ReturnID = null;
            this.PaymentDetails = string.Empty;
            this.PaidInitialTotalDueAmount = -1f;
            this.ActualTotalDueAmount = null;
            this.TotalRemaining = null;
            this.TotalRefundedAmount = null;
            this.TransactionDate = DateTime.Now;
            this.UpdatedTransactionDate = null;

            Mode = enMode.AddNew;
        }

        private clsTransaction(int? BookingID, int? CustomerID, int? VehicleID, DateTime RentalStartDate,
            DateTime RentalEndDate, int? InitialRentalDays, string PickupLocation,
            string DropoffLocation, float RentalPricePerDay, float? InitialTotalDueAmount,
            string InitialCheckNotes, int? TransactionID, int? ReturnID, string PaymentDetails,
            float PaidInitialTotalDueAmount, float? ActualTotalDueAmount,
            float? TotalRemaining, float? TotalRefundedAmount, DateTime TransactionDate,
            DateTime? UpdatedTransactionDate)
        {
            base.BookingID = BookingID;
            base.CustomerID = CustomerID;
            base.VehicleID = VehicleID;
            base.RentalStartDate = RentalStartDate;
            base.RentalEndDate = RentalEndDate;
            base.InitialRentalDays = InitialRentalDays;
            base.PickupLocation = PickupLocation;
            base.DropoffLocation = DropoffLocation;
            base.RentalPricePerDay = RentalPricePerDay;
            base.InitialTotalDueAmount = InitialTotalDueAmount;
            base.InitialCheckNotes = InitialCheckNotes;

            this.TransactionID = TransactionID;
            this.ReturnID = ReturnID;
            this.PaymentDetails = PaymentDetails;
            this.PaidInitialTotalDueAmount = PaidInitialTotalDueAmount;
            this.ActualTotalDueAmount = ActualTotalDueAmount;
            this.TotalRemaining = TotalRemaining;
            this.TotalRefundedAmount = TotalRefundedAmount;
            this.TransactionDate = TransactionDate;
            this.UpdatedTransactionDate = UpdatedTransactionDate;

            this.ReturnInfo = clsReturn.Find(ReturnID);

            Mode = enMode.Update;
        }

        private bool _AddNewTransaction()
        {
            this.TransactionID = clsTransactionData.AddNewTransaction(this.BookingID,
                this.PaymentDetails, this.PaidInitialTotalDueAmount);

            return (this.TransactionID.HasValue);
        }

        private bool _UpdateTransaction()
        {
            return clsTransactionData.UpdateTransaction(this.TransactionID,
                this.ReturnID, this.ActualTotalDueAmount, this.TotalRefundedAmount);
        }

        public bool Save()
        {
            base.Mode = (clsBooking.enMode)Mode;

            if (!base.Save())
            {
                return false;
            }

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransaction())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTransaction();
            }

            return false;
        }

        public static clsTransaction FindByTransactionID(int? TransactionID)
        {
            int? BookingID = null;
            int? ReturnID = null;
            string PaymentDetails = string.Empty;
            float PaidInitialTotalDueAmount = -1f;
            float? ActualTotalDueAmount = null;
            float? TotalRemaining = null;
            float? TotalRefundedAmount = null;
            DateTime TransactionDate = DateTime.Now;
            DateTime? UpdatedTransactionDate = null;

            bool IsFound = clsTransactionData.GetTransactionInfoByTransactionID(TransactionID, ref BookingID,
                ref ReturnID, ref PaymentDetails, ref PaidInitialTotalDueAmount,
                ref ActualTotalDueAmount, ref TotalRemaining, ref TotalRefundedAmount,
                ref TransactionDate, ref UpdatedTransactionDate);

            if (IsFound)
            {
                clsBooking Booking = clsBooking.Find(BookingID);

                if (Booking == null)
                {
                    return null;
                }

                return new clsTransaction(Booking.BookingID, Booking.CustomerID,
                    Booking.VehicleID, Booking.RentalStartDate, Booking.RentalEndDate,
                    Booking.InitialRentalDays, Booking.PickupLocation,
                    Booking.DropoffLocation, Booking.RentalPricePerDay,
                    Booking.InitialTotalDueAmount, Booking.InitialCheckNotes,
                    TransactionID, ReturnID, PaymentDetails, PaidInitialTotalDueAmount,
                     ActualTotalDueAmount, TotalRemaining, TotalRefundedAmount,
                     TransactionDate, UpdatedTransactionDate);
            }
            else
            {
                return null;
            }
        }

        public static clsTransaction FindByReturnID(int? ReturnID)
        {
            int? TransactionID = null;
            int? BookingID = null;
            string PaymentDetails = string.Empty;
            float PaidInitialTotalDueAmount = -1f;
            float? ActualTotalDueAmount = null;
            float? TotalRemaining = null;
            float? TotalRefundedAmount = null;
            DateTime TransactionDate = DateTime.Now;
            DateTime? UpdatedTransactionDate = null;

            bool IsFound = clsTransactionData.GetTransactionInfoByReturnID(ReturnID, ref TransactionID,
                ref BookingID, ref PaymentDetails, ref PaidInitialTotalDueAmount,
                ref ActualTotalDueAmount, ref TotalRemaining, ref TotalRefundedAmount,
                ref TransactionDate, ref UpdatedTransactionDate);

            if (IsFound)
            {
                clsBooking Booking = clsBooking.Find(BookingID);

                if (Booking == null)
                {
                    return null;
                }

                return new clsTransaction(Booking.BookingID, Booking.CustomerID,
                    Booking.VehicleID, Booking.RentalStartDate, Booking.RentalEndDate,
                    Booking.InitialRentalDays, Booking.PickupLocation,
                    Booking.DropoffLocation, Booking.RentalPricePerDay,
                    Booking.InitialTotalDueAmount, Booking.InitialCheckNotes,
                    TransactionID, ReturnID, PaymentDetails, PaidInitialTotalDueAmount,
                     ActualTotalDueAmount, TotalRemaining, TotalRefundedAmount,
                     TransactionDate, UpdatedTransactionDate);
            }
            else
            {
                return null;
            }
        }

        public static clsTransaction FindByBookingID(int? BookingID)
        {
            int? TransactionID = null;
            int? ReturnID = null;
            string PaymentDetails = string.Empty;
            float PaidInitialTotalDueAmount = -1f;
            float? ActualTotalDueAmount = null;
            float? TotalRemaining = null;
            float? TotalRefundedAmount = null;
            DateTime TransactionDate = DateTime.Now;
            DateTime? UpdatedTransactionDate = null;

            bool IsFound = clsTransactionData.GetTransactionInfoByBookingID(BookingID, ref TransactionID,
                ref ReturnID, ref PaymentDetails, ref PaidInitialTotalDueAmount,
                ref ActualTotalDueAmount, ref TotalRemaining, ref TotalRefundedAmount,
                ref TransactionDate, ref UpdatedTransactionDate);

            if (IsFound)
            {
                clsBooking Booking = clsBooking.Find(BookingID);

                if (Booking == null)
                {
                    return null;
                }

                return new clsTransaction(Booking.BookingID, Booking.CustomerID,
                    Booking.VehicleID, Booking.RentalStartDate, Booking.RentalEndDate,
                    Booking.InitialRentalDays, Booking.PickupLocation,
                    Booking.DropoffLocation, Booking.RentalPricePerDay,
                    Booking.InitialTotalDueAmount, Booking.InitialCheckNotes,
                    TransactionID, ReturnID, PaymentDetails, PaidInitialTotalDueAmount,
                     ActualTotalDueAmount, TotalRemaining, TotalRefundedAmount,
                     TransactionDate, UpdatedTransactionDate);
            }
            else
            {
                return null;
            }
        }

        public bool DeleteTransaction()
        {
            if (!clsTransactionData.DeleteTransaction(this.TransactionID))
            {
                return false;
            }

            return base.DeleteBooking();
        }

        public static bool DoesTransactionExist(int? TransactionID)
        {
            return clsTransactionData.DoesTransactionExist(TransactionID);
        }

        public static DataTable GetAllRentalTransaction()
        {
            return clsTransactionData.GetAllRentalTransaction();
        }

        public static int GetTransactionsCount()
        {
            return clsTransactionData.GetTransactionsCount();
        }

        public static int? GetReturnIDByBookingID(int? BookingID)
        {
            return clsTransactionData.GetReturnIDByBookingID(BookingID);
        }
    }
}
