using C1.BarCode;
using C1.Xaml.BarCode;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace BarCodeSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewBarcodes : Page
    {
        List<CodeType> _barcodes = new List<CodeType>
        {
            CodeType.Bc412, CodeType.Code11, CodeType.HIBCCode128, CodeType.HIBCCode39, CodeType.Iata25, CodeType.IntelligentMailPackage, CodeType.ISBN, CodeType.ISMN, CodeType.ISSN, CodeType.ITF14, CodeType.MicroQRCode, CodeType.Pharmacode, CodeType.Plessey, CodeType.PZN, CodeType.SSCC18, CodeType.Telepen
        };
        public NewBarcodes()
        {
            this.InitializeComponent();
            Loaded += NewBarcodes_Loaded;
        }

        private void NewBarcodes_Loaded(object sender, RoutedEventArgs e)
        {
            BarcodeType.ItemsSource = _barcodes;
            BarcodeType.SelectedIndex = 0;
        }

        private void BarcodeType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            barCode.Text = "";
            CodeType codetype = (CodeType)BarcodeType.SelectedItem;
            barCode.CodeType = codetype;
            // Change the available text for selected barcode type
            switch (codetype)
            {
                case CodeType.HIBCCode128:
                case CodeType.HIBCCode39:
                    BarcodeText.Text = @"A123PROD78905/0123456789DATA";
                    break;
                case CodeType.IntelligentMailPackage:
                    BarcodeText.Text = "9212391234567812345671";
                    break;
                case CodeType.PZN:
                    BarcodeText.Text = "01234562";
                    break;
                case CodeType.Pharmacode:
                    BarcodeText.Text = "131070";
                    break;
                case CodeType.SSCC18:
                    BarcodeText.Text = "1234t5+678912345678";
                    break;
                case CodeType.Bc412:
                    BarcodeText.Text = "AQ1557";
                    break;
                case CodeType.MicroQRCode:
                    BarcodeText.Text = "12345";
                    break;
                case CodeType.Iata25:
                    BarcodeText.Text = "0123456789";
                    break;
                case CodeType.ITF14:
                    BarcodeText.Text = "1234567891011";
                    break;
                default:
                    BarcodeText.Text = "9790123456785";
                    break;
            }
            barCode.Text = BarcodeText.Text;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(BarcodeText.Text))
            {
                var msg = new MessageDialog(Strings.EmptyDataError);
                msg.ShowAsync();
                return;
            }
            barCode.Text = BarcodeText.Text;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileSavePicker()
            {
                DefaultFileExtension = ".jpeg",
            };
            picker.FileTypeChoices.Add("Jpeg files", new List<string>() { ".jpeg" });
            picker.FileTypeChoices.Add("Bmp Files", new List<string>() { ".bmp" });
            picker.FileTypeChoices.Add("PNG Files", new List<string>() { ".png" });
            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                var fileExtension = file.FileType.Remove(0, 1);
                using (Stream stream = new MemoryStream())
                {
                    await barCode.SaveAsync(stream, (ImageFormat)Enum.Parse(typeof(ImageFormat), fileExtension, true));
                    using (Stream saveSteam = await file.OpenStreamForWriteAsync())
                    {
                        stream.CopyTo(saveSteam);
                        stream.Seek(0, SeekOrigin.Begin);
                        saveSteam.Seek(0, SeekOrigin.Begin);
                        saveSteam.Flush();
                    }
                }
            }
        }
    }
}
