' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

Imports C1.Chart
Imports C1.Xaml.Chart
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>

Partial Public Class ColumnPie
    Inherits Page
    Private _vm As DrillDownViewModel
    Public Sub New()
        InitializeComponent()
        _vm = New DrillDownViewModel()
        Me.DataContext = _vm

        AddHandler Me.Loaded, AddressOf me_Loaded

        AddHandler Me.barChart.Tapped, AddressOf Chart_Tapped
        AddHandler Me.pieChart.Tapped, AddressOf Chart_Tapped
    End Sub

    Function me_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        cbAggregate.SelectedIndex = 0
        cbChartTypes.SelectedIndex = 0
    End Function

    Private Sub Chart_Tapped(sender As Object, e As TappedRoutedEventArgs)
        Dim flexChart = TryCast(sender, FlexChartBase)
        Dim hitInfo = flexChart.HitTest(e.GetPosition(flexChart))
        If hitInfo IsNot Nothing AndAlso hitInfo.Distance < 2 Then
            _vm.DataLayer.DrillDown(hitInfo.PointIndex)
        End If
    End Sub

End Class
