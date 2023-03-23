Imports System.Collections.Specialized
Imports C1.Chart
Imports C1.Xaml.Chart.Interaction
Imports Windows.UI

Public Class ChartViewModel
    Implements INotifyPropertyChanged
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private Sub OnPropertyChanged(propName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
    End Sub

    Private Sub New()
    End Sub


    Private Shared _Instance As ChartViewModel
    Public Shared ReadOnly Property Instance() As ChartViewModel
        Get
            If _Instance Is Nothing Then
                _Instance = New ChartViewModel()
            End If
            Return _Instance
        End Get
    End Property

#Region ""
    Private _mainSymbol As String = "MSFT"
    Public Property MainSymbol() As String
        Get
            Return _mainSymbol
        End Get
        Set
            If _mainSymbol <> Value Then
                _mainSymbol = Value


                'DataSource = DataService.Instance.GetSymbolData(_mainSymbol);
                ChangeDataSourceAsync()
            End If
        End Set
    End Property

    Private Sub ChangeDataSourceAsync()
        DataService.Instance.GetSymbolDataAsync(_mainSymbol, Async Sub(data)
                                                                 If Me.MainChart IsNot Nothing Then
                                                                     Await Me.MainChart.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                                                                                                      Sub()
                                                                                                          DataSource = data
                                                                                                      End Sub)
                                                                 End If

                                                             End Sub)
    End Sub

    Private _symbolNames As Dictionary(Of String, String)
    Public ReadOnly Property SymbolNames() As Dictionary(Of String, String)
        Get
            If _symbolNames Is Nothing Then
                _symbolNames = DataService.Instance.SymbolNames
            End If
            Return _symbolNames
        End Get
    End Property

    Public ReadOnly Property SymbolName() As String
        Get
            Return String.Format("{0}({1})", DataService.Instance.SymbolNames(_mainSymbol), _mainSymbol.ToUpper())
        End Get
    End Property

    Public ReadOnly Property Price() As Double
        Get
            If ChartViewModel.Instance.DataSource IsNot Nothing Then
                Return ChartViewModel.Instance.DataSource.Last().close
            End If
            Return 0
        End Get
    End Property

    Public ReadOnly Property Chg() As String
        Get
            If ChartViewModel.Instance.DataSource IsNot Nothing Then
                Dim quoteData = ChartViewModel.Instance.DataSource
                Dim value = quoteData(Math.Max(quoteData.Count - 1, 0)).close - quoteData(Math.Max(quoteData.Count - 2, 0)).close

                Return String.Format((If(value >= 0, "+{0:0.00}", "{0:0.00}")), value)
            End If

            Return "0.00"
        End Get
    End Property

#End Region


#Region "ViewModel DataSource"
    Private _chartTypes As Dictionary(Of String, ChartType)
    Public ReadOnly Property ChartTypes() As Dictionary(Of String, ChartType)
        Get
            If _chartTypes Is Nothing Then
                Dim types = New ChartType() {C1.Chart.ChartType.Line, C1.Chart.ChartType.Area, C1.Chart.ChartType.Candlestick, C1.Chart.ChartType.HighLowOpenClose}
                _chartTypes = New Dictionary(Of String, ChartType)()
                For Each t As ChartType In types
                    _chartTypes.Add("Chart Type: " + t.ToString(), t)
                Next
            End If
            Return _chartTypes
        End Get
    End Property

    Private _types As String() = New String() {"JPG", "PNG", "SVG"}
    Private _exportTypes As Dictionary(Of String, String)
    Public ReadOnly Property ExportTypes() As Dictionary(Of String, String)
        Get
            If _exportTypes Is Nothing Then
                _exportTypes = New Dictionary(Of String, String)()
                For Each t As String In _types
                    _exportTypes.Add(t.ToString(), t)

                Next
            End If
            Return _exportTypes
        End Get
    End Property

    Private _movingAverageTypes As Dictionary(Of String, C1.Chart.MovingAverageType)
    Public ReadOnly Property MovingAverageTypes() As Dictionary(Of String, C1.Chart.MovingAverageType)
        Get
            If _movingAverageTypes Is Nothing Then
                _movingAverageTypes = New Dictionary(Of String, C1.Chart.MovingAverageType)()
                For Each t As C1.Chart.MovingAverageType In [Enum].GetValues(GetType(C1.Chart.MovingAverageType))
                    _movingAverageTypes.Add("Type: " + t.ToString(), t)
                Next
            End If
            Return _movingAverageTypes
        End Get
    End Property
