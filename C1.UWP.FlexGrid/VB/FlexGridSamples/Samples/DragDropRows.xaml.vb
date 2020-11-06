Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class DragDropRows
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Loaded, AddressOf DragDropRows_Loaded
        _flex.AllowDragging = C1.Xaml.FlexGrid.AllowDragging.Both
        _flex.AllowSorting = False
    End Sub

    Private Async Sub DragDropRows_Loaded(sender As Object, e As RoutedEventArgs)
        Dim data As List(Of NorthwindData) = Await NorthwindStorage.Load()
        _flex.ItemsSource = data
    End Sub
End Class