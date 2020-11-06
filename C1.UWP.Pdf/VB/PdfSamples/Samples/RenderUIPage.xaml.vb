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
Imports C1.Xaml.Pdf

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class RenderUIPage
    Inherits Page
    Private pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        Dim comboItems As New List(Of String)()
        comboItems.Add(PdfSamples.Strings.ComboBoxItem1_Content)
        comboItems.Add(PdfSamples.Strings.ComboBoxItem2_Content)
        combo.ItemsSource = comboItems

        pdf = PdfUtils.CreatePdfDocument()
    End Sub

    Private Async Sub btnRender_Click(sender As Object, e As RoutedEventArgs)
        Await Task.Delay(TimeSpan.FromMilliseconds(100))
        pdf.Clear()
        If c1PdfViewer1 IsNot Nothing Then
            c1PdfViewer1.CloseDocument()
        End If
        progressRing.IsActive = True
        panel.Arrange(pdf.PageRectangle)

        '1. Export UI as an image and then draw this image in pdf document.
        Dim renderTargetBitmap As New RenderTargetBitmap()
        Await renderTargetBitmap.RenderAsync(panel)
        Dim wb As New WriteableBitmap(renderTargetBitmap.PixelWidth, renderTargetBitmap.PixelHeight)
        Dim pixels As IBuffer = Await renderTargetBitmap.GetPixelsAsync()
        pixels.CopyTo(wb.PixelBuffer)
        Dim rect As New Rect(0, 0, renderTargetBitmap.PixelWidth, renderTargetBitmap.PixelHeight)
        pdf.DrawImage(wb, rect)

        '2. Draw every UI elements inside the panel in pdf document.
        'await pdf.DrawElement(panel, pdf.PageRectangle);
        SetDocumentInfo(pdf, Strings.RenderUIDocumentTitle)
        Await c1PdfViewer1.LoadDocumentAsync(SaveToStream(pdf))
        progressRing.IsActive = False
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        btnRender_Click(btnRender, Nothing)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Save(pdf)
    End Sub
End Class