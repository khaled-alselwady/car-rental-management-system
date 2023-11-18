using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsVehicle
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int SubModelID { get; set; }
        public int BodyID { get; set; }
        public string Vehicle_Display_Name { get; set; }
        public short Year { get; set; }
        public int DriveTypeID { get; set; }
        public string Engine { get; set; }
        public short Engine_CC { get; set; }
        public byte Engine_Cylinders { get; set; }
        public decimal Engine_Liter_Display { get; set; }
        public int FuelTypeID { get; set; }
        public byte NumDoors { get; set; }
        public int Mileage { get; set; }
        public bool IsAvailableForRent { get; set; }
        public decimal RentalPricePerDay { get; set; }

        public clsVehicle()
        {
            this.VehicleID = -1;
            this.MakeID = -1;
            this.ModelID = -1;
            this.SubModelID = -1;
            this.BodyID = -1;
            this.Vehicle_Display_Name = string.Empty;
            this.Year = -1;
            this.DriveTypeID = -1;
            this.Engine = string.Empty;
            this.Engine_CC = -1;
            this.Engine_Cylinders = 0;
            this.Engine_Liter_Display = -1M;
            this.FuelTypeID = -1;
            this.NumDoors = 0;
            this.Mileage = -1;
            this.IsAvailableForRent = false;
            this.RentalPricePerDay = -1M;

            Mode = enMode.AddNew;
        }

        private clsVehicle(int VehicleID, int MakeID, int ModelID, int SubModelID, int BodyID,
            string Vehicle_Display_Name, short Year, int DriveTypeID, string Engine,
            short Engine_CC, byte Engine_Cylinders, decimal Engine_Liter_Display,
            int FuelTypeID, byte NumDoors, int Mileage, bool IsAvailableForRent, 
            decimal RentalPricePerDay)
        {
            this.VehicleID = VehicleID;
            this.MakeID = MakeID;
            this.ModelID = ModelID;
            this.SubModelID = SubModelID;
            this.BodyID = BodyID;
            this.Vehicle_Display_Name = Vehicle_Display_Name;
            this.Year = Year;
            this.DriveTypeID = DriveTypeID;
            this.Engine = Engine;
            this.Engine_CC = Engine_CC;
            this.Engine_Cylinders = Engine_Cylinders;
            this.Engine_Liter_Display = Engine_Liter_Display;
            this.FuelTypeID = FuelTypeID;
            this.NumDoors = NumDoors;
            this.Mileage = Mileage;
            this.IsAvailableForRent = IsAvailableForRent;
            this.RentalPricePerDay = RentalPricePerDay;

            Mode = enMode.Update;
        }

        private bool _AddNewVehicle()
        {
            this.VehicleID = clsVehicleData.AddNewVehicle(this.MakeID, this.ModelID, this.SubModelID,
                this.BodyID, this.Vehicle_Display_Name, this.Year, this.DriveTypeID, this.Engine,
                this.Engine_CC, this.Engine_Cylinders, this.Engine_Liter_Display, this.FuelTypeID,
                this.NumDoors, this.Mileage, this.IsAvailableForRent, this.RentalPricePerDay);

            return (this.VehicleID != -1);
        }

        private bool _UpdateVehicle()
        {
            return clsVehicleData.UpdateVehicle(this.VehicleID, this.MakeID, this.ModelID, 
                this.SubModelID, this.BodyID, this.Vehicle_Display_Name, this.Year, this.DriveTypeID,
                this.Engine, this.Engine_CC, this.Engine_Cylinders, this.Engine_Liter_Display,
                this.FuelTypeID, this.NumDoors, this.Mileage, this.IsAvailableForRent,
                this.RentalPricePerDay);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewVehicle())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateVehicle();
            }

            return false;
        }

        public static clsVehicle Find(int VehicleID)
        {
            int MakeID = -1;
            int ModelID = -1;
            int SubModelID = -1;
            int BodyID = -1;
            string Vehicle_Display_Name = string.Empty;
            short Year = -1;
            int DriveTypeID = -1;
            string Engine = string.Empty;
            short Engine_CC = -1;
            byte Engine_Cylinders = 0;
            decimal Engine_Liter_Display = -1M;
            int FuelTypeID = -1;
            byte NumDoors = 0;
            int Mileage = -1;
            bool IsAvailableForRent = false;
            decimal RentalPricePerDay = -1M;

            bool IsFound = clsVehicleData.GetVehicleInfoByID(VehicleID, ref MakeID, ref ModelID,
                ref SubModelID, ref BodyID, ref Vehicle_Display_Name, ref Year, ref DriveTypeID,
                ref Engine, ref Engine_CC, ref Engine_Cylinders, ref Engine_Liter_Display,
                ref FuelTypeID, ref NumDoors, ref Mileage, ref IsAvailableForRent, 
                ref RentalPricePerDay);

            if (IsFound)
            {
                return new clsVehicle(VehicleID, MakeID, ModelID, SubModelID, BodyID, 
                    Vehicle_Display_Name, Year, DriveTypeID, Engine, Engine_CC,
                    Engine_Cylinders, Engine_Liter_Display, FuelTypeID, NumDoors,
                    Mileage, IsAvailableForRent, RentalPricePerDay);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteVehicle(int VehicleID)
        {
            return clsVehicleData.DeleteVehicle(VehicleID);
        }

        public static bool DoesVehicleExist(int VehicleID)
        {
            return clsVehicleData.DoesVehicleExist(VehicleID);
        }

        public static DataTable GetAllVehicleDetails()
        {
            return clsVehicleData.GetAllVehicleDetails();
        }

        public static int GetVehiclesCount()
        {
            return clsVehicleData.GetVehiclesCount();
        }
    }
}
