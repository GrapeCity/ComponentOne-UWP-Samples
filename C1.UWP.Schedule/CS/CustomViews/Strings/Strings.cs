using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace CustomViews
{
    public class Strings
    {
        private static ResourceLoader _loader;

        private static ResourceLoader Loader
        {
            get
            {
                if (_loader == null)
                {
                    _loader = ResourceLoader.GetForCurrentView("Resources");
                }
                return _loader;
            }
        }

        public static string AppointmentSubject
        {
            get
            {
                return Loader.GetString("AppointmentSubject");
            }
        }

        public static string MonthView
        {
            get
            {
                return Loader.GetString("MonthView");
            }
        }

        public static string DayView
        {
            get
            {
                return Loader.GetString("DayView");
            }
        }

        public static string HolidaySubject
        {
            get
            {
                return Loader.GetString("HolidaySubject");
            }
        }


        public static string AppName_Text
        {
            get
            {
                return Loader.GetString("AppName_Text");
            }
        }

        public static string Day_Text
        {
            get
            {
                return Loader.GetString("Day_Text");
            }
        }

        public static string Month_Text
        {
            get
            {
                return Loader.GetString("Month_Text");
            }
        }

        public static string CustomStyle_Text
        {
            get
            {
                return Loader.GetString("CustomStyle_Text");
            }
        }

        public static string Today_Label
        {
            get
            {
                return Loader.GetString("Today_Label");
            }
        }

        public static string View_Label
        {
            get
            {
                return Loader.GetString("View_Label");
            }
        }

        public static string Week_Text
        {
            get
            {
                return Loader.GetString("Week_Text");
            }
        }

        public static string WorkWeek_Text
        {
            get
            {
                return Loader.GetString("WorkWeek_Text");
            }
        }

    }
}
