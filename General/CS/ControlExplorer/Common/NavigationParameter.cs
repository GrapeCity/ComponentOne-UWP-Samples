using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlExplorer.Common
{
    class NavigationParameter
    {
        public NavigationParameter()
        {

        }

        public NavigationParameter(ControlDescription control, NavigationHelper navigation)
        {
            Control = control;
            Navigation = navigation;
        }

        public NavigationParameter(FeatureDescription feature, NavigationHelper navigation)
        {
            Feature = feature;
            Navigation = navigation;
        }

        public ControlDescription Control { get; set; }
        public FeatureDescription Feature { get; set; }
        public NavigationHelper Navigation { get; set; }
    }
}
