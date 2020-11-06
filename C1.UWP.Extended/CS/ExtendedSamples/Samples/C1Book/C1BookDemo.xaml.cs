using ExtendedSamples.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;

namespace ExtendedSamples
{
    public sealed partial class C1BookDemo : Page
    {
        public C1BookDemo()
        {
            this.InitializeComponent();
            this.InitDataSource();
        }

        private void InitDataSource()
        {
            // load book descriptions from xml
            Assembly assembly = typeof(C1BookDemo).GetTypeInfo().Assembly;
            XDocument doc = XDocument.Load(new StreamReader(assembly.GetManifestResourceStream("ExtendedSamples.Resources.Amazon.xml")));
            
            var books = from reader in doc.Descendants("book")
                        select new AmazonBookDescription
                        {
                            Title = reader.Attribute("title").Value,
                            CoverUri = reader.Attribute("coverUri").Value,
                            Author = reader.Attribute("author").Value,
                            Price = reader.Attribute("price").Value
                        };

            // set the book's item source
            book.ItemsSource = books;
        }
    }
}
