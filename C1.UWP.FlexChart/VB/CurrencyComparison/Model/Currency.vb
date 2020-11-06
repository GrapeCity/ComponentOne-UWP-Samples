Imports System

Public Class Currency
    Public Property DisplayName() As String
    Public Property Symbol() As String
    Public Property ExchangeRateSeries() As ChartSeries
    Public Property PercentageChangeSeries() As ChartSeries
End Class

Public Class Data
    Public Property [Date]() As DateTime
    Public Property USD() As Double
    Public Property JPY() As Double
    Public Property GBP() As Double
    Public Property RUB() As Double
    Public Property CNY() As Double
    Public Property INR() As Double
    Public Property KRW() As Double
    Public Property EUR() As Double

    Public Function GetValue([property] As String) As Double
        Select Case [property]
            Case "USD"
                Return USD
            Case "JPY"
                Return JPY
            Case "GBP"
                Return GBP
            Case "RUB"
                Return RUB
            Case "CNY"
                Return CNY
            Case "INR"
                Return INR
            Case "KRW"
                Return KRW
            Case "EUR"
                Return EUR
        End Select
    End Function
End Class