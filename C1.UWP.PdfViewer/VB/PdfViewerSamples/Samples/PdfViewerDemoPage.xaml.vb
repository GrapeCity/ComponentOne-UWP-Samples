Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class PdfViewerDemoPage
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Loaded, AddressOf PdfViewerDemoPage_Loaded
        AddHandler Unloaded, AddressOf PdfViewerDemoPage_Unloaded
    End Sub

    Private Sub PdfViewerDemoPage_Unloaded(sender As Object, e As RoutedEventArgs)
        pdfViewer.CloseDocument()
    End Sub

    Private Sub PdfViewerDemoPage_Loaded(sender As Object, e As RoutedEventArgs)
        Dim asm As Assembly = GetType(PdfViewerDemoPage).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream("PdfViewerSamples.GCDataSheet_2016.pdf")
        pdfViewer.LoadDocument(stream)
        cmbOrientation.SelectedIndex = 1
    End Sub

    Private Async Sub btnLoad_Click(sender As Object, e As Windows.UI.Xaml.RoutedEventArgs)
        Dim openPicker As New FileOpenPicker()
        openPicker.FileTypeFilter.Add(".pdf")

        Dim file As StorageFile = Await openPicker.PickSingleFileAsync()
        If file IsNot Nothing Then
            Dim stream As Stream = Await file.OpenStreamForReadAsync()
            pdfViewer.LoadDocument(stream)
        End If

    End Sub

    Private Sub cmbOrientation_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If cmbOrientation.SelectedIndex = 0 Then
            pdfViewer.Orientation = Windows.UI.Xaml.Controls.Orientation.Horizontal
        Else
            pdfViewer.Orientation = Windows.UI.Xaml.Controls.Orientation.Vertical
        End If
    End Sub

End Class