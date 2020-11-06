using C1.Xaml.Tile;
using TileSamples.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TileSamples
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ContentSourceSample : Page
    {
        public ContentSourceSample()
        {
            this.InitializeComponent();
        }

        private async void LoadContent()
        {
            sv.Visibility = Visibility.Collapsed;
            loading.Visibility = Visibility.Visible;
            retry.Visibility = Visibility.Collapsed;
            try
            {
                foreach (C1Tile tile in tilePanel.Children)
                {
                    var content = await FlickrPhoto.Load((string)tile.Header);
                    loading.Visibility = Visibility.Collapsed;
                    sv.Visibility = Visibility.Visible;
                    tile.ContentSource = content;
                }
            }
            catch
            {
                var dialog = new Windows.UI.Popups.MessageDialog(Strings.DownloadFlickrErrorMessage);
                dialog.ShowAsync();
                retry.Visibility = Visibility.Visible;
                loading.Visibility = Visibility.Collapsed;
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadContent();
        }
    }
}
