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
Imports C1.Xaml.TileView


Partial Public NotInheritable Class MainPage2
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim button As Button = TryCast(sender, Button)
        Dim index As Integer = Integer.Parse(button.Tag.ToString())
        Dim tile As C1TileViewItem = TryCast(tileView.Items(index), C1TileViewItem)
        tile.TiledState = If(tile.TiledState = TiledState.Maximized, TiledState.Tiled, TiledState.Maximized)
    End Sub
End Class