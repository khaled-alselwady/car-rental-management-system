using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsUserData
    {
        public static bool GetUserInfoByID(int UserID, ref int PersonID, ref string Username,
            ref string Password, ref int Permissions, ref string SecurityQuestion,
            ref string SecurityAnswer, ref string ImagePath, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    PersonID = (int)reader["PersonID"];
                    Username = (string)reader["Username"];
                    Password = (string)reader["Password"];
                    Permissions = (int)reader["Permissions"];
                    SecurityQuestion = (reader["SecurityQuestion"] != DBNull.Value) ? (string)reader["SecurityQuestion"] : string.Empty;
                    SecurityAnswer = (reader["SecurityAnswer"] != DBNull.Value) ? (string)reader["SecurityAnswer"] : string.Empty;
                    ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : string.Empty;
                    IsActive = (bool)reader["IsActive"];
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

        public static bool GetUserInfoByUsername(ref int UserID, ref int PersonID, string Username,
            ref string Password, ref int Permissions, ref string SecurityQuestion,
            ref string SecurityAnswer, ref string ImagePath, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users where Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password = (string)reader["Password"];
                    Permissions = (int)reader["Permissions"];
                    SecurityQuestion = (reader["SecurityQuestion"] != DBNull.Value) ? (string)reader["SecurityQuestion"] : string.Empty;
                    SecurityAnswer = (reader["SecurityAnswer"] != DBNull.Value) ? (string)reader["SecurityAnswer"] : string.Empty;
                    ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : string.Empty;
                    IsActive = (bool)reader["IsActive"];
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

        public static bool GetUserInfoByUsernameAndPassword(ref int UserID, ref int PersonID,
            string Username, string Password, ref int Permissions, ref string SecurityQuestion,
            ref string SecurityAnswer, ref string ImagePath, ref bool IsActive)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users where Username = @Username AND Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Permissions = (int)reader["Permissions"];
                    SecurityQuestion = (reader["SecurityQuestion"] != DBNull.Value) ? (string)reader["SecurityQuestion"] : string.Empty;
                    SecurityAnswer = (reader["SecurityAnswer"] != DBNull.Value) ? (string)reader["SecurityAnswer"] : string.Empty;
                    ImagePath = (reader["ImagePath"] != DBNull.Value) ? (string)reader["ImagePath"] : string.Empty;
                    IsActive = (bool)reader["IsActive"];
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

        public static int AddNewUser(int PersonID, string Username, string Password, int Permissions,
            string SecurityQuestion, string SecurityAnswer, string ImagePath, bool IsActive)
        {
            // This function will return the new person id if succeeded and -1 if not
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"if not Exists (select found = 1 from Users where Username = @Username)
begin
insert into Users (PersonID, Username, Password, Permissions, SecurityQuestion, SecurityAnswer, ImagePath, IsActive)
values (@PersonID, @Username, @Password, @Permissions, @SecurityQuestion, @SecurityAnswer, @ImagePath, @IsActive)
select scope_identity()
end";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permissions", Permissions);
            if (string.IsNullOrWhiteSpace(SecurityQuestion))
            {
                command.Parameters.AddWithValue("@SecurityQuestion", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SecurityQuestion", SecurityQuestion);
            }
            if (string.IsNullOrWhiteSpace(SecurityAnswer))
            {
                command.Parameters.AddWithValue("@SecurityAnswer", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SecurityAnswer", SecurityAnswer);
            }
            if (string.IsNullOrWhiteSpace(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    UserID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        public static bool UpdateUser(int UserID, int PersonID, string Username, string Password,
            int Permissions, string SecurityQuestion, string SecurityAnswer, string ImagePath,
            bool IsActive)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Users
set PersonID = @PersonID,
Username = @Username,
Password = @Password,
Permissions = @Permissions,
SecurityQuestion = @SecurityQuestion,
SecurityAnswer = @SecurityAnswer,
ImagePath = @ImagePath,
IsActive = @IsActive
where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permissions", Permissions);
            if (string.IsNullOrWhiteSpace(SecurityQuestion))
            {
                command.Parameters.AddWithValue("@SecurityQuestion", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SecurityQuestion", SecurityQuestion);
            }
            if (string.IsNullOrWhiteSpace(SecurityAnswer))
            {
                command.Parameters.AddWithValue("@SecurityAnswer", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SecurityAnswer", SecurityAnswer);
            }
            if (string.IsNullOrWhiteSpace(ImagePath))
            {
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool DeleteUser(int UserID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool DoesUserExist(int UserID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

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

        public static bool DoesUserExist(string Username)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Users where Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

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

        public static bool DoesUserExist(string Username, string Password)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from Users where Username = @Username and Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            command.Parameters.AddWithValue("@Password", Password);

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

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from UsersDetails_View order by UserID desc";

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

        public static int GetUsersCount()
        {
            int Count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from Users";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int Value))
                {
                    Count = Value;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return Count;
        }

        public static int GetPersonIDByUserID(int UserID)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select PersonID from Users where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    PersonID = ID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

        public static bool ChangePassword(int UserID, string NewPassword)
        {
            int AffectedRows = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update users 
                             set Password = @Password
                             where UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Password", NewPassword);
            command.Parameters.AddWithValue("UserID", UserID);

            try
            {
                connection.Open();

                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (AffectedRows > 0);
        }

    }
}
