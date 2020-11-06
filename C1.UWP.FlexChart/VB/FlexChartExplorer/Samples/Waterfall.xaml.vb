' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class Waterfall
    Inherits Page

    Dim _data As List(Of WaterfallItem)

    Public Sub New()
        InitializeComponent()
        AddHandler Me.Loaded, AddressOf OnLoaded
    End Sub

    Public Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        'wf.Start = 100
        wf.IntermediateTotalPositions = New List(Of Integer) From {3, 6, 9, 12}
    End Sub

    Public ReadOnly Property Data As List(Of WaterfallItem)
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateWaterfallData()
            End If
            Return _data
        End Get
    End Property
End Class
