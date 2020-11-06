Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.Storage.Streams
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Threading.Tasks
Imports System.Net.Http
Imports System.Net
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class LargeFile
    Inherits Page
    Private pdf As String = "http://wwwimages.adobe.com/content/dam/Adobe/en/devnet/pdf/pdfs/adobe_supplement_iso32000.pdf"
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Loaded, AddressOf LargeFile_Loaded
        AddHandler Unloaded, AddressOf LargeFile_Unloaded
    End Sub

    Private Sub LargeFile_Unloaded(sender As Object, e As RoutedEventArgs)
        pdfViewer.CloseDocument()
    End Sub

    Private Sub LargeFile_Loaded(sender As Object, e As RoutedEventArgs)
        LoadDocument()
    End Sub

    Private Async Sub LoadDocument()
        loading.Visibility = Visibility.Visible
        retry.Visibility = Visibility.Collapsed
        viewer.Visibility = Visibility.Collapsed

        ' load file from the Web
        Dim client As New HttpClient()

        Try
            Dim stream As Stream = Await client.GetStreamAsync(New Uri(pdf, UriKind.Absolute))
            pdfViewer.LoadDocument(stream)

            loading.Visibility = Visibility.Collapsed
            viewer.Visibility = Visibility.Visible
            retry.Visibility = Visibility.Collapsed
        Catch
            Dim dialog As New MessageDialog(Strings.DownloadException)
            dialog.ShowAsync()
            loading.Visibility = Visibility.Collapsed
            retry.Visibility = Visibility.Visible
        End Try
    End Sub

    Private Sub Retry_Click(sender As Object, e As RoutedEventArgs)
        LoadDocument()
    End Sub

End Class