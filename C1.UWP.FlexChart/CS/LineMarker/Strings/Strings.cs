using Windows.ApplicationModel.Resources;

namespace LineMarkerSample
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

        public static string LineType
        {
            get
            {
                return _loader.GetString("LineType");
            }
        }

        public static string Alignment
        {
            get
            {
                return _loader.GetString("Alignment");
            }
        }

        public static string Interaction
        {
            get
            {
                return _loader.GetString("Interaction");
            }
        }

        public static string DragContent
        {
            get
            {
                return _loader.GetString("DragContent");
            }
        }

        public static string DragLines
        {
            get
            {
                return _loader.GetString("DragLines");
            }
        }

        public static string Auto
        {
            get
            {
                return _loader.GetString("Auto");
            }
        }

        public static string Right
        {
            get
            {
                return _loader.GetString("Right");
            }
        }

        public static string Left
        {
            get
            {
                return _loader.GetString("Left");
            }
        }

        public static string Bottom
        {
            get
            {
                return _loader.GetString("Bottom");
            }
        }

        public static string Top
        {
            get
            {
                return _loader.GetString("Top");
            }
        }

        public static string LeftBottom
        {
            get
            {
                return _loader.GetString("LeftBottom");
            }
        }

        public static string LeftTop
        {
            get
            {
                return _loader.GetString("LeftTop");
            }
        }

        public static string True
        {
            get
            {
                return _loader.GetString("True");
            }
        }

        public static string False
        {
            get
            {
                return _loader.GetString("False");
            }
        }
    }
}
