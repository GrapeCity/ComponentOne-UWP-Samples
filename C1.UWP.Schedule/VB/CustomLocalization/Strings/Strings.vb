Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("ScheduleSamplesLib/Resources")

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

    Public Shared ReadOnly Property DefaultName() As String
        Get
            Return _loader.GetString("DefaultName")
        End Get
    End Property

    Public Shared ReadOnly Property DefaultTitle() As String
        Get
            Return _loader.GetString("DefaultTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DefaultDescription() As String
        Get
            Return _loader.GetString("DefaultDescription")
        End Get
    End Property

    Public Shared ReadOnly Property BindingName() As String
        Get
            Return _loader.GetString("BindingName")
        End Get
    End Property

    Public Shared ReadOnly Property BindingTitle() As String
        Get
            Return _loader.GetString("BindingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property BindingDescription() As String
        Get
            Return _loader.GetString("BindingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property SaveName() As String
        Get
            Return _loader.GetString("SaveName")
        End Get
    End Property

    Public Shared ReadOnly Property SaveTitle() As String
        Get
            Return _loader.GetString("SaveTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SaveDescription() As String
        Get
            Return _loader.GetString("SaveDescription")
        End Get
    End Property

    Public Shared ReadOnly Property AppointmentSubject() As String
        Get
            Return _loader.GetString("AppointmentSubject")
        End Get
    End Property

    Public Shared ReadOnly Property MonthView() As String
        Get
            Return _loader.GetString("MonthView")
        End Get
    End Property

    Public Shared ReadOnly Property DayView() As String
        Get
            Return _loader.GetString("DayView")
        End Get
    End Property

    Public Shared ReadOnly Property HolidaySubject() As String
        Get
            Return _loader.GetString("HolidaySubject")
        End Get
    End Property

    Public Shared ReadOnly Property ExportFileName() As String
        Get
            Return _loader.GetString("ExportFileName")
        End Get
    End Property

    Public Shared ReadOnly Property ImportFileName() As String
        Get
            Return _loader.GetString("ImportFileName")
        End Get
    End Property

    Public Shared ReadOnly Property RelayCommandArgumentNullException() As String
        Get
            Return _loader.GetString("RelayCommandArgumentNullException")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Day_Text() As String
        Get
            Return _loader.GetString("Day_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Export_Content() As String
        Get
            Return _loader.GetString("Export_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Import_Content() As String
        Get
            Return _loader.GetString("Import_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Month_Text() As String
        Get
            Return _loader.GetString("Month_Text")
        End Get
    End Property

    Public Shared ReadOnly Property New_Label() As String
        Get
            Return _loader.GetString("New_Label")
        End Get
    End Property

    Public Shared ReadOnly Property Today_Label() As String
        Get
            Return _loader.GetString("Today_Label")
        End Get
    End Property

    Public Shared ReadOnly Property View_Label() As String
        Get
            Return _loader.GetString("View_Label")
        End Get
    End Property

    Public Shared ReadOnly Property Week_Text() As String
        Get
            Return _loader.GetString("Week_Text")
        End Get
    End Property

    Public Shared ReadOnly Property WorkWeek_Text() As String
        Get
            Return _loader.GetString("WorkWeek_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Cancel_Label() As String
        Get
            Return _loader.GetString("Cancel_Label")
        End Get
    End Property

    Public Shared ReadOnly Property Save_Label() As String
        Get
            Return _loader.GetString("Save_Label")
        End Get
    End Property

    Public Shared ReadOnly Property Back_Label() As String
        Get
            Return _loader.GetString("Back_Label")
        End Get
    End Property
End Class