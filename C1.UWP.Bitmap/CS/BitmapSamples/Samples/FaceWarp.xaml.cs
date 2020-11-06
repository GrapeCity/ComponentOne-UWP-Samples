using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

using C1.Xaml;
using C1.Xaml.Bitmap;

using D2D = C1.Util.DX.Direct2D;
using D3D = C1.Util.DX.Direct3D11;
using DXGI = C1.Util.DX.DXGI;
using WIC = C1.Util.DX.WIC;
using C1.Util.DX;

namespace BitmapSamples
{
    public sealed partial class FaceWarp : Page
    {
        C1Bitmap _bitmap;
        C1Bitmap _savedCopy;
        C1DragHelper _dragHelper;
        Application _app;
        Point _position;
        Line _line;
        Point2F _warpStart;
        Point2F _warpEnd;
        bool _initialized;

        SurfaceImageSource _imageSource;
        DXGI.ISurfaceImageSourceNative _sisNative;

        D2D.Factory2 _d2dFactory;
        WIC.ImagingFactory2 _wicFactory;

        DXGI.Device _dxgiDevice;
        D2D.DeviceContext1 _d2dContext;

        D2D.Effects.GaussianBlur _blur;
        WarpEffect _warp;

        public FaceWarp()
        {
            InitializeComponent();

            Loaded += Page_Loaded;
            Unloaded += Page_Unloaded;
        }

        void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CreateDeviceIndependentResources();
            _bitmap = new C1Bitmap(_wicFactory);

            CreateDeviceResources();

            LoadDefaultImage();
            _dragHelper = new C1DragHelper(image, captureElementOnPointerPressed: true, initialThreshold: 0);
            _dragHelper.DragStarted += OnDragStarted;
            _dragHelper.DragDelta += OnDragDelta;
            _dragHelper.DragCompleted += OnDragCompleted;

