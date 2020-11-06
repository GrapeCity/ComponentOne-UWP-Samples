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
    public sealed partial class CustomTileSource : Page
    {
        public CustomTileSource()
        {
            this.InitializeComponent();
            this.OSMSource.Source = new OpenStreetMapsSource();
            this.Unloaded += CustomTileSource_Unloaded;
        }

        void CustomTileSource_Unloaded(object sender, RoutedEventArgs e)
        {
            this.OSMSource.Zoom = 1;
            this.OSMSource.Center = new Point();
        }

        public class OpenStreetMapsSource : C1MultiScaleTileSource
        {
            private readonly string[] tilePathPrefixes = new[] { "a", "b", "c" };
            private readonly Random rand = new Random();
            private const string uriFormat = @"http://{S}.tile.openstreetmap.org/{Z}/{X}/{Y}.png";

            public OpenStreetMapsSource()
                : base(0x8000000, 0x8000000, 0x100, 0x100, 0)
            { }

            protected override void GetTileLayers(int tileLevel, int tilePositionX, int tilePositionY, IList<object> sources)
            {
                if (tileLevel > 8)
                {
                    var zoom = tileLevel - 8;
                    var prefix = tilePathPrefixes[rand.Next(3)];
                    var url = uriFormat;

                    url = url.Replace("{S}", prefix);
                    url = url.Replace("{Z}", zoom.ToString());
                    url = url.Replace("{X}", tilePositionX.ToString());
                    url = url.Replace("{Y}", tilePositionY.ToString());
                    sources.Add(new Uri(url));
                }
            }
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            this.OSMSource.TargetZoom += 1.0;
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            this.OSMSource.TargetZoom -= 1.0;
        }

    }
}