#End Region


#Region ""

    Private _indexDataSource As QuoteData
    Public ReadOnly Property IndexDataSource() As QuoteData
        Get
            If _indexDataSource Is Nothing Then
                _indexDataSource = DataService.Instance.GetSymbolData("SP")
            End If
            Return _indexDataSource
        End Get
    End Property


    Private _datasource As QuoteData
    Public Property DataSource() As QuoteData
        Get
            If _datasource Is Nothing Then
                _datasource = DataService.Instance.GetSymbolData(_mainSymbol)
            End If
            Return _datasource
        End Get
        Set
            If Not _datasource.Equals(Value) Then
                _datasource = Value
                OnPropertyChanged("DataSource")
                OnPropertyChanged("SymbolName")
                OnPropertyChanged("Price")
                OnPropertyChanged("Chg")
                UpdateDataRange()
                If IsShowNews Then
                    SetupAnnotation()
                End If
            End If
        End Set
    End Property

    Private _binding As String = "close"
    Public Property Binding() As String
        Get
            Return _binding
        End Get
        Set
            _binding = Value
            If MainSeries IsNot Nothing Then
                SetSeriesAfterBindingChanged(MainSeries)
            End If
            If MainMovingAverage IsNot Nothing Then
                SetSeriesAfterBindingChanged(MainMovingAverage)
            End If
        End Set
    End Property

    Private Async Sub SetSeriesAfterBindingChanged(series As C1.Xaml.Chart.Series)
        Await series.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                                   Sub()
                                       series.Binding = _binding
                                       series.Dispose()

                                   End Sub)
    End Sub

    Public Shared _Colors As Color() = New Color() {Color.FromArgb(255, 16, 150, 24), Color.FromArgb(255, 153, 0, 153), Color.FromArgb(255, 34, 40, 141), Color.FromArgb(255, 0, 153, 198)}

    Private _symbolCollection As ObservableCollection(Of Symbol)

    Public ReadOnly Property SymbolCollection() As ObservableCollection(Of Symbol)
        Get
            If _symbolCollection Is Nothing Then
                _symbolCollection = New ObservableCollection(Of Symbol)()
                AddHandler _symbolCollection.CollectionChanged, AddressOf symbolCollection_CollectionChanged

            End If
            Return _symbolCollection
        End Get
    End Property

    Public Sub symbolCollection_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs)
        If e.Action = System.Collections.Specialized.NotifyCollectionChangedAction.Remove Then
            If MainChart IsNot Nothing Then
                For Each item As Symbol In e.OldItems
                    If MainChart.Series.Contains(item.Series) Then
                        MainChart.Series.Remove(item.Series)
                    End If
                    If MainChart.Series.Contains(item.MovingAverage) Then
                        MainChart.Series.Remove(item.MovingAverage)
                    End If
                Next
            End If
        ElseIf e.Action = System.Collections.Specialized.NotifyCollectionChangedAction.Add Then
            For Each s As Symbol In e.NewItems
                If s IsNot Nothing Then
                    AddHandler s.PropertyChanged, AddressOf symbol_PropertyChanged
                End If

            Next
        End If

        If ResetCommand IsNot Nothing Then
            ResetCommand.RaiseCanExecuteChanged()
        End If

        OnPropertyChanged("SymbolCollection")
        RefrushComparisonMode()
    End Sub

    Private Sub symbol_PropertyChanged(sender As Object, e As PropertyChangedEventArgs)
        If e.PropertyName = "Visibility" Then
            RefrushComparisonMode()
        End If
    End Sub



    Private _comparisonQuoteInfo As IEnumerable(Of QuoteInfo)
    Public Property ComparisonQuoteInfo() As IEnumerable(Of QuoteInfo)
        Get

            Return _comparisonQuoteInfo
        End Get
        Set
            If _comparisonQuoteInfo Is Nothing OrElse
                Not _comparisonQuoteInfo.Equals(Value) Then
                _comparisonQuoteInfo = Value
                OnPropertyChanged("ComparisonQuoteInfo")
            End If
        End Set
    End Property

    Public Property AddingSymbolCode() As String
        Get
            Return m_AddingSymbolCode
        End Get
        Set
            m_AddingSymbolCode = Value
        End Set
    End Property
    Private m_AddingSymbolCode As String

    Private _rangeSelectIndex As Integer = 3
    Public Property RangeSelectIndex() As Integer
        Get
            Return _rangeSelectIndex
        End Get
        Set
            _rangeSelectIndex = Value
            UpdateRangeSelect(_rangeSelectIndex)
        End Set
    End Property

    Private _dateRangeText As String
    Public Property DateRangeText() As String
        Get
            Return _dateRangeText
        End Get
        Set
            If _dateRangeText <> Value Then
                _dateRangeText = Value
                OnPropertyChanged("DateRangeText")
            End If
        End Set
    End Property

    Private _isShowVolume As Boolean = True
    Public Property IsShowVolume() As Boolean
        Get
            Return _isShowVolume
        End Get
        Set
            _isShowVolume = Value
            If VolumeSeries IsNot Nothing Then
                VolumeSeries.Visibility = If(_isShowVolume, SeriesVisibility.Visible, SeriesVisibility.Hidden)
            End If
        End Set
    End Property

    Private _chartType As ChartType
    Public Property ChartType() As ChartType
        Get
            Return _chartType
        End Get
        Set
            _chartType = Value
            OnPropertyChanged("ChartType")

            If MainSeries IsNot Nothing Then
                MainSeries.ChartType = _chartType
                ChangeMode()
            End If
        End Set
    End Property

    Private _isShowMovingAverage As Boolean = False
    Public Property IsShowMovingAverage() As Boolean
        Get
            Return _isShowMovingAverage
        End Get
        Set
            _isShowMovingAverage = Value
            OnPropertyChanged("IsShowMovingAverage")
            ChangeMovingAverageVisibility()
        End Set
    End Property

    Private _movingAverageType As C1.Chart.MovingAverageType = C1.Chart.MovingAverageType.Simple
    Public Property MovingAverageType() As C1.Chart.MovingAverageType
        Get
            Return _movingAverageType
        End Get
        Set
            _movingAverageType = Value
            ChangeMovingAverageType()
        End Set
    End Property

    Private _movingAveragePeriod As Integer = 10
    Public Property MovingAveragePeriod() As Integer
        Get
            Return _movingAveragePeriod
        End Get
        Set
            _movingAveragePeriod = Value
            ChangeMovingAveragePeriod()
        End Set
    End Property

    Private _isShowLineMarker As Boolean = True
    Public Property IsShowLineMarker() As Boolean
        Get
            Return _isShowLineMarker
        End Get
        Set
            _isShowLineMarker = Value
            OnPropertyChanged("IsShowLineMarker")
        End Set
    End Property

    Private _isShowNews As Boolean = False
    Public Property IsShowNews() As Boolean
        Get
            Return (Not IsComparisonMode AndAlso _isShowNews)
        End Get
        Set
            _isShowNews = Value
            ChangeNewsVisibility()
        End Set
    End Property

    Private Sub RefrushComparisonMode()
        IsComparisonMode = Me.SymbolCollection IsNot Nothing AndAlso (From p In Me.SymbolCollection Where p.Visibility = SeriesVisibility.Visible Select p).Any()
    End Sub

    Private _isComparisonMode As Boolean = False
    Public Property IsComparisonMode() As Boolean
        Get
            ' 
            Return _isComparisonMode
        End Get

        Set
            If _isComparisonMode <> Value Then
                _isComparisonMode = Value
                OnPropertyChanged("IsComparisonMode")
                If _isComparisonMode Then
                    ChartType = ChartType.Line
                End If
                ChangeMode()
            Else
                UpdateDataRange()

            End If
        End Set
    End Property

    Private Sub ChangeMode()
        If IsComparisonMode Then
            Me.Binding = "percentage"
            MainChart.AxisY.Format = "P0"
        Else
            If ChartType = ChartType.Candlestick OrElse ChartType = ChartType.HighLowOpenClose Then
                Me.Binding = "high,low,open,close"
            Else
                Me.Binding = "close"
            End If
            MainChart.AxisY.Format = Nothing
        End If
        UpdateDataRange()
    End Sub


