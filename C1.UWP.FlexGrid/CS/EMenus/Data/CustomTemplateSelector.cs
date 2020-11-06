using C1.Xaml;
using Windows.UI.Xaml;

namespace Grapecity.C1_EMenus
{
    public class CustomTemplateSelector : C1DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            if (item is Category)
            {                
                return Resources["CategoryTemplate"] as DataTemplate;
            }
            if (item is SubCategory)
            {
                return Resources["SubCategoryTemplate"] as DataTemplate;
            }
            return null;
        }
    }
}
