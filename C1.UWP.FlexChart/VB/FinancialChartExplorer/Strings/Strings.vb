Imports Windows.ApplicationModel.Resources

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("FinancialChartExplorerLib/Resources")

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Symbol() As String
        Get
            Return _loader.GetString("Symbol")
        End Get
    End Property

    Public Shared ReadOnly Property LineBreakCaption() As String
        Get
            Return _loader.GetString("LineBreakCaption")
        End Get
    End Property

    Public Shared ReadOnly Property BoxSizeCaption() As String
        Get
            Return _loader.GetString("BoxSizeCaption")
        End Get
    End Property

    Public Shared ReadOnly Property RangeModeCaptioin() As String
        Get
            Return _loader.GetString("RangeModeCaptioin")
        End Get
    End Property

    Public Shared ReadOnly Property DataFieldsCaption() As String
        Get
            Return _loader.GetString("DataFieldsCaption")
        End Get
    End Property

    Public Shared ReadOnly Property ReversalAmountCaption() As String
        Get
            Return _loader.GetString("ReversalAmountCaption")
        End Get
    End Property

    Public Shared ReadOnly Property FitTypeCaption() As String
        Get
            Return _loader.GetString("FitTypeCaption")
        End Get
    End Property

    Public Shared ReadOnly Property OrderCaption() As String
        Get
            Return _loader.GetString("OrderCaption")
        End Get
    End Property

    Public Shared ReadOnly Property PeriodCaption() As String
        Get
            Return _loader.GetString("PeriodCaption")
        End Get
    End Property

    Public Shared ReadOnly Property MovingAverageTypeCaption() As String
        Get
            Return _loader.GetString("MovingAverageTypeCaption")
        End Get
    End Property

    Public Shared ReadOnly Property IndicatorsTypeCaption() As String
        Get
            Return _loader.GetString("IndicatorsTypeCaption")
        End Get
    End Property

    Public Shared ReadOnly Property DPeriodCaption() As String
        Get
            Return _loader.GetString("DPeriodCaption")
        End Get
    End Property

    Public Shared ReadOnly Property KPeriodCaption() As String
        Get
            Return _loader.GetString("KPeriodCaption")
        End Get
    End Property

    Public Shared ReadOnly Property SlowPeriodCaption() As String
        Get
            Return _loader.GetString("SlowPeriodCaption")
        End Get
    End Property

    Public Shared ReadOnly Property SmoothingPeriodCaption() As String
        Get
            Return _loader.GetString("SmoothingPeriodCaption")
        End Get
    End Property

    Public Shared ReadOnly Property FastPeriodCaption() As String
        Get
            Return _loader.GetString("FastPeriodCaption")
        End Get
    End Property

    Public Shared ReadOnly Property IndicatorsSettings() As String
        Get
            Return _loader.GetString("IndicatorsSettings")
        End Get
    End Property

    Public Shared ReadOnly Property IndicatorType() As String
        Get
            Return _loader.GetString("IndicatorType")
        End Get
    End Property

    Public Shared ReadOnly Property OverlaysSettings() As String
        Get
            Return _loader.GetString("OverlaysSettings")
        End Get
    End Property

    Public Shared ReadOnly Property OverlayCaption() As String
        Get
            Return _loader.GetString("OverlayCaption")
        End Get
    End Property

    Public Shared ReadOnly Property TypeCaption() As String
        Get
            Return _loader.GetString("TypeCaption")
        End Get
    End Property

    Public Shared ReadOnly Property SizeCaption() As String
        Get
            Return _loader.GetString("SizeCaption")
        End Get
    End Property

    Public Shared ReadOnly Property MultiplierCaptin() As String
        Get
            Return _loader.GetString("MultiplierCaptin")
        End Get
    End Property

    Public Shared ReadOnly Property FibonacciTypeCaption() As String
        Get
            Return _loader.GetString("FibonacciTypeCaption")
        End Get
    End Property

    Public Shared ReadOnly Property UptrendCaption() As String
        Get
            Return _loader.GetString("UptrendCaption")
        End Get
    End Property

    Public Shared ReadOnly Property PositionCaption() As String
        Get
            Return _loader.GetString("PositionCaption")
        End Get
    End Property

    Public Shared ReadOnly Property RangeSelectorCaption() As String
        Get
            Return _loader.GetString("RangeSelectorCaption")
        End Get
    End Property

    Public Shared ReadOnly Property StartXCaption() As String
        Get
            Return _loader.GetString("StartXCaption")
        End Get
    End Property

    Public Shared ReadOnly Property StartYCaption() As String
        Get
            Return _loader.GetString("StartYCaption")
        End Get
    End Property

    Public Shared ReadOnly Property EndXCaption As String
        Get
            Return _loader.GetString("EndXCaption")
        End Get
    End Property

    Public Shared ReadOnly Property EndYCaption() As String
        Get
            Return _loader.GetString("EndYCaption")
        End Get
    End Property

    Public Shared ReadOnly Property TimeZonesPositions() As String
        Get
            Return _loader.GetString("TimeZonesPositions")
        End Get
    End Property

    Public Shared ReadOnly Property VerticalPositions() As String
        Get
            Return _loader.GetString("VerticalPositions")
        End Get
    End Property

    Public Shared ReadOnly Property Positions() As String
        Get
            Return _loader.GetString("Positions")
        End Get
    End Property

    Public Shared ReadOnly Property FibonacciTypes() As String
        Get
            Return _loader.GetString("FibonacciTypes")
        End Get
    End Property

    Public Shared ReadOnly Property FibonacciSettings() As String
        Get
            Return _loader.GetString("FibonacciSettings")
        End Get
    End Property

    Public Shared ReadOnly Property OverlaysTypes() As String
        Get
            Return _loader.GetString("OverlaysTypes")
        End Get
    End Property

    Public Shared ReadOnly Property AlignmentCaption() As String
        Get
            Return _loader.GetString("AlignmentCaption")
        End Get
    End Property

    Public Shared ReadOnly Property InteractionCaption() As String
        Get
            Return _loader.GetString("InteractionCaption")
        End Get
    End Property

    Public Shared ReadOnly Property MarkerLinesCaption() As String
        Get
            Return _loader.GetString("MarkerLinesCaption")
        End Get
    End Property

    Public Shared ReadOnly Property SnappingCaptioin() As String
        Get
            Return _loader.GetString("SnappingCaptioin")
        End Get
    End Property

