Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Zoom
    Inherits Page
    Private _function1Source As List(Of DataPoint)
    Private _function2Source As List(Of DataPoint)
    Private zooming As Boolean = False
    Private ptStart As New Point()

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub Zoom_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        SetupChart()
    End Sub

    Sub SetupChart()
        flexChart.ManipulationMode = ManipulationModes.TranslateX Or ManipulationModes.TranslateY
        flexChart.BeginUpdate()
        Me.Function1.ItemsSource = Function1Source
        Me.Function2.ItemsSource = Function2Source
        flexChart.EndUpdate()
    End Sub

    Public ReadOnly Property Function1Source() As List(Of DataPoint)
        Get
            If _function1Source Is Nothing Then
                _function1Source = DataCreator.Create(Function(x) 2 * Math.Sin(0.16 * x), Function(y) 2 * Math.Cos(0.12 * y), 160)
            End If

            Return _function1Source
        End Get
    End Property

    Public ReadOnly Property Function2Source() As List(Of DataPoint)
        Get
            If _function2Source Is Nothing Then
                _function2Source = DataCreator.Create(Function(x) Math.Sin(0.1 * x), Function(y) Math.Cos(0.15 * y), 160)
            End If

            Return _function2Source
        End Get
    End Property

    Private Sub PerformZoom(ptStart As Point, ptLast As Point)
        Dim p1 As Point = flexChart.PointToData(ptStart)
        Dim p2 As Point = flexChart.PointToData(ptLast)
        flexChart.BeginUpdate()
        ' Update axes with new limits
        flexChart.AxisX.Min = Math.Min(p1.X, p2.X)
        flexChart.AxisY.Min = Math.Min(p1.Y, p2.Y)
        flexChart.AxisX.Max = Math.Max(p1.X, p2.X)
        flexChart.AxisY.Max = Math.Max(p1.Y, p2.Y)
        flexChart.EndUpdate()
    End Sub

    Private Sub DrawReversibleRectangle(p1 As Point, p2 As Point)
        ' Normalize the rectangle
        Dim rc As New Rect(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p2.X - p1.X), Math.Abs(p2.Y - p1.Y))

        ' Draw the reversible frame
        reversibleFrame.Rect = rc
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        flexChart.BeginUpdate()
        ' Restore default values for axis limits
        flexChart.AxisX.Min = Double.NaN
        flexChart.AxisY.Min = Double.NaN
        flexChart.AxisX.Max = Double.NaN
        flexChart.AxisY.Max = Double.NaN
        flexChart.EndUpdate()
    End Sub

    Private Sub flexChart_ManipulationStarted(sender As Object, e As ManipulationStartedRoutedEventArgs)
        reversibleFrameContainer.Visibility = Visibility.Visible
        ' Start zooming
        zooming = True
        ' Save starting point of selection rectangle
        ptStart = e.Position
    End Sub

    Private Sub flexChart_ManipulationDelta(sender As Object, e As ManipulationDeltaRoutedEventArgs)
        ' when zooming update selection range
        If zooming Then
            Dim currentPosition As Point = e.Position
            Dim ptCurrent As Point = currentPosition
            ' Draw new frame
            DrawReversibleRectangle(ptStart, ptCurrent)
        End If
    End Sub

    Private Sub flexChart_ManipulationCompleted(sender As Object, e As ManipulationCompletedRoutedEventArgs)
        ' End zooming
        zooming = False
        reversibleFrameContainer.Visibility = Visibility.Collapsed
        reversibleFrame.Rect = New Rect()
        Dim currentPosition As Point = e.Position
        PerformZoom(ptStart, currentPosition)
        'Clean up
        ptStart = New Point()
    End Sub
End Class