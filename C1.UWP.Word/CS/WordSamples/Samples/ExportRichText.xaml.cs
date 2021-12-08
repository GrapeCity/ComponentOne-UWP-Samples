using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;

using C1.Xaml.Word;
using C1.Xaml.Word.Objects;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;
using Windows.Storage;
using System.Reflection;

namespace WordSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExportRichText : Page
    {
        C1WordDocument _doc;

        public ExportRichText()
        {
            this.InitializeComponent();

            _doc = new C1WordDocument(PaperKind.Letter);
            LoadRichText();
        }

        async void LoadRichText()
        {
            using (var sr = new StreamReader(typeof(ExportRichText).GetTypeInfo().Assembly.GetManifestResourceStream("WordSamples.Resources.dickens.htm")))
            {
                var html = sr.ReadToEnd();
                richTextBox.Html = html;
            }    
        }

        private async void btnRender_Click(object sender, RoutedEventArgs e)
        {
            // document parameters
            _doc.Clear();
            progressRing.IsActive = true;

            //This string rtfText can be used well in MS Word
            var rtfText = new RtfFilter().ConvertFromDocument(richTextBox.Document);
            _doc.ParseRtfText(rtfText);

            // save document
            WordUtils.SetDocumentInfo(_doc, Strings.RenderUIDocumentTitle);
            WordUtils.Save(_doc);
            progressRing.IsActive = false;
        }
    }
}
