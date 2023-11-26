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
        public static bool GetMaintenanceInfoByID(int? MaintenanceID, ref int? VehicleID,
            ref string Description, ref DateTime MaintenanceDate, ref float Cost)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from Maintenance where MaintenanceID = @MaintenanceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                VehicleID = (reader["VehicleID"] != DBNull.Value) ? (int?)reader["VehicleID"] : null;
                                Description = (string)reader["Description"];
                                MaintenanceDate = (DateTime)reader["MaintenanceDate"];
                                Cost = Convert.ToSingle(reader["Cost"]);
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

        public static int? AddNewMaintenance(int? VehicleID, string Description,
            DateTime MaintenanceDate, float Cost)
        {
            // This function will return the new person id if succeeded and null if not
            int? MaintenanceID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into Maintenance (VehicleID, Description, MaintenanceDate, Cost)
values (@VehicleID, @Description, @MaintenanceDate, @Cost)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@MaintenanceDate", MaintenanceDate);
                        command.Parameters.AddWithValue("@Cost", Cost);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            MaintenanceID = InsertID;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return MaintenanceID;
        }

        public static bool UpdateMaintenance(int? MaintenanceID, int? VehicleID,
            string Description, DateTime MaintenanceDate, float Cost)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update Maintenance
set VehicleID = @VehicleID,
Description = @Description,
MaintenanceDate = @MaintenanceDate,
Cost = @Cost
where MaintenanceID = @MaintenanceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaintenanceID", (object)MaintenanceID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@MaintenanceDate", MaintenanceDate);
                        command.Parameters.AddWithValue("@Cost", Cost);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DeleteMaintenance(int? MaintenanceID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete Maintenance where MaintenanceID = @MaintenanceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaintenanceID", (object)MaintenanceID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DoesMaintenanceExist(int? MaintenanceID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from Maintenance where MaintenanceID = @MaintenanceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaintenanceID", (object)MaintenanceID ?? DBNull.Value);

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

        public static DataTable GetAllMaintenance()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from Maintenance";

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

        public static DataTable GetVehicleMaintenanceHistory(int? VehicleID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT Maintenance.MaintenanceID, Maintenance.VehicleID, Vehicles.VehicleName, Maintenance.MaintenanceDate, Maintenance.Description, Maintenance.Cost, Vehicles.IsAvailableForRent
                            FROM Vehicles
                            INNER JOIN Maintenance ON Vehicles.VehicleID = Maintenance.VehicleID
                            WHERE Maintenance.VehicleID = @VehicleID
                            ORDER BY Maintenance.MaintenanceDate DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);

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
    }
}