#End Region

#Region "Command"

    Private _changeSymbolCommand As ChangeSymbolCommand
    Public ReadOnly Property ChangeSymbolCommand() As ChangeSymbolCommand
        Get
            If _changeSymbolCommand Is Nothing Then
                _changeSymbolCommand = New ChangeSymbolCommand(Me)
            End If
            Return _changeSymbolCommand
        End Get
    End Property
    Private _changeSymbolCommandParamter As String
    Public Property ChangeSymbolCommandParamter() As String
        Get
            Return _changeSymbolCommandParamter
        End Get
        Set
            _changeSymbolCommandParamter = Value
            OnPropertyChanged("ChangeSymbolCommandParamter")
            If ChangeSymbolCommand IsNot Nothing Then
                ChangeSymbolCommand.RaiseCanExecuteChanged()
            End If
        End Set
    End Property



    Private _addCommand As AddCommand
    Public ReadOnly Property AddCommand() As AddCommand
        Get
            If _addCommand Is Nothing Then
                _addCommand = New AddCommand(Me)
            End If
            Return _addCommand
        End Get
    End Property
    Private _addCommandParamter As String
    Public Property AddCommandParamter() As String
        Get
            Return _addCommandParamter
        End Get
        Set
            _addCommandParamter = Value
            OnPropertyChanged("AddCommandParamter")
            If AddCommand IsNot Nothing Then
                AddCommand.RaiseCanExecuteChanged()
            End If
        End Set
    End Property

    Private _resetCommand As ResetCommand
    Public ReadOnly Property ResetCommand() As ResetCommand
        Get
            If _resetCommand Is Nothing Then
                _resetCommand = New ResetCommand(Me)
            End If
            Return _resetCommand
        End Get
    End Property


    Private _exportCommand As ExportCommand
    Public ReadOnly Property ExportCommand() As ExportCommand
        Get
            If _exportCommand Is Nothing Then
                _exportCommand = New ExportCommand(Me)
            End If
            Return _exportCommand
        End Get
    End Property


