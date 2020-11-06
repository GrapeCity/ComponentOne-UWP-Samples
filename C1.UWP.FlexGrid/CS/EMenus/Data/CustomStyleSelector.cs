using C1.Xaml;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Grapecity.C1_EMenus
{
    public class CustomStyleSelector : C1StyleSelector
    {

        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var tvi = (C1TreeViewItem)container;
            if (tvi.Header is Category)
            {
                Style style = ((Style)Resources["ExpandedStyle"]);

                return style;
            }

            if (tvi.Header is SubCategory)
            {

                return (Style)Resources["ExpandedStyle"];
            }
            return null;
        }
    }
}
