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
Public NotInheritable Partial Class MainSample
		Inherits Page
		Private sampleData As New SampleData()
		Public Sub New()
			Me.InitializeComponent()
			sparklineType.ItemsSource = [Enum].GetValues(GetType(SparklineType))
			sparklineType.SelectedItem = sparkline.SparklineType

			sparkline.Data = sampleData.DefaultData
		End Sub

		Private Sub sparklineType_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
			sparkline.SparklineType = CType(sparklineType.SelectedItem, SparklineType)
		End Sub

		Private Sub checkBox_Click(sender As Object, e As RoutedEventArgs)
			If checkBox.IsChecked.Value Then
				sparkline.DateAxisData = sampleData.DefaultDateAxisData
			Else
				If sparkline.DateAxisData IsNot Nothing Then
					sparkline.DateAxisData = Nothing
				End If
			End If
		End Sub

		Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
			Dim cnt As Integer = 12
			Dim vals As Double() = New Double(cnt) {}
			Dim rnd As New Random()
			Dim i As Integer = 0
			While i < cnt
				vals(i) = rnd.[Next](-50, 50)
				i += 1
			End While
			sparkline.Data = vals
		End Sub
	End Class
