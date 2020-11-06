using C1.Xaml.Gauge;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace GaugeSamples
{
    public sealed partial class RadialGauge : Page
    {

        bool _isPressed;

        public RadialGauge()
        {
            this.InitializeComponent();
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            myGauge.CapturePointer(e.Pointer);
            _isPressed = true;
        }

        private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if(_isPressed)
                myGauge.Value = PointToValue(e.GetCurrentPoint(myGauge).Position);
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            myGauge.ReleasePointerCapture(e.Pointer);
            _isPressed = false;
        }


        double PointToValue(Point point)
        {
            Point center = new Point(myGauge.PointerOrigin.X * myGauge.RenderSize.Width, myGauge.PointerOrigin.Y * myGauge.RenderSize.Height);
            double angle = Mod360(Math.Atan2(point.X - center.X, center.Y - point.Y) * 180 / Math.PI);
            return AngleToValue(angle);
        }

        double Mod360(double value)
        {
            double result = value % 360;
            if (value < 0)
            {
                result += 360;
            }
            return result;
        }

        double AngleToValue(double angle)
        {
            double alpha = AngleToLogical(angle);
            return LogicalToValue(alpha);
        }

        double AngleToLogical(double angle)
        {
            var relativeAngle = Mod360(angle - myGauge.StartAngle);
            var absSweepAngle = myGauge.SweepAngle;
            if (absSweepAngle == 0 || relativeAngle == 0)
                return 0;
            if (absSweepAngle < 0)
            {
                relativeAngle = 360 - relativeAngle;
                absSweepAngle = -absSweepAngle;
            }
            var overflow = relativeAngle - absSweepAngle;
            if (overflow > 0)
            {
                var underflow = 360 - relativeAngle;
                return overflow < underflow ? 1 : 0;
            }
            return relativeAngle / absSweepAngle;
        }

        double LogicalToValue(double alpha)
        {
            if (alpha <= 0)
                return myGauge.Minimum;
            if (1 <= alpha)
                return myGauge.Maximum;

            double linearValue;
            if (!myGauge.IsLogarithmic)
            {
                linearValue = alpha;
            }
            else
            {
                if (myGauge.LogarithmicBase <= 1)
                    return myGauge.Minimum;

                linearValue = (Math.Pow(myGauge.LogarithmicBase, alpha) - 1) / (myGauge.LogarithmicBase - 1);
            }
            return (myGauge.Minimum + (myGauge.Maximum - myGauge.Minimum) * linearValue);
        }
    }

    class ValueTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((double)value).ToString("F0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
