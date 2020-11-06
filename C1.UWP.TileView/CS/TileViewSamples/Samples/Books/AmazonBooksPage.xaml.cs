using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace TileViewSamples
{
    public sealed partial class AmazonBooksPage : Page
    {
        public AmazonBooksPage()
        {
            this.InitializeComponent();

            // load book descriptions from xml
            Assembly assembly = typeof(AmazonBooksPage).GetTypeInfo().Assembly;
            XDocument doc = XDocument.Load(new StreamReader(assembly.GetManifestResourceStream("TileViewSamples.Resources.Amazon.xml")));
            var books = from reader in doc.Descendants("book")
                        select new Book
                        {
                            Title = reader.Attribute("title").Value,
                            CoverUri = reader.Attribute("coverUri").Value,
                            Id = reader.Attribute("id").Value,
                            Price = reader.Attribute("price").Value,
                            Author = reader.Attribute("author").Value,
                            Description = reader.Attribute("description").Value,
                            StockAmount = int.Parse(reader.Attribute("stockAmount").Value)
                        };

            // set the book's item source
            c1TileView1.ItemsSource = books;
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string CoverUri { get; set; }
        public string Id { get; set; }
        public string Price { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
    }
}
