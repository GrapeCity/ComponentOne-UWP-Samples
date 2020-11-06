using Windows.ApplicationModel.Resources;

namespace FlexChartMvvmDemo
{
    public class Strings
    {
        public static ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("Resources");

        public static string Title
        {
            get
            {
                return _loader.GetString("Title");
            }
        }

        public static string GroupBy
        {
            get
            {
                return _loader.GetString("GroupBy");
            }
        }

        public static string Aggregate
        {
            get
            {
                return _loader.GetString("Aggregate");
            }
        }

        public static string Select
        {
            get
            {
                return _loader.GetString("Select");
            }
        }

    }
}
