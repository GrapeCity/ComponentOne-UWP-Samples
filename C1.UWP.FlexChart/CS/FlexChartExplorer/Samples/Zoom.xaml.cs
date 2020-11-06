using System;
using System.Collections.Generic;
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
    public sealed partial class Zoom : Page
    {
        List<DataPoint> _function1Source;
        List<DataPoint> _function2Source;
        bool zooming = false;
        Point ptStart = new Point();

        public Zoom()
        {
            this.InitializeComponent();
            this.Loaded += Zoom_Loaded;
        }

        private void Zoom_Loaded(object sender, RoutedEventArgs e)
        {
            SetupChart();
        }

        void SetupChart()
        {
            flexChart.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
            flexChart.BeginUpdate();
            this.Function1.ItemsSource = Function1Source;
            this.Function2.ItemsSource = Function2Source;
            flexChart.EndUpdate();
        }

        public List<DataPoint> Function1Source
        {
            get
            {
                if (_function1Source == null)
                {
                    _function1Source = DataCreator.Create(x => 2 * Math.Sin(0.16 * x), y => 2 * Math.Cos(0.12 * y), 160);
                }
                
                return _function1Source;
            }
        }

        public List<DataPoint> Function2Source
        {
            get
            {
                if (_function2Source == null)
                {
                    _function2Source = DataCreator.Create(x => Math.Sin(0.1 * x), y => Math.Cos(0.15 * y), 160);
                }

                return _function2Source;
            }
        }

        private void PerformZoom(Point ptStart, Point ptLast)
        {
            var p1 = flexChart.PointToData(ptStart);
            var p2 = flexChart.PointToData(ptLast);
            flexChart.BeginUpdate();
            // Update axes with new limits
            flexChart.AxisX.Min = Math.Min(p1.X, p2.X);
            flexChart.AxisY.Min = Math.Min(p1.Y, p2.Y);
            flexChart.AxisX.Max = Math.Max(p1.X, p2.X);
            flexChart.AxisY.Max = Math.Max(p1.Y, p2.Y);
            flexChart.EndUpdate();
        }

        private void DrawReversibleRectangle(Point p1, Point p2)
        {
            // Normalize the rectangle
            var rc = new Rect(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y),
                Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y));

            // Draw the reversible frame
            reversibleFrame.Rect = rc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            flexChart.BeginUpdate();
            // Restore default values for axis limits
            flexChart.AxisX.Min = double.NaN;
            flexChart.AxisY.Min = double.NaN;
            flexChart.AxisX.Max = double.NaN;
            flexChart.AxisY.Max = double.NaN;
            flexChart.EndUpdate();
        }

        private void flexChart_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            reversibleFrameContainer.Visibility = Visibility.Visible;
            // Start zooming
            zooming = true;
            // Save starting point of selection rectangle
            ptStart = e.Position;
        }

        private void flexChart_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            // when zooming update selection range
            if (zooming)
            {
                var currentPosition = e.Position;
                Point ptCurrent = currentPosition;
                // Draw new frame
                DrawReversibleRectangle(ptStart, ptCurrent);
            }
        }

        private void flexChart_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            // End zooming
            zooming = false;
            reversibleFrameContainer.Visibility = Visibility.Collapsed;
            reversibleFrame.Rect = new Rect();
            var currentPosition = e.Position;
            PerformZoom(ptStart, currentPosition);
            //Clean up
            ptStart = new Point();
        }
    }
}
