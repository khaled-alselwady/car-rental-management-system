using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsTransactionData
    {
        public static bool GetTransactionInfoByID(int TransactionID, ref int BookingID,
            ref int ReturnID, ref string PaymentDetails, ref decimal PaidInitialTotalDueAmount,
            ref decimal ActualTotalDueAmount, ref decimal TotalRemaining,
            ref decimal TotalRefundedAmount, ref DateTime TransactionDate,
            ref DateTime UpdatedTransactionDate)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from RentalTransaction where TransactionID = @TransactionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    BookingID = (int)reader["BookingID"];
                    ReturnID = (reader["ReturnID"] != DBNull.Value) ? (int)reader["ReturnID"] : 0;
                    PaymentDetails = (string)reader["PaymentDetails"];
                    PaidInitialTotalDueAmount = (decimal)reader["PaidInitialTotalDueAmount"];
                    ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (decimal)reader["ActualTotalDueAmount"] : 0M;
                    TotalRemaining = (reader["TotalRemaining"] != DBNull.Value) ? (decimal)reader["TotalRemaining"] : 0M;
                    TotalRefundedAmount = (reader["TotalRefundedAmount"] != DBNull.Value) ? (decimal)reader["TotalRefundedAmount"] : 0M;
                    TransactionDate = (DateTime)reader["TransactionDate"];
                    UpdatedTransactionDate = (reader["UpdatedTransactionDate"] != DBNull.Value) ? (DateTime)reader["UpdatedTransactionDate"] : DateTime.Now;
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

        public static int AddNewTransaction(int BookingID, int ReturnID, string PaymentDetails,
            decimal PaidInitialTotalDueAmount, decimal ActualTotalDueAmount,
            decimal TotalRemaining, decimal TotalRefundedAmount, DateTime TransactionDate, 
            DateTime UpdatedTransactionDate)
        {
            // This function will return the new person id if succeeded and -1 if not
            int TransactionID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into RentalTransaction (BookingID, ReturnID, PaymentDetails, PaidInitialTotalDueAmount, ActualTotalDueAmount, TotalRemaining, TotalRefundedAmount, TransactionDate, UpdatedTransactionDate)
values (@BookingID, @ReturnID, @PaymentDetails, @PaidInitialTotalDueAmount, @ActualTotalDueAmount, @TotalRemaining, @TotalRefundedAmount, @TransactionDate, @UpdatedTransactionDate)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BookingID", BookingID);
            if (ReturnID <= 0)
            {
                command.Parameters.AddWithValue("@ReturnID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReturnID", ReturnID);
            }
            command.Parameters.AddWithValue("@PaymentDetails", PaymentDetails);
            command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", PaidInitialTotalDueAmount);
            if (ActualTotalDueAmount <= 0)
            {
                command.Parameters.AddWithValue("@ActualTotalDueAmount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
            }
            if (TotalRemaining <= 0)
            {
                command.Parameters.AddWithValue("@TotalRemaining", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@TotalRemaining", TotalRemaining);
            }
            if (TotalRefundedAmount <= 0)
            {
                command.Parameters.AddWithValue("@TotalRefundedAmount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@TotalRefundedAmount", TotalRefundedAmount);
            }
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
            if (UpdatedTransactionDate == DateTime.Now)
            {
                command.Parameters.AddWithValue("@UpdatedTransactionDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@UpdatedTransactionDate", UpdatedTransactionDate);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    TransactionID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return TransactionID;
        }

        public static bool UpdateTransaction(int TransactionID, int BookingID, int ReturnID,
            string PaymentDetails, decimal PaidInitialTotalDueAmount, decimal ActualTotalDueAmount,
            decimal TotalRemaining, decimal TotalRefundedAmount, DateTime TransactionDate,
            DateTime UpdatedTransactionDate)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update RentalTransaction
set BookingID = @BookingID,
ReturnID = @ReturnID,
PaymentDetails = @PaymentDetails,
PaidInitialTotalDueAmount = @PaidInitialTotalDueAmount,
ActualTotalDueAmount = @ActualTotalDueAmount,
TotalRemaining = @TotalRemaining,
TotalRefundedAmount = @TotalRefundedAmount,
TransactionDate = @TransactionDate,
UpdatedTransactionDate = @UpdatedTransactionDate
where TransactionID = @TransactionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);
            command.Parameters.AddWithValue("@BookingID", BookingID);
            if (ReturnID <= 0)
            {
                command.Parameters.AddWithValue("@ReturnID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ReturnID", ReturnID);
            }
            command.Parameters.AddWithValue("@PaymentDetails", PaymentDetails);
            command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", PaidInitialTotalDueAmount);
            if (ActualTotalDueAmount <= 0)
            {
                command.Parameters.AddWithValue("@ActualTotalDueAmount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
            }
            if (TotalRemaining <= 0)
            {
                command.Parameters.AddWithValue("@TotalRemaining", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@TotalRemaining", TotalRemaining);
            }
            if (TotalRefundedAmount <= 0)
            {
                command.Parameters.AddWithValue("@TotalRefundedAmount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@TotalRefundedAmount", TotalRefundedAmount);
            }
            command.Parameters.AddWithValue("@TransactionDate", TransactionDate);
            if (UpdatedTransactionDate == DateTime.Now)
            {
                command.Parameters.AddWithValue("@UpdatedTransactionDate", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@UpdatedTransactionDate", UpdatedTransactionDate);
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

        public static bool DeleteTransaction(int TransactionID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete RentalTransaction where TransactionID = @TransactionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);

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

        public static bool DoesTransactionExist(int TransactionID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from RentalTransaction where TransactionID = @TransactionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransactionID", TransactionID);

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

        public static DataTable GetAllRentalTransaction()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from RentalTransaction";

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
