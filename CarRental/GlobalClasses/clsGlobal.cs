using CarRental_Business;
using Microsoft.Win32;
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
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\CarRental";

            string UsernameName = "Username";
            string UsernameData = Username;

            string PasswordName = "Password";
            string PasswordData = Password;

            try
            {
                // Write the value to the Registry
                Registry.SetValue(keyPath, UsernameName, UsernameData, RegistryValueKind.String);
                Registry.SetValue(keyPath, PasswordName, PasswordData, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An Error occurred: {ex.Message}");
                return false;
            }
        }

        public static bool RemoveStoredCredential()
        {
            string keyPath = @"SOFTWARE\CarRental";

            string UsernameName = "Username";
            string PasswordName = "Password";

            try
            {
                // Open the registry key in read/write mode with explicit registry view
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            // Delete the specified value
                            key.DeleteValue(UsernameName);
                            key.DeleteValue(PasswordName);

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("UnauthorizedAccessException: Run the program with" +
                    " administrative privileges.", "Access Denied",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\CarRental";

            string UsernameName = "Username";
            string PasswordName = "Password";

            try
            {
                // Read the value from the Registry
                Username = Registry.GetValue(keyPath, UsernameName, null) as string;
                Password = Registry.GetValue(keyPath, PasswordName, null) as string;

               return true;
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
