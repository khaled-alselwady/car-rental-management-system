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

        public int ReturnID { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int ActualRentalDays { get; set; }
        public short Mileage { get; set; }
        public int ConsumedMileage { get; set; }
        public string FinalCheckNotes { get; set; }
        public decimal AdditionalCharges { get; set; }
        public decimal ActualTotalDueAmount { get; set; }

        public clsReturn()
        {
            this.ReturnID = -1;
            this.ActualReturnDate = DateTime.Now;
            this.ActualRentalDays = -1;
            this.Mileage = -1;
            this.ConsumedMileage = -1;
            this.FinalCheckNotes = string.Empty;
            this.AdditionalCharges = -1M;
            this.ActualTotalDueAmount = -1M;

            Mode = enMode.AddNew;
        }

        private clsReturn(int ReturnID, DateTime ActualReturnDate, int ActualRentalDays, 
            short Mileage, int ConsumedMileage, string FinalCheckNotes, decimal AdditionalCharges,
            decimal ActualTotalDueAmount)
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
                this.ActualRentalDays, this.Mileage, this.ConsumedMileage, this.FinalCheckNotes,
                this.AdditionalCharges, this.ActualTotalDueAmount);

            return (this.ReturnID != -1);
        }

        private bool _UpdateReturn()
        {
            return clsReturnData.UpdateReturn(this.ReturnID, this.ActualReturnDate,
                this.ActualRentalDays, this.Mileage, this.ConsumedMileage, this.FinalCheckNotes,
                this.AdditionalCharges, this.ActualTotalDueAmount);
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

        public static clsReturn Find(int ReturnID)
        {
            DateTime ActualReturnDate = DateTime.Now;
            int ActualRentalDays = -1;
            short Mileage = -1;
            int ConsumedMileage = -1;
            string FinalCheckNotes = string.Empty;
            decimal AdditionalCharges = -1M;
            decimal ActualTotalDueAmount = -1M;

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

        public static bool DeleteReturn(int ReturnID)
        {
            return clsReturnData.DeleteReturn(ReturnID);
        }

        public static bool DoesReturnExist(int ReturnID)
        {
            return clsReturnData.DoesReturnExist(ReturnID);
        }

        public static DataTable GetAllVehicleReturns()
        {
            return clsReturnData.GetAllVehicleReturns();
        }
    }
}
