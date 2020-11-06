Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("FlexChartCustomizationLib/Resources")

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

#Region "Samples"

    Public Shared ReadOnly Property LineStylesName() As String
        Get
            Return _loader.GetString("LineStylesName")
        End Get
    End Property

    Public Shared ReadOnly Property LineStylesTitle() As String
        Get
            Return _loader.GetString("LineStylesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LineStylesDescription() As String
        Get
            Return _loader.GetString("LineStylesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property LegendItemsDescription() As String
        Get
            Return _loader.GetString("LegendItemsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property LegendItemsName() As String
        Get
            Return _loader.GetString("LegendItemsName")
        End Get
    End Property

    Public Shared ReadOnly Property LegendItemsTitle() As String
        Get
            Return _loader.GetString("LegendItemsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LegendRangesName() As String
        Get
            Return _loader.GetString("LegendRangesName")
        End Get
    End Property

    Public Shared ReadOnly Property LegendRangesTitle() As String
        Get
            Return _loader.GetString("LegendRangesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property LegendRangesDescription() As String
        Get
            Return _loader.GetString("LegendRangesDescription")
        End Get
    End Property

#End Region
End Class