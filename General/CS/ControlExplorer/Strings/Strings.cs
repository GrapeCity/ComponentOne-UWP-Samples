using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace ControlExplorer
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("Resources");

        public static string App_Title
        {
            get
            {
                return _loader.GetString("App_Title");
            }
        }

        public static string All_Text
        {
            get
            {
                return _loader.GetString("All_Text");
            }
        }

        public static string About_Text
        {
            get
            {
                return _loader.GetString("About_Text");
            }
        }

        public static string Support_Text
        {
            get
            {
                return _loader.GetString("Support_Text");
            }
        }

        public static string Pricing_Text
        {
            get
            {
                return _loader.GetString("Pricing_Text");
            }
        }

        public static string PlaceHolder_Text
        {
            get
            {
                return _loader.GetString("PlaceHolder_Text");
            }
        }

        public static string FreeTrial_Text
        {
            get
            {
                return _loader.GetString("FreeTrial_Text");
            }
        }

        public static string Home_Text
        {
            get
            {
                return _loader.GetString("Home_Text");
            }
        }

        public static string Features_Text
        {
            get
            {
                return _loader.GetString("Features_Text");
            }
        }

        public static string ExpandAll_Text
        {
            get
            {
                return _loader.GetString("ExpandAll_Text");
            }
        }

        public static string CollapseAll_Text
        {
            get
            {
                return _loader.GetString("CollapseAll_Text");
            }
        }

        public static string NewControls_Header
        {
            get
            {
                return _loader.GetString("NewControls_Header");
            }
        }

        public static string TopControls_Header
        {
            get
            {
                return _loader.GetString("TopControls_Header");
            }
        }

        public static string ControlsHub_Text
        {
            get
            {
                return _loader.GetString("ControlsHub_Text");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string LeftPanelTB1_Text
        {
            get
            {
                return _loader.GetString("LeftPanelTB1_Text");
            }
        }

        public static string LeftPanelTB2_Text
        {
            get
            {
                return _loader.GetString("LeftPanelTB2_Text");
            }
        }

        public static string LeftPanelTB3_Text
        {
            get
            {
                return _loader.GetString("LeftPanelTB3_Text");
            }
        }

        public static string LeftPanelTB4_Text
        {
            get
            {
                return _loader.GetString("LeftPanelTB4_Text");
            }
        }

        public static string New_Text
        {
            get
            {
                return _loader.GetString("New_Text");
            }
        }

        public static string PageTitle_Text
        {
            get
            {
                return _loader.GetString("PageTitle_Text");
            }
        }

        public static string Copyright_Text
        {
            get
            {
                return _loader.GetString("Copyright_Text");
            }
        }

        public static string Trademarks_Text
        {
            get
            {
                return _loader.GetString("Trademarks_Text");
            }
        }

        public static string PhoneControlsHub_Header
        {
            get
            {
                return _loader.GetString("PhoneControlsHub_Header");
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

        public static string About_Url
        {
            get
            {
                return _loader.GetString("About_Url");
            }
        }

        public static string Support_Url
        {
            get
            {
                return _loader.GetString("Support_Url");
            }
        }

        public static string Pricing_Url
        {
            get
            {
                return _loader.GetString("Pricing_Url");
            }
        }

        public static string Trial_Url
        {
            get
            {
                return _loader.GetString("Trial_Url");
            }
        }
    }
}
