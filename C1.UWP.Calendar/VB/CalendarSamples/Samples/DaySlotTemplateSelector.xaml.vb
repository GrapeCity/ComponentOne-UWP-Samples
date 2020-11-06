Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Calendar

''' <summary>
''' Shows customized holiday days, alters appearance of weekends and current day, uses custom data to show bolded days.
''' </summary>
Public NotInheritable Partial Class DaySlotTemplateSelector
		Inherits Page
		' dictionary of appointments to display in calendar
		Private _boldedDays As New Dictionary(Of DateTime, String)()
		Private _dayTemplateSelector As DayTemplateSelector = Nothing

		Public Sub New()
			Me.InitializeComponent()

			calendar.DaySlotTemplateSelector = DayTemplateSelector
			calendar.DayOfWeekSlotTemplateSelector = New DayOfWeekTemplateSelector()

			' add some bolded days
			_boldedDays.Add(DateTime.Today.AddDays(2), Strings.BoldedDay1)
			_boldedDays.Add(DateTime.Today.AddDays(15), Strings.BoldedDay2)
			_boldedDays.Add(DateTime.Today.AddDays(29), Strings.BoldedDay3)
			_boldedDays.Add(DateTime.Today.AddDays(48), Strings.BoldedMotherBirthday)
			_boldedDays.Add(DateTime.Today.AddDays(-5), Strings.BoldedDay4)
			_boldedDays.Add(DateTime.Today.AddDays(-17), Strings.BoldedDay5)
			_boldedDays.Add(DateTime.Today.AddDays(-30), Strings.BoldedDay6)

			' bind calendar to _boldedDays dictionary
			calendar.StartTimePath = "Key"
			calendar.DataSource = _boldedDays
		End Sub

		''' <summary>
		''' The DayTemplateSelector to alter individual days appearance.
		''' </summary>
		Private ReadOnly Property DayTemplateSelector() As DayTemplateSelector
			Get
				If _dayTemplateSelector Is Nothing Then
					'throw exception in CE, replace with following codes
					'_dayTemplateSelector = Resources["DaySlotTemplateSelector"] as DayTemplateSelector;
					_dayTemplateSelector = New DayTemplateSelector()
					_dayTemplateSelector.Resources = Me.Resources

					' fill-in some holidays
					FillHolidays(_dayTemplateSelector.Holidays, DateTime.Today.Year)
					FillHolidays(_dayTemplateSelector.Holidays, DateTime.Today.Year + 1)
				End If
				Return _dayTemplateSelector
			End Get
		End Property
		Private Shared Sub FillHolidays(ByRef holidays As Dictionary(Of DateTime, Holiday), year As Integer)
			AddHoliday(holidays, New DateTime(year, 1, 1), Strings.NewYearDay, Colors.Green, Colors.White)
			AddHoliday(holidays, New DateTime(year, 12, 25), Strings.ChristmasDay, Colors.Red, Colors.White)
			AddHoliday(holidays, New DateTime(year, 2, 14), Strings.ValentineDay, Colors.RosyBrown, Colors.DarkRed)
			AddHoliday(holidays, New DateTime(year, 4, 22), Strings.EarthDay, Colors.YellowGreen, Colors.Brown)
			AddHoliday(holidays, New DateTime(year, 6, 14), Strings.FlagDay, Colors.MidnightBlue, Colors.White)
			AddHoliday(holidays, New DateTime(year, 7, 4), Strings.IndependenceDay, Colors.MidnightBlue, Colors.White)
			AddHoliday(holidays, New DateTime(year, 10, 31), Strings.HalloweenDay, Colors.DarkOrange, Colors.Brown)
			AddHoliday(holidays, New DateTime(year, 11, 11), Strings.VeteransDay, Colors.MidnightBlue, Colors.White)
		End Sub
		Private Shared Sub AddHoliday(ByRef holidays As Dictionary(Of DateTime, Holiday), [date] As DateTime, text As String, background As Color, foreground As Color)
			holidays.Add([date], New Holiday() With { _
				.[Date] = [date], _
				.Text = text, _
				.Background = New SolidColorBrush(background), _
				.Foreground = New SolidColorBrush(foreground) _
			})
		End Sub
	End Class

	''' <summary>
	''' The structure to hold information about holiday day and it's appearance
	''' </summary>
	Public Structure Holiday
		''' <summary>
		''' The date
		''' </summary>
		Public Property [Date]() As DateTime
		''' <summary>
		''' The text to show in calendar
		''' </summary>
		Public Property Text() As [String]
		''' <summary>
		''' The brush to color day in calendar
		''' </summary>
		Public Property Background() As Brush
		''' <summary>
		''' The foreground brush to color day in calendar
		''' </summary>
		Public Property Foreground() As Brush
	End Structure

	Public Class DayTemplateSelector
		Inherits C1.Xaml.Calendar.DaySlotTemplateSelector
		Public Holidays As New Dictionary(Of DateTime, Holiday)()
		Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
			Dim slot As DaySlot = TryCast(item, DaySlot)
			If slot IsNot Nothing Then
				If Not slot.IsAdjacent AndAlso slot.DayOfWeek = DayOfWeek.Saturday Then
                ' set color for Saturday
                DirectCast(container, Control).Foreground = New SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 90, 255))
            End If
				If Not slot.IsAdjacent AndAlso Holidays.ContainsKey(slot.[Date]) Then
					Dim holiday As Holiday = Holidays(slot.[Date])
					slot.Tag = holiday
					Return TryCast(Resources("Holiday"), DataTemplate)
				End If
				If slot.[Date] = DateTime.Today Then
                ' use TodayBrush for border
                DirectCast(container, Control).BorderBrush = (CType(container, Control)).Background
                ' clear background
                DirectCast(container, Control).Background = New SolidColorBrush(Windows.UI.Colors.Transparent)
                Return TryCast((If(slot.IsBolded, Resources("TodayBoldedDay"), Resources("TodayUnboldedDay"))), DataTemplate)
				End If
			End If

			' the base class will select custom DataTemplate, defined in the DaySlotTemplateSelector.Resources collection (see MainPage.xaml file)
			Return MyBase.SelectTemplateCore(item, container)
		End Function
	End Class

	Public Class DayOfWeekTemplateSelector
		Inherits DataTemplateSelector
		Protected Overrides Function SelectTemplateCore(item As Object, container As DependencyObject) As DataTemplate
			Dim slot As DayOfWeekSlot = TryCast(item, DayOfWeekSlot)
			If slot IsNot Nothing AndAlso slot.DayOfWeek = DayOfWeek.Saturday Then
            ' set color for Saturday
            DirectCast(container, Control).Foreground = New SolidColorBrush(Windows.UI.Color.FromArgb(255, 0, 90, 255))
        End If
			' don't change DataTemplate at all
			Return Nothing
		End Function

	End Class
