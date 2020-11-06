using Windows.ApplicationModel.Resources;

namespace GestureChartSample
{
    public class Strings
    {
        public static ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("Resources");

        public static string ZoomMode
        {
            get
            {
                return _loader.GetString("ZoomMode");
            }
        }

        public static string TranslationMode
        {
            get
            {
                return _loader.GetString("TranslationMode");
            }
        }

        public static string ResetBtn
        {
            get
            {
                return _loader.GetString("ResetBtn");
            }
        }

        public static string Description
        {
            get
            {
                return _loader.GetString("Description");
            }
        }

        public static string Header
        {
            get
            {
                return _loader.GetString("Header");
            }
        }

        public static string Title
        {
            get
            {
                return _loader.GetString("Title");
            }
        }
    }
}
