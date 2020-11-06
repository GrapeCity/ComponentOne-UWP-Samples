Imports C1.Xaml.Chart
Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports Windows.UI.Xaml
Imports System.Linq
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class LegendAndTitles
    Inherits Page
    Private _data As List(Of GroupDataItem)
    Private _positions As List(Of String)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of GroupDataItem)
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateGroupData()
            End If

            Return _data
        End Get
    End Property

    Public ReadOnly Property Legends() As List(Of String)
        Get
            If _positions Is Nothing Then
                _positions = [Enum].GetNames(GetType(Position)).ToList()
            End If

            Return _positions
        End Get
    End Property

    Public ReadOnly Property FlexChartInstance() As C1FlexChart
        Get
            Return Me.flexChart
        End Get
    End Property

    Private Sub Button_Click(sender As Object, e As Windows.UI.Xaml.RoutedEventArgs)
        If TypeOf sender Is AppBarButton Then
            settings.Visibility = Visibility.Visible
        Else
            settings.Visibility = Visibility.Collapsed
        End If
    End Sub

    Private Sub cbGroup_Checked(sender As Object, e As RoutedEventArgs)
        If cbGroup.IsChecked.HasValue And flexChart IsNot Nothing Then
            For Each ser As ISeries In flexChart.Series
                If cbGroup.IsChecked = False Then
                    ser.LegendGroup = Nothing
                ElseIf ser.Name.IndexOf("Sales") > -1 Then
                    ser.LegendGroup = "Sales"
                Else
                    ser.LegendGroup = "Expenses"
                End If
            Next
        End If
    End Sub
End Class
