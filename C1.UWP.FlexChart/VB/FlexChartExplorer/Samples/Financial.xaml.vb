Imports C1.Xaml.Chart
Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Financial
    Inherits Page
    Private npts As Integer = 30
    Private _data As List(Of Quote)
    Private _chartTypes As Dictionary(Of ChartType, String)
    Private rnd As New Random()

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property ChartTypes() As Dictionary(Of ChartType, String)
        Get
            If _chartTypes Is Nothing Then
                _chartTypes = DataCreator.CreateFinancialChartTypes()
            End If

            Return _chartTypes
        End Get
    End Property

    Public ReadOnly Property FinancialSeriesInstance() As Series
        Get
            Return financialSeries
        End Get
    End Property

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            If _data Is Nothing Then
                _data = CreateData()
            End If

            Return _data
        End Get
    End Property

    Function CreateData() As List(Of Quote)
        Dim list As New List(Of Quote)()
        Dim dt As Date = DateTime.Today
        Dim i As Integer = 0
        While i < npts
            Dim q As New Quote()
            q.Time = dt.AddDays(i)
            If i > 0 Then
                q.Open = list(i - 1).Close
            Else
                q.Open = 1000
            End If
            q.High = q.Open + rnd.[Next](50)
            q.Low = q.Open - rnd.[Next](50)
            q.Close = rnd.[Next](CType(q.Low, Integer), CType(q.High, Integer))
            q.Volume = rnd.[Next](0, 100)
            list.Add(q)
            i += 1
        End While
        Return list
    End Function

End Class

Public Class Quote
    Public Property Time() As DateTime
    Public Property Open() As Double
    Public Property Close() As Double
    Public Property High() As Double
    Public Property Low() As Double
    Public Property Volume() As Double
End Class