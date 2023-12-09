using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? CountryID { get; set; }
        public string CountryName { get; set; }

        public clsCountry()
        {
            this.CountryID = null;
            this.CountryName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsCountry(int? CountryID, string CountryName)
        {
            this.CountryID = CountryID;
            this.CountryName = CountryName;

            Mode = enMode.Update;
        }
       
        public static clsCountry Find(int? CountryID)
        {
            string CountryName = string.Empty;

            bool IsFound = clsCountryData.GetCountryInfoByID(CountryID, ref CountryName);

            if (IsFound)
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }

        public static clsCountry Find(string CountryName)
        {
            int? CountryID = null;

            bool IsFound = clsCountryData.GetCountryInfoByName(CountryName, ref CountryID);

            if (IsFound)
            {
                return new clsCountry(CountryID, CountryName);
            }
            else
            {
                return null;
            }
        }
      
        public static DataTable GetAllCountries()
        {
            return clsCountryData.GetAllCountries();
        }

        public static DataTable GetAllCountriesName()
        {
            return clsCountryData.GetAllCountriesName();
        }

    }
}
