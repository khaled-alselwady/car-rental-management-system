using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsMaintenance
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int MaintenanceID { get; set; }
        public int VehicleID { get; set; }
        public string Description { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public decimal Cost { get; set; }

        public clsMaintenance()
        {
            this.MaintenanceID = -1;
            this.VehicleID = -1;
            this.Description = string.Empty;
            this.MaintenanceDate = DateTime.Now;
            this.Cost = -1M;

            Mode = enMode.AddNew;
        }

        private clsMaintenance(int MaintenanceID, int VehicleID, string Description,
            DateTime MaintenanceDate, decimal Cost)
        {
            this.MaintenanceID = MaintenanceID;
            this.VehicleID = VehicleID;
            this.Description = Description;
            this.MaintenanceDate = MaintenanceDate;
            this.Cost = Cost;

            Mode = enMode.Update;
        }

        private bool _AddNewMaintenance()
        {
            this.MaintenanceID = clsMaintenanceData.AddNewMaintenance(this.VehicleID, this.Description, this.MaintenanceDate, this.Cost);

            return (this.MaintenanceID != -1);
        }

        private bool _UpdateMaintenance()
        {
            return clsMaintenanceData.UpdateMaintenance(this.MaintenanceID, this.VehicleID, this.Description, this.MaintenanceDate, this.Cost);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMaintenance())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMaintenance();
            }

            return false;
        }

        public static clsMaintenance Find(int MaintenanceID)
        {
            int VehicleID = -1;
            string Description = string.Empty;
            DateTime MaintenanceDate = DateTime.Now;
            decimal Cost = -1M;

            bool IsFound = clsMaintenanceData.GetMaintenanceInfoByID(MaintenanceID, ref VehicleID, ref Description, ref MaintenanceDate, ref Cost);

            if (IsFound)
            {
                return new clsMaintenance(MaintenanceID, VehicleID, Description, MaintenanceDate, Cost);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteMaintenance(int MaintenanceID)
        {
            return clsMaintenanceData.DeleteMaintenance(MaintenanceID);
        }

        public static bool DoesMaintenanceExist(int MaintenanceID)
        {
            return clsMaintenanceData.DoesMaintenanceExist(MaintenanceID);
        }

        public static DataTable GetAllMaintenance()
        {
            return clsMaintenanceData.GetAllMaintenance();
        }
    }
}
