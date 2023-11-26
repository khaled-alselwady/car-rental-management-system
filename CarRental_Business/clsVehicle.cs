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

        public int? VehicleID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int SubModelID { get; set; }
        public int BodyID { get; set; }
        public string VehicleName { get; set; }
        public string PlateNumber { get; set; }
        public short Year { get; set; }
        public int DriveTypeID { get; set; }
        public string Engine { get; set; }
        public int FuelTypeID { get; set; }
        public byte NumberDoors { get; set; }
        public int Mileage { get; set; }
        public float RentalPricePerDay { get; set; }
        public bool IsAvailableForRent { get; set; }

        public clsMake MakeInfo { get; set; }
        public clsModel ModelInfo { get; set; }
        public clsSubModel SubModelInfo { get; set; }
        public clsBody BodyInfo { get; set; }
        public clsDriveType DriverTypeInfo { get; set; }
        public clsFuelType FuelTypeInfo { get; set; }

        public clsVehicle()
        {
            this.VehicleID = null;
            this.MakeID = -1;
            this.ModelID = -1;
            this.SubModelID = -1;
            this.BodyID = -1;
            this.VehicleName = string.Empty;
            this.PlateNumber = string.Empty;
            this.Year = -1;
            this.DriveTypeID = -1;
            this.Engine = string.Empty;
            this.FuelTypeID = -1;
            this.NumberDoors = 0;
            this.Mileage = -1;
            this.RentalPricePerDay = -1f;
            this.IsAvailableForRent = false;

            Mode = enMode.AddNew;
        }

        private clsVehicle(int? VehicleID, int MakeID, int ModelID, int SubModelID, int BodyID,
            string VehicleName, string PlateNumber, short Year, int DriveTypeID, string Engine,
            int FuelTypeID, byte NumberDoors, int Mileage, float RentalPricePerDay,
            bool IsAvailableForRent)
        {
            this.VehicleID = VehicleID;
            this.MakeID = MakeID;
            this.ModelID = ModelID;
            this.SubModelID = SubModelID;
            this.BodyID = BodyID;
            this.VehicleName = VehicleName;
            this.PlateNumber = PlateNumber;
            this.Year = Year;
            this.DriveTypeID = DriveTypeID;
            this.Engine = Engine;
            this.FuelTypeID = FuelTypeID;
            this.NumberDoors = NumberDoors;
            this.Mileage = Mileage;
            this.RentalPricePerDay = RentalPricePerDay;
            this.IsAvailableForRent = IsAvailableForRent;

            this.MakeInfo = clsMake.Find(MakeID);
            this.ModelInfo = clsModel.Find(ModelID);
            this.SubModelInfo = clsSubModel.Find(SubModelID);
            this.BodyInfo = clsBody.Find(BodyID);
            this.DriverTypeInfo = clsDriveType.Find(DriveTypeID);
            this.FuelTypeInfo = clsFuelType.Find(FuelTypeID);

            Mode = enMode.Update;
        }

        private bool _AddNewVehicle()
        {
            this.VehicleID = clsVehicleData.AddNewVehicle(this.MakeID, this.ModelID, this.SubModelID,
                this.BodyID, this.VehicleName, this.PlateNumber, this.Year, this.DriveTypeID,
                this.Engine, this.FuelTypeID, this.NumberDoors, this.Mileage, this.RentalPricePerDay,
                this.IsAvailableForRent);

            return (this.VehicleID.HasValue);
        }

        private bool _UpdateVehicle()
        {
            return clsVehicleData.UpdateVehicle(this.VehicleID, this.MakeID, this.ModelID,
                this.SubModelID, this.BodyID, this.VehicleName, this.PlateNumber, this.Year,
                this.DriveTypeID, this.Engine, this.FuelTypeID, this.NumberDoors, this.Mileage,
                this.RentalPricePerDay, this.IsAvailableForRent);
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

        public static clsVehicle Find(int? VehicleID)
        {
            int MakeID = -1;
            int ModelID = -1;
            int SubModelID = -1;
            int BodyID = -1;
            string VehicleName = string.Empty;
            string PlateNumber = string.Empty;
            short Year = -1;
            int DriveTypeID = -1;
            string Engine = string.Empty;
            int FuelTypeID = -1;
            byte NumberDoors = 0;
            int Mileage = -1;
            float RentalPricePerDay = -1f;
            bool IsAvailableForRent = false;

            bool IsFound = clsVehicleData.GetVehicleInfoByID(VehicleID, ref MakeID, ref ModelID,
                ref SubModelID, ref BodyID, ref VehicleName, ref PlateNumber, ref Year,
                ref DriveTypeID, ref Engine, ref FuelTypeID, ref NumberDoors, ref Mileage,
                ref RentalPricePerDay, ref IsAvailableForRent);

            if (IsFound)
            {
                return new clsVehicle(VehicleID, MakeID, ModelID, SubModelID, BodyID, VehicleName,
                    PlateNumber, Year, DriveTypeID, Engine, FuelTypeID, NumberDoors, Mileage,
                    RentalPricePerDay, IsAvailableForRent);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteVehicle(int? VehicleID)
        {
            return clsVehicleData.DeleteVehicle(VehicleID);
        }

        public static bool DoesVehicleExist(int? VehicleID)
        {
            return clsVehicleData.DoesVehicleExist(VehicleID);
        }

        public static bool DoesPlateNumberExist(string PlateNumber)
        {
            return clsVehicleData.DoesPlateNumberExist(PlateNumber);
        }

        public static DataTable GetAllVehicles()
        {
            return clsVehicleData.GetAllVehicles();
        }

        public static int GetVehiclesCount()
        {
            return clsVehicleData.GetVehiclesCount();
        }

        public int? Maintenance(string Description, DateTime MaintenanceDate, float Cost)
        {        
            // this method will add Maintenance record to DB and return MaintenanceID

            clsMaintenance Maintenance = new clsMaintenance();

            Maintenance.VehicleID = this.VehicleID;
            Maintenance.Description = Description;
            Maintenance.MaintenanceDate = MaintenanceDate;
            Maintenance.Cost = Cost;

            if (!Maintenance.Save())
            {
                return null;
            }

            return Maintenance.MaintenanceID;
        }

    }
}
