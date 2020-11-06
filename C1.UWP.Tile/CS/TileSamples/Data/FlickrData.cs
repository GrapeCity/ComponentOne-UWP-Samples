using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace TileSamples.Data
{
    public class FlickrPhoto : C1.Xaml.Tile.ILoadable
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public ImageSource ImageSource { get; private set; }

        #region ** ILoadable implementation
        public bool IsLoaded
        {
            get { return _isLoaded; }
        }
        private bool _isLoaded = false;

        public bool Load()
        {
            if (!_isLoaded && !string.IsNullOrEmpty(Thumbnail))
            {
                BitmapImage img = new BitmapImage(new System.Uri(Thumbnail));
                img.ImageOpened += (s, e) =>
                {
                    _isLoaded = true;
                };
                img.ImageFailed += (s, e) =>
                {
                    _isLoaded = true;
                };
                ImageBrush image = new ImageBrush();
                image.ImageSource = img;
                ImageSource = img;
            }
            return _isLoaded;
        }
        #endregion

        static string flickrUrl = "http://api.flickr.com/services/feeds/photos_public.gne";
        static string AtomNS = "http://www.w3.org/2005/Atom";

        /// <summary>
        /// Loads public photos from flickr.
        /// </summary>
        /// <param name="tag">If set, method uses it to load photos only with this specific tag.</param>
        /// <returns></returns>
        public static async Task<List<FlickrPhoto>> Load(string tag)
        {

            List<FlickrPhoto> result = new List<FlickrPhoto>();
            try
            {
                string uri = string.IsNullOrEmpty(tag) ? flickrUrl : flickrUrl + "?tags=" + tag;
                var client = WebRequest.CreateHttp(uri);
                var response = await client.GetResponseAsync();

                #region ** parse flickr data
                using (System.IO.Stream stream = response.GetResponseStream())
                {
                    var doc = XDocument.Load(stream);
                    foreach (var entry in doc.Descendants(XName.Get("entry", AtomNS)))
                    {
                        var title = entry.Element(XName.Get("title", AtomNS)).Value;
                        var author = entry.Element(XName.Get("author", AtomNS)).Element(XName.Get("name", AtomNS)).Value;
                        var enclosure = entry.Elements(XName.Get("link", AtomNS)).Where(elem => elem.Attribute("rel").Value == "enclosure").FirstOrDefault();
                        var contentUri = enclosure.Attribute("href").Value;
                        result.Add(new FlickrPhoto() { Title = title, Content = contentUri, Thumbnail = contentUri.Replace("_b", "_m"), Author = author });
                    }
                }
                #endregion
            }
            catch
            {
            }
            return result;
        }
    }

}
