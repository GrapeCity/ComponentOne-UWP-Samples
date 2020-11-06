using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using C1.Chart;
using C1.Xaml;
using C1.Xaml.Chart;
using C1.Xaml.Chart.Finance;
using System;
using System.Linq;
using Windows.UI.Xaml.Input;
using Windows.Foundation;

namespace FinancialChartExplorer
{
    /// <summary>
    /// Interaction logic for Indicators.xaml
    /// </summary>
    public partial class Indicators : Page
    {
        DataService dataService = DataService.GetService();
        public Indicators()
        {
            InitializeComponent();
            this.Loaded += OnIndicatorsLoaded;
        }

        public List<Quote> Data
        {
            get
            {
                return dataService.GetSymbolData("box", 87);
            }
        }

        public List<string> IndicatorType
        {
            get
            {
                return Strings.IndicatorType.Split(',').ToList();
            }
        }

        void OnIndicatorsLoaded(object sender, RoutedEventArgs e)
        {
            cbIndicatorType.SelectedIndex = 0;
            this.cbPeriod.Value = atr.Period;
        }

        void OnIndicatorTypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (indicatorChart == null)
                return;

            var selectedIndex = cbIndicatorType.SelectedIndex;

            if (selectedIndex == 0
                || selectedIndex == 1
                || selectedIndex == 2
                || selectedIndex == 3)
            {
                if (spNormalOptions != null)
                    spNormalOptions.Visibility = Visibility.Visible;
                if (spMacdOptions != null)
                    spMacdOptions.Visibility = Visibility.Collapsed;
                if (spStochasticOptions != null)
                    spStochasticOptions.Visibility = Visibility.Collapsed;
            }
            else if (selectedIndex == 4)
            {
                if (spNormalOptions != null)
                    spNormalOptions.Visibility = Visibility.Collapsed;
                if (spStochasticOptions != null)
                    spStochasticOptions.Visibility = Visibility.Collapsed;
                if (spMacdOptions != null)
                    spMacdOptions.Visibility = Visibility.Visible;
            }
            else if (selectedIndex == 5)
            {
                if (spNormalOptions != null)
                    spNormalOptions.Visibility = Visibility.Collapsed;
                if (spMacdOptions != null)
                    spMacdOptions.Visibility = Visibility.Collapsed;
                if (spStochasticOptions != null)
                    spStochasticOptions.Visibility = Visibility.Visible;
            }

            indicatorChart.BeginUpdate();
            foreach (var ser in indicatorChart.Series)
            {
                ser.Visibility = SeriesVisibility.Hidden;
            }
            if (selectedIndex == 0)
                atr.Visibility = SeriesVisibility.Visible;
            else if (selectedIndex == 1)
                rsi.Visibility = SeriesVisibility.Visible;
            else if (selectedIndex == 2)
                cci.Visibility = SeriesVisibility.Visible;
            else if (selectedIndex == 3)
                wi.Visibility = SeriesVisibility.Visible;
            else if (selectedIndex == 4)
            {
                macd.Visibility = SeriesVisibility.Visible;
                histogram.Visibility = SeriesVisibility.Visible;
            }
            else if (selectedIndex == 5)
            {
                stochastic.Visibility = SeriesVisibility.Visible;
            }
            indicatorChart.EndUpdate();
        }

        void OnCbPeriodValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            atr.Period = rsi.Period = cci.Period = wi.Period = CorrectValue(e.NewValue);
        }

        void OnFinancialChartRendered(object sender, RenderEventArgs e)
        {
            if (indicatorChart != null)
            {
                indicatorChart.AxisX.Min = ((IAxis)financialChart.AxisX).GetMin();
                indicatorChart.AxisX.Max = ((IAxis)financialChart.AxisX).GetMax();
            }
        }

        private void OnStochasticSmoothingPeriodValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (stochastic != null)
                stochastic.SmoothingPeriod = CorrectValue(e.NewValue, 1);
        }

        private void OnDPeriodValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (stochastic != null)
                stochastic.DPeriod = CorrectValue(e.NewValue);
        }

        private void OnKPeriodValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (stochastic != null)
                stochastic.KPeriod = CorrectValue(e.NewValue);
        }

        private void OnSmoothingPeriodValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (macd != null)
                macd.SmoothingPeriod = CorrectValue(e.NewValue);
            if (histogram != null)
                histogram.SmoothingPeriod = CorrectValue(e.NewValue);
        }

        private void OnSlowPeriodValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (macd != null)
                macd.SlowPeriod = CorrectValue(e.NewValue);
            if (histogram != null)
                histogram.SlowPeriod = CorrectValue(e.NewValue);
        }

        private void OnFastPeriodValueChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            if (macd != null)
                macd.FastPeriod = CorrectValue(e.NewValue);
            if (histogram != null)
                histogram.FastPeriod = CorrectValue(e.NewValue);
        }

        private int CorrectValue(double newValue, int minimum = 2)
        {
            return Math.Max(Math.Min(86, (int)newValue), minimum);
        }

        private void OnSplitterButtonClick(object sender, RoutedEventArgs e)
        {
            splitter.IsPaneOpen = !splitter.IsPaneOpen;
        }

        private void indicatorChart_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var pt = e.GetCurrentPoint(indicatorChart).Position;
            HandleTooltip(pt);
        }

        private void indicatorChart_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var pt = e.GetCurrentPoint(indicatorChart).Position;
            HandleTooltip(pt);
        }

        void HandleTooltip(Point pt)
        {
            var hitTest = indicatorChart.HitTest(pt);
            var series = hitTest != null ? hitTest.Series : null;
            if (series != null)
            {
                if (series == macd)
                {
                    indicatorChart.ToolTipContent = "Date: {Date}\u000AMACD: {Macd:n2}\u000ASignal: {Signal:n2}";
                }
                else if (series == stochastic)
                {
                    indicatorChart.ToolTipContent = "Date: {Date}\u000A%K: {K:n2}\u000A%D: {D:n2}";
                }
                else
                {
                    indicatorChart.ToolTipContent = "{seriesName}\u000ADate: {Date}\u000AY: {y:n2}\u000AVolume: {Volume:n0}";
                }
            }
        }
    }
}
