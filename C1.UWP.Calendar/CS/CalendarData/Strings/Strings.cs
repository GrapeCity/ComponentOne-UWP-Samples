using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace CalendarData
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("CalendarDataLib/Resources");

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString("UniqueIdItemsArgumentException");
            }
        }

        public static string SessionStateErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateErrorMessage");
            }
        }

        public static string SessionStateKeyErrorMessage
        {
            get
            {
                return _loader.GetString("SessionStateKeyErrorMessage");
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

        public static string CalendarDataTitle
        {
            get
            {
                return _loader.GetString("CalendarDataTitle");
            }
        }

        public static string CalendarDatatDescription
        {
            get
            {
                return _loader.GetString("CalendarDatatDescription");
            }
        }

        public static string CalendarDataName
        {
            get
            {
                return _loader.GetString("CalendarDataName");
            }
        }

        public static string AppointmentSubject
        {
            get
            {
                return _loader.GetString("AppointmentSubject");
            }
        }

        public static string DeviceAppointmentSubject
        {
            get
            {
                return _loader.GetString("DeviceAppointmentSubject");
            }
        }

        public static string Message
        {
            get
            {
                return _loader.GetString("Message");
            }
        }

        public static string EmulatorAppointmentSubject
        {
            get
            {
                return _loader.GetString("EmulatorAppointmentSubject");
            }
        }

        public static string DialogMessage
        {
            get
            {
                return _loader.GetString("DialogMessage");
            }
        }

        public static string Alter_Label
        {
            get
            {
                return _loader.GetString("Alter_Label");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string Help_Label
        {
            get
            {
                return _loader.GetString("Help_Label");
            }
        }

        public static string Today_Label
        {
            get
            {
                return _loader.GetString("Today_Label");
            }
        }
    }
}
