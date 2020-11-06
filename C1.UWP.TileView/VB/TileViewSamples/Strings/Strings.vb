Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("TileViewSamplesLib/Resources")

    Public Shared ReadOnly Property AmazonBooksDescription() As String
        Get
            Return _loader.GetString("AmazonBooksDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AmazonBooksName() As String
        Get
            Return _loader.GetString("AmazonBooksName")
        End Get
    End Property

    Public Shared ReadOnly Property AmazonBooksTitle() As String
        Get
            Return _loader.GetString("AmazonBooksTitle")
        End Get
    End Property

    Public Shared ReadOnly Property AnnCity_Text() As String
        Get
            Return _loader.GetString("AnnCity_Text")
        End Get
    End Property

    Public Shared ReadOnly Property AnnEmail_Text() As String
        Get
            Return _loader.GetString("AnnEmail_Text")
        End Get
    End Property

    Public Shared ReadOnly Property AnnName_Text() As String
        Get
            Return _loader.GetString("AnnName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property AnnTel_Text() As String
        Get
            Return _loader.GetString("AnnTel_Text")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Author_Text() As String
        Get
            Return _loader.GetString("Author_Text")
        End Get
    End Property

    Public Shared ReadOnly Property CustomLookDescription() As String
        Get
            Return _loader.GetString("CustomLookDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CustomLookName() As String
        Get
            Return _loader.GetString("CustomLookName")
        End Get
    End Property

    Public Shared ReadOnly Property CustomLookTitle() As String
        Get
            Return _loader.GetString("CustomLookTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DashBoardDescription() As String
        Get
            Return _loader.GetString("DashBoardDescription")
        End Get
    End Property

    Public Shared ReadOnly Property DashBoardName() As String
        Get
            Return _loader.GetString("DashBoardName")
        End Get
    End Property

    Public Shared ReadOnly Property DashBoardTitle() As String
        Get
            Return _loader.GetString("DashBoardTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FredCity_Text() As String
        Get
            Return _loader.GetString("FredCity_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FredEmail_Text() As String
        Get
            Return _loader.GetString("FredEmail_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FredName_Text() As String
        Get
            Return _loader.GetString("FredName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FredTel_Text() As String
        Get
            Return _loader.GetString("FredTel_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Header_Text() As String
        Get
            Return _loader.GetString("Header_Text")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property ISBN_Text() As String
        Get
            Return _loader.GetString("ISBN_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Price_Text() As String
        Get
            Return _loader.GetString("Price_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ReportSummary_Text() As String
        Get
            Return _loader.GetString("ReportSummary_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RusselCity_Text() As String
        Get
            Return _loader.GetString("RusselCity_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RusselEmail_Text() As String
        Get
            Return _loader.GetString("RusselEmail_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RusselName_Text() As String
        Get
            Return _loader.GetString("RusselName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RusselTel_Text() As String
        Get
            Return _loader.GetString("RusselTel_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SalesAgents_Text() As String
        Get
            Return _loader.GetString("SalesAgents_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SalesPerAgent_Text() As String
        Get
            Return _loader.GetString("SalesPerAgent_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SalesPerMonth_Text() As String
        Get
            Return _loader.GetString("SalesPerMonth_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SariyaCity_Text() As String
        Get
            Return _loader.GetString("SariyaCity_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SariyaEmail_Text() As String
        Get
            Return _loader.GetString("SariyaEmail_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SariyaName_Text() As String
        Get
            Return _loader.GetString("SariyaName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property SariyaTel_Text() As String
        Get
            Return _loader.GetString("SariyaTel_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ScottCity_Text() As String
        Get
            Return _loader.GetString("ScottCity_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ScottEmail_Text() As String
        Get
            Return _loader.GetString("ScottEmail_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ScottName_Text() As String
        Get
            Return _loader.GetString("ScottName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ScottTel_Text() As String
        Get
            Return _loader.GetString("ScottTel_Text")
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

    Public Shared ReadOnly Property Title_Text() As String
        Get
            Return _loader.GetString("Title_Text")
        End Get
    End Property

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property VirtualizationDescription() As String
        Get
            Return _loader.GetString("VirtualizationDescription")
        End Get
    End Property

    Public Shared ReadOnly Property VirtualizationName() As String
        Get
            Return _loader.GetString("VirtualizationName")
        End Get
    End Property

    Public Shared ReadOnly Property VirtualizationTitle() As String
        Get
            Return _loader.GetString("VirtualizationTitle")
        End Get
    End Property
End Class