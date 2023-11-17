using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsModelData
    {
        public static bool GetModelInfoByID(int ModelID, ref int MakeID, ref string ModelName)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from MakeModels where ModelID = @ModelID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ModelID", ModelID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    MakeID = (int)reader["MakeID"];
                    ModelName = (string)reader["ModelName"];
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

        public static int AddNewModel(int MakeID, string ModelName)
        {
            // This function will return the new person id if succeeded and -1 if not
            int ModelID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into MakeModels (MakeID, ModelName)
values (@MakeID, @ModelName)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MakeID", MakeID);
            command.Parameters.AddWithValue("@ModelName", ModelName);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    ModelID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return ModelID;
        }

        public static bool UpdateModel(int ModelID, int MakeID, string ModelName)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update MakeModels
set MakeID = @MakeID,
ModelName = @ModelName
where ModelID = @ModelID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ModelID", ModelID);
            command.Parameters.AddWithValue("@MakeID", MakeID);
            command.Parameters.AddWithValue("@ModelName", ModelName);

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

        public static bool DeleteModel(int ModelID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete MakeModels where ModelID = @ModelID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ModelID", ModelID);

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

        public static bool DoesModelExist(int ModelID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from MakeModels where ModelID = @ModelID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ModelID", ModelID);

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

        public static DataTable GetAllMakeModels()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from MakeModels";

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

