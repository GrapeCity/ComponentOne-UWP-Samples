' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

Imports C1.Chart
Imports C1.Xaml.Chart
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class TopNView
    Inherits Page

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        AddHandler Me.Loaded, AddressOf Me_Loaded
    End Sub

    Private Sub Me_Loaded(sender As System.Object, e As RoutedEventArgs)
        Me.cbTopNCount.SelectedIndex = 0
    End Sub

    Private Sub flexChart1_SeriesVisibilityChanged(sender As Object, e As C1.Xaml.Chart.SeriesEventArgs)
        Dim bindings As Queue(Of String) = New Queue(Of String)
        For Each s As Series In flexChart1.Series

            If (s.Visibility = SeriesVisibility.Visible) Then
                bindings.Enqueue(s.Binding)
            End If
        Next
        topNViewModel.Bindings = bindings.ToArray()
    End Sub
End Class
