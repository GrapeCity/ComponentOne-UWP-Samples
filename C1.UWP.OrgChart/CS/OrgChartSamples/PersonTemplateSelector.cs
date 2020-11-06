using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OrgChartSamples
{
    /// <summary>
    /// Class used to select the templates for items being created.
    /// </summary>
    public class PersonTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var p = item as Person;
            //var e = Application.Current.RootVisual as FrameworkElement;
            //return p.Position.IndexOf("Director") > -1
            //    ? e.Resources["_tplDirector"] as DataTemplate
            //    : e.Resources["_tplOther"] as DataTemplate;


            if (p.Position.IndexOf(Strings.Director) > -1)
            {
                return DirectorTemplate;
            }
            else if (p.Position.IndexOf(Strings.Manager) > -1)
            {
                return ManagerTemplate;
            }
            else if (p.Position.IndexOf(Strings.Designer) > -1)
            {
                return DesignerTemplate;
            }
            else
            {
                return OtherTemplate;
            }
        }

        public DataTemplate DirectorTemplate { get; set; }
        public DataTemplate ManagerTemplate { get; set; }
        public DataTemplate DesignerTemplate { get; set; }
        public DataTemplate OtherTemplate { get; set; }
    }
}
