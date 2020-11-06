using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace DrillDown
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("DrillDownLib/Resources");

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

        public static string BasicDrillDownName
        {
            get
            {
                return _loader.GetString("BasicDrillDownName");
            }
        }

        public static string BasicDrillDownTitle
        {
            get
            {
                return _loader.GetString("BasicDrillDownTitle");
            }
        }

        public static string BasicDrillDownDescription
        {
            get
            {
                return _loader.GetString("BasicDrillDownDescription");
            }
        }

        public static string AsyncDrillDownName
        {
            get
            {
                return _loader.GetString("AsyncDrillDownName");
            }
        }

        public static string AsyncDrillDownTitle
        {
            get
            {
                return _loader.GetString("AsyncDrillDownTitle");
            }
        }

        public static string AsyncDrillDownDescription
        {
            get
            {
                return _loader.GetString("AsyncDrillDownDescription");
            }
        }

        public static string WaitMessage
        {
            get
            {
                return _loader.GetString("WaitMessage");
            }
        }

        public static string SunburstName
        {
            get
            {
                return _loader.GetString("SunburstName");
            }
        }

        public static string SunburstTitle
        {
            get
            {
                return _loader.GetString("SunburstTitle");
            }
        }

        public static string SunburstDescription
        {
            get
            {
                return _loader.GetString("SunburstDescription");
            }
        }

        public static string TreemapName
        {
            get
            {
                return _loader.GetString("TreemapName");
            }
        }

        public static string TreemapTitle
        {
            get
            {
                return _loader.GetString("TreemapTitle");
            }
        }

        public static string TreemapDescription
        {
            get
            {
                return _loader.GetString("TreemapDescription");
            }
        }

        #endregion
    }
}
