Imports Windows.ApplicationModel.Appointments
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Popups
Imports Windows.UI
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Runtime.Serialization
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System
Imports C1.Xaml.Calendar

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class CalendarDataDemo
    Inherits Page
    Private _appointments As New AppointmentCollection()
    ' If it is true, the sample will work with device's Appointments provider.
    ' If it is false, the sample will bind collection of custom Appointment objects. 
    Private Shared UseAppointmentManager As Boolean = True
    ' async task for opening device calendar application
    Private _calTask As Windows.Foundation.IAsyncOperation(Of String)

    Public Sub New()
        Me.InitializeComponent()

        If Not UseAppointmentManager Then
            ' bind C1Calendar to the AppointmentCollection
            calendar.StartTimePath = "Start"
            calendar.EndTimePath = "End"
            calendar.DataSource = _appointments

        End If
    End Sub

    Private Sub Appointment_KeyDown(sender As Object, e As KeyRoutedEventArgs)
        ' handle appointment removing
        If e.Key = Windows.System.VirtualKey.Delete Then
            Dim el As ListBox = TryCast(sender, ListBox)
            If el IsNot Nothing AndAlso el.SelectedItems.Count > 0 Then
                For Each app As Appointment In el.SelectedItems
                    _appointments.Remove(app)
                Next
            End If
        End If
    End Sub

    Private Sub AlterAppearance_Click(sender As Object, e As RoutedEventArgs)
        ' show Sundays in Red and Saturdays in Blue
        Dim datesSelector As DaySlotTemplateSelector = TryCast(Me.Resources("DaySlotTemplateSelector"), DaySlotTemplateSelector)
        calendar.DaySlotTemplateSelector = datesSelector
        ' use bolded days dictionary defined in the DaySlotTemplateSelector class instance 
        calendar.DayOfWeekSlotTemplateSelector = New DayOfWeekTemplateSelector()
        calendar.WeekendBrush = New SolidColorBrush(Colors.Red)
        calendar.TodayBrush = New SolidColorBrush(Colors.Green)
        Refresh(calendar.DisplayDate)
    End Sub

    Private Sub cal1_Loaded(sender As Object, e As RoutedEventArgs)
        Refresh(calendar.DisplayDate)
    End Sub

    Private Sub Refresh(displayDate As DateTime)
        ' update bolded dates for the visible month (and for adjacent days)
        GetBoldedDates(displayDate.AddMonths(-1), displayDate.AddMonths(2))
    End Sub

    Private Sub cal1_DisplayDateChanging(sender As Object, e As DateChangedEventArgs)
        Refresh(e.NewValue)
    End Sub

    Private Async Sub calendar_DoubleTapped(sender As Object, e As RoutedEventArgs)
        If _calTask IsNot Nothing Then
            ' if there Is already opened task, cancel it first
            _calTask.Cancel()
            _calTask.Close()
            _calTask = Nothing
        End If
        ' show the list of appointments for the bolded day
        Dim fel As FrameworkElement = TryCast(e.OriginalSource, FrameworkElement)
        If fel IsNot Nothing Then
            Dim slot As DaySlot = TryCast(fel.DataContext, DaySlot)
            If slot IsNot Nothing Then
                Dim [date] As DateTime = slot.[Date]
                Dim message As String = [date].ToString()
                If slot.DataSource Is Nothing OrElse slot.DataSource.Count = 0 Then
                    If UseAppointmentManager Then
                        ' create new appointment and fill initial properties
                        Dim app As New Windows.ApplicationModel.Appointments.Appointment()
                        app.StartTime = [date]
                        app.AllDay = True
                        app.Subject = Strings.DeviceAppointmentSubject
                        ' Show the Appointments provider Add Appointment UI, to enable the user to add an appointment. 
                        ' The returned id can be used later to edit or remove existent appointment.
                        _calTask = AppointmentManager.ShowEditNewAppointmentAsync(app)
                        Dim id As String = Await _calTask
                        Refresh(calendar.DisplayDate)
                        _calTask = Nothing
                        Return
                    Else
                        If Not Device.IsWindowsPhoneDevice() Then
                            Dim boldedDaySlotTemplate As DataTemplate = TryCast(Me.Resources("BoldedDaySlotTemplate"), DataTemplate)
                            calendar.BoldedDaySlotTemplate = boldedDaySlotTemplate
                            Dim app As New Appointment()
                            app.Start = calendar.SelectedDate
                            app.Duration = TimeSpan.FromDays(1)
                            app.Subject = Strings.AppointmentSubject + " " + app.Start.ToString()
                            _appointments.Add(app)
                            calendar.DataSource = _appointments
                            Return
                        Else
                            message += vbCr & vbLf + Strings.Message
                        End If
                    End If
                Else
                    If Not UseAppointmentManager Then
                        For Each app As Appointment In slot.DataSource
                            message += vbCr & vbLf + app.Subject
                        Next
                    Else
                        For Each app As Windows.ApplicationModel.Appointments.Appointment In slot.DataSource
                            message += vbCr & vbLf + app.Subject
                        Next
                    End If
                    Dim dialog As New MessageDialog(message)

                    dialog.ShowAsync()
                End If
            End If
        End If
    End Sub

    Private Async Function GetBoldedDates(start As DateTime, [end] As DateTime) As Task
        Dim boldedDates As DateList = calendar.BoldedDates
        If Not UseAppointmentManager Then
            ' generate test appointment
            Dim list As New List(Of Object)()
            Dim app As New Appointment()
            app.Start = start.AddDays(12)
            app.[End] = app.Start.AddHours(1)
            app.Subject = Strings.EmulatorAppointmentSubject
            list.Add(app)
            ' bind calendar to data
            ' don't set StartTimePath and EndTimePath as they are the same as default values
            calendar.DataSource = list
        Else
            ' get appointments from the device calendar
            Dim store As AppointmentStore = Await AppointmentManager.RequestStoreAsync(AppointmentStoreAccessType.AllCalendarsReadOnly)
            Dim appointments As IEnumerable = Await store.FindAppointmentsAsync(New DateTimeOffset(start), [end] - start)

            ' bind calendar to the search results
            ' don't set StartTimePath and EndTimePath as they are the same as default values
            calendar.DataSource = appointments
        End If
    End Function

    Private Sub Help_Click(sender As Object, e As RoutedEventArgs)
        Dim dialog As New MessageDialog(Strings.DialogMessage)
        dialog.ShowAsync()
    End Sub

    Private Sub Today_Click(sender As Object, e As RoutedEventArgs)
        calendar.Today()
    End Sub

End Class
