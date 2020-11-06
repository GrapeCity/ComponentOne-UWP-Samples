Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Chart

Public Class FlexRadarViewModel
    Private n As Integer = 6
    Private rnd As New Random()
    Private _pts1 As List(Of DataItem)
    Private _pts2 As List(Of DataItem)

    Public ReadOnly Property Points1() As List(Of DataItem)
        Get
            If _pts1 Is Nothing Then
                _pts1 = New List(Of DataItem)()
                Dim i As Object = 0
                While i < n
                    _pts1.Add(New DataItem() With {
                        .Name = "Item" + i.ToString(),
                        .Value = rnd.[Next](100)
                    })
                    i += 1
                End While
            End If

            Return _pts1
        End Get
    End Property

    Public ReadOnly Property Points2() As List(Of DataItem)
        Get
            If _pts2 Is Nothing Then
                _pts2 = New List(Of DataItem)()
                Dim i As Object = 0
                While i < n
                    _pts2.Add(New DataItem() With {
                        .Name = "Item" + i.ToString(),
                        .Value = rnd.[Next](50)
                    })
                    i += 1
                End While
            End If

            Return _pts2
        End Get
    End Property

    Public ReadOnly Property ChartTypes() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(RadarChartType)).ToList()
        End Get
    End Property

    Public ReadOnly Property Stackings() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(Stacking)).ToList()
        End Get
    End Property

    Public ReadOnly Property Palettes() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(Palette)).ToList()
        End Get
    End Property
End Class