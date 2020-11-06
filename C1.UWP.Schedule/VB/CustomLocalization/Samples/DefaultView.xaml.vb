Imports System
Imports C1.Xaml.Schedule
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class DefaultView
    Inherits Page
    Public Sub New()
        AddHandler Unloaded, AddressOf DefaultView_Unloaded
        Me.InitializeComponent()
        sched1.Settings.FirstVisibleTime = System.TimeSpan.FromHours(8)

        ' add test appointments
        Dim app As C1.C1Schedule.Appointment = sched1.DataStorage.AppointmentStorage.Appointments.Add()
        app.Start = DateTime.Today.AddHours(14)
        app.Duration = TimeSpan.FromMinutes(60)
        app.Label = sched1.DataStorage.LabelStorage.Labels(3)
        app.Subject = Strings.AppointmentSubject

        app = sched1.DataStorage.AppointmentStorage.Appointments.Add()
        app.Start = DateTime.Today.AddDays(2)
        app.AllDayEvent = True
        app.Label = sched1.DataStorage.LabelStorage.Labels(9)
        app.BusyStatus = sched1.DataStorage.StatusStorage.Statuses(C1.C1Schedule.StatusTypeEnum.Free)
        app.Subject = Strings.HolidaySubject
    End Sub

    Sub DefaultView_Unloaded(sender As Object, e As RoutedEventArgs)
        ' dispose C1Scheduler control to avoid memory leaks
        sched1.Dispose()
    End Sub
    Private Sub DayClick(sender As Object, e As RoutedEventArgs)
        sched1.ChangeStyle(sched1.OneDayStyle)
    End Sub
    Private Sub WorkWeekClick(sender As Object, e As RoutedEventArgs)
        sched1.ChangeStyle(sched1.WorkingWeekStyle)
    End Sub
    Private Sub WeekClick(sender As Object, e As RoutedEventArgs)
        sched1.ChangeStyle(sched1.WeekStyle)
    End Sub

    Private Sub MonthClick(sender As Object, e As RoutedEventArgs)
        sched1.ChangeStyle(sched1.MonthStyle)
    End Sub

    Private Sub Export_Click(sender As Object, e As RoutedEventArgs)
        C1Scheduler.ExportCommand.Execute(If(sched1.SelectedAppointment IsNot Nothing, sched1.SelectedAppointment, Nothing), sched1)
    End Sub
    Private Sub Import_Click(sender As Object, e As RoutedEventArgs)
        C1Scheduler.ImportCommand.Execute(Nothing, sched1)
    End Sub

    Private Sub Add_Click(sender As Object, e As RoutedEventArgs)
        sched1.NewAppointmentDialog()
    End Sub

    Private Sub View_Click(sender As Object, e As RoutedEventArgs)
        If sched1.ViewType = ViewType.Month Then
            sched1.ViewType = ViewType.Day
            ViewButton.Label = Strings.MonthView
        Else
            sched1.ViewType = ViewType.Month
            ViewButton.Label = Strings.DayView
        End If
    End Sub

    Private Sub Today_Click(sender As Object, e As RoutedEventArgs)
        sched1.SelectedDateTime = DateTime.Now
    End Sub
End Class