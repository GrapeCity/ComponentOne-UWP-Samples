Imports Windows.UI.Xaml.Controls
Imports System.Xml.Linq
Imports System.Reflection
Imports System.Linq
Imports System.IO

Partial Public NotInheritable Class C1BookDemo
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        Me.InitDataSource()
    End Sub

    Private Sub InitDataSource()
        ' load book descriptions from xml
        Dim assembly As Assembly = GetType(C1BookDemo).GetTypeInfo().Assembly
        Dim doc As XDocument = XDocument.Load(New StreamReader(assembly.GetManifestResourceStream("ExtendedSamples.Amazon.xml")))

        Dim books As IEnumerable(Of AmazonBookDescription) = From reader In doc.Descendants("book") Select New AmazonBookDescription() With {
                .Title = reader.Attribute("title").Value,
                .CoverUri = reader.Attribute("coverUri").Value,
                .Author = reader.Attribute("author").Value,
                .Price = reader.Attribute("price").Value
            }

        ' set the book's item source
        book.ItemsSource = books
    End Sub
End Class
