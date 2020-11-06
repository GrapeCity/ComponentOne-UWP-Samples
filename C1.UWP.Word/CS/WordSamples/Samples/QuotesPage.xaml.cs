using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using C1.Xaml.Word;
using C1.Xaml.Word.Objects;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;

namespace WordSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuotesPage : Page
    {
        C1WordDocument word;

        public QuotesPage()
        {
            this.InitializeComponent();
            this.Loaded += QuotesPage_Loaded;

            word = new C1WordDocument(PaperKind.Letter);
            word.Clear();
        }

        async void QuotesPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentQuotes(word);
            WordUtils.SetDocumentInfo(word, Strings.QuotesDocumentTitle);
            c1RichTextBox1.Document = new RtfFilter().ConvertToDocument(word.ToRtfText());
            progressRing.IsActive = false;
        }

        static void CreateDocumentQuotes(C1WordDocument word)
        {
            // calculate page rect (discounting margins)
            Rect rcPage = WordUtils.PageRectangle(word);
            var height = rcPage.Top;

            // initialize fonts
            Font hdrFont = new Font("Arial", 14, RtfFontStyle.Bold);
            Font titleFont = new Font("Arial", 20, RtfFontStyle.Bold);
            Font txtFont = new Font("Times New Roman", 10, RtfFontStyle.Italic);

            // add title paragraph
            word.AddParagraph(Strings.QuotesAuthors, titleFont, Colors.DeepPink, RtfHorizontalAlignment.Center);
            word.AddParagraph(string.Empty);
            height += 2 * word.MeasureString(Strings.QuotesAuthors, titleFont, rcPage.Width).Height;

            // build document
            foreach (string s in GetQuotes())
            {
                // quote
                var authorQuote = s.Split('\t');
                var author = authorQuote[0];
                var text = authorQuote[1];

                // if it won't fit this page, do a page break
                var h = word.MeasureString(author, hdrFont, rcPage.Width).Height;
                var sf = new StringFormat();
                sf.Alignment = HorizontalAlignment.Stretch;
                h += word.MeasureString(text, txtFont, rcPage.Width, sf).Height;
                h += 20;
                if (height + h > rcPage.Bottom)
                {
                    word.PageBreak();
                    height = rcPage.Top;
                }
                height += h;

                // render header (author)
                word.AddParagraph(author, hdrFont, Colors.Black, RtfHorizontalAlignment.Left);
                var paragraph = (RtfParagraph)word.Current;
                paragraph.TopBorderColor = Colors.Black;
                paragraph.TopBorderStyle = RtfBorderStyle.Single;
                paragraph.TopBorderWidth = 1f;

                // render body text (quote)
                word.AddParagraph(text, txtFont, Colors.DarkSlateGray, RtfHorizontalAlignment.Left);
                paragraph = (RtfParagraph)word.Current;
                paragraph.LeftIndent = 40.0f;
                word.AddParagraph(string.Empty);
            }
        }

        static List<string> GetQuotes()
        {
            var list = new List<string>();

            using (var sr = new StreamReader(typeof(BasicTextPage).GetTypeInfo().Assembly.GetManifestResourceStream("WordSamples.Resources.quotes.txt")))
            {
                var quotes = sr.ReadToEnd();
                foreach (string quote in quotes.Split('*'))
                {
                    int pos = quote.IndexOf("\r\n");
                    if (pos > -1)
                    {
                        var q = string.Format("{0}\t{1}", quote.Substring(0, pos), quote.Substring(pos + 2).Trim());
                        list.Add(q);
                    }
                }
            }

            return list;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WordUtils.Save(word);
        }
    }
}
