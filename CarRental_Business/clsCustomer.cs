using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsCustomer : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int CustomerID { get; set; }
        public string DriverLicenseNumber { get; set; }

        public clsCustomer()
        {
            this.CustomerID = -1;
            this.PersonID = -1;
            this.DriverLicenseNumber = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsCustomer(int PersonID, string Name, string Address, string Phone,
            string Email, DateTime DateOfBirth, enGender Gender, int NationalityCountryID,
            DateTime CreatedAt, DateTime UpdatedAt, int CustomerID, string DriverLicenseNumber)
        {
            base.PersonID = PersonID;
            base.Name = Name;
            base.Address = Address;
            base.Phone = Phone;
            base.Email = Email;
            base.DateOfBirth = DateOfBirth;
            base.Gender = Gender;
            base.NationalityCountryID = NationalityCountryID;
            base.CreatedAt = CreatedAt;
            base.UpdatedAt = UpdatedAt;
            base.CountryInfo = clsCountry.Find(NationalityCountryID);

            this.CustomerID = CustomerID;
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
            base.Mode = (clsPerson.enMode)Mode;

            if (!base.Save())
            {
                return false;
            }

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

        private static int _GetPersonIDByCustomerID(int CustomerID)
        {
            return clsCustomerData.GetPersonIDByCustomerID(CustomerID);
        }

        public static clsCustomer Find(int CustomerID)
        {
            int PersonID = -1;
            string DriverLicenseNumber = string.Empty;

            bool IsFound = clsCustomerData.GetCustomerInfoByID
                (CustomerID, ref PersonID, ref DriverLicenseNumber);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsCustomer(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.NationalityCountryID,
                    Person.CreatedAt, Person.UpdatedAt, CustomerID, DriverLicenseNumber);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteCustomer(int CustomerID)
        {
            int PersonID = _GetPersonIDByCustomerID(CustomerID);

            if (PersonID == -1)
            {
                return false;
            }

            if (clsCustomerData.DeleteCustomer(CustomerID))
            {
                return clsPerson.DeletePerson(PersonID);
            }

            return false;
        }

        public static bool DoesCustomerExist(int CustomerID)
        {
            return clsCustomerData.DoesCustomerExist(CustomerID);
        }

        public static bool DoesDriverLicenseNumberExist(string DriverLicenseNumber)
        {
            return clsCustomerData.DoesDriverLicenseNumberExist(DriverLicenseNumber);
        }

        public static DataTable GetAllCustomers()
        {
            return clsCustomerData.GetAllCustomers();
        }

        public static int GetCustomersCount()
        {
            return clsCustomerData.GetCustomersCount();
        }
    }
}
