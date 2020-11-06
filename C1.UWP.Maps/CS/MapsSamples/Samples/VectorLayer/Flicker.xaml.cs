using C1.Xaml;
using C1.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MapsSamples
{
    public sealed partial class Flicker : Page
    {
        DispatcherTimer _timer;
        public Flicker()
        {
            InitializeComponent();

            this.Loaded += Flicker_Loaded;
            this.Unloaded += Flicker_Unloaded;
            btnLoad.IsEnabledChanged += (s, e) =>
            {
                btnLoad.Content = btnLoad.IsEnabled ? Strings.Load : Strings.Loading;
            };

            maps.TargetZoom = 4;
        }

        void Flicker_Unloaded(object sender, RoutedEventArgs e)
        {
            txt.Visibility = Visibility.Visible;
            this.maps.Zoom = 0;
            this.maps.Center = new Point();
            this.maps.Opacity = 0.5;
            this.maps.TargetCenter = new Point();
            _timer.Stop();

            
        }

        void Flicker_Loaded(object sender, RoutedEventArgs e)
        {
            this.maps.Zoom = 0;
            // shuffle images in z-order
            vl = maps.Layers[0] as C1VectorLayer;
            _timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(0.5) };
            _timer.Tick += (ts, te) =>
            {
                int cnt = vl.Children.Count;
                if (cnt >= 2)
                {
                    vl.BeginUpdate();

                    C1VectorItemBase item = vl.Children[0];
                    vl.Children.RemoveAt(0);
                    vl.Children.Add(item);

                    vl.EndUpdate();
                }
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb.Text))
            {
                string source = string.Format("http://api.flickr.com/services/feeds/geo/{0}", tb.Text);
                if (vl != null)
                {
                    _timer.Stop();
                    vl.UriSource = new Uri(source);
                    btnLoad.IsEnabled = tb.IsEnabled = false;
                    txt.Text = Strings.Loading1;
                    txt.Visibility = Visibility.Visible;
                    maps.Opacity = 0.5;
                }
            }
        }

        private void Border_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Border bdr = (Border)sender;
            
            ShowImage(bdr, "");
            ShowModalWindow();

            // Find other images covered by the current images
            Point pt0 = e.GetPosition(bdr);

            Point pt = e.GetPosition(maps);
            Point pt1 = pt, pt2 = pt;
            pt1.X -= pt0.X;
            pt1.Y -= pt0.Y;
            pt2.X = pt1.X + bdr.ActualWidth;
            pt2.Y = pt1.Y + bdr.ActualWidth;

            pt1 = maps.ScreenToGeographic(pt1);
            pt2 = maps.ScreenToGeographic(pt2);

            Point min = new Point(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y));
            Point max = new Point(Math.Max(pt1.X, pt2.X), Math.Max(pt1.Y, pt2.Y));

            List<C1VectorPlacemark> list = new List<C1VectorPlacemark>();

            foreach (C1VectorPlacemark pm in vl.Children)
            {
                if (pm.GeoPoint.X >= min.X && pm.GeoPoint.X <= max.X &&
                  pm.GeoPoint.Y >= min.Y && pm.GeoPoint.Y <= max.Y)
                {
                    list.Add(pm);
                }
            }

            // start "slideshow"
            if (list.Count > 1)
            {
                DispatcherTimer dp;
                int tcnt = 0;

                dp = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(2) };
                dp.Tick += (se, ea) =>
                {
                    tcnt++;
                    if (tcnt >= list.Count)
                        tcnt = 0;

                    ShowImage(list[tcnt].LabelUI as FrameworkElement,
                      string.Format("{0}/{1} ", tcnt + 1, list.Count));
                };

                popup.Closed += (s1, e1) =>
                {
                    dp.Stop();
                };

                dp.Start();
            }
        }

        private void ShowImage(FrameworkElement lbl, string header)
        {
            if (lbl != null)
            {
                Image im = lbl.FindName("img") as Image;
                if (im != null)
                    contImg.Source = im.Source;
                TextBlock tb = lbl.FindName("txt") as TextBlock;
                if (tb != null)
                    tbHeader.Text = header + tb.Text;
            }
        }

        private void ShowModalWindow()
        {
            //First we need to find out how big our window is, so we can center to it.
            CoreWindow currentWindow = Window.Current.CoreWindow;

            //Set our background rectangle to fill the entire window
            mask.Height = currentWindow.Bounds.Height;
            mask.Width = currentWindow.Bounds.Width;
            mask.Margin = new Thickness(0, 0, 0, 0);

            //Make sure the background is visible
            mask.Visibility = Windows.UI.Xaml.Visibility.Visible;

            //Here is where I get a bit tricky.  You see popMessage.ActualWidth will show
            //the full screen width, and not the actual width of the popup, and popMessage.Width
            //will show 0 at this point.  So we needed to calculate the actual
            //display width.  I do this by using a calculation that determines the
            //scaling percentage from the height, and then calculates that against my
            //original width coding.
            popup.HorizontalOffset = (currentWindow.Bounds.Width / 2) - (400 / 2);
            popup.VerticalOffset = (currentWindow.Bounds.Height / 2 - (440 / 2));
            popup.IsOpen = true;
        }

        private void btnClose_Tapped(object sender, TappedRoutedEventArgs e)
        {
            mask.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            popup.IsOpen = false;
        }

        double _zoom = 0;

        private void vl_UriSourceFailed(object sender, EventArgs e)
        {
            txt.Text = Strings.CannotLoadMessage;
            btnLoad.IsEnabled = tb.IsEnabled = true;
        }

        private void vl_UriSourceLoaded(object sender, EventArgs e)
        {
            txt.Visibility = Visibility.Collapsed;
            maps.Opacity = 1;
            btnLoad.IsEnabled = tb.IsEnabled = true;
            _timer.Start();

            C1VectorLayer vl = (C1VectorLayer)sender;
            Rect bnds = vl.Children.GetBounds();
            if (!bnds.IsEmpty)
            {
                maps.TargetCenter = new Point(bnds.Left + 0.5 * bnds.Width, bnds.Top + 0.5 * bnds.Height);

                double w = maps.ActualWidth > 0 ? maps.ActualWidth : 500;
                double h = maps.ActualHeight > 0 ? maps.ActualHeight : 500;

                double scale = Math.Max(bnds.Width / 360 * w,
                      bnds.Height / 180 * h); ;
                _zoom = Math.Log(512 / Math.Max(scale, 1), 2.0);
                maps.CenterChanged += (maps_CenterChanged);
            }
        }

        void maps_CenterChanged(object sender, PropertyChangedEventArgs<Point> e)
        {
            if (maps.TargetCenter == maps.Center)
            {
                maps.CenterChanged -= (maps_CenterChanged);
                maps.TargetZoom = _zoom;
            }
        }

        private void tb_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                Button_Click(btnLoad, new RoutedEventArgs());
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, string language)
        {
            XElement xe = value as XElement;

            if (xe != null)
            {
                var content = xe.Element(xe.GetDefaultNamespace() + "content");
                if (content != null)
                {
                    string s = content.Value;
                    if (!string.IsNullOrEmpty(s))
                    {
                        int i1 = s.IndexOf("http://farm");
                        if (i1 >= 0)
                        {
                            int i2 = s.IndexOf(".jpg", i1);
                            if (i2 >= 0)
                            {
                                return s.Substring(i1, i2 - i1 + ".jpg".Length);
                            }
                        }
                    }
                }
            }

            return null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
