Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("ExtendedSamplesLib/Resources")

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

    Public Shared ReadOnly Property BookDemoDescription() As String
        Get
            Return _loader.GetString("BookDemoDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BookDemoName() As String
        Get
            Return _loader.GetString("BookDemoName")
        End Get
    End Property

    Public Shared ReadOnly Property BookDemoTitle() As String
        Get
            Return _loader.GetString("BookDemoTitle")
        End Get
    End Property

    Public Shared ReadOnly Property BookPageSpanDescription() As String
        Get
            Return _loader.GetString("BookPageSpanDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BookPageSpanName() As String
        Get
            Return _loader.GetString("BookPageSpanName")
        End Get
    End Property

    Public Shared ReadOnly Property BookPageSpanTitle() As String
        Get
            Return _loader.GetString("BookPageSpanTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ColorPickerDemoDescription() As String
        Get
            Return _loader.GetString("ColorPickerDemoDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ColorPickerDemoName() As String
        Get
            Return _loader.GetString("ColorPickerDemoName")
        End Get
    End Property

    Public Shared ReadOnly Property ColorPickerDemoTitle() As String
        Get
            Return _loader.GetString("ColorPickerDemoTitle")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property Note_Text() As String
        Get
            Return _loader.GetString("Note_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Price_Text() As String
        Get
            Return _loader.GetString("Price_Text")
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
