Imports C1.Xaml.Chart
Imports C1.Chart

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class RangedHistogram
    Inherits Page

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property FlexChartInstance() As C1FlexChart
        Get
            Return flexChart
        End Get
    End Property

    Private Sub Histogram_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        SetupChart()
    End Sub

    Sub SetupChart()
        flexChart.BeginUpdate()

        flexChart.EndUpdate()
    End Sub

    Private _data As List(Of WaterfallItem)
    Public ReadOnly Property Data() As List(Of WaterfallItem)
        Get
            If _data Is Nothing Then
                _data = New List(Of WaterfallItem)
                _data.Add(New WaterfallItem With {.Name = "A", .Value = 20})
                _data.Add(New WaterfallItem With {.Name = "B", .Value = 35})
                _data.Add(New WaterfallItem With {.Name = "C", .Value = 40})
                _data.Add(New WaterfallItem With {.Name = "A", .Value = 55})
                _data.Add(New WaterfallItem With {.Name = "B", .Value = 80})
                _data.Add(New WaterfallItem With {.Name = "C", .Value = 60})
                _data.Add(New WaterfallItem With {.Name = "A", .Value = 61})
                _data.Add(New WaterfallItem With {.Name = "B", .Value = 85})
                _data.Add(New WaterfallItem With {.Name = "C", .Value = 80})
                _data.Add(New WaterfallItem With {.Name = "A", .Value = 64})
                _data.Add(New WaterfallItem With {.Name = "B", .Value = 80})
                _data.Add(New WaterfallItem With {.Name = "C", .Value = 75})
                _data.Add(New WaterfallItem With {.Name = "A", .Value = 1222})
                _data.Add(New WaterfallItem With {.Name = "B", .Value = 133})
            End If
            Return _data
        End Get
    End Property

    Private _modes As List(Of String)
    Public ReadOnly Property Mode() As List(Of String)
        Get
            If _modes Is Nothing Then
                _modes = [Enum].GetNames(GetType(HistogramBinning)).ToList()
            End If
            Return _modes
        End Get
    End Property

    Private Sub flexChart_Rendered(sender As Object, e As RenderEventArgs)
        tbBinWidth.Text = histogramSeries.BinWidth.ToString("0")
        tbBinNum.Text = histogramSeries.NumberOfBins.ToString()
        tbOverflow.Text = histogramSeries.OverflowBin.ToString("0")
        tbUnderflow.Text = histogramSeries.UnderflowBin.ToString("0")
    End Sub

    Private Sub tbBinWidth_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim result As Double
        If (Double.TryParse(tbBinWidth.Text, result)) Then
            histogramSeries.BinWidth = result
        End If

    End Sub

    Private Sub cbCategory_Checked(sender As Object, e As RoutedEventArgs)
        histogramSeries.BindingX = "Name"
        histogramSeries.SeriesName = "Category Total"

        cbMode.IsEnabled = False
        cbOverflow.IsEnabled = False
        tbOverflow.IsEnabled = False
        cbUnderflow.IsEnabled = False
        tbUnderflow.IsEnabled = False
        tbBinWidth.IsEnabled = False
        tbBinNum.IsEnabled = False
    End Sub

    Private Sub cbCategory_Unchecked(sender As Object, e As RoutedEventArgs)
        histogramSeries.BindingX = ""
        histogramSeries.SeriesName = "Frequency"

        cbMode.IsEnabled = True
        cbOverflow.IsEnabled = True
        tbOverflow.IsEnabled = cbOverflow.IsChecked IsNot Nothing And cbOverflow.IsChecked.Value
        cbUnderflow.IsEnabled = True
        tbUnderflow.IsEnabled = cbUnderflow.IsChecked IsNot Nothing And cbUnderflow.IsChecked.Value
        tbBinWidth.IsEnabled = histogramSeries.BinMode = HistogramBinning.BinWidth
        tbBinNum.IsEnabled = histogramSeries.BinMode = HistogramBinning.NumberOfBins
    End Sub

    Private Sub cbOverflow_Checked(sender As Object, e As RoutedEventArgs)
        tbOverflow.IsEnabled = True
        histogramSeries.ShowOverflowBin = True
        UpdateOverflowBin()
    End Sub

    Private Sub cbOverflow_Unchecked(sender As Object, e As RoutedEventArgs)
        histogramSeries.ShowOverflowBin = False
        tbOverflow.IsEnabled = False
    End Sub

    Private Sub tbOverflow_TextChanged(sender As Object, e As TextChangedEventArgs)
        UpdateOverflowBin()
    End Sub

    Private Sub cbUnderflow_Checked(sender As Object, e As RoutedEventArgs)
        tbUnderflow.IsEnabled = True
        histogramSeries.ShowUnderflowBin = True
        UpdateUnderflowBin()
    End Sub

    Private Sub cbUnderflow_Unchecked(sender As Object, e As RoutedEventArgs)
        histogramSeries.ShowUnderflowBin = False
        tbUnderflow.IsEnabled = False
    End Sub

    Private Sub tbUnderflow_TextChanged(sender As Object, e As TextChangedEventArgs)
        UpdateUnderflowBin()
    End Sub

    Private Sub UpdateOverflowBin()
        Dim result As Double
        If (cbOverflow.IsChecked IsNot Nothing And cbOverflow.IsChecked.Value And Double.TryParse(tbOverflow.Text, result)) Then
            histogramSeries.OverflowBin = result
        End If
    End Sub

    Private Sub UpdateUnderflowBin()
        Dim result As Double
        If (cbUnderflow.IsChecked IsNot Nothing And cbUnderflow.IsChecked.Value And Double.TryParse(tbUnderflow.Text, result)) Then
            histogramSeries.UnderflowBin = result
        End If
    End Sub

    Private Sub tbBinNum_TextChanged(sender As Object, e As TextChangedEventArgs)
        Dim result As Int32
        If (Int32.TryParse(tbBinNum.Text, result)) Then
            histogramSeries.NumberOfBins = result
        End If
    End Sub

    Private Sub cbMode_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim Mode As Int32 = cbMode.SelectedIndex
        If (Mode = 0) Then
            'Automatic
            tbBinNum.IsEnabled = False
            tbBinWidth.IsEnabled = False
        ElseIf (Mode = 1) Then
            'Bin width
            tbBinWidth.IsEnabled = True
            tbBinNum.IsEnabled = False
        Else
            'Number of bins
            tbBinNum.IsEnabled = True
            tbBinWidth.IsEnabled = False
        End If
    End Sub
End Class