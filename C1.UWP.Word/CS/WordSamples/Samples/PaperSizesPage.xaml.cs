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
    public sealed partial class PaperSizesPage : Page
    {
        C1WordDocument word;

        public PaperSizesPage()
        {
            this.InitializeComponent();
            this.Loaded += PaperSizesPage_Loaded;

            word = new C1WordDocument(PaperKind.Letter);
            word.Clear();
        }

        async void PaperSizesPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentPaperSizes(word);
            WordUtils.SetDocumentInfo(word, Strings.PaperSizesDocumentTitle);
            c1RichTextBox1.Document = new RtfFilter().ConvertToDocument(word.ToRtfText());
            progressRing.IsActive = false;
        }


        static void CreateDocumentPaperSizes(C1WordDocument word)
        {
            // landscape for first page
            bool landscape = true;
            word.Landscape = landscape;

            // add title
            Font titleFont = new Font("Tahoma", 24, RtfFontStyle.Bold);
            Rect rc = WordUtils.PageRectangle(word);
            word.AddParagraph(Strings.PaperSizesFirstPage, titleFont);
            var paragraph = (RtfParagraph)word.Current;
            paragraph.BottomBorderColor = Colors.Purple;
            paragraph.BottomBorderStyle = RtfBorderStyle.Dotted;
            paragraph.BottomBorderWidth = 3.0f;

            // view warning
            Font warningFont = new Font("Arial", 14);
            word.AddParagraph(Strings.PaperSizesWarning, warningFont, Colors.Blue);

            // create constant font and StringFormat objects
            Font font = new Font("Tahoma", 18);
            StringFormat sf = new StringFormat();
            sf.Alignment = HorizontalAlignment.Center;
            sf.LineAlignment = VerticalAlignment.Center;
            word.AddParagraph(string.Empty, font, Colors.Black);

            // create one page with each paper size
            foreach (PaperKind pk in Enum.GetValues(typeof(PaperKind)))
            {
                // skip custom page size
                if (pk == PaperKind.Custom) continue;

                // add new page for every page after the first one
                word.PageBreak();

                // set paper kind and orientation
                var section = new RtfSection(pk);
                word.Add(section);
                landscape = !landscape;
                word.Landscape = landscape;

                // add some content on the page
                string text = string.Format(Strings.StringFormatTwoArg, pk, word.Landscape);
                word.AddParagraph(text);
                paragraph = (RtfParagraph)word.Current;
                paragraph.SetRectBorder(RtfBorderStyle.DashSmall, Colors.Aqua, 2.0f);
                word.AddParagraph(string.Empty);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WordUtils.Save(word);
        }
    }
}
