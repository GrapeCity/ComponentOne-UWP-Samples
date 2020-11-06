using System;
using TileSamples.Data;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace TileSamples
{
    /// <summary>
    /// 
    /// </summary>
    public sealed partial class ListBoxSample : Page
    {
        public ListBoxSample()
        {
           TileCommand = new DelegateCommand<object>(ExecuteCommand, GetCanExecuteCommand);
           this.InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadPhotos();
        }
 
        private async void LoadPhotos()
        {
            loading.Visibility = Visibility.Visible;
            retry.Visibility = Visibility.Collapsed;
            try
            {
                var photos = await FlickrPhoto.Load("people");
                loading.Visibility = Visibility.Collapsed;
                this.DataContext = photos; 
            }
            catch
            {
                var dialog = new Windows.UI.Popups.MessageDialog(Strings.DownloadFlickrErrorMessage);
                dialog.ShowAsync();
                retry.Visibility = Visibility.Visible;
                loading.Visibility = Visibility.Collapsed;
            }
            splitView.IsPaneOpen = true;
        }

        #region ** Command
        public DelegateCommand<object> TileCommand { get; set; }

        private void ExecuteCommand(object parameter)
        {
            // show tile content in the preview
            // ((FlickrPhoto)parameter).Content contains Image Uri
            Preview.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(((FlickrPhoto)parameter).Content));
        }

        private bool GetCanExecuteCommand(object parameter)
        {
            return true;
        }
        #endregion

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = true;
            HamburgerButton.Visibility = Visibility.Collapsed;
        }

        private void splitView_PaneClosed(SplitView sender, object args)
        {
            HamburgerButton.Visibility = Visibility.Visible;
        }
    }
}
