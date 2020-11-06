' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Public NotInheritable Class ucTitlebar
    Inherits UserControl
    Public Sub New()
        Me.InitializeComponent()
        Me.DataContext = ChartViewModel.Instance
    End Sub
End Class
