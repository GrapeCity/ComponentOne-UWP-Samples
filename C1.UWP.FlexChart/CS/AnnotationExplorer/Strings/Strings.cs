using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace AnnotationExplorer
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("AnnotationExplorerLib/Resources");

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

        public static string RectangleTooltip
        {
            get
            {
                return _loader.GetString("RectangleTooltip");
            }
        }

        public static string EllipseTooltip
        {
            get
            {
                return _loader.GetString("EllipseTooltip");
            }
        }

        public static string CircleTooltip
        {
            get
            {
                return _loader.GetString("CircleTooltip");
            }
        }

        public static string TextTooltip
        {
            get
            {
                return _loader.GetString("TextTooltip");
            }
        }

        public static string SquareTooltip
        {
            get
            {
                return _loader.GetString("SquareTooltip");
            }
        }

        public static string PolygonTooltip
        {
            get
            {
                return _loader.GetString("PolygonTooltip");
            }
        }

        public static string LineTooltip
        {
            get
            {
                return _loader.GetString("LineTooltip");
            }
        }

        public static string ImageTooltip
        {
            get
            {
                return _loader.GetString("ImageTooltip");
            }
        }

        public static string PhoneRectangleTooltip
        {
            get
            {
                return _loader.GetString("PhoneRectangleTooltip");
            }
        }

        public static string PhoneTextTooltip
        {
            get
            {
                return _loader.GetString("TextTooltip");
            }
        }

        public static string PhoneSquareTooltip
        {
            get
            {
                return _loader.GetString("SquareTooltip");
            }
        }

        public static string PhonePolygonTooltip
        {
            get
            {
                return _loader.GetString("PolygonTooltip");
            }
        }

        public static string PhoneImageTooltip
        {
            get
            {
                return _loader.GetString("ImageTooltip");
            }
        }

        public static string DContent
        {
            get
            {
                return _loader.GetString("DContent");
            }
        }

        public static string EContent
        {
            get
            {
                return _loader.GetString("EContent");
            }
        }

        public static string RWContent
        {
            get
            {
                return _loader.GetString("RWContent");
            }
        }

        public static string FacebookContent
        {
            get
            {
                return _loader.GetString("FacebookContent");
            }
        }

        public static string AlibabaContent
        {
            get
            {
                return _loader.GetString("AlibabaContent");
            }
        }

        public static string CloseTooltip
        {
            get
            {
                return _loader.GetString("CloseTooltip");
            }
        }

        public static string InfoTooltip
        {
            get
            {
                return _loader.GetString("InfoTooltip");
            }
        }

        public static string ArrowTooltip
        {
            get
            {
                return _loader.GetString("ArrowTooltip");
            }
        }

        public static string DividendTooltip
        {
            get
            {
                return _loader.GetString("DividendTooltip");
            }
        }

        #region Samples

        public static string BasicName
        {
            get
            {
                return _loader.GetString("BasicName");
            }
        }

        public static string BasicTitle
        {
            get
            {
                return _loader.GetString("BasicTitle");
            }
        }

        public static string BasicDescription
        {
            get
            {
                return _loader.GetString("BasicDescription");
            }
        }

        public static string AdvancedName
        {
            get
            {
                return _loader.GetString("AdvancedName");
            }
        }

        public static string AdvancedTitle
        {
            get
            {
                return _loader.GetString("AdvancedTitle");
            }
        }

        public static string AdvancedDescription
        {
            get
            {
                return _loader.GetString("AdvancedDescription");
            }
        }

        public static string CalloutsName
        {
            get
            {
                return _loader.GetString("CalloutsName");
            }
        }

        public static string CalloutsTitle
        {
            get
            {
                return _loader.GetString("CalloutsTitle");
            }
        }

        public static string CalloutsDescription
        {
            get
            {
                return _loader.GetString("CalloutsDescription");
            }
        }

        #endregion
    }
}