#End Region

#Region "UI property"

    Public Property MainChart() As C1.Xaml.Chart.Finance.C1FinancialChart
        Get
            Return m_MainChart
        End Get
        Set
            m_MainChart = Value
        End Set
    End Property
    Private m_MainChart As C1.Xaml.Chart.Finance.C1FinancialChart

    Private _mainSeries As C1.Xaml.Chart.Series
    Public Property MainSeries() As C1.Xaml.Chart.Series
        Get
            Return _mainSeries
        End Get
        Set
            _mainSeries = Value
            _mainSeries.Binding = Me.Binding
        End Set
    End Property
    Public _mainMovingAverage As C1.Xaml.Chart.Finance.MovingAverage
    Public Property MainMovingAverage() As C1.Xaml.Chart.Finance.MovingAverage
        Get
            Return _mainMovingAverage
        End Get
        Set
            _mainMovingAverage = Value
            _mainMovingAverage.Binding = Me.Binding
        End Set
    End Property
    Public Property VolumeSeries() As C1.Xaml.Chart.Series
        Get
            Return m_VolumeSeries
        End Get
        Set
            m_VolumeSeries = Value
        End Set
    End Property
    Private m_VolumeSeries As C1.Xaml.Chart.Series

    Public Property RangeSelector() As C1.Xaml.Chart.Interaction.C1RangeSelector
        Get
            Return m_RangeSelector
        End Get
        Set
            m_RangeSelector = Value
        End Set
    End Property
    Private m_RangeSelector As C1.Xaml.Chart.Interaction.C1RangeSelector

    Public Property AnnotationLayer() As C1.Xaml.Chart.Annotation.AnnotationLayer
        Get
            Return m_AnnotationLayer
        End Get
        Set
            m_AnnotationLayer = Value
        End Set
    End Property
    Private m_AnnotationLayer As C1.Xaml.Chart.Annotation.AnnotationLayer

    Private _lineMarker As C1.Xaml.Chart.Interaction.C1LineMarker
    Public Property LineMarker() As C1.Xaml.Chart.Interaction.C1LineMarker
        Get
            Return _lineMarker
        End Get
        Set
            If _lineMarker IsNot Nothing Then
                RemoveHandler _lineMarker.PositionChanged, AddressOf LineMarker_PositionChanged
            End If
            _lineMarker = Value
            AddHandler _lineMarker.PositionChanged, AddressOf LineMarker_PositionChanged
        End Set
    End Property

    Private _lowValue As Double = Utilities.ToOADate(DateTime.Parse(String.Format("01-01-{0}", DateTime.Now.Year)))
    Public Property LowerValue() As Double
        Get
            Return _lowValue
        End Get
        Set
            _lowValue = Value
            RangeSelectorChanged()
        End Set
    End Property

    Private _upperValue As Double = Utilities.ToOADate(DateTime.Now)
    Public Property UpperValue() As Double
        Get
            Return _upperValue
        End Get
        Set
            _upperValue = Value
            RangeSelectorChanged()
        End Set
    End Property


