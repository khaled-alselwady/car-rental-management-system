using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsUser : clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enPermissions
        {
            All = -1,
            ManageCustomers = 1,
            ManageUsers = 2,
            ManageVehicles = 4,
            ManageBooking = 8,
            ManageReturn = 16,
            ManageTransactions = 32
        }
        public int? UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = null;
            this.PersonID = null;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Permissions = -1;
            this.SecurityQuestion = null;
            this.SecurityAnswer = null;
            this.ImagePath = null;
            this.IsActive = false;

            Mode = enMode.AddNew;
        }

        private clsUser(int? PersonID, string Name, string Address, string Phone,
            string Email, DateTime DateOfBirth, enGender Gender, int? NationalityCountryID,
            DateTime CreatedAt, DateTime? UpdatedAt, int? UserID, string Username, string Password,
            int Permissions, string SecurityQuestion, string SecurityAnswer,
            string ImagePath, bool IsActive)
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

            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.Permissions = Permissions;
            this.SecurityQuestion = SecurityQuestion;
            this.SecurityAnswer = SecurityAnswer;
            this.ImagePath = ImagePath;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.Username, this.Password,
                this.Permissions, this.SecurityQuestion, this.SecurityAnswer, this.ImagePath,
                this.IsActive);

            return (this.UserID.HasValue);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.Username, this.Password,
                this.Permissions, this.SecurityQuestion, this.SecurityAnswer, this.ImagePath,
                this.IsActive);
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
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateUser();
            }

            return false;
        }

        private static int? _GetPersonIDByUserID(int? UserID)
        {
            return clsUserData.GetPersonIDByUserID(UserID);
        }

        public static clsUser Find(int? UserID)
        {
            int? PersonID = null;
            string Username = string.Empty;
            string Password = string.Empty;
            int Permissions = -1;
            string SecurityQuestion = null;
            string SecurityAnswer = null;
            string ImagePath = null;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByID(UserID, ref PersonID, ref Username,
                ref Password, ref Permissions, ref SecurityQuestion, ref SecurityAnswer,
                ref ImagePath, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.NationalityCountryID,
                    Person.CreatedAt, Person.UpdatedAt, UserID, Username, Password, Permissions,
                    SecurityQuestion, SecurityAnswer, ImagePath, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username)
        {
            int? UserID = null;
            int? PersonID = null;
            string Password = string.Empty;
            int Permissions = -1;
            string SecurityQuestion = null;
            string SecurityAnswer = null;
            string ImagePath = null;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsername(ref UserID, ref PersonID, Username,
                ref Password, ref Permissions, ref SecurityQuestion, ref SecurityAnswer,
                ref ImagePath, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.NationalityCountryID,
                    Person.CreatedAt, Person.UpdatedAt, UserID, Username, Password, Permissions,
                    SecurityQuestion, SecurityAnswer, ImagePath, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username, string Password)
        {
            int? UserID = null;
            int? PersonID = null;
            int Permissions = -1;
            string SecurityQuestion = null;
            string SecurityAnswer = null;
            string ImagePath = null;
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword(ref UserID, ref PersonID,
                Username, Password, ref Permissions, ref SecurityQuestion, ref SecurityAnswer,
                ref ImagePath, ref IsActive);

            if (IsFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);

                if (Person == null)
                {
                    return null;
                }

                return new clsUser(Person.PersonID, Person.Name, Person.Address, Person.Phone,
                    Person.Email, Person.DateOfBirth, Person.Gender, Person.NationalityCountryID,
                    Person.CreatedAt, Person.UpdatedAt, UserID, Username, Password, Permissions,
                    SecurityQuestion, SecurityAnswer, ImagePath, IsActive);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteUser(int? UserID)
        {
            int? PersonID = _GetPersonIDByUserID(UserID);

            if (!PersonID.HasValue)
            {
                return false;
            }

            if (clsUserData.DeleteUser(UserID))
            {
                return clsPerson.DeletePerson(PersonID);
            }

            return false;
        }

        public static bool DoesUserExist(int? UserID)
        {
            return clsUserData.DoesUserExist(UserID);
        }

        public static bool DoesUserExist(string Username)
        {
            return clsUserData.DoesUserExist(Username);
        }

        public static bool DoesUserExist(string Username, string Password)
        {
            return clsUserData.DoesUserExist(Username, Password);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static int GetUsersCount()
        {
            return clsUserData.GetUsersCount();
        }

        public bool ChangePassword(string NewPassword)
        {
            return ChangePassword(this.UserID, NewPassword);
        }

        public static bool ChangePassword(int? UserID, string NewPassword)
        {
            return clsUserData.ChangePassword(UserID, NewPassword);
        }
    }
}
