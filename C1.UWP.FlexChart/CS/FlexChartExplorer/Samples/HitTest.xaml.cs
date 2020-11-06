using System;
using System.Collections.Generic;
using System.Text;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FlexChartExplorer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HitTest : Page
    {
        List<DataPoint> _data1;
        List<DataPoint> _data2;

        public HitTest()
        {
            this.InitializeComponent();
            this.Loaded += HitTest_Loaded;
        }

        private void HitTest_Loaded(object sender, RoutedEventArgs e)
        {
            SetupChart();
        }

        void SetupChart()
        {
            flexChart.BeginUpdate();
            series0.ItemsSource = Data1;
            series1.ItemsSource = Data2;
            flexChart.EndUpdate();
        }

        void HitTestOnFlexChart(Point p)
        {
            // Show information about chart element under mouse/touch.
            var ht = flexChart.HitTest(p);
            var result = new StringBuilder();
            result.AppendLine(string.Format("Chart element:{0}", ht.ChartElement));
            if (ht.Series != null)
                result.AppendLine(string.Format("Series name:{0}", ht.Series.Name));
            if (ht.PointIndex > 0)
                result.AppendLine(string.Format("Point index={0:0}", ht.PointIndex));
            tbPosition1.Text = result.ToString();

            var result2 = new StringBuilder();
            if (ht.Distance > 0)
                result2.AppendLine(string.Format("Distance={0:0}", ht.Distance));
            if (ht.X != null)
                result2.AppendLine(string.Format("X={0:0:0}", ht.X));
            if (ht.Y != null)
                result2.AppendLine(string.Format("Y={0:0:0}", ht.Y));
            tbPosition2.Text = result2.ToString();
        }

        public List<DataPoint> Data1
        {
            get
            {
                if (_data1 == null)
                {
                    _data1 = DataCreator.Create(x => Math.Sin(x), 0, 60, 7);
                }

                return _data1;
            }
        }

        public List<DataPoint> Data2
        {
            get
            {
                if (_data2 == null)
                {
                    _data2 = DataCreator.Create(x => Math.Sin(x + 5), 0, 60, 7);
                }

                return _data2;
            }
        }

        private void flexChart_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            HitTestOnFlexChart(e.GetCurrentPoint(flexChart).Position);
        }

        private void flexChart_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            HitTestOnFlexChart(e.GetCurrentPoint(flexChart).Position);
        }
    }
}
