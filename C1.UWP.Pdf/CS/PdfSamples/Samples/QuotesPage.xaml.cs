using C1.Xaml.Document;
using C1.Xaml.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PdfSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QuotesPage : Page
    {
        C1PdfDocumentSource pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        C1PdfDocument pdf;

        public QuotesPage()
        {
            this.InitializeComponent();
            this.Loaded += QuotesPage_Loaded;

            flexViewer.DocumentSource = pdfDocSource;
            pdf = PdfUtils.CreatePdfDocument();
        }

        async void QuotesPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentQuotes(pdf);
            PdfUtils.SetDocumentInfo(pdf, Strings.QuotesDocumentTitle);

            await pdfDocSource.LoadFromStreamAsync(PdfUtils.SaveToStream(pdf).AsRandomAccessStream());
            progressRing.IsActive = false;
        }

        static void CreateDocumentQuotes(C1PdfDocument pdf)
        {
            // calculate page rect (discounting margins)
            Rect rcPage = PdfUtils.PageRectangle(pdf);
            Rect rc = rcPage;

            // initialize output parameters
            Font hdrFont = new Font("Arial", 14, PdfFontStyle.Bold);
            Font titleFont = new Font("Arial", 24, PdfFontStyle.Bold);
            Font txtFont = new Font("Times New Roman", 10, PdfFontStyle.Italic);

            // add title
            rc = PdfUtils.RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rcPage, rc);

            // build document
            foreach (string s in GetQuotes())
            {
                string[] authorQuote = s.Split('\t');

                // render header (author)
                var author = authorQuote[0];
                rc.Y += 20;
                rc = PdfUtils.RenderParagraph(pdf, author, hdrFont, rcPage, rc, true);

                // render body text (quote)
                string text = authorQuote[1];
                rc.X = rcPage.X + 36; // << indent body text by 1/2 inch
                rc.Width = rcPage.Width - 40;
                rc = PdfUtils.RenderParagraph(pdf, text, txtFont, rcPage, rc);
                rc.X = rcPage.X; // << restore indent
                rc.Width = rcPage.Width;
                rc.Y += 12; // << add 12pt spacing after each quote
            }
        }

        static List<string> GetQuotes()
        {
            var list = new List<string>();

            using (var sr = new StreamReader(typeof(BasicTextPage).GetTypeInfo().Assembly.GetManifestResourceStream("PdfSamples.Resources.quotes.txt")))
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
            PdfUtils.Save(pdf);
        }
    }
}
