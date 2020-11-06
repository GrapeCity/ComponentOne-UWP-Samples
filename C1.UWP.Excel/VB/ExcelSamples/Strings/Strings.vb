Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("ExcelSamplesLib/Resources")


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

    Public Shared ReadOnly Property Typexlsx() As String
        Get
            Return _loader.GetString("Typexlsx")
        End Get
    End Property

    Public Shared ReadOnly Property Typecsv() As String
        Get
            Return _loader.GetString("Typecsv")
        End Get
    End Property

    Public Shared ReadOnly Property DefaultFileName() As String
        Get
            Return _loader.GetString("DefaultFileName")
        End Get
    End Property

    Public Shared ReadOnly Property SaveLocationTip() As String
        Get
            Return _loader.GetString("SaveLocationTip")
        End Get
    End Property

    Public Shared ReadOnly Property SaveAndOpenException() As String
        Get
            Return _loader.GetString("SaveAndOpenException")
        End Get
    End Property

    Public Shared ReadOnly Property SheetName() As String
        Get
            Return _loader.GetString("SheetName")
        End Get
    End Property

    Public Shared ReadOnly Property DataCreatedTip() As String
        Get
            Return _loader.GetString("DataCreatedTip")
        End Get
    End Property

    Public Shared ReadOnly Property OpenTip() As String
        Get
            Return _loader.GetString("OpenTip")
        End Get
    End Property

    Public Shared ReadOnly Property ExcelSamplesTitle() As String
        Get
            Return _loader.GetString("ExcelSamplesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ExcelSamplesDescription() As String
        Get
            Return _loader.GetString("ExcelSamplesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ExcelSamplesName() As String
        Get
            Return _loader.GetString("ExcelSamplesName")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property C1Excel_Text() As String
        Get
            Return _loader.GetString("C1Excel_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ContentTB_Text() As String
        Get
            Return _loader.GetString("ContentTB_Text")
        End Get
    End Property

    Public Shared ReadOnly Property CreateButton_Content() As String
        Get
            Return _loader.GetString("CreateButton_Content")
        End Get
    End Property

    Public Shared ReadOnly Property OpenButton_Content() As String
        Get
            Return _loader.GetString("OpenButton_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SaveButton_Content() As String
        Get
            Return _loader.GetString("SaveButton_Content")
        End Get
    End Property
End Class