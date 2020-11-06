Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.BarCode

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class DemoBarCode
    Inherits Page
    Private CategoriesData As New List(Of Category)()
    Public Sub New()
        Me.InitializeComponent()
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            AddHandler Loaded, AddressOf Generator_Loaded
        End If
    End Sub

    Sub Generator_Loaded(sender As Object, e As RoutedEventArgs)
        frame.Navigate(GetType(Editor), Format.Email)
    End Sub

    Private Sub categories_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim gridView As GridView = TryCast(sender, GridView)
        If gridView.SelectedItem IsNot Nothing Then
            Dim selectedItem As Category = CType(gridView.SelectedItem, Category)
            Dim format As Format = selectedItem.Format
            Dim frame As Frame = TryCast(Window.Current.Content, Frame)
            frame.Navigate(GetType(Editor), format)
        End If
    End Sub

    Private Sub AppBarButton_Click(sender As Object, e As RoutedEventArgs)
        Dim btn As AppBarButton = CType(sender, AppBarButton)
        Dim tag As Object = btn.Tag
        Dim fmt As Format = CType([Enum].Parse(GetType(Format), tag.ToString()), Format)
        frame.Navigate(GetType(Editor), fmt)
    End Sub
End Class