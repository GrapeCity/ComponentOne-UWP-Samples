Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("FlexRadarIntroLib/Resources")

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

    Public Shared ReadOnly Property AppName() As String
        Get
            Return _loader.GetString("AppName")
        End Get
    End Property

    Public Shared ReadOnly Property ChartType() As String
        Get
            Return _loader.GetString("ChartType")
        End Get
    End Property

    Public Shared ReadOnly Property Stacking() As String
        Get
            Return _loader.GetString("Stacking")
        End Get
    End Property

    Public Shared ReadOnly Property Palette() As String
        Get
            Return _loader.GetString("Palette")
        End Get
    End Property

    Public Shared ReadOnly Property StartAngle() As String
        Get
            Return _loader.GetString("StartAngle")
        End Get
    End Property

    Public Shared ReadOnly Property Reversed() As String
        Get
            Return _loader.GetString("Reversed")
        End Get
    End Property

    Public Shared ReadOnly Property StartAngleCaption() As String
        Get
            Return _loader.GetString("StartAngleCaption")
        End Get
    End Property

    Public Shared ReadOnly Property UpDownCaption() As String
        Get
            Return _loader.GetString("UpDownCaption")
        End Get
    End Property

    Public Shared ReadOnly Property [Function]() As String
        Get
            Return _loader.GetString("Function")
        End Get
    End Property

#Region "Samples"

    Public Shared ReadOnly Property PolarChartTitle() As String
        Get
            Return _loader.GetString("PolarChartTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PolarChartName() As String
        Get
            Return _loader.GetString("PolarChartName")
        End Get
    End Property

    Public Shared ReadOnly Property PolarChartDescription() As String
        Get
            Return _loader.GetString("PolarChartDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RadarChartName() As String
        Get
            Return _loader.GetString("RadarChartName")
        End Get
    End Property

    Public Shared ReadOnly Property RadarChartTitle() As String
        Get
            Return _loader.GetString("RadarChartTitle")
        End Get
    End Property

    Public Shared ReadOnly Property RadarChartDescription() As String
        Get
            Return _loader.GetString("RadarChartDescription")
        End Get
    End Property

#End Region
End Class