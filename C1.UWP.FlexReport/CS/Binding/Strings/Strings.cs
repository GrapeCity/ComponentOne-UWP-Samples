using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace Binding
{
    public class Strings
    {
        private static ResourceLoader _loader = ResourceLoader.GetForViewIndependentUse("Resources");

        public static string FailedToShowReport
        {
            get { return _loader.GetString("FailedToShowReport"); }
        }

        public static string lblReport_Text
        {
            get { return _loader.GetString("lblReport_Text"); }
        }
    }
}
