Imports C1.Xaml.Chart.Interaction
Imports C1.Chart
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Documents
Imports Windows.UI.Xaml.Controls
Imports Windows.UI
Imports System
Imports C1.Xaml.Chart

''' <summary>
''' Interaction logic for LineMarkerDemo.xaml
''' </summary>
Partial Public Class LineMarkerDemo
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Function FromArgb(clr As Integer) As Color
        Dim bytes As Byte() = BitConverter.GetBytes(clr)
        Return Color.FromArgb(bytes(3), bytes(2), bytes(1), bytes(0))
    End Function

    Private Sub OnLineMarkerPositionChanged(sender As Object, e As PositionChangedArgs)
        If flexChart IsNot Nothing Then
            Dim info As HitTestInfo = flexChart.HitTest(New Point(e.Position.X, Double.NaN))
            If info.Item Is Nothing Then
                Return
            End If
            Dim pointIndex As Integer = info.PointIndex
            Dim tb As New TextBlock()
            tb.Inlines.Add(New Run() With {
                .Text = String.Format("{0:dd-MM}", info.X)
            })
            Dim index As Integer = 0
            While index < flexChart.Series.Count
                Dim series As Series = flexChart.Series(index)
                Dim value As Object = series.GetValues(0)(pointIndex)
                Dim fill As Integer = CType((CType(flexChart, IChart)).GetColor(index), Integer)
                Dim content As String = String.Format("{0}{1} = {2}", vbLf, series.SeriesName, String.Format("{0:f2}", value))
                tb.Inlines.Add(New Run() With {
                    .Text = content,
                    .Foreground = New SolidColorBrush() With {
                        .Color = FromArgb(fill)
                    }
                })
                index += 1
            End While
            tb.IsHitTestVisible = False
            lineMarker.Content = tb
        End If
    End Sub
End Class