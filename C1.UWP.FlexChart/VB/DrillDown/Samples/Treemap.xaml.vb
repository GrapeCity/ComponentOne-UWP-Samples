' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236


Imports C1.Xaml.Chart

Partial Public NotInheritable Class Treemap
    Inherits Page
    Private _vm As DrillDownViewModel
    Public Sub New()
        Me.InitializeComponent()
        _vm = New DrillDownViewModel()
        Me.DataContext = _vm
    End Sub
End Class
