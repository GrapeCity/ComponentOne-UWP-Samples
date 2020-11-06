Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Popups
Imports Windows.System
Imports System.Xml.Linq
Imports System.Net
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Xaml

Partial Public NotInheritable Class ListBoxSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Loaded, AddressOf ListBoxSample_Loaded
    End Sub

    Sub ListBoxSample_Loaded(sender As Object, e As RoutedEventArgs)
        LoadPhotos()
    End Sub

    Private Async Sub LoadPhotos()
        Dim flickrUrl As String = "http://api.flickr.com/services/feeds/photos_public.gne?tags=animals"
        Dim AtomNS As String = "http://www.w3.org/2005/Atom"
        loading.Visibility = Visibility.Visible
        retry.Visibility = Visibility.Collapsed

        Dim photos As New List(Of Photo)()
        Dim client As HttpWebRequest = WebRequest.CreateHttp(New Uri(flickrUrl))
        Try
            Dim response As WebResponse = Await client.GetResponseAsync()

            '#Region "** parse you tube data"
            Dim doc As XDocument = XDocument.Load(response.GetResponseStream())
            For Each entry As XElement In doc.Descendants(XName.[Get]("entry", AtomNS))
                Dim title As String = entry.Element(XName.[Get]("title", AtomNS)).Value
                Dim enclosure As XElement = entry.Elements(XName.[Get]("link", AtomNS)).Where(Function(elem) elem.Attribute("rel").Value = "enclosure").FirstOrDefault()
                Dim contentUri As String = enclosure.Attribute("href").Value
                Dim alternate As XElement = entry.Elements(XName.[Get]("link", AtomNS)).Where(Function(elem) elem.Attribute("rel").Value = "alternate").FirstOrDefault()
                Dim link As String = alternate.Attribute("href").Value
                photos.Add(New Photo() With {
                    .Title = title,
                    .Content = contentUri,
                    .Thumbnail = contentUri.Replace("_b", "_m"),
                    .Link = link
                })
            Next
            listBox.ItemsSource = photos
            loading.Visibility = Visibility.Collapsed
            listBox.Visibility = Visibility.Visible
            retry.Visibility = Visibility.Collapsed
        Catch
            Dim dialog As New MessageDialog(Strings.ListBoxSampleErrorMessage)
            Dim result As IUICommand = CType(dialog.ShowAsync(), IUICommand)
            loading.Visibility = Visibility.Collapsed
            retry.Visibility = Visibility.Visible
        End Try
    End Sub

    Private Sub Retry_Click(sender As Object, e As RoutedEventArgs)
        LoadPhotos()
    End Sub

    Private Async Sub listBox_ItemTapped(sender As Object, e As C1TappedEventArgs)
        If Not e.IsRightTapped Then
            Try
                Dim listBoxItem As C1ListBoxItem = TryCast(sender, C1ListBoxItem)
                Dim photo As Photo = TryCast(listBoxItem.Content, Photo)
                e.Handled = True
                Await Launcher.LaunchUriAsync(New Uri(photo.Link))
            Catch
            End Try
        End If
    End Sub
End Class

Public Class Photo
    Public Property Title() As String
    Public Property Thumbnail() As String
    Public Property Content() As String
    Public Property Link() As String
End Class