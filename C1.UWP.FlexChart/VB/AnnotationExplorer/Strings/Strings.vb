Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("AnnotationExplorerLib/Resources")

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

    Public Shared ReadOnly Property RectangleTooltip() As String
        Get
            Return _loader.GetString("RectangleTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property EllipseTooltip() As String
        Get
            Return _loader.GetString("EllipseTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property CircleTooltip() As String
        Get
            Return _loader.GetString("CircleTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property TextTooltip() As String
        Get
            Return _loader.GetString("TextTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property SquareTooltip() As String
        Get
            Return _loader.GetString("SquareTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property PolygonTooltip() As String
        Get
            Return _loader.GetString("PolygonTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property LineTooltip() As String
        Get
            Return _loader.GetString("LineTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property ImageTooltip() As String
        Get
            Return _loader.GetString("ImageTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneRectangleTooltip() As String
        Get
            Return _loader.GetString("PhoneRectangleTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneTextTooltip() As String
        Get
            Return _loader.GetString("TextTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneSquareTooltip() As String
        Get
            Return _loader.GetString("SquareTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property PhonePolygonTooltip() As String
        Get
            Return _loader.GetString("PolygonTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property PhoneImageTooltip() As String
        Get
            Return _loader.GetString("ImageTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property DContent() As String
        Get
            Return _loader.GetString("DContent")
        End Get
    End Property

    Public Shared ReadOnly Property EContent() As String
        Get
            Return _loader.GetString("EContent")
        End Get
    End Property

    Public Shared ReadOnly Property RWContent() As String
        Get
            Return _loader.GetString("RWContent")
        End Get
    End Property

    Public Shared ReadOnly Property FacebookContent() As String
        Get
            Return _loader.GetString("FacebookContent")
        End Get
    End Property

    Public Shared ReadOnly Property AlibabaContent() As String
        Get
            Return _loader.GetString("AlibabaContent")
        End Get
    End Property

    Public Shared ReadOnly Property CloseTooltip() As String
        Get
            Return _loader.GetString("CloseTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property InfoTooltip() As String
        Get
            Return _loader.GetString("InfoTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property ArrowTooltip() As String
        Get
            Return _loader.GetString("ArrowTooltip")
        End Get
    End Property

    Public Shared ReadOnly Property DividendTooltip() As String
        Get
            Return _loader.GetString("DividendTooltip")
        End Get
    End Property

#Region "Samples"

    Public Shared ReadOnly Property BasicName() As String
        Get
            Return _loader.GetString("BasicName")
        End Get
    End Property

    Public Shared ReadOnly Property BasicTitle() As String
        Get
            Return _loader.GetString("BasicTitle")
        End Get
    End Property

    Public Shared ReadOnly Property BasicDescription() As String
        Get
            Return _loader.GetString("BasicDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AdvancedName() As String
        Get
            Return _loader.GetString("AdvancedName")
        End Get
    End Property

    Public Shared ReadOnly Property AdvancedTitle() As String
        Get
            Return _loader.GetString("AdvancedTitle")
        End Get
    End Property

    Public Shared ReadOnly Property AdvancedDescription() As String
        Get
            Return _loader.GetString("AdvancedDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CalloutsName() As String
        Get
            Return _loader.GetString("CalloutsName")
        End Get
    End Property

    Public Shared ReadOnly Property CalloutsTitle() As String
        Get
            Return _loader.GetString("CalloutsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CalloutsDescription() As String
        Get
            Return _loader.GetString("CalloutsDescription")
        End Get
    End Property

#End Region
End Class