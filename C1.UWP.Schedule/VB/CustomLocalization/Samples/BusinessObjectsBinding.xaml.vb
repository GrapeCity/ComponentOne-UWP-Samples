Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Runtime.Serialization
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class BusinessObjectsBinding
    Inherits Page
    Public Sub New()
        AddHandler Unloaded, AddressOf BusinessObjectsBinding_Unloaded
        Me.InitializeComponent()
        sched1.Settings.FirstVisibleTime = System.TimeSpan.FromHours(8)

        Dim apps As AppointmentCollection = TryCast(Resources("_ds"), AppointmentCollection)
        If apps IsNot Nothing Then
            ' add demo appointment
            Dim app As New Appointment()
            app.Subject = Strings.AppointmentSubject
            app.Start = DateTime.Today
            app.Duration = TimeSpan.FromMinutes(60)
            apps.Add(app)

        End If
    End Sub
    Sub BusinessObjectsBinding_Unloaded(sender As Object, e As RoutedEventArgs)
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

    Private Sub Add_Click(sender As Object, e As RoutedEventArgs)
        sched1.NewAppointmentDialog()
    End Sub

    Private Sub View_Click(sender As Object, e As RoutedEventArgs)
        If sched1.ViewType = C1.Xaml.Schedule.ViewType.Month Then
            sched1.ViewType = C1.Xaml.Schedule.ViewType.Day
            ViewButton.Label = Strings.MonthView
        Else
            sched1.ViewType = C1.Xaml.Schedule.ViewType.Month
            ViewButton.Label = Strings.DayView
        End If
    End Sub

    Private Sub Today_Click(sender As Object, e As RoutedEventArgs)
        sched1.SelectedDateTime = DateTime.Now
    End Sub
End Class

<DataContract(Name:="Appointment", [Namespace]:="http://www.componentone.com")>
Public Class Appointment
    Implements INotifyPropertyChanged
    Public Sub New()
        Id = Guid.NewGuid()
    End Sub
    <DataMember>
    Public Property Id() As Guid

    Private _subject As String = ""
    <DataMember>
    Public Property Subject() As String
        Get
            Return _subject
        End Get
        Set
            If _subject <> Value Then
                _subject = Value
                OnPropertyChanged("Subject")
            End If
        End Set
    End Property

    Private _location As String = ""
    <DataMember>
    Public Property Location() As String
        Get
            Return _location
        End Get
        Set
            If _location <> Value Then
                _location = Value
                OnPropertyChanged("Location")
            End If
        End Set
    End Property

    Private _start As DateTime
    <DataMember>
    Public Property Start() As DateTime
        Get
            Return _start
        End Get
        Set
            If _start <> Value Then
                _start = Value
                OnPropertyChanged("Start")
            End If
        End Set
    End Property

    <DataMember>
    Public Property [End]() As DateTime
        Get
            Return _start.Add(_duration)
        End Get
        Set
            If Value >= _start Then
                Duration = (Value.Subtract(_start))
                OnPropertyChanged("End")
            End If
        End Set
    End Property

    Private _duration As TimeSpan
    Public Property Duration() As TimeSpan
        Get
            Return _duration
        End Get
        Set
            If _duration <> Value Then
                _duration = Value
                OnPropertyChanged("Duration")
            End If
        End Set
    End Property

    Private _description As String = ""
    <DataMember>
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set
            If _description <> Value Then
                _description = Value
                OnPropertyChanged("Description")
            End If
        End Set
    End Property

    Private _properties As String = ""
    <DataMember>
    Public Property Properties() As String
        Get
            Return _properties
        End Get
        Set
            If _properties <> Value Then
                _properties = Value
                OnPropertyChanged("Properties")
            End If
        End Set
    End Property

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Protected Sub OnPropertyChanged(propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub
End Class

' inherit from ObservableCollection to allow auto refresh in calendar
Public Class AppointmentCollection
    Inherits ObservableCollection(Of Appointment)
    Public Sub New()
    End Sub
End Class