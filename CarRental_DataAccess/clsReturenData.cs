using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsReturnData
    {
        public static bool GetReturnInfoByID(int? ReturenID, ref DateTime ActualReturnDate,
            ref int? ActualRentalDays, ref short Mileage, ref int? ConsumedMileage,
            ref string FinalCheckNotes, ref float AdditionalCharges,
            ref float? ActualTotalDueAmount)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from VehicleReturns where ReturenID = @ReturenID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturenID", (object)ReturenID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                ActualReturnDate = (DateTime)reader["ActualReturnDate"];
                                ActualRentalDays = (reader["ActualRentalDays"] != DBNull.Value) ? (int?)reader["ActualRentalDays"] : null;
                                Mileage = (short)reader["Mileage"];
                                ConsumedMileage = (reader["ConsumedMileage"] != DBNull.Value) ? (int?)reader["ConsumedMileage"] : null;
                                FinalCheckNotes = (string)reader["FinalCheckNotes"];
                                AdditionalCharges = Convert.ToSingle(reader["AdditionalCharges"]);
                                ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (float?)Convert.ToSingle(reader["ActualTotalDueAmount"]) : null;
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

        public static int? AddNewReturn(DateTime ActualReturnDate, int? ActualRentalDays,
            short Mileage, int? ConsumedMileage, string FinalCheckNotes,
            float AdditionalCharges, float? ActualTotalDueAmount)
        {
            // This function will return the new person id if succeeded and null if not
            int? ReturenID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into VehicleReturns (ActualReturnDate, ActualRentalDays, Mileage, ConsumedMileage, FinalCheckNotes, AdditionalCharges, ActualTotalDueAmount)
values (@ActualReturnDate, @ActualRentalDays, @Mileage, @ConsumedMileage, @FinalCheckNotes, @AdditionalCharges, @ActualTotalDueAmount)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                        command.Parameters.AddWithValue("@ActualRentalDays", (object)ActualRentalDays ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Mileage", Mileage);
                        command.Parameters.AddWithValue("@ConsumedMileage", (object)ConsumedMileage ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                        command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", (object)ActualTotalDueAmount ?? DBNull.Value);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            ReturenID = InsertID;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return ReturenID;
        }

        public static bool UpdateReturn(int? ReturenID, DateTime ActualReturnDate,
            int? ActualRentalDays, short Mileage, int? ConsumedMileage,
            string FinalCheckNotes, float AdditionalCharges,
            float? ActualTotalDueAmount)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update VehicleReturns
set ActualReturnDate = @ActualReturnDate,
ActualRentalDays = @ActualRentalDays,
Mileage = @Mileage,
ConsumedMileage = @ConsumedMileage,
FinalCheckNotes = @FinalCheckNotes,
AdditionalCharges = @AdditionalCharges,
ActualTotalDueAmount = @ActualTotalDueAmount
where ReturenID = @ReturenID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturenID", (object)ReturenID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                        command.Parameters.AddWithValue("@ActualRentalDays", (object)ActualRentalDays ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Mileage", Mileage);
                        command.Parameters.AddWithValue("@ConsumedMileage", (object)ConsumedMileage ?? DBNull.Value);
                        command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                        command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", (object)ActualTotalDueAmount ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DeleteReturn(int? ReturenID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete VehicleReturns where ReturenID = @ReturenID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturenID", (object)ReturenID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DoesReturnExist(int? ReturenID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from VehicleReturns where ReturenID = @ReturenID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturenID", (object)ReturenID ?? DBNull.Value);

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

        public static DataTable GetAllVehicleReturns()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from VehicleReturns";

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

        public static int GetReturnCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM VehicleReturns";

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
