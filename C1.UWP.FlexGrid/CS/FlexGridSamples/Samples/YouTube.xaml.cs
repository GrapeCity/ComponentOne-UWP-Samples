using C1.Xaml.FlexGrid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Popups;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FlexGridSamples
{
    public sealed partial class YouTube : Page
    {
        public YouTube()
        {
            this.InitializeComponent();
            flexgrid.CellFactory = new YouTubeCellFactory();

            // resize the header font
            foreach (var c in flexgrid.Columns)
            {
                c.HeaderFontSize = 24;
            }

            // adjust row sizes to fit (whether or not the cells are visible)
            flexgrid.AutoSizeFixedRows(0, flexgrid.ColumnHeaders.Rows.Count - 1, 4, true);

            Loaded += OnLoaded;
        }

        void OnLoaded(object sender, RoutedEventArgs e)
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
                flexgrid.ItemsSource = feed;
                loading.Visibility = Visibility.Collapsed;
                flexgrid.Visibility = Visibility.Visible;
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
            var YouTubeNS = "http://gdata.youtube.com/schemas/2007";
            var GDNS = "http://schemas.google.com/g/2005";

            var videos = new List<Video>();
            var client = WebRequest.CreateHttp(new Uri(youtubeUrl));
            try
            {
                var response = await client.GetResponseAsync();

                #region ** parse you tube data
                var doc = XDocument.Load(response.GetResponseStream());
                foreach (var entry in doc.Descendants(XName.Get("entry", AtomNS)))
                {
                    var video = new Video();
                    video.Title = entry.Element(XName.Get("title", AtomNS)).Value;
                    var authorElem = entry.Element(XName.Get("author", AtomNS));
                    if (authorElem != null)
                    {
                        var authorNameElem = authorElem.Element(XName.Get("name", AtomNS));
                        if (authorNameElem != null)
                            video.Author = authorNameElem.Value;
                    }
                    var group = entry.Element(XName.Get("group", MediaNS));
                    var thumbnails = group.Elements(XName.Get("thumbnail", MediaNS));
                    var thumbnailElem = thumbnails.FirstOrDefault();
                    if (thumbnailElem != null)
                        video.Thumbnail = thumbnailElem.Attribute("url").Value;
                    var durationElement = group.Element(XName.Get("duration", YouTubeNS));
                    video.Duration = TimeSpan.FromSeconds(long.Parse(durationElement.Attribute("seconds").Value));
                    var ratingElement = entry.Element(XName.Get("rating", GDNS));
                    if (ratingElement != null)
                        video.Rating = double.Parse(ratingElement.Attribute("average").Value);
                    else
                        video.Rating = double.NaN;
                    var statisticsElement = entry.Element(XName.Get("statistics", YouTubeNS));
                    if (statisticsElement != null)
                    {
                        video.ViewCount = long.Parse(statisticsElement.Attribute("viewCount").Value);
                    }
                    var alternate = entry.Elements(XName.Get("link", AtomNS)).Where(elem => elem.Attribute("rel").Value == "alternate").FirstOrDefault();
                    video.Link = alternate.Attribute("href").Value;
                    videos.Add(video);
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
        public string Author { get; set; }
        public TimeSpan Duration { get; set; }
        public double Rating { get; set; }
        public long ViewCount { get; set; }
    }

    public class YouTubeCellFactory : CellFactory
    {
        public override void CreateCellContent(C1FlexGrid grid, Border bdr, CellRange range)
        {
            // get row/col
            var row = grid.Rows[range.Row];
            var col = grid.Columns[range.Column];

            // bind regular data cells
            switch (col.ColumnName)
            {
                // show ratings with stars
                case "Rating":
                    var video = row.DataItem as Video;
                    if (video != null)
                    {
                        var cell = new RatingCell();
                        cell.SetBinding(RatingCell.RatingProperty, col.Binding);
                        bdr.Child = cell;
                    }
                    return;
            }

            // default binding
            base.CreateCellContent(grid, bdr, range);
        }
    }
}
