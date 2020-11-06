using C1.Xaml;
using Windows.UI.Xaml;

namespace BasicLibrarySamples
{
    /// <summary>
    /// Selects a style for the nodes that are ancestors of a C1.Silverlight assembly class
    /// so they start with the IsExpanded property set to True
    /// </summary>
    public class CustomStyleSelector : C1StyleSelector
    {
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var group = ((C1TreeViewItem)container).Header as WorldCupGroup;

            if (group != null)
                return (Style)Resources["ExpandedStyle"];

            return null;
        }

        public override ResourceDictionary Resources
        {
            get
            {
                return base.Resources;
            }
            set
            {
                base.Resources = value;
            }
        }
    }
}
