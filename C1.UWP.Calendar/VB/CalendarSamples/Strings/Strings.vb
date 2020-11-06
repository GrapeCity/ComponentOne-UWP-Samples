Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("CalendarSamplesLib/Resources")

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

    Public Shared ReadOnly Property CalendarSamplesDefaultTitle() As String
        Get
            Return _loader.GetString("CalendarSamplesDefaultTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesDefaultDescription() As String
        Get
            Return _loader.GetString("CalendarSamplesDefaultDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesDefaultName() As String
        Get
            Return _loader.GetString("CalendarSamplesDefaultName")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesBoldedDaysTitle() As String
        Get
            Return _loader.GetString("CalendarSamplesBoldedDaysTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesBoldedDaysDescription() As String
        Get
            Return _loader.GetString("CalendarSamplesBoldedDaysDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesBoldedDaysName() As String
        Get
            Return _loader.GetString("CalendarSamplesBoldedDaysName")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesCustomDaysTitle() As String
        Get
            Return _loader.GetString("CalendarSamplesCustomDaysTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesCustomDaysDescription() As String
        Get
            Return _loader.GetString("CalendarSamplesCustomDaysDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesCustomDaysName() As String
        Get
            Return _loader.GetString("CalendarSamplesCustomDaysName")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesCustomDataTitle() As String
        Get
            Return _loader.GetString("CalendarSamplesCustomDataTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesCustomDataDescription() As String
        Get
            Return _loader.GetString("CalendarSamplesCustomDataDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CalendarSamplesCustomDataName() As String
        Get
            Return _loader.GetString("CalendarSamplesCustomDataName")
        End Get
    End Property

    Public Shared ReadOnly Property AppointmentSubject() As String
        Get
            Return _loader.GetString("AppointmentSubject")
        End Get
    End Property

    Public Shared ReadOnly Property BoldedDay1() As String
        Get
            Return _loader.GetString("BoldedDay1")
        End Get
    End Property

    Public Shared ReadOnly Property BoldedDay2() As String
        Get
            Return _loader.GetString("BoldedDay2")
        End Get
    End Property

    Public Shared ReadOnly Property BoldedDay3() As String
        Get
            Return _loader.GetString("BoldedDay3")
        End Get
    End Property

    Public Shared ReadOnly Property BoldedMotherBirthday() As String
        Get
            Return _loader.GetString("BoldedMotherBirthday")
        End Get
    End Property

    Public Shared ReadOnly Property BoldedDay4() As String
        Get
            Return _loader.GetString("BoldedDay4")
        End Get
    End Property

    Public Shared ReadOnly Property BoldedDay5() As String
        Get
            Return _loader.GetString("BoldedDay5")
        End Get
    End Property

    Public Shared ReadOnly Property BoldedDay6() As String
        Get
            Return _loader.GetString("BoldedDay6")
        End Get
    End Property

    Public Shared ReadOnly Property NewYearDay() As String
        Get
            Return _loader.GetString("NewYearDay")
        End Get
    End Property

    Public Shared ReadOnly Property ChristmasDay() As String
        Get
            Return _loader.GetString("ChristmasDay")
        End Get
    End Property

    Public Shared ReadOnly Property ValentineDay() As String
        Get
            Return _loader.GetString("ValentineDay")
        End Get
    End Property

    Public Shared ReadOnly Property EarthDay() As String
        Get
            Return _loader.GetString("EarthDay")
        End Get
    End Property

    Public Shared ReadOnly Property FlagDay() As String
        Get
            Return _loader.GetString("FlagDay")
        End Get
    End Property

    Public Shared ReadOnly Property IndependenceDay() As String
        Get
            Return _loader.GetString("IndependenceDay")
        End Get
    End Property

    Public Shared ReadOnly Property HalloweenDay() As String
        Get
            Return _loader.GetString("HalloweenDay")
        End Get
    End Property

    Public Shared ReadOnly Property VeteransDay() As String
        Get
            Return _loader.GetString("VeteransDay")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property
End Class
