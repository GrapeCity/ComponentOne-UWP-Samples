using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace ZipSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("ZipSamplesLib/Resources");

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString(" AppName_Text ");
            }
        }

        public static string Clear_Content
        {
            get
            {
                return _loader.GetString(" Clear_Content ");
            }
        }

        public static string Close_Content
        {
            get
            {
                return _loader.GetString(" Close_Content ");
            }
        }

        public static string Compress_Text
        {
            get
            {
                return _loader.GetString(" Compress_Text ");
            }
        }

        public static string CompressButton_Content
        {
            get
            {
                return _loader.GetString(" CompressButton_Content ");
            }
        }

        public static string CompressMessage
        {
            get
            {
                return _loader.GetString(" CompressMessage ");
            }
        }

        public static string DemoZipDescription
        {
            get
            {
                return _loader.GetString(" DemoZipDescription ");
            }
        }

        public static string DemoZipName
        {
            get
            {
                return _loader.GetString(" DemoZipName ");
            }
        }

        public static string DemoZipTitle
        {
            get
            {
                return _loader.GetString(" DemoZipTitle ");
            }
        }

        public static string Extract_Text
        {
            get
            {
                return _loader.GetString(" Extract_Text ");
            }
        }

        public static string ExtractButton_Content
        {
            get
            {
                return _loader.GetString(" ExtractButton_Content ");
            }
        }

        public static string ExtractMessage
        {
            get
            {
                return _loader.GetString(" ExtractMessage ");
            }
        }

        public static string InitializationException
        {
            get
            {
                return _loader.GetString(" InitializationException ");
            }
        }

        public static string NewFolder
        {
            get
            {
                return _loader.GetString(" NewFolder ");
            }
        }

        public static string Open_Content
        {
            get
            {
                return _loader.GetString(" Open_Content ");
            }
        }

        public static string PickFiles_Content
        {
            get
            {
                return _loader.GetString(" PickFiles_Content ");
            }
        }

        public static string PickSingleFolder_Content
        {
            get
            {
                return _loader.GetString(" PickSingleFolder_Content ");
            }
        }

        public static string Preview_Text
        {
            get
            {
                return _loader.GetString(" Preview_Text ");
            }
        }

        public static string Remove_Content
        {
            get
            {
                return _loader.GetString(" Remove_Content ");
            }
        }

        public static string Save
        {
            get
            {
                return _loader.GetString(" Save ");
            }
        }

        public static string Star
        {
            get
            {
                return _loader.GetString(" Star ");
            }
        }

        public static string UniqueIdItemsArgumentException
        {
            get
            {
                return _loader.GetString(" UniqueIdItemsArgumentException ");
            }
        }

        public static string View_Content
        {
            get
            {
                return _loader.GetString(" View_Content ");
            }
        }

        public static string ZipFile
        {
            get
            {
                return _loader.GetString(" ZipFile ");
            }
        }


    }
}
