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

namespace MapsSamples
{
    public sealed partial class Grid : Page
    {
        C1VectorLayer vl;
        public Grid()
        {
            InitializeComponent();

            this.Loaded += Grid_Loaded;
            this.Unloaded += Grid_Unloaded;
        }

        void Grid_Unloaded(object sender, RoutedEventArgs e)
        {
            this.maps.Zoom = 2;
            this.maps.Center = new Point();
            this.maps.Layers.Clear();
        }

        void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Color fc = Colors.LightGray;// Color.FromArgb(0xff, 0xC0, 0x50, 0x4d);
            Color bk = Color.FromArgb(0xff, 0x44, 0x44, 0x44);
            Color bb = Colors.Black;
            maps.Foreground = new SolidColorBrush(fc);
            maps.Background = new SolidColorBrush(bk);
            maps.BorderBrush = new SolidColorBrush(bb);

            vl = new C1VectorLayer();

            SolidColorBrush stroke = new SolidColorBrush(Colors.LightGray);

            for (int lon = -180; lon <= 180; lon += 30)
            {
                DoubleCollection dc = new DoubleCollection();
                dc.Add(1); dc.Add(2);

                C1VectorPolyline pl = new C1VectorPolyline() { Stroke = stroke };
                PointCollection pc = new PointCollection();
                pc.Add(new Point(lon, -85));
                pc.Add(new Point(lon, +85));
                pl.Points = pc;
                vl.Children.Insert(0, pl);

                string lbl = Math.Abs(lon).ToString() + Strings.Degree;
                if (lon > 0)
                    lbl += Strings.East;
                else if (lon < 0)
                    lbl += Strings.West;

                C1VectorPlacemark pm = new C1VectorPlacemark()
                {
                    GeoPoint = new Point(lon, 0),
                    Label = lbl,
                    LabelPosition = LabelPosition.Top
                };
                vl.Children.Add(pm);
            }

            for (int lat = -80; lat <= 80; lat += 20)
            {
                DoubleCollection dc = new DoubleCollection();
                dc.Add(1); dc.Add(2);

                C1VectorPolyline pl = new C1VectorPolyline() { Stroke = stroke };
                PointCollection pc = new PointCollection();
                pc.Add(new Point(-180, lat));
                pc.Add(new Point(180, lat));
                pl.Points = pc;
                vl.Children.Insert(0, pl);

                string lbl = Math.Abs(lat).ToString() + Strings.Degree;
                if (lat > 0)
                    lbl += Strings.North;
                else if (lat < 0)
                    lbl += Strings.South;

                C1VectorPlacemark pm = new C1VectorPlacemark()
                {
                    GeoPoint = new Point(0, lat),
                    Label = lbl,
                    LabelPosition = LabelPosition.Right
                };
                vl.Children.Add(pm);
            }

            maps.Layers.Add(vl);
        }
    }
}
