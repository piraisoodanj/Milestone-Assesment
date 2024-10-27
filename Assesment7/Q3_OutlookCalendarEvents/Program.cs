using Microsoft.Office.Interop.Outlook;
using System.Runtime.InteropServices;
namespace Part3_OutlookCalendarEvents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application outlookApp = null;
            NameSpace outlookNamespace = null;
            MAPIFolder calendarFolder = null;

            try
            {
                //Initialize Outlook application
                outlookApp = new Application();
                outlookNamespace = outlookApp.GetNamespace("MAPI");

                //Get the default calendar folder
                calendarFolder = outlookNamespace.GetDefaultFolder(OlDefaultFolders.olFolderCalendar);
                Items calendarItems = calendarFolder.Items;

                //Define the time frame for upcoming events
                DateTime startTime = DateTime.Now;
                DateTime endTime = startTime.AddDays(30); //Get events for the next 30 days

                //Filter items based on the start and end time
                calendarItems.IncludeRecurrences = true;
                calendarItems.Sort("[Start]");

                //Create a filter for upcoming events
                string filter = $"[Start] >= '{startTime.ToString("g")}' AND [Start] <= '{endTime.ToString("g")}'";
                Items filteredItems = calendarItems.Restrict(filter);

                //Display the events
                Console.WriteLine("Upcoming Events:");

                if (filteredItems.Count > 0)
                {
                    foreach (AppointmentItem item in filteredItems)
                    {
                        if (item is AppointmentItem)
                        {
                            Console.WriteLine($"- {item.Subject}: {item.Start.ToString("yyyy-MM-dd hh:mm tt")}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No upcoming events found.");
                }
            }
            catch (COMException comEx)
            {
                Console.WriteLine($"COM Exception: {comEx.Message}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Permission denied. Please ensure you have access to ");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                //Cleanup: Release COM objects
                if (calendarFolder != null)
                {
                    Marshal.ReleaseComObject(calendarFolder);
                }
                if (outlookNamespace != null)
                {
                    Marshal.ReleaseComObject(outlookNamespace);
                }
                if (outlookApp != null)
                {
                    Marshal.ReleaseComObject(outlookApp);
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}
