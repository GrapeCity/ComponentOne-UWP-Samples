using C1.Xaml;
using C1.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.UI.Xaml.Shapes;

namespace MapsSamples
{
    public sealed partial class Marks : Page
    {
        #region fields
        C1VectorLayer vl;
        Random rnd = new Random();
        C1VectorPlacemark current = null;
        Dictionary<C1VectorPlacemark, Path> shapes;
        int idx = 1;
        Canvas placeHolder;
        double offsetX;
        double offsetY;
        bool isCapture = false;
        #endregion

        public Marks()
        {
            InitializeComponent();

            shapes = new Dictionary<C1VectorPlacemark, Path>();
            this.Loaded += Marks_Loaded;
            this.Unloaded += Marks_Unloaded;

            comboSources.ItemsSource = Enum.GetValues(typeof(Sources));
            comboSources.SelectedItem = Sources.VirtualEarthRoad;
        }

        void Marks_Unloaded(object sender, RoutedEventArgs e)
        {
            c1Maps1.RightTapped -= maps_RightTapped;
            shapes.Clear();
            comboSources.SelectedIndex = 0;
            idx = 1;
            this.c1Maps1.Zoom = 0;
            this.c1Maps1.Center = new Point();
            this.c1Maps1.Layers.Clear();
        }

        void Marks_Loaded(object sender, RoutedEventArgs e)
        {
            vl = new C1VectorLayer();
            c1Maps1.Layers.Add(vl);
            c1Maps1.RightTapped += maps_RightTapped;
            c1Maps1.TargetCenter = new Point(0, 20);
            c1Maps1.Zoom = 2;
            for (int i = 0; i < 10; i++)
            {
                // create random coordinates
                Point pt = new Point(-80 + rnd.Next(160), -80 + rnd.Next(160));
                AddMark(pt);
            }
        }

        void maps_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            AddMark(c1Maps1.ScreenToGeographic(e.GetPosition(c1Maps1)));
        }

