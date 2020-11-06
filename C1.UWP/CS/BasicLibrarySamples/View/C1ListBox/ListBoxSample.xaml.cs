using C1.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BasicLibrarySamples
{
    public sealed partial class ListBoxSample : Page
    {
        public ListBoxSample()
        {
            this.InitializeComponent();

            //listBox.Zoom = new C1ZoomUnit(.5);

            Loaded += ListBoxSample_Loaded;
        }

        void ListBoxSample_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPhotos();
        }

        private async void LoadPhotos()
        {
            var flickrUrl = "http://api.flickr.com/services/feeds/photos_public.gne?tags=animals";
            var AtomNS = "http://www.w3.org/2005/Atom";
            loading.Visibility = Visibility.Visible;
            retry.Visibility = Visibility.Collapsed;

            var photos = new List<Photo>();
            var client = WebRequest.CreateHttp(new Uri(flickrUrl));
            try
            {
                var response = await client.GetResponseAsync();

                #region ** parse you tube data
                var doc = XDocument.Load(response.GetResponseStream());
                foreach (var entry in doc.Descendants(XName.Get("entry", AtomNS)))
                {
                    var title = entry.Element(XName.Get("title", AtomNS)).Value;
                    var enclosure = entry.Elements(XName.Get("link", AtomNS)).Where(elem => elem.Attribute("rel").Value == "enclosure").FirstOrDefault();
                    var contentUri = enclosure.Attribute("href").Value;
                    var alternate = entry.Elements(XName.Get("link", AtomNS)).Where(elem => elem.Attribute("rel").Value == "alternate").FirstOrDefault();
                    var link = alternate.Attribute("href").Value;
                    photos.Add(new Photo() { Title = title, Content = contentUri, Thumbnail = contentUri.Replace("_b", "_m"), Link = link });
                }
                #endregion

                listBox.ItemsSource = photos;
                loading.Visibility = Visibility.Collapsed;
                listBox.Visibility = Visibility.Visible;
                retry.Visibility = Visibility.Collapsed;
            }
            catch
            {
                var dialog = new MessageDialog(Strings.ListBoxSampleErrorMessage);
                dialog.ShowAsync();
                loading.Visibility = Visibility.Collapsed;
                retry.Visibility = Visibility.Visible;
            }
        }

        private void Retry_Click(object sender, RoutedEventArgs e)
        {
            LoadPhotos();
        }

        private async void listBox_ItemTapped(object sender, C1TappedEventArgs e)
        {
            if (!e.IsRightTapped)
            {
                try
                {
                    var listBoxItem = sender as C1ListBoxItem;
                    var photo = listBoxItem.Content as Photo;
                    e.Handled = true;
                    await Launcher.LaunchUriAsync(new Uri(photo.Link));
                }
                catch { }
            }
        }
    }

    public class Photo
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
    }
}
