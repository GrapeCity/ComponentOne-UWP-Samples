using C1.Xaml.Document;
using C1.Xaml.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    public sealed partial class TOCPage : Page
    {
        C1PdfDocumentSource pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        C1PdfDocument pdf;

        public TOCPage()
        {
            this.InitializeComponent();
            this.Loaded += TOCPage_Loaded;

            flexViewer.DocumentSource = pdfDocSource;
            pdf = PdfUtils.CreatePdfDocument();
        }

        async void TOCPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentTOC(pdf);
            PdfUtils.SetDocumentInfo(pdf, Strings.TableOfContentsDocumentTitle);
            await pdfDocSource.LoadFromStreamAsync(PdfUtils.SaveToStream(pdf).AsRandomAccessStream());
            progressRing.IsActive = false;
        }

        static void CreateDocumentTOC(C1PdfDocument pdf)
        {
            // create pdf document
            pdf.DocumentInfo.Title = Strings.TableOfContentsDocumentTitle;

            // add title
            Font titleFont = new Font("Tahoma", 24, PdfFontStyle.Bold);
            Rect rcPage = PdfUtils.PageRectangle(pdf);
            Rect rc = PdfUtils.RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rcPage, rcPage, false);
            rc.Y += 12;

            // create nonsense document
            var bkmk = new List<string[]>();
            Font headerFont = new Font("Arial", 14, PdfFontStyle.Bold);
            Font bodyFont = new Font("Times New Roman", 11);
            for (int i = 0; i < 30; i++)
            {
                // create ith header (as a link target and outline entry)
                string header = string.Format("{0}. {1}", i + 1, BuildRandomTitle());
                rc = PdfUtils.RenderParagraph(pdf, header, headerFont, rcPage, rc, true, true);

                // save bookmark to build TOC later
                int pageNumber = pdf.CurrentPage + 1;
                bkmk.Add(new string[] { pageNumber.ToString(), header });

                // create some text
                rc.X += 36;
                rc.Width -= 36;
                for (int j = 0; j < 3 + _rnd.Next(20); j++)
                {
                    string text = BuildRandomParagraph();
                    rc = PdfUtils.RenderParagraph(pdf, text, bodyFont, rcPage, rc);
                    rc.Y += 6;
                }
                rc.X -= 36;
                rc.Width += 36;
                rc.Y += 20;
            }

            // start Table of Contents
            pdf.NewPage();					// start TOC on a new page
            int tocPage = pdf.CurrentPage;	// save page index (to move TOC later)
            rc = PdfUtils.RenderParagraph(pdf, Strings.TableOfContentsDocumentTitle, titleFont, rcPage, rcPage, true);
            rc.Y += 12;
            rc.X += 30;
            rc.Width -= 40;

            // render Table of Contents
            Pen dottedPen = new Pen(Colors.Gray, 1.5f);
            dottedPen.DashStyle = C1.Xaml.Pdf.DashStyle.Dot;
            StringFormat sfRight = new StringFormat();
            sfRight.Alignment = HorizontalAlignment.Right;
            rc.Height = bodyFont.Size * 1.2;
            foreach (string[] entry in bkmk)
            {
                // get bookmark info
                string page = entry[0];
                string header = entry[1];

                // render header name and page number
                pdf.DrawString(header, bodyFont, Colors.Black, rc);
                pdf.DrawString(page, bodyFont, Colors.Black, rc, sfRight);

#if true
                // connect the two with some dots (looks better than a dotted line)
                string dots = ". ";
                var wid = pdf.MeasureString(dots, bodyFont).Width;
                var x1 = rc.X + pdf.MeasureString(header, bodyFont).Width + 8;
                var x2 = rc.Right - pdf.MeasureString(page, bodyFont).Width - 8;
                var x = rc.X;
                for (rc.X = x1; rc.X < x2; rc.X += wid)
                {
                    pdf.DrawString(dots, bodyFont, Colors.Gray, rc);
                }
                rc.X = x;
#else 
				// connect with a dotted line (another option)
				var x1 = rc.X + pdf.MeasureString(header, bodyFont).Width + 5;
				var x2 = rc.Right - pdf.MeasureString(page, bodyFont).Width  - 5;
				var y  = rc.Top + bodyFont.Size;
				pdf.DrawLine(dottedPen, x1, y, x2, y);
#endif
                // add local hyperlink to entry
                pdf.AddLink(Strings.PoundSign + header, rc);

                // move on to next entry
                rc = PdfUtils.Offset(rc, 0, rc.Height);
                if (rc.Bottom > rcPage.Bottom)
                {
                    pdf.NewPage();
                    rc.Y = rcPage.Y;
                }
            }

            // move table of contents to start of document
            PdfPage[] arr = new PdfPage[pdf.Pages.Count - tocPage];
            pdf.Pages.CopyTo(tocPage, arr, 0, arr.Length);
            pdf.Pages.RemoveRange(tocPage, arr.Length);
            pdf.Pages.InsertRange(0, arr);
        }

        static string BuildRandomTitle()
        {
            string[] a1 = Strings.BuildRandomTitleString1.Split('|');
            string[] a2 = Strings.BuildRandomTitleString2.Split('|');
            string[] a3 = Strings.BuildRandomTitleString3.Split('|');
            return string.Format("{0} {1} {2}", a1[_rnd.Next(a1.Length - 1)], a2[_rnd.Next(a2.Length - 1)], a3[_rnd.Next(a3.Length - 1)]);
        }

        static string BuildRandomParagraph()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 5 + _rnd.Next(10); i++)
            {
                sb.AppendFormat(BuildRandomSentence());
            }
            return sb.ToString();
        }
        static string BuildRandomSentence()
        {
            string[] a1 = Strings.BuildRandomSentenceString1.Split('|');
            string[] a2 = Strings.BuildRandomSentenceString2.Split('|');
            string[] a3 = Strings.BuildRandomSentenceString3.Split('|');
            string[] a4 = Strings.BuildRandomSentenceString4.Split('|');
            return string.Format("{0} {1} {2} {3}. ", a1[_rnd.Next(a1.Length - 1)], a2[_rnd.Next(a2.Length - 1)], a3[_rnd.Next(a3.Length - 1)], a4[_rnd.Next(a4.Length - 1)]);
        }
        static Random _rnd = new Random();

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PdfUtils.Save(pdf);
        }
    }
}
