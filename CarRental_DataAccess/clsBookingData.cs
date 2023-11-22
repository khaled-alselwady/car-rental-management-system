using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsBookingData
    {
        public static bool GetBookingInfoByID(int BookingID, ref int CustomerID, ref int VehicleID, ref DateTime RentalStartDate, ref DateTime RentalEndDate, ref int InitialRentalDays, ref string PickupLocation, ref string DropoffLocation, ref decimal RentalPricePerDay, ref decimal InitialTotalDueAmount, ref string InitialCheckNotes)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalBooking where BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", BookingID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                CustomerID = (int)reader["CustomerID"];
                                VehicleID = (int)reader["VehicleID"];
                                RentalStartDate = (DateTime)reader["RentalStartDate"];
                                RentalEndDate = (DateTime)reader["RentalEndDate"];
                                InitialRentalDays = (reader["InitialRentalDays"] != DBNull.Value) ? (int)reader["InitialRentalDays"] : 0;
                                PickupLocation = (string)reader["PickupLocation"];
                                DropoffLocation = (string)reader["DropoffLocation"];
                                RentalPricePerDay = (decimal)reader["RentalPricePerDay"];
                                InitialTotalDueAmount = (reader["InitialTotalDueAmount"] != DBNull.Value) ? (decimal)reader["InitialTotalDueAmount"] : 0M;
                                InitialCheckNotes = (reader["InitialCheckNotes"] != DBNull.Value) ? (string)reader["InitialCheckNotes"] : string.Empty;
                            }
                            else
                            {
                                // The record was not found
                                IsFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
            }

            return IsFound;
        }

        public static int AddNewBooking(int CustomerID, int VehicleID, DateTime RentalStartDate, DateTime RentalEndDate, int InitialRentalDays, string PickupLocation, string DropoffLocation, decimal RentalPricePerDay, decimal InitialTotalDueAmount, string InitialCheckNotes)
        {
            // This function will return the new person id if succeeded and -1 if not
            int BookingID = -1;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into RentalBooking (CustomerID, VehicleID, RentalStartDate, RentalEndDate, InitialRentalDays, PickupLocation, DropoffLocation, RentalPricePerDay, InitialTotalDueAmount, InitialCheckNotes)
values (@CustomerID, @VehicleID, @RentalStartDate, @RentalEndDate, @InitialRentalDays, @PickupLocation, @DropoffLocation, @RentalPricePerDay, @InitialTotalDueAmount, @InitialCheckNotes)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@RentalStartDate", RentalStartDate);
                        command.Parameters.AddWithValue("@RentalEndDate", RentalEndDate);
                        if (InitialRentalDays <= 0)
                        {
                            command.Parameters.AddWithValue("@InitialRentalDays", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@InitialRentalDays", InitialRentalDays);
                        }
                        command.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                        command.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
                        command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
                        if (InitialTotalDueAmount <= 0)
                        {
                            command.Parameters.AddWithValue("@InitialTotalDueAmount", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@InitialTotalDueAmount", InitialTotalDueAmount);
                        }
                        if (string.IsNullOrWhiteSpace(InitialCheckNotes))
                        {
                            command.Parameters.AddWithValue("@InitialCheckNotes", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@InitialCheckNotes", InitialCheckNotes);
                        }

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            BookingID = InsertID;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return BookingID;
        }

        public static bool UpdateBooking(int BookingID, int CustomerID, int VehicleID, DateTime RentalStartDate, DateTime RentalEndDate, int InitialRentalDays, string PickupLocation, string DropoffLocation, decimal RentalPricePerDay, decimal InitialTotalDueAmount, string InitialCheckNotes)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update RentalBooking
set CustomerID = @CustomerID,
VehicleID = @VehicleID,
RentalStartDate = @RentalStartDate,
RentalEndDate = @RentalEndDate,
InitialRentalDays = @InitialRentalDays,
PickupLocation = @PickupLocation,
DropoffLocation = @DropoffLocation,
RentalPricePerDay = @RentalPricePerDay,
InitialTotalDueAmount = @InitialTotalDueAmount,
InitialCheckNotes = @InitialCheckNotes
where BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", BookingID);
                        command.Parameters.AddWithValue("@CustomerID", CustomerID);
                        command.Parameters.AddWithValue("@VehicleID", VehicleID);
                        command.Parameters.AddWithValue("@RentalStartDate", RentalStartDate);
                        command.Parameters.AddWithValue("@RentalEndDate", RentalEndDate);
                        if (InitialRentalDays <= 0)
                        {
                            command.Parameters.AddWithValue("@InitialRentalDays", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@InitialRentalDays", InitialRentalDays);
                        }
                        command.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                        command.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
                        command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
                        if (InitialTotalDueAmount <= 0)
                        {
                            command.Parameters.AddWithValue("@InitialTotalDueAmount", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@InitialTotalDueAmount", InitialTotalDueAmount);
                        }
                        if (string.IsNullOrWhiteSpace(InitialCheckNotes))
                        {
                            command.Parameters.AddWithValue("@InitialCheckNotes", DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@InitialCheckNotes", InitialCheckNotes);
                        }

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DeleteBooking(int BookingID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete RentalBooking where BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", BookingID);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DoesBookingExist(int BookingID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from RentalBooking where BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", BookingID);

                        object result = command.ExecuteScalar();

                        IsFound = (result != null);
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;
            }

            return IsFound;
        }

        public static DataTable GetAllRentalBooking()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalBooking";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return dt;
        }

        public static int GetBookingCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM RentalBooking";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                
            }
            
            return Count;
        }
    }
}