            _app = Application.Current;
            if (_app != null)
            {
                _app.Suspending += App_Suspending;
            }
            _initialized = true;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_initialized)
            {
                if (_app != null)
                {
                    _app.Suspending -= App_Suspending;
                }
                _initialized = false;

                _dragHelper.FinalizeHelper();

                DiscardDeviceResources();

                ClearSavedCopy();
                _bitmap.Dispose();

                DiscardDeviceIndependentResources();
            }
        }

        void App_Suspending(object sender, SuspendingEventArgs e)
        {
            TrimDxgiDevice();
        }

        void OnDragStarted(object sender, C1DragStartedEventArgs e)
        {
            _position = e.GetPosition(image);
            _line = new Line
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
            imageGrid.Children.Add(_line);
        }

        void OnDragDelta(object sender, C1DragDeltaEventArgs e)
        {
            var pos = e.GetPosition(image);
            _line.X2 = pos.X;
            _line.Y2 = pos.Y;
        }

        void OnDragCompleted(object sender, C1DragCompletedEventArgs e)
        {
            imageGrid.Children.Remove(_line);
            var start = new Point(_position.X + e.CumulativeTranslation.X, _position.Y + e.CumulativeTranslation.Y);
            var end = _position;

            var w = image.ActualWidth;
            var h = image.ActualHeight;
            _warpStart = new Point2F((float)(start.X / w), (float)(start.Y / h));
            _warpEnd = new Point2F((float)(end.X / w), (float)(end.Y / h));

            UpdateImageSource(true);
        }

        void LoadDefaultImage()
        {
            Assembly asm = typeof(Crop).GetTypeInfo().Assembly;
            using (Stream stream = asm.GetManifestResourceStream("BitmapSamples.Assets.Sheep.jpg"))
            {
                _bitmap.Load(stream, new FormatConverter(PixelFormat.Format32bppPBGRA));
            }

            ClearSavedCopy();
            _savedCopy = _bitmap.Transform();

            CreateImageSource();
        }

        async void LoadImage(object sender, RoutedEventArgs e)
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

                    CreateImageSource();
                }
                catch (Exception ex)
                {
                    LoadDefaultImage();
                    MessageDialog md = new MessageDialog(Strings.ImageFormatNotSupportedException + ex.Message, "");
                    await md.ShowAsync();
                }
            }
        }

        async void ExportImage(object sender, RoutedEventArgs e)
        {
            var picker = new FileSavePicker();
            picker.FileTypeChoices.Add("png", new List<string> { ".png" });
            picker.DefaultFileExtension = ".png";

            StorageFile file = await picker.PickSaveFileAsync();

            if (file != null)
            {
                await _bitmap.SaveAsPngAsync(file, null);
            }
        }

        void Restart(object sender, RoutedEventArgs e)
        {
            _bitmap.ImportAsFragment(_savedCopy, 0, 0);
            UpdateImageSource(false);
        }

        void ClearSavedCopy()
        {
            if (_savedCopy != null)
            {
                _savedCopy.Dispose();
                _savedCopy = null;
            }
        }

        void CreateDeviceIndependentResources()
        {
            _d2dFactory = D2D.Factory2.Create(D2D.FactoryType.SingleThreaded);
            _wicFactory = WIC.ImagingFactory2.Create();
        }

        void DiscardDeviceIndependentResources()
        {
            DXUtil.Dispose(ref _d2dFactory);
            DXUtil.Dispose(ref _wicFactory);
        }

        void CreateDeviceResources()
        {
            D3D.FeatureLevel actualLevel;
            D3D.DeviceContext d3dContext = null;
            var d3dDevice = new D3D.Device(IntPtr.Zero);
            var result = HResult.Ok;

            for (int i = 0; i <= 1; i++)
            {
                // use WARP if hardware is not available
                var dt = i == 0 ? D3D.DriverType.Hardware : D3D.DriverType.Warp;
                result = D3D.D3D11.CreateDevice(null, dt, IntPtr.Zero, D3D.DeviceCreationFlags.BgraSupport | D3D.DeviceCreationFlags.SingleThreaded,
                    null, 0, D3D.D3D11.SdkVersion, d3dDevice, out actualLevel, out d3dContext);
                if (result.Code != unchecked((int)0x887A0004)) // DXGI_ERROR_UNSUPPORTED
                {
                    break;
                }
            }
            result.CheckError();
            d3dContext.Dispose();

            _dxgiDevice = d3dDevice.QueryInterface<DXGI.Device>();
            d3dDevice.Dispose();

            var d2dDevice = D2D.Device1.Create(_d2dFactory, _dxgiDevice);
            _d2dContext = d2dDevice.CreateDeviceContext1(D2D.DeviceContextOptions.None);
            _d2dContext.SetUnitMode(D2D.UnitMode.Pixels);
            d2dDevice.Dispose();

            var sourceEffect = D2D.Effect.RegisterAndCreateCustom<WarpEffect>(_d2dFactory, _d2dContext);
            _warp = (WarpEffect)sourceEffect.CustomEffect;
            _warp.Effect = sourceEffect;

            _blur = D2D.Effects.GaussianBlur.Create(_d2dContext);
            _blur.StandardDeviation = 2f;
        }

        internal void DiscardDeviceResources()
        {
            ClearImageSource();

            DXUtil.Dispose(ref _blur);
            DXUtil.Dispose(ref _warp);

            DXUtil.Dispose(ref _dxgiDevice);
            DXUtil.Dispose(ref _d2dContext);
        }

        void TrimDxgiDevice()
        {
            if (_dxgiDevice != null)
            {
                using (var dxgiDevice = _dxgiDevice.QueryInterface<DXGI.Device3>())
                {
                    dxgiDevice.Trim();
                }
            }
        }

        void CreateImageSource()
        {
            ClearImageSource();

            _imageSource = new SurfaceImageSource(_bitmap.PixelWidth, _bitmap.PixelHeight, false);

            _sisNative = ComObject.QueryInterface<DXGI.ISurfaceImageSourceNative>(_imageSource);
            _sisNative.SetDevice(_dxgiDevice);

            UpdateImageSource(false);

            image.Source = _imageSource;
        }

        void ClearImageSource()
        {
            if (_sisNative != null)
            {
                image.Source = null;
                _sisNative.Dispose();
                _sisNative = null;
                _imageSource = null;
            }
        }

        void UpdateImageSource(bool applyWarpEffect)
        {
            Point2L surfaceOffset;
            DXGI.Surface dxgiSurface;

            int w = _bitmap.PixelWidth;
            int h = _bitmap.PixelHeight;
            var hr = _sisNative.BeginDraw(new RectL(w, h), out surfaceOffset, out dxgiSurface);
            if (hr == DXGI.ResultCode.DeviceRemoved || hr == DXGI.ResultCode.DeviceReset)
            {
                DiscardDeviceResources();
                CreateDeviceResources();
                _sisNative.SetDevice(_dxgiDevice);
                return;
            }
            hr.CheckError();

            var rt = _d2dContext;

            var bpTarget = new D2D.BitmapProperties1(
                new D2D.PixelFormat(DXGI.Format.B8G8R8A8_UNorm, D2D.AlphaMode.Premultiplied),
                (float)_bitmap.DpiX, (float)_bitmap.DpiY, D2D.BitmapOptions.Target | D2D.BitmapOptions.CannotDraw);

            var targetBmp = D2D.Bitmap1.Create(rt, dxgiSurface, bpTarget);
            dxgiSurface.Dispose();

            rt.SetTarget(targetBmp);

            rt.BeginDraw();
            rt.Clear(null);

            var buffer = _bitmap.ToD2DBitmap1(rt, D2D.BitmapOptions.None);
            if (!applyWarpEffect)
                rt.DrawBitmap(buffer, new RectF(surfaceOffset.X, surfaceOffset.Y, w, h));
            else
            {
                _warp.SetNormPositions(_warpStart, _warpEnd);
                _warp.Effect.SetInput(0, buffer);

                rt.DrawImage(_warp.Effect, new Point2F(surfaceOffset.X, surfaceOffset.Y));

                //_blur.SetInputEffect(0, _warp.Effect);
                //rt.DrawImage(_blur, new Point2F(surfaceOffset.X, surfaceOffset.Y));
            }
            buffer.Dispose();

            rt.EndDraw();
            rt.SetTarget(null);

            if (applyWarpEffect)
            {
                var srcRect = new RectL(surfaceOffset.X, surfaceOffset.Y, w, h);
                _bitmap.ImportAsFragment(targetBmp, rt, srcRect, 0, 0);
            }
            targetBmp.Dispose();

            _sisNative.EndDraw();
        }
    }
}
