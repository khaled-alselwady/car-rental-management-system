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
        public static bool GetSubModelInfoByID(int SubModelID, ref int ModelID,
            ref string SubModelName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from SubModels where SubModelID = @SubModelID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SubModelID", SubModelID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

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

        public static int AddNewSubModel(int ModelID, string SubModelName)
        {
            // This function will return the new person id if succeeded and -1 if not
            int SubModelID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into SubModels (ModelID, SubModelName)
values (@ModelID, @SubModelName)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ModelID", ModelID);
            command.Parameters.AddWithValue("@SubModelName", SubModelName);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    SubModelID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return SubModelID;
        }

        public static bool UpdateSubModel(int SubModelID, int ModelID, string SubModelName)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update SubModels
set ModelID = @ModelID,
SubModelName = @SubModelName
where SubModelID = @SubModelID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SubModelID", SubModelID);
            command.Parameters.AddWithValue("@ModelID", ModelID);
            command.Parameters.AddWithValue("@SubModelName", SubModelName);

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

        public static bool DeleteSubModel(int SubModelID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete SubModels where SubModelID = @SubModelID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SubModelID", SubModelID);

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

        public static bool DoesSubModelExist(int SubModelID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from SubModels where SubModelID = @SubModelID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SubModelID", SubModelID);

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

        public static DataTable GetAllSubModels()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from SubModels";

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
