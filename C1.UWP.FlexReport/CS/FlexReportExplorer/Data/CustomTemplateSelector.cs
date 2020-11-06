using C1.Xaml;
using Windows.UI.Xaml;

namespace C1FlexReportExplorer
{
    public class CustomTemplateSelector : C1DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var group = item as Category;
            if (group != null)
            {
                if (group.Name == "Separator")
                    return Resources["CategorySeparatorTemplate"] as DataTemplate; 
                return Resources["CategoryTemplate"] as DataTemplate;
            }
            if (item is Report)
            {
                return Resources["ReportTemplate"] as DataTemplate;
            }
            return null;
        }
    }
}
