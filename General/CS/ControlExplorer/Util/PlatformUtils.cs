using System;
using System.Net;
using System.Windows;
using System.IO;

namespace ControlExplorer
{
    static class PlatformUtils
    {
        public static string AdjustPlatformName(string name, bool hasExtension)
        {
            return name;
        }

        public static string StripPlatformSuffix(string name, bool hasExtension)
        {
            return name;
        }

        public static bool IsWindowsPhoneDevice()
        {
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
            {
                return true;
            }

            return false;
        }
    }
}