        void mark_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (!isCapture)
                return;
            isCapture = false;
            if (current != null)
            {
                vl.Children.Add(current);
                var currentPosition = e.Container.C1TransformToVisual(c1Maps1).TransformPoint(e.Position);
                current.GeoPoint = this.c1Maps1.ScreenToGeographic(new Point(currentPosition.X - offsetX, currentPosition.Y - offsetY));
                var timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 120);
                timer.Tick += (s, e1) =>
                {
                    timer.Stop();
                    if (root.Children.Contains(placeHolder))
                    {
                        root.Children.Remove(placeHolder);
                    }
                    if (placeHolder != null)
                    {
                        placeHolder.Children.Clear();
                        placeHolder = null;
                    }
                };
                timer.Start();
            }
            current = null;
            offsetX = 0;
            offsetY = 0;
            e.Handled = true;
        }

        void mark_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (current == null || !isCapture)
            {
                return;
            }
            Point pt = e.Container.C1TransformToVisual(c1Maps1).TransformPoint(e.Position);
            if (placeHolder != null)
            {
                placeHolder.RenderTransform = new TranslateTransform() { X = pt.X - offsetX, Y = pt.Y - offsetY };
            }
            e.Handled = true;
        }

        void mark_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            current = sender as C1VectorPlacemark;

            if (current == null || !isCapture)
                return;

            vl.Children.Remove(current);
            if (placeHolder == null)
            {
                placeHolder = new Canvas();
                Shape shape = null;
                if (shapes.Keys.Contains(current))
                {
                    shape = shapes[current];
                }
                else
                {
                    shape = InitShape(current);
                }
                placeHolder.Children.Add(shape);
                var textBlock = InitLabel(current);
                placeHolder.Children.Add(textBlock);
                var pt = this.c1Maps1.GeographicToScreen(this.current.GeoPoint);
                var currentPosition = e.Container.C1TransformToVisual(c1Maps1).TransformPoint(e.Position);
                offsetX = currentPosition.X - pt.X;
                offsetY = currentPosition.Y - pt.Y;
                placeHolder.RenderTransform = new TranslateTransform() { X = pt.X, Y = pt.Y };
            }
            if (!this.root.Children.Contains(placeHolder))
            {
                this.root.Children.Add(placeHolder);
            }
            e.Handled = true;
        }

        void mark_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (placeHolder != null)
            {
                if (root.Children.Contains(placeHolder))
                {
                    root.Children.Remove(placeHolder);
                }
            }
            e.Handled = true;
            vl.Children.Remove((C1VectorPlacemark)sender);
        }


        private Path InitShape(C1VectorPlacemark place)
        {
            Path path = new Path()
            {
                Fill = place.Fill,
                Stroke = place.Stroke,
                StrokeThickness = place.StrokeThickness,
                StrokeDashArray = place.StrokeDashArray,
                StrokeStartLineCap = place.StrokeStartLineCap,
                StrokeEndLineCap = place.StrokeEndLineCap,
                StrokeDashCap = place.StrokeDashCap,
                StrokeLineJoin = place.StrokeLineJoin,
                StrokeDashOffset = place.StrokeDashOffset,
                StrokeMiterLimit = place.StrokeMiterLimit,
                Data = place.Geometry
            };
            shapes.Add(place, path);

            return path;
        }

        private TextBlock InitLabel(C1VectorPlacemark place)
        {
            TextBlock text = place.Label as TextBlock;
            text.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
            var desiredSize = text.DesiredSize;
            double left = 0;
            double top = 2;

            if (text != null)
            {
                switch (place.LabelPosition)
                {
                    case LabelPosition.Center:
                        left = left - 0.5 * desiredSize.Width;
                        top = top - 0.5 * desiredSize.Height;
                        break;
                    case LabelPosition.Bottom:
                        left = left - 0.5 * desiredSize.Width;
                        break;
                    case LabelPosition.Top:
                        left = left - 0.5 * desiredSize.Width;
                        top = top - desiredSize.Height;
                        break;
                    case LabelPosition.Left:
                        left = left - desiredSize.Width;
                        top = top - 0.5 * desiredSize.Height;
                        break;
                    case LabelPosition.Right:
                        top = top - 0.5 * desiredSize.Height;
                        break;
                }
                Canvas.SetLeft(text, left);
                Canvas.SetTop(text, top);
            }

            return text;
        }

        void AddMark(Point pt)
        {
            Color clr = Colors.DarkRed;
            C1VectorPlacemark mark = new C1VectorPlacemark()
            {
                GeoPoint = pt,
                Label = new TextBlock()
                {
                    RenderTransform = new TranslateTransform() { Y = -5 },
                    IsHitTestVisible = false,
                    FontSize = 18,
                    Foreground = new SolidColorBrush(Colors.White),
                    Margin = new Thickness(0, 20, 0, 18),
                    Text = idx.ToString()
                },
                LabelPosition = LabelPosition.Top,
                Geometry = Utils.CreateBaloon(),
                Fill = root.Resources["MarkFill"] as SolidColorBrush
            };

            mark.PointerPressed += mark_PointerPressed;
            mark.ManipulationStarted += mark_ManipulationStarted;
            mark.ManipulationDelta += mark_ManipulationDelta;
            mark.ManipulationCompleted += mark_ManipulationCompleted;
            mark.ManipulationMode = ManipulationModes.TranslateX | ManipulationModes.TranslateY;
            
            vl.Children.Add(mark);
            vl.LabelVisibility = LabelVisibility.Visible;

            mark.DoubleTapped += mark_DoubleTapped;
            idx++;
        }

        void mark_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            isCapture = true;
            e.Handled = true;
        }

        

        private void comboSources_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Source = (Sources)comboSources.SelectedItem;
        }

        public enum Sources
        {
            VirtualEarthAerial,
            VirtualEarthRoad,
            VirtualEarthHybrid,
        };

        Dictionary<Sources, MultiScaleTileSource> sourcesMap = new Dictionary<Sources, MultiScaleTileSource> 
		{ 
			{Sources.VirtualEarthAerial, new VirtualEarthAerialSource() },
			{Sources.VirtualEarthRoad, new VirtualEarthRoadSource() },
			{Sources.VirtualEarthHybrid, new VirtualEarthHybridSource() },
		};

        Sources _source;
        public Sources Source
        {
            get { return _source; }
            set
            {
                _source = value;
                c1Maps1.Source = sourcesMap[_source];
            }
        }
    }
}
