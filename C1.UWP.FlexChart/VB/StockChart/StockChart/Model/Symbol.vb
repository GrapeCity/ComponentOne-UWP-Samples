Public Class Symbol
    Implements INotifyPropertyChanged
    Implements IDisposable
    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Private Sub OnPropertyChanged(propName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propName))
    End Sub

    Public Sub New(code__1 As String)
        Code = code__1.ToUpper()
    End Sub

    Private _code As String
    Public Property Code() As String
        Get
            Return _code
        End Get
        Set
            _code = Value
            OnPropertyChanged("Code")
        End Set
    End Property

    Public Property Color() As Windows.UI.Color
        Get
            Return m_Color
        End Get
        Set
            m_Color = Value
        End Set
    End Property
    Private m_Color As Windows.UI.Color


    Public Property Visibility() As C1.Chart.SeriesVisibility
        Get
            Return If(MovingAverage Is Nothing OrElse Series Is Nothing, C1.Chart.SeriesVisibility.Hidden, MovingAverage.Visibility And Series.Visibility)
        End Get
        Set
            Series.Visibility = Value
            If ChartViewModel.Instance.IsShowMovingAverage Then
                MovingAverage.Visibility = Value
            Else
                MovingAverage.Visibility = C1.Chart.SeriesVisibility.Hidden
            End If
            OnPropertyChanged("Visibility")
        End Set
    End Property

    Friend Property DataSource() As QuoteData
        Get
            Return m_DataSource
        End Get
        Set
            m_DataSource = Value
        End Set
    End Property
    Private m_DataSource As QuoteData

    Friend Property Series() As C1.Xaml.Chart.Series
        Get
            Return m_Series
        End Get
        Set
            m_Series = Value
        End Set
    End Property
    Private m_Series As C1.Xaml.Chart.Series

    Friend Property MovingAverage() As C1.Xaml.Chart.Finance.MovingAverage
        Get
            Return m_MovingAverage
        End Get
        Set
            m_MovingAverage = Value
        End Set
    End Property
    Private m_MovingAverage As C1.Xaml.Chart.Finance.MovingAverage

    Public Sub Dispose() Implements IDisposable.Dispose
        Me.Series.Dispose()
        Me.MovingAverage.Dispose()
        Me.DataSource = Nothing
    End Sub
End Class