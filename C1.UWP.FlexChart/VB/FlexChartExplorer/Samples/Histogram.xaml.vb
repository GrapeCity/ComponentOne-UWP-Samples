Imports C1.Xaml.Chart

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Histogram
    Inherits Page

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property FlexChartInstance() As C1FlexChart
        Get
            Return flexChart
        End Get
    End Property

    Private Sub flexChart_Rendered(sender As Object, e As RenderEventArgs)
        tbBinWidth.Text = histogramSeries.BinWidth.ToString("0")
    End Sub

    Private Sub tbBinWidth_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim result As Double
        If (Double.TryParse(tbBinWidth.Text, result)) Then
            histogramSeries.BinWidth = result
        End If

    End Sub

    Private _bins As List(Of Bin)
    Public ReadOnly Property Data() As List(Of Bin)
        Get
            If _bins Is Nothing Then
                _bins = DataCreator.CreateHistogramData()
            End If
            Return _bins
        End Get
    End Property

End Class