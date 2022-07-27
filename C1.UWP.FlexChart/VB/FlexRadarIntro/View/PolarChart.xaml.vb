Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation
Imports System.Collections.Generic
Imports System
Imports C1.Xaml

''' <summary>
''' Interaction logic for PolarChart.xaml
''' </summary>
Partial Public Class PolarChart
    Inherits Page
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub PolarChart_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        polarChart.ChartType = C1.Chart.RadarChartType.LineSymbols
        polarChart.ItemsSource = CreateData(10, 2)
    End Sub

    Function CreateData(k As Double, a As Double) As List(Of Point)
        Dim pts As New List(Of Point)()
        Dim n As Integer = 360
        Dim i As Integer = 0
        While i < n
            Dim angle As Double = Math.PI * i / 180
            pts.Add(New Point() With {
                .X = i,
                .Y = CType((Math.Cos(k * angle) + a), Single)
            })
            i += 1
        End While
        Return pts
    End Function

    Sub OnNumericBoxValueChanged(sender As Object, e As PropertyChangedEventArgs(Of Double))
        If numericUpDown2 IsNot Nothing AndAlso numericUpDown2 IsNot Nothing AndAlso polarChart IsNot Nothing Then
            polarChart.ItemsSource = CreateData(numericUpDownStartAngle.Value, numericUpDown2.Value)
        End If
    End Sub
End Class