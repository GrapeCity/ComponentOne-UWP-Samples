using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace AnimationDemo
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("AnimationDemoLib/Resources");

        public static string FlexChartAnimationTitle
        {
            get
            {
                return _loader.GetString("FlexChartAnimationTitle");
            }
        }

        public static string FlexChartAnimationDescription
        {
            get
            {
                return _loader.GetString("FlexChartAnimationDescription");
            }
        }

        public static string FlexChartAnimationName
        {
            get
            {
                return _loader.GetString("FlexChartAnimationName");
            }
        }

        public static string FlexPieAnimationTitle
        {
            get
            {
                return _loader.GetString("FlexPieAnimationTitle");
            }
        }

        public static string FlexPieAnimationDescription
        {
            get
            {
                return _loader.GetString("FlexPieAnimationDescription");
            }
        }

        public static string FlexPieAnimationName
        {
            get
            {
                return _loader.GetString("FlexPieAnimationName");
            }
        }

        public static string CustomAnimationTitle
        {
            get
            {
                return _loader.GetString("CustomAnimationTitle");
            }
        }

        public static string CustomAnimationDescription
        {
            get
            {
                return _loader.GetString("CustomAnimationDescription");
            }
        }

        public static string CustomAnimationName
        {
            get
            {
                return _loader.GetString("CustomAnimationName");
            }
        }


        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

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
    }
}
