

Imports System.Collections.Generic
Imports C1.Chart

Class SortingViewModel
    Inherits ViewModelBase(Of SortingFilter)

    Shared r As New Random()
    Public Sub New()
        Filter.Bindings = New String() {"PredictiveValue"}
        Filter.AggregateType = AggregateType.Sum
        Dim sis As New Queue(Of SortingItem)()

        sis.Enqueue(New SortingItem() With {
            .Name = "Mechanical",
            .PredictiveValue = 230,
            .ActualValue = 226
        })
        sis.Enqueue(New SortingItem() With {
            .Name = "3C",
            .PredictiveValue = 960,
            .ActualValue = 870
        })
        sis.Enqueue(New SortingItem() With {
            .Name = "Medicinal",
            .PredictiveValue = 520,
            .ActualValue = 500
        })
        sis.Enqueue(New SortingItem() With {
            .Name = "Appliances",
            .PredictiveValue = 370,
            .ActualValue = 300
        })
        sis.Enqueue(New SortingItem() With {
            .Name = "Software",
            .PredictiveValue = 320,
            .ActualValue = 120
        })
        sis.Enqueue(New SortingItem() With {
            .Name = "Cosmetic",
            .PredictiveValue = 780,
            .ActualValue = 700
        })
        Me.Source = sis
    End Sub

    Public Overrides Property Filter() As SortingFilter
        Get
            Return MyBase.Filter
        End Get
        Set
            MyBase.Filter = Value
        End Set
    End Property

#Region "Selection Data"

    Private _sortBySource As Dictionary(Of String, String)
    Public ReadOnly Property SortBySource() As Dictionary(Of String, String)
        Get
            If _sortBySource Is Nothing Then
                _sortBySource = New Dictionary(Of String, String)
                _sortBySource.Add("None", "none")
                _sortBySource.Add("Descending by PredictiveValue", "dbp")
                _sortBySource.Add("Ascending by PredictiveValue", "abp")
                _sortBySource.Add("Descending by ActualValue", "dba")
                _sortBySource.Add("Ascending by ActualValue", "aba")
                _sortBySource.Add("Descending by Difference", "dbd")
                _sortBySource.Add("Ascending by Difference", "abd")
            End If
            Return _sortBySource
        End Get
    End Property

#End Region

    Private _sortBy As String = "none"
    Public Property SortBy() As String
        Get
            Return _sortBy
        End Get
        Set
            _sortBy = Value

            Select Case _sortBy
                Case "dba"
                    Filter.Bindings = New String() {"ActualValue"}
                    Filter.AggregateType = AggregateType.Sum
                    Filter.CustomSortFun = Nothing
                    Filter.SortType = SortType.Descending
                    Exit Select
                Case "aba"
                    Filter.Bindings = New String() {"ActualValue"}
                    Filter.AggregateType = AggregateType.Sum
                    Filter.CustomSortFun = Nothing
                    Filter.SortType = SortType.Ascending
                    Exit Select
                Case "dbp"
                    Filter.Bindings = New String() {"PredictiveValue"}
                    Filter.AggregateType = AggregateType.Sum
                    Filter.CustomSortFun = Nothing
                    Filter.SortType = SortType.Descending
                    Exit Select
                Case "abp"
                    Filter.Bindings = New String() {"PredictiveValue"}
                    Filter.AggregateType = AggregateType.Sum
                    Filter.CustomSortFun = Nothing
                    Filter.SortType = SortType.Ascending
                    Exit Select
                Case "dbd"
                    Filter.Bindings = New String() {"PredictiveValue", "ActualValue"}
                    Filter.CustomSortFun = Function(k) k.First() - k.Last()
                    Filter.SortType = SortType.Descending
                    Exit Select
                Case "abd"
                    Filter.Bindings = New String() {"PredictiveValue", "ActualValue"}
                    Filter.CustomSortFun = Function(k) k.First() - k.Last()
                    Filter.SortType = SortType.Ascending
                    Exit Select
                Case "none"
                    Filter.Bindings = New String() {"PredictiveValue"}
                    Filter.SortType = SortType.None
                    Filter.CustomSortFun = Nothing
                    Exit Select
                Case Else
                    Filter.Bindings = New String() {"PredictiveValue"}
                    Filter.SortType = SortType.None
                    Filter.CustomSortFun = Nothing
                    Exit Select
            End Select
        End Set
    End Property

End Class