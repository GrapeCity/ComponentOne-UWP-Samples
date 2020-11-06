Imports Windows.UI.Xaml.Controls
Imports System

''' <summary>
''' Shows the C1Calendar control with default appearance options and some bolded dates.
''' </summary>
Public NotInheritable Partial Class DefaultView
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
