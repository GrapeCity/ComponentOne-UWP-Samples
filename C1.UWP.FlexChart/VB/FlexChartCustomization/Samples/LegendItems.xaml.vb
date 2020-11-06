Imports C1.Xaml.Chart
Imports C1.Chart

''' <summary>
''' Interaction logic for LegendItems.xaml
''' </summary>
Partial Public Class LegendItems
    Inherits Page
    Dim defaultSeries, customSeries As Series
    Public Sub New()
        InitializeComponent()
        flexChart.Binding = "Shipments"
        flexChart.BindingX = "Name"
        customSeries = New SeriesWithPointLegendItems()
        AddHandler customSeries.SymbolRendering, AddressOf SymbolRendering
        customSeries.SeriesName = "Shipments"
        flexChart.Series.Add(customSeries)
    End Sub

    Private Sub SymbolRendering(sender As System.Object, e As RenderSymbolEventArgs)
        e.Engine.SetFill(New SolidColorBrush(SampleViewModel.SmartPhoneVendors.ElementAt(e.Index).Color))
        e.Engine.SetStroke(New SolidColorBrush(SampleViewModel.SmartPhoneVendors.ElementAt(e.Index).Color))
    End Sub

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
            Return SampleViewModel.SmartPhoneVendors.ElementAt(index).Name
        End Function

        ''' <summary>
        ''' Gets the style of legend.
        ''' </summary>
        ''' <param name="index"></param>
        ''' <returns></returns>
        Function GetLegendItemStyle(ByVal index As Int32) As _Style _
            Implements ISeries.GetLegendItemStyle
            Return New _Style With {.Fill = New SolidColorBrush(SampleViewModel.SmartPhoneVendors.ElementAt(index).Color)}
        End Function

        ''' <summary>
        ''' Get the number of series items in the legend.
        ''' </summary>
        ''' <returns></returns>
        Function GetLegendItemLength() As Int32 _
            Implements ISeries.GetLegendItemLength
            Return SampleViewModel.SmartPhoneVendors.Count
        End Function

    End Class

    Private Sub ChbPointsLegends_Changed(sender As Object, e As RoutedEventArgs)
        If (flexChart Is Nothing) Then
            Return
        End If
        If (chbPointsLegends.IsChecked.HasValue And chbPointsLegends.IsChecked.Value) Then
            flexChart.Series.Clear()
            flexChart.Series.Add(customSeries)
        Else
            If (defaultSeries Is Nothing) Then
                defaultSeries = New Series()
                defaultSeries.SeriesName = "Shipments"
            End If
            flexChart.Series.Clear()
            flexChart.Series.Add(defaultSeries)
        End If

    End Sub
End Class

