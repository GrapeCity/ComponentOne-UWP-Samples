using C1.Chart;
using C1.Xaml;
using C1.Xaml.Chart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FlexChartExplorer
{
    public sealed partial class TrendLine : Page
    {
        C1DragHelper _dragHelper;
        DataItem clickedItem;
        Random rnd = new Random();
        ObservableCollection<DataItem> _data;
        List<string> _fitTypes;

        public TrendLine()
        {
            this.InitializeComponent();
            this.Loaded += HandleLoaded;
        }

        public ObservableCollection<DataItem> Data
        {
            get
            {
                if (_data == null)
                {
                    _data = new ObservableCollection<DataItem>();
                    for (int i = 1; i < 11; i++)
                    {
                        _data.Add(new DataItem() { X = i, Y = rnd.Next(100) });
                    }
                }

                return _data;
            }
        }

        public List<string> FitTypes
        {
            get
            {
                if (_fitTypes == null)
                {
                    _fitTypes = Enum.GetNames(typeof(FitType)).ToList();
                }

                return _fitTypes;
            }
        }

        public C1.Xaml.Chart.TrendLine TrendLineSeries
        {
            get
            {
                return trendLine;
            }
        }

        string GetEquationString(C1.Xaml.Chart.TrendLine trendLine)
        {
            string result = String.Empty;
            int X = 1, Y0 = 0;
            var order = trendLine.Order;

            switch (trendLine.FitType)
            {
                case FitType.Linear:
                    result = String.Format("y={1:0.0000}x{0:+0.0000;-0.0000;+0}", trendLine.Coefficients[0], trendLine.Coefficients[1]);
                    break;
                case FitType.Exponent:
                    result = String.Format("y={0:0.0000}e<sup>{1:0.0000}x</sup>", trendLine.Coefficients[0], trendLine.Coefficients[1]);
                    break;
                case FitType.Logarithmic:
                    result = String.Format("y={1:0.0000}ln(x){0:+0.0000;-0.0000;+0}", trendLine.Coefficients[0], trendLine.Coefficients[1]);
                    break;
                case FitType.Power:
                    result = String.Format("y={0:0.0000}x<sup>{1:0.0000}</sup>", trendLine.Coefficients[0], trendLine.Coefficients[1]);
                    break;
                case FitType.Polynom:
                    result = String.Format("{1:+0.0000;-0.0000;+0}x{0:+0.0000;-0.0000;+0}", trendLine.Coefficients[0], trendLine.Coefficients[1]);
                    for (int i = 2; i <= (int)order; i++)
                        result = result.Insert(0, String.Format("{0:+0.000;-0.0000;+0}x<sup>{1}</sup>", trendLine.Coefficients[i], i));
                    result = result.Remove(0, 1).Insert(0, "y=");
                    break;
                case FitType.Fourier:
                    result = String.Format("{0:+0.0000;-0.0000;+0}", trendLine.Coefficients[0]);
                    for (int i = 2, a = 1; i <= (int)order; i++, a = i % 2 == 0 ? a + 1 : a)
                        result += String.Format("{0:+0.000;-0.0000;+0}{2}({1}x)", trendLine.Coefficients[i - 1], a == 1 ? "" : a.ToString(), (i) % 2 == 0 ? "cos" : "sin");
                    result = result.Remove(0, 1).Insert(0, "y=");
                    break;
                case FitType.MaxX: result = "x=" + trendLine.GetValues(X).Max(); break;
                case FitType.MinX: result = "x=" + trendLine.GetValues(X).Min(); break;
                case FitType.MaxY: result = "y=" + trendLine.GetValues(Y0).Max(); break;
                case FitType.MinY: result = "y=" + trendLine.GetValues(Y0).Min(); break;
                case FitType.AverageX: result = "x=" + trendLine.GetValues(X).Average(); break;
                case FitType.AverageY: result = "y=" + trendLine.GetValues(Y0).Average(); break;
            }
            return result;
        }

        #region Event Handler

        void HandleLoaded(object sender, RoutedEventArgs e)
        {
            _dragHelper = new C1DragHelper(flexChart, C1DragHelperMode.TranslateXY, captureElementOnPointerPressed:true, useManipulationEvents:true);
            _dragHelper.DragStarted += HandleDragStarted;
            _dragHelper.DragDelta += HandleDragDelta;
            _dragHelper.DragCompleted += HandleDragCompleted;
            Window.Current.CoreWindow.PointerCursor = new CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
        }

        void HandlePointerPressed(object sender, PointerRoutedEventArgs e)
        {
            var ht = flexChart.HitTest(e.GetCurrentPoint(flexChart).Position);
            if (ht.Distance < 3 && ht.X != null && ht.Y != null)
            {
                clickedItem = ht.Item as DataItem;
            }
        }

        void HandleDragStarted(object sender, C1DragStartedEventArgs e)
        {
            var ht = flexChart.HitTest(e.GetPosition(flexChart));
            if (ht.Distance < 3 && ht.X != null && ht.Y != null)
            {
                clickedItem = ht.Item as DataItem;
            }
        }

        void HandleDragDelta(object sender, C1DragDeltaEventArgs e)
        {
            if (clickedItem != null)
            {
                var newY = (int)flexChart.PointToData(e.GetPosition(flexChart)).Y;
                if (newY >= 0 && newY <= 100)
                {
                    clickedItem.Y = newY;
                }
            }
        }

        void HandleDragCompleted(object sender, C1DragCompletedEventArgs e)
        {
            clickedItem = null;
        }

        void HandleRendered(object sender, RenderEventArgs e)
        {
            rich.Html = GetEquationString(trendLine);
        }

        #endregion

        #region DataItem

        public class DataItem : INotifyPropertyChanged
        {
            int _y;
            public int X { get; set; }

            public int Y
            {
                get { return _y; }
                set
                {
                    if (value == _y) return;
                    _y = value;

                    OnPropertyChanged("Y");
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
