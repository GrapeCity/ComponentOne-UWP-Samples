using C1.Chart;
using C1.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using MovingAverageType = C1.Chart.Finance.MovingAverageType;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FinancialChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Overlays : Page
    {
        DataService dataService = DataService.GetService();

        public Overlays()
        {
            this.InitializeComponent();
            this.Loaded += Overlays_Loaded;
        }

        private void Overlays_Loaded(object sender, RoutedEventArgs e)
        {
            if (cbOverlays != null)
            {
                cbOverlays.SelectedIndex = 0;
            }
            if (cbTypes != null)
            {
                cbTypes.SelectedIndex = 0;
            }
        }

        public List<Quote> Data
        {
            get
            {
                return dataService.GetSymbolData("box", 87);
            }
        }

        public List<string> OverlayTypes
        {
            get
            {
                return Strings.OverlaysTypes.Split(',').ToList();
            }
        }

        public List<string> Types
        {
            get
            {
                return Enum.GetNames(typeof(MovingAverageType)).ToList();
            }
        }

        void HandleTooltip(Point pt)
        {
            var hitTest = overlayChart.HitTest(pt);
            var ser = hitTest.Series;
            if (ser != null)
            {
                if (ser == bollinger)
                {
                    overlayChart.ToolTipContent = "{seriesName}\u000ADate: {Date}\u000AUpper: {Upper:n2}\u000AMiddle: {Middle:n2}\u000ALower: {Lower:n2}";
                }
                else if (ser == envelopes)
                {
                    overlayChart.ToolTipContent = "{seriesName}\u000ADate: {Date}\u000AUpper: {Upper:n2}\u000ALower: {Lower:n2}";
                }
                else
                {
                    overlayChart.ToolTipContent = "{}{seriesName}\u000ADate: {Date}\u000AY: {y:n2}\u000AVolume: {Volume:n0}";
                }
            }
        }

        private void overlayChart_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var pt = e.GetCurrentPoint(overlayChart).Position;
            HandleTooltip(pt);
        }

        private void overlayChart_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var pt = e.GetCurrentPoint(overlayChart).Position;
            HandleTooltip(pt);
        }

        private void cbOverlays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedIndex = cbOverlays.SelectedIndex;
            if (selectedIndex == 0)
            {
                bollinger.Visibility = SeriesVisibility.Visible;
                envelopes.Visibility = SeriesVisibility.Hidden;
                spBollingerOptions.Visibility = Visibility.Visible;
                spEnvelopesOptions.Visibility = Visibility.Collapsed;
            }
            else
            {
                bollinger.Visibility = SeriesVisibility.Hidden;
                envelopes.Visibility = SeriesVisibility.Visible;
                spBollingerOptions.Visibility = Visibility.Collapsed;
                spEnvelopesOptions.Visibility = Visibility.Visible;
            }
        }

        private void cbMultiplier_ValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (bollinger != null)
            {
                var multiplier = (int)e.NewValue;
                multiplier = Math.Min(Math.Max(1, multiplier), 100);
                bollinger.Multiplier = multiplier;
            }
        }

        private void cbPeriod_ValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (bollinger != null)
            {
                var period = (int)e.NewValue;
                period = Math.Min(Math.Max(2, period), 86);
                bollinger.Period = period;
            }
        }

        private void cbEnvelopesPeriod_ValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (envelopes != null)
            {
                var period = (int)e.NewValue;
                period = Math.Min(Math.Max(2, period), 86);
                envelopes.Period = period;
            }
        }

        private void cbSize_ValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (envelopes != null)
            {
                var size = e.NewValue;
                size = Math.Min(Math.Max(0, size), 1);
                envelopes.Size = size;
            }
        }

        private void cbTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (envelopes != null)
            {
                var type = (MovingAverageType)Enum.Parse(typeof(MovingAverageType), cbTypes.SelectedValue.ToString());
                envelopes.Type = type;
            }
        }

        private void OnSplitterButtonClick(object sender, RoutedEventArgs e)
        {
            splitter.IsPaneOpen = !splitter.IsPaneOpen;
        }
    }
}
