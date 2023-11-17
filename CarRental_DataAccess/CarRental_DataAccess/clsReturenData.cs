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
        public static bool GetReturnInfoByID(int ReturenID, ref DateTime ActualReturnDate,
            ref int ActualRentalDays, ref short Mileage, ref int ConsumedMileage, 
            ref string FinalCheckNotes, ref decimal AdditionalCharges,
            ref decimal ActualTotalDueAmount)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from VehicleReturns where ReturenID = @ReturenID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReturenID", ReturenID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    ActualReturnDate = (DateTime)reader["ActualReturnDate"];
                    ActualRentalDays = (reader["ActualRentalDays"] != DBNull.Value) ? (int)reader["ActualRentalDays"] : 0;
                    Mileage = (short)reader["Mileage"];
                    ConsumedMileage = (reader["ConsumedMileage"] != DBNull.Value) ? (int)reader["ConsumedMileage"] : 0;
                    FinalCheckNotes = (string)reader["FinalCheckNotes"];
                    AdditionalCharges = (decimal)reader["AdditionalCharges"];
                    ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (decimal)reader["ActualTotalDueAmount"] : 0M;
                }
                else
                {
                    // The record was not found
                    IsFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int AddNewReturn(DateTime ActualReturnDate, int ActualRentalDays, 
            short Mileage, int ConsumedMileage, string FinalCheckNotes,
            decimal AdditionalCharges, decimal ActualTotalDueAmount)
        {
            // This function will return the new person id if succeeded and -1 if not
            int ReturenID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into VehicleReturns (ActualReturnDate, ActualRentalDays, Mileage, ConsumedMileage, FinalCheckNotes, AdditionalCharges, ActualTotalDueAmount)
values (@ActualReturnDate, @ActualRentalDays, @Mileage, @ConsumedMileage, @FinalCheckNotes, @AdditionalCharges, @ActualTotalDueAmount)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            if (ActualRentalDays <= 0)
            {
                command.Parameters.AddWithValue("@ActualRentalDays", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
            }
            command.Parameters.AddWithValue("@Mileage", Mileage);
            if (ConsumedMileage <= 0)
            {
                command.Parameters.AddWithValue("@ConsumedMileage", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);
            }
            command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
            command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
            if (ActualTotalDueAmount <= 0)
            {
                command.Parameters.AddWithValue("@ActualTotalDueAmount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    ReturenID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ReturenID;
        }

        public static bool UpdateReturn(int ReturenID, DateTime ActualReturnDate,
            int ActualRentalDays, short Mileage, int ConsumedMileage, 
            string FinalCheckNotes, decimal AdditionalCharges, decimal ActualTotalDueAmount)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update VehicleReturns
set ActualReturnDate = @ActualReturnDate,
ActualRentalDays = @ActualRentalDays,
Mileage = @Mileage,
ConsumedMileage = @ConsumedMileage,
FinalCheckNotes = @FinalCheckNotes,
AdditionalCharges = @AdditionalCharges,
ActualTotalDueAmount = @ActualTotalDueAmount
where ReturenID = @ReturenID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReturenID", ReturenID);
            command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
            if (ActualRentalDays <= 0)
            {
                command.Parameters.AddWithValue("@ActualRentalDays", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
            }
            command.Parameters.AddWithValue("@Mileage", Mileage);
            if (ConsumedMileage <= 0)
            {
                command.Parameters.AddWithValue("@ConsumedMileage", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);
            }
            command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
            command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
            if (ActualTotalDueAmount <= 0)
            {
                command.Parameters.AddWithValue("@ActualTotalDueAmount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
            }

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowAffected > 0);
        }

        public static bool DeleteReturn(int ReturenID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete VehicleReturns where ReturenID = @ReturenID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReturenID", ReturenID);

            try
            {
                connection.Open();

                RowAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (RowAffected > 0);
        }

        public static bool DoesReturnExist(int ReturenID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from VehicleReturns where ReturenID = @ReturenID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReturenID", ReturenID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                IsFound = (result != null);
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllVehicleReturns()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from VehicleReturns";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
    }
}
