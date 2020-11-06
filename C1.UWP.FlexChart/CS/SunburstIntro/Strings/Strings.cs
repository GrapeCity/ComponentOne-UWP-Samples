using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace SunburstIntro
{
   public class Strings
    {
        public static ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("SunburstIntroLib/Resources");

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

        public static string TxtAppName
        {
            get
            {
                return _loader.GetString("TxtAppName");
            }
        }

        public static string InnerRadius
        {
            get
            {
                return _loader.GetString("InnerRadius");
            }
        }

        public static string Offset
        {
            get
            {
                return _loader.GetString("Offset");
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

        public static string Palette
        {
            get
            {
                return _loader.GetString("Palette");
            }
        }

        public static string LegendPosition
        {
            get
            {
                return _loader.GetString("LegendPosition");
            }
        }

        public static string Header
        {
            get
            {
                return _loader.GetString("Header");
            }
        }

        public static string Footer
        {
            get
            {
                return _loader.GetString("Footer");
            }
        }

        public static string FooterContent
        {
            get
            {
                return _loader.GetString("FooterContent");
            }
        }

        public static string HeaderContent
        {
            get
            {
                return _loader.GetString("HeaderContent");
            }
        }

        public static string SelectedItemPosition
        {
            get
            {
                return _loader.GetString("SelectedItemPosition");
            }
        }

        public static string SelectedItemOffset
        {
            get
            {
                return _loader.GetString("SelectedItemOffset");
            }
        }

        public static string LabelPosition
        {
            get
            {
                return _loader.GetString("LabelPosition");
            }
        }

        public static string LabelOverlapping
        {
            get
            {
                return _loader.GetString("LabelOverlapping");
            }
        }

        #region Samples
        public static string BasicFeaturesTitle
        {
            get
            {
                return _loader.GetString("BasicFeaturesTitle");
            }
        }

        public static string BasicFeaturesDescription
        {
            get
            {
                return _loader.GetString("BasicFeaturesDescription");
            }
        }

        public static string BasicFeaturesName
        {
            get
            {
                return _loader.GetString("BasicFeaturesName");
            }
        }

        public static string GettingStartedTitle
        {
            get
            {
                return _loader.GetString("GettingStartedTitle");
            }
        }

        public static string GettingStartedDescription
        {
            get
            {
                return _loader.GetString("GettingStartedDescription");
            }
        }

        public static string GettingStartedName
        {
            get
            {
                return _loader.GetString("GettingStartedName");
            }
        }

        public static string LegendTitleTitle
        {
            get
            {
                return _loader.GetString("LegendTitleTitle");
            }
        }

        public static string LegendTitleDescription
        {
            get
            {
                return _loader.GetString("LegendTitleDescription");
            }
        }

        public static string LegendTitlesName
        {
            get
            {
                return _loader.GetString("LegendTitlesName");
            }
        }

        public static string SelectionTitle
        {
            get
            {
                return _loader.GetString("SelectionTitle");
            }
        }

        public static string SelectionDescription
        {
            get
            {
                return _loader.GetString("SelectionDescription");
            }
        }

        public static string SelectionName
        {
            get
            {
                return _loader.GetString("SelectionName");
            }
        }

        public static string GroupTitle
        {
            get
            {
                return _loader.GetString("GroupTitle");
            }
        }

        public static string GroupDescription
        {
            get
            {
                return _loader.GetString("GroupDescription");
            }
        }

        public static string GroupName
        {
            get
            {
                return _loader.GetString("GroupName");
            }
        }

        #endregion
    }
}
