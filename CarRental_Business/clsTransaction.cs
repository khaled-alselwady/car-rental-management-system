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
        public float PaidInitialTotalDueAmount { get; set; }
        public float ActualTotalDueAmount { get; set; }
        public float TotalRemaining { get; set; }
        public float TotalRefundedAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime UpdatedTransactionDate { get; set; }

        public clsTransaction()
        {
            this.TransactionID = -1;
            this.BookingID = -1;
            this.ReturnID = -1;
            this.PaymentDetails = string.Empty;
            this.PaidInitialTotalDueAmount = -1f;
            this.ActualTotalDueAmount = -1f;
            this.TotalRemaining = -1f;
            this.TotalRefundedAmount = -1f;
            this.TransactionDate = DateTime.Now;
            this.UpdatedTransactionDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private clsTransaction(int TransactionID, int BookingID, int ReturnID, string PaymentDetails,
            float PaidInitialTotalDueAmount, float ActualTotalDueAmount,
            float TotalRemaining, float TotalRefundedAmount, DateTime TransactionDate,
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
            this.TransactionID = clsTransactionData.AddNewTransaction(this.BookingID,
                this.PaymentDetails, this.PaidInitialTotalDueAmount);

            return (this.TransactionID != -1);
        }

        private bool _UpdateTransaction()
        {
            return clsTransactionData.UpdateTransaction(this.TransactionID,
                this.ReturnID, this.ActualTotalDueAmount, this.TotalRefundedAmount);
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
            float PaidInitialTotalDueAmount = -1f;
            float ActualTotalDueAmount = -1f;
            float TotalRemaining = -1f;
            float TotalRefundedAmount = -1f;
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

        public static int GetTransactionsCount()
        {
            return clsTransactionData.GetTransactionsCount();
        }
    }
}
