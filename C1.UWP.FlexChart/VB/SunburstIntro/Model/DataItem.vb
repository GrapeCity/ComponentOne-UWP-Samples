Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class DataItem
    Private _items As List(Of DataItem)

    Public Property Year() As String
    Public Property Quarter() As String
    Public Property Month() As String
    Public Property Value() As Double
    Public ReadOnly Property Items() As List(Of DataItem)
        Get
            If _items Is Nothing Then
                _items = New List(Of DataItem)()
            End If

            Return _items
        End Get
    End Property
End Class

Public Class FlatDataItem
    Public Property Year() As String
    Public Property Quarter() As String
    Public Property Month() As String
    Public Property Value() As Double
End Class

Public Class Item
    Public Property Year() As Integer
    Public Property Quarter() As String
    Public Property MonthName() As String
    Public Property MonthValue() As Integer
    Public Property Value() As Double
End Class