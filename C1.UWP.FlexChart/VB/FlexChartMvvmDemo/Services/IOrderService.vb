Imports FlexChartMvvmDemo.Model
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System


Namespace Services
    Public Interface IOrderService
        Sub FetchOrders(list As IList(Of OrderModel))
    End Interface
End Namespace