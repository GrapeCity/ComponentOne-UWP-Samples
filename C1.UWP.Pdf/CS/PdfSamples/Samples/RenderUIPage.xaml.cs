using C1.Xaml.Document;
using C1.Xaml.Pdf;
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

namespace PdfSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RenderUIPage : Page
    {
        C1PdfDocumentSource pdfDocSource = new C1PdfDocumentSource() { UseSystemRendering = false };
        C1PdfDocument pdf;

        public RenderUIPage()
        {
            this.InitializeComponent();
            List<string> comboItems = new List<string>();
            comboItems.Add(PdfSamples.Strings.ComboBoxItem1_Content);
            comboItems.Add(PdfSamples.Strings.ComboBoxItem2_Content);
            combo.ItemsSource = comboItems;

            flexViewer.DocumentSource = pdfDocSource;
            pdf = PdfUtils.CreatePdfDocument();
        }

        private async void btnRender_Click(object sender, RoutedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            pdf.Clear();
            progressRing.IsActive = true;
            panel.Arrange(pdf.PageRectangle);
            
            //1. Export UI as an image and then draw this image in pdf document.
            var renderTargetBitmap = new RenderTargetBitmap();
            await renderTargetBitmap.RenderAsync(panel);
            var wb = new WriteableBitmap(renderTargetBitmap.PixelWidth, renderTargetBitmap.PixelHeight);
            (await renderTargetBitmap.GetPixelsAsync()).CopyTo(wb.PixelBuffer);
            var rect = new Rect(0, 0, renderTargetBitmap.PixelWidth, renderTargetBitmap.PixelHeight);
            pdf.DrawImage(wb, rect);
            
            //2. Draw every UI elements inside the panel in pdf document.
            //await pdf.DrawElement(panel, pdf.PageRectangle);
            PdfUtils.SetDocumentInfo(pdf, Strings.RenderUIDocumentTitle);
            await pdfDocSource.LoadFromStreamAsync(PdfUtils.SaveToStream(pdf).AsRandomAccessStream());
            progressRing.IsActive = false;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            btnRender_Click(btnRender, null);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            PdfUtils.Save(pdf);
        }
    }
}
