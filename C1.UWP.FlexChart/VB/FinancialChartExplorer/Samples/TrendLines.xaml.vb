Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' Interaction logic for TrendLines.xaml
''' </summary>
Partial Public Class TrendLines
    Inherits Page
    Implements INotifyPropertyChanged
    Private dataSerivice As DataService = DataService.GetService()

    Public Sub New()
        InitializeComponent()

        Dim bindingMinX As Binding = New Binding
        bindingMinX.Source = Me
        bindingMinX.Path = New PropertyPath("MinX")
        BindingOperations.SetBinding(trendLine, C1.Xaml.Chart.TrendLine.MinXProperty, bindingMinX)

        Dim bindingMaxX As Binding = New Binding
        bindingMaxX.Source = Me
        bindingMaxX.Path = New PropertyPath("MaxX")
        BindingOperations.SetBinding(trendLine, C1.Xaml.Chart.TrendLine.MaxXProperty, bindingMaxX)

    End Sub
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub OnPropertyChanged(pName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(pName))
    End Sub

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            Return dataSerivice.GetSymbolData("box")
        End Get
    End Property

    Private m_minDate As DateTime = DateTime.MinValue
    Public ReadOnly Property MinDate() As DateTime
        Get
            If m_minDate = DateTime.MinValue Then
                m_minDate = Data.Min(Function(p) p.[Date2])
            End If
            Return m_minDate
        End Get
    End Property

    Private m_maxDate As DateTime = DateTime.MinValue
    Public ReadOnly Property MaxDate() As DateTime
        Get
            If m_maxDate = DateTime.MinValue Then
                m_maxDate = Data.Max(Function(p) p.[Date2])
            End If
            Return m_maxDate
        End Get
    End Property

    Private m_forward As UInteger = 30
    Public Property Forward() As UInteger
        Get
            Return m_forward
        End Get
        Set
            m_forward = Value
            MaxX = Convert(MaxDate, CInt(Forward))
        End Set
    End Property

    Private m_backward As UInteger = 0
    Public Property Backward() As UInteger
        Get
            Return m_backward
        End Get
        Set
            m_backward = Value
            MinX = Convert(MinDate, CInt(-Backward))
        End Set
    End Property

    Private m_minX As Double = Double.NaN
    Public Property MinX() As Double
        Get
            Return m_minX
        End Get
        Set
            m_minX = Value
            OnPropertyChanged("MinX")
        End Set
    End Property

    Private m_maxX As Double = Double.NaN

    Public Property MaxX() As Double
        Get
            Return m_maxX
        End Get
        Set
            m_maxX = Value
            OnPropertyChanged("MaxX")
        End Set
    End Property

    Private Function Convert(baseValue As DateTime, changes As Integer) As Double
        Dim value As Double = Double.NaN
        If Me.chkForecast.IsChecked = True Then
            value = baseValue.AddDays(changes).ToOADate()
        End If
        Return value
    End Function

    Public ReadOnly Property FitType() As List(Of String)
        Get
            Return New List(Of String)() From {
                "Linear",
                "Exponent",
                "Polynom",
                "AverageX",
                "MinX",
                "MaxX",
                "AverageY",
                "MinY",
                "MaxY"
            }
        End Get
    End Property

    Private Sub chkForecast_CheckedChanged(sender As Object, e As RoutedEventArgs)

        If (chkForecast.IsChecked.Equals(True)) Then
            financialChart.BeginUpdate()
            financialChart.BindingX = "Date2"
            financialChart.EndUpdate()
        Else
            financialChart.BeginUpdate()
            financialChart.BindingX = "Date"
            financialChart.EndUpdate()
        End If

        MinX = Convert(MinDate, CInt(-Backward))
        MaxX = Convert(MaxDate, CInt(Forward))
    End Sub
End Class