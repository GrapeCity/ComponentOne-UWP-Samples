Imports C1.Chart

Public Class TopNViewModel
    Inherits ViewModelBase(Of TopNFilter)
    Public Sub New()
        Filter.Bindings = New String() {"Shipments"}
        Filter.AggregateType = AggregateType.Sum
        Filter.SortType = SortType.Descending
        Filter.SortOrder = True

        Dim vendors As New Queue(Of SmartPhoneVendor)()
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "Alcatel",
        .Shipments = 34.1
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "Apple",
        .Shipments = 215.2
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "Huawei",
        .Shipments = 139
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "Lenovo",
        .Shipments = 50.7
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "LG",
        .Shipments = 55.1
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "Oppo",
        .Shipments = 92.5
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "Samsung",
        .Shipments = 310.3
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "Vivo",
        .Shipments = 71.7
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "Xiaomi",
        .Shipments = 61
        })
        vendors.Enqueue(New SmartPhoneVendor() With {
        .Name = "ZTE",
        .Shipments = 61.9
        })

        Me.Source = vendors
    End Sub

    Public Overrides Property Filter() As TopNFilter
        Get
            Return MyBase.Filter
        End Get

        Set
            MyBase.Filter = Value
        End Set
    End Property

#Region "Selection Data"
    Private _topNCounts As Dictionary(Of String, Integer)
    Public ReadOnly Property TopNCounts() As Dictionary(Of String, Integer)
        Get
            If _topNCounts Is Nothing Then
                _topNCounts = New Dictionary(Of String, Integer)()
                _topNCounts.Add("Show all", -1)
                For i As Integer = 0 To 8
                    _topNCounts.Add("Top: " + (i + 1).ToString(), i + 1)
                Next
            End If
            Return _topNCounts
        End Get
    End Property

    Private _sortTypes As Dictionary(Of String, SortType)
    Public ReadOnly Property SortTypes() As Dictionary(Of String, SortType)
        Get
            If _sortTypes Is Nothing Then
                _sortTypes = New Dictionary(Of String, SortType)()
                For Each item As Object In [Enum].GetValues(GetType(SortType))
                    _sortTypes.Add("Sort Type: " + DirectCast(item, SortType).ToString(), DirectCast(item, SortType))
                Next
            End If
            Return _sortTypes
        End Get
    End Property
#End Region
    Public Property TopNCount() As Integer
        Get
            Return Filter.TopNCount
        End Get
        Set
            Filter.TopNCount = Value
            Filter.Analyse()
        End Set
    End Property
    Public Property ShowOthers() As Boolean
        Get
            Return Filter.ShowOthers
        End Get
        Set
            Filter.ShowOthers = Value
            Filter.Analyse()
        End Set
    End Property
End Class