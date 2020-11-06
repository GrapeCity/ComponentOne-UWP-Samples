Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class HeaderAndFooter
    Inherits Page
    Private _data As List(Of DataItem)
    Private rnd As New Random()
    Private year As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            If _data Is Nothing Then
                _data = New List(Of DataItem)()
                Dim count As Integer = year.Length
                Dim i As Integer = 0
                While i < count - 1
                    _data.Add(New DataItem() With {
                        .Amount = rnd.[Next](0, 1000),
                        .Month = year(i)
                    })
                    i += 1
                End While
            End If

            Return _data
        End Get
    End Property

    Public Class DataItem
        Public Property Amount() As Integer
        Public Property Month() As String
    End Class

End Class