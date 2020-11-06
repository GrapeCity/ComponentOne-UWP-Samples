using C1.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace BasicLibrarySamples
{
    public sealed partial class TileListBoxSample : Page
    {
        public TileListBoxSample()
        {
            this.InitializeComponent();

            Loaded += TileListBoxSample_Loaded;
        }

        void TileListBoxSample_Loaded(object sender, RoutedEventArgs e)
        {
            LoadVideos();
        }

        private async void LoadVideos()
        {
            try
            {
                loading.Visibility = Visibility.Visible;
                retry.Visibility = Visibility.Collapsed;
                var feed = new YoutubeFeed();
                await feed.LoadMoreItemsAsync(50);
                tileListBox.ItemsSource = feed;
                loading.Visibility = Visibility.Collapsed;
                tileListBox.Visibility = Visibility.Visible;
                retry.Visibility = Visibility.Collapsed;
            }
            catch
            {
                var dialog = new MessageDialog("There was an error when attempting to download data from you tube.");
                dialog.ShowAsync();
                loading.Visibility = Visibility.Collapsed;
                retry.Visibility = Visibility.Visible;
            }
        }


        private void Retry_Click(object sender, RoutedEventArgs e)
        {
            LoadVideos();
        }

        private void tileListBox_ItemTapped(object sender, C1TappedEventArgs e)
        {
            if (!e.IsRightTapped)
            {
                var video = (sender as C1ListBoxItem).Content as Video;
                NavigateUrl(video.Link);
                e.Handled = true;
            }
        }

        public void NavigateUrl(string url)
        {
            try
            {
                Launcher.LaunchUriAsync(new Uri(url));
            }
            catch { }
        }

        #region ** public properties

        public Orientation Orientation
        {
            get
            {
                return tileListBox.Orientation;
            }
            set
            {
                tileListBox.Orientation = value;
            }
        }

        public double ItemWidth
        {
            get
            {
                return tileListBox.ItemWidth;
            }
            set
            {
                tileListBox.ItemWidth = value;
            }
        }

        public double ItemHeight
        {
            get
            {
                return tileListBox.ItemHeight;
            }
            set
            {
                tileListBox.ItemHeight = value;
            }
        }

        #endregion

        private void tileListBox_ItemContainerLoaded_1(object sender, EventArgs e)
        {
            var listBoxItem = sender as C1ListBoxItem;
            listBoxItem.PointerPressed += (s, e2) =>
                {
                    var storyboard = new Storyboard();
                    var animation = new PointerDownThemeAnimation();
                    Storyboard.SetTarget(animation, listBoxItem);
                    storyboard.Children.Add(animation);
                    storyboard.Begin();
                };
            listBoxItem.PointerReleased += (s, e2) =>
                {
                    var storyboard = new Storyboard();
                    var animation = new PointerUpThemeAnimation();
                    Storyboard.SetTarget(animation, listBoxItem);
                    storyboard.Children.Add(animation);
                    storyboard.Begin();
                };
        }
    }

    public class YoutubeFeed : IncrementalLoadingBase
    {
        private bool _hasMoreItems = true;
        private uint _lastIndex = 0;
        protected override async Task<IList<object>> LoadMoreItemsOverrideAsync(CancellationToken c, uint count)
        {
            var videos = await LoadVideosAsync(_lastIndex + 1, Math.Min(count, 500 - _lastIndex));
            _lastIndex += (uint)videos.Count;
            _hasMoreItems = _lastIndex < 500;
            return videos.Cast<object>().ToList();
        }

        protected override bool HasMoreItemsOverride()
        {
            return _hasMoreItems;
        }

        private async Task<List<Video>> LoadVideosAsync(uint startIndex, uint maxResults)
        {
            var youtubeUrl = string.Format("https://gdata.youtube.com/feeds/api/videos?q=windows+8&start-index={0}&max-results={1}", startIndex, maxResults);
            var AtomNS = "http://www.w3.org/2005/Atom";
            var MediaNS = "http://search.yahoo.com/mrss/";

            var videos = new List<Video>();
            var client = WebRequest.CreateHttp(new Uri(youtubeUrl));
            try
            {
                var response = await client.GetResponseAsync();

                #region ** parse you tube data
                var doc = XDocument.Load(response.GetResponseStream());
                foreach (var entry in doc.Descendants(XName.Get("entry", AtomNS)))
                {
                    var title = entry.Element(XName.Get("title", AtomNS)).Value;
                    var thumbnail = "";
                    var group = entry.Element(XName.Get("group", MediaNS));
                    var thumbnails = group.Elements(XName.Get("thumbnail", MediaNS));
                    var thumbnailElem = thumbnails.FirstOrDefault();
                    if (thumbnailElem != null)
                        thumbnail = thumbnailElem.Attribute("url").Value;
                    var alternate = entry.Elements(XName.Get("link", AtomNS)).Where(elem => elem.Attribute("rel").Value == "alternate").FirstOrDefault();
                    var link = alternate.Attribute("href").Value;
                    videos.Add(new Video() { Title = title, Link = link, Thumbnail = thumbnail });
                }
                #endregion
            }
            catch (WebException exc)
            {
                var excText = new StreamReader(exc.Response.GetResponseStream()).ReadToEnd();
                throw;
            }

            return videos;

        }

    }

    public class Video
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Link { get; set; }
    }
}