#End Region

#Region "Mothod"


    Private Sub UpdateRangeSelect(index As Integer)
        If RangeSelector IsNot Nothing Then
            Dim lowValue As DateTime = DateTime.Now
            Select Case index
                Case 0
                    lowValue = DateTime.Now.AddMonths(-1)
                    Exit Select
                Case 1
                    lowValue = DateTime.Now.AddMonths(-3)
                    Exit Select
                Case 2
                    lowValue = DateTime.Now.AddMonths(-6)
                    Exit Select
                Case 3
                    lowValue = DateTime.Parse(String.Format("01-01-{0}", DateTime.Now.Year))
                    Exit Select
                Case 4
                    lowValue = DateTime.Now.AddYears(-1)
                    Exit Select
                Case 5
                    lowValue = DateTime.Now.AddYears(-3)
                    Exit Select
                Case 6
                    lowValue = DateTime.Now.AddYears(-6)
                    Exit Select
                Case 7
                    lowValue = ChartViewModel.Instance.DataSource.Min(Function(p) p.[date])
                    Exit Select
                Case Else
                    Exit Select
            End Select
            RangeSelector.LowerValue = Utilities.ToOADate(lowValue)
            RangeSelector.UpperValue = Utilities.ToOADate(DateTime.Now)
        End If
    End Sub

    Friend Function GetYRange(low As Double, high As Double) As IEnumerable(Of QuoteRange)
        Dim ranges As IEnumerable(Of QuoteRange) = (New QuoteRange() {DataService.Instance.GetSymbolYRange(DataSource, low, high, Me.Binding)})

        If SymbolCollection IsNot Nothing AndAlso SymbolCollection.Any() Then
            Dim cssRange = From cs In SymbolCollection Where cs.Visibility = SeriesVisibility.Visible Select DataService.Instance.GetSymbolYRange(cs.DataSource, low, high, Me.Binding)
            ranges = ranges.Union(cssRange)
        End If
        Return ranges
    End Function



    Friend Sub RangeSelectorChanged()
        If MainChart IsNot Nothing Then
            MainChart.BeginUpdate()
            UpdateDataRange()

            Dim ranges As IEnumerable(Of QuoteRange) = ChartViewModel.Instance.GetYRange(Me.LowerValue, Me.UpperValue)
            If ranges IsNot Nothing AndAlso ranges.Any() Then
                If MainChart IsNot Nothing Then
                    MainChart.AxisY.Min = ranges.Min(Function(p)
                                                         Return If(p Is Nothing, Integer.MaxValue, p.PriceMin)

                                                     End Function)
                    MainChart.AxisY.Max = ranges.Max(Function(p)
                                                         Return If(p Is Nothing, Integer.MinValue, p.PriceMax)

                                                     End Function)
                End If
                Dim quote = ranges.First()
                If quote IsNot Nothing AndAlso VolumeSeries IsNot Nothing Then
                    VolumeSeries.AxisY.Min = quote.VolumeMin
                    VolumeSeries.AxisY.Max = quote.VolumeMax * 12
                End If
            End If
            MainChart.EndUpdate()

            If Me.RangeSelector IsNot Nothing Then
                DateRangeText = Utilities.FromOADate(RangeSelector.LowerValue).ToString("MMM dd, yyyy") + " - " + Utilities.FromOADate(RangeSelector.UpperValue).ToString("MMM dd, yyyy")
            End If
        End If
    End Sub


    Friend Sub UpdateDataRange()
        If MainChart IsNot Nothing Then
            Dim ds As DateTime = Utilities.FromOADate(Me.LowerValue)
            Dim quote As Quote = ChartViewModel.Instance.DataSource.First(Function(p) p.[date] >= ds)
            ChartViewModel.Instance.DataSource.ReferenceValue.Value = quote.close

            Dim type = Me.MovingAverageType
            Dim nonType = MovingAverageType.Simple
            For Each t As MovingAverageType In [Enum].GetValues(GetType(MovingAverageType))
                If t <> type Then
                    nonType = t
                    Exit For
                End If
            Next


            If ChartViewModel.Instance.SymbolCollection IsNot Nothing AndAlso ChartViewModel.Instance.SymbolCollection.Any() Then
                For Each symbol As Symbol In ChartViewModel.Instance.SymbolCollection
                    quote = symbol.DataSource.FirstOrDefault(Function(p) p.[date] >= ds)
                    If quote IsNot Nothing Then
                        symbol.DataSource.ReferenceValue.Value = quote.close
                        If symbol.Series IsNot Nothing Then
                            symbol.Series.Dispose()
                        End If
                        If symbol.MovingAverage IsNot Nothing Then
                            symbol.MovingAverage.Dispose()
                            symbol.MovingAverage.Type = nonType
                            symbol.MovingAverage.Type = type
                        End If
                    End If
                Next
            End If
            If MainSeries IsNot Nothing Then
                MainSeries.Dispose()
            End If
            If MainMovingAverage IsNot Nothing Then
                MainMovingAverage.Dispose()
                MainMovingAverage.Type = nonType
                MainMovingAverage.Type = type
            End If
            UpdateYRange()
        End If
    End Sub

    Friend Sub UpdateYRange()
        If MainChart IsNot Nothing Then
            Dim ranges As IEnumerable(Of QuoteRange) = (New QuoteRange() {DataService.Instance.GetSymbolYRange(DataSource, LowerValue, UpperValue, Binding)})

            If SymbolCollection IsNot Nothing Then
                Dim cssRange = From cs In SymbolCollection Where cs.Visibility = SeriesVisibility.Visible Select DataService.Instance.GetSymbolYRange(cs.DataSource, LowerValue, UpperValue, Binding)
                ranges = ranges.Union(cssRange)
            End If
            If ranges.Any() Then
                MainChart.AxisX.Min = LowerValue
                MainChart.AxisX.Max = UpperValue
                MainChart.AxisY.Min = ranges.Min(Function(p)
                                                     Return If(p Is Nothing, Integer.MaxValue, p.PriceMin)

                                                 End Function)
                MainChart.AxisY.Max = ranges.Max(Function(p)
                                                     Return If(p Is Nothing, Integer.MinValue, p.PriceMax)

                                                 End Function)
                If VolumeSeries IsNot Nothing AndAlso ranges.FirstOrDefault() IsNot Nothing Then
                    VolumeSeries.AxisY.Min = ranges.First().VolumeMin
                    VolumeSeries.AxisY.Max = ranges.First().VolumeMax * 12
                End If
            End If
        End If
    End Sub

    Private Sub ChangeMovingAverageVisibility()
        If MainMovingAverage IsNot Nothing Then
            MainMovingAverage.Visibility = If(Me.IsShowMovingAverage, SeriesVisibility.Visible, SeriesVisibility.Hidden)
        End If

        For Each symbol As Symbol In SymbolCollection
            If symbol IsNot Nothing AndAlso symbol.Visibility = SeriesVisibility.Visible AndAlso symbol.MovingAverage IsNot Nothing Then
                symbol.MovingAverage.Visibility = If(Me.IsShowMovingAverage, SeriesVisibility.Visible, SeriesVisibility.Hidden)
            End If
        Next
    End Sub

    Private Sub ChangeMovingAverageType()
        If MainMovingAverage IsNot Nothing Then
            MainMovingAverage.Type = Me.MovingAverageType
        End If

        For Each symbol As Symbol In SymbolCollection
            If symbol IsNot Nothing AndAlso symbol.MovingAverage IsNot Nothing Then
                symbol.MovingAverage.Type = Me.MovingAverageType
            End If
        Next
    End Sub

    Private Sub ChangeMovingAveragePeriod()
        Dim period As Integer = Math.Max(Me.MovingAveragePeriod, 2)
        If MainMovingAverage IsNot Nothing Then
            MainMovingAverage.Period = period
        End If

        For Each symbol As Symbol In SymbolCollection
            If symbol IsNot Nothing AndAlso symbol.MovingAverage IsNot Nothing Then
                symbol.MovingAverage.Period = period
            End If
        Next
    End Sub

    Private Sub ChangeLineMarkerVisibility()
        If LineMarker IsNot Nothing Then
            LineMarker.Visibility = If(IsShowLineMarker, Visibility.Visible, Visibility.Collapsed)
        End If

    End Sub

    Private Sub ChangeNewsVisibility()
        If AnnotationLayer IsNot Nothing Then
            AnnotationLayer.Annotations.Clear()

            If IsShowNews Then
                SetupAnnotation()
            End If
        End If

    End Sub

    Private Sub LineMarker_PositionChanged(sender As Object, e As PositionChangedArgs)
        Dim chartPoint = New Point(LineMarker.X, LineMarker.Y)
        Dim _hitTestInfo = MainChart.HitTest(chartPoint)

        Dim hitTestInfo = MainChart.HitTest(chartPoint)


    End Sub

    Friend Sub SetupAnnotation()
        If AnnotationLayer IsNot Nothing AndAlso DataSource IsNot Nothing AndAlso DataSource.Any() Then

            Dim cache = New Queue(Of C1.Xaml.Chart.Annotation.Square)()


            For Each d As Quote In DataSource
                If Not String.IsNullOrEmpty(d.events) Then
                    Dim dSquare = New C1.Xaml.Chart.Annotation.Square("N", 20) With {
                        .SeriesIndex = 0,
                        .Location = New Point(CInt(Utilities.ToOADate(d.[date])), CInt(d.GetValue("close"))),
                        .Attachment = C1.Chart.Annotation.AnnotationAttachment.DataCoordinate,
                        .TooltipText = d.events
                    }
                    dSquare.ContentStyle = New C1.Xaml.Chart.ChartStyle()
                    dSquare.ContentStyle.Stroke = New SolidColorBrush(Colors.Black)
                    dSquare.Style.Fill = New SolidColorBrush(Color.FromArgb(255, 136, 136, 136))
                    dSquare.Style.Stroke = New SolidColorBrush(Colors.Black)
                    dSquare.Style.StrokeThickness = 1
                    AnnotationLayer.Annotations.Add(dSquare)

                    cache.Enqueue(dSquare)
                End If
            Next
        End If
    End Sub


#End Region

End Class