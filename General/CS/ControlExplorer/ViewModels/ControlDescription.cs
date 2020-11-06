using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using Windows.UI.Xaml;
using ControlExplorer.Common;

namespace ControlExplorer
{
    public class ControlDescription: BindableBase, ISearchable
    {
        private bool _visible = false;

        public ControlDescription(XElement c)
        {
            bool b = false;
            IsNew = (c.Attribute("isNew") != null && bool.TryParse(c.Attribute("isNew").Value, out b) ? b : false);
            IsTop = (c.Attribute("isTop") != null && bool.TryParse(c.Attribute("isTop").Value, out b) ? b : false);
            IsEnabled = (c.Attribute("enabled") != null && bool.TryParse(c.Attribute("enabled").Value, out b) ? b : true);
            AssemblyName = c.Attribute("assembly") != null ? PlatformUtils.AdjustPlatformName(c.Attribute("assembly").Value, false) : string.Empty;
            Name = c.Attribute("name").Value;
            IconName = c.Attribute("iconName").Value;
            Source = (c.Attribute("source") != null) ? c.Attribute("source").Value : string.Empty;
            Description = (c.Element("Description") != null) ? c.Element("Description").Value : string.Empty;
            Features = (from f in c.Elements("Feature") select new FeatureDescription(this, f)).ToList();
        }

        public ControlDescription(string p1, string p2, string p3, string p4, string p5, bool isEnabled = true)
        {
            Name = p1;
            AssemblyName = p2;
            Features = new List<FeatureDescription>();
            IsEnabled = isEnabled;
        }

        public bool IsNew { get; set; }
        public bool IsTop { get; set; }
        public bool IsEnabled { get; set; }
        public string Name { get; set; }
        public string AssemblyName { get; set; }
        public string IconName { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }

        public bool Visible
        {
            get { return _visible; }
            set
            {
                SetProperty(ref _visible, value, "Visible");
            }
        }

        public Uri Link
        {
            get
            {
                var first = Features.FirstOrDefault();
                if (first != null)
                    return first.Link;
                else
                    return null;
            }
        }

        public DataTemplate Icon
        {
            get
            {
                try
                {
                    return (DataTemplate)App.Current.Resources["IconC1" + IconName.Replace(" ", "")];
                }
                catch
                {
                    return (DataTemplate)App.Current.Resources["IconC1Gray"];
                }
            }
        }

        public IEnumerable<FeatureDescription> Features { get; set; }

        internal IEnumerable<FeatureDescription> GetAllFeatures()
        {
            return Features.SelectMany(f => f.SubFeatures.Count() > 0 ? f.SubFeatures.ToList()/*.Concat(new List<FeatureDescription> {f})*/ : new List<FeatureDescription> { f });
        }

        public bool Contains(string word)
        {
            return Name.ToLower().Contains(word.ToLower());
        }

        public bool ContainsAny(string[] searchKeys)
        {
            return searchKeys.Any(key => Contains(key));
        }
    }
}
