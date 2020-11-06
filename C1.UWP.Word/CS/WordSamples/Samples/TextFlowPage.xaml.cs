#define WITHOUT_GRAPHICS

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
    public sealed partial class TextFlowPage : Page
    {
        C1WordDocument _doc;

        public TextFlowPage()
        {
            this.InitializeComponent();
            this.Loaded += TextFlowPage_Loaded;

            _doc = new C1WordDocument(PaperKind.Letter);
            _doc.Clear();
        }

        async void TextFlowPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            CreateDocumentTextFlow(_doc);
            WordUtils.SetDocumentInfo(_doc, Strings.TextFlowDocumentTitle);
            c1RichTextBox1.Document = new RtfFilter().ConvertToDocument(_doc.ToRtfText());
            progressRing.IsActive = false;
        }

        static void CreateDocumentTextFlow(C1WordDocument word)
        {
            // load long string from resource file
            string text = Strings.ResourceNotFound;

            using (var sr = new StreamReader(typeof(BasicTextPage).GetTypeInfo().Assembly.GetManifestResourceStream("WordSamples.Resources.flow.txt")))
            {
                text = sr.ReadToEnd();
            }

            // content rectangle
            Rect rcPage = WordUtils.PageRectangle(word);

            // create two columns for the text
            var columnWidth = (float)(rcPage.Width - 30) / 2;
            word.MainSection.Columns.Clear();
            word.MainSection.Columns.Add(new RtfColumn(columnWidth));
            word.MainSection.Columns.Add(new RtfColumn(columnWidth));

            // add title
            Font titleFont = new Font("Tahoma", 14, RtfFontStyle.Bold);
            Font bodyFont = new Font("Tahoma", 11);
            word.AddParagraph(Strings.MsWordFormats, titleFont, Colors.DarkOliveGreen, RtfHorizontalAlignment.Center);
            word.AddParagraph(string.Empty);

            // first paragraph about C1Word object model
            var paragraph = word.GetParagraph(string.Empty, bodyFont);
            var hyperlink = new RtfHyperlink(Strings.WordSamplesWordLink, Colors.Blue, RtfUnderlineStyle.Single);
            hyperlink.Add(new RtfString(Strings.WordSamplesWordTitle));
            paragraph.Add(hyperlink);
            word.Add(paragraph);
            word.AddParagraph(string.Empty);

            // render string spanning columns and pages
            foreach (var part in text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
            {
                word.AddParagraph(part, bodyFont, Colors.Black, RtfHorizontalAlignment.Justify);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WordUtils.Save(_doc);
        }

        private void c1RichTextBox1_RequestNavigate(object sender, RequestNavigateEventArgs e)
        { 
            Windows.System.Launcher.LaunchUriAsync(e.Hyperlink.NavigateUri);
        }
    }
}
