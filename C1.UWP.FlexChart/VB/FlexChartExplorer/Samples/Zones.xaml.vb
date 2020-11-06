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
Imports C1.Xaml.Chart
Imports C1.Chart

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Zones
    Inherits Page
    Const STUDENTS_COUNT As Integer = 200
    Const MAX_POINT As Integer = 1600
    Private rnd As New Random()
    Private _zones() As Double
    Private _data As List(Of StudentScore) = New List(Of StudentScore)
    Private _zones_colors As Color() = New Color() {Color.FromArgb(64, 255, 192, 192), Color.FromArgb(128, 55, 228, 228), Color.FromArgb(128, 255, 228, 128), Color.FromArgb(128, 128, 255, 128), Color.FromArgb(128, 128, 128, 225)}

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub Zones_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        SetupChart()
    End Sub

    Public Sub SetupChart()
        Dim i As Integer = 0
        While i < STUDENTS_COUNT
            Dim d As StudentScore = New StudentScore() With {
                .Number = i,
                .Score = CType((MAX_POINT * 0.5 * (1 + rnd.NextDouble())), Integer)
            }
            _data.Add(d)
            i += 1
        End While
        flexChart.ItemsSource = _data
        ' Calculate statistics
        Dim mean As Double = FindMean(_data)
        Dim stdDev As Double = FindStdDev(_data, mean)
        flexChart.BeginUpdate()
        Dim j As Integer = -2
        While j <= 2
            Dim y As Double = mean + j * stdDev
            Dim sdata() As Point = {New Point(0, y), New Point(STUDENTS_COUNT - 1, y)}
            Dim series As New Series() With {
                    .BindingX = "X",
                    .Binding = "Y",
                    .ChartType = ChartType.Line,
                    .Style = New ChartStyle() With {
                        .Stroke = flexChart.Foreground,
                        .StrokeThickness = 2
                    },
                    .ItemsSource = sdata
                }

            If Math.Abs(j) = 1 Then
                series.Style.StrokeDashArray = New DoubleCollection() From {
                    5,
                    1
                }
            ElseIf Math.Abs(j) = 2 Then
                series.Style.StrokeDashArray = New DoubleCollection() From {
                    2,
                    2
                }
            End If

            If j > 0 Then
                series.SeriesName = "m+" + j.ToString() + "s"
            ElseIf j < 0 Then
                series.SeriesName = "m" + j.ToString() + "s"
            Else
                series.SeriesName = "mean"
            End If

            flexChart.Series.Add(series)
            j += 1
        End While
        Dim scores() As Integer = _data.Select(Function(x) x.Score).OrderByDescending(Function(x) x).ToArray()
        _zones = {
            scores(GetBoundingIndex(scores, 0.95)), scores(GetBoundingIndex(scores, 0.75)), scores(GetBoundingIndex(scores, 0.25)), scores(GetBoundingIndex(scores, 0.05))}

        ' Add _zones to legend
        Dim z As Integer = 0
        While i < 5
            Dim series As New Series() With {
                .ChartType = ChartType.Area,
                .SeriesName = "ABCDE"(i).ToString(),
                .Style = New ChartStyle() With {
                    .Stroke = New SolidColorBrush(Colors.Transparent),
                    .Fill = New SolidColorBrush(_zones_colors(4 - z))
                }
            }
            flexChart.Series.Add(series)
            z += 1
        End While

        flexChart.EndUpdate()
    End Sub

    Sub DrawAlarmZone(chart As C1FlexChart, engine As IRenderEngine, xmin As Double, ymin As Double, xmax As Double, ymax As Double,
        fill As Color)
        Dim pt1 As Point = chart.DataToPoint(New Point(xmin, ymin))
        Dim pt2 As Point = chart.DataToPoint(New Point(xmax, ymax))
        engine.SetFill(New SolidColorBrush(fill))
        engine.SetStroke(New SolidColorBrush(Colors.Transparent))
        engine.DrawRect(Math.Min(pt1.X, pt2.X), Math.Min(pt1.Y, pt2.Y), Math.Abs(pt2.X - pt1.X), Math.Abs(pt2.Y - pt1.Y))
    End Sub

    Function GetBoundingIndex(data As Integer(), frac As Double) As Integer
        Dim n As Integer = data.Length
        Dim i As Integer = CType(Math.Ceiling(n * frac), Integer)
        While i > data(0) AndAlso data(i) = data(i + 1)
            i -= 1
        End While

        Return i
    End Function

    Function FindMean(data As List(Of StudentScore)) As Double
        Dim sum As Double = 0
        data.ForEach(Sub(x) sum = sum + x.Score)
        Return sum / data.Count
    End Function

    Function FindStdDev(data As List(Of StudentScore), mean As Double) As Double
        Dim sum As Double = 0
        Dim i As Integer = 0
        data.ForEach(Sub(x)
                         Dim d As Double = x.Score - mean
                         sum = sum + d * d
                     End Sub)
        Return Math.Sqrt(sum / data.Count)
    End Function

    Private Sub flexChart_Rendering(sender As Object, e As RenderEventArgs)
        Dim engine As IRenderEngine = e.Engine
        Dim chart As C1FlexChart = TryCast(sender, C1FlexChart)
        If engine Is Nothing OrElse chart Is Nothing OrElse _zones Is Nothing Then
            Return
        End If

        Dim i As Integer = 0
        While i < 5
            Dim ymin As Double = If(i = 0, (CType(chart.AxisY, IAxis)).GetMin(), _zones(i - 1))
            Dim ymax As Double = If(i = 4, (CType(chart.AxisY, IAxis)).GetMax(), _zones(i))
            DrawAlarmZone(chart, engine, (CType(chart.AxisX, IAxis)).GetMin(), ymin, (CType(chart.AxisX, IAxis)).GetMax(), ymax,
                _zones_colors(i))
            i += 1
        End While
    End Sub
End Class

Public Class StudentScore
    Public Property Number() As Integer
    Public Property Score() As Integer
End Class