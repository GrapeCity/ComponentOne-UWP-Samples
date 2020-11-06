Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Data
Imports System.Collections.Generic
Imports System
Imports C1.Chart
Imports System.Collections

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

    Public Shared Function CreateFinancialChartTypes() As Dictionary(Of ChartType, String)
        Dim types As New Dictionary(Of ChartType, String)()
        types.Add(ChartType.Candlestick, Strings.Candlestick)
        types.Add(ChartType.HighLowOpenClose, Strings.HighLowOpenClose)

        Return types
    End Function

    Public Shared Function Create([function] As MathActionDouble, from As Double, [to] As Double, [step] As Double) As List(Of DataPoint)
        Dim result As New List(Of DataPoint)()
        Dim count As Double = ([to] - from) / [step]

        Dim r As Double = from
        While r < [to]
            result.Add(New DataPoint() With {
                .XVals = r,
                .YVals = [function](r)
            })
            r += [step]
        End While
        Return result
    End Function

    Public Shared Function Create([function] As MathActionInt, from As Integer, [to] As Integer, [step] As Integer) As List(Of DataPoint)
        Dim result As New List(Of DataPoint)()
        Dim count As Double = ([to] - from) / [step]

        Dim r As Integer = from
        While r < [to]
            result.Add(New DataPoint() With {
                .XVals = r,
                .YVals = [function](r)
            })
            r += [step]
        End While
        Return result
    End Function

    Public Shared Function Create(functionX As MathActionDouble, functionY As MathActionDouble, ptsCount As Integer) As List(Of DataPoint)
        Dim result As New List(Of DataPoint)()

        Dim i As Double = 0
        While i < ptsCount
            result.Add(New DataPoint() With {
                .XVals = functionX(i),
                .YVals = functionY(i)
            })
            i += 1
        End While
        Return result
    End Function

    Public Shared Function Create(coef As String(), ptsCount As Integer) As List(Of DataPoint)
        Dim result As New List(Of DataPoint)()

        Dim x As Double() = New Double(ptsCount) {}
        Dim y As Double() = New Double(ptsCount) {}
        Dim rnd As New Random()
        Dim c As Double() = StringToCoeff(coef(rnd.[Next](coef.Length)))

        Dim i As Integer = 1
        While i < ptsCount
            Dim pt As DataPoint = Iterate(x(i - 1), y(i - 1), c)
            result.Add(pt)
            x(i) = pt.XVals
            y(i) = pt.YVals
            i += 1
        End While

        Return result
    End Function

    Public Shared Function CreateFruit() As List(Of FruitDataItem)
        Dim fruits() As String = {"Oranges", "Apples", "Pears", "Bananas"}
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

    Public Shared Function CreateFruits() As List(Of FruitsDataItem)
        Dim fruits() As String = {"Oranges", "Apples", "Pears", "Bananas"}
        Dim count As Integer = fruits.Length
        Dim result As New List(Of FruitsDataItem)()
        Dim rnd As New Random()
        Dim i As Integer = 0
        While i < count
            result.Add(New FruitsDataItem() With {
                .Fruit = fruits(i),
                .March = 1 + rnd.[Next](20),
                .April = 1 + rnd.[Next](20),
                .May = 1 + rnd.[Next](20),
                .June = 1 + rnd.[Next](20),
            .July = 1 + rnd.[Next](20)
            })
            i += 1
        End While
        Return result
    End Function

    Public Shared Function CreateWaterfallData() As List(Of WaterfallItem)
        Dim rnd As New Random
        Dim items As New List(Of WaterfallItem)
        Dim names() As String = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
        For Each name As String In names
            items.Add(New WaterfallItem With {
                      .Name = name,
                      .Value = Math.Round((0.5 - rnd.NextDouble()) * 1000)})
        Next
        Return items
    End Function

    Public Shared Function CreateChartTypesForErrorBar() As IDictionary(Of ChartType, String)
        Dim types As Dictionary(Of ChartType, String) = New Dictionary(Of ChartType, String)
        types.Add(ChartType.Column, Strings.Column)
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

    Public Shared Function CreateQuartileCalculations() As List(Of String)
        Return [Enum].GetNames(GetType(QuartileCalculation)).ToList()
    End Function

    Public Shared Function CreateSchoolScoreData() As List(Of ClassScore)
        Dim result As New List(Of ClassScore)
        result.Add(New ClassScore() With {.ClassName = "English", .SchoolA = 46, .SchoolB = 53, .SchoolC = 66})
        result.Add(New ClassScore() With {.ClassName = "Physics", .SchoolA = 61, .SchoolB = 55, .SchoolC = 65})
        result.Add(New ClassScore() With {.ClassName = "English", .SchoolA = 58, .SchoolB = 56, .SchoolC = 67})
        result.Add(New ClassScore() With {.ClassName = "Math", .SchoolA = 58, .SchoolB = 51, .SchoolC = 64})
        result.Add(New ClassScore() With {.ClassName = "English", .SchoolA = 63, .SchoolB = 53, .SchoolC = 45})
        result.Add(New ClassScore() With {.ClassName = "English", .SchoolA = 63, .SchoolB = 50, .SchoolC = 65})
        result.Add(New ClassScore() With {.ClassName = "Math", .SchoolA = 60, .SchoolB = 45, .SchoolC = 67})
        result.Add(New ClassScore() With {.ClassName = "Math", .SchoolA = 62, .SchoolB = 53, .SchoolC = 66})
        result.Add(New ClassScore() With {.ClassName = "Physics", .SchoolA = 63, .SchoolB = 54, .SchoolC = 64})
        result.Add(New ClassScore() With {.ClassName = "English", .SchoolA = 63, .SchoolB = 52, .SchoolC = 67})
        result.Add(New ClassScore() With {.ClassName = "Physics", .SchoolA = 69, .SchoolB = 66, .SchoolC = 71})
        result.Add(New ClassScore() With {.ClassName = "Physics", .SchoolA = 48, .SchoolB = 67, .SchoolC = 50})
        result.Add(New ClassScore() With {.ClassName = "Physics", .SchoolA = 54, .SchoolB = 50, .SchoolC = 56})
        result.Add(New ClassScore() With {.ClassName = "Physics", .SchoolA = 60, .SchoolB = 56, .SchoolC = 64})
        result.Add(New ClassScore() With {.ClassName = "Math", .SchoolA = 71, .SchoolB = 65, .SchoolC = 50})
        result.Add(New ClassScore() With {.ClassName = "Math", .SchoolA = 48, .SchoolB = 70, .SchoolC = 72})
        result.Add(New ClassScore() With {.ClassName = "Math", .SchoolA = 53, .SchoolB = 40, .SchoolC = 80})
        result.Add(New ClassScore() With {.ClassName = "Math", .SchoolA = 60, .SchoolB = 56, .SchoolC = 67})
        result.Add(New ClassScore() With {.ClassName = "Math", .SchoolA = 61, .SchoolB = 56, .SchoolC = 45})
        result.Add(New ClassScore() With {.ClassName = "English", .SchoolA = 63, .SchoolB = 58, .SchoolC = 64})
        result.Add(New ClassScore() With {.ClassName = "Physics", .SchoolA = 59, .SchoolB = 54, .SchoolC = 65})
        Return result

    End Function

    Public Shared Function CreateHistogramData() As List(Of Bin)
        Dim result As New List(Of Bin)
        result.Add(New Bin() With {.X = 161.2, .Y = 51.6})
        result.Add(New Bin() With {.X = 167.5, .Y = 59.0})
        result.Add(New Bin() With {.X = 159.5, .Y = 49.2})
        result.Add(New Bin() With {.X = 157.0, .Y = 63.0})
        result.Add(New Bin() With {.X = 155.8, .Y = 53.6})
        result.Add(New Bin() With {.X = 170.0, .Y = 59.0})
        result.Add(New Bin() With {.X = 159.1, .Y = 47.6})
        result.Add(New Bin() With {.X = 166.0, .Y = 69.8})
        result.Add(New Bin() With {.X = 176.2, .Y = 66.8})
        result.Add(New Bin() With {.X = 160.2, .Y = 75.2})
        result.Add(New Bin() With {.X = 172.5, .Y = 55.2})
        result.Add(New Bin() With {.X = 170.9, .Y = 54.2})
        result.Add(New Bin() With {.X = 172.9, .Y = 62.5})
        result.Add(New Bin() With {.X = 153.4, .Y = 42.0})
        result.Add(New Bin() With {.X = 160.0, .Y = 50.0})
        result.Add(New Bin() With {.X = 147.2, .Y = 49.8})
        result.Add(New Bin() With {.X = 168.2, .Y = 49.2})
        result.Add(New Bin() With {.X = 175.0, .Y = 73.2})
        result.Add(New Bin() With {.X = 157.0, .Y = 47.8})
        result.Add(New Bin() With {.X = 167.6, .Y = 68.8})
        result.Add(New Bin() With {.X = 159.5, .Y = 50.6})
        result.Add(New Bin() With {.X = 175.0, .Y = 82.5})
        result.Add(New Bin() With {.X = 166.8, .Y = 57.2})
        result.Add(New Bin() With {.X = 176.5, .Y = 87.8})
        result.Add(New Bin() With {.X = 170.2, .Y = 72.8})
        result.Add(New Bin() With {.X = 174.0, .Y = 54.5})
        result.Add(New Bin() With {.X = 173.0, .Y = 59.8})
        result.Add(New Bin() With {.X = 179.9, .Y = 67.3})
        result.Add(New Bin() With {.X = 170.5, .Y = 67.8})
        result.Add(New Bin() With {.X = 160.0, .Y = 47.0})
        result.Add(New Bin() With {.X = 154.4, .Y = 46.2})
        result.Add(New Bin() With {.X = 162.0, .Y = 55.0})
        result.Add(New Bin() With {.X = 176.5, .Y = 83.0})
        result.Add(New Bin() With {.X = 160.0, .Y = 54.4})
        result.Add(New Bin() With {.X = 152.0, .Y = 45.8})
        result.Add(New Bin() With {.X = 162.1, .Y = 53.6})
        result.Add(New Bin() With {.X = 170.0, .Y = 73.2})
        result.Add(New Bin() With {.X = 160.2, .Y = 52.1})
        result.Add(New Bin() With {.X = 161.3, .Y = 67.9})
        result.Add(New Bin() With {.X = 166.4, .Y = 56.6})
        result.Add(New Bin() With {.X = 168.9, .Y = 62.3})
        result.Add(New Bin() With {.X = 163.8, .Y = 58.5})
        result.Add(New Bin() With {.X = 167.6, .Y = 54.5})
        result.Add(New Bin() With {.X = 160.0, .Y = 50.2})
        result.Add(New Bin() With {.X = 161.3, .Y = 60.3})
        result.Add(New Bin() With {.X = 167.6, .Y = 58.3})
        result.Add(New Bin() With {.X = 165.1, .Y = 56.2})
        result.Add(New Bin() With {.X = 160.0, .Y = 50.2})
        result.Add(New Bin() With {.X = 170.0, .Y = 72.9})
        result.Add(New Bin() With {.X = 157.5, .Y = 59.8})
        result.Add(New Bin() With {.X = 167.6, .Y = 61.0})
        result.Add(New Bin() With {.X = 160.7, .Y = 69.1})
        result.Add(New Bin() With {.X = 163.2, .Y = 55.9})
        result.Add(New Bin() With {.X = 152.4, .Y = 46.5})
        result.Add(New Bin() With {.X = 157.5, .Y = 54.3})
        result.Add(New Bin() With {.X = 168.3, .Y = 54.8})
        result.Add(New Bin() With {.X = 180.3, .Y = 60.7})
        result.Add(New Bin() With {.X = 165.5, .Y = 60.0})
        result.Add(New Bin() With {.X = 165.0, .Y = 62.0})
        result.Add(New Bin() With {.X = 164.5, .Y = 60.3})
        result.Add(New Bin() With {.X = 156.0, .Y = 52.7})
        result.Add(New Bin() With {.X = 160.0, .Y = 74.3})
        result.Add(New Bin() With {.X = 163.0, .Y = 62.0})
        result.Add(New Bin() With {.X = 165.7, .Y = 73.1})
        result.Add(New Bin() With {.X = 161.0, .Y = 80.0})
        result.Add(New Bin() With {.X = 162.0, .Y = 54.7})
        result.Add(New Bin() With {.X = 166.0, .Y = 53.2})
        result.Add(New Bin() With {.X = 174.0, .Y = 75.7})
        result.Add(New Bin() With {.X = 172.7, .Y = 61.1})
        result.Add(New Bin() With {.X = 167.6, .Y = 55.7})
        result.Add(New Bin() With {.X = 151.1, .Y = 48.7})
        result.Add(New Bin() With {.X = 164.5, .Y = 52.3})
        result.Add(New Bin() With {.X = 163.5, .Y = 50.0})
        result.Add(New Bin() With {.X = 152.0, .Y = 59.3})
        result.Add(New Bin() With {.X = 169.0, .Y = 62.5})
        result.Add(New Bin() With {.X = 164.0, .Y = 55.7})
        result.Add(New Bin() With {.X = 161.2, .Y = 54.8})
        result.Add(New Bin() With {.X = 155.0, .Y = 45.9})
        result.Add(New Bin() With {.X = 170.0, .Y = 70.6})
        result.Add(New Bin() With {.X = 176.2, .Y = 67.2})
        result.Add(New Bin() With {.X = 170.0, .Y = 69.4})
        result.Add(New Bin() With {.X = 162.5, .Y = 58.2})
        result.Add(New Bin() With {.X = 170.3, .Y = 64.8})
        result.Add(New Bin() With {.X = 164.1, .Y = 71.6})
        result.Add(New Bin() With {.X = 169.5, .Y = 52.8})
        result.Add(New Bin() With {.X = 163.2, .Y = 59.8})
        result.Add(New Bin() With {.X = 154.5, .Y = 49.0})
        result.Add(New Bin() With {.X = 159.8, .Y = 50.0})
        result.Add(New Bin() With {.X = 173.2, .Y = 69.2})
        result.Add(New Bin() With {.X = 170.0, .Y = 55.9})
        result.Add(New Bin() With {.X = 161.4, .Y = 63.4})
        result.Add(New Bin() With {.X = 169.0, .Y = 58.2})
        result.Add(New Bin() With {.X = 166.2, .Y = 58.6})
        result.Add(New Bin() With {.X = 159.4, .Y = 45.7})
        result.Add(New Bin() With {.X = 162.5, .Y = 52.2})
        result.Add(New Bin() With {.X = 159.0, .Y = 48.6})
        result.Add(New Bin() With {.X = 162.8, .Y = 57.8})
        result.Add(New Bin() With {.X = 159.0, .Y = 55.6})
        result.Add(New Bin() With {.X = 179.8, .Y = 66.8})
        result.Add(New Bin() With {.X = 162.9, .Y = 59.4})
        result.Add(New Bin() With {.X = 161.0, .Y = 53.6})
        result.Add(New Bin() With {.X = 151.1, .Y = 73.2})
        result.Add(New Bin() With {.X = 168.2, .Y = 53.4})
        result.Add(New Bin() With {.X = 168.9, .Y = 69.0})
        result.Add(New Bin() With {.X = 173.2, .Y = 58.4})
        result.Add(New Bin() With {.X = 171.8, .Y = 56.2})
        result.Add(New Bin() With {.X = 178.0, .Y = 70.6})
        result.Add(New Bin() With {.X = 164.3, .Y = 59.8})
        result.Add(New Bin() With {.X = 163.0, .Y = 72.0})
        result.Add(New Bin() With {.X = 168.5, .Y = 65.2})
        result.Add(New Bin() With {.X = 166.8, .Y = 56.6})
        result.Add(New Bin() With {.X = 172.7, .Y = 105.2})
        result.Add(New Bin() With {.X = 163.5, .Y = 51.8})
        result.Add(New Bin() With {.X = 169.4, .Y = 63.4})
        result.Add(New Bin() With {.X = 167.8, .Y = 59.0})
        result.Add(New Bin() With {.X = 159.5, .Y = 47.6})
        result.Add(New Bin() With {.X = 167.6, .Y = 63.0})
        result.Add(New Bin() With {.X = 161.2, .Y = 55.2})
        result.Add(New Bin() With {.X = 160.0, .Y = 45.0})
        result.Add(New Bin() With {.X = 163.2, .Y = 54.0})
        result.Add(New Bin() With {.X = 162.2, .Y = 50.2})
        result.Add(New Bin() With {.X = 161.3, .Y = 60.2})
        result.Add(New Bin() With {.X = 149.5, .Y = 44.8})
        result.Add(New Bin() With {.X = 157.5, .Y = 58.8})
        result.Add(New Bin() With {.X = 163.2, .Y = 56.4})
        result.Add(New Bin() With {.X = 172.7, .Y = 62.0})
        result.Add(New Bin() With {.X = 155.0, .Y = 49.2})
        result.Add(New Bin() With {.X = 156.5, .Y = 67.2})
        result.Add(New Bin() With {.X = 164.0, .Y = 53.8})
        result.Add(New Bin() With {.X = 160.9, .Y = 54.4})
        result.Add(New Bin() With {.X = 162.8, .Y = 58.0})
        result.Add(New Bin() With {.X = 167.0, .Y = 59.8})
        result.Add(New Bin() With {.X = 160.0, .Y = 54.8})
        result.Add(New Bin() With {.X = 160.0, .Y = 43.2})
        result.Add(New Bin() With {.X = 168.9, .Y = 60.5})
        result.Add(New Bin() With {.X = 158.2, .Y = 46.4})
        result.Add(New Bin() With {.X = 156.0, .Y = 64.4})
        result.Add(New Bin() With {.X = 160.0, .Y = 48.8})
        result.Add(New Bin() With {.X = 167.1, .Y = 62.2})
        result.Add(New Bin() With {.X = 158.0, .Y = 55.5})
        result.Add(New Bin() With {.X = 167.6, .Y = 57.8})
        result.Add(New Bin() With {.X = 156.0, .Y = 54.6})
        result.Add(New Bin() With {.X = 162.1, .Y = 59.2})
        result.Add(New Bin() With {.X = 173.4, .Y = 52.7})
        result.Add(New Bin() With {.X = 159.8, .Y = 53.2})
        result.Add(New Bin() With {.X = 170.5, .Y = 64.5})
        result.Add(New Bin() With {.X = 159.2, .Y = 51.8})
        result.Add(New Bin() With {.X = 157.5, .Y = 56.0})
        result.Add(New Bin() With {.X = 161.3, .Y = 63.6})
        result.Add(New Bin() With {.X = 162.6, .Y = 63.2})
        result.Add(New Bin() With {.X = 160.0, .Y = 59.5})
        result.Add(New Bin() With {.X = 168.9, .Y = 56.8})
        result.Add(New Bin() With {.X = 165.1, .Y = 64.1})
        result.Add(New Bin() With {.X = 162.6, .Y = 50.0})
        result.Add(New Bin() With {.X = 165.1, .Y = 72.3})
        result.Add(New Bin() With {.X = 166.4, .Y = 55.0})
        result.Add(New Bin() With {.X = 160.0, .Y = 55.9})
        result.Add(New Bin() With {.X = 152.4, .Y = 60.4})
        result.Add(New Bin() With {.X = 170.2, .Y = 69.1})
        result.Add(New Bin() With {.X = 162.6, .Y = 84.5})
        result.Add(New Bin() With {.X = 170.2, .Y = 55.9})
        result.Add(New Bin() With {.X = 158.8, .Y = 55.5})
        result.Add(New Bin() With {.X = 172.7, .Y = 69.5})
        result.Add(New Bin() With {.X = 167.6, .Y = 76.4})
        result.Add(New Bin() With {.X = 162.6, .Y = 61.4})
        result.Add(New Bin() With {.X = 167.6, .Y = 65.9})
        result.Add(New Bin() With {.X = 156.2, .Y = 58.6})
        result.Add(New Bin() With {.X = 175.2, .Y = 66.8})
        result.Add(New Bin() With {.X = 172.1, .Y = 56.6})
        result.Add(New Bin() With {.X = 162.6, .Y = 58.6})
        result.Add(New Bin() With {.X = 160.0, .Y = 55.9})
        result.Add(New Bin() With {.X = 165.1, .Y = 59.1})
        result.Add(New Bin() With {.X = 182.9, .Y = 81.8})
        result.Add(New Bin() With {.X = 166.4, .Y = 70.7})
        result.Add(New Bin() With {.X = 165.1, .Y = 56.8})
        result.Add(New Bin() With {.X = 177.8, .Y = 60.0})
        result.Add(New Bin() With {.X = 165.1, .Y = 58.2})
        result.Add(New Bin() With {.X = 175.3, .Y = 72.7})
        result.Add(New Bin() With {.X = 154.9, .Y = 54.1})
        result.Add(New Bin() With {.X = 158.8, .Y = 49.1})
        result.Add(New Bin() With {.X = 172.7, .Y = 75.9})
        result.Add(New Bin() With {.X = 168.9, .Y = 55.0})
        result.Add(New Bin() With {.X = 161.3, .Y = 57.3})
        result.Add(New Bin() With {.X = 167.6, .Y = 55.0})
        result.Add(New Bin() With {.X = 165.1, .Y = 65.5})
        result.Add(New Bin() With {.X = 175.3, .Y = 65.5})
        result.Add(New Bin() With {.X = 157.5, .Y = 48.6})
        result.Add(New Bin() With {.X = 163.8, .Y = 58.6})
        result.Add(New Bin() With {.X = 167.6, .Y = 63.6})
        result.Add(New Bin() With {.X = 165.1, .Y = 55.2})
        result.Add(New Bin() With {.X = 165.1, .Y = 62.7})
        result.Add(New Bin() With {.X = 168.9, .Y = 56.6})
        result.Add(New Bin() With {.X = 162.6, .Y = 53.9})
        result.Add(New Bin() With {.X = 164.5, .Y = 63.2})
        result.Add(New Bin() With {.X = 176.5, .Y = 73.6})
        result.Add(New Bin() With {.X = 168.9, .Y = 62.0})
        result.Add(New Bin() With {.X = 175.3, .Y = 63.6})
        result.Add(New Bin() With {.X = 159.4, .Y = 53.2})
        result.Add(New Bin() With {.X = 160.0, .Y = 53.4})
        result.Add(New Bin() With {.X = 170.2, .Y = 55.0})
        result.Add(New Bin() With {.X = 162.6, .Y = 70.5})
        result.Add(New Bin() With {.X = 167.6, .Y = 54.5})
        result.Add(New Bin() With {.X = 162.6, .Y = 54.5})
        result.Add(New Bin() With {.X = 160.7, .Y = 55.9})
        result.Add(New Bin() With {.X = 160.0, .Y = 59.0})
        result.Add(New Bin() With {.X = 157.5, .Y = 63.6})
        result.Add(New Bin() With {.X = 162.6, .Y = 54.5})
        result.Add(New Bin() With {.X = 152.4, .Y = 47.3})
        result.Add(New Bin() With {.X = 170.2, .Y = 67.7})
        result.Add(New Bin() With {.X = 165.1, .Y = 80.9})
        result.Add(New Bin() With {.X = 172.7, .Y = 70.5})
        result.Add(New Bin() With {.X = 165.1, .Y = 60.9})
        result.Add(New Bin() With {.X = 170.2, .Y = 63.6})
        result.Add(New Bin() With {.X = 170.2, .Y = 54.5})
        result.Add(New Bin() With {.X = 170.2, .Y = 59.1})
        result.Add(New Bin() With {.X = 161.3, .Y = 70.5})
        result.Add(New Bin() With {.X = 167.6, .Y = 52.7})
        result.Add(New Bin() With {.X = 167.6, .Y = 62.7})
        result.Add(New Bin() With {.X = 165.1, .Y = 86.3})
        result.Add(New Bin() With {.X = 162.6, .Y = 66.4})
        result.Add(New Bin() With {.X = 152.4, .Y = 67.3})
        result.Add(New Bin() With {.X = 168.9, .Y = 63.0})
        result.Add(New Bin() With {.X = 170.2, .Y = 73.6})
        result.Add(New Bin() With {.X = 175.2, .Y = 62.3})
        result.Add(New Bin() With {.X = 175.2, .Y = 57.7})
        result.Add(New Bin() With {.X = 160.0, .Y = 55.4})
        result.Add(New Bin() With {.X = 165.1, .Y = 104.1})
        result.Add(New Bin() With {.X = 174.0, .Y = 55.5})
        result.Add(New Bin() With {.X = 170.2, .Y = 77.3})
        result.Add(New Bin() With {.X = 160.0, .Y = 80.5})
        result.Add(New Bin() With {.X = 167.6, .Y = 64.5})
        result.Add(New Bin() With {.X = 167.6, .Y = 72.3})
        result.Add(New Bin() With {.X = 167.6, .Y = 61.4})
        result.Add(New Bin() With {.X = 154.9, .Y = 58.2})
        result.Add(New Bin() With {.X = 162.6, .Y = 81.8})
        result.Add(New Bin() With {.X = 175.3, .Y = 63.6})
        result.Add(New Bin() With {.X = 171.4, .Y = 53.4})
        result.Add(New Bin() With {.X = 157.5, .Y = 54.5})
        result.Add(New Bin() With {.X = 165.1, .Y = 53.6})
        result.Add(New Bin() With {.X = 160.0, .Y = 60.0})
        result.Add(New Bin() With {.X = 174.0, .Y = 73.6})
        result.Add(New Bin() With {.X = 162.6, .Y = 61.4})
        result.Add(New Bin() With {.X = 174.0, .Y = 55.5})
        result.Add(New Bin() With {.X = 162.6, .Y = 63.6})
        result.Add(New Bin() With {.X = 161.3, .Y = 60.9})
        result.Add(New Bin() With {.X = 156.2, .Y = 60.0})
        result.Add(New Bin() With {.X = 149.9, .Y = 46.8})
        result.Add(New Bin() With {.X = 169.5, .Y = 57.3})
        result.Add(New Bin() With {.X = 160.0, .Y = 64.1})
        result.Add(New Bin() With {.X = 175.3, .Y = 63.6})
        result.Add(New Bin() With {.X = 169.5, .Y = 67.3})
        result.Add(New Bin() With {.X = 160.0, .Y = 75.5})
        result.Add(New Bin() With {.X = 172.7, .Y = 68.2})
        result.Add(New Bin() With {.X = 162.6, .Y = 61.4})
        result.Add(New Bin() With {.X = 157.5, .Y = 76.8})
        result.Add(New Bin() With {.X = 176.5, .Y = 71.8})
        result.Add(New Bin() With {.X = 164.4, .Y = 55.5})
        result.Add(New Bin() With {.X = 160.7, .Y = 48.6})
        result.Add(New Bin() With {.X = 174.0, .Y = 66.4})
        result.Add(New Bin() With {.X = 163.8, .Y = 67.3})
        Return result
    End Function

    Public Shared Function CreateRangedHistogramData() As List(Of WaterfallItem)
        Dim result As New List(Of WaterfallItem)
        result.Add(New WaterfallItem() With {.Name = "A", .Value = 20})
        result.Add(New WaterfallItem() With {.Name = "B", .Value = 35})
        result.Add(New WaterfallItem() With {.Name = "C", .Value = 40})
        result.Add(New WaterfallItem() With {.Name = "A", .Value = 55})
        result.Add(New WaterfallItem() With {.Name = "B", .Value = 80})
        result.Add(New WaterfallItem() With {.Name = "C", .Value = 60})
        result.Add(New WaterfallItem() With {.Name = "A", .Value = 61})
        result.Add(New WaterfallItem() With {.Name = "B", .Value = 85})
        result.Add(New WaterfallItem() With {.Name = "C", .Value = 80})
        result.Add(New WaterfallItem() With {.Name = "A", .Value = 64})
        result.Add(New WaterfallItem() With {.Name = "B", .Value = 80})
        result.Add(New WaterfallItem() With {.Name = "C", .Value = 75})
        result.Add(New WaterfallItem() With {.Name = "A", .Value = 1222})
        result.Add(New WaterfallItem() With {.Name = "B", .Value = 133})
        Return result
    End Function

    Public Shared Function CreateSales() As Sale()
        Dim countries As String() = {"US", "Germany", "UK", "Japan", "Italy", "Greece", "China", "France", "Russia"}
        Dim count As Integer = countries.Length
        Dim result As Sale() = New Sale(count - 1) {}
        Dim rnd As Random = New Random()
        Dim i As Integer = 0
        While i < count
            result(i) = New Sale() With {
                .Country = countries(i),
                .Sales = rnd.[Next](60)
            }
            i += 1
        End While
        Return result
    End Function

    Public Shared Function CreateForPlotAreas() As PlotAreasSampleDataItem()
        Dim data As PlotAreasSampleDataItem() = New PlotAreasSampleDataItem(19) {}
        Dim i As Integer = 0
        While i < 20
            Dim ac As Double = i
            Dim ve As Double = ac * i
            Dim di As Double = 0.5 * ac * i * i
            data(i) = New PlotAreasSampleDataItem() With
                {
                    .Acceleration = ac,
                    .Velocity = ve,
                    .Distance = di,
                    .Time = i
                }
            i += 1
        End While

        Return data
    End Function

    Public Shared Function Sinus(x As Double) As Double
        Return Math.Sin(x)
    End Function

    Public Shared Function Test1(x As Double) As Double
        Return (Math.Pow(-x, 2 / 3) + Math.Sqrt(Math.Pow(x, 4 / 3) - 4 * Math.Pow(x, 2) + 4)) / 2
    End Function

    Shared Function Iterate(x As Double, y As Double, c As Double()) As DataPoint
        Dim x1 As Double = c(0) + c(1) * x + c(2) * x * x + c(3) * x * y + c(4) * y + c(5) * y * y
        Dim y1 As Double = c(6) + c(7) * x + c(8) * x * x + c(9) * x * y + c(10) * y + c(11) * y * y

        Return New DataPoint() With {
            .XVals = x1,
            .YVals = y1
        }
    End Function

    Shared Function StringToCoeff(s As String) As Double()
        Dim len As Integer = s.Length
        Dim c As Double() = New Double(len) {}
        Dim i As Integer = 0
        While i < len
            c(i) = -1.2 + 0.1 * (AscW(s(i)) - AscW("A"))
            i += 1
        End While

        Return c
    End Function
End Class

Public Class FruitDataItem
    Public Property Fruit() As String
    Public Property March() As Double
    Public Property April() As Double
    Public Property May() As Double
End Class

Public Class FruitsDataItem
    Public Property Fruit() As String
    Public Property March() As Double
    Public Property April() As Double
    Public Property May() As Double
    Public Property June() As Double
    Public Property July() As Double
End Class

Public Class DataPoint
    Public Property XVals() As Double
    Public Property YVals() As Double
End Class

Public Class WaterfallItem
    Public Property Name() As String
    Public Property Value() As Double
End Class

Public Class ClassScore
    Public Property ClassName() As String
    Public Property SchoolA() As Double
    Public Property SchoolB() As Double
    Public Property SchoolC() As Double
End Class

Public Class Bin
    Public Property Y() As Double
    Public Property X() As Double
End Class

Public Class Sale
    Public Property Country() As String
    Public Property Sales() As Integer
End Class

Public Class PlotAreasSampleDataItem
    Public Property Acceleration() As Double
    Public Property Velocity() As Double
    Public Property Distance() As Double
    Public Property Time() As Integer
End Class
