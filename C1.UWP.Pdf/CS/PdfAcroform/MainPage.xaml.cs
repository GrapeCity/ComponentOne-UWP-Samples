using C1.Xaml.Pdf;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PdfAcroform
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        C1PdfDocument _pdf;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += BasicText_Loaded;

            _pdf = new C1PdfDocument(C1.Xaml.Pdf.PaperKind.Letter);
            //word = new C1WordDocument(PaperKind.Letter);
            //word.Clear();
        }
        async void BasicText_Loaded(object sender, RoutedEventArgs e)
        {
            progressRing.IsActive = true;
            PdfUtil.CreateDocument(_pdf);
            await c1PdfViewer1.LoadDocumentAsync(PdfUtil.SaveToStream(_pdf));
            progressRing.IsActive = false;
        }
        async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.FileTypeChoices.Add("Adobe PDF (*.pdf)", new List<string>() { ".pdf" });
            picker.DefaultFileExtension = ".pdf";
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                PdfUtil.CreateDocument(_pdf);
                await _pdf.SaveAsync(file);

                MessageDialog dlg = new MessageDialog("Saved to path: " + file.Path, "C1Pdf");
                await dlg.ShowAsync();
            }
        }
    }
}
