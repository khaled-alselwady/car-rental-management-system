using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsDriveTypeData
    {
        public static bool GetDriveTypeInfoByID(int? DriveTypeID, ref string DriveTypeName)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from DriveTypes where DriveTypeID = @DriveTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriveTypeID", (object)DriveTypeID != DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                DriveTypeName = (string)reader["DriveTypeName"];
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

        public static bool GetDriveTypeInfoByName(string driveTypeName, ref int? driveTypeID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from DriveTypes where DriveTypeName = @DriveTypeName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriveTypeName", driveTypeName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;
                                driveTypeID = (reader["DriveTypeID"] != DBNull.Value) ? (int?)reader["DriveTypeID"] : null;
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isFound = false;
            }

            return isFound;
        }

        public static int? AddNewDriveType(string DriveTypeName)
        {
            // This function will return the new person id if succeeded and null if not
            int? DriveTypeID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into DriveTypes (DriveTypeName)
values (@DriveTypeName)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriveTypeName", DriveTypeName);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            DriveTypeID = InsertID;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }
            return DriveTypeID;
        }

        public static bool UpdateDriveType(int? DriveTypeID, string DriveTypeName)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update DriveTypes
set DriveTypeName = @DriveTypeName
where DriveTypeID = @DriveTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriveTypeID", (object)DriveTypeID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DriveTypeName", DriveTypeName);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DeleteDriveType(int? DriveTypeID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete DriveTypes where DriveTypeID = @DriveTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriveTypeID", (object)DriveTypeID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DoesDriveTypeExist(int? DriveTypeID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from DriveTypes where DriveTypeID = @DriveTypeID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DriveTypeID", (object)DriveTypeID ?? DBNull.Value);

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

        public static DataTable GetAllDriveTypes()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from DriveTypes";

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

        public static DataTable GetAllDriveTypesName()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select distinct DriveTypeName from DriveTypes order by DriveTypeName";

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

    }
}
