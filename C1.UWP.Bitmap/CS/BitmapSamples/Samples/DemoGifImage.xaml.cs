using System;
using System.Reflection;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace BitmapSamples
{
    public sealed partial class DemoGifImage : Page
    {
        static PropertyInfo piIsAnimatedBitmap;
        static MethodInfo miPlay, miStop;

        static DemoGifImage()
        {
            if (ApiInformation.IsPropertyPresent("Windows.UI.Xaml.Media.Imaging.BitmapImage", "IsAnimatedBitmap"))
            {
                var bitmapImageType = typeof(BitmapImage);
                piIsAnimatedBitmap = bitmapImageType.GetProperty("IsAnimatedBitmap");
                miPlay = bitmapImageType.GetMethod("Play");
                miStop = bitmapImageType.GetMethod("Stop");
            }
        }

        public DemoGifImage()
        {
            InitializeComponent();

            gifImage.ImageOpened += GifImage_ImageOpened;
            gifImage.UriSource = new Uri("ms-appx:///BitmapSamplesLib/Assets/C1FlexChartZoom.gif");
        }

        private void GifImage_ImageOpened(object sender, RoutedEventArgs e)
        {
            if (piIsAnimatedBitmap != null && (bool)piIsAnimatedBitmap.GetValue(gifImage))
            {
                playbackButtons.Visibility = Visibility.Visible;
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (miPlay != null)
            {
                miPlay.Invoke(gifImage, new object[0]);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (miStop != null)
            {
                miStop.Invoke(gifImage, new object[0]);
            }
        }

        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer.ChangeView(null, null, scrollViewer.ZoomFactor / 0.7f);
        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer.ChangeView(null, null, scrollViewer.ZoomFactor * 0.7f);
        }
    }
}
