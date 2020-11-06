Imports Windows.UI
Imports C1.Chart
Imports C1.Xaml.Chart
Imports System.Collections.Generic
Imports System.Linq
Imports System

Public Module HelperExtensions
    <Extension()>
    Public Function FilterTableByDate(sourceTable As List(Of Data), [date] As DateTime) As List(Of Data)
        Return sourceTable.Where(Function(data) data.[Date] >= [date]).ToList()
    End Function

    Public Function ImportData() As List(Of Data)
        Dim sourceTable As New List(Of Data)()
        Dim crlf() As String = {vbCrLf}
        Dim rows As String() = Utils.Read("CurrencyHistory.csv").TrimEnd().Split(crlf, StringSplitOptions.None)
        Dim i As Integer = 1
        While i < rows.Length
            Dim columns As String() = rows(i).Trim(ChrW(13)).TrimEnd().Split(","c)
            Dim d As Double
            Dim data As New Data() With {
                .[Date] = DateTime.ParseExact(columns(0), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
                .USD = If(Double.TryParse(columns(1), d), Math.Round(d, 4), sourceTable(sourceTable.Count - 1).USD),
                .JPY = If(Double.TryParse(columns(2), d), Math.Round(d, 4), sourceTable(sourceTable.Count - 1).JPY),
                .GBP = If(Double.TryParse(columns(3), d), Math.Round(d, 4), sourceTable(sourceTable.Count - 1).GBP),
                .RUB = If(Double.TryParse(columns(4), d), Math.Round(d, 4), sourceTable(sourceTable.Count - 1).RUB),
                .CNY = If(Double.TryParse(columns(5), d), Math.Round(d, 4), sourceTable(sourceTable.Count - 1).CNY),
                .INR = If(Double.TryParse(columns(6), d), Math.Round(d, 4), sourceTable(sourceTable.Count - 1).INR),
                .KRW = If(Double.TryParse(columns(7), d), Math.Round(d, 4), sourceTable(sourceTable.Count - 1).KRW),
                .EUR = If(Double.TryParse(columns(8), d), Math.Round(d, 4), sourceTable(sourceTable.Count - 1).EUR)
            }
            sourceTable.Add(data)
            i += 1
        End While

        Return sourceTable
    End Function

    <Extension()>
    Public Function ConvertToBase(sourceTable As List(Of Data), baseCurrency As String) As List(Of Data)
        Dim list As New List(Of Data)()
        For Each data As Data In sourceTable
            Dim baseCurrencyValue As Double = data.GetValue(baseCurrency)
            Dim newData As New Data() With {
                .[Date] = data.[Date],
                .USD = Math.Round(CType(data.USD, Double) / baseCurrencyValue, 4),
                .JPY = Math.Round(CType(data.JPY, Double) / baseCurrencyValue, 4),
                .GBP = Math.Round(CType(data.GBP, Double) / baseCurrencyValue, 4),
                .RUB = Math.Round(CType(data.RUB, Double) / baseCurrencyValue, 4),
                .CNY = Math.Round(CType(data.CNY, Double) / baseCurrencyValue, 4),
                .INR = Math.Round(CType(data.INR, Double) / baseCurrencyValue, 4),
                .KRW = Math.Round(CType(data.KRW, Double) / baseCurrencyValue, 4),
                .EUR = Math.Round(CType(data.EUR, Double) / baseCurrencyValue, 4)
            }
            list.Add(newData)
        Next
        Return list
    End Function

    <Extension()>
    Public Function ConvertToPercentage(sourceTable As List(Of Data)) As List(Of Data)
        Dim list As New List(Of Data)()
        For Each data As Data In sourceTable
            Dim x1 As Double, x2 As Double
            Dim newData As New Data() With {
                .[Date] = data.[Date]
            }
            x1 = sourceTable(sourceTable.Count - 1).USD
            x2 = data.USD
            newData.USD = Math.Round(((x2 - x1) / x1), 4)

            x1 = sourceTable(sourceTable.Count - 1).JPY
            x2 = data.JPY
            newData.JPY = Math.Round(((x2 - x1) / x1), 4)

            x1 = sourceTable(sourceTable.Count - 1).GBP
            x2 = data.GBP
            newData.GBP = Math.Round(((x2 - x1) / x1), 4)

            x1 = sourceTable(sourceTable.Count - 1).RUB
            x2 = data.RUB
            newData.RUB = Math.Round(((x2 - x1) / x1), 4)

            x1 = sourceTable(sourceTable.Count - 1).CNY
            x2 = data.CNY
            newData.CNY = Math.Round(((x2 - x1) / x1), 4)

            x1 = sourceTable(sourceTable.Count - 1).INR
            x2 = data.INR
            newData.INR = Math.Round(((x2 - x1) / x1), 4)

            x1 = sourceTable(sourceTable.Count - 1).KRW
            x2 = data.KRW
            newData.KRW = Math.Round(((x2 - x1) / x1), 4)

            x1 = sourceTable(sourceTable.Count - 1).EUR
            x2 = data.EUR
            newData.EUR = Math.Round(((x2 - x1) / x1), 4)

            list.Add(newData)
        Next

        Return list
    End Function

    <Extension()>
    Public Function AddBusinessDays(current As DateTime, days As Integer) As DateTime
        Dim sign As Double = Math.Sign(days)
        Dim unsignedDays As Double = Math.Abs(days)
        Dim i As Integer = 0
        While i < unsignedDays
            Do
                current = current.AddDays(sign)
            Loop While current.DayOfWeek = DayOfWeek.Saturday OrElse current.DayOfWeek = DayOfWeek.Sunday
            i += 1
        End While
        Return current
    End Function

    <Extension()>
    Public Function ToOADate([date] As DateTime) As Double
        Dim value As Long = [date].Ticks
        If value = 0L Then
            Return 0.0
        End If
        If value < 864000000000L Then
            value += 599264352000000000L
        End If
        If value < 31241376000000000L Then
            Throw New OverflowException("Arg_OleAutDateInvalid")
        End If
        Dim num As Long = CType((value - 599264352000000000L) / 10000L, Long)
        If num < 0L Then
            Dim num2 As Long = num Mod 86400000L
            If num2 <> 0L Then
                num -= (86400000L + num2) * 2L
            End If
        End If
        Return CType(num, Double) / 86400000.0
    End Function

    <Extension()>
    Public Function ToShortDateString([date] As DateTime) As String
        Return String.Format("{0}/{1}/{2}", [date].Year, [date].Month, [date].Day)
    End Function

    Public Function FromOADate(val As Double) As DateTime
        Dim ticks As Long = 0
        If val >= 2958466.0 OrElse val <= -657435.0 Then
            Throw New ArgumentException("Arg_OleAutDateInvalid")
        End If
        Dim num As Long = CType((val * 86400000.0 + (If((val >= 0.0), 0.5, -0.5))), Long)
        If num < 0L Then
            num -= (num Mod 86400000L) * 2L
        End If
        num += 59926435200000L
        If num < 0L OrElse num >= 315537897600000L Then
            Throw New ArgumentException("Arg_OleAutDateScale")
        End If
        ticks = num * 10000L

        Return New DateTime(ticks, DateTimeKind.Unspecified)
    End Function

    <Extension()>
    Public Function GetMax(axis As Axis) As Double
        Return (CType(axis, IAxis)).GetMax()
    End Function

    <Extension()>
    Public Function GetMin(axis As Axis) As Double
        Return (CType(axis, IAxis)).GetMin()
    End Function
End Module