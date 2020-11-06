Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports C1.Xaml.Word.Objects
Imports C1.Xaml.Word
Imports Windows.Graphics.Imaging
Imports System.Threading.Tasks
Imports Windows.Storage.Streams
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class RenderUIPage
    Inherits Page
    Private _doc As C1WordDocument

    Public Sub New()
        Me.InitializeComponent()

        _doc = New C1WordDocument(PaperKind.Letter)
    End Sub

    Private Async Sub btnRender_Click(sender As Object, e As RoutedEventArgs)
        _doc.Clear()
        progressRing.IsActive = True
        _doc.Landscape = True
        Dim sz As Size = _doc.PageSize
        Dim rc As New Rect(0, 0, sz.Width, sz.Height)

        '_doc.PageSize = new Size(_doc.PageSize.Height, _doc.PageSize.Width); // landscape view
        panel.Arrange(rc)

        ' 1. Export UI as an image and then draw this image in word document.
        Dim renderTargetBitmap As New RenderTargetBitmap()
        Await renderTargetBitmap.RenderAsync(panel)
        Dim wb As New WriteableBitmap(renderTargetBitmap.PixelWidth, renderTargetBitmap.PixelHeight)
        Dim pixels As IBuffer = Await renderTargetBitmap.GetPixelsAsync()
        pixels.CopyTo(wb.PixelBuffer)
        Dim rect As New Rect(0, 0, renderTargetBitmap.PixelWidth, renderTargetBitmap.PixelHeight)
        '_doc.DrawImage(wb, rect);

        ' 2. Draw every UI elements inside the panel in word document.
        Await _doc.DrawElement(panel, rc)

        WordUtils.SetDocumentInfo(_doc, Strings.RenderUIDocumentTitle)
        WordUtils.Save(_doc)
        progressRing.IsActive = False
    End Sub
End Class