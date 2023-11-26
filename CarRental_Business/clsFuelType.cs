using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsFuelType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? FuelTypeID { get; set; }
        public string FuelTypeName { get; set; }

        public clsFuelType()
        {
            this.FuelTypeID = null;
            this.FuelTypeName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsFuelType(int? FuelTypeID, string FuelTypeName)
        {
            this.FuelTypeID = FuelTypeID;
            this.FuelTypeName = FuelTypeName;

            Mode = enMode.Update;
        }

        private bool _AddNewFuelType()
        {
            this.FuelTypeID = clsFuelTypeData.AddNewFuelType(this.FuelTypeName);

            return (this.FuelTypeID.HasValue);
        }

        private bool _UpdateFuelType()
        {
            return clsFuelTypeData.UpdateFuelType(this.FuelTypeID, this.FuelTypeName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewFuelType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateFuelType();
            }

            return false;
        }

        public static clsFuelType Find(int? FuelTypeID)
        {
            string FuelTypeName = string.Empty;

            bool IsFound = clsFuelTypeData.GetFuelTypeInfoByID(FuelTypeID, ref FuelTypeName);

            if (IsFound)
            {
                return new clsFuelType(FuelTypeID, FuelTypeName);
            }
            else
            {
                return null;
            }
        }

        public static clsFuelType Find(string FuelTypeName)
        {
            int? FuelTypeID = null;

            bool IsFound = clsFuelTypeData.GetFuelTypeInfoByName(FuelTypeName, ref FuelTypeID);

            if (IsFound)
            {
                return new clsFuelType(FuelTypeID, FuelTypeName);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteFuelType(int? FuelTypeID)
        {
            return clsFuelTypeData.DeleteFuelType(FuelTypeID);
        }

        public static bool DoesFuelTypeExist(int? FuelTypeID)
        {
            return clsFuelTypeData.DoesFuelTypeExist(FuelTypeID);
        }

        public static DataTable GetAllFuelTypes()
        {
            return clsFuelTypeData.GetAllFuelTypes();
        }

        public static DataTable GetAllFuelTypesName()
        {
            return clsFuelTypeData.GetAllFuelTypesName();
        }
    }
}
