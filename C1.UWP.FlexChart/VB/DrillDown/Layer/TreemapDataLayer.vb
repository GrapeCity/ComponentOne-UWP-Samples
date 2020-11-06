Public Class TreemapDataLayer
    Inherits Bindable
    Private _itemsSource As Leaf()
    Private _depth As Integer = 0

    Private _histories As New ObservableCollection(Of KeyValuePair(Of String, Leaf()))()

    Public Sub New(dataSource As Leaf())
        ItemsSource = dataSource
        AddHandler _histories.CollectionChanged, AddressOf _histories_CollectionChanged
        _histories.Add(New KeyValuePair(Of String, Leaf())("All Types", dataSource))

        Dim actionBack As Action(Of String) = Sub(s As String)
                                                  Back(s)
                                              End Sub
        BackCommand = New RelayCommand(actionBack)
    End Sub

    Private Sub _histories_CollectionChanged(sender As Object, e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
        Notify("CurrentType")
    End Sub

    Public Property ItemsSource() As Leaf()
        Get
            Return _itemsSource
        End Get
        Set
            SetProperty(_itemsSource, Value, "ItemsSource")
        End Set
    End Property

    Public Property Depth() As Integer
        Get
            Return _depth
        End Get
        Set
            SetProperty(_depth, Value, "Depth")
        End Set
    End Property

    Public Property Histories() As ObservableCollection(Of KeyValuePair(Of String, Leaf()))
        Get
            Return _histories
        End Get
        Set
            SetProperty(_histories, Value, "Histories")
        End Set
    End Property

    Public ReadOnly Property CurrentType() As String
        Get
            Return Histories.Last().Key
        End Get
    End Property

    Public Property BackCommand() As RelayCommand
        Get
            Return m_BackCommand
        End Get
        Set
            m_BackCommand = Value
        End Set
    End Property
    Private m_BackCommand As RelayCommand

    Public Overridable Sub Back(obj As Object)
        Dim idx = Integer.Parse(obj.ToString())
        For i As Integer = _histories.Count() - 1 To idx + 1 Step -1
            Histories.RemoveAt(i)
        Next
        Depth = idx
        ItemsSource = _histories.Last().Value
    End Sub

    Public Sub DrillDown(item As Object)
        Dim dataItem As Leaf = TryCast(item, Leaf)
        If dataItem IsNot Nothing AndAlso dataItem.Items IsNot Nothing AndAlso dataItem.Items.Count() > 0 Then
            Histories.Add(New KeyValuePair(Of String, Leaf())(dataItem.Type, dataItem.Items))
            ItemsSource = dataItem.Items
            Depth += 1
        End If
    End Sub
End Class
