using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsDriveType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? DriveTypeID { get; set; }
        public string DriveTypeName { get; set; }

        public clsDriveType()
        {
            this.DriveTypeID = null;
            this.DriveTypeName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsDriveType(int? DriveTypeID, string DriveTypeName)
        {
            this.DriveTypeID = DriveTypeID;
            this.DriveTypeName = DriveTypeName;

            Mode = enMode.Update;
        }

        private bool _AddNewDriveType()
        {
            this.DriveTypeID = clsDriveTypeData.AddNewDriveType(this.DriveTypeName);

            return (this.DriveTypeID.HasValue);
        }

        private bool _UpdateDriveType()
        {
            return clsDriveTypeData.UpdateDriveType(this.DriveTypeID, this.DriveTypeName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriveType())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDriveType();
            }

            return false;
        }

        public static clsDriveType Find(int? DriveTypeID)
        {
            string DriveTypeName = string.Empty;

            bool IsFound = clsDriveTypeData.GetDriveTypeInfoByID(DriveTypeID, ref DriveTypeName);

            if (IsFound)
            {
                return new clsDriveType(DriveTypeID, DriveTypeName);
            }
            else
            {
                return null;
            }
        }

        public static clsDriveType Find(string DriveTypeName)
        {
            int? DriveTypeID = null;

            bool IsFound = clsDriveTypeData.GetDriveTypeInfoByName(DriveTypeName, ref DriveTypeID);

            if (IsFound)
            {
                return new clsDriveType(DriveTypeID, DriveTypeName);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteDriveType(int? DriveTypeID)
        {
            return clsDriveTypeData.DeleteDriveType(DriveTypeID);
        }

        public static bool DoesDriveTypeExist(int? DriveTypeID)
        {
            return clsDriveTypeData.DoesDriveTypeExist(DriveTypeID);
        }

        public static DataTable GetAllDriveTypes()
        {
            return clsDriveTypeData.GetAllDriveTypes();
        }

        public static DataTable GetAllDriveTypesName()
        {
            return clsDriveTypeData.GetAllDriveTypesName();
        }
    }
}
