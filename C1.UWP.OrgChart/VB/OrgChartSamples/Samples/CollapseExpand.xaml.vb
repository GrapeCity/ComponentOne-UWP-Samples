Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.OrgChart

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class CollapseExpand
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        CreateData()
    End Sub

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property is typically used to configure the page.</param>
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
    End Sub
    ' toggle OrgChart orientation when user clicks the checkbox on the main page
    Sub CheckBox_Click(sender As Object, e As RoutedEventArgs)
        _orgChart.Orientation = If((CType(sender, CheckBox)).IsChecked.Value, Orientation.Horizontal, Orientation.Vertical)
    End Sub

    ' rebuild the chart using new random data
    Sub Button_Refresh_Click(sender As Object, e As RoutedEventArgs)
        CreateData()
        SetToggleButtonState(_orgChart, _orgChart.IsCollapsed)
    End Sub

    ' collapse the chart to level 2, if Phone to level 1 
    Sub Button_Collapse_Click(sender As Object, e As RoutedEventArgs)
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            ToggleCollapseExpand(_orgChart, 0, 1)
        Else
            ToggleCollapseExpand(_orgChart, 0, 2)
        End If

    End Sub


    ' collapse the chart to a given level
    Sub ToggleCollapseExpand(node As C1OrgChart, level As Integer, maxLevel As Integer)
        'ToggleButton button = null;
        If level >= maxLevel Then
            node.IsCollapsed = True
            ' Get ToggleButton and set its IsCheced property to true.
            SetToggleButtonState(node, True)
        Else
            node.IsCollapsed = False
            SetToggleButtonState(node, False)
            For Each subNode As C1OrgChart In node.ChildNodes
                ToggleCollapseExpand(subNode, level + 1, maxLevel)
            Next
        End If
    End Sub

    ' create some random data and assign it to the chart
    Sub CreateData()
        Dim p As Person
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            p = Person.CreatePerson(3)
        Else
            p = Person.CreatePerson(5)
            _tbTotal.Text = String.Format(Strings.TotalItem, p.TotalCount)
        End If
        _orgChart.Header = p
    End Sub


    ''' <summary>
    ''' Get ToggleButton from orgChart and set its IsChecked property to isChecked;
    ''' </summary>
    Private Sub SetToggleButtonState(chart As DependencyObject, isChecked As Boolean)
        Dim button As ToggleButton = Nothing
        Dim count As Integer = VisualTreeHelper.GetChildrenCount(chart)
        Dim index As Integer = 0
        While index < count
            Dim child As DependencyObject = VisualTreeHelper.GetChild(chart, index)
            If TypeOf child Is ToggleButton Then
                button = CType(child, ToggleButton)
                button.IsChecked = isChecked
            Else
                SetToggleButtonState(child, isChecked)
            End If
            index += 1
        End While
    End Sub

    Private Sub CheckedChanged(sender As Object)
        Dim toggleButton As ToggleButton = TryCast(sender, ToggleButton)
        Dim parent As FrameworkElement = TryCast(VisualTreeHelper.GetParent(toggleButton), FrameworkElement)
        While parent IsNot Nothing AndAlso Not (TypeOf parent Is C1OrgChart)
            parent = TryCast(VisualTreeHelper.GetParent(parent), FrameworkElement)
        End While
        If parent IsNot Nothing Then
            Dim orgChart As C1OrgChart = TryCast(parent, C1OrgChart)
            If toggleButton.IsChecked IsNot Nothing Then
                orgChart.IsCollapsed = toggleButton.IsChecked.Value
            End If
        End If
    End Sub

    Private Sub ToggleButton_Click(sender As Object, e As RoutedEventArgs)
        CheckedChanged(sender)
    End Sub

End Class