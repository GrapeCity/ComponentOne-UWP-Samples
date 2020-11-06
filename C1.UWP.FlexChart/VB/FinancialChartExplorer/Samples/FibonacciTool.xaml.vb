' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

Imports System.Collections.Generic
Imports C1.Chart
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class FibonacciTool
    Inherits Page
    Private dataService As DataService = DataService.GetService()

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            Return dataService.GetSymbolData("box", 87)
        End Get
    End Property

    Public ReadOnly Property FibonacciTypes() As List(Of String)
        Get
            Return Strings.FibonacciTypes.Split(","c).ToList()
        End Get
    End Property

    Public ReadOnly Property Uptrends() As List(Of String)
        Get
            Return New List(Of String)() From {Boolean.TrueString, Boolean.FalseString}
        End Get
    End Property

    Public ReadOnly Property Positions() As List(Of String)
        Get
            Return Strings.Positions.Split(","c).ToList()
        End Get
    End Property

    Public ReadOnly Property VerticalPositions() As List(Of String)
        Get
            Return Strings.VerticalPositions.Split(","c).ToList()
        End Get
    End Property

    Public ReadOnly Property TimeZonesPositions() As List(Of String)
        Get
            Return Strings.TimeZonesPositions.Split(","c).ToList()
        End Get
    End Property

    Private Sub OnSplitterButtonClick(sender As Object, e As RoutedEventArgs)
        If splitter IsNot Nothing Then
            splitter.IsPaneOpen = Not splitter.IsPaneOpen
        End If
    End Sub

    Private Sub FibonacciTool_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        cbFibonacciTypes.SelectedIndex = 2
    End Sub

    Private Sub cbRangeSelector_Checked(sender As Object, e As RoutedEventArgs)
        If rangeSelector IsNot Nothing Then
            rangeSelector.Visibility = Visibility.Visible
        End If
    End Sub

    Private Sub cbRangeSelector_Unchecked(sender As Object, e As RoutedEventArgs)
        If rangeSelector IsNot Nothing Then
            rangeSelector.Visibility = Visibility.Collapsed
        End If
    End Sub

    Private Sub C1RangeSelector_ValueChanged(sender As Object, e As EventArgs)
        If fibonacci IsNot Nothing Then
            financialChart.BeginUpdate()
            fibonacci.MinX = rangeSelector.LowerValue
            fibonacci.MaxX = rangeSelector.UpperValue
            financialChart.EndUpdate()
        End If
    End Sub

    Private Sub cbFibonacciTypes_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim selectedIndex As Integer = cbFibonacciTypes.SelectedIndex
        If selectedIndex = -1 Then
            Return
        End If

        rangeSelector.Visibility = Visibility.Collapsed
        For Each ser As ISeries In financialChart.Series
            If ser Is fs Then
                Continue For
            End If
            ser.Visibility = SeriesVisibility.Hidden
        Next

        If selectedIndex = 0 Then
            arc.Visibility = SeriesVisibility.Visible
        ElseIf selectedIndex = 1 Then
            fans.Visibility = SeriesVisibility.Visible
        ElseIf selectedIndex = 2 Then
            fibonacci.Visibility = SeriesVisibility.Visible
            If cbRangeSelector.IsChecked.Value Then
                rangeSelector.Visibility = Visibility.Visible
            End If
        ElseIf selectedIndex = 3 Then
            timeZones.Visibility = SeriesVisibility.Visible
        End If
    End Sub
End Class
