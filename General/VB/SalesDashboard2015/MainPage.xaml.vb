Imports Windows.Graphics.Display
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

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        AddHandler DisplayProperties.OrientationChanged, AddressOf DisplayProperties_OrientationChanged
    End Sub

    Private Sub DisplayProperties_OrientationChanged(sender As Object)
        If Not IsWindowsPhoneDevice() Then
            OrientationChanged()
        End If
    End Sub

    Private Sub OrientationChanged()
        If DisplayProperties.CurrentOrientation = DisplayOrientations.Portrait OrElse DisplayProperties.CurrentOrientation = DisplayOrientations.PortraitFlipped Then
            'FristFrame
            FristFrame.RowDefinitions.Add(New RowDefinition() With {
                .Height = New GridLength(2, GridUnitType.Star)
            })
            FristFrame.ColumnDefinitions.RemoveAt(0)
            Grid.SetRow(salesByType, 2)
            salesByType.Margin = New Thickness(0, 20, 0, 0)

            'LastFrame
            LastFrame.RowDefinitions.Add(New RowDefinition() With {
                .Height = New GridLength(2, GridUnitType.Star)
            })
            LastFrame.ColumnDefinitions.RemoveAt(0)
            Grid.SetRow(salesByCategory, 2)

            salesByCategory.Margin = New Thickness(0, 20, 0, 0)
        Else
            'FristFrame
            FristFrame.ColumnDefinitions.Add(New ColumnDefinition())
            FristFrame.RowDefinitions.RemoveAt(0)
            Grid.SetRow(salesByType, 0)
            Grid.SetColumn(salesByType, 1)
            Grid.SetRowSpan(salesByType, 2)
            salesByType.Margin = New Thickness(20, 0, 0, 0)

            'LastFrame
            LastFrame.ColumnDefinitions.Add(New ColumnDefinition())
            LastFrame.RowDefinitions.RemoveAt(0)
            Grid.SetRow(salesByCategory, 0)
            Grid.SetColumn(salesByCategory, 1)
            Grid.SetRowSpan(salesByCategory, 2)
            salesByCategory.Margin = New Thickness(20, 0, 0, 0)
        End If
    End Sub

    Private Function IsWindowsPhoneDevice() As Boolean
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            Return True
        End If

        Return False
    End Function
End Class