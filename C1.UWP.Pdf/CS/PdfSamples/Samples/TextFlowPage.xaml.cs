using C1.Xaml.Document;
using C1.Xaml.Pdf;
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

namespace PdfSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TextFlowPage : Page
    {
        C1PdfDocumentSource pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        C1PdfDocument pdf;

        public TextFlowPage()
        {
            this.InitializeComponent();
            this.Loaded += TextFlowPage_Loaded;

            flexViewer.DocumentSource = pdfDocSource;
            pdf = PdfUtils.CreatePdfDocument();
        }

        async void TextFlowPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentTextFlow(pdf);
            PdfUtils.SetDocumentInfo(pdf, Strings.TextFlowDocumentTitle);
            await pdfDocSource.LoadFromStreamAsync(PdfUtils.SaveToStream(pdf).AsRandomAccessStream());
            progressRing.IsActive = false;
        }

        static void CreateDocumentTextFlow(C1PdfDocument pdf)
        {
            // load long string from resource file
            string text = Strings.ResourceNotFound;

            using (var sr = new StreamReader(typeof(BasicTextPage).GetTypeInfo().Assembly.GetManifestResourceStream("PdfSamples.Resources.flow.txt")))
            {
                text = sr.ReadToEnd();
            }
            text = text.Replace("\t", "   ");
            text = string.Format("{0}\r\n\r\n---oOoOoOo---\r\n\r\n{0}", text);

            // create pdf document
            pdf.DocumentInfo.Title = Strings.TextFlowDocumentTitle;

            // add title
            Font titleFont = new Font("Tahoma", 24, PdfFontStyle.Bold);
            Font bodyFont = new Font("Tahoma", 9);
            Rect rcPage = PdfUtils.PageRectangle(pdf);
            Rect rc = PdfUtils.RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rcPage, rcPage, false);
            rc.Y += titleFont.Size + 6;
            rc.Height = rcPage.Height - rc.Y;

            // create two columns for the text
            Rect rcLeft = rc;
            rcLeft.Width = rcPage.Width / 2 - 12;
            rcLeft.Height = 300;
            rcLeft.Y = (rcPage.Y + rcPage.Height - rcLeft.Height) / 2;
            Rect rcRight = rcLeft;
            rcRight.X = rcPage.Right - rcRight.Width;

            // start with left column
            rc = rcLeft;

            // render string spanning columns and pages
            for (; ; )
            {
                // render as much as will fit into the rectangle
                rc = PdfUtils.Inflate(rc, -3, -3);
                int nextChar = pdf.DrawString(text, bodyFont, Colors.Black, rc);
                rc = PdfUtils.Inflate(rc, +3, +3);
                pdf.DrawRectangle(Colors.LightGray, rc);

                // break when done
                if (nextChar >= text.Length)
                {
                    break;
                }

                // get rid of the part that was rendered
                text = text.Substring(nextChar);

                // switch to right-side rectangle
                if (rc.Left == rcLeft.Left)
                {
                    rc = rcRight;
                }
                else // switch to left-side rectangle on the next page
                {
                    pdf.NewPage();
                    rc = rcLeft;
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PdfUtils.Save(pdf);
        }
    }
}
