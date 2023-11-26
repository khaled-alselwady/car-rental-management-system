using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsSubModel
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? SubModelID { get; set; }
        public int ModelID { get; set; }
        public string SubModelName { get; set; }

        public clsSubModel()
        {
            this.SubModelID = null;
            this.ModelID = -1;
            this.SubModelName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsSubModel(int? SubModelID, int ModelID, string SubModelName)
        {
            this.SubModelID = SubModelID;
            this.ModelID = ModelID;
            this.SubModelName = SubModelName;

            Mode = enMode.Update;
        }

        private bool _AddNewSubModel()
        {
            this.SubModelID = clsSubModelData.AddNewSubModel(this.ModelID, this.SubModelName);

            return (this.SubModelID.HasValue);
        }

        private bool _UpdateSubModel()
        {
            return clsSubModelData.UpdateSubModel(this.SubModelID, this.ModelID, this.SubModelName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewSubModel())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateSubModel();
            }

            return false;
        }

        public static clsSubModel Find(int? SubModelID)
        {
            int ModelID = -1;
            string SubModelName = string.Empty;

            bool IsFound = clsSubModelData.GetSubModelInfoByID(SubModelID, ref ModelID,
                ref SubModelName);

            if (IsFound)
            {
                return new clsSubModel(SubModelID, ModelID, SubModelName);
            }
            else
            {
                return null;
            }
        }

        public static clsSubModel Find(string SubModelName)
        {
            int? SubModelID = null;
            int ModelID = -1;

            bool IsFound = clsSubModelData.GetSubModelInfoByName(SubModelName, ref SubModelID,
                ref ModelID);

            if (IsFound)
            {
                return new clsSubModel(SubModelID, ModelID, SubModelName);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteSubModel(int? SubModelID)
        {
            return clsSubModelData.DeleteSubModel(SubModelID);
        }

        public static bool DoesSubModelExist(int? SubModelID)
        {
            return clsSubModelData.DoesSubModelExist(SubModelID);
        }

        public static DataTable GetAllSubModels()
        {
            return clsSubModelData.GetAllSubModels();
        }

        public static DataTable GetAllSubModelsName()
        {
            return clsSubModelData.GetAllSubModelsName();
        }
    }
}
