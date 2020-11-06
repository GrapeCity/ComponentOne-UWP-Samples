Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System
Imports Windows.UI.Popups

''' <summary>
''' 
''' </summary>
Partial Public NotInheritable Class ListBoxSample
    Inherits Page
    Public Sub New()
        TileCommand = New DelegateCommand(Of Object)(AddressOf ExecuteCommand, AddressOf GetCanExecuteCommand)
        Me.InitializeComponent()
    End Sub

    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        LoadPhotos()
    End Sub

    Private Async Sub LoadPhotos()
        loading.Visibility = Visibility.Visible
        retry.Visibility = Visibility.Collapsed
        Try
            Dim photos As List(Of FlickrPhoto) = Await FlickrPhoto.Load("people")
            loading.Visibility = Visibility.Collapsed
            Me.DataContext = photos
        Catch
            Dim dialog As New MessageDialog(Strings.DownloadFlickrErrorMessage)
            Dim result As IUICommand = CType(dialog.ShowAsync(), IUICommand)
            retry.Visibility = Visibility.Visible
            loading.Visibility = Visibility.Collapsed
        End Try
        splitView.IsPaneOpen = True
    End Sub

#Region "** Command"
    Public Property TileCommand() As DelegateCommand(Of Object)

    Private Sub ExecuteCommand(parameter As Object)
        ' show tile content in the preview
        ' ((FlickrPhoto)parameter).Content contains Image Uri
        Preview.Source = New Windows.UI.Xaml.Media.Imaging.BitmapImage(New Uri((CType(parameter, FlickrPhoto)).Content))
    End Sub

    Private Function GetCanExecuteCommand(parameter As Object) As Boolean
        Return True
    End Function
#End Region

    Private Sub HamburgerButton_Click(sender As Object, e As RoutedEventArgs)
        splitView.IsPaneOpen = True
        HamburgerButton.Visibility = Visibility.Collapsed
    End Sub

    Private Sub splitView_PaneClosed(sender As SplitView, args As Object)
        HamburgerButton.Visibility = Visibility.Visible
    End Sub
End Class