Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation
Imports System.Text
Imports System.Collections.Generic
Imports System
Imports C1.Chart

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class HitTest
    Inherits Page
    Private _data1 As List(Of DataPoint)
    Private _data2 As List(Of DataPoint)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub HitTest_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        SetupChart()
    End Sub

    Sub SetupChart()
        flexChart.BeginUpdate()
        series0.ItemsSource = Data1
        series1.ItemsSource = Data2
        flexChart.EndUpdate()
    End Sub

    Sub HitTestOnFlexChart(p As Point)
        ' Show information about chart element under mouse/touch.
        Dim ht As HitTestInfo = flexChart.HitTest(p)
        Dim result As New StringBuilder()
        result.AppendLine(String.Format("Chart element:{0}", ht.ChartElement))
        If ht.Series IsNot Nothing Then
            result.AppendLine(String.Format("Series name:{0}", ht.Series.Name))
        End If
        If ht.PointIndex > 0 Then
            result.AppendLine(String.Format("Point index={0:0}", ht.PointIndex))
        End If
        tbPosition1.Text = result.ToString()

        Dim result2 As New StringBuilder()
        If ht.Distance > 0 Then
            result2.AppendLine(String.Format("Distance={0:0}", ht.Distance))
        End If
        If ht.X IsNot Nothing Then
            result2.AppendLine(String.Format("X={0:0:0}", ht.X))
        End If
        If ht.Y IsNot Nothing Then
            result2.AppendLine(String.Format("Y={0:0:0}", ht.Y))
        End If
        tbPosition2.Text = result2.ToString()
    End Sub

    Public ReadOnly Property Data1() As List(Of DataPoint)
        Get
            If _data1 Is Nothing Then
                _data1 = DataCreator.Create(Function(x) Math.Sin(x), 0, 60, 7)
            End If

            Return _data1
        End Get
    End Property

    Public ReadOnly Property Data2() As List(Of DataPoint)
        Get
            If _data2 Is Nothing Then
                _data2 = DataCreator.Create(Function(x) Math.Sin(x + 5), 0, 60, 7)
            End If

            Return _data2
        End Get
    End Property

    Private Sub flexChart_PointerEntered(sender As Object, e As PointerRoutedEventArgs)
        HitTestOnFlexChart(e.GetCurrentPoint(flexChart).Position)
    End Sub

    Private Sub flexChart_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        HitTestOnFlexChart(e.GetCurrentPoint(flexChart).Position)
    End Sub
End Class