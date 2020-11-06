Public Class SunburstDataLayer
    Inherits Bindable
    Private _bindingX As String
    Private _binding As String
    Private _itemsSource As List(Of DataItem)
    Private _customPalette As IList(Of Brush)
    Private _previousItem As Object
    Private _histories As New Stack()

    Public Sub New(dataSource As List(Of DataItem))
        ItemsSource = dataSource
    End Sub

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

    Public Property ItemsSource() As List(Of DataItem)
        Get
            Return _itemsSource
        End Get
        Set
            SetProperty(_itemsSource, Value, "ItemsSource")
        End Set
    End Property

    Public Property CustomPalette() As IList(Of Brush)
        Get
            Return _customPalette
        End Get
        Set
            SetProperty(_customPalette, Value, "CustomPalette")
        End Set
    End Property

    Public ReadOnly Property CanBack() As Boolean
        Get
            Return (_histories.Count > 0)
        End Get
    End Property

    Private Function GetRootIndexFromItem(item As DataItem) As Integer
        Dim len = ItemsSource.Count
        Dim index = -1
        For i As Integer = 0 To len - 1
            If Contains(ItemsSource(i), item) Then
                index = i
            End If
        Next
        Return index
    End Function

    Private Function Contains(sourceItem As DataItem, targetItem As DataItem) As Boolean
        Dim result As Boolean = False
        If sourceItem.Equals(targetItem) Then
            result = True
        Else
            For Each item As DataItem In sourceItem.Items
                If Contains(item, targetItem) Then
                    result = True
                    Exit For
                End If
            Next
        End If
        Return result
    End Function

    Public Sub DrillDown(item As Object)
        Dim dataItem As DataItem = TryCast(item, DataItem)
        Dim index = GetRootIndexFromItem(dataItem)
        If dataItem IsNot Nothing AndAlso dataItem.Items.Count <> 0 AndAlso _previousItem IsNot item Then
            _previousItem = item
            _histories.Push(BindingX)
            _histories.Push(ItemsSource)
            _histories.Push(CustomPalette)
            If index <> -1 Then
                CustomPalette = New List(Of Brush)() From {
                    CustomPalette(index)
                }
            End If
            ItemsSource = New List(Of DataItem)() From {
                dataItem
            }
            If Not String.IsNullOrEmpty(dataItem.Month) Then
                BindingX = "Month"
            ElseIf Not String.IsNullOrEmpty(dataItem.Quarter) Then
                BindingX = "Quarter,Month"
            End If
            Notify("CanBack")
        End If
    End Sub

    Public Sub Back()
        If CanBack Then
            CustomPalette = TryCast(_histories.Pop(), IList(Of Brush))
            ItemsSource = TryCast(_histories.Pop(), List(Of DataItem))
            BindingX = TryCast(_histories.Pop(), String)
            _previousItem = Nothing
            Notify("CanBack")
        End If
    End Sub
End Class