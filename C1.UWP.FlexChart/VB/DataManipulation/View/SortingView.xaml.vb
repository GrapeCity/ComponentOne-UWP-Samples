' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class SortingView
    Inherits Page

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AddHandler Me.Loaded, AddressOf Me_Loaded
    End Sub

    Private Sub Me_Loaded(sender As System.Object, e As RoutedEventArgs)
        Me.cbSortBy.SelectedIndex = 0
    End Sub
End Class
