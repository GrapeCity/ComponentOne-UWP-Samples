


Imports C1.Xaml.Chart

Partial Public NotInheritable Class Sunburst
    Inherits Page
    Private _vm As DrillDownViewModel
    Public Sub New()
        Me.InitializeComponent()
        _vm = New DrillDownViewModel()
        Me.DataContext = _vm
    End Sub


End Class
