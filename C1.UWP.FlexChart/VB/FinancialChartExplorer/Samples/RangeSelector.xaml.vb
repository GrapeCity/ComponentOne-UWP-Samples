Imports System.Collections.Generic
Imports Windows.UI.Xaml.Controls
Imports System

''' <summary>
''' Interaction logic for RangeSelector.xaml
''' </summary>
Partial Public Class RangeSelector
    Inherits Page
    Private dataService As DataService = dataService.GetService()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            Return dataService.GetSymbolData("fb")
        End Get
    End Property

    Sub OnRangeSelectorValueChanged(sender As Object, e As EventArgs)
        candlestickChart.AxisX.Min = rangeSelector.LowerValue
        candlestickChart.AxisX.Max = rangeSelector.UpperValue
    End Sub
End Class