Imports FlexChartMvvmDemo.Services
Imports FlexChartMvvmDemo.Model
Imports System.Threading.Tasks
Imports System.Text
Imports System.Windows.Input
Imports System.Linq
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System


Namespace ViewModel
    Public Class OrdersViewModel
        Implements INotifyPropertyChanged
        Private _group As String = "Country"
        Private _agg As String = "Sum"
        Private _selectedIndex As Integer = -1

        Public Sub New()
            Orders = New ObservableCollection(Of OrderModel)()

            OrderService = New OrderService()
            UpdateOrders()
        End Sub

        Public Property Orders() As ObservableCollection(Of OrderModel)

        Public Property OrderService() As IOrderService

        Public Property Group() As String
            Get
                Return _group
            End Get
            Set
                _group = Value
                UpdateOrders()
                OnPropertyChanged("Group")
            End Set
        End Property

        Public ReadOnly Property Groups() As String()
            Get
                Return "Country,Category,Year".Split(","c)
            End Get
        End Property

        Public Property Aggregate() As String
            Get
                Return _agg
            End Get
            Set
                _agg = Value
                UpdateOrders()
                OnPropertyChanged("Aggregate")
            End Set
        End Property

        Public ReadOnly Property Aggregates() As String()
            Get
                Return "Sum,Count,Average".Split(","c)
            End Get
        End Property

        Public Property SelectedIndex() As Integer
            Get
                Return _selectedIndex
            End Get
            Set
                _selectedIndex = Value
                OnPropertyChanged("SelectedIndex")
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

        Private Sub UpdateOrders()
            Dim list As New List(Of OrderModel)()
            OrderService.FetchOrders(list)

            Dim g As IEnumerable(Of OrderModel) = list.GroupBy(AddressOf Selector).[Select](Function(go) New OrderModel() With {
                .Country = If(Group = "Country", go.First().Country, Nothing),
                .Category = If(Group = "Category", go.First().Category, Nothing),
                .Year = If(Group = "Year", go.First().[Date].Year.ToString(), Nothing),
                .Amount = Aggregator(go)
            })

            Orders.Clear()
            For Each o As OrderModel In g
                Orders.Add(o)
            Next
        End Sub

        Function Aggregator(group As IGrouping(Of String, OrderModel)) As Double
            Dim total As Double = 0.0
            If Aggregate = "Sum" Then
                total = group.Sum(Function(o) o.Amount)
            ElseIf Aggregate = "Count" Then
                total = group.Count()
            ElseIf Aggregate = "Average" Then
                total = group.Average(Function(o) o.Amount)
            End If

            Return total
        End Function

        Function Selector(order As OrderModel) As String
            Dim s As String = Nothing
            If Group = "Category" Then
                s = order.Category
            ElseIf Group = "Country" Then
                s = order.Country
            ElseIf Group = "Year" Then
                s = order.[Date].Year.ToString()
            End If
            Return s
        End Function
    End Class
End Namespace