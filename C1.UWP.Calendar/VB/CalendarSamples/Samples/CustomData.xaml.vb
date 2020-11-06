Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Runtime.Serialization
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System
Imports C1.Xaml.Calendar

''' <summary>
''' Binds calendar to custom data and use custom BoldedDaySlotTemplate to show the list of events. 
''' Use double tap to create new event, use Delete key to remove event.
''' Note, the full sample with Appointment dialog is implemented as a separate application, see CalendarData sample. 
''' </summary>
Public NotInheritable Partial Class CustomData
		Inherits Page
		Private _appointments As New AppointmentCollection()
		Public Sub New()
			Me.InitializeComponent()

			' bind C1Calendar to the AppointmentCollection
			cal1.StartTimePath = "Start"
			cal1.EndTimePath = "End"
			cal1.DataSource = _appointments
		End Sub

		Private Sub calendar_DoubleTapped(sender As Object, e As DoubleTappedRoutedEventArgs)
			' add test appointment
			Dim source As FrameworkElement = TryCast(e.OriginalSource, FrameworkElement)
			If source IsNot Nothing AndAlso TypeOf source.DataContext Is DaySlot Then
				' create new in-place appointment
				Dim app As New Appointment()
				app.Start = cal1.SelectedDate
				app.Duration = TimeSpan.FromDays(1)
				app.Subject = Strings.AppointmentSubject + " " + app.Start.ToString()
				_appointments.Add(app)
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
	End Class


	<DataContract(Name := "Appointment", [Namespace] := "http://www.componentone.com")> _
	Public Class Appointment
		Implements INotifyPropertyChanged
		Public Sub New()
			Id = Guid.NewGuid()
		End Sub
		<DataMember> _
		Public Property Id() As Guid

		Private _subject As String = ""
		<DataMember> _
		Public Property Subject() As String
			Get
				Return _subject
			End Get
			Set
				If _subject <> value Then
					_subject = value
					OnPropertyChanged("Subject")
				End If
			End Set
		End Property

		Private _location As String = ""
		<DataMember> _
		Public Property Location() As String
			Get
				Return _location
			End Get
			Set
				If _location <> value Then
					_location = value
					OnPropertyChanged("Location")
				End If
			End Set
		End Property

		Private _start As DateTime
		<DataMember> _
		Public Property Start() As DateTime
			Get
				Return _start
			End Get
			Set
				If _start <> value Then
					_start = value
					OnPropertyChanged("Start")
				End If
			End Set
		End Property

		<DataMember> _
		Public Property [End]() As DateTime
			Get
				Return _start.Add(_duration)
			End Get
			Set
				If value >= _start Then
					Duration = (value.Subtract(_start))
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
				If _duration <> value Then
					_duration = value
					OnPropertyChanged("Duration")
				End If
			End Set
		End Property

		Private _description As String = ""
		<DataMember> _
		Public Property Description() As String
			Get
				Return _description
			End Get
			Set
				If _description <> value Then
					_description = value
					OnPropertyChanged("Description")
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
