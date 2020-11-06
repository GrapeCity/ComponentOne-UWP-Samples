using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace InputPanelSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("InputPanelSamplesLib/Resources");

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }      

        public static string DemoDescription
        {
            get
            {
                return _loader.GetString("DemoDescription");
            }
        }

        public static string DemoName
        {
            get
            {
                return _loader.GetString("DemoName");
            }
        }

        public static string DemoTitle
        {
            get
            {
                return _loader.GetString("DemoTitle");
            }
        }     

        public static string CustomTemplateDescription
        {
            get
            {
                return _loader.GetString("CustomTemplateDescription");
            }
        }

        public static string CustomTemplateName
        {
            get
            {
                return _loader.GetString("CustomTemplateName");
            }
        }

        public static string CustomTemplateTitle
        {
            get
            {
                return _loader.GetString("CustomTemplateTitle");
            }
        }    

        public static string IntegrateDescription
        {
            get
            {
                return _loader.GetString("IntegrateDescription");
            }
        }      

        public static string IntegrateName
        {
            get
            {
                return _loader.GetString("IntegrateName");
            }
        }

        public static string IntegrateTitle
        {
            get
            {
                return _loader.GetString("IntegrateTitle");
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

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString("UniqueIdItemsArgumentException");
            }
        }

        public static string FileNotFoundException
        {
            get
            {
                return _loader.GetString("FileNotFoundException");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }
    }
}
