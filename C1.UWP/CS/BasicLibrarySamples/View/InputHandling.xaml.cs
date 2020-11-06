using C1.Xaml;
using System;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace BasicLibrarySamples
{
    public partial class InputHandling : Page
    {
        private C1DragHelper _dragHelper;
        private C1ZoomHelper _zoomHelper;
        private Random _rand = new Random();

        public InputHandling()
        {
            InitializeComponent();

            _dragHelper = new C1DragHelper(FramePanel, C1DragHelperMode.TranslateXY | C1DragHelperMode.Inertia, captureElementOnPointerPressed: false);
            _dragHelper.DragStarting += OnDragStarting;
            _dragHelper.DragStarted += OnDragStarted;
            _dragHelper.DragDelta += OnDragDelta;
            _dragHelper.DragCompleted += OnDragCompleted;
            _dragHelper.DragInertiaStarted += OnDragInertiaStarted;

            _zoomHelper = new C1ZoomHelper(FramePanel, ctrlRequired: false);
            _zoomHelper.ZoomStarted += OnZoomStarted;
            _zoomHelper.ZoomDelta += OnZoomDelta;
            _zoomHelper.ZoomCompleted += OnZoomCompleted;

            Rectangle.Tapped += OnTapped;
        }

        #region ** tapped

        void OnTapped(object sender, TappedRoutedEventArgs e)
        {
            Rectangle.Background = GetRandomBrush();
        }

        #endregion

        #region ** drag
        void OnDragStarting(object sender, C1DragStartingEventArgs e)
        {
        }

        double _initialX, _initialY;

        void OnDragStarted(object sender, EventArgs e)
        {
            var position = GetPosition();
            _initialX = position.X;
            _initialY = position.Y;
        }

        void OnDragDelta(object sender, C1DragDeltaEventArgs e)
        {
            var zoom = GetZoom();
            var maxX = FramePanel.ActualWidth - Rectangle.ActualWidth * zoom;
            var maxY = FramePanel.ActualHeight - Rectangle.ActualHeight * zoom;
            var newX = _initialX + e.CumulativeTranslation.X;
            var newY = _initialY + e.CumulativeTranslation.Y;
            if (e.IsInertial)
                Bounce(maxX, maxY, ref newX, ref newY);
            else
                Clip(maxX, maxY, ref newX, ref newY);
            SetPosition(new Point(newX, newY));
        }

        void OnDragInertiaStarted(object sender, EventArgs e)
        {
        }

        void OnDragCompleted(object sender, EventArgs e)
        {
            Rectangle.Background = GetRandomBrush();
        }

        #endregion

        #region ** zoom

        double _initialZoom;
        Point _initialPosition;
        Point _relativePosition;

        void OnZoomStarted(object sender, C1ZoomStartedEventArgs e)
        {
            _dragHelper.Complete();
            _initialZoom = GetZoom();
            _initialPosition = GetPosition();
            _relativePosition = e.GetPosition(Rectangle);
        }

        void OnZoomDelta(object sender, C1ZoomDeltaEventArgs e)
        {
            var maxZoom = Math.Min(ActualWidth / Rectangle.ActualWidth, ActualHeight / Rectangle.ActualHeight) / 2;
            var newZoom = Math.Min(maxZoom, _initialZoom * e.UniformCumulativeScale);
            var maxX = FramePanel.ActualWidth - Rectangle.ActualWidth * newZoom;
            var maxY = FramePanel.ActualHeight - Rectangle.ActualHeight * newZoom;
            double newX, newY;
            Zoom(maxZoom, _initialZoom, _initialPosition, _relativePosition, newZoom, out newX, out newY);
            Clip(maxX, maxY, ref newX, ref newY);
            SetZoom(newZoom, newX, newY);
        }

        void OnZoomInertiaStarted(object sender, EventArgs e)
        {
        }

        void OnZoomCompleted(object sender, C1ZoomCompletedEventArgs e)
        {
            var maxZoom = Math.Min(ActualWidth / Rectangle.ActualWidth, ActualHeight / Rectangle.ActualHeight) / 2;
            var newZoom = Math.Min(maxZoom, _initialZoom * e.UniformCumulativeScale);
            var maxX = FramePanel.ActualWidth - Rectangle.ActualWidth * newZoom;
            var maxY = FramePanel.ActualHeight - Rectangle.ActualHeight * newZoom;
            double newX, newY;
            Zoom(maxZoom, _initialZoom, _initialPosition, _relativePosition, newZoom, out newX, out newY);
            Clip(maxX, maxY, ref newX, ref newY);
            SetZoom(newZoom, newX, newY);
        }

        #endregion

        #region ** implementation

        private SolidColorBrush GetRandomBrush()
        {
            byte[] buffer = new byte[3];
            _rand.NextBytes(buffer);
            return new SolidColorBrush(Color.FromArgb(0xFF, buffer[0], buffer[1], buffer[2]));
        }

        private static void Clip(double maxX, double maxY, ref double newX, ref double newY)
        {
            newX = Math.Max(0, Math.Min(maxX, newX));
            newY = Math.Max(0, Math.Min(maxY, newY));
        }

        private static void Bounce(double maxX, double maxY, ref double newX, ref double newY)
        {
            if (newX < 0)
                newX = (int)(newX / maxX) % 2 == 0 ? -(newX % maxX) : maxX + (newX % maxX);
            else
                newX = (int)(newX / maxX) % 2 == 0 ? newX % maxX : maxX - (newX % maxX);
            if (newY < 0)
                newY = (int)(newY / maxY) % 2 == 0 ? -(newY % maxY) : maxY + (newY % maxY);
            else
                newY = (int)(newY / maxY) % 2 == 0 ? newY % maxY : maxY - (newY % maxY);
        }

        private static void Zoom(double maxZoom, double initialZoom, Point initialPosition, Point relativePosition, double zoom, out double newX, out double newY)
        {
            newX = initialPosition.X + ((relativePosition.X * initialZoom) - (relativePosition.X * zoom));
            newY = initialPosition.Y + ((relativePosition.Y * initialZoom) - (relativePosition.Y * zoom));
        }

        private Point GetPosition()
        {
            var transform = Rectangle.RenderTransform as CompositeTransform;
            return new Point(transform.TranslateX, transform.TranslateY);
        }

        private void SetPosition(Point position)
        {
            var transform = Rectangle.RenderTransform as CompositeTransform;
            transform.TranslateX = position.X;
            transform.TranslateY = position.Y;
        }

        private double GetZoom()
        {
            var transform = Rectangle.RenderTransform as CompositeTransform;
            return transform.ScaleX;
        }

        private void SetZoom(double zoom, double x, double y)
        {
            var transform = Rectangle.RenderTransform as CompositeTransform;
            transform.ScaleX = zoom;
            transform.ScaleY = zoom;
            transform.TranslateX = x;
            transform.TranslateY = y;
        }

        #endregion
    }
}
