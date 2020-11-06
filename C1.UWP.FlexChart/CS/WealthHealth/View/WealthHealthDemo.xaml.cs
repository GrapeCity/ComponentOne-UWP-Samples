using C1.Xaml.Chart;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;

namespace WealthHealth
{
    /// <summary>
    /// Interaction logic for WealthHealthDemo.xaml
    /// </summary>
    public partial class WealthHealthDemo : UserControl
    {
        public WealthHealthDemo()
        {
            InitializeComponent();
        }

        void Series_SymbolRendering(object sender, RenderSymbolEventArgs e)
        {
            var country = e.Item as Country;
            if (country != null)
            {
                int selectedIndex = flexChart.SelectedIndex;
                var fill = new SolidColorBrush(GetColorByRegion(country.Region));
                var engine = e.Engine;
                engine.SetStroke(null);
                if (selectedIndex == -1)
                {
                    fill = engine.SetOpacity(fill, 0.5) as SolidColorBrush;
                    engine.SetFill(fill);
                }
                else
                {
                    var dataContext = Root.DataContext as WealthHealthViewModel;
                    if (dataContext.Countries[selectedIndex] == country)
                    {
                        var strokeClr = ConvertFromString("#b6ff00");
                        engine.SetStroke(new SolidColorBrush(strokeClr));
                        engine.SetStrokeThickness(6.0); 
                        engine.SetFill(fill);
                    }
                    else
                    {
                        fill = engine.SetOpacity(fill, 0.2) as SolidColorBrush;
                        engine.SetFill(fill);
                    }
                }
            }
        }

        Color GetColorByRegion(string region)
        {
            string clr = string.Empty;

            switch (region)
            {
                case "Sub-Saharan Africa":
                    clr = "#FF1F77B4";
                    break;
                case "South Asia":
                    clr = "#FFFF7F0E";
                    break;
                case "Middle East & North Africa":
                    clr = "#FF2CA02C";
                    break;
                case "America":
                    clr = "#FFD62728";
                    break;
                case "Europe & Central Asia":
                    clr = "#FF9467BD";
                    break;
                case "East Asia & Pacific":
                    clr = "#FF8C564B";
                    break;
            }
            if (string.IsNullOrEmpty(clr))
                return Colors.Black;

            return ConvertFromString(clr);
        }

        private Color ConvertFromString(string clr)
        {
            var color = (Color)XamlBindingHelper.ConvertValue(typeof(Color), clr);
            return color;
        }

        private void flexChart_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var hitInfo = flexChart.HitTest(e.GetCurrentPoint(flexChart).Position);
            Country selectedCountry = hitInfo.Item as Country;
            var dataContext = Root.DataContext as WealthHealthViewModel;
            if (selectedCountry != null && hitInfo.Distance < 3)
            {
                if (dataContext != null)
                {
                    tbTip.Visibility = Visibility.Collapsed;
                    tbTrack.Visibility = Visibility.Visible;
                    dataContext.TrackContent = selectedCountry.Name;
                }
            }
            else
            {
                tbTip.Visibility = Visibility.Visible;
                tbTrack.Visibility = Visibility.Collapsed;
            }
            dataContext.StopAnimation();
        }
    }
}
