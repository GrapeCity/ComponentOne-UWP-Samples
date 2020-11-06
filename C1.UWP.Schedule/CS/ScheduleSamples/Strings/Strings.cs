using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace ScheduleSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("ScheduleSamplesLib/Resources");

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString("UniqueIdItemsArgumentException");
            }
        }

        public static string SessionStateKeyErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateKeyErrorMessage");
            }
        }

        public static string SessionStateErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateErrorMessage");
            }
        }

        public static string SuspensionManagerErrorMessage
        {
            get
            {
                return _loader.GetString("SuspensionManagerErrorMessage");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string DefaultName
        {
            get
            {
                return _loader.GetString("DefaultName");
            }
        }

        public static string DefaultTitle
        {
            get
            {
                return _loader.GetString("DefaultTitle");
            }
        }

        public static string DefaultDescription
        {
            get
            {
                return _loader.GetString("DefaultDescription");
            }
        }

        public static string BindingName
        {
            get
            {
                return _loader.GetString("BindingName");
            }
        }

        public static string BindingTitle
        {
            get
            {
                return _loader.GetString("BindingTitle");
            }
        }

        public static string BindingDescription
        {
            get
            {
                return _loader.GetString("BindingDescription");
            }
        }

        public static string SaveName
        {
            get
            {
                return _loader.GetString("SaveName");
            }
        }

        public static string SaveTitle
        {
            get
            {
                return _loader.GetString("SaveTitle");
            }
        }

        public static string SaveDescription
        {
            get
            {
                return _loader.GetString("SaveDescription");
            }
        }

        public static string AppointmentSubject
        {
            get
            {
                return _loader.GetString("AppointmentSubject");
            }
        }

        public static string MonthView
        {
            get
            {
                return _loader.GetString("MonthView");
            }
        }

        public static string DayView
        {
            get
            {
                return _loader.GetString("DayView");
            }
        }

        public static string HolidaySubject
        {
            get
            {
                return _loader.GetString("HolidaySubject");
            }
        }

        public static string ExportFileName
        {
            get
            {
                return _loader.GetString("ExportFileName");
            }
        }

        public static string ImportFileName
        {
            get
            {
                return _loader.GetString("ImportFileName");
            }
        }

        public static string RelayCommandArgumentNullException
        {
            get
            {
                return _loader.GetString("RelayCommandArgumentNullException");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string Day_Text
        {
            get
            {
                return _loader.GetString("Day_Text");
            }
        }

        public static string Export_Content
        {
            get
            {
                return _loader.GetString("Export_Content");
            }
        }

        public static string Import_Content
        {
            get
            {
                return _loader.GetString("Import_Content");
            }
        }

        public static string Month_Text
        {
            get
            {
                return _loader.GetString("Month_Text");
            }
        }

        public static string New_Label
        {
            get
            {
                return _loader.GetString("New_Label");
            }
        }

        public static string Today_Label
        {
            get
            {
                return _loader.GetString("Today_Label");
            }
        }

        public static string View_Label
        {
            get
            {
                return _loader.GetString("View_Label");
            }
        }

        public static string Week_Text
        {
            get
            {
                return _loader.GetString("Week_Text");
            }
        }

        public static string WorkWeek_Text
        {
            get
            {
                return _loader.GetString("WorkWeek_Text");
            }
        }

        public static string Cancel_Label
        {
            get
            {
                return _loader.GetString("Cancel_Label");
            }
        }

        public static string Save_Label
        {
            get
            {
                return _loader.GetString("Save_Label");
            }
        }

        public static string Back_Label
        {
            get
            {
                return _loader.GetString("Back_Label");
            }
        }
    }
}
