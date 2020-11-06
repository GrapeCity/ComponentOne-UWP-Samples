Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports System.Xml.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Linq
Imports System.Collections.Generic
Imports C1.Xaml.Tile

Public Class FlickrPhoto
    Implements C1.Xaml.Tile.ILoadable
    Public Property Title() As String
    Public Property Thumbnail() As String
    Public Property Content() As String
    Public Property Author() As String
    Public Property ImageSource() As ImageSource

#Region "** ILoadable implementation"
    Public ReadOnly Property ILoadable_IsLoaded As Boolean Implements ILoadable.IsLoaded
        Get
            Return _isLoaded
        End Get
    End Property

    Private _isLoaded As Boolean = False

    Public Function ILoadable_Load() As Boolean Implements ILoadable.Load
        If Not _isLoaded AndAlso Not String.IsNullOrEmpty(Thumbnail) Then
            Dim img As New BitmapImage(New System.Uri(Thumbnail))
            AddHandler img.ImageOpened, AddressOf OnImageOpened
            AddHandler img.ImageFailed, AddressOf OnImageFailed
            Dim image As New ImageBrush()
            image.ImageSource = img
            ImageSource = img
        End If
        Return _isLoaded
    End Function

    Private Sub OnImageOpened()
        _isLoaded = True
    End Sub

    Private Sub OnImageFailed()
        _isLoaded = True
    End Sub

#End Region

    Shared flickrUrl As String = "http://api.flickr.com/services/feeds/photos_public.gne"
    Shared AtomNS As String = "http://www.w3.org/2005/Atom"

    ''' <summary>
    ''' Loads public photos from flickr.
    ''' </summary>
    ''' <param name="tag">If set, method uses it to load photos only with this specific tag.</param>
    ''' <returns></returns>
    Public Shared Async Function Load(tag As String) As Task(Of List(Of FlickrPhoto))

        Dim result As New List(Of FlickrPhoto)()
        Try
            Dim uri As String = If(String.IsNullOrEmpty(tag), flickrUrl, flickrUrl + "?tags=" + tag)
            Dim client As HttpWebRequest = WebRequest.CreateHttp(uri)
            Dim response As WebResponse = Await client.GetResponseAsync()

#Region "** parse flickr data"
            Using stream As Stream = CType(response.GetResponseStream(), Stream)
                Dim doc As XDocument = XDocument.Load(stream)
                For Each entry As XElement In CType(doc.Descendants(XName.[Get]("entry", AtomNS)), IEnumerable(Of XElement))
                    Dim title As String = entry.Element(XName.[Get]("title", AtomNS)).Value
                    Dim author As String = entry.Element(XName.[Get]("author", AtomNS)).Element(XName.[Get]("name", AtomNS)).Value
                    Dim enclosure As XElement = entry.Elements(XName.[Get]("link", AtomNS)).Where(Function(elem) elem.Attribute("rel").Value = "enclosure").FirstOrDefault()
                    Dim contentUri As String = enclosure.Attribute("href").Value
                    result.Add(New FlickrPhoto() With {
                            .Title = CType(title, String),
                            .Content = CType(contentUri, String),
                            .Thumbnail = CType(contentUri.Replace("_b", "_m"), String),
                            .Author = CType(author, String)
                        })
                Next
#End Region
            End Using
        Catch
        End Try
        Return result
    End Function

End Class
