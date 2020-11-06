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
Imports C1.Xaml.Sparkline

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Partial Class AppearanceSample
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Loaded, AddressOf AppearanceSample_Loaded
    End Sub

    Private Sub AppearanceSample_Loaded(sender As Object, e As RoutedEventArgs)
        sparklineType.SelectedIndex = 0
        SeriesColor.SelectedIndex = 1
        MarksColor.SelectedIndex = 2
        HightMarkColor.SelectedIndex = 1
        LowMarkColor.SelectedIndex = 2
        FirstMarkColor.SelectedIndex = 7
        LastMarkColor.SelectedIndex = 1
        NegativeColor.SelectedIndex = 1
        XAxisColor.SelectedIndex = 3
    End Sub
	End Class
