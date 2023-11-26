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
        public static bool GetBookingInfoByID(int? BookingID, ref int? CustomerID, ref int? VehicleID,
            ref DateTime RentalStartDate, ref DateTime RentalEndDate, ref int? InitialRentalDays,
            ref string PickupLocation, ref string DropoffLocation, ref float RentalPricePerDay,
            ref float? InitialTotalDueAmount, ref string InitialCheckNotes)
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
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                // un nullable columns
                                CustomerID = (reader["CustomerID"] != DBNull.Value) ? (int?)reader["CustomerID"] : null;
                                VehicleID = (reader["VehicleID"] != DBNull.Value) ? (int?)reader["VehicleID"] : null;
                                RentalStartDate = (DateTime)reader["RentalStartDate"];
                                RentalEndDate = (DateTime)reader["RentalEndDate"];
                                PickupLocation = (string)reader["PickupLocation"];
                                DropoffLocation = (string)reader["DropoffLocation"];
                                RentalPricePerDay = Convert.ToSingle(reader["RentalPricePerDay"]);

                                // nullable columns
                                InitialRentalDays = (reader["InitialRentalDays"] != DBNull.Value) ? (int?)reader["InitialRentalDays"] : null;
                                InitialTotalDueAmount = (reader["InitialTotalDueAmount"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["InitialTotalDueAmount"]) : null;
                                InitialCheckNotes = (reader["InitialCheckNotes"] != DBNull.Value) ? (string)reader["InitialCheckNotes"] : null;
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

        public static int? AddNewBooking(int? CustomerID, int? VehicleID, DateTime RentalStartDate,
            DateTime RentalEndDate, string PickupLocation, string DropoffLocation,
             float RentalPricePerDay, string InitialCheckNotes)

        {
            // This function will return the new person id if succeeded and null if not
            int? BookingID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"
update Vehicles
set IsAvailableForRent = 0
where VehicleID = @VehicleID;

insert into RentalBooking (CustomerID, VehicleID, RentalStartDate, RentalEndDate, PickupLocation, DropoffLocation, RentalPricePerDay, InitialCheckNotes)
values (@CustomerID, @VehicleID, @RentalStartDate, @RentalEndDate, @PickupLocation, @DropoffLocation, @RentalPricePerDay, @InitialCheckNotes)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // un nullable columns
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RentalStartDate", RentalStartDate);
                        command.Parameters.AddWithValue("@RentalEndDate", RentalEndDate);
                        command.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                        command.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
                        command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);

                        // nullable columns
                        command.Parameters.AddWithValue("@InitialCheckNotes", (object)InitialCheckNotes ?? DBNull.Value);

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

        public static bool UpdateBooking(int? BookingID, int? CustomerID, int? VehicleID,
            DateTime RentalStartDate, DateTime RentalEndDate, string PickupLocation,
             string DropoffLocation, float RentalPricePerDay, string InitialCheckNotes)

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
PickupLocation = @PickupLocation,
DropoffLocation = @DropoffLocation,
RentalPricePerDay = @RentalPricePerDay,
InitialCheckNotes = @InitialCheckNotes
where BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RentalStartDate", RentalStartDate);
                        command.Parameters.AddWithValue("@RentalEndDate", RentalEndDate);
                        command.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                        command.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
                        command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);

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

        public static bool DeleteBooking(int? BookingID)
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
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DoesBookingExist(int? BookingID)
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
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

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

                    string query = @"select * from BookingDetails_View order by BookingID desc";

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

        public static DataTable GetBookingHistoryByCustomerID(int? CustomerID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from BookingDetails_View where CustomerID = @CustomerID order by BookingID desc";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);

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
            catch(SqlException ex)
            {

            }

            return dt;
        }

    }
}
