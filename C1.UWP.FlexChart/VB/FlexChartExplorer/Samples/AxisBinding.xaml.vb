Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class AxisBinding
    Inherits Page
    Dim _data As List(Of Quote)
    Dim _axisBindingItems As List(Of AxisBindingItem)
    Dim npts As Integer = 30
    Dim rnd As Random = New Random()

    Public Sub New()
        Me.InitializeComponent()
        Me.flexChart.AxisY.ItemsSource = AxisData
    End Sub

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            If _data Is Nothing Then
                _data = CreateData()
            End If

            Return _data
        End Get
    End Property

    Public ReadOnly Property AxisData() As List(Of AxisBindingItem)
        Get
            If _axisBindingItems Is Nothing Then
                _axisBindingItems = CreateAxisData()
            End If

            Return _axisBindingItems
        End Get
    End Property

    Function CreateAxisData() As List(Of AxisBindingItem)
        Dim list As New List(Of AxisBindingItem)()
        For i As Integer = 0 To 19
            list.Add(New AxisBindingItem() With {
                    .Value = 500 + i * 50,
                    .Text = String.Format("$ {0:n0}", 500 + i * 50)
                })
        Next

        Return list
    End Function
    Function CreateData() As List(Of Quote)
        Dim list As New List(Of Quote)()
        Dim dt As DateTime = DateTime.Today
        Dim price As Double = 1000
        For i As Integer = 0 To npts - 1
            price += If(rnd.[Next](10) Mod 2 = 0, rnd.[Next](50), -rnd.[Next](50))
            list.Add(New Quote() With {
                .Time = dt.AddDays(i),
                .Price = price
            })
        Next

        Return list
    End Function

    Public Class Quote

        Public Property Time() As DateTime
        Public Property Price() As Double
    End Class

    Public Class AxisBindingItem
        Public Property Value() As Double
        Public Property Text() As String
    End Class
End Class