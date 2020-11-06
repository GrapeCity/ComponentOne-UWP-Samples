Imports C1.Xaml.Chart
Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System

' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Partial Public NotInheritable Class Binding
    Inherits Page
    Private npts As Integer = 50
    Private rnd As New Random()
    Private _chartTypes As Dictionary(Of ChartType, String)
    Private _data As List(Of DataItem)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property ChartTypes() As Dictionary(Of ChartType, String)
        Get
            If _chartTypes Is Nothing Then
                _chartTypes = New Dictionary(Of ChartType, String)()
                _chartTypes.Add(ChartType.Line, Strings.Line)
                _chartTypes.Add(ChartType.LineSymbols, Strings.LineSymbols)
                _chartTypes.Add(ChartType.Area, Strings.Area)
            End If
            Return _chartTypes
        End Get
    End Property

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            If _data Is Nothing Then
                _data = New List(Of DataItem)()
                Dim dateStep As Integer = 0
                Dim i As Integer = 0
                While i < npts
                    dateStep = dateStep + 9
                    Dim [date] As DateTime = DateTime.Today.AddDays(dateStep)
                    _data.Add(New DataItem() With {
                        .Downloads = If([date].Month = 4 OrElse [date].Month = 8, CType(Nothing, Nullable(Of Integer)), rnd.[Next](10, 20)),
                        .Sales = If([date].Month = 4 OrElse [date].Month = 8, CType(Nothing, Nullable(Of Integer)), rnd.[Next](0, 10)),
                        .[Date] = [date]
                    })
                    i += 1
                End While
            End If

            Return _data
        End Get
    End Property

    Public ReadOnly Property FlexChartInstance() As C1FlexChart
        Get
            Return flexChart
        End Get
    End Property
End Class

Public Class DataItem
    Public Property Downloads() As Nullable(Of Integer)
    Public Property Sales() As Nullable(Of Integer)
    Public Property [Date]() As DateTime
End Class