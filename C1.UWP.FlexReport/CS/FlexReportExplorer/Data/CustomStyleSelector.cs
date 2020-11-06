using C1.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace C1FlexReportExplorer
{
    public class CustomStyleSelector : C1StyleSelector
    {
        protected override Style SelectStyleCore(object item, DependencyObject container)
        {
            var tvi = (C1TreeViewItem)container;
            if (tvi.Header is Category)
            {
                tvi.SetBinding(C1TreeViewItem.IsExpandedProperty, new Binding()
                {
                    Source = tvi.Header,
                    Path = new PropertyPath("IsExpanded"),
                    Mode = BindingMode.TwoWay
                });
                return (Style)Resources["ExpandedStyle"];
            }
            if (tvi.Header is Report)
            {
                tvi.SetBinding(C1TreeViewItem.IsSelectedProperty, new Binding()
                {
                    Source = tvi.Header,
                    Path = new PropertyPath("IsSelected"),
                    Mode = BindingMode.TwoWay
                });
            }
            return null;
        }
    }
}
