using C1.Xaml;
using C1.Xaml.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace ImagingSamples
{
    public sealed partial class Crop : Page
    {
        C1Bitmap bitmap = new C1Bitmap();
        Rect selection;

        public Crop()
        {
            InitializeComponent();

            LoadDefaultImage();
            image.Source = bitmap.ImageSource;

            var mouseHelper = new C1DragHelper(imageGrid);
            mouseHelper.DragStarted += OnDragStarted;
            mouseHelper.DragDelta += OnDragDelta;
        }

        Point _startPosition;
        void OnDragStarted(object sender, C1DragStartedEventArgs e)
        {
            _startPosition = e.Origin;
        }

        void OnDragDelta(object sender, C1DragDeltaEventArgs e)
        {
            var transform = Window.Current.Content.TransformToVisual(image);
            var start = transform.TransformPoint(_startPosition);
            var end = transform.TransformPoint(e.GetPosition(null));
            start.X = Math.Min((double)Math.Max(start.X, 0), bitmap.Width);
            end.X = Math.Min((double)Math.Max(end.X, 0), bitmap.Width);
            start.Y = Math.Min((double)Math.Max(start.Y, 0), bitmap.Height);
            end.Y = Math.Min((double)Math.Max(end.Y, 0), bitmap.Height);

            selection = new Rect(new Point( 
                Math.Round(Convert.ToDouble(Math.Min(start.X, end.X))),
                Math.Round(Convert.ToDouble(Math.Min(start.Y, end.Y)))),
                new Size(Convert.ToDouble(Math.Round(Math.Abs(start.X - end.X))),
                    Convert.ToDouble(Math.Round(Math.Abs(start.Y - end.Y)))));

            UpdateMask();
        }

        void UpdateMask()
        {
            topMask.Height = selection.Top;
            bottomMask.Height = bitmap.Height - selection.Bottom;
            leftMask.Width = selection.Left;
            rightMask.Width = bitmap.Width - selection.Right;
        }

        void LoadDefaultImage()
        {
            Assembly asm = typeof(Crop).GetTypeInfo().Assembly;
            Stream stream = asm.GetManifestResourceStream("ImagingSamples.Assets.Lenna.jpg");
            LoadImageStream(stream);
        }

        private async void LoadImage(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();

            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".gif");
            picker.FileTypeFilter.Add(".jpeg");

            StorageFile file = await picker.PickSingleFileAsync();
            
            if (file != null)
            {
                using (var fileStream = await file.OpenStreamForReadAsync())
                {
                    try
                    {
                        LoadImageStream(fileStream);
                    }
                    catch (Exception ex)
                    {
                        LoadDefaultImage();
                        MessageDialog md = new MessageDialog(Strings.ImageFormatNotSupportedException + ex.Message, "");
                        md.ShowAsync();
                    }
                }
            }
        }

        void LoadImageStream(Stream stream)
        {
            bitmap.SetStream(stream);
            
            imageGrid.Width = bitmap.Width;
            imageGrid.Height = bitmap.Height;

            selection = new Rect(0, 0, bitmap.Width, bitmap.Height);
            UpdateMask();
        }

        private async void ExportImage(object sender, RoutedEventArgs e)
        {
            if(selection.Width == 0 || selection.Height == 0)
            {
                MessageDialog md = new MessageDialog(Strings.EmptySelectionMessage);
                md.ShowAsync();
                return;
            }
            var picker = new FileSavePicker();
            picker.FileTypeChoices.Add("png", new List<string>{".png"});
            picker.DefaultFileExtension = ".png";

            StorageFile file = await picker.PickSaveFileAsync();

            if (file != null)
            {
                var saveStream = await file.OpenStreamForWriteAsync();
                var crop = new C1Bitmap((int)selection.Width, (int)selection.Height);
                crop.BeginUpdate();
                for (int x = 0; x < selection.Width; ++x)
                {
                    for (int y = 0; y < selection.Height; ++y)
                    {
                        crop.SetPixel(x, y, bitmap.GetPixel(x + (int)selection.X, y + (int)selection.Y));
                    }
                }
                crop.EndUpdate();
                var readStream = crop.GetStream(ImageFormat.Png, true);
                var data = new byte[readStream.Length];
                readStream.Read(data, 0, (int)readStream.Length);
                saveStream.Write(data, 0, data.Length);
                saveStream.Dispose();
            }
        }
    }
}
