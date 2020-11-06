using System;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace AnnotationExplorer
{
    /// <summary>
    /// Interaction logic for Basic.xaml
    /// </summary>
    public partial class Basic : Page
    {
        public Basic()
        {
            InitializeComponent();
            this.Loaded += OnBasicLoaded;
        }

        private void OnBasicLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var pngImage = new BitmapImage(new Uri("ms-appx:///AnnotationExplorerLib/Assets/Image.png"));
            imageAnno.Source = pngImage;
            AddPoints(polygonAnno.Points);
            flexChart.Invalidate();
        }

        void AddPoints(PointCollection pts)
        {
            if (Util.IsWindowsDevice)
            {
                pts.Add(new Point(100, 25));
                pts.Add(new Point(50, 70));
                pts.Add(new Point(75, 115));
                pts.Add(new Point(125, 115));
                pts.Add(new Point(150, 70));
            }
            else
            {
                pts.Add(new Point(200, 25));
                pts.Add(new Point(150, 70));
                pts.Add(new Point(175, 115));
                pts.Add(new Point(225, 115));
                pts.Add(new Point(250, 70));
            }
        }
    }
}
