using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace WealthHealth
{
    public class Strings
    {
        public static ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("Resources");

        public static string TxtTip
        {
            get
            {
                return _loader.GetString("TxtTip");
            }
        }

        public static string TxtTrack
        {
            get
            {
                return _loader.GetString("TxtTrack");
            }
        }

        public static string SubTitle
        {
            get
            {
                return _loader.GetString("SubTitle");
            }
        }

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

        public static string AxisXTitle
        {
            get
            {
                return _loader.GetString("AxisXTitle");
            }
        }

        public static string AxisYTitle
        {
            get
            {
                return _loader.GetString("AxisYTitle");
            }
        }
    }
}
