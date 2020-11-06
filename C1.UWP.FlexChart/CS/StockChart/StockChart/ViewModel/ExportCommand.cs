using C1.Chart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Windows.UI.Xaml;
using System.IO;
using C1.Xaml.Chart;
using Windows.Storage.Pickers;
using Windows.Storage;

namespace StockChart.ViewModel
{

    public class ExportCommand : DependencyObject, System.Windows.Input.ICommand
    {
        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, new EventArgs());
            }
        }

        ChartViewModel _viewModel;
        public ExportCommand(ChartViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return parameter != null;
        }

        public async void Execute(object parameter)
        {
            string type = parameter.ToString();


            string fmt = string.Empty;
            C1.Xaml.Chart.ImageFormat format = C1.Xaml.Chart.ImageFormat.Png;
            switch (type)
            {
                case "PNG":
                    fmt = "png";
                    format = C1.Xaml.Chart.ImageFormat.Png;
                    break;
                case "JPG":
                    fmt = "jpg";
                    format = C1.Xaml.Chart.ImageFormat.Jpeg;
                    break;
                case "SVG":
                    fmt = "svg";
                    format = C1.Xaml.Chart.ImageFormat.Svg;
                    break;
                default:
                    fmt = "png";
                    format = C1.Xaml.Chart.ImageFormat.Png;
                    break;
            }
            var picker = new FileSavePicker();

            picker.FileTypeChoices.Add(fmt.ToString().ToUpper(), new List<string>() { "." + fmt.ToString().ToLower() });

            StorageFile file = await picker.PickSaveFileAsync();
            if (file != null)
            {
                Stream stream = new MemoryStream();
                var extension = file.FileType.Substring(1, file.FileType.Length - 1);
                _viewModel.MainChart.SaveImage(stream, format);
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
