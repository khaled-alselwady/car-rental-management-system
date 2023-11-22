using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarRental_Business
{
    public class clsBody
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int BodyID { get; set; }
        public string BodyName { get; set; }

        public clsBody()
        {
            this.BodyID = -1;
            this.BodyName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsBody(int BodyID, string BodyName)
        {
            this.BodyID = BodyID;
            this.BodyName = BodyName;

            Mode = enMode.Update;
        }

        private bool _AddNewBody()
        {
            this.BodyID = clsBodyData.AddNewBody(this.BodyName);

            return (this.BodyID != -1);
        }

        private bool _UpdateBody()
        {
            return clsBodyData.UpdateBody(this.BodyID, this.BodyName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewBody())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBody();
            }

            return false;
        }

        public static clsBody Find(int BodyID)
        {
            string BodyName = string.Empty;

            bool IsFound = clsBodyData.GetBodyInfoByID(BodyID, ref BodyName);

            if (IsFound)
            {
                return new clsBody(BodyID, BodyName);
            }
            else
            {
                return null;
            }
        }

        public static clsBody Find(string BodyName)
        {
            int BodyID = -1;

            bool IsFound = clsBodyData.GetBodyInfoByName(BodyName, ref BodyID);

            if (IsFound)
            {
                return new clsBody(BodyID, BodyName);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteBody(int BodyID)
        {
            return clsBodyData.DeleteBody(BodyID);
        }

        public static bool DoesBodyExist(int BodyID)
        {
            return clsBodyData.DoesBodyExist(BodyID);
        }

        public static DataTable GetAllBodies()
        {
            return clsBodyData.GetAllBodies();
        }

        public static DataTable GetAllBodiesName()
        {
            return clsBodyData.GetAllBodiesName();
        }

    }
}
