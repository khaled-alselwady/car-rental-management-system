using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsUser
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.SecurityQuestion = string.Empty;
            this.SecurityAnswer = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsUser(int UserID, int PersonID, string Username, string Password, 
            string SecurityQuestion, string SecurityAnswer)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.Username = Username;
            this.Password = Password;
            this.SecurityQuestion = SecurityQuestion;
            this.SecurityAnswer = SecurityAnswer;

            Mode = enMode.Update;
        }

        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.Username,
                this.Password, this.SecurityQuestion, this.SecurityAnswer);

            return (this.UserID != -1);
        }

        private bool _UpdateUser()
        {
            return clsUserData.UpdateUser(this.UserID, this.PersonID, this.Username,
                this.Password, this.SecurityQuestion, this.SecurityAnswer);
        }

        public bool Save()
        {
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

        public static clsUser Find(int UserID)
        {
            int PersonID = -1;
            string Username = string.Empty;
            string Password = string.Empty;
            string SecurityQuestion = string.Empty;
            string SecurityAnswer = string.Empty;

            bool IsFound = clsUserData.GetUserInfoByID(UserID, ref PersonID, ref Username,
                ref Password, ref SecurityQuestion, ref SecurityAnswer);

            if (IsFound)
            {
                return new clsUser(UserID, PersonID, Username, Password, SecurityQuestion,
                    SecurityAnswer);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username)
        {
            int UserID = -1;
            int PersonID = -1;
            string Password = string.Empty;
            string SecurityQuestion = string.Empty;
            string SecurityAnswer = string.Empty;

            bool IsFound = clsUserData.GetUserInfoByUsername(ref UserID, ref PersonID,
                Username, ref Password, ref SecurityQuestion, ref SecurityAnswer);

            if (IsFound)
            {
                return new clsUser(UserID, PersonID, Username, Password, SecurityQuestion,
                    SecurityAnswer);
            }
            else
            {
                return null;
            }
        }

        public static clsUser Find(string Username, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            string SecurityQuestion = string.Empty;
            string SecurityAnswer = string.Empty;

            bool IsFound = clsUserData.GetUserInfoByUsernameAndPassword(ref UserID, ref PersonID,
                Username, Password, ref SecurityQuestion, ref SecurityAnswer);

            if (IsFound)
            {
                return new clsUser(UserID, PersonID, Username, Password,
                    SecurityQuestion, SecurityAnswer);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public static bool DoesUserExist(int UserID)
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
    }
}
