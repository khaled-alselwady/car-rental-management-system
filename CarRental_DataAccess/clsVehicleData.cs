using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsVehicleData
    {
        public static bool GetVehicleInfoByID(int VehicleID, ref int MakeID, ref int ModelID,
            ref int SubModelID, ref int BodyID, ref string Vehicle_Display_Name, ref short Year,
            ref int DriveTypeID, ref string Engine, ref short Engine_CC, ref byte Engine_Cylinders,
            ref decimal Engine_Liter_Display, ref int FuelTypeID, ref byte NumDoors,
            ref int Mileage, ref bool IsAvailableForRent, ref decimal RentalPricePerDay)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from VehicleDetails where VehicleID = @VehicleID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    IsFound = true;

                    MakeID = (reader["MakeID"] != DBNull.Value) ? (int)reader["MakeID"] : 0;
                    ModelID = (reader["ModelID"] != DBNull.Value) ? (int)reader["ModelID"] : 0;
                    SubModelID = (reader["SubModelID"] != DBNull.Value) ? (int)reader["SubModelID"] : 0;
                    BodyID = (reader["BodyID"] != DBNull.Value) ? (int)reader["BodyID"] : 0;
                    Vehicle_Display_Name = (reader["Vehicle_Display_Name"] != DBNull.Value) ? (string)reader["Vehicle_Display_Name"] : string.Empty;
                    Year = (reader["Year"] != DBNull.Value) ? (short)reader["Year"] : (short)0;
                    DriveTypeID = (reader["DriveTypeID"] != DBNull.Value) ? (int)reader["DriveTypeID"] : 0;
                    Engine = (reader["Engine"] != DBNull.Value) ? (string)reader["Engine"] : string.Empty;
                    Engine_CC = (reader["Engine_CC"] != DBNull.Value) ? (short)reader["Engine_CC"] : (short)0;
                    Engine_Cylinders = (reader["Engine_Cylinders"] != DBNull.Value) ? (byte)reader["Engine_Cylinders"] : (byte)0;
                    Engine_Liter_Display = (reader["Engine_Liter_Display"] != DBNull.Value) ? (decimal)reader["Engine_Liter_Display"] : 0M;
                    FuelTypeID = (reader["FuelTypeID"] != DBNull.Value) ? (int)reader["FuelTypeID"] : 0;
                    NumDoors = (reader["NumDoors"] != DBNull.Value) ? (byte)reader["NumDoors"] : (byte)0;
                    Mileage = (reader["Mileage"] != DBNull.Value) ? (int)reader["Mileage"] : 0;
                    IsAvailableForRent = (reader["IsAvailableForRent"] != DBNull.Value) ? (bool)reader["IsAvailableForRent"] : false;
                    RentalPricePerDay = (reader["RentalPricePerDay"] != DBNull.Value) ? (decimal)reader["RentalPricePerDay"] : 0M;
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

        public static int AddNewVehicle(int MakeID, int ModelID, int SubModelID, int BodyID, 
            string Vehicle_Display_Name, short Year, int DriveTypeID, string Engine,
            short Engine_CC, byte Engine_Cylinders, decimal Engine_Liter_Display, 
            int FuelTypeID, byte NumDoors, int Mileage, bool IsAvailableForRent, 
            decimal RentalPricePerDay)
        {
            // This function will return the new person id if succeeded and -1 if not
            int VehicleID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into VehicleDetails (MakeID, ModelID, SubModelID, BodyID, Vehicle_Display_Name, Year, DriveTypeID, Engine, Engine_CC, Engine_Cylinders, Engine_Liter_Display, FuelTypeID, NumDoors, Mileage, IsAvailableForRent, RentalPricePerDay)
values (@MakeID, @ModelID, @SubModelID, @BodyID, @Vehicle_Display_Name, @Year, @DriveTypeID, @Engine, @Engine_CC, @Engine_Cylinders, @Engine_Liter_Display, @FuelTypeID, @NumDoors, @Mileage, @IsAvailableForRent, @RentalPricePerDay)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            if (MakeID <= 0)
            {
                command.Parameters.AddWithValue("@MakeID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@MakeID", MakeID);
            }
            if (ModelID <= 0)
            {
                command.Parameters.AddWithValue("@ModelID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ModelID", ModelID);
            }
            if (SubModelID <= 0)
            {
                command.Parameters.AddWithValue("@SubModelID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SubModelID", SubModelID);
            }
            if (BodyID <= 0)
            {
                command.Parameters.AddWithValue("@BodyID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@BodyID", BodyID);
            }
            if (string.IsNullOrWhiteSpace(Vehicle_Display_Name))
            {
                command.Parameters.AddWithValue("@Vehicle_Display_Name", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Vehicle_Display_Name", Vehicle_Display_Name);
            }
            if (Year <= 0)
            {
                command.Parameters.AddWithValue("@Year", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Year", Year);
            }
            if (DriveTypeID <= 0)
            {
                command.Parameters.AddWithValue("@DriveTypeID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@DriveTypeID", DriveTypeID);
            }
            if (string.IsNullOrWhiteSpace(Engine))
            {
                command.Parameters.AddWithValue("@Engine", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Engine", Engine);
            }
            if (Engine_CC <= 0)
            {
                command.Parameters.AddWithValue("@Engine_CC", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Engine_CC", Engine_CC);
            }
            if (Engine_Cylinders <= 0)
            {
                command.Parameters.AddWithValue("@Engine_Cylinders", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Engine_Cylinders", Engine_Cylinders);
            }
            if (Engine_Liter_Display <= 0)
            {
                command.Parameters.AddWithValue("@Engine_Liter_Display", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Engine_Liter_Display", Engine_Liter_Display);
            }
            if (FuelTypeID <= 0)
            {
                command.Parameters.AddWithValue("@FuelTypeID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
            }
            if (NumDoors <= 0)
            {
                command.Parameters.AddWithValue("@NumDoors", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@NumDoors", NumDoors);
            }
            if (Mileage <= 0)
            {
                command.Parameters.AddWithValue("@Mileage", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Mileage", Mileage);
            }
            if (!IsAvailableForRent)
            {
                command.Parameters.AddWithValue("@IsAvailableForRent", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@IsAvailableForRent", IsAvailableForRent);
            }
            if (RentalPricePerDay <= 0)
            {
                command.Parameters.AddWithValue("@RentalPricePerDay", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
            }

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertID))
                {
                    VehicleID = InsertID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return VehicleID;
        }

        public static bool UpdateVehicle(int VehicleID, int MakeID, int ModelID, int SubModelID,
            int BodyID, string Vehicle_Display_Name, short Year, int DriveTypeID, string Engine,
            short Engine_CC, byte Engine_Cylinders, decimal Engine_Liter_Display, int FuelTypeID,
            byte NumDoors, int Mileage, bool IsAvailableForRent, decimal RentalPricePerDay)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update VehicleDetails
set MakeID = @MakeID,
ModelID = @ModelID,
SubModelID = @SubModelID,
BodyID = @BodyID,
Vehicle_Display_Name = @Vehicle_Display_Name,
Year = @Year,
DriveTypeID = @DriveTypeID,
Engine = @Engine,
Engine_CC = @Engine_CC,
Engine_Cylinders = @Engine_Cylinders,
Engine_Liter_Display = @Engine_Liter_Display,
FuelTypeID = @FuelTypeID,
NumDoors = @NumDoors,
Mileage = @Mileage,
IsAvailableForRent = @IsAvailableForRent,
RentalPricePerDay = @RentalPricePerDay
where VehicleID = @VehicleID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            if (MakeID <= 0)
            {
                command.Parameters.AddWithValue("@MakeID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@MakeID", MakeID);
            }
            if (ModelID <= 0)
            {
                command.Parameters.AddWithValue("@ModelID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@ModelID", ModelID);
            }
            if (SubModelID <= 0)
            {
                command.Parameters.AddWithValue("@SubModelID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@SubModelID", SubModelID);
            }
            if (BodyID <= 0)
            {
                command.Parameters.AddWithValue("@BodyID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@BodyID", BodyID);
            }
            if (string.IsNullOrWhiteSpace(Vehicle_Display_Name))
            {
                command.Parameters.AddWithValue("@Vehicle_Display_Name", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Vehicle_Display_Name", Vehicle_Display_Name);
            }
            if (Year <= 0)
            {
                command.Parameters.AddWithValue("@Year", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Year", Year);
            }
            if (DriveTypeID <= 0)
            {
                command.Parameters.AddWithValue("@DriveTypeID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@DriveTypeID", DriveTypeID);
            }
            if (string.IsNullOrWhiteSpace(Engine))
            {
                command.Parameters.AddWithValue("@Engine", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Engine", Engine);
            }
            if (Engine_CC <= 0)
            {
                command.Parameters.AddWithValue("@Engine_CC", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Engine_CC", Engine_CC);
            }
            if (Engine_Cylinders <= 0)
            {
                command.Parameters.AddWithValue("@Engine_Cylinders", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Engine_Cylinders", Engine_Cylinders);
            }
            if (Engine_Liter_Display <= 0)
            {
                command.Parameters.AddWithValue("@Engine_Liter_Display", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Engine_Liter_Display", Engine_Liter_Display);
            }
            if (FuelTypeID <= 0)
            {
                command.Parameters.AddWithValue("@FuelTypeID", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
            }
            if (NumDoors <= 0)
            {
                command.Parameters.AddWithValue("@NumDoors", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@NumDoors", NumDoors);
            }
            if (Mileage <= 0)
            {
                command.Parameters.AddWithValue("@Mileage", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@Mileage", Mileage);
            }
            if (!IsAvailableForRent)
            {
                command.Parameters.AddWithValue("@IsAvailableForRent", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@IsAvailableForRent", IsAvailableForRent);
            }
            if (RentalPricePerDay <= 0)
            {
                command.Parameters.AddWithValue("@RentalPricePerDay", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
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

        public static bool DeleteVehicle(int VehicleID)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"delete VehicleDetails where VehicleID = @VehicleID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);

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

        public static bool DoesVehicleExist(int VehicleID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select found = 1 from VehicleDetails where VehicleID = @VehicleID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);

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

        public static DataTable GetAllVehicleDetails()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from VehicleDetails";

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
