using C1.Xaml.Sparkline;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;

namespace FlexGrid101
{
    /// <summary>
    /// Interaction logic for StockTicker.xaml
    /// </summary>
    [TemplatePart(Name = "LayoutRoot", Type = typeof(Grid))]
    [TemplatePart(Name = "Arrow", Type = typeof(Polygon))]
    [TemplatePart(Name = "TxtChange", Type = typeof(TextBlock))]
    [TemplatePart(Name = "TxtValue", Type = typeof(TextBlock))]
    [TemplatePart(Name = "SparkLine", Type = typeof(C1Sparkline))]
    public class StockTicker : Control
    {
        public static readonly DependencyProperty ValueProperty = 
            DependencyProperty.Register(
            "Value", 
            typeof(double), 
            typeof(StockTicker), 
            new PropertyMetadata(0.0, ValueChanged));

        string _format = "n2";
        Storyboard _flash;
        string _bindingSource;
        bool _firstTime = true;
        Grid _root;
        Polygon _arrow;
        TextBlock _txtChange;
        TextBlock _txtValue;
        ScaleTransform _stArrow;
        C1Sparkline _sparkLine;

        static Brush _brNegative = new SolidColorBrush(Colors.Red);
        static Brush _brPositive = new SolidColorBrush(Colors.Green);
        static Color _clrNegative = Color.FromArgb(100, 0xff, 0, 0);
        static Color _clrPositive = Color.FromArgb(100, 0, 0xff, 0);

        public StockTicker()
        {
            IsHitTestVisible = false;
            DefaultStyleKey = typeof(StockTicker);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _root = GetTemplateChild("LayoutRoot") as Grid;
            bool error = false;
            if (_root == null)
            {
                error = true;
            }
            else
            {
                _arrow = GetTemplateChild("Arrow") as Polygon;
                if (_arrow != null)
                {
                    _stArrow = _arrow.RenderTransform as ScaleTransform;
                }
                _txtChange = GetTemplateChild("TxtChange") as TextBlock;
                _txtValue = GetTemplateChild("TxtValue") as TextBlock;
                _sparkLine = GetTemplateChild("SparkLine") as C1Sparkline;
                   error |= _arrow == null || _txtChange == null || _txtValue == null || _stArrow == null || _sparkLine == null;
            }
            if (error)
            {
                throw new System.Exception("StockTicker ControlTemplate doesn't contain all required members");
            }
        }

        private Storyboard Flash
        {
            get
            {
                if (_flash == null)
                {
                    _flash = (Storyboard)_root.Resources["Flash"];
                }
                return _flash;
            }
        }
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        private static void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as StockTicker).OnValueChanged(e);
        }

        private void OnValueChanged(DependencyPropertyChangedEventArgs e)
        {
            var value = (double)e.NewValue;
            var oldValue = (double)e.OldValue;

            // resetting
            if (double.IsNaN(value))
            {
                if (_flash != null)
                {
                    _flash.Stop();
                }
                _root.Background = new SolidColorBrush(Colors.Transparent);
                _arrow.Fill = null;
                _txtChange.Foreground = _txtValue.Foreground;
                return;
            }

            // get historical data
            var data = Tag as FinancialData;
            var list = BindingSource != null ? data.GetHistory(BindingSource) : new System.Collections.Generic.List<decimal>();
            if (list != null && list.Count > 1)
            {
                oldValue = (double)list[list.Count - 2];
            }

            // calculate percentage change
            var change = oldValue == 0 || double.IsNaN(oldValue) ? 0 : (value - oldValue) / oldValue;

            // update text
            _txtValue.Text = value.ToString(_format);
            _txtChange.Text = string.Format(Strings.Change, change * 100);

            // update flash color
            ColorAnimation ca;

            // update symbol
            if (change == 0)
            {
                _arrow.Fill = null;
                _txtChange.Foreground = _txtValue.Foreground;
            }
            else if (change < 0)
            {
                _stArrow.ScaleY = -1;
                _txtChange.Foreground = _arrow.Fill = _brNegative;
                ca = Flash.Children[0] as ColorAnimation;
                ca.From = _clrNegative;
            }
            else
            {
                _stArrow.ScaleY = +1;
                _txtChange.Foreground = _arrow.Fill = _brPositive;
                ca = Flash.Children[0] as ColorAnimation;
                ca.From = _clrPositive;
            }

            // update sparkline
            if (list != null)
            {
                _sparkLine.Data = null;
                _sparkLine.Data = list;
            }

            // flash new value (but not right after the control was created)
            if (!_firstTime && change != 0)
            {
                _flash.Begin();
            }
            _firstTime = false;
        }

        public string BindingSource
        {
            get { return _bindingSource; }
            set { _bindingSource = value; }
        }
        public string Format
        {
            get { return _format; }
            set
            {
                _format = value;
                _txtValue.Text = Value.ToString(_format);
            }
        }
    }
}
