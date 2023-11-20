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
            ref int SubModelID, ref int BodyID, ref string VehicleName, ref string PlateNumber,
            ref short Year, ref int DriveTypeID, ref string Engine, ref int FuelTypeID,
            ref byte NumberDoors, ref int Mileage, ref decimal RentalPricePerDay,
            ref bool IsAvailableForRent)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Vehicles where VehicleID = @VehicleID";

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

                    MakeID = (int)reader["MakeID"];
                    ModelID = (int)reader["ModelID"];
                    SubModelID = (int)reader["SubModelID"];
                    BodyID = (int)reader["BodyID"];
                    VehicleName = (string)reader["VehicleName"];
                    PlateNumber = (string)reader["PlateNumber"];
                    Year = (short)reader["Year"];
                    DriveTypeID = (int)reader["DriveTypeID"];
                    Engine = (string)reader["Engine"];
                    FuelTypeID = (int)reader["FuelTypeID"];
                    NumberDoors = (byte)reader["NumberDoors"];
                    Mileage = (int)reader["Mileage"];
                    RentalPricePerDay = (decimal)reader["RentalPricePerDay"];
                    IsAvailableForRent = (bool)reader["IsAvailableForRent"];
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
            string VehicleName, string PlateNumber, short Year, int DriveTypeID, string Engine,
            int FuelTypeID, byte NumberDoors, int Mileage, decimal RentalPricePerDay,
            bool IsAvailableForRent)
        {
            // This function will return the new person id if succeeded and -1 if not
            int VehicleID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Vehicles (MakeID, ModelID, SubModelID, BodyID, VehicleName, PlateNumber, Year, DriveTypeID, Engine, FuelTypeID, NumberDoors, Mileage, RentalPricePerDay, IsAvailableForRent)
values (@MakeID, @ModelID, @SubModelID, @BodyID, @VehicleName, @PlateNumber, @Year, @DriveTypeID, @Engine, @FuelTypeID, @NumberDoors, @Mileage, @RentalPricePerDay, @IsAvailableForRent)
select scope_identity()";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@MakeID", MakeID);
            command.Parameters.AddWithValue("@ModelID", ModelID);
            command.Parameters.AddWithValue("@SubModelID", SubModelID);
            command.Parameters.AddWithValue("@BodyID", BodyID);
            command.Parameters.AddWithValue("@VehicleName", VehicleName);
            command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
            command.Parameters.AddWithValue("@Year", Year);
            command.Parameters.AddWithValue("@DriveTypeID", DriveTypeID);
            command.Parameters.AddWithValue("@Engine", Engine);
            command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
            command.Parameters.AddWithValue("@NumberDoors", NumberDoors);
            command.Parameters.AddWithValue("@Mileage", Mileage);
            command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
            command.Parameters.AddWithValue("@IsAvailableForRent", IsAvailableForRent);

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
            int BodyID, string VehicleName, string PlateNumber, short Year, int DriveTypeID,
            string Engine, int FuelTypeID, byte NumberDoors, int Mileage, decimal RentalPricePerDay, 
            bool IsAvailableForRent)
        {
            int RowAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Vehicles
set MakeID = @MakeID,
ModelID = @ModelID,
SubModelID = @SubModelID,
BodyID = @BodyID,
VehicleName = @VehicleName,
PlateNumber = @PlateNumber,
Year = @Year,
DriveTypeID = @DriveTypeID,
Engine = @Engine,
FuelTypeID = @FuelTypeID,
NumberDoors = @NumberDoors,
Mileage = @Mileage,
RentalPricePerDay = @RentalPricePerDay,
IsAvailableForRent = @IsAvailableForRent
where VehicleID = @VehicleID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VehicleID", VehicleID);
            command.Parameters.AddWithValue("@MakeID", MakeID);
            command.Parameters.AddWithValue("@ModelID", ModelID);
            command.Parameters.AddWithValue("@SubModelID", SubModelID);
            command.Parameters.AddWithValue("@BodyID", BodyID);
            command.Parameters.AddWithValue("@VehicleName", VehicleName);
            command.Parameters.AddWithValue("@PlateNumber", PlateNumber);
            command.Parameters.AddWithValue("@Year", Year);
            command.Parameters.AddWithValue("@DriveTypeID", DriveTypeID);
            command.Parameters.AddWithValue("@Engine", Engine);
            command.Parameters.AddWithValue("@FuelTypeID", FuelTypeID);
            command.Parameters.AddWithValue("@NumberDoors", NumberDoors);
            command.Parameters.AddWithValue("@Mileage", Mileage);
            command.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
            command.Parameters.AddWithValue("@IsAvailableForRent", IsAvailableForRent);

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

            string query = @"delete Vehicles where VehicleID = @VehicleID";

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

            string query = @"select found = 1 from Vehicles where VehicleID = @VehicleID";

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

        public static DataTable GetAllVehicles()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from Vehicles";

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

        public static int GetVehiclesCount()
        {
            int Count = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select count(*) from Vehicles";

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
    }
}
