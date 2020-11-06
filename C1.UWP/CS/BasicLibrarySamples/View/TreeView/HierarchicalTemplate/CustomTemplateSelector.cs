using C1.Xaml;
using Windows.UI.Xaml;

namespace BasicLibrarySamples
{
    /// <summary>
    /// Selects a data template depending on the assembly of the type stored in the data object.
    /// If the type belongs to the C1.Silverlight assembly then the DataTemplate
    /// with key=C1DataTemplate is selected, otherwise the DataTemplate with key=SilverlightDataTemplate
    /// is selected
    /// </summary>
    public class CustomTemplateSelector : C1DataTemplateSelector
    {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            var group = item as WorldCupGroup;
            var team = item as WorldCupTeam;

            if (group != null)
                return Resources["GroupTemplate"] as DataTemplate;

            if (team != null)
                return Resources["TeamTemplate"] as DataTemplate;

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
