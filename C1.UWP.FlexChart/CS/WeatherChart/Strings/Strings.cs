using Windows.ApplicationModel.Resources;

namespace WeatherChart
{
    public class Strings
    {
        public static ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("Resources");

        public static string Description
        {
            get
            {
                return _loader.GetString("Description");
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
