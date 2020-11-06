using C1.BarCode;
using C1.Xaml.BarCode;
using System;
using System.Collections.Generic;
using System.IO;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace BarCodeSamples
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PhoneBarCodePage : Page
    {
        private List<string> _types;

        public PhoneBarCodePage()
        {
            this.InitializeComponent();
        }

        public List<string> Types
        {
            get
            {
                if (_types == null)
                {
                    _types = new List<string>()
                    {
                        "QRCode",
                        "DataMatrix",
                        "Pdf417",
                        "Code39x",
                        "Ansi39x",
                        "Code93x"
                    };
                }

                return _types;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var encodingText = (string)e.Parameter;
            this.barCode.DataContext = encodingText;
        }

        private void OnSaveImageBtnClick(object sender, RoutedEventArgs e)
        {
            ExportToImage();
        }

        private async void ExportToImage()
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
