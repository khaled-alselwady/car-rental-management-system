using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsTransaction
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int TransactionID { get; set; }
        public int BookingID { get; set; }
        public int ReturnID { get; set; }
        public string PaymentDetails { get; set; }
        public decimal PaidInitialTotalDueAmount { get; set; }
        public decimal ActualTotalDueAmount { get; set; }
        public decimal TotalRemaining { get; set; }
        public decimal TotalRefundedAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime UpdatedTransactionDate { get; set; }

        public clsTransaction()
        {
            this.TransactionID = -1;
            this.BookingID = -1;
            this.ReturnID = -1;
            this.PaymentDetails = string.Empty;
            this.PaidInitialTotalDueAmount = -1M;
            this.ActualTotalDueAmount = -1M;
            this.TotalRemaining = -1M;
            this.TotalRefundedAmount = -1M;
            this.TransactionDate = DateTime.Now;
            this.UpdatedTransactionDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsTransaction(int TransactionID, int BookingID, int ReturnID, string PaymentDetails,
            decimal PaidInitialTotalDueAmount, decimal ActualTotalDueAmount,
            decimal TotalRemaining, decimal TotalRefundedAmount, DateTime TransactionDate,
            DateTime UpdatedTransactionDate)
        {
            this.TransactionID = TransactionID;
            this.BookingID = BookingID;
            this.ReturnID = ReturnID;
            this.PaymentDetails = PaymentDetails;
            this.PaidInitialTotalDueAmount = PaidInitialTotalDueAmount;
            this.ActualTotalDueAmount = ActualTotalDueAmount;
            this.TotalRemaining = TotalRemaining;
            this.TotalRefundedAmount = TotalRefundedAmount;
            this.TransactionDate = TransactionDate;
            this.UpdatedTransactionDate = UpdatedTransactionDate;

            Mode = enMode.Update;
        }

        private bool _AddNewTransaction()
        {
            this.TransactionID = clsTransactionData.AddNewTransaction(this.BookingID, this.ReturnID,
                this.PaymentDetails, this.PaidInitialTotalDueAmount, this.ActualTotalDueAmount, 
                this.TotalRemaining, this.TotalRefundedAmount, this.TransactionDate,
                this.UpdatedTransactionDate);

            return (this.TransactionID != -1);
        }

        private bool _UpdateTransaction()
        {
            return clsTransactionData.UpdateTransaction(this.TransactionID, this.BookingID,
                this.ReturnID, this.PaymentDetails, this.PaidInitialTotalDueAmount,
                this.ActualTotalDueAmount, this.TotalRemaining, this.TotalRefundedAmount,
                this.TransactionDate, this.UpdatedTransactionDate);
        }

        public bool Save()
        {
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

        public static clsTransaction Find(int TransactionID)
        {
            int BookingID = -1;
            int ReturnID = -1;
            string PaymentDetails = string.Empty;
            decimal PaidInitialTotalDueAmount = -1M;
            decimal ActualTotalDueAmount = -1M;
            decimal TotalRemaining = -1M;
            decimal TotalRefundedAmount = -1M;
            DateTime TransactionDate = DateTime.Now;
            DateTime UpdatedTransactionDate = DateTime.Now;

            bool IsFound = clsTransactionData.GetTransactionInfoByID(TransactionID, ref BookingID,
                ref ReturnID, ref PaymentDetails, ref PaidInitialTotalDueAmount,
                ref ActualTotalDueAmount, ref TotalRemaining, ref TotalRefundedAmount, 
                ref TransactionDate, ref UpdatedTransactionDate);

            if (IsFound)
            {
                return new clsTransaction(TransactionID, BookingID, ReturnID,
                    PaymentDetails, PaidInitialTotalDueAmount, ActualTotalDueAmount,
                    TotalRemaining, TotalRefundedAmount, TransactionDate, UpdatedTransactionDate);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteTransaction(int TransactionID)
        {
            return clsTransactionData.DeleteTransaction(TransactionID);
        }

        public static bool DoesTransactionExist(int TransactionID)
        {
            return clsTransactionData.DoesTransactionExist(TransactionID);
        }

        public static DataTable GetAllRentalTransaction()
        {
            return clsTransactionData.GetAllRentalTransaction();
        }
    }
}
