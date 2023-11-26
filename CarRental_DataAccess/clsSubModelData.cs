using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsSubModelData
    {
        public static bool GetSubModelInfoByID(int? SubModelID, ref int ModelID,
            ref string SubModelName)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from SubModels where SubModelID = @SubModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubModelID", (object)SubModelID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                ModelID = (int)reader["ModelID"];
                                SubModelName = (string)reader["SubModelName"];
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

        public static bool GetSubModelInfoByName(string SubModelName, ref int? SubModelID, ref int ModelID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT * FROM SubModels WHERE SubModelName = @SubModelName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubModelName", SubModelName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                SubModelID = (reader["SubModelID"] != DBNull.Value) ? (int?)reader["SubModelID"] : null;
                                ModelID = (int)reader["ModelID"];
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

        public static int? AddNewSubModel(int ModelID, string SubModelName)
        {
            // This function will return the new person id if succeeded and null if not
            int? SubModelID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into SubModels (ModelID, SubModelName)
values (@ModelID, @SubModelName)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ModelID", ModelID);
                        command.Parameters.AddWithValue("@SubModelName", SubModelName);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            SubModelID = InsertID;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return SubModelID;
        }

        public static bool UpdateSubModel(int? SubModelID, int ModelID, string SubModelName)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update SubModels
set ModelID = @ModelID,
SubModelName = @SubModelName
where SubModelID = @SubModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubModelID", (object)SubModelID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ModelID", ModelID);
                        command.Parameters.AddWithValue("@SubModelName", SubModelName);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DeleteSubModel(int? SubModelID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete SubModels where SubModelID = @SubModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubModelID", (object)SubModelID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return (RowAffected > 0);
        }

        public static bool DoesSubModelExist(int? SubModelID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from SubModels where SubModelID = @SubModelID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SubModelID", (object)SubModelID ?? DBNull.Value);

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

        public static DataTable GetAllSubModels()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from SubModels";

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

        public static DataTable GetAllSubModelsName()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT DISTINCT SubModelName FROM SubModels ORDER BY SubModelName";

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
