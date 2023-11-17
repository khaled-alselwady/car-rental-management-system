using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsMaintenanceData
    {
        public static bool GetMaintenanceInfoByID(int MaintenanceID, ref int VehicleID, ref string Description, ref DateTime MaintenanceDate, ref decimal Cost)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Maintenance where MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    VehicleID = (int)reader["VehicleID"];
                    Description = (string)reader["Description"];
                    MaintenanceDate = (DateTime)reader["MaintenanceDate"];
                    Cost = (decimal)reader["Cost"];
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

        public static int AddNewMaintenance(int VehicleID, string Description, DateTime MaintenanceDate, decimal Cost)
        {
            // This function will return the new person id if succeeded and -1 if not
            int MaintenanceID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Maintenance (VehicleID, Description, MaintenanceDate, Cost)
values (@VehicleID, @Description, @MaintenanceDate, @Cost)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@MaintenanceDate", MaintenanceDate);
            command.Parameters.AddWithValue("@Cost", Cost);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    MaintenanceID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return MaintenanceID;
        }

        public static bool UpdateMaintenance(int MaintenanceID, int VehicleID, string Description, DateTime MaintenanceDate, decimal Cost)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Maintenance
set VehicleID = @VehicleID,
Description = @Description,
MaintenanceDate = @MaintenanceDate,
Cost = @Cost
where MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);
            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@MaintenanceDate", MaintenanceDate);
            command.Parameters.AddWithValue("@Cost", Cost);

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

        public static bool DeleteMaintenance(int MaintenanceID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete Maintenance where MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

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

        public static bool DoesMaintenanceExist(int MaintenanceID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Maintenance where MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

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

        public static DataTable GetAllMaintenance()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Maintenance";

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
