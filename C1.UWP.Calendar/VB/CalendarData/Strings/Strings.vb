Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("CalendarDataLib/Resources")

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

    Public Shared ReadOnly Property CalendarDataTitle() As String
        Get
            Return _loader.GetString("CalendarDataTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarDatatDescription() As String
        Get
            Return _loader.GetString("CalendarDatatDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarDataName() As String
        Get
            Return _loader.GetString("CalendarDataName")
        End Get
    End Property

    Public Shared ReadOnly Property AppointmentSubject() As String
        Get
            Return _loader.GetString("AppointmentSubject")
        End Get
    End Property

    Public Shared ReadOnly Property DeviceAppointmentSubject() As String
        Get
            Return _loader.GetString("DeviceAppointmentSubject")
        End Get
    End Property

    Public Shared ReadOnly Property Message() As String
        Get
            Return _loader.GetString("Message")
        End Get
    End Property

    Public Shared ReadOnly Property EmulatorAppointmentSubject() As String
        Get
            Return _loader.GetString("EmulatorAppointmentSubject")
        End Get
    End Property

    Public Shared ReadOnly Property DialogMessage() As String
        Get
            Return _loader.GetString("DialogMessage")
        End Get
    End Property

    Public Shared ReadOnly Property Alter_Label() As String
        Get
            Return _loader.GetString("Alter_Label")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Help_Label() As String
        Get
            Return _loader.GetString("Help_Label")
        End Get
    End Property

    Public Shared ReadOnly Property Today_Label() As String
        Get
            Return _loader.GetString("Today_Label")
        End Get
    End Property
End Class
