using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsReturn
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ReturnID { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int ActualRentalDays { get; set; }
        public int Mileage { get; set; }
        public int ConsumedMileage { get; set; }
        public string FinalCheckNotes { get; set; }
        public float AdditionalCharges { get; set; }
        public float ActualTotalDueAmount { get; set; }

        public clsTransaction TransactionInfo => clsTransaction.FindByReturnID(this.ReturnID);

        public clsReturn()
        {
            this.ReturnID = null;
            this.ActualReturnDate = DateTime.Now;
            this.ActualRentalDays = 0;
            this.Mileage = -1;
            this.ConsumedMileage = 0;
            this.FinalCheckNotes = string.Empty;
            this.AdditionalCharges = -1f;
            this.ActualTotalDueAmount = 0f;

            Mode = enMode.AddNew;
        }

        private clsReturn(int? ReturnID, DateTime ActualReturnDate, int ActualRentalDays,
            int Mileage, int ConsumedMileage, string FinalCheckNotes, float AdditionalCharges,
            float ActualTotalDueAmount)
        {
            this.ReturnID = ReturnID;
            this.ActualReturnDate = ActualReturnDate;
            this.ActualRentalDays = ActualRentalDays;
            this.Mileage = Mileage;
            this.ConsumedMileage = ConsumedMileage;
            this.FinalCheckNotes = FinalCheckNotes;
            this.AdditionalCharges = AdditionalCharges;
            this.ActualTotalDueAmount = ActualTotalDueAmount;

            Mode = enMode.Update;
        }

        private bool _AddNewReturn()
        {
            this.ReturnID = clsReturnData.AddNewReturn(this.ActualReturnDate,
                this.ActualRentalDays, this.Mileage, this.ConsumedMileage,
                  this.FinalCheckNotes, this.AdditionalCharges, this.ActualTotalDueAmount);

            return (this.ReturnID.HasValue);
        }

        private bool _UpdateReturn()
        {
            return clsReturnData.UpdateReturn(this.ReturnID, this.ActualReturnDate,
                this.ActualRentalDays, this.Mileage, this.ConsumedMileage,
                  this.FinalCheckNotes, this.AdditionalCharges, this.ActualTotalDueAmount);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReturn())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateReturn();
            }

            return false;
        }

        public static clsReturn Find(int? ReturnID)
        {
            DateTime ActualReturnDate = DateTime.Now;
            int ActualRentalDays = 0;
            int Mileage = -1;
            int ConsumedMileage = 0;
            string FinalCheckNotes = string.Empty;
            float AdditionalCharges = -1f;
            float ActualTotalDueAmount = 0f;

            bool IsFound = clsReturnData.GetReturnInfoByID(ReturnID, ref ActualReturnDate,
                ref ActualRentalDays, ref Mileage, ref ConsumedMileage, ref FinalCheckNotes,
                ref AdditionalCharges, ref ActualTotalDueAmount);

            if (IsFound)
            {
                return new clsReturn(ReturnID, ActualReturnDate, ActualRentalDays,
                    Mileage, ConsumedMileage, FinalCheckNotes, AdditionalCharges,
                    ActualTotalDueAmount);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteReturn(int? ReturnID)
        {
            return clsReturnData.DeleteReturn(ReturnID);
        }

        public static bool DoesReturnExist(int? ReturnID)
        {
            return clsReturnData.DoesReturnExist(ReturnID);
        }

        public static DataTable GetAllVehicleReturns()
        {
            return clsReturnData.GetAllVehicleReturns();
        }

        public static int GetReturnCount()
        {
            return clsReturnData.GetReturnCount();
        }

        public bool UpdateTransaction(int? TransactionID)
        {
            clsTransaction Transaction = clsTransaction.FindByTransactionID(TransactionID);

            if (Transaction == null)
            {
                return false;
            }

            Transaction.ReturnID = this.ReturnID;
            Transaction.ActualTotalDueAmount = this.ActualTotalDueAmount;
            Transaction.TotalRemaining = Transaction.InitialTotalDueAmount - this.ActualTotalDueAmount;

            return Transaction.Save();
        }
    }
}
