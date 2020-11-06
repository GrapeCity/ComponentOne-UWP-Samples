using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace PdfViewerSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LargeFile : Page
    {
        private string pdf = "http://wwwimages.adobe.com/content/dam/Adobe/en/devnet/pdf/pdfs/adobe_supplement_iso32000.pdf";
        public LargeFile()
        {
            this.InitializeComponent();
            Loaded += LargeFile_Loaded;
            Unloaded += LargeFile_Unloaded;
        }

        private void LargeFile_Unloaded(object sender, RoutedEventArgs e)
        {
            pdfViewer.CloseDocument();
        }

        private void LargeFile_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDocument();
        }

        private async void LoadDocument()
        {
            loading.Visibility = Visibility.Visible;
            retry.Visibility = Visibility.Collapsed;
            viewer.Visibility = Visibility.Collapsed;

            // load file from the Web
            HttpClient client = new HttpClient();
            
            try
            {
                var stream = await client.GetStreamAsync(new Uri(pdf, UriKind.Absolute));

                pdfViewer.LoadDocument(stream);

                loading.Visibility = Visibility.Collapsed;
                viewer.Visibility = Visibility.Visible;
                retry.Visibility = Visibility.Collapsed;
            }
            catch
            {
                var dialog = new MessageDialog(Strings.DownloadException);
                dialog.ShowAsync();
                loading.Visibility = Visibility.Collapsed;
                retry.Visibility = Visibility.Visible;
            }
        }

        private void Retry_Click(object sender, RoutedEventArgs e)
        {
            LoadDocument();
        }

    }
}
