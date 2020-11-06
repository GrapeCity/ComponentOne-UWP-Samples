Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports C1.Xaml.Tile
Imports C1.Xaml
Imports Windows.UI.Core

''' <summary>
''' 
''' </summary>
Partial Public NotInheritable Class GridViewSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        Dim source As New ObservableCollection(Of SampleItem)()
        Dim i As Integer = 1
        While i < 45
            source.Add(New SampleItem() With {
                .Title = Strings.SampleDataTitle + i.ToString(),
                .Header = Strings.SampleDataHeader + i.ToString()
                       })
            i += 1
        End While
        gridView.ItemsSource = source
    End Sub
End Class

''' <summary>
''' The GridView control is much more advanced ItemsControl than ListBox. It supports items reodering and dragging.
''' It also can use WrapGrid as an ItemsPanel. That requires some additional code for correct working with C1 tiles in the GridView.ItemTemplate.
''' Please, carefully read code comments for more information.
''' </summary>
Public Class MyGridView
    Inherits GridView
    Public Sub New()
    End Sub

    Dim tileList As IList(Of DependencyObject)

    ' The default GridView virtualization reuses the ContentTemplate visual tree for different elements.
    ' The GridView creates the limited number of C1Tile objects and reuses them at scrolling. 
    ' So, the C1Tile content is changed when end-user scrolls the GridView. 
    ' Unfortunately, WrapGrid doesn't honor VirtualizingStackPanel.VirtualizationMode="Standard" setting.
    ' So we need some code to workaround this issue.
    ' To avoid ContentChange animations while scrolling, freeze tiles in the ClearContainerForItemOverride
    ' and unfreeze after reusing them for the new item.
    Protected Overrides Async Sub PrepareContainerForItemOverride(element As DependencyObject, item As Object)
        MyBase.PrepareContainerForItemOverride(element, item)
        tileList = Nothing
        tileList = New List(Of DependencyObject)()
        VTreeHelper.GetChildrenOfType(element, GetType(C1TileBase), tileList)
        Await Dispatcher.RunAsync(CoreDispatcherPriority.Low, UnFrozenTile())
    End Sub

    Protected Overrides Sub ClearContainerForItemOverride(element As DependencyObject, item As Object)
        Dim list As IList(Of DependencyObject) = New List(Of DependencyObject)()
        VTreeHelper.GetChildrenOfType(element, GetType(C1TileBase), list)
        For Each tile As C1TileBase In list
            tile.IsFrozen = True
        Next
        MyBase.ClearContainerForItemOverride(element, item)
    End Sub

    Private Function UnFrozenTile() As DispatchedHandler
        ' unfreeze ile after changing tile content.
        For Each tile As C1TileBase In tileList
            tile.IsFrozen = False
        Next
        Return New DispatchedHandler(AddressOf UnFrozenTile)
    End Function
End Class