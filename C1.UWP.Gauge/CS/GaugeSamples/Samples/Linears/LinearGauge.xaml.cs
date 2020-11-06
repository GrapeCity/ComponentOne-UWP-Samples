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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace GaugeSamples
{
    public sealed partial class LinearGauge : Page
    {
        bool _isPressed;

        public LinearGauge()
        {
            this.InitializeComponent();
        }

        private void OnPointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (_isPressed)
                myGauge.Value = PointToValue(e.GetCurrentPoint(myGauge).Position);
        }

        private void OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            myGauge.CapturePointer(e.Pointer);
            _isPressed = true;
        }

        private void OnPointerReleased(object sender, PointerRoutedEventArgs e)
        {
            myGauge.ReleasePointerCapture(e.Pointer);
            _isPressed = false;
        }

        double PointToValue(Point point)
        {
            double min = myGauge.ActualWidth * myGauge.XAxisLocation;
            double max = myGauge.ActualWidth * (1 - myGauge.XAxisLocation);
            if (point.X <= min)
                return 0;
            if (point.X >= max)
                return 100;
            double maxvalue = myGauge.ActualWidth * myGauge.XAxisLength;
            double locatX = point.X - min;
            return locatX / maxvalue * 100;
        }
    }
}
