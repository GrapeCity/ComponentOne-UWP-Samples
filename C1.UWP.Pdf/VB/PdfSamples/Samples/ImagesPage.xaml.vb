Imports Windows.UI.Core
Imports Windows.Graphics.Imaging
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Storage.Streams
Imports Windows.Storage
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Pdf

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class ImagesPage
    Inherits Page
    Private pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf ImagesPage_Loaded

        pdf = PdfUtils.CreatePdfDocument()
    End Sub

    Async Sub ImagesPage_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        Await CreateDocumentImages(pdf)
        SetDocumentInfo(pdf, Strings.ImagesDocumentTitle)
        Await c1PdfViewer1.LoadDocumentAsync(SaveToStream(pdf))
        progressRing.IsActive = False
    End Sub

    Async Function CreateDocumentImages(pdf As C1PdfDocument) As Task
        ' calculate page rect (discounting margins)
        Dim rcPage As Rect = PageRectangle(pdf)
        Dim ras As New InMemoryRandomAccessStream()

        ' title
        Dim font As New Font("Segoe UI Light", 16, PdfFontStyle.Italic)
        pdf.DrawString(Strings.ImagesDocumentTitle, font, Colors.Black, New Rect(72, 72, 400, 100))

        ' load image into writeable bitmap
        Dim wb As New WriteableBitmap(880, 660)
        Dim file As StorageFile = Await StorageFile.GetFileFromApplicationUriAsync(New Uri("ms-appx:///PdfSamplesLib/Assets/pic.jpg"))

        wb.SetSource(Await file.OpenReadAsync())

        ' simple draw image
        Dim rcPic As New Rect(72, 100, wb.PixelWidth / 5.0, wb.PixelHeight / 5.0)
        pdf.DrawImage(wb, rcPic)

        ' draw on page preserving aspect ratio
        Dim delta As Double = 100.0
        rcPic = New Rect(New Point(delta, delta), New Point(rcPage.Width - delta, rcPage.Height - delta))
        pdf.DrawImage(wb, rcPic, ContentAlignment.MiddleCenter, Stretch.Uniform)

        ' translucent rectangle
        Dim clr As Color = Color.FromArgb(50, 0, 255, 0)
        pdf.FillRectangle(clr, New Rect(200, 200, 300, 400))
    End Function

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Save(pdf)
    End Sub
End Class