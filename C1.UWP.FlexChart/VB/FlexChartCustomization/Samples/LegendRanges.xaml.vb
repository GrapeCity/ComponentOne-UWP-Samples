Imports C1.Chart
Imports C1.Xaml.Chart
Imports Windows.UI

''' <summary>
''' Interaction logic for LegendRanges.xaml
''' </summary>
Partial Public Class LegendRanges
    Inherits Page

    Dim _engine As IRenderEngine
    Public Sub New()
        InitializeComponent()
        Dim recordsSeries As Series = New SeriesWithPointLegendItems()
        AddHandler recordsSeries.SymbolRendering, AddressOf SymbolRendering
        flexChart.Series.Add(recordsSeries)
    End Sub

    Private Sub SymbolRendering(sender As System.Object, e As RenderSymbolEventArgs)
        Dim idx As Integer = CInt((CType(e.Item, TemperatureRecord).High - 95) / 5)
        e.Engine.SetFill(New SolidColorBrush(GetTempartureRangeColor(idx)))
        e.Engine.SetStroke(New SolidColorBrush(GetTempartureRangeColor(idx)))
    End Sub

    Private Shared Function GetTempartureRangeColor(index As Integer) As Color
        Return Color.FromArgb(CByte(80 + index * 20), 255, 0, 0)
    End Function


    Public Class SeriesWithPointLegendItems
        Inherits Series
        Implements ISeries

        ''' <summary>
        ''' Gets the name of legend.
        ''' </summary>
        ''' <param name="index"></param>
        ''' <returns></returns>
        Function GetLegendItemName(ByVal index As Int32) As String _
            Implements ISeries.GetLegendItemName
            Dim low As Integer = 95 + 5 * index
            Return low.ToString() + " to " + (low + 5).ToString()
        End Function

        ''' <summary>
        ''' Gets the style of legend.
        ''' </summary>
        ''' <param name="index"></param>
        ''' <returns></returns>
        Function GetLegendItemStyle(ByVal index As Int32) As _Style _
            Implements ISeries.GetLegendItemStyle
            Return New _Style With {.Fill = New SolidColorBrush(GetTempartureRangeColor(index))}
        End Function

        ''' <summary>
        ''' Get the number of series items in the legend.
        ''' </summary>
        ''' <returns></returns>
        Function GetLegendItemLength() As Int32 _
            Implements ISeries.GetLegendItemLength
            Return 8
        End Function

    End Class
End Class