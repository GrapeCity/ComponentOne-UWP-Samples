using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace FloatingBarChart
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("FloatingBarChartLib/Resources");

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

        public static string AppName
        {
            get
            {
                return _loader.GetString("AppName");
            }
        }

        #region Samples

        public static string GanttName
        {
            get
            {
                return _loader.GetString("GanttName");
            }
        }

        public static string GanttTitle
        {
            get
            {
                return _loader.GetString("GanttTitle");
            }
        }

        public static string GanttDescription
        {
            get
            {
                return _loader.GetString("GanttDescription");
            }
        }

        public static string FloatingBarName
        {
            get
            {
                return _loader.GetString("FloatingBarName");
            }
        }

        public static string FloatingBarTitle
        {
            get
            {
                return _loader.GetString("FloatingBarTitle");
            }
        }

        public static string FloatingBarDescription
        {
            get
            {
                return _loader.GetString("FloatingBarDescription");
            }
        }

        public static string RangedAreaName
        {
            get
            {
                return _loader.GetString("RangedAreaName");
            }
        }

        public static string RangedAreaTitle
        {
            get
            {
                return _loader.GetString("RangedAreaTitle");
            }
        }

        public static string RangedAreaDescription
        {
            get
            {
                return _loader.GetString("RangedAreaDescription");
            }
        }

        #endregion
    }
}
