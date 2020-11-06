using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace ExtendedSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("ExtendedSamplesLib/Resources");

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string Author_Text
        {
            get
            {
                return _loader.GetString("Author_Text");
            }
        }

        public static string BookDemoDescription
        {
            get
            {
                return _loader.GetString("BookDemoDescription");
            }
        }

        public static string BookDemoName
        {
            get
            {
                return _loader.GetString("BookDemoName");
            }
        }

        public static string BookDemoTitle
        {
            get
            {
                return _loader.GetString("BookDemoTitle");
            }
        }

        public static string BookPageSpanDescription
        {
            get
            {
                return _loader.GetString("BookPageSpanDescription");
            }
        }

        public static string BookPageSpanName
        {
            get
            {
                return _loader.GetString("BookPageSpanName");
            }
        }

        public static string BookPageSpanTitle
        {
            get
            {
                return _loader.GetString("BookPageSpanTitle");
            }
        }

        public static string ColorPickerDemoDescription
        {
            get
            {
                return _loader.GetString("ColorPickerDemoDescription");
            }
        }

        public static string ColorPickerDemoName
        {
            get
            {
                return _loader.GetString("ColorPickerDemoName");
            }
        }

        public static string ColorPickerDemoTitle
        {
            get
            {
                return _loader.GetString("ColorPickerDemoTitle");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string Note_Text
        {
            get
            {
                return _loader.GetString("Note_Text");
            }
        }

        public static string Price_Text
        {
            get
            {
                return _loader.GetString("Price_Text");
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
