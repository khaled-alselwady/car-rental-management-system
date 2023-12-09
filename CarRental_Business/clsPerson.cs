using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enGender { Male = 0, Female = 1 };

        public int? PersonID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public enGender Gender { get; set; }
        public int? NationalityCountryID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string GenderName => (this.Gender == enGender.Male) ? "Male" : "Female";
        public clsCountry CountryInfo { get; set; }

        public clsPerson()
        {
            this.PersonID = null;
            this.Name = string.Empty;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.Email = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Gender = 0;
            this.NationalityCountryID = null;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = null;

            Mode = enMode.AddNew;
        }

        private clsPerson(int? PersonID, string Name, string Address, string Phone,
            string Email, DateTime DateOfBirth, enGender Gender, int? NationalityCountryID,
            DateTime CreatedAt, DateTime? UpdatedAt)
        {
            this.PersonID = PersonID;
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.NationalityCountryID = NationalityCountryID;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.CountryInfo = clsCountry.Find(NationalityCountryID);

            Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.Name, this.Address, this.Phone,
                this.Email, this.DateOfBirth, (byte)this.Gender, this.NationalityCountryID);

            return (this.PersonID.HasValue);
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.Name, this.Address,
                this.Phone, this.Email, this.DateOfBirth, (byte)this.Gender, this.NationalityCountryID,
                this.CreatedAt);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        public static clsPerson Find(int? PersonID)
        {
            string Name = string.Empty;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;
            int? NationalityCountryID = null;
            DateTime CreatedAt = DateTime.Now;
            DateTime? UpdatedAt = null;

            bool IsFound = clsPersonData.GetPersonInfoByID(PersonID, ref Name, ref Address,
                ref Phone, ref Email, ref DateOfBirth, ref Gender, ref NationalityCountryID,
                ref CreatedAt, ref UpdatedAt);

            if (IsFound)
            {
                return new clsPerson(PersonID, Name, Address, Phone, Email,
                    DateOfBirth, (enGender)Gender, NationalityCountryID, CreatedAt, UpdatedAt);
            }
            else
            {
                return null;
            }
        }

        public static bool DeletePerson(int? PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }

        public static bool DoesPersonExist(int? PersonID)
        {
            return clsPersonData.DoesPersonExist(PersonID);
        }

        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
    }
}
