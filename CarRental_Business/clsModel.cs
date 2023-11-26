using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsModel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ModelID { get; set; }
        public int MakeID { get; set; }
        public string ModelName { get; set; }

        public clsModel()
        {
            this.ModelID = null;
            this.MakeID = -1;
            this.ModelName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsModel(int? ModelID, int MakeID, string ModelName)
        {
            this.ModelID = ModelID;
            this.MakeID = MakeID;
            this.ModelName = ModelName;

            Mode = enMode.Update;
        }

        private bool _AddNewModel()
        {
            this.ModelID = clsModelData.AddNewModel(this.MakeID, this.ModelName);

            return (this.ModelID.HasValue);
        }

        private bool _UpdateModel()
        {
            return clsModelData.UpdateModel(this.ModelID, this.MakeID, this.ModelName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewModel())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateModel();
            }

            return false;
        }

        public static clsModel Find(int? ModelID)
        {
            int MakeID = -1;
            string ModelName = string.Empty;

            bool IsFound = clsModelData.GetModelInfoByID(ModelID, ref MakeID, ref ModelName);

            if (IsFound)
            {
                return new clsModel(ModelID, MakeID, ModelName);
            }
            else
            {
                return null;
            }
        }

        public static clsModel Find(string ModelName)
        {
            int MakeID = -1;
            int? ModelID = null;

            bool IsFound = clsModelData.GetModelInfoByName(ModelName, ref ModelID, ref MakeID);

            if (IsFound)
            {
                return new clsModel(ModelID, MakeID, ModelName);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteModel(int? ModelID)
        {
            return clsModelData.DeleteModel(ModelID);
        }

        public static bool DoesModelExist(int? ModelID)
        {
            return clsModelData.DoesModelExist(ModelID);
        }

        public static DataTable GetAllModels()
        {
            return clsModelData.GetAllModels();
        }

        public static DataTable GetAllModelsName()
        {
            return clsModelData.GetAllModelsName();
        }
    }
}
