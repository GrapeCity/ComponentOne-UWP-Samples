using ControlExplorer.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace ControlExplorer
{
    public class GroupDescription : BindableBase
    {
        private bool _isExpanded = false;

        public GroupDescription(XElement g)
        {
            Name = g.Attribute("name").Value;
            Controls = (from c in g.Elements("Control")
                      select new ControlDescription(c)).ToList();
            IsExpanded = (g.Attribute("isExpanded") != null) ? bool.Parse(g.Attribute("isExpanded").Value) : false;
        }

        public string Name { get; private set; }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                foreach (var c in Controls)
                {
                    c.Visible = value;
                }
                SetProperty(ref _isExpanded, value, "IsExpanded");
            }
        }

        public IEnumerable<ControlDescription> Controls { get; private set; }
    }
}
