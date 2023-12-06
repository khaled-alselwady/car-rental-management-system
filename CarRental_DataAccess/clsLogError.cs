using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public static class clsLogError
    {
        public static void LogError(string errorType, Exception ex)
        {
            // Specify the source name for the event log
            string sourceName = "CarRental";

            // Create the event source if it does not exist
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }

            string errorMessage = $"{errorType} in {ex.Source}\n\nException Message:" +
                    $" {ex.Message}\n\nException Type: {ex.GetType().Name}\n\nStack Trace:" +
                    $" {ex.StackTrace}\n\nException Location: {ex.TargetSite}";

            // Log an error event
            EventLog.WriteEntry(sourceName, errorMessage, EventLogEntryType.Error);
        }
    }
}
