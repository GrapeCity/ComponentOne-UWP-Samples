using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace DateTimeSelector_UIATest
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("Resources");

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

        public static string InitializationException
        {
            get
            {
                return _loader.GetString("InitializationException");
            }
        }

        public static string btn_Clear_Content
        {
            get
            {
                return _loader.GetString("btn_Clear_Content");
            }
        }

        public static string btn_Set_Content
        {
            get
            {
                return _loader.GetString("btn_Set_Content");
            }
        }
    }
}
