Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("InputPanelSamplesLib/Resources")

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property DemoDescription() As String
        Get
            Return _loader.GetString("DemoDescription")
        End Get
    End Property

    Public Shared ReadOnly Property DemoName() As String
        Get
            Return _loader.GetString("DemoName")
        End Get
    End Property

    Public Shared ReadOnly Property DemoTitle() As String
        Get
            Return _loader.GetString("DemoTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CustomTemplateDescription() As String
        Get
            Return _loader.GetString("CustomTemplateDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CustomTemplateName() As String
        Get
            Return _loader.GetString("CustomTemplateName")
        End Get
    End Property

    Public Shared ReadOnly Property CustomTemplateTitle() As String
        Get
            Return _loader.GetString("CustomTemplateTitle")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrateDescription() As String
        Get
            Return _loader.GetString("IntegrateDescription")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrateName() As String
        Get
            Return _loader.GetString("IntegrateName")
        End Get
    End Property

    Public Shared ReadOnly Property IntegrateTitle() As String
        Get
            Return _loader.GetString("IntegrateTitle")
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

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property FileNotFoundException() As String
        Get
            Return _loader.GetString("FileNotFoundException")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property
End Class