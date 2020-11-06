Imports C1.Chart
Imports System.Collections.Generic
Imports System

Class DataCreator
    Public Delegate Function MathActionDouble(num As Double) As Double
    Public Delegate Function MathActionInt(num As Integer) As Double

    Public Shared Function CreateSimpleChartTypes() As Dictionary(Of ChartType, String)
        Dim types As New Dictionary(Of ChartType, String)()
        types = New Dictionary(Of ChartType, String)()
        types.Add(ChartType.Column, Strings.Column)
        types.Add(ChartType.Bar, Strings.Bar)
        types.Add(ChartType.Line, Strings.Line)
        types.Add(ChartType.Scatter, Strings.Scatter)
        types.Add(ChartType.LineSymbols, Strings.LineSymbols)
        types.Add(ChartType.Area, Strings.Area)
        types.Add(ChartType.Spline, Strings.Spline)
        types.Add(ChartType.SplineArea, Strings.SplineArea)
        types.Add(ChartType.SplineSymbols, Strings.SplineSymbols)
        types.Add(ChartType.Step, Strings.StepType)
        types.Add(ChartType.StepArea, Strings.StepArea)
        types.Add(ChartType.StepSymbols, Strings.StepSymbols)

        Return types
    End Function

    Public Shared Function CreateFruit() As List(Of FruitDataItem)
        Dim fruits As String() = {"Oranges", "Apples", "Pears", "Bananas"}
        Dim count As Integer = fruits.Length
        Dim result As New List(Of FruitDataItem)()
        Dim rnd As New Random()
        Dim i As Integer = 0
        While i < count
            result.Add(New FruitDataItem() With {
                .Fruit = fruits(i),
                .March = rnd.[Next](20),
                .April = rnd.[Next](20),
                .May = rnd.[Next](20)
            })
            i += 1
        End While
        Return result
    End Function

    Public Shared Function CreateData() As List(Of DataItem)
        Dim data As New List(Of DataItem)()
        data.Add(New DataItem("UK", 5, 4))
        data.Add(New DataItem("USA", 7, 3))
        data.Add(New DataItem("Germany", 8, 5))
        data.Add(New DataItem("Japan", 12, 8))
        Return data
    End Function

    Public Shared Function CreateGroupData() As List(Of GroupDataItem)
        Dim data As New List(Of GroupDataItem)()
        data.Add(New GroupDataItem("UK", 5, 4, 6, 5))
        data.Add(New GroupDataItem("USA", 7, 6, 3, 2))
        data.Add(New GroupDataItem("Germany", 8, 5, 10, 6))
        data.Add(New GroupDataItem("Japan", 12, 8, 10, 7))
        Return data
    End Function

    Public Shared Function CreateFunnelData() As List(Of DataItem)
        Dim data As New List(Of DataItem)
        Dim countries As String() = "US,Germany,UK,Japan,Italy,Greece".Split(",")
        Dim sales As Integer = 10000
        Dim rnd As Random = New Random()
        Dim i As Integer = 0
        While i < countries.Length
            Dim item As New DataItem(countries(i), sales, 0)
            sales = sales - CType(Math.Round(rnd.NextDouble() * 2000), Integer)
            data.Add(item)
            i += 1
        End While
        Return data
    End Function
End Class

Public Class FruitDataItem
    Public Property Fruit() As String
    Public Property March() As Double
    Public Property April() As Double
    Public Property May() As Double
End Class

Public Class DataItem
    Public Sub New(c As String, s As Integer, e As Integer)
        Country = c
        Sales = s
        Expenses = e
    End Sub

    Public Property Country() As String
    Public Property Sales() As Integer
    Public Property Expenses() As Integer
End Class

Public Class GroupDataItem
    Public Sub New(c As String, ds As Integer, de As Integer, es As Integer, ee As Integer)
        Country = c
        DomesticSales = ds
        DomesticExpenses = de
        ExportSales = es
        ExportExpenses = ee
    End Sub

    Public Property Country() As String
    Public Property DomesticSales() As Integer
    Public Property DomesticExpenses() As Integer
    Public Property ExportSales() As Integer
    Public Property ExportExpenses() As Integer
End Class


Public Class DynamicItem
    Public Property Day() As Integer
    Public Property Trucks() As Integer
    Public Property Ships() As Integer
    Public Property Planes() As Integer
End Class