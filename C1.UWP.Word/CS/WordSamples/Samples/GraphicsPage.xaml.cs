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

using C1.Xaml.Word;
using C1.Xaml.Word.Objects;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;

namespace WordSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GraphicsPage : Page
    {
        C1WordDocument word;

        public GraphicsPage()
        {
            this.InitializeComponent();
            this.Loaded += GraphicsPage_Loaded;

            word = new C1WordDocument(PaperKind.Letter);
            word.Clear();
        }

        async void GraphicsPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentGraphics(word);
            WordUtils.SetDocumentInfo(word, Strings.GraphicsDocumentTitle);
            c1RichTextBox1.Document = new RtfFilter().ConvertToDocument(word.ToRtfText());
            progressRing.IsActive = false;
        }

        static void CreateDocumentGraphics(C1WordDocument word)
        {
            // set up to draw
            word.Landscape = true;
            Rect rc = new Rect(0, 100, 300, 300);
            string text = Strings.DocumentGraphicsText;
            Font font = new Font("Segoe UI Light", 16, RtfFontStyle.Italic);

            // add warning paragraph
            word.AddParagraph(Strings.GraphicsWarning, font, Colors.DarkGray, RtfHorizontalAlignment.Left);
            var paragraph = (RtfParagraph)word.Current;
            paragraph.BottomBorderColor = Colors.Red;
            paragraph.BottomBorderStyle = RtfBorderStyle.Dotted;
            paragraph.BottomBorderWidth = 1f;
            word.AddParagraph(string.Empty);

            // draw to word document
            int penWidth = 0;
            byte penRGB = 0;
            word.FillPie(Colors.DarkRed, rc, 0, 20f);
            word.FillPie(Colors.Green, rc, 20f, 30f);
            word.FillPie(Colors.Teal, rc, 60f, 12f);
            word.FillPie(Colors.Orange, rc, -80f, -20f);
            for (float startAngle = 0; startAngle < 360; startAngle += 40)
            {
                Color penColor = Color.FromArgb(0xff, penRGB, penRGB, penRGB);
                Pen pen = new Pen(penColor, penWidth++);
                penRGB = (byte)(penRGB + 20);
                word.DrawArc(pen, rc, startAngle, 40f);
            }
            word.DrawRectangle(Colors.Red, rc);
            word.DrawString(text, font, Colors.Black, rc);

            // show a Bezier curve
            var pts = new Point[]
			{
				new Point(400, 100), new Point(420,  30),
				new Point(500, 140), new Point(530,  20),
			};

            // draw Bezier 
            word.DrawBeziers(new Pen(Colors.Green, 4), pts);

            // show Bezier control points
            word.DrawPolyline(Colors.Gray, pts);
            foreach (Point pt in pts)
            {
                word.FillRectangle(Colors.Orange, pt.X - 2, pt.Y - 2, 4, 4);
            }

            // title
            word.DrawString(Strings.Bezier, font, Colors.Black, new Rect(500, 150, 100, 100));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WordUtils.Save(word);
        }
    }
}
