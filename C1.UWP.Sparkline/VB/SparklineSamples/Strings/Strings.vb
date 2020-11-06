Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("SparklineSamplesLib/Resources")

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
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

    Public Shared ReadOnly Property SparklineSamplesOverviewTitle() As String
        Get
            Return _loader.GetString("SparklineSamplesOverviewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineSamplesOverviewDescription() As String
        Get
            Return _loader.GetString("SparklineSamplesOverviewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineSamplesOverviewName() As String
        Get
            Return _loader.GetString("SparklineSamplesOverviewName")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineSamplesAppearanceTitle() As String
        Get
            Return _loader.GetString("SparklineSamplesAppearanceTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineSamplesAppearanceDescription() As String
        Get
            Return _loader.GetString("SparklineSamplesAppearanceDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineSamplesAppearanceName() As String
        Get
            Return _loader.GetString("SparklineSamplesAppearanceName")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineSamplesListBoxTitle() As String
        Get
            Return _loader.GetString("SparklineSamplesListBoxTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineSamplesListBoxDescription() As String
        Get
            Return _loader.GetString("SparklineSamplesListBoxDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineSamplesListBoxName() As String
        Get
            Return _loader.GetString("SparklineSamplesListBoxName")
        End Get
    End Property

    Public Shared ReadOnly Property StatesColumnValue() As String
        Get
            Return _loader.GetString("StatesColumnValue")
        End Get
    End Property

    Public Shared ReadOnly Property SkyBlueColor() As String
        Get
            Return _loader.GetString("SkyBlueColor")
        End Get
    End Property

    Public Shared ReadOnly Property GoldColor() As String
        Get
            Return _loader.GetString("GoldColor")
        End Get
    End Property

    Public Shared ReadOnly Property SandyBrownColor() As String
        Get
            Return _loader.GetString("SandyBrownColor")
        End Get
    End Property

    Public Shared ReadOnly Property LightPinkColor() As String
        Get
            Return _loader.GetString("LightPinkColor")
        End Get
    End Property

    Public Shared ReadOnly Property GrayColor() As String
        Get
            Return _loader.GetString("GrayColor")
        End Get
    End Property

    Public Shared ReadOnly Property MediumOrchidColor() As String
        Get
            Return _loader.GetString("MediumOrchidColor")
        End Get
    End Property

    Public Shared ReadOnly Property LightCoralColor() As String
        Get
            Return _loader.GetString("LightCoralColor")
        End Get
    End Property

    Public Shared ReadOnly Property LightGreenColor() As String
        Get
            Return _loader.GetString("LightGreenColor")
        End Get
    End Property

    Public Shared ReadOnly Property DarkKhakiColor() As String
        Get
            Return _loader.GetString("DarkKhakiColor")
        End Get
    End Property

    Public Shared ReadOnly Property SparklineTypeTB_Text() As String
        Get
            Return _loader.GetString("SparklineTypeTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property DisplayDateAxisTB_Text() As String
        Get
            Return _loader.GetString("DisplayDateAxisTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property NewDataBT_Content() As String
        Get
            Return _loader.GetString("NewDataBT_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ShowMarksTB_Text() As String
        Get
            Return _loader.GetString("ShowMarksTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property DisplayXAxisTB_Text() As String
        Get
            Return _loader.GetString("DisplayXAxisTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ShowFirstTB_Text() As String
        Get
            Return _loader.GetString("ShowFirstTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ShowLastTB_Text() As String
        Get
            Return _loader.GetString("ShowLastTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ShowHighTB_Text() As String
        Get
            Return _loader.GetString("ShowHighTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ShowLowTB_Text() As String
        Get
            Return _loader.GetString("ShowLowTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ShowNegativeTB_Text() As String
        Get
            Return _loader.GetString("ShowNegativeTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SeriesColorTB_Text() As String
        Get
            Return _loader.GetString("SeriesColorTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property AxisColorTB_Text() As String
        Get
            Return _loader.GetString("AxisColorTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property MarksColorTB_Text() As String
        Get
            Return _loader.GetString("MarksColorTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FirstMarkColorTB_Text() As String
        Get
            Return _loader.GetString("FirstMarkColorTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LastMarkColorTB_Text() As String
        Get
            Return _loader.GetString("LastMarkColorTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property HighMarkColorTB_Text() As String
        Get
            Return _loader.GetString("HighMarkColorTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LowMarkColorTB_Text() As String
        Get
            Return _loader.GetString("LowMarkColorTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property NegativeColorTB_Text() As String
        Get
            Return _loader.GetString("NegativeColorTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property MarksCB_Content() As String
        Get
            Return _loader.GetString("MarksCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property XAxisCB_Content() As String
        Get
            Return _loader.GetString("XAxisCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property FirstCB_Content() As String
        Get
            Return _loader.GetString("FirstCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property LastCB_Content() As String
        Get
            Return _loader.GetString("LastCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property HighCB_Content() As String
        Get
            Return _loader.GetString("HighCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property LowCB_Content() As String
        Get
            Return _loader.GetString("LowCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property NegativeCB_Content() As String
        Get
            Return _loader.GetString("NegativeCB_Content")
        End Get
    End Property

    Public Shared ReadOnly Property RegionTB_Text() As String
        Get
            Return _loader.GetString("RegionTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property TotalSaleTB_Text() As String
        Get
            Return _loader.GetString("TotalSaleTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SalesTrendTB_Text() As String
        Get
            Return _loader.GetString("SalesTrendTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property WinLossTB_Text() As String
        Get
            Return _loader.GetString("WinLossTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ProfitTrendTB_Text() As String
        Get
            Return _loader.GetString("ProfitTrendTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LineType() As String
        Get
            Return _loader.GetString("LineType")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnType() As String
        Get
            Return _loader.GetString("ColumnType")
        End Get
    End Property

    Public Shared ReadOnly Property WinlossType() As String
        Get
            Return _loader.GetString("WinlossType")
        End Get
    End Property
End Class
