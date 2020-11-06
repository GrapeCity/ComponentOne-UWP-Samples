Public Class Quote
    Public Sub New(value As Reference)
        referenceValue = value
    End Sub

    Public Property [date]() As DateTime
        Get
            Return m_date
        End Get
        Set
            m_date = Value
        End Set
    End Property
    Private m_date As DateTime
    Public Property high() As Double
        Get
            Return m_high
        End Get
        Set
            m_high = Value
        End Set
    End Property
    Private m_high As Double
    Public Property low() As Double
        Get
            Return m_low
        End Get
        Set
            m_low = Value
        End Set
    End Property
    Private m_low As Double
    Public Property open() As Double
        Get
            Return m_open
        End Get
        Set
            m_open = Value
        End Set
    End Property
    Private m_open As Double
    Public Property close() As Double
        Get
            Return m_close
        End Get
        Set
            m_close = Value
        End Set
    End Property
    Private m_close As Double
    Public Property volume() As Double
        Get
            Return m_volume
        End Get
        Set
            m_volume = Value
        End Set
    End Property
    Private m_volume As Double
    Public Property events() As String
        Get
            Return m_events
        End Get
        Set
            m_events = Value
        End Set
    End Property
    Private m_events As String

    Friend Property referenceValue() As Reference
        Get
            Return m_referenceValue
        End Get
        Set
            m_referenceValue = Value
        End Set
    End Property
    Private m_referenceValue As Reference

    Public ReadOnly Property percentage() As Double
        Get
            Dim reValue As Double = referenceValue.Value
            Return If(reValue = 0, 0.75, (Me.close - reValue) / reValue)
        End Get
    End Property
End Class