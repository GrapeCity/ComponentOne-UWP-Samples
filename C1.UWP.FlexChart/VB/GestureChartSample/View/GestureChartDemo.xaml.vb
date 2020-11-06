Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class GestureChartDemo
    Inherits UserControl
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub OnResetButtonClick(sender As Object, e As RoutedEventArgs)
        gestureChart.AxisX.Min = Double.NaN
        gestureChart.AxisX.Max = Double.NaN
        gestureChart.AxisY.Min = Double.NaN
        gestureChart.AxisY.Max = Double.NaN
    End Sub
End Class