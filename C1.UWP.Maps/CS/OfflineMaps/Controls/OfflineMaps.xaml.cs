using C1.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace OfflineMaps
{
    public sealed partial class OfflineMaps : UserControl
    {
        C1VectorLayer vl;
        Point currentPosition;

        public OfflineMaps()
        {
            this.InitializeComponent();

            this.Loaded += OnMapsLoaded;
            currentPosition = new Point(-76.9057, 40.2726);
            vl = new C1VectorLayer();
            this.maps.Layers.Add(vl);
        }

        void OnMapsLoaded(object sender, RoutedEventArgs e)
        {
            this.maps.Center = currentPosition;
            this.maps.Source = new OfflineMapsSource();
            AddMark(currentPosition);
        }

        private void AddMark(Point position)
        {
            Color clr = Colors.DarkRed;
            C1VectorPlacemark mark = new C1VectorPlacemark()
            {
                GeoPoint = position,
                LabelPosition = LabelPosition.Top,
                Geometry = Utils.CreateBaloon(),
                Fill = new SolidColorBrush(clr),
            };
            vl.Children.Add(mark);
            vl.LabelVisibility = LabelVisibility.Visible;
        }
    }

    public class OfflineMapsSource : C1MultiScaleTileSource
    {
        private const string uriFormat = @"ms-appx:/Resources/Tiles/{Z}/{X}/{Y}.png";

        public OfflineMapsSource()
            : base(0x8000000, 0x8000000, 0x100, 0x100, 0)
        { }

        protected override void GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY, IList<object> source)
        {
            if (tileLevel > 8)
            {
                var zoom = tileLevel - 8;
                var uri = uriFormat;

                uri = uri.Replace("{X}", tilePositionX.ToString());
                uri = uri.Replace("{Y}", tilePositionY.ToString());
                uri = uri.Replace("{Z}", zoom.ToString());
                source.Add(new Uri(uri));
            }
        }
    }
}
