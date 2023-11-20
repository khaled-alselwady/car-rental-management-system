using CarRental_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.GlobalClasses
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                //this will get the current project directory folder.
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();


                // Define the path to the text file where you want to save the data
                string filePath = currentDirectory + "\\data.txt";

                //in case the username is empty, delete the file
                if (Username == "" && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                // make the line that I want to save in the file.
                string Data = Username + "#//#" + Password;

                File.WriteAllText(filePath, Data);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath))
                {
                    string Data = File.ReadAllText(filePath);

                    string[] arrData = Data.Split(new string[] { "#//#" }, StringSplitOptions.None);

                    if (arrData.Length >= 2)
                    {
                        Username = arrData[0];
                        Password = arrData[1];
                    }

                    return (Username != "");
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool CheckAccessDenied(clsUser.enPermissions enPermissions)
        {
            if (CurrentUser.Permissions == (int)clsUser.enPermissions.All)
                return true;


            if (((int)enPermissions & CurrentUser.Permissions) == (int)enPermissions)
                return true;

            else
                return false;

        }
    }
}
