Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class AnnotationViewModel
    Private _data As List(Of DataItem)
    Private _financialData As List(Of FinancialItem)
    Private rnd As New Random()

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            If _data Is Nothing Then
                _data = New List(Of DataItem)()
                Dim i As Integer = 1
                While i < 51
                    _data.Add(New DataItem() With {
                        .X = i,
                        .Y = rnd.[Next](10, 80)
                    })
                    i += 1
                End While
            End If

            Return _data
        End Get
    End Property

    Public ReadOnly Property FinancialData() As List(Of FinancialItem)
        Get
            If _financialData Is Nothing Then
                _financialData = New List(Of FinancialItem)()
                Dim current As New DateTime(DateTime.Now.Year, 1, 1)
                Dim j As Integer = 10, k As Integer = 30
                While k <= 110
                    Dim i As Integer = 1
                    While i < 20
                        current = current.AddDays(1)
                        Dim item As New FinancialItem() With {
                            .[Date] = current,
                            .Close = rnd.[Next](j, k) + Math.Round(rnd.NextDouble(), 2),
                            .Volume = rnd.[Next](0, 10)
                        }
                        item.Hight = item.Close + Math.Round(rnd.NextDouble(), 2)
                        item.Low = item.Close - Math.Round(rnd.NextDouble(), 2)
                        item.Open = If(rnd.[Next](100) Mod 2 = 0, item.Close - rnd.[Next](2) - Math.Round(rnd.NextDouble(), 2), item.Close + rnd.[Next](2) + Math.Round(rnd.NextDouble(), 2))

                        _financialData.Add(item)
                        i += 1
                    End While
                    j += 20
                    k += 20
                End While
            End If

            Return _financialData
        End Get
    End Property
End Class