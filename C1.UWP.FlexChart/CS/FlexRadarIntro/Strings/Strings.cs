using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace FlexRadarIntro
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("FlexRadarIntroLib/Resources");

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

        public static string ChartType
        {
            get
            {
                return _loader.GetString("ChartType");
            }
        }

        public static string Stacking
        {
            get
            {
                return _loader.GetString("Stacking");
            }
        }

        public static string Palette
        {
            get
            {
                return _loader.GetString("Palette");
            }
        }

        public static string StartAngle
        {
            get
            {
                return _loader.GetString("StartAngle");
            }
        }

        public static string Reversed
        {
            get
            {
                return _loader.GetString("Reversed");
            }
        }

        public static string StartAngleCaption
        {
            get
            {
                return _loader.GetString("StartAngleCaption");
            }
        }

        public static string UpDownCaption
        {
            get
            {
                return _loader.GetString("UpDownCaption");
            }
        }

        public static string Function
        {
            get
            {
                return _loader.GetString("Function");
            }
        }

        #region Samples

        public static string PolarChartTitle
        {
            get
            {
                return _loader.GetString("PolarChartTitle");
            }
        }

        public static string PolarChartName
        {
            get
            {
                return _loader.GetString("PolarChartName");
            }
        }

        public static string PolarChartDescription
        {
            get
            {
                return _loader.GetString("PolarChartDescription");
            }
        }

        public static string RadarChartName
        {
            get
            {
                return _loader.GetString("RadarChartName");
            }
        }

        public static string RadarChartTitle
        {
            get
            {
                return _loader.GetString("RadarChartTitle");
            }
        }

        public static string RadarChartDescription
        {
            get
            {
                return _loader.GetString("RadarChartDescription");
            }
        }

        #endregion
    }
}
