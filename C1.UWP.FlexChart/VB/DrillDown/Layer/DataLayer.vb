Imports System.Dynamic
Imports C1.Xaml

Public Class DataLayer
    Inherits Bindable
    Private _depth As Integer = 0
    Private _bindingX As String
    Private _binding As String
    Private _groupBy As String
    Private _current As Object
    Private _parent As Object
    Private _itemsSource As IEnumerable
    Private _view As C1CollectionView
    Private _chartView As List(Of Object)
    Private _aggType As AggregateType = AggregateType.Sum
    Private _histories As New Dictionary(Of String, List(Of Object))()

    Public Sub New(dataSource As IEnumerable)
        _view = New C1CollectionView(dataSource)
        Dim actionBack As Action(Of String) = Sub(s As String)
                                                  Back(s)
                                              End Sub
        BackCommand = New RelayCommand(actionBack)
    End Sub

    Public Property Depth() As Integer
        Get
            Return _depth
        End Get
        Set
            SetProperty(_depth, Value, "Depth")
        End Set
    End Property

    Public Property GroupBy() As String
        Get
            Return _groupBy
        End Get
        Set
            If _groupBy <> Value Then
                _groupBy = Value
                _view.GroupDescriptions.Clear()
                _histories.Clear()
                For Each groupName As String In GroupNames
                    _view.GroupDescriptions.Add(New PropertyGroupDescription(groupName))
                    _histories.Add(groupName, Nothing)
                Next
                Depth = 0
                ChartView = _view.CollectionGroups.ToList()
                Parent = InlineAssignHelper(Current, Nothing)
                Notify("GroupNames")
            End If
        End Set
    End Property

    Public Property Binding() As String
        Get
            Return _binding
        End Get
        Set
            SetProperty(_binding, Value, "Binding")
        End Set
    End Property

    Public Property BindingX() As String
        Get
            Return _bindingX
        End Get
        Set
            SetProperty(_bindingX, Value, "BindingX")
        End Set
    End Property

    Public Property AggregateType() As AggregateType
        Get
            Return _aggType
        End Get
        Set
            _aggType = Value
            UpdateChartItemsSource()
        End Set
    End Property

    Public Property Current() As Object
        Get
            Return _current
        End Get
        Set
            SetProperty(_current, Value, "Current")
        End Set
    End Property

    Public Property Parent() As Object
        Get
            Return _parent
        End Get
        Set
            SetProperty(_parent, Value, "Parent")
        End Set
    End Property

    Public Property ItemsSource() As IEnumerable
        Get
            Return _itemsSource
        End Get
        Set
            SetProperty(_itemsSource, Value, "ItemsSource")
        End Set
    End Property

    Friend Property ChartView() As List(Of Object)
        Get
            Return _chartView
        End Get
        Set
            _chartView = Value
            OnChartViewChanged()
        End Set
    End Property

    Public ReadOnly Property GroupNames() As List(Of String)
        Get
            Return GroupBy.Split(",").ToList()
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


    Private Function Aggregate(item As Object, type As AggregateType) As Double
        Dim group As CollectionViewGroup = TryCast(item, CollectionViewGroup)
        If group IsNot Nothing Then

            Dim sum__1 = group.GroupItems.Sum(Function(p) Aggregate(p, AggregateType.Sum))
            Dim sum2 = Sum(item)
            Dim cnt = group.ItemCount
            Dim avg = sum__1 / cnt
            Select Case type
                Case AggregateType.Avg
                    Return Math.Floor(avg)
                Case AggregateType.Max
                    Return group.GroupItems.Max(Function([sub]) Aggregate([sub], type))
                Case AggregateType.Min
                    Return group.GroupItems.Min(Function([sub]) Aggregate([sub], type))
                Case AggregateType.Rng
                    Return group.GroupItems.Max(Function([sub]) Aggregate([sub], AggregateType.Max)) - group.GroupItems.Min(Function([sub]) Aggregate([sub], AggregateType.Min))
                Case AggregateType.Cnt
                    Return cnt
                Case AggregateType.Std
                    Return Math.Floor(Math.Sqrt((sum2 / cnt - avg * avg) * cnt / (cnt - 1)))
                Case AggregateType.Var
                    Return Math.Floor((sum2 / cnt - avg * avg) * cnt / (cnt - 1))
                Case AggregateType.StdPop
                    Return Math.Floor(Math.Sqrt(sum2 / cnt - avg * avg))
                Case AggregateType.VarPop
                    Return Math.Floor(sum2 / cnt - avg * avg)
                Case AggregateType.Sum
                    Return sum__1
                Case Else
                    Return sum__1
            End Select
        Else
            Return TryCast(item, Item).Amount
        End If
    End Function


    Private Function Sum(item As Object) As Double
        Dim group As CollectionViewGroup = TryCast(item, CollectionViewGroup)
        If group IsNot Nothing Then
            Return group.GroupItems.Sum(Function(p) Sum(p))
        Else
            Dim amount = TryCast(item, Item).Amount
            Return amount * amount
        End If
    End Function

    Private Sub OnChartViewChanged()
        _histories(GroupNames(Depth)) = ChartView
        UpdateChartItemsSource()
    End Sub

    Private Sub UpdateChartItemsSource()
        Dim groups As New List(Of Object)()
        Dim groupName = GroupNames(Depth)
        For Each item As CollectionViewGroup In ChartView
            Dim groupItem As ExpandoObject = New ExpandoObject()
            Dim dt As IDictionary(Of String, Object) = TryCast(groupItem, IDictionary(Of String, Object))
            Dim gItem As CollectionViewGroup = TryCast(item, CollectionViewGroup)
            dt(groupName) = gItem.Group
            dt("Value") = Aggregate(item, AggregateType)
            groups.Add(groupItem)
        Next
        BindingX = groupName
        ItemsSource = groups
    End Sub

    Public Overridable Sub DrillDown(index As Integer)
        If Depth >= GroupNames.Count - 1 Then
            Return
        End If
        Depth += 1
        Dim selectedGroup As CollectionViewGroup = TryCast(ChartView(index), CollectionViewGroup)
        Parent = Current
        Current = selectedGroup
        ChartView = selectedGroup.GroupItems.ToList()
    End Sub

    Public Overridable Sub Back(chartViewPath As String)
        If _histories.Keys.Contains(chartViewPath) Then
            Depth = GroupNames.IndexOf(chartViewPath)
            ChartView = _histories(chartViewPath)
        End If
    End Sub
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class