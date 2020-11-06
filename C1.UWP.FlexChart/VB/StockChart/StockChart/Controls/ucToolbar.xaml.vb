Partial Public NotInheritable Class ucToolbar
    Inherits UserControl
    Public Sub New()
        Me.InitializeComponent()
        Me.DataContext = ChartViewModel.Instance

        AddHandler Me.Loaded, AddressOf me_Loaded
    End Sub

    Private Sub me_Loaded(sender As System.Object, e As RoutedEventArgs)
        Me.cmbChartType.SelectedIndex = 0
        Me.cmbMovingAverageType.SelectedIndex = 0
    End Sub

    Private Sub cmbExport_DropDownClosed(sender As Object, e As Object)
        If (ChartViewModel.Instance.ExportCommand IsNot Nothing AndAlso cmbExport.SelectedValue IsNot Nothing) Then

            ChartViewModel.Instance.ExportCommand.Execute(CType(cmbExport.SelectedValue, KeyValuePair(Of String, String)).Value)

            cmbExport.SelectedIndex = -1
        End If
    End Sub
End Class