using C1.Xaml;
using C1.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MapsSamples
{
    public sealed partial class ScaleTool : UserControl
    {
        public ScaleTool()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Identifies the <see cref="Maps"/> dependency property. 
        /// </summary>
        public static readonly DependencyProperty MapsProperty =
            DependencyProperty.Register(
                "Maps",
                typeof(C1Maps),
                typeof(ScaleTool),
                new PropertyMetadata(null, OnMapsPropertyChanged)
                );

        private static void OnMapsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ScaleTool).OnMapsChanged(e.OldValue as C1Maps);
        }

        private void OnMapsChanged(C1Maps oldMaps)
        {
            if (oldMaps != null)
            {
                oldMaps.ZoomChanged -= OnZoomChanged;
                oldMaps.CenterChanged -= OnCenterChanged;
                oldMaps.SizeChanged -= OnSizeChanged;
            }

            if (this.Maps != null)
            {
                this.Maps.ZoomChanged += OnZoomChanged;
                this.Maps.CenterChanged += OnCenterChanged;
                this.Maps.SizeChanged += OnSizeChanged;
                UpdateScale();
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="C1Maps" /> associated with this <see cref="C1Maps" />.
        /// </summary>
        public C1Maps Maps
        {
            get { return (C1Maps)GetValue(MapsProperty); }
            set
            {
                SetValue(MapsProperty, value);
            }
        }

        void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateScale();
        }

        void OnCenterChanged(object sender, PropertyChangedEventArgs<Point> e)
        {
            UpdateScale();
        }

        void OnZoomChanged(object sender, PropertyChangedEventArgs<double> e)
        {
            UpdateScale();
        }

        void UpdateScale()
        {
            UpdateScale(MetersScale, MetersLabel, 1, 1000, Strings.FRMeasurementLargeUnit, Strings.FRMeasurementUnit);
            UpdateScale(MilesScale, MilesLabel, 3.2808399, 5280, Strings.USMeasurementLargeUnit, Strings.USMeasurementUnit);
        }

        void UpdateScale(FrameworkElement scale, TextBlock label, double meterToUnit, double largeToSmall, string largeUnit, string unit)
        {
            if (scale == null)
                return;

            var minPixels = double.IsNaN(scale.MinWidth) ? 0 : scale.MinWidth;
            var maxPixels = double.IsNaN(scale.MaxWidth) ? 500 : scale.MaxWidth;

            var minDistance = GetDistance(minPixels) * meterToUnit;
            var maxDistance = GetDistance(maxPixels) * meterToUnit;

            var roundest = Roundest((int)minDistance, (int)maxDistance);
            if (roundest.ToString().Length <= Math.Ceiling(Math.Log10(largeToSmall)))
            {
                if (label != null)
                    label.Text = roundest + Strings.Space + unit;
            }
            else
            {
                minDistance /= largeToSmall;
                maxDistance /= largeToSmall;
                roundest = Roundest((int)minDistance, (int)maxDistance);
                if (label != null)
                    label.Text = roundest + Strings.Space + largeUnit;
            }

            var alpha = (roundest - minDistance) * 1.0 / (maxDistance - minDistance);
            scale.Width = Math.Max(minPixels * (1 - alpha) + maxPixels * alpha, 0);
        }

        // returns the distance in meters from the center of the map to a point 'pixels' pixels to the right
        double GetDistance(double pixels)
        {
            return C1Maps.Distance(Maps.Center, Maps.ScreenToGeographic(new Point(
                Maps.ActualWidth / 2 + pixels,
                Maps.ActualHeight / 2)));
        }

        // returns the largest number with more trailing zeros between min and max
        static int Roundest(int min, int max)
        {
            var maxs = max.ToString();
            var mins = min.ToString();

            for (int i = 0; i < maxs.Length; ++i)
            {
                if (maxs.Length > mins.Length || maxs[i] != mins[i])
                {
                    return int.Parse(maxs.Substring(0, i + 1).PadRight(maxs.Length, '0'));
                }
            }
            return max;
        }
    }
}
