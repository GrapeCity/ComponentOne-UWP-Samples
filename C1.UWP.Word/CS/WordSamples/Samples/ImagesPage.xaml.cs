using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.UI.Core;

using C1.Xaml.Word;
using C1.Xaml.Word.Objects;
using C1.Xaml.RichTextBox;
using C1.Xaml.RichTextBox.Documents;

namespace WordSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImagesPage : Page
    {
        C1WordDocument word;

        public ImagesPage()
        {
            this.InitializeComponent();
            this.Loaded += ImagesPage_Loaded;

            word = new C1WordDocument(PaperKind.Letter);
            word.Clear();
        }

        async void ImagesPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            await CreateDocumentImages(word);
            WordUtils.SetDocumentInfo(word, Strings.TableOfContentsDocumentTitle);
            c1RichTextBox1.Document = new RtfFilter().ConvertToDocument(word.ToRtfText());
            progressRing.IsActive = false;
        }
        
        async Task CreateDocumentImages(C1WordDocument word)
        {
            // add first image paragraph
            Font font = new Font("Segoe UI Light", 16, RtfFontStyle.Italic);
            word.AddParagraph(Strings.ImageFirstParagraph, font, Colors.DarkGray, RtfHorizontalAlignment.Left);
            var paragraph = (RtfParagraph)word.Current;
            paragraph.BottomBorderColor = Colors.Gray;
            paragraph.BottomBorderStyle = RtfBorderStyle.Single;
            paragraph.BottomBorderWidth = 1f;
            word.AddParagraph(string.Empty);

            // calculate page rect (discounting margins)
            Rect rcPage = WordUtils.PageRectangle(word);
            InMemoryRandomAccessStream ras = new InMemoryRandomAccessStream();
#if !true
            // load image into C1 bitmap
            var wb = new C1.Xaml.Bitmap.C1Bitmap();
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///WordSamplesLib/Assets/pic.jpg"));
            await wb.LoadAsync(file);
#else
            // load image into writeable bitmap
            WriteableBitmap wb = new WriteableBitmap(880, 660);
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///WordSamplesLib/Assets/pic.jpg"));
            wb.SetSource(await file.OpenReadAsync());
#endif
            // add image without scaling by center
            word.AddPicture(wb, RtfHorizontalAlignment.Center);
            word.LineBreak();
            word.AddParagraph(string.Empty);

            // add first image paragraph
            font = new Font("Segoe UI Light", 12, RtfFontStyle.Regular);
            word.AddParagraph(Strings.ImageSecondParagraph, font, Colors.DeepSkyBlue, RtfHorizontalAlignment.Left);
            paragraph = (RtfParagraph)word.Current;
            paragraph.BottomBorderColor = Colors.BlueViolet;
            paragraph.BottomBorderStyle = RtfBorderStyle.Dotted;
            paragraph.BottomBorderWidth = 2f;
            word.AddParagraph(string.Empty);

            // add image with scaling by right
            word.AddPicture(wb, RtfHorizontalAlignment.Right);
            var picture = (RtfPicture)word.Current;
            picture.Height = 33;
            picture.Width = 44;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            WordUtils.Save(word);
        }
    }
}
