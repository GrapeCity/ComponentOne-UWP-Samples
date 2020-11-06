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

namespace WordSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RenderUIPage : Page
    {
        C1WordDocument _doc;

        public RenderUIPage()
        {
            this.InitializeComponent();

            _doc = new C1WordDocument(PaperKind.Letter);
        }

        private async void btnRender_Click(object sender, RoutedEventArgs e)
        {
            // document parameters
            _doc.Clear();
            progressRing.IsActive = true;
            _doc.Landscape = true;
            var sz = _doc.PageSize;
            var rc = new Rect(0, 0, sz.Width - _doc.MainSection.LeftMargin - _doc.MainSection.RightMargin, sz.Height - _doc.MainSection.TopMargin - _doc.MainSection.BottomMargin);

            // draw every UI elements inside the panel in word document.
            await _doc.DrawElement(panel, rc);

            // save document
            WordUtils.SetDocumentInfo(_doc, Strings.RenderUIDocumentTitle);
            WordUtils.Save(_doc);
            progressRing.IsActive = false;
        }
    }
}
