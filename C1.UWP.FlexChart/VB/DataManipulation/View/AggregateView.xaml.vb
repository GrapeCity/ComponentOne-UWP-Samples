' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Public NotInheritable Class AggregateView
    Inherits Page

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AddHandler Me.Loaded, AddressOf Me_Loaded
    End Sub

    Private Sub Me_Loaded(sender As System.Object, e As RoutedEventArgs)
        Me.cbProperty.SelectedIndex = 0
        Me.cbAggregateType.SelectedIndex = 0
    End Sub


End Class
