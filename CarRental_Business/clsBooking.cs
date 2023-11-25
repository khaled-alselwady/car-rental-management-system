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

        public int BookingID { get; set; } // not allow null
        public int CustomerID { get; set; } // not allow null
        public int VehicleID { get; set; } // not allow null
        public DateTime RentalStartDate { get; set; } // not allow null
        public DateTime RentalEndDate { get; set; } // not allow null
        public int InitialRentalDays { get; set; } // allow null
        public string PickupLocation { get; set; } // not allow null
        public string DropoffLocation { get; set; } // not allow null
        public float RentalPricePerDay { get; set; } // not allow null
        public float InitialTotalDueAmount { get; set; } // allow null
        public string InitialCheckNotes { get; set; } // allow null

        public clsBooking()
        {
            this.BookingID = -1;
            this.CustomerID = -1;
            this.VehicleID = -1;
            this.RentalStartDate = DateTime.Now;
            this.RentalEndDate = DateTime.Now.AddDays(1);
            this.InitialRentalDays = -1;
            this.PickupLocation = string.Empty;
            this.DropoffLocation = string.Empty;
            this.RentalPricePerDay = -1f;
            this.InitialTotalDueAmount = -1f;
            this.InitialCheckNotes = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsBooking(int BookingID, int CustomerID, int VehicleID, DateTime RentalStartDate,
            DateTime RentalEndDate, int InitialRentalDays, string PickupLocation,
            string DropoffLocation, float RentalPricePerDay, float InitialTotalDueAmount,
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

            Mode = enMode.Update;
        }

        private bool _AddNewBooking()
        {
            this.BookingID = clsBookingData.AddNewBooking(this.CustomerID, this.VehicleID,
                this.RentalStartDate, this.RentalEndDate, this.PickupLocation,
                 this.DropoffLocation, this.RentalPricePerDay, this.InitialCheckNotes);


            return (this.BookingID != -1);
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

        public static clsBooking Find(int BookingID)
        {
            int CustomerID = -1;
            int VehicleID = -1;
            DateTime RentalStartDate = DateTime.Now;
            DateTime RentalEndDate = DateTime.Now.AddDays(1);
            int InitialRentalDays = -1;
            string PickupLocation = string.Empty;
            string DropoffLocation = string.Empty;
            float RentalPricePerDay = -1f;
            float InitialTotalDueAmount = -1f;
            string InitialCheckNotes = string.Empty;

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

        public static bool DeleteBooking(int BookingID)
        {
            return clsBookingData.DeleteBooking(BookingID);
        }

        public static bool DoesBookingExist(int BookingID)
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

        public int? Transaction(string PaymentDetails, float InitialTotalDueAmount)
        {
            clsTransaction Transaction = new clsTransaction();

            Transaction.BookingID = this.BookingID;
            Transaction.PaidInitialTotalDueAmount = InitialTotalDueAmount;
            Transaction.PaymentDetails = PaymentDetails;

            if (!Transaction.Save())
            {
                return null;
            }

            return Transaction.TransactionID;
        }

        public static DataTable GetBookingHistoryByCustomerID(int CustomerID)
        {
            return clsBookingData.GetBookingHistoryByCustomerID(CustomerID);
        }

    }
}
