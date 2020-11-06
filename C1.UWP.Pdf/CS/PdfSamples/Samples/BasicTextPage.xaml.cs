using C1.Xaml.Document;
using C1.Xaml.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class BasicTextPage : Page
    {
        C1PdfDocumentSource pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        C1PdfDocument pdf;

        public BasicTextPage()
        {
            this.InitializeComponent();
            this.Loaded += BasicText_Loaded;

            pdf = PdfUtils.CreatePdfDocument();
            flexViewer.DocumentSource = pdfDocSource;
        }

        async void BasicText_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentText(pdf);

            await pdfDocSource.LoadFromStreamAsync(PdfUtils.SaveToStream(pdf).AsRandomAccessStream());
            progressRing.IsActive = false;
        }

        /// <summary>
        /// Shows how to position and align text
        /// </summary>
        static void CreateDocumentText(C1PdfDocument pdf)
        {
            // use landscape for more impact
            pdf.Landscape = true;

            // measure and show some text 
            var text = Strings.DocumentBasicText;
            var font = new Font("Segoe UI Light", 12, PdfFontStyle.Italic);

            // create StringFormat used to set text alignment and line spacing
            var fmt = new StringFormat();
            fmt.LineSpacing = -1.5; // 1.5 char height
            fmt.Alignment = HorizontalAlignment.Center;

            // measure it
            var sz = pdf.MeasureString(text, font, 72 * 3, fmt);
            var rc = new Rect(pdf.PageRectangle.Width / 2, 72, sz.Width, sz.Height);
            rc = PdfUtils.Offset(rc, 110, 0);

            // draw a rounded frame
            rc = PdfUtils.Inflate(rc, 0, 0);
            pdf.FillRectangle(Colors.Teal, rc, new Size(0, 0));
            //pdf.DrawRectangle(new Pen(Colors.DarkGray, 5), rc, new Size(0, 0));
            rc = PdfUtils.Inflate(rc, -10, -10);

            // draw the text
            //pdf.RotateAngle = 90;
            pdf.DrawString(text, font, Colors.White, rc, fmt);
            //pdf.RotateAngle = 0;

            // point in center for rotate the text
            rc = pdf.PageRectangle;
            var pt = new Point(rc.X + rc.Width / 2, rc.Y + rc.Height / 2);

            // rotate the string in small increments
            var step = 6;
            text = Strings.DocumentBasicText2;
            for (int i = 0; i <= 360; i += step)
            {
                pdf.RotateAngle = i;
                var s = string.Format(text, i);
                font = new Font("Courier New", 8 + i / 30.0, PdfFontStyle.Bold);
                byte b = (byte)(255 * (1 - i / 360.0));
                pdf.DrawString(s, font, Color.FromArgb(0xff, b, b, b), pt);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PdfUtils.Save(pdf);
        }
    }
}
