Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports C1.Xaml.Tile
Imports Windows.UI.Popups

''' <summary>
''' 
''' </summary>
Partial Public NotInheritable Class ContentSourceSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Async Sub LoadContent()
        sv.Visibility = Visibility.Collapsed
        loading.Visibility = Visibility.Visible
        retry.Visibility = Visibility.Collapsed
        Try
            For Each tile As C1Tile In tilePanel.Children
                Dim content As List(Of FlickrPhoto) = Await FlickrPhoto.Load(CType(tile.Header, String))
                loading.Visibility = Visibility.Collapsed
                sv.Visibility = Visibility.Visible
                tile.ContentSource = CType(content, IEnumerable)
            Next
        Catch
            Dim dialog As New MessageDialog(Strings.DownloadFlickrErrorMessage)
            Dim result As IUICommand = CType(dialog.ShowAsync(), IUICommand)
            retry.Visibility = Visibility.Visible
            loading.Visibility = Visibility.Collapsed
        End Try
    End Sub

    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        LoadContent()
    End Sub
End Class