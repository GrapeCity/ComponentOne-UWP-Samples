using System;
using System.IO;
using System.Linq;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.Generic;

using C1.Xaml.Chart;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FlexChartExplorer
{
    public sealed partial class ImageExport : Page
    {
        int cnt = 100;
        Random rnd = new Random();
        string[] coef = new string[]
        {
          "AMTMNQQXUYGA",
          "CVQKGHQTPHTE",
          "FIRCDERRPVLD",
          "GIIETPIQRRUL",
          "GLXOESFTTPSV",
          "GXQSNSKEECTX",
        };

        public ImageExport()
        {
            this.InitializeComponent();
            this.Loaded += ImageExport_Loaded;
        }

        private void ImageExport_Loaded(object sender, RoutedEventArgs e)
        {
            CreateData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateData();
        }

        void CreateData()
        {
            flexChart.BeginUpdate();
            flexChart.ItemsSource = DataCreator.Create(coef, cnt);
            flexChart.EndUpdate();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var picker = new FileSavePicker();
            Enum.GetNames(typeof(ImageFormat)).ToList().ForEach(fmt =>
            {
                picker.FileTypeChoices.Add(fmt.ToString().ToUpper(), new List<string>() { "." + fmt.ToString().ToLower() });
            });
            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                Stream stream = new MemoryStream();
                var extension = file.FileType.Substring(1, file.FileType.Length - 1);
                ImageFormat fmt = (ImageFormat)Enum.Parse(typeof(ImageFormat), extension, true);
                flexChart.SaveImage(stream, fmt);
                using (Stream saveStream = await file.OpenStreamForWriteAsync())
                {
                    stream.CopyTo(saveStream);
                    stream.Seek(0, SeekOrigin.Begin);
                    saveStream.Seek(0, SeekOrigin.Begin);
                    saveStream.Flush();
                    saveStream.Dispose();
                }
            }
        }
    }
}
