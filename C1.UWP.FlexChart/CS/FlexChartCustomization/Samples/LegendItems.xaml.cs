using C1.Xaml.Chart;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.Graphics.Imaging;
using System.Threading.Tasks;
using C1.Chart;

namespace FlexChartCustomization
{
    /// <summary>
    /// Interaction logic for LegendItems.xaml
    /// </summary>
    public partial class LegendItems : Page
    {
        Series defaultSeries, customSeries;
        public LegendItems()
        {
            InitializeComponent();
            flexChart.Binding = "Shipments";
            flexChart.BindingX = "Name";
            customSeries = new SeriesWithPointLegendItems()
            {
                ShowLegendNames = chbLegendNames.IsChecked.Value,
                ShowCustomIcons = chbLegendCustomIcons.IsChecked.Value,
                ShowLegendGroups = chbLegendGroups.IsChecked.Value,
            };
            customSeries.SymbolRendering += VendorSeries_SymbolRendering;
            customSeries.SeriesName = "Shipments";
            flexChart.Series.Add(customSeries);

            // for small displays (WindowsPhone), rearrange the page in a more vertical fashion
            // and reduce the size of legend fonts.
            if (IsWindowsPhoneDevice)
            {
                flexChart.LegendStyle = new ChartStyle() { FontSize = 10 };
                flexChart.LegendGroupHeaderStyle.FontSize = 10;

                chbLegendCustomIcons.Margin = chbLegendGroups.Margin = chbLegendNames.Margin =
                    chbPointsLegends.Margin = new Windows.UI.Xaml.Thickness(0);

                optionPanel.Orientation = Windows.UI.Xaml.Controls.Orientation.Vertical;
            }
        }

        private bool IsWindowsPhoneDevice
        {
            get
            {
                return Windows.Foundation.Metadata.ApiInformation.
                    IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            }
        }

    private void VendorSeries_SymbolRendering(object sender, RenderSymbolEventArgs e)
        {
            e.Engine.SetFill(new SolidColorBrush(SampleViewModel.SmartPhoneVendors.ElementAt(e.Index).Color));
            e.Engine.SetStroke(new SolidColorBrush(SampleViewModel.SmartPhoneVendors.ElementAt(e.Index).Color));
        }

        public class SeriesWithPointLegendItems : Series, ISeries
        {
            public bool ShowLegendGroups { get; set; }
            public bool ShowCustomIcons { get; set; }
            public bool ShowLegendNames { get; set; }

            /// <summary>
            /// Gets the name of legend.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            string ISeries.GetLegendItemName(int index)
            {
                return ShowLegendNames ? SampleViewModel.SmartPhoneVendors.ElementAt(index).Name : null;
            }

            /// <summary>
            /// Gets the style of legend.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            _Style ISeries.GetLegendItemStyle(int index)
            {
                return new _Style { Fill = new SolidColorBrush(SampleViewModel.SmartPhoneVendors.ElementAt(index).Color) };
            }

            /// <summary>
            /// Get the number of series items in the legend.
            /// </summary>
            int ISeries.GetLegendItemLength() { return SampleViewModel.SmartPhoneVendors.Count; }

            /// <summary>
            /// Get the legend group name for the series item.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            string ISeries.GetLegendItemGroup(int index)
            {
                if (ShowLegendGroups)
                    return SampleViewModel.SmartPhoneVendors.ElementAt(index).Country;
                else
                    return null;
            }

            object ISeries.GetLegendItemImageSource(int index, ref C1.Chart._Size imageSize)
            {
                if (ShowCustomIcons)
                {
                    var bounds = Windows.UI.ViewManagement.ApplicationView.
                        GetForCurrentView().VisibleBounds;
                    double divadj = bounds.Height > 900 ? 15 : 35;
                    double fracHeight = bounds.Height / divadj;
                    imageSize.Width = imageSize.Height = fracHeight < 60 ? fracHeight : 60;
                    SmartPhoneVendor vendor = SampleViewModel.SmartPhoneVendors.ElementAt(index);
                    return vendor.ImageSource;
                }
                else
                    return null;
            }
        }

        private void setCustomOptionCheckBoxes(bool customOptionVisibility)
        {
            Windows.UI.Xaml.Visibility visibility = customOptionVisibility
                ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
            chbLegendGroups.Visibility = visibility;
            chbLegendNames.Visibility = visibility;
            chbLegendCustomIcons.Visibility = visibility;
        }

        private void ChbPointsLegends_Changed(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flexChart == null) return;
            if (chbPointsLegends.IsChecked.HasValue && chbPointsLegends.IsChecked.Value)
            {
                flexChart.Series.Clear();
                flexChart.Series.Add(customSeries);
                setCustomOptionCheckBoxes(true);
            }
            else
            {
                if (defaultSeries == null)
                {
                    defaultSeries = new Series();
                    defaultSeries.SeriesName = "Shipments";
                }
                flexChart.Series.Clear();
                flexChart.Series.Add(defaultSeries);
                setCustomOptionCheckBoxes(false);
            }
        }

        private void chbLegendGroups_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flexChart == null) return;
            if (flexChart.Series[0] == customSeries)
            {
                (customSeries as SeriesWithPointLegendItems).ShowLegendGroups = chbLegendGroups.IsChecked.Value;
                flexChart.Invalidate();
            }
        }

        private void chbLegendCustomIcons_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flexChart == null) return;
            if (flexChart.Series[0] == customSeries)
            {
                (customSeries as SeriesWithPointLegendItems).ShowCustomIcons = chbLegendCustomIcons.IsChecked.Value;
                flexChart.Invalidate();
            }
        }

        private void chbLegendNames_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (flexChart == null) return;
            if (flexChart.Series[0] == customSeries)
            {
                (customSeries as SeriesWithPointLegendItems).ShowLegendNames = chbLegendNames.IsChecked.Value;
                flexChart.Invalidate();
            }
        }
    }
}
