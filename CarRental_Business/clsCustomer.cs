using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsCustomer
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CustomerID { get; set; }
        public int PersonID { get; set; }
        public string DriverLicenseNumber { get; set; }

        public clsCustomer()
        {
            this.CustomerID = -1;
            this.PersonID = -1;
            this.DriverLicenseNumber = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsCustomer(int CustomerID, int PersonID, string DriverLicenseNumber)
        {
            this.CustomerID = CustomerID;
            this.PersonID = PersonID;
            this.DriverLicenseNumber = DriverLicenseNumber;

            Mode = enMode.Update;
        }

        private bool _AddNewCustomer()
        {
            this.CustomerID = clsCustomerData.AddNewCustomer(this.PersonID, this.DriverLicenseNumber);

            return (this.CustomerID != -1);
        }

        private bool _UpdateCustomer()
        {
            return clsCustomerData.UpdateCustomer(this.CustomerID, this.PersonID, this.DriverLicenseNumber);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCustomer())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateCustomer();
            }

            return false;
        }

        public static clsCustomer Find(int CustomerID)
        {
            int PersonID = -1;
            string DriverLicenseNumber = string.Empty;

            bool IsFound = clsCustomerData.GetCustomerInfoByID(CustomerID, ref PersonID, ref DriverLicenseNumber);

            if (IsFound)
            {
                return new clsCustomer(CustomerID, PersonID, DriverLicenseNumber);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteCustomer(int CustomerID)
        {
            return clsCustomerData.DeleteCustomer(CustomerID);
        }

        public static bool DoesCustomerExist(int CustomerID)
        {
            return clsCustomerData.DoesCustomerExist(CustomerID);
        }

        public static DataTable GetAllCustomer()
        {
            return clsCustomerData.GetAllCustomer();
        }

        public static int GetCustomersCount()
        {
            return clsCustomerData.GetCustomersCount();
        }
    }
}
