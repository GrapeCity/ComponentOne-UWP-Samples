Imports Windows.Storage
Imports Windows.Storage.Pickers

Imports C1.Xaml.Bitmap

Imports D2D = C1.Util.DX.Direct2D
Imports D3D = C1.Util.DX.Direct3D11
Imports DW = C1.Util.DX.DirectWrite
Imports DXGI = C1.Util.DX.DXGI
Imports C1.Util.DX

Public NotInheritable Class MainPage
    Inherits Page

    Private _imageSource As SurfaceImageSource
    Private _sisNative As DXGI.ISurfaceImageSourceNative
    Private _bitmap As C1Bitmap

    ' device-independent resources
    Private _d2dFactory As D2D.Factory2
    Private _dwFactory As DW.Factory

    ' device resources
    Private _dxgiDevice As DXGI.Device
    Private _d2dContext As D2D.DeviceContext1
    Private _brush As D2D.SolidColorBrush
    Private _textLayout As DW.TextLayout1

    ' Direct2D built-in effects
    Private _shadow As D2D.Effects.Shadow
    Private _affineTransform As D2D.Effects.AffineTransform2D
    Private _composite As D2D.Effects.Composite
    Private _displacementMap As D2D.Effects.DisplacementMap
    Private _turbulence As D2D.Effects.Turbulence
    Private _tile As D2D.Effects.Tile
    Private _gaussianBlur As D2D.Effects.GaussianBlur
    Private _convolveMatrix As D2D.Effects.ConvolveMatrix
    Private _colorMatrix As D2D.Effects.ColorMatrix
    Private _flood As D2D.Effects.Flood
    Private _crop As D2D.Effects.Crop

    Private Const _marginLT As Int32 = 20
    Private Const _marginRB As Int32 = 36

    Enum ImageEffect
        Original
        GaussianBlur
        Sharpen
        HorizontalSmear
        Shadow
        DisplacementMap
        Emboss
        EdgeDetect
        Sepia
    End Enum

    Public Sub New()
        Me.InitializeComponent()

        AddHandler Loaded, AddressOf MainPage_Loaded

        ' The Unloaded event is not actually executed until the user
        ' navigates to another Page. We add the handler anyway
        ' to show the clean up process for unmanaged resources.
        AddHandler Unloaded, AddressOf MainPage_Unloaded
    End Sub

    Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
        ' locate the image
        Dim imageUri = New Uri("ms-appx:///Assets/GcLogo.png")
        Dim stgFile = Await StorageFile.GetFileFromApplicationUriAsync(imageUri)

        ' load the image into C1Bitmap
        _bitmap = New C1Bitmap()
        Await _bitmap.LoadAsync(stgFile, New FormatConverter(PixelFormat.Format32bppPBGRA))

        ' create Direct2D and DirectWrite factories
        _d2dFactory = D2D.Factory2.Create(D2D.FactoryType.SingleThreaded)
        _dwFactory = DW.Factory.Create(DW.FactoryType.[Shared])

        ' create GPU resources
        CreateDeviceResources()

        ' create the image source
        _imageSource = New SurfaceImageSource(_marginLT + _bitmap.PixelWidth + _marginRB, _marginLT + _bitmap.PixelHeight + _marginRB, False)

        ' obtain the native interface for the image source
        _sisNative = ComObject.QueryInterface(Of DXGI.ISurfaceImageSourceNative)(_imageSource)
        _sisNative.SetDevice(_dxgiDevice)

        ' draw the image to SurfaceImageSource
        UpdateImageSource(ImageEffect.Original)

        ' associate the image source with the Image
        imageElement.Source = _imageSource
    End Sub

    Private Sub MainPage_Unloaded(sender As Object, e As RoutedEventArgs)
        DiscardDeviceResources()

        _bitmap.Dispose()
        _d2dFactory.Dispose()
        _dwFactory.Dispose()

        imageElement.Source = Nothing
        _sisNative.Dispose()
        _sisNative = Nothing
    End Sub

    Private Sub Original_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.Original)
    End Sub

    Private Sub GaussianBlur_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.GaussianBlur)
    End Sub

    Private Sub Sharpen_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.Sharpen)
    End Sub

    Private Sub HorizontalSmear_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.HorizontalSmear)
    End Sub

    Private Sub Shadow_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.Shadow)
    End Sub

    Private Sub DisplacementMap_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.DisplacementMap)
    End Sub

    Private Sub Emboss_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.Emboss)
    End Sub

    Private Sub EdgeDetect_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.EdgeDetect)
    End Sub

    Private Sub Sepia_Click(sender As Object, e As RoutedEventArgs)
        UpdateImageSource(ImageEffect.Sepia)
    End Sub

    Private Async Sub Export_Click(sender As Object, e As RoutedEventArgs)
        Await ExportGrayscale()
    End Sub

    ''' <summary>
    ''' Creates and initializes GPU resources.
    ''' </summary>
    Private Sub CreateDeviceResources()
        ' create the Direct3D device
        Dim actualLevel As D3D.FeatureLevel
        Dim d3dContext As D3D.DeviceContext = Nothing
        Dim d3dDevice = New D3D.Device(IntPtr.Zero)
        Dim result = HResult.Ok
        For i As Integer = 0 To 1
            ' use WARP if hardware is not available
            Dim dt = If(i = 0, D3D.DriverType.Hardware, D3D.DriverType.Warp)
            result = D3D.D3D11.CreateDevice(Nothing, dt, IntPtr.Zero, D3D.DeviceCreationFlags.BgraSupport Or D3D.DeviceCreationFlags.SingleThreaded, Nothing, 0,
                D3D.D3D11.SdkVersion, d3dDevice, actualLevel, d3dContext)
            If result.Code <> -2005270524 Then
                ' DXGI_ERROR_UNSUPPORTED
                Exit For
            End If
        Next
        result.CheckError()
        d3dContext.Dispose()

        ' store the DXGI device (for trimming when the application is being suspended)
        _dxgiDevice = d3dDevice.QueryInterface(Of DXGI.Device)()
        d3dDevice.Dispose()

        ' create a RenderTarget (DeviceContext for Direct2D drawing)
        Dim d2dDevice = D2D.Device1.Create(_d2dFactory, _dxgiDevice)
        Dim rt = D2D.DeviceContext1.Create(d2dDevice, D2D.DeviceContextOptions.None)
        d2dDevice.Dispose()
        rt.SetUnitMode(D2D.UnitMode.Pixels)
        _d2dContext = rt

        ' create built-in effects
        _shadow = D2D.Effects.Shadow.Create(rt)
        _affineTransform = D2D.Effects.AffineTransform2D.Create(rt)
        _composite = D2D.Effects.Composite.Create(rt)
        _displacementMap = D2D.Effects.DisplacementMap.Create(rt)
        _turbulence = D2D.Effects.Turbulence.Create(rt)
        _tile = D2D.Effects.Tile.Create(rt)
        _gaussianBlur = D2D.Effects.GaussianBlur.Create(rt)
        _convolveMatrix = D2D.Effects.ConvolveMatrix.Create(rt)
        _colorMatrix = D2D.Effects.ColorMatrix.Create(rt)
        _flood = D2D.Effects.Flood.Create(rt)
        _crop = D2D.Effects.Crop.Create(rt)

        ' create a brush and TextLayout for drawing text on the image
        _brush = D2D.SolidColorBrush.Create(rt, ColorF.Red)

        Dim format = DW.TextFormat.Create(_dwFactory, "Gabriola", DW.FontWeight.Bold, DW.FontStyle.Normal, 28.0F)
        _textLayout = DW.TextLayout1.Create(_dwFactory, Strings.StoneInscription, format, 350.0F, 100.0F)
        format.Dispose()

        ' add a font feature for more beautiful text
        Dim typo = DW.Typography.Create(_dwFactory)
        Dim fontFeature = New DW.FontFeature(DW.FontFeatureTag.StylisticSet7, 1)
        typo.AddFontFeature(fontFeature)
        _textLayout.SetTypography(typo, New DW.TextRange(0, 100))
        typo.Dispose()
    End Sub

    ''' <summary>
    ''' Releases GPU resources.
    ''' </summary>
    Private Sub DiscardDeviceResources()
        _shadow.Dispose()
        _affineTransform.Dispose()
        _composite.Dispose()
        _displacementMap.Dispose()
        _turbulence.Dispose()
        _tile.Dispose()
        _gaussianBlur.Dispose()
        _convolveMatrix.Dispose()
        _colorMatrix.Dispose()
        _flood.Dispose()
        _crop.Dispose()

        _textLayout.Dispose()
        _brush.Dispose()
        _dxgiDevice.Dispose()
        _d2dContext.Dispose()
    End Sub

    ''' <summary>
    ''' This method must be executed when the application is suspending,
    ''' to avoid reporting an issue by Windows App Certification Kit.
    ''' </summary>
    Public Sub TrimDxgiDevice()
        If _dxgiDevice IsNot Nothing Then
            Using dxgiDevice = _dxgiDevice.QueryInterface(Of DXGI.Device3)()
                dxgiDevice.Trim()
            End Using
        End If
    End Sub

    ''' <summary>
    ''' Draws the image on SurfaceImageSource.
    ''' </summary>
    Private Sub UpdateImageSource(imgEffect As ImageEffect)
        Dim w As Integer = _bitmap.PixelWidth + _marginLT + _marginRB
        Dim h As Integer = _bitmap.PixelHeight + _marginLT + _marginRB
        Dim surfaceOffset As Point2L = Point2L.Empty
        Dim dxgiSurface As DXGI.Surface = Nothing
        Dim hr = HResult.Ok

        ' receive the target DXGI.Surface and offset for drawing
        For i As Integer = 0 To 1
            hr = _sisNative.BeginDraw(New RectL(w, h), surfaceOffset, dxgiSurface)
            If (hr <> DXGI.ResultCode.DeviceRemoved AndAlso hr <> DXGI.ResultCode.DeviceReset) OrElse i > 0 Then
                Exit For
            End If

            ' try to recreate the device resources if the old GPU device was removed
            DiscardDeviceResources()
            CreateDeviceResources()
            _sisNative.SetDevice(_dxgiDevice)
        Next
        hr.CheckError()

        ' the render target object
        Dim rt = _d2dContext

        ' create the target Direct2D bitmap for the given DXGI.Surface
        Dim bpTarget = New D2D.BitmapProperties1(New D2D.PixelFormat(DXGI.Format.B8G8R8A8_UNorm, D2D.AlphaMode.Premultiplied), CSng(_bitmap.DpiX), CSng(_bitmap.DpiY), D2D.BitmapOptions.Target Or D2D.BitmapOptions.CannotDraw)
        Dim targetBmp = D2D.Bitmap1.Create(rt, dxgiSurface, bpTarget)
        dxgiSurface.Dispose()

        ' associate the target bitmap with render target
        rt.SetTarget(targetBmp)
        targetBmp.Dispose()

        ' start drawing
        rt.BeginDraw()

        ' clear the target bitmap
        rt.Clear(Nothing)

        ' convert C1Bitmap image to Direct2D image
        Dim d2dBitmap = _bitmap.ToD2DBitmap1(rt, D2D.BitmapOptions.None)
        surfaceOffset.Offset(_marginLT, _marginLT)

        ' apply the effect or just draw the original image
        Select Case imgEffect
            Case ImageEffect.Original
                rt.DrawImage(d2dBitmap, surfaceOffset.ToPoint2F())
                Exit Select
            Case ImageEffect.GaussianBlur
                rt.DrawImage(ApplyGaussianBlur(d2dBitmap), surfaceOffset.ToPoint2F())
                Exit Select
            Case ImageEffect.Sharpen
                rt.DrawImage(ApplySharpen(d2dBitmap), surfaceOffset.ToPoint2F())
                Exit Select
            Case ImageEffect.HorizontalSmear
                rt.DrawImage(ApplyHorizontalSmear(d2dBitmap), surfaceOffset.ToPoint2F())
                Exit Select
            Case ImageEffect.Shadow
                rt.DrawImage(ApplyShadow(d2dBitmap), surfaceOffset.ToPoint2F())
                Exit Select
            Case ImageEffect.DisplacementMap
                rt.DrawImage(ApplyDisplacementMap(d2dBitmap), surfaceOffset.ToPoint2F())
                Exit Select
            Case ImageEffect.Emboss
                rt.DrawImage(ApplyEmboss(d2dBitmap), surfaceOffset.ToPoint2F())
                Exit Select
            Case ImageEffect.EdgeDetect
                rt.DrawImage(ApplyEdgeDetect(d2dBitmap), surfaceOffset.ToPoint2F())
                Exit Select
            Case ImageEffect.Sepia
                rt.DrawImage(ApplySepia(d2dBitmap), surfaceOffset.ToPoint2F())
                Exit Select
        End Select
        d2dBitmap.Dispose()

        ' draw the additional text label in case of the Shadow effect
        If imgEffect = ImageEffect.Shadow Then
            Dim mr = Matrix3x2.Rotation(-90.0F)
            Dim mt = Matrix3x2.Translation(surfaceOffset.X + 6, surfaceOffset.Y + 344)
            rt.Transform = mr * mt
            _brush.SetColor(ColorF.White)
            rt.DrawTextLayout(New Point2F(-1.0F, -1.0F), _textLayout, _brush)
            _brush.SetColor(ColorF.DimGray)
            rt.DrawTextLayout(Point2F.Empty, _textLayout, _brush)
            rt.Transform = Matrix3x2.Identity
        End If

        ' finish drawing (all drawing commands are executed at that moment)
        rt.EndDraw()

        ' detach and actually dispose the target bitmap
        rt.SetTarget(Nothing)

        ' complete drawing on SurfaceImageSource
        _sisNative.EndDraw()
    End Sub

    Private Function ApplyGaussianBlur(bitmap As D2D.Bitmap1) As D2D.Effect
        _gaussianBlur.SetInput(0, bitmap)
        _gaussianBlur.BorderMode = D2D.BorderMode.Soft
        _gaussianBlur.StandardDeviation = 3.0F
        Return _gaussianBlur
    End Function

    Private Function ApplySharpen(bitmap As D2D.Bitmap1) As D2D.Effect
        _convolveMatrix.SetInput(0, bitmap)
        _convolveMatrix.KernelSizeX = 3
        _convolveMatrix.KernelSizeY = 3
        _convolveMatrix.KernelMatrix = New Single() {
            0F, -1.0F, 0F,
            -1.0F, 6.0F, -1.0F,
            0F, -1.0F, 0F}
        _convolveMatrix.Divisor = 2.0F
        Return _convolveMatrix
    End Function

    Private Function ApplyHorizontalSmear(bitmap As D2D.Bitmap1) As D2D.Effect
        _convolveMatrix.SetInput(0, bitmap)
        _convolveMatrix.KernelSizeX = 20
        _convolveMatrix.KernelSizeY = 1
        _convolveMatrix.KernelMatrix = New Single() {
            1.0F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F,
            1.0F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F,
            1.0F, 1.0F, 1.0F, 1.0F, 1.0F, 1.0F,
            1.0F, 1.0F}
        _convolveMatrix.Divisor = 20.0F
        Return _convolveMatrix
    End Function

    Private Function ApplyShadow(bitmap As D2D.Bitmap1) As D2D.Effect
        _shadow.SetInput(0, bitmap)
        _shadow.BlurStandardDeviation = 5.0F
        _affineTransform.SetInputEffect(0, _shadow)
        _affineTransform.TransformMatrix = Matrix3x2.Translation(20.0F, 20.0F)
        _composite.SetInputEffect(0, _affineTransform)
        _composite.SetInput(1, bitmap)
        Return _composite
    End Function

    Private Function ApplyDisplacementMap(bitmap As D2D.Bitmap1) As D2D.Effect
        _displacementMap.SetInput(0, bitmap)
        _turbulence.Stitchable = True
        _tile.SetInputEffect(0, _turbulence)
        _tile.Rectangle = New Vector4(0, 0, 512, 512)
        _displacementMap.SetInputEffect(1, _tile)
        _displacementMap.Scale = 100.0F
        Return _displacementMap
    End Function

    Private Function ApplyEmboss(bitmap As D2D.Bitmap1) As D2D.Effect
        _convolveMatrix.SetInput(0, bitmap)
        _convolveMatrix.KernelSizeX = 3
        _convolveMatrix.KernelSizeY = 3
        _convolveMatrix.KernelMatrix = New Single() {
            2.0F, 1.0F, 0F,
            1.0F, 1.0F, -1.0F,
            0F, -1.0F, -2.0F}
        _convolveMatrix.Divisor = 1.0F
        Return _convolveMatrix
    End Function

    Private Function ApplyEdgeDetect(bitmap As D2D.Bitmap1) As D2D.Effect
        _flood.Color = ColorF.Black
        _crop.SetInputEffect(0, _flood)
        _crop.Rectangle = New Vector4(0, 0, _bitmap.PixelWidth, _bitmap.PixelHeight)
        _convolveMatrix.SetInput(0, bitmap)
        _convolveMatrix.KernelSizeX = 3
        _convolveMatrix.KernelSizeY = 3
        _convolveMatrix.KernelMatrix = New Single() {
            0F, -1.0F, 0F,
            -1.0F, 4.0F, -1.0F,
            0F, -1.0F, 0F}
        _convolveMatrix.Divisor = 1.0F
        _composite.SetInputEffect(0, _crop)
        _composite.SetInputEffect(1, _convolveMatrix)
        Return _composite
    End Function

    Private Function ApplySepia(bitmap As D2D.Bitmap1) As D2D.Effect
        _colorMatrix.SetInput(0, bitmap)
        _colorMatrix.Matrix = New Matrix5x4(
            0.393F, 0.349F, 0.272F, 0,
            0.769F, 0.686F, 0.534F, 0,
            0.189F, 0.168F, 0.131F, 0,
            0, 0, 0, 1,
            0, 0, 0, 0)
        Return _colorMatrix
    End Function

    Private Async Function ExportGrayscale() As Task
        Dim picker = New FileSavePicker()
        picker.FileTypeChoices.Add("Jpeg files", New List(Of String)() From {
            ".jpg"
        })
        picker.DefaultFileExtension = ".jpg"

        ' the user should pick the output file
        Dim file As StorageFile = Await picker.PickSaveFileAsync()
        If file IsNot Nothing Then
            ' the render target object
            Dim rt = _d2dContext

            ' create the target Direct2D bitmap for the given DXGI.Surface
            Dim bpTarget = New D2D.BitmapProperties1(New D2D.PixelFormat(DXGI.Format.B8G8R8A8_UNorm, D2D.AlphaMode.Premultiplied), CSng(_bitmap.DpiX), CSng(_bitmap.DpiY), D2D.BitmapOptions.Target Or D2D.BitmapOptions.CannotDraw)
            Dim bmpSize As New Size2L(_bitmap.PixelWidth, _bitmap.PixelHeight)
            Dim targetBmp = D2D.Bitmap1.Create(rt, bmpSize, bpTarget)

            ' associate the target bitmap with render target
            rt.SetTarget(targetBmp)

            ' start drawing
            rt.BeginDraw()

            ' clear the target bitmap
            rt.Clear(Nothing)

            ' convert C1Bitmap image to Direct2D image
            Dim d2dBitmap = _bitmap.ToD2DBitmap1(rt, D2D.BitmapOptions.None)

            ' create the Grayscale effect
            _colorMatrix.SetInput(0, d2dBitmap)
            _colorMatrix.Matrix = New Matrix5x4(
                0.299F, 0.299F, 0.299F, 0,
                0.587F, 0.587F, 0.587F, 0,
                0.114F, 0.114F, 0.114F, 0,
                0, 0, 0, 1,
                0, 0, 0, 0)

            ' and draw the result
            rt.DrawImage(_colorMatrix, Point2F.Empty)
            d2dBitmap.Dispose()

            ' now let's draw the additional text label with shadow
            rt.Transform = Matrix3x2.Rotation(-90.0F) * Matrix3x2.Translation(6.0F, 344.0F)
            _brush.SetColor(ColorF.White)
            rt.DrawTextLayout(New Point2F(-1.0F, -1.0F), _textLayout, _brush)
            _brush.SetColor(ColorF.DimGray)
            rt.DrawTextLayout(Point2F.Empty, _textLayout, _brush)
            rt.Transform = Matrix3x2.Identity

            ' finish drawing (all drawing commands are executed now)
            If Not rt.EndDraw(True) Then
                ' clean up and return if the GPU device was removed and we can't draw
                targetBmp.Dispose()
                Return
            End If

            ' detach the target bitmap
            rt.SetTarget(Nothing)

            ' create a temporary C1Bitmap object
            Dim exportBitmap = New C1Bitmap(_bitmap.ImagingFactory)

            ' import the image from Direct2D target bitmap to C1Bitmap
            Dim srcRect = New RectL(_bitmap.PixelWidth, _bitmap.PixelHeight)
            exportBitmap.Import(targetBmp, rt, srcRect)
            targetBmp.Dispose()

            ' save the image to file
            Await exportBitmap.SaveAsJpegAsync(file, Nothing)
            exportBitmap.Dispose()
        End If
    End Function

End Class
