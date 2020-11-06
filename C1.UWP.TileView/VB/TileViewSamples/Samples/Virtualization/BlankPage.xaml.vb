Imports System.Xml.Serialization
Imports System.Threading.Tasks
Imports Windows.Storage
Imports System.Reflection
Imports System.ComponentModel.DataAnnotations
Imports System.Collections.ObjectModel
Imports Windows.UI.Xaml.Navigation
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
Partial Public NotInheritable Class BlankPage
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        Me.InitDataSource()
    End Sub

    Private Sub InitDataSource()
        AddHandler Me.Loaded, AddressOf OnLoaded
    End Sub

    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        Dim assembly As Assembly = GetType(AmazonBooksPage).GetTypeInfo().Assembly
        Dim celebrities As List(Of Celebrity) = New List(Of Celebrity)
        Dim doc As XDocument = XDocument.Load(New StreamReader(assembly.GetManifestResourceStream("TileViewSamples.Celebrity.xml")))
        Dim nodes As IEnumerable(Of XElement) = doc.Descendants("Celebrity")
        For Each node As XElement In nodes
            Dim celebrity As Celebrity = New Celebrity() With
                {
                .ID = Integer.Parse(node.Element("ID").Value),
                .Name = node.Element("Name").Value,
                .Description = node.Element("Description").Value
                }
            celebrities.Add(celebrity)
        Next
        c1tileView1.ItemsSource = CType(celebrities, IEnumerable)
    End Sub
End Class

Public Class Celebrity
    <Display(Name:="ID")>
    Public Property ID() As Integer

    <Display(Name:="Name")>
    Public Property Name() As String

    <Display(Name:="Description")>
    Public Property Description() As String
End Class