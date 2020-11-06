Imports FlexChartMvvmDemo.Model
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Namespace Services
    Public Class OrderService
        Implements IOrderService
        Private _list As List(Of OrderModel)

        Public Sub FetchOrders(list As IList(Of OrderModel)) Implements IOrderService.FetchOrders
            If _list Is Nothing Then
                _list = New List(Of OrderModel)()
                Dim i As Integer = 0
                While i < 200
                    _list.Add(GenerateOrder(i + 1))
                    i += 1
                End While
            End If
            For Each o As OrderModel In _list
                list.Add(o)
            Next
        End Sub

        Private rnd As New Random()

        Private Function GenerateOrder(i As Integer) As OrderModel
            Dim countries As String() = "France,Spain,UK,USA".Split(","c)
            Dim categories As String() = "Electronics,Audio,Video".Split(","c)

            Return New OrderModel() With {
                .ID = i,
                .[Date] = New DateTime(2014, 1, 1).AddDays(i * 5),
                .Country = countries(rnd.[Next](countries.Length)),
                .Category = categories(rnd.[Next](categories.Length)),
                .Amount = rnd.[Next](1000)
            }
        End Function
    End Class
End Namespace