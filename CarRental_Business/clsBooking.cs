using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsBooking
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? BookingID { get; set; }
        public int? CustomerID { get; set; }
        public int? VehicleID { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public int? InitialRentalDays { get; set; }
        public string PickupLocation { get; set; }
        public string DropoffLocation { get; set; }
        public float RentalPricePerDay { get; set; }
        public float? InitialTotalDueAmount { get; set; }
        public string InitialCheckNotes { get; set; }

        public clsCustomer CustomerInfo { get; set; }
        public clsVehicle VehicleInfo { get; set; }
        public clsTransaction TransactionInfo => clsTransaction.FindByBookingID(BookingID);

        public bool IsBookingFinished => (clsTransaction.GetReturnIDByBookingID(BookingID).HasValue);

        public clsBooking()
        {
            this.BookingID = null;
            this.CustomerID = null;
            this.VehicleID = null;
            this.RentalStartDate = DateTime.Now;
            this.RentalEndDate = DateTime.Now.AddDays(1);
            this.InitialRentalDays = null;
            this.PickupLocation = string.Empty;
            this.DropoffLocation = string.Empty;
            this.RentalPricePerDay = -1f;
            this.InitialTotalDueAmount = null;
            this.InitialCheckNotes = null;

            Mode = enMode.AddNew;
        }

        private clsBooking(int? BookingID, int? CustomerID, int? VehicleID, DateTime RentalStartDate,
            DateTime RentalEndDate, int? InitialRentalDays, string PickupLocation,
            string DropoffLocation, float RentalPricePerDay, float? InitialTotalDueAmount,
            string InitialCheckNotes)
        {
            this.BookingID = BookingID;
            this.CustomerID = CustomerID;
            this.VehicleID = VehicleID;
            this.RentalStartDate = RentalStartDate;
            this.RentalEndDate = RentalEndDate;
            this.InitialRentalDays = InitialRentalDays;
            this.PickupLocation = PickupLocation;
            this.DropoffLocation = DropoffLocation;
            this.RentalPricePerDay = RentalPricePerDay;
            this.InitialTotalDueAmount = InitialTotalDueAmount;
            this.InitialCheckNotes = InitialCheckNotes;

            this.CustomerInfo = clsCustomer.Find(CustomerID);
            this.VehicleInfo = clsVehicle.Find(VehicleID);

            Mode = enMode.Update;
        }

        private bool _AddNewBooking()
        {
            this.BookingID = clsBookingData.AddNewBooking(this.CustomerID, this.VehicleID,
                this.RentalStartDate, this.RentalEndDate, this.PickupLocation,
                 this.DropoffLocation, this.RentalPricePerDay, this.InitialCheckNotes);


            return (this.BookingID.HasValue);
        }

        private bool _UpdateBooking()
        {
            return clsBookingData.UpdateBooking(this.BookingID, this.CustomerID, this.VehicleID,
                this.RentalStartDate, this.RentalEndDate, this.PickupLocation,
                 this.DropoffLocation, this.RentalPricePerDay, this.InitialCheckNotes);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBooking())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBooking();
            }

            return false;
        }

        public static clsBooking Find(int? BookingID)
        {
            int? CustomerID = null;
            int? VehicleID = null;
            DateTime RentalStartDate = DateTime.Now;
            DateTime RentalEndDate = DateTime.Now.AddDays(1);
            int? InitialRentalDays = null;
            string PickupLocation = string.Empty;
            string DropoffLocation = string.Empty;
            float RentalPricePerDay = -1f;
            float? InitialTotalDueAmount = null;
            string InitialCheckNotes = null;

            bool IsFound = clsBookingData.GetBookingInfoByID(BookingID, ref CustomerID,
                ref VehicleID, ref RentalStartDate, ref RentalEndDate, ref InitialRentalDays,
                ref PickupLocation, ref DropoffLocation, ref RentalPricePerDay,
                ref InitialTotalDueAmount, ref InitialCheckNotes);

            if (IsFound)
            {
                return new clsBooking(BookingID, CustomerID, VehicleID, RentalStartDate,
                    RentalEndDate, InitialRentalDays, PickupLocation, DropoffLocation,
                    RentalPricePerDay, InitialTotalDueAmount, InitialCheckNotes);
            }
            else
            {
                return null;
            }
        }

        public bool DeleteBooking()
        {
            return clsBookingData.DeleteBooking(this.BookingID);
        }

        public static bool DoesBookingExist(int? BookingID)
        {
            return clsBookingData.DoesBookingExist(BookingID);
        }

        public static DataTable GetAllRentalBooking()
        {
            return clsBookingData.GetAllRentalBooking();
        }

        public static int GetBookingCount()
        {
            return clsBookingData.GetBookingCount();
        }

        public static DataTable GetBookingHistoryByCustomerID(int? CustomerID)
        {
            return clsBookingData.GetBookingHistoryByCustomerID(CustomerID);
        }

    }
}
