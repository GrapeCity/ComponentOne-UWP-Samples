using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

using Windows.Foundation;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Input;

using C1.Xaml;
using C1.Xaml.Bitmap;
using C1.Util.DX;

namespace BitmapSamples
{
    public sealed partial class Transform : Page
    {
        C1Bitmap _bitmap;
        SoftwareBitmap _softwareBitmap;
        SoftwareBitmapSource _sbs;
        C1Bitmap _savedCopy;

        Point _startPosition;
        C1DragHelper _dragHelper;
        Rect _selection;
        bool _initialized;

        public Transform()
        {
            this.InitializeComponent();

            this.Loaded += Page_Loaded;
            this.Unloaded += Page_Unloaded;
        }

        async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _bitmap = new C1Bitmap();

            await LoadDefaultImage();

            _dragHelper = new C1DragHelper(imageGrid);
            _dragHelper.DragStarted += OnDragStarted;
            _dragHelper.DragDelta += OnDragDelta;

            imageGrid.Tapped += ImageGrid_Tapped;

            _initialized = true;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_initialized)
            {
                _initialized = false;
                _dragHelper.FinalizeHelper();

                CleanImageSource();
                ClearSavedCopy();
                _bitmap.Dispose();
            }
        }

        async Task LoadDefaultImage()
        {
            Assembly asm = typeof(Crop).GetTypeInfo().Assembly;
            using (Stream stream = asm.GetManifestResourceStream("BitmapSamples.Assets.HousePlan.jpg"))
            {
                _bitmap.Load(stream, new FormatConverter(PixelFormat.Format32bppPBGRA));
            }

            ClearSavedCopy();
            _savedCopy = _bitmap.Transform();

            await UpdateImageSource();
        }

        async void LoadImage_Clicked(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();

            picker.FileTypeFilter.Add(".ico");
            picker.FileTypeFilter.Add(".bmp");
            picker.FileTypeFilter.Add(".gif");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".jxr");
            picker.FileTypeFilter.Add(".tif");
            picker.FileTypeFilter.Add(".tiff");

            StorageFile file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                try
                {
                    await _bitmap.LoadAsync(file, new FormatConverter(PixelFormat.Format32bppPBGRA));

                    ClearSavedCopy();
                    _savedCopy = _bitmap.Transform();

                    await UpdateImageSource();
                }
                catch (Exception ex)
                {
                    await LoadDefaultImage();
                    MessageDialog md = new MessageDialog(Strings.ImageFormatNotSupportedException + ex.Message, "");
                    await md.ShowAsync();
                }
            }
        }

        async Task UpdateImageSource()
        {
            CleanImageSource();
            _softwareBitmap = _bitmap.ToSoftwareBitmap();
            _sbs = new SoftwareBitmapSource();
            await _sbs.SetBitmapAsync(_softwareBitmap);
            image.Source = _sbs;

            imageGrid.Width = _bitmap.PixelWidth;
            imageGrid.Height = _bitmap.PixelHeight;

            InitSelection();
        }

        void CleanImageSource()
        {
            if (_sbs != null)
            {
                image.Source = null;
                _sbs.Dispose();
                _softwareBitmap.Dispose();
                _sbs = null;
            }
        }

        async void ExportImage_Clicked(object sender, RoutedEventArgs e)
        {
            var picker = new FileSavePicker();
            picker.FileTypeChoices.Add("png", new List<string> { ".png" });
            picker.DefaultFileExtension = ".png";

            StorageFile file = await picker.PickSaveFileAsync();

            if (file != null)
            {
                await _bitmap.SaveAsPngAsync(file, null);
                InitSelection();
            }
        }

        async void Restart_Clicked(object sender, RoutedEventArgs e)
        {
            if (_savedCopy != null)
            {
                _bitmap.Dispose();
                _bitmap = _savedCopy.Transform();
                await UpdateImageSource();
            }
        }

        void ClearSavedCopy()
        {
            if (_savedCopy != null)
            {
                _savedCopy.Dispose();
                _savedCopy = null;
            }
        }

        async Task ApplyTransform(BaseTransform t)
        {
            var newBitmap = _bitmap.Transform(t);
            _bitmap.Dispose();
            _bitmap = newBitmap;
            await UpdateImageSource();
        }

        async void CropToSelection_Clicked(object sender, RoutedEventArgs e)
        {
            var cropRect = ((RectD)_selection).Round();
            await ApplyTransform(new Clipper(new ImageRect(cropRect)));
        }

        async void RotateCW_Clicked(object sender, RoutedEventArgs e)
        {
            await ApplyTransform(new FlipRotator(TransformOptions.Rotate90));
        }

        async void RotateCCW_Clicked(object sender, RoutedEventArgs e)
        {
            await ApplyTransform(new FlipRotator(TransformOptions.Rotate270));
        }

        async void FlipH_Clicked(object sender, RoutedEventArgs e)
        {
            await ApplyTransform(new FlipRotator(TransformOptions.FlipHorizontal));
        }

        async void FlipV_Clicked(object sender, RoutedEventArgs e)
        {
            await ApplyTransform(new FlipRotator(TransformOptions.FlipVertical));
        }

        async void ScaleIn_Clicked(object sender, RoutedEventArgs e)
        {
            int px = (int)(_bitmap.PixelWidth * 1.6f + 0.5f);
            int py = (int)(_bitmap.PixelHeight * 1.6f + 0.5f);
            await ApplyTransform(new Scaler(px, py, InterpolationMode.HighQualityCubic));
        }

        async void ScaleOut_Clicked(object sender, RoutedEventArgs e)
        {
            int px = (int)(_bitmap.PixelWidth * 0.625f + 0.5f);
            int py = (int)(_bitmap.PixelHeight * 0.625f + 0.5f);
            if (px > 0 && py > 0)
            {
                await ApplyTransform(new Scaler(px, py, InterpolationMode.HighQualityCubic));
            }
        }

        void OnDragStarted(object sender, C1DragStartedEventArgs e)
        {
            _startPosition = e.Origin;
        }

        void OnDragDelta(object sender, C1DragDeltaEventArgs e)
        {
            var transform = Window.Current.Content.TransformToVisual(image);
            var start = transform.TransformPoint(_startPosition);
            var end = transform.TransformPoint(e.GetPosition(null));
            start.X = Math.Min((double)Math.Max(start.X, 0), _bitmap.PixelWidth);
            end.X = Math.Min((double)Math.Max(end.X, 0), _bitmap.PixelWidth);
            start.Y = Math.Min((double)Math.Max(start.Y, 0), _bitmap.PixelHeight);
            end.Y = Math.Min((double)Math.Max(end.Y, 0), _bitmap.PixelHeight);

            _selection = new Rect(new Point(
                Math.Round(Convert.ToDouble(Math.Min(start.X, end.X))),
                Math.Round(Convert.ToDouble(Math.Min(start.Y, end.Y)))),
                new Size(Convert.ToDouble(Math.Round(Math.Abs(start.X - end.X))),
                    Convert.ToDouble(Math.Round(Math.Abs(start.Y - end.Y)))));

            UpdateMask();
        }

        void ImageGrid_Tapped(object sender, TappedRoutedEventArgs e)
        {
            InitSelection();
        }

        void InitSelection()
        {
            _selection = new Rect(0, 0, _bitmap.PixelWidth, _bitmap.PixelHeight);
            UpdateMask();
        }

        void UpdateMask()
        {
            topMask.Height = _selection.Top;
            bottomMask.Height = _bitmap.PixelHeight - _selection.Bottom;
            leftMask.Width = _selection.Left;
            rightMask.Width = _bitmap.PixelWidth - _selection.Right;
        }
    }
}
