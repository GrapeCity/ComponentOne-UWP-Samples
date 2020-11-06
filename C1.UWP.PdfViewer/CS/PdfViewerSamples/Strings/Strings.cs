using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace PdfViewerSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("PdfViewerSamplesLib/Resources");

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string ComboBoxItemHorizontal_Content
        {
            get
            {
                return _loader.GetString("ComboBoxItemHorizontal_Content");
            }
        }

        public static string ComboBoxItemVertical_Content
        {
            get
            {
                return _loader.GetString("ComboBoxItemVertical_Content");
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

        public static string Download_Text
        {
            get
            {
                return _loader.GetString("Download_Text");
            }
        }

        public static string DownloadException
        {
            get
            {
                return _loader.GetString("DownloadException");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string LargeFileDescription
        {
            get
            {
                return _loader.GetString("LargeFileDescription");
            }
        }

        public static string LargeFileName
        {
            get
            {
                return _loader.GetString("LargeFileName");
            }
        }

        public static string LargeFileTitle
        {
            get
            {
                return _loader.GetString("LargeFileTitle");
            }
        }

        public static string Load_Content
        {
            get
            {
                return _loader.GetString("Load_Content");
            }
        }

        public static string Orientation_Text
        {
            get
            {
                return _loader.GetString("Orientation_Text");
            }
        }

        public static string Print_Content
        {
            get
            {
                return _loader.GetString("Print_Content");
            }
        }

        public static string PrintDescription
        {
            get
            {
                return _loader.GetString("PrintDescription");
            }
        }

        public static string PrintException
        {
            get
            {
                return _loader.GetString("PrintException");
            }
        }

        public static string PrintName
        {
            get
            {
                return _loader.GetString("PrintName");
            }
        }

        public static string PrintTitle
        {
            get
            {
                return _loader.GetString("PrintTitle");
            }
        }

        public static string Retry_Content
        {
            get
            {
                return _loader.GetString("Retry_Content");
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
    }
}
