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
        public static bool GetVehicleInfoByID(int? VehicleID, ref int MakeID, ref int ModelID,
            ref int SubModelID, ref int BodyID, ref string VehicleName, ref string PlateNumber,
            ref short Year, ref int DriveTypeID, ref string Engine, ref int FuelTypeID,
            ref byte NumberDoors, ref int Mileage, ref float RentalPricePerDay,
            ref bool IsAvailableForRent)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from Vehicles where VehicleID = @VehicleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
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
                                RentalPricePerDay = Convert.ToSingle(reader["RentalPricePerDay"]);
                                IsAvailableForRent = (bool)reader["IsAvailableForRent"];
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

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static int? AddNewVehicle(int MakeID, int ModelID, int SubModelID, int BodyID,
            string VehicleName, string PlateNumber, short Year, int DriveTypeID, string Engine,
            int FuelTypeID, byte NumberDoors, int Mileage, float RentalPricePerDay,
            bool IsAvailableForRent)
        {
            // This function will return the new person id if succeeded and null if not
            int? VehicleID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into Vehicles (MakeID, ModelID, SubModelID, BodyID, VehicleName, PlateNumber, Year, DriveTypeID, Engine, FuelTypeID, NumberDoors, Mileage, RentalPricePerDay, IsAvailableForRent)
values (@MakeID, @ModelID, @SubModelID, @BodyID, @VehicleName, @PlateNumber, @Year, @DriveTypeID, @Engine, @FuelTypeID, @NumberDoors, @Mileage, @RentalPricePerDay, @IsAvailableForRent)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            VehicleID = InsertID;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return VehicleID;
        }

        public static bool UpdateVehicle(int? VehicleID, int MakeID, int ModelID, int SubModelID,
            int BodyID, string VehicleName, string PlateNumber, short Year, int DriveTypeID,
            string Engine, int FuelTypeID, byte NumberDoors, int Mileage, float RentalPricePerDay,
            bool IsAvailableForRent)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

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

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);
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

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DeleteVehicle(int? VehicleID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete Vehicles where VehicleID = @VehicleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (RowAffected > 0);
        }

        public static bool DoesVehicleExist(int? VehicleID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from Vehicles where VehicleID = @VehicleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);

                        object result = command.ExecuteScalar();

                        IsFound = (result != null);
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static bool DoesPlateNumberExist(string PlateNumber)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT found = 1 FROM Vehicles WHERE PlateNumber = @PlateNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PlateNumber", PlateNumber);

                        object result = command.ExecuteScalar();

                        IsFound = (result != null);
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static DataTable GetAllVehicles()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from VehiclesDetails_View order by VehicleID desc";

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
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return dt;
        }

        public static int GetAllVehiclesCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM Vehicles";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return Count;
        }

        public static bool UpdateMileage(int? VehicleID, int NewMileage)
        {
            int AffectedRows = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"update Vehicles
                                     set Mileage = @NewMileage
                                     where VehicleID = @VehicleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("NewMileage", NewMileage);
                        command.Parameters.AddWithValue("VehicleID", (object)VehicleID ?? DBNull.Value);

                        AffectedRows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (AffectedRows > 0);
        }

        public static bool UpdateAvailableForRent(int? VehicleID, bool IsAvailable)
        {
            int AffectedRows = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"update Vehicles
                                     set IsAvailableForRent = @IsAvailableForRent
                                     where VehicleID = @VehicleID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("IsAvailableForRent", IsAvailable);
                        command.Parameters.AddWithValue("VehicleID", (object)VehicleID ?? DBNull.Value);

                        AffectedRows = command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return (AffectedRows > 0);
        }

        public static int GetAvailableVehiclesCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select count (*) from Vehicles where IsAvailableForRent = 1;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return Count;
        }
    }
}