#Region "Samples info"

    Public Shared ReadOnly Property HeikinAshiName() As String
        Get
            Return _loader.GetString("HeikinAshiName")
        End Get
    End Property

    Public Shared ReadOnly Property HeikinAshiTitle() As String
        Get
            Return _loader.GetString("HeikinAshiTitle")
        End Get
    End Property

    Public Shared ReadOnly Property HeikinAshiDescription() As String
        Get
            Return _loader.GetString("HeikinAshiDescription")
        End Get
    End Property

    Public Shared ReadOnly Property LineBreakName() As String
        Get
            Return _loader.GetString("LineBreakName")
        End Get
    End Property

    Public Shared ReadOnly Property LineBreakTitle() As String
        Get
            Return _loader.GetString("LineBreakTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LineBreakDescription() As String
        Get
            Return _loader.GetString("LineBreakDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RenkoName() As String
        Get
            Return _loader.GetString("RenkoName")
        End Get
    End Property

    Public Shared ReadOnly Property RenkoTitle() As String
        Get
            Return _loader.GetString("RenkoTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RenkoDescription() As String
        Get
            Return _loader.GetString("RenkoDescription")
        End Get
    End Property

    Public Shared ReadOnly Property KagiName() As String
        Get
            Return _loader.GetString("KagiName")
        End Get
    End Property

    Public Shared ReadOnly Property KagiTitle() As String
        Get
            Return _loader.GetString("KagiTitle")
        End Get
    End Property

    Public Shared ReadOnly Property KagiDescription() As String
        Get
            Return _loader.GetString("KagiDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnVolumeName() As String
        Get
            Return _loader.GetString("ColumnVolumeName")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnVolumeTitle() As String
        Get
            Return _loader.GetString("ColumnVolumeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnVolumeDescription() As String
        Get
            Return _loader.GetString("ColumnVolumeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property EquiVolumeName() As String
        Get
            Return _loader.GetString("EquiVolumeName")
        End Get
    End Property

    Public Shared ReadOnly Property EquiVolumeTitle() As String
        Get
            Return _loader.GetString("EquiVolumeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property EquiVolumeDescription() As String
        Get
            Return _loader.GetString("EquiVolumeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CandleVolumeName() As String
        Get
            Return _loader.GetString("CandleVolumeName")
        End Get
    End Property

    Public Shared ReadOnly Property CandleVolumeTitle() As String
        Get
            Return _loader.GetString("CandleVolumeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CandleVolumeDescription() As String
        Get
            Return _loader.GetString("CandleVolumeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ArmsCandleVolumeName() As String
        Get
            Return _loader.GetString("ArmsCandleVolumeName")
        End Get
    End Property

    Public Shared ReadOnly Property ArmsCandleVolumeTitle() As String
        Get
            Return _loader.GetString("ArmsCandleVolumeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ArmsCandleVolumeDescription() As String
        Get
            Return _loader.GetString("ArmsCandleVolumeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RangeSelectorName() As String
        Get
            Return _loader.GetString("RangeSelectorName")
        End Get
    End Property

    Public Shared ReadOnly Property RangeSelectorTitle() As String
        Get
            Return _loader.GetString("RangeSelectorTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RangeSelectorDescription() As String
        Get
            Return _loader.GetString("RangeSelectorDescription")
        End Get
    End Property

    Public Shared ReadOnly Property TrendLinesName() As String
        Get
            Return _loader.GetString("TrendLinesName")
        End Get
    End Property

    Public Shared ReadOnly Property TrendLinesTitle() As String
        Get
            Return _loader.GetString("TrendLinesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property TrendLinesDescription() As String
        Get
            Return _loader.GetString("TrendLinesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MovingAveragesName() As String
        Get
            Return _loader.GetString("MovingAveragesName")
        End Get
    End Property

    Public Shared ReadOnly Property MovingAveragesTitle() As String
        Get
            Return _loader.GetString("MovingAveragesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MovingAveragesDescription() As String
        Get
            Return _loader.GetString("MovingAveragesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property IndicatorsName() As String
        Get
            Return _loader.GetString("IndicatorsName")
        End Get
    End Property

    Public Shared ReadOnly Property IndicatorsTitle() As String
        Get
            Return _loader.GetString("IndicatorsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property IndicatorsDescription() As String
        Get
            Return _loader.GetString("IndicatorsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property FibonacciToolName() As String
        Get
            Return _loader.GetString("FibonacciToolName")
        End Get
    End Property

    Public Shared ReadOnly Property FibonacciToolTitle() As String
        Get
            Return _loader.GetString("FibonacciToolTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FibonacciToolDescription() As String
        Get
            Return _loader.GetString("FibonacciToolDescription")
        End Get
    End Property

    Public Shared ReadOnly Property OverlaysDescription() As String
        Get
            Return _loader.GetString("OverlaysDescription")
        End Get
    End Property

    Public Shared ReadOnly Property OverlaysName() As String
        Get
            Return _loader.GetString("OverlaysName")
        End Get
    End Property

    Public Shared ReadOnly Property OverlaysTitle() As String
        Get
            Return _loader.GetString("OverlaysTitle")
        End Get
    End Property

    Public Shared ReadOnly Property EventAnnotationsName() As String
        Get
            Return _loader.GetString("EventAnnotationsName")
        End Get
    End Property

    Public Shared ReadOnly Property EventAnnotationsTitle() As String
        Get
            Return _loader.GetString("EventAnnotationsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property EventAnnotationsDescription() As String
        Get
            Return _loader.GetString("EventAnnotationsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MarkersName() As String
        Get
            Return _loader.GetString("MarkersName")
        End Get
    End Property

    Public Shared ReadOnly Property MarkersTitle() As String
        Get
            Return _loader.GetString("MarkersTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MarkersDescription() As String
        Get
            Return _loader.GetString("MarkersDescription")
        End Get
    End Property

#End Region

#Region "ChartType"

    Public Shared ReadOnly Property Bar() As String
        Get
            Return _loader.GetString("Bar")
        End Get
    End Property

    Public Shared ReadOnly Property Column() As String
        Get
            Return _loader.GetString("Column")
        End Get
    End Property

    Public Shared ReadOnly Property Line() As String
        Get
            Return _loader.GetString("Line")
        End Get
    End Property

    Public Shared ReadOnly Property Scatter() As String
        Get
            Return _loader.GetString("Scatter")
        End Get
    End Property

    Public Shared ReadOnly Property LineSymbols() As String
        Get
            Return _loader.GetString("LineSymbols")
        End Get
    End Property

    Public Shared ReadOnly Property Area() As String
        Get
            Return _loader.GetString("Area")
        End Get
    End Property

    Public Shared ReadOnly Property Spline() As String
        Get
            Return _loader.GetString("Spline")
        End Get
    End Property

    Public Shared ReadOnly Property SplineSymbols() As String
        Get
            Return _loader.GetString("SplineSymbols")
        End Get
    End Property

    Public Shared ReadOnly Property SplineArea() As String
        Get
            Return _loader.GetString("SplineArea")
        End Get
    End Property

    Public Shared ReadOnly Property Candlestick() As String
        Get
            Return _loader.GetString("Candlestick")
        End Get
    End Property

    Public Shared ReadOnly Property HighLowOpenClose() As String
        Get
            Return _loader.GetString("HighLowOpenClose")
        End Get
    End Property

#End Region
End Class