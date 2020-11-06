using C1.Xaml.Document;
using C1.Xaml.Pdf;
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

namespace PdfSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImagesPage : Page
    {
        C1PdfDocumentSource pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        C1PdfDocument pdf;

        public ImagesPage()
        {
            this.InitializeComponent();
            this.Loaded += ImagesPage_Loaded;

            flexViewer.DocumentSource = pdfDocSource;
            pdf = PdfUtils.CreatePdfDocument();
        }

        async void ImagesPage_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            await CreateDocumentImages(pdf);
            PdfUtils.SetDocumentInfo(pdf, Strings.ImagesDocumentTitle);

            await pdfDocSource.LoadFromStreamAsync(PdfUtils.SaveToStream(pdf).AsRandomAccessStream());
            progressRing.IsActive = false;
        }
        
        async Task CreateDocumentImages(C1PdfDocument pdf)
        {
            // calculate page rect (discounting margins)
            var rcPage = PdfUtils.PageRectangle(pdf);
            InMemoryRandomAccessStream ras = new InMemoryRandomAccessStream();

            // title
            Font font = new Font("Segoe UI Light", 16, PdfFontStyle.Italic);
            pdf.DrawString(Strings.ImagesDocumentTitle, font, Colors.Black, new Rect(72, 72, 400, 100));

            // load image into writeable bitmap
            WriteableBitmap wb = new WriteableBitmap(880, 660);
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///PdfSamplesLib/Assets/pic.jpg"));
            
            wb.SetSource(await file.OpenReadAsync());

            // simple draw image
            var rcPic = new Rect(72, 100, wb.PixelWidth / 5.0, wb.PixelHeight / 5.0);
            pdf.DrawImage(wb, rcPic);

            // draw on page preserving aspect ratio
            var delta = 100.0;
            rcPic = new Rect(new Point(delta, delta), new Point(rcPage.Width - delta, rcPage.Height - delta));
            pdf.DrawImage(wb, rcPic, ContentAlignment.MiddleCenter, Stretch.Uniform);

            // translucent rectangle
            var clr = Color.FromArgb(50, 0, 255, 0);
            pdf.FillRectangle(clr, new Rect(200, 200, 300, 400));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PdfUtils.Save(pdf);
        }
    }
}
