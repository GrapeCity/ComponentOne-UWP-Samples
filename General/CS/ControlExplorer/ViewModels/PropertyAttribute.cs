using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlExplorer
{
    public class PropertyAttribute
    {
        public string MemberName { get; set; }

        public string DisplayName { get; set; }

        public string DefaultValue { get; set; }

        public bool Browsable { get; set; }

        public double MinimumValue { get; set; }

        public double MaximumValue { get; set; }

        public bool Tag { get; set; }
    }
}
