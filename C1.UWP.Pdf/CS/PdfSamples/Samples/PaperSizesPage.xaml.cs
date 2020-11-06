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
    public sealed partial class PaperSizesPage : Page
    {
        C1PdfDocumentSource pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        C1PdfDocument pdf;

        public PaperSizesPage()
        {
            this.InitializeComponent();
            this.Loaded += PaperSizesPage_Loaded;

            flexViewer.DocumentSource = pdfDocSource;
            pdf = PdfUtils.CreatePdfDocument();
        }

        async void PaperSizesPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentPaperSizes(pdf);
            PdfUtils.SetDocumentInfo(pdf, Strings.PaperSizesDocumentTitle);

            await pdfDocSource.LoadFromStreamAsync(PdfUtils.SaveToStream(pdf).AsRandomAccessStream());
            progressRing.IsActive = false;
        }

        static void CreateDocumentPaperSizes(C1PdfDocument pdf)
        {
            // add title
            Font titleFont = new Font("Tahoma", 24, PdfFontStyle.Bold);
            Rect rc = PdfUtils.PageRectangle(pdf);
            PdfUtils.RenderParagraph(pdf, pdf.DocumentInfo.Title, titleFont, rc, rc, false);

            // create constant font and StringFormat objects
            Font font = new Font("Tahoma", 18);
            StringFormat sf = new StringFormat();
            sf.Alignment = HorizontalAlignment.Center;
            sf.LineAlignment = VerticalAlignment.Center;

            // create one page with each paper size
            bool firstPage = true;
            foreach (PaperKind pk in Enum.GetValues(typeof(PaperKind)))
            {
                // Silverlight doesn't have Enum.GetValues
                //PaperKind pk = fi;

                // skip custom size
                if (pk == PaperKind.Custom) continue;

                // add new page for every page after the first one
                if (!firstPage) pdf.NewPage();
                firstPage = false;

                // set paper kind and orientation
                pdf.PaperKind = pk;
                pdf.Landscape = !pdf.Landscape;

                // draw some content on the page
                rc = PdfUtils.PageRectangle(pdf);
                rc = PdfUtils.Inflate(rc, -6, -6);
                string text = string.Format(Strings.StringFormatTwoArg,
                    pdf.PaperKind, pdf.Landscape);
                pdf.DrawString(text, font, Colors.Black, rc, sf);
                pdf.DrawRectangle(Colors.Black, rc);
            }
            //foreach (var fi in typeof(PaperKind).GetTypeInfo().GetFields(BindingFlags.Static | BindingFlags.Public))
            //{
                
            //}
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PdfUtils.Save(pdf);
        }
    }
}
