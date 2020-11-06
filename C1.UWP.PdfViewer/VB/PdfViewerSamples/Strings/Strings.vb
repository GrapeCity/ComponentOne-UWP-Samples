Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("PdfViewerSamplesLib/Resources")

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ComboBoxItemHorizontal_Content() As String
        Get
            Return _loader.GetString("ComboBoxItemHorizontal_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ComboBoxItemVertical_Content() As String
        Get
            Return _loader.GetString("ComboBoxItemVertical_Content")
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

    Public Shared ReadOnly Property Download_Text() As String
        Get
            Return _loader.GetString("Download_Text")
        End Get
    End Property

    Public Shared ReadOnly Property DownloadException() As String
        Get
            Return _loader.GetString("DownloadException")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property LargeFileDescription() As String
        Get
            Return _loader.GetString("LargeFileDescription")
        End Get
    End Property

    Public Shared ReadOnly Property LargeFileName() As String
        Get
            Return _loader.GetString("LargeFileName")
        End Get
    End Property

    Public Shared ReadOnly Property LargeFileTitle() As String
        Get
            Return _loader.GetString("LargeFileTitle")
        End Get
    End Property

    Public Shared ReadOnly Property Load_Content() As String
        Get
            Return _loader.GetString("Load_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Orientation_Text() As String
        Get
            Return _loader.GetString("Orientation_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Print_Content() As String
        Get
            Return _loader.GetString("Print_Content")
        End Get
    End Property

    Public Shared ReadOnly Property PrintDescription() As String
        Get
            Return _loader.GetString("PrintDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PrintException() As String
        Get
            Return _loader.GetString("PrintException")
        End Get
    End Property

    Public Shared ReadOnly Property PrintName() As String
        Get
            Return _loader.GetString("PrintName")
        End Get
    End Property

    Public Shared ReadOnly Property PrintTitle() As String
        Get
            Return _loader.GetString("PrintTitle")
        End Get
    End Property

    Public Shared ReadOnly Property Retry_Content() As String
        Get
            Return _loader.GetString("Retry_Content")
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
End Class