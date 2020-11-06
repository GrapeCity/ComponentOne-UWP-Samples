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
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;


namespace ImagingSamples
{
    public sealed partial class FaceWarp : Page
    {
        const int imageSize = 470 * 470;

        C1Bitmap originalBitmap = new C1Bitmap();
        C1Bitmap bitmap = new C1Bitmap();
        C1Bitmap screen = new C1Bitmap();
        Point _position;

        public FaceWarp()
        {
            InitializeComponent();

            LoadDefaultImage();
            image.Source = screen.ImageSource;

            var mouseHelper = new C1DragHelper(image, captureElementOnPointerPressed: true, initialThreshold:0);
            var line = new Line();
            mouseHelper.DragStarted += (s, e) =>
            {
                _position = e.GetPosition(image);
                line = new Line
                {
                    X1 = _position.X,
                    Y1 = _position.Y,
                    X2 = _position.X,
                    Y2 = _position.Y,
                    Stroke = new SolidColorBrush(Colors.Blue),
                    StrokeThickness = 7,
                    StrokeEndLineCap = PenLineCap.Triangle,
                    StrokeStartLineCap = PenLineCap.Round
                };
                imageGrid.Children.Add(line);
            };
            mouseHelper.DragDelta += (s, e) =>
            {
                var pos = e.GetPosition(image);
                line.X2 = pos.X;
                line.Y2 = pos.Y;
            };
            mouseHelper.DragCompleted += (s, e) =>
            {
                imageGrid.Children.Remove(line);
                var start = _position;
                var end = new Point(_position.X + e.CumulativeTranslation.X, _position.Y + e.CumulativeTranslation.Y);

                bitmap = new C1Bitmap(screen);
                Warp(bitmap, screen, start, end);
            };
        }

        void Warp(C1Bitmap src, C1Bitmap dst, Point start, Point end)
        {
            dst.BeginUpdate();
            dst.Copy(src, false);

            var dist = Distance(start, end);
            var affectedDist = dist * 1.5;
            var affectedDistSquared = affectedDist * affectedDist;
            for (int row = 0; row < dst.Height; ++row)
            {
                for (int col = 0; col < dst.Width; ++col)
                {
                    var point = new Point(col, row);
                    if (DistanceSq(start, point) > affectedDistSquared)
                    {
                        continue;
                    }
                    if (DistanceSq(end, point) < 0.25)
                    {
                        dst.SetPixel(col, row, src.GetPixel((int)start.X, (int)start.Y));
                        continue;
                    }
                    var dir = new Point(point.X - end.X, point.Y - end.Y);
                    var t = IntersectRayCircle(end, dir, start, affectedDist);
                    TryT(-end.X / dir.X, ref t);
                    TryT(-end.Y / dir.Y, ref t);
                    TryT((dst.Width - end.X) / dir.X, ref t);
                    TryT((dst.Height - end.X) / dir.X, ref t);
                    var anchor = new Point(end.X + (point.X - end.X) * t, end.Y + (point.Y - end.Y));
                    var x = start.X + (anchor.X - start.X) / t;
                    var y = start.Y + (anchor.Y - start.Y) / t;
                    dst.SetPixel(col, row, src.GetInterpolatedPixel(x, y));
                }
            }
            dst.EndUpdate();
        }

        static double Distance(Point a, Point b)
        {
            return Math.Sqrt(DistanceSq(a, b));
        }

        static double DistanceSq(Point a, Point b)
        {
            var dx = a.X - b.X;
            var dy = a.Y - b.Y;
            return dx * dx + dy * dy;
        }

        static void TryT(double t2, ref double t)
        {
            if (t2 > 0 && t2 < t)
            {
                t = t2;
            }
        }

        static double IntersectRayCircle(Point rayOri, Point rayDir, Point center, double radius)
        {
            var a = rayDir.X;
            var b = rayOri.X;
            var c = center.X;
            var d = rayDir.Y;
            var e = rayOri.Y;
            var f = center.Y;
            var g = radius * radius;

            var num1 = Math.Sqrt(d * (2 * a * (b - c) * (e - f) - d * (b * b - 2 * b * c + c * c - g)) - a * a * (e * e - 2 * e * f + f * f - g));
            var num2 = a * (c - b) + d * (f - e);
            return (num1 + num2 > 0 ? num1 + num2 : num1 - num2) / (a * a + d * d);
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
            picker.FileTypeFilter.Add(".bmp");
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
            if (bitmap.Width * bitmap.Height > imageSize)
            {
                var scale = Math.Sqrt(imageSize * 1.0 / (bitmap.Width * bitmap.Height));
                var resizedBitmap = new C1Bitmap((int)(bitmap.Width * scale), (int)(bitmap.Height * scale));
                resizedBitmap.Copy(bitmap, true);
                bitmap = resizedBitmap;
            }
            originalBitmap.Copy(bitmap, false);
            screen.Copy(bitmap, false);

            imageGrid.Width = screen.Width;
            imageGrid.Height = screen.Height;
        }

        private async void ExportImage(object sender, RoutedEventArgs e)
        {
            var picker = new FileSavePicker();
            picker.FileTypeChoices.Add("png", new List<string> { ".png" });
            picker.DefaultFileExtension = ".png";

            StorageFile file = await picker.PickSaveFileAsync();

            if (file != null)
            {
                var saveStream = await file.OpenStreamForWriteAsync();
                var readStream = screen.GetStream(ImageFormat.Png, true);
                var data = new byte[readStream.Length];
                readStream.Read(data, 0, (int)readStream.Length);
                saveStream.Write(data, 0, data.Length);
                saveStream.Dispose();
            }
        }

        private void Restart(object sender, RoutedEventArgs e)
        {
            bitmap.Copy(originalBitmap, false);
            screen.Copy(originalBitmap, false);
        }
    }
}
