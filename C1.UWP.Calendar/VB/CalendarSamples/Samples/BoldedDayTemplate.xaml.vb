Imports Windows.UI.Xaml.Controls
Imports System

''' <summary>
''' The C1Calendar control allows to set custom DataTemplate to represent bolded days. Use C1Calendar.BoldedDaySlotTemplate property to alter appearance of all bolded days.
''' </summary>
Public NotInheritable Partial Class BoldedDayTemplate
		Inherits Page
		Public Sub New()
			Me.InitializeComponent()

			' add some bolded days
			cal1.BoldedDates.Add(DateTime.Today.AddDays(2))
			cal1.BoldedDates.Add(DateTime.Today.AddDays(12))
			cal1.BoldedDates.Add(DateTime.Today.AddDays(22))
			cal1.BoldedDates.Add(DateTime.Today.AddDays(-2))
			cal1.BoldedDates.Add(DateTime.Today.AddDays(-12))
			cal1.BoldedDates.Add(DateTime.Today.AddDays(-22))
		End Sub
	End Class
