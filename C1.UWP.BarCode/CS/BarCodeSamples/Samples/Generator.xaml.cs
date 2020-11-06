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
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace BarCodeSamples
{
    public sealed partial class Generator : Page
    {
        public Generator()
        {
            this.InitializeComponent();
            editor.Loaded += Editor_Loaded;
        }

        private void Editor_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshBarCode();
        }

        private void RefreshBarCode()
        {
            var entity = editor.DataContext as Entity;
            if (entity != null)
            {
                barCode.Text = entity.EncodingText;
            }
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

        private void GenerateBarCode(object sender, RoutedEventArgs e)
        {
            RefreshBarCode();
        }

        private void OnSaveImageBtnClick(object sender, RoutedEventArgs e)
        {
            ExportToImage();
        }
    }
}
