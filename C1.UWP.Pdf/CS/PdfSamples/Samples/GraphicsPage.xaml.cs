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
    public sealed partial class GraphicsPage : Page
    {
        C1PdfDocumentSource pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        C1PdfDocument pdf;

        public GraphicsPage()
        {
            this.InitializeComponent();
            this.Loaded += GraphicsPage_Loaded;

            pdf = PdfUtils.CreatePdfDocument();
            flexViewer.DocumentSource = pdfDocSource;
        }

        async void GraphicsPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentGraphics(pdf);
            PdfUtils.SetDocumentInfo(pdf, Strings.GraphicsDocumentTitle);

            await pdfDocSource.LoadFromStreamAsync(PdfUtils.SaveToStream(pdf).AsRandomAccessStream());
            progressRing.IsActive = false;
        }

        static void CreateDocumentGraphics(C1PdfDocument pdf)
        {
            // set up to draw
            Rect rc = new Rect(50, 70, 300, 300);
            string text = Strings.DocumentGraphicsText;
            Font font = new Font("Segoe UI Light", 16, PdfFontStyle.Italic);

            // draw to pdf document
            int penWidth = 0;
            byte penRGB = 0;
            pdf.FillPie(Colors.DarkRed, rc, 0, 20f);
            pdf.FillPie(Colors.Green, rc, 20f, 30f);
            pdf.FillPie(Colors.Teal, rc, 60f, 12f);
            pdf.FillPie(Colors.Orange, rc, -80f, -20f);
            for (float startAngle = 0; startAngle < 360; startAngle += 40)
            {
                Color penColor = Color.FromArgb(0xff, penRGB, penRGB, penRGB);
                Pen pen = new Pen(penColor, penWidth++);
                penRGB = (byte)(penRGB + 20);
                pdf.DrawArc(pen, rc, startAngle, 40f);
            }
            //pdf.DrawRectangle(Colors.Red, rc);
            rc = new Rect(10, 20, 300, 50);
            pdf.DrawString(text, font, Colors.Black, rc);

            // show a Bezier curve
            var pts = new Point[]
			{
				new Point(400, 100), new Point(420,  30),
				new Point(500, 140), new Point(530,  20),
			};

            // draw Bezier 
            pdf.DrawBezier(new Pen(Colors.Green, 4), pts[0], pts[1], pts[2], pts[3]);

            // show Bezier control points
            pdf.DrawLines(Colors.Gray, pts);
            foreach (Point pt in pts)
            {
                pdf.FillRectangle(Colors.Orange, pt.X - 2, pt.Y - 2, 4, 4);
            }

            // title
            pdf.DrawString(Strings.Bezier, font, Colors.Black, new Rect(450, 180, 100, 100));

            // figures
            Color clr = Color.FromArgb(255, 250, 250, 0);
            Pen linePen = new Pen(clr, 2);
            linePen.DashStyle = C1.Xaml.Pdf.DashStyle.DashDotDot;
            pdf.DrawLine(linePen, 120, 700, 550, 300);
            pts = new Point[]
            {
                new Point(200, 400), new Point(500, 300),
                new Point(500, 560), new Point(370, 660),
                new Point(250, 600), new Point(200, 400),
            };
            clr = Color.FromArgb(120, 0, 255, 0);
            pdf.FillPolygon(clr, pts);
            rc = new Rect(120, 350, 300, 300);
            clr = Color.FromArgb(150, 0, 0, 255);
            pdf.FillEllipse(clr, rc);
            rc = new Rect(100, 400, 250, 250);
            clr = Color.FromArgb(100, 255, 0, 0);
            pdf.FillRectangle(clr, rc);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PdfUtils.Save(pdf);
        }
    }
}
