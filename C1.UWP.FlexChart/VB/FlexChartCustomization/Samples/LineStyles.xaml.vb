Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.Foundation
Imports System
Imports Windows.UI

''' <summary>
''' Interaction logic for LineStyles.xaml
''' </summary>
Partial Public Class LineStyles
    Inherits Page
    Public Sub New()
        InitializeComponent()
        flexChart.Series.ElementAt(0).Style = New C1.Xaml.Chart.ChartStyle With {.Stroke = New SolidColorBrush(Color.FromArgb(0, 0, 0, 0))}
    End Sub

    Dim previousX, previousY As Double
    Dim sequentialIncrement, sequentialDecrement As Int32

    Private Sub Series_SymbolRendered(ender As Object, e As C1.Xaml.Chart.RenderSymbolEventArgs)
        If e.Index > 0 Then
            Dim lineColor As Color
            If e.Point.Y = previousY Then
                lineColor = Color.FromArgb(255, 255, 255, 0)
                e.Engine.SetStrokePattern({2, 1})

            ElseIf e.Point.Y > previousY Then

                lineColor = Color.FromArgb(CByte(Math.Min(255, 100 + 50 * sequentialIncrement)), 0, 255, 0)
                sequentialIncrement += 1
                sequentialDecrement = 0
                e.Engine.SetStrokePattern(Nothing)

            Else
                lineColor = Color.FromArgb(CByte(Math.Min(100 + 50 * sequentialDecrement, 255)), 255, 0, 0)
                sequentialDecrement += 1
                sequentialIncrement = 0
                e.Engine.SetStrokePattern(Nothing)

            End If
            e.Engine.SetStroke(New SolidColorBrush(lineColor))
            e.Engine.SetStrokeThickness(3)
            e.Engine.DrawLine(previousX, previousY, e.Point.X, e.Point.Y)
        End If
        previousX = e.Point.X
        previousY = e.Point.Y
    End Sub

End Class