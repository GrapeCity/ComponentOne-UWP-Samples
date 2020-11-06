using System;
using Windows.ApplicationModel.Resources;
using System.Diagnostics;

namespace C1FlexReportExplorer
{
    public class Strings
    {
        static ResourceLoader _loader;

        static Strings()
        {
            try
            {
                _loader = ResourceLoader.GetForCurrentView("Resources");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static string CatalogToolLabel
        {
            get { return _loader.GetString("CatalogToolLabel"); }
        }

        public static string CloseButtonToolTip
        {
            get { return _loader.GetString("CloseButtonToolTip"); }
        }

        public static string ErrorFormat
        {
            get { return _loader.GetString("ErrorFormat"); }
        }

        public static string ReportErrorFormat
        {
            get { return _loader.GetString("ReportErrorFormat"); }
        }

        public static string ErrorTitle
        {
            get { return _loader.GetString("ErrorTitle"); }
        }
    }
}
