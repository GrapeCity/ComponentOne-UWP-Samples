Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System

' inherit from ObservableCollection to allow auto refresh in calendar
Public Class AppointmentCollection
		Inherits ObservableCollection(Of Appointment)
		Public Sub New()
		End Sub
	End Class
