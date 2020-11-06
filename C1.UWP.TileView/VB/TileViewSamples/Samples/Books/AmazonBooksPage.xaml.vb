Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Xml.Linq
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class AmazonBooksPage
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        Me.InitDataSource()
    End Sub

    Private Sub InitDataSource()
        ' load book descriptions from xml
        Dim assembly As Assembly = GetType(AmazonBooksPage).GetTypeInfo().Assembly
        Dim doc As XDocument = XDocument.Load(New StreamReader(assembly.GetManifestResourceStream("TileViewSamples.Amazon.xml")))
        Dim books As IEnumerable(Of Book) = From reader In doc.Descendants("book")
                                            Select New Book() With
                                      {
                                  .Title = reader.Attribute("title").Value,
                                  .CoverUri = reader.Attribute("coverUri").Value,
                                  .Id = reader.Attribute("id").Value,
                                  .Price = reader.Attribute("price").Value,
                                  .Author = reader.Attribute("author").Value,
                                  .Description = reader.Attribute("description").Value,
                                  .StockAmount = Integer.Parse(reader.Attribute("stockAmount").Value)
                                  }
        ' set the book's item source
        c1TileView1.ItemsSource = CType(books, IEnumerable)
    End Sub
End Class

Public Class Book
    Public Property Title() As String
    Public Property CoverUri() As String
    Public Property Id() As String
    Public Property Price() As String
    Public Property Author() As String
    Public Property Description() As String
    Public Property StockAmount() As Integer
End Class