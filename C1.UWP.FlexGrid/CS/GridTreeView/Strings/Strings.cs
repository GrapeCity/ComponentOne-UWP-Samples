using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace GridTreeViewSamples
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForCurrentView("GridTreeViewSamplesLib/Resources");

        public static string GridTreeViewSamplesDescription
        {
            get
            {
                return _loader.GetString("GridTreeViewSamplesDescription");
            }
        }

        public static string GridTreeViewSamplesName
        {
            get
            {
                return _loader.GetString("GridTreeViewSamplesName");
            }
        }

        public static string GridTreeViewSamplesTitle
        {
            get
            {
                return _loader.GetString("GridTreeViewSamplesTitle");
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

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }


        public static string BoundC1TreeView
        {
            get
            {
                return _loader.GetString("BoundC1TreeView");
            }
        }


        public static string UnBoundC1TreeView
        {
            get
            {
                return _loader.GetString("UnBoundC1TreeView");
            }
        }

        public static string BoundC1FlexGrid
        {
            get
            {
                return _loader.GetString("BoundC1FlexGrid");
            }
        }

        public static string UnBoundC1FlexGrid
        {
            get
            {
                return _loader.GetString("UnBoundC1FlexGrid");
            }
        }

        public static string BuildingPersonTree
        {
            get
            {
                return _loader.GetString("BuildingPersonTree");
            }
        }

        public static string PersonFormat
        {
            get
            {
                return _loader.GetString("PersonFormat");
            }
        }

        public static string AddChild_Content
        {
            get
            {
                return _loader.GetString("AddChild_Content");
            }
        }

        public static string AddRoot_Content
        {
            get
            {
                return _loader.GetString("AddRoot_Content");
            }
        }

        public static string AppName_Text
        {
            get
            {
                return _loader.GetString("AppName_Text");
            }
        }

        public static string Bound_Header
        {
            get
            {
                return _loader.GetString("Bound_Header");
            }
        }

        public static string Change_Content
        {
            get
            {
                return _loader.GetString("Change_Content");
            }
        }

        public static string Delete_Content
        {
            get
            {
                return _loader.GetString("Delete_Content");
            }
        }

        public static string Ready_Text
        {
            get
            {
                return _loader.GetString("Ready_Text");
            }
        }

        public static string Unbound_Header
        {
            get
            {
                return _loader.GetString("Unbound_Header");
            }
        }
    }
}
