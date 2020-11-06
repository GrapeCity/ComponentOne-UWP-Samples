using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace FlexChartCustomization
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("FlexChartCustomizationLib/Resources");

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

        public static string LineStylesName
        {
            get
            {
                return _loader.GetString("LineStylesName");
            }
        }

        public static string LineStylesTitle
        {
            get
            {
                return _loader.GetString("LineStylesTitle");
            }
        }

        public static string LineStylesDescription
        {
            get
            {
                return _loader.GetString("LineStylesDescription");
            }
        }

        public static string LegendItemsName
        {
            get
            {
                return _loader.GetString("LegendItemsName");
            }
        }

        public static string LegendItemsTitle
        {
            get
            {
                return _loader.GetString("LegendItemsTitle");
            }
        }

        public static string LegendItemsDescription
        {
            get
            {
                return _loader.GetString("LegendItemsDescription");
            }
        }

        public static string LegendRangesName
        {
            get
            {
                return _loader.GetString("LegendRangesName");
            }
        }

        public static string LegendRangesTitle
        {
            get
            {
                return _loader.GetString("LegendRangesTitle");
            }
        }

        public static string LegendRangesDescription
        {
            get
            {
                return _loader.GetString("LegendRangesDescription");
            }
        }

        #endregion
    }
}
