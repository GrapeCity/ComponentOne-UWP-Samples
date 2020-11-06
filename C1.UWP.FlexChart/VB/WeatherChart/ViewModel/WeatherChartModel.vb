Imports System.Collections.Generic
Imports System

Public Class WeatherChartModel
    Private rnd As New Random()

    Public ReadOnly Property Data() As List(Of DataItem)
        Get
            Dim pointsCount As Object = rnd.[Next](1, 30)
            Dim temperaturePoints As New List(Of DataItem)()
            Dim [date] As New DateTime(2016, 1, 1)
            While [date].Year = 2016
                Dim newItem As New DataItem()
                newItem.[Date] = [date]
                If [date].Month <= 8 Then
                    newItem.MaxTemp = rnd.[Next](3 * [date].Month, 4 * [date].Month)
                Else
                    newItem.MaxTemp = rnd.[Next]((13 - [date].Month - 2) * [date].Month, (13 - [date].Month) * [date].Month)
                End If
                newItem.MinTemp = newItem.MaxTemp - rnd.[Next](6, 8)
                newItem.MeanTemp = CType((newItem.MaxTemp + newItem.MinTemp) / 2, Integer)
                newItem.MeanPressure = rnd.[Next](980, 1050)
                newItem.Precipitation = If(rnd.[Next](5) = 1, rnd.[Next](0, 20), 0)
                temperaturePoints.Add(newItem)
                [date] = [date].AddDays(1)
            End While

            Return temperaturePoints
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return Strings.Description
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return Strings.Title
        End Get
    End Property
End Class