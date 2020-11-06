using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace CalendarSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("CalendarSamplesLib/Resources");

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

        public static string CalendarSamplesDefaultTitle
        {
            get
            {
                return _loader.GetString("CalendarSamplesDefaultTitle");
            }
        }

        public static string CalendarSamplesDefaultDescription
        {
            get
            {
                return _loader.GetString("CalendarSamplesDefaultDescription");
            }
        }

        public static string CalendarSamplesDefaultName
        {
            get
            {
                return _loader.GetString("CalendarSamplesDefaultName");
            }
        }

        public static string CalendarSamplesBoldedDaysTitle
        {
            get
            {
                return _loader.GetString("CalendarSamplesBoldedDaysTitle");
            }
        }

        public static string CalendarSamplesBoldedDaysDescription
        {
            get
            {
                return _loader.GetString("CalendarSamplesBoldedDaysDescription");
            }
        }

        public static string CalendarSamplesBoldedDaysName
        {
            get
            {
                return _loader.GetString("CalendarSamplesBoldedDaysName");
            }
        }

        public static string CalendarSamplesCustomDaysTitle
        {
            get
            {
                return _loader.GetString("CalendarSamplesCustomDaysTitle");
            }
        }

        public static string CalendarSamplesCustomDaysDescription
        {
            get
            {
                return _loader.GetString("CalendarSamplesCustomDaysDescription");
            }
        }

        public static string CalendarSamplesCustomDaysName
        {
            get
            {
                return _loader.GetString("CalendarSamplesCustomDaysName");
            }
        }

        public static string CalendarSamplesCustomDataTitle
        {
            get
            {
                return _loader.GetString("CalendarSamplesCustomDataTitle");
            }
        }

        public static string CalendarSamplesCustomDataDescription
        {
            get
            {
                return _loader.GetString("CalendarSamplesCustomDataDescription");
            }
        }

        public static string CalendarSamplesCustomDataName
        {
            get
            {
                return _loader.GetString("CalendarSamplesCustomDataName");
            }
        }

        public static string AppointmentSubject
        {
            get
            {
                return _loader.GetString("AppointmentSubject");
            }
        }

        public static string BoldedDay1
        {
            get
            {
                return _loader.GetString("BoldedDay1");
            }
        }

        public static string BoldedDay2
        {
            get
            {
                return _loader.GetString("BoldedDay2");
            }
        }

        public static string BoldedDay3
        {
            get
            {
                return _loader.GetString("BoldedDay3");
            }
        }

        public static string BoldedMotherBirthday
        {
            get
            {
                return _loader.GetString("BoldedMotherBirthday");
            }
        }

        public static string BoldedDay4
        {
            get
            {
                return _loader.GetString("BoldedDay4");
            }
        }

        public static string BoldedDay5
        {
            get
            {
                return _loader.GetString("BoldedDay5");
            }
        }

        public static string BoldedDay6
        {
            get
            {
                return _loader.GetString("BoldedDay6");
            }
        }

        public static string NewYearDay
        {
            get
            {
                return _loader.GetString("NewYearDay");
            }
        }

        public static string ChristmasDay
        {
            get
            {
                return _loader.GetString("ChristmasDay");
            }
        }

        public static string ValentineDay
        {
            get
            {
                return _loader.GetString("ValentineDay");
            }
        }

        public static string EarthDay
        {
            get
            {
                return _loader.GetString("EarthDay");
            }
        }

        public static string FlagDay
        {
            get
            {
                return _loader.GetString("FlagDay");
            }
        }

        public static string IndependenceDay
        {
            get
            {
                return _loader.GetString("IndependenceDay");
            }
        }

        public static string HalloweenDay
        {
            get
            {
                return _loader.GetString("HalloweenDay");
            }
        }

        public static string VeteransDay
        {
            get
            {
                return _loader.GetString("VeteransDay");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }
    }
}
