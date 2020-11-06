Public Class QuoteRange
    Public Property PriceMin() As Double
        Get
            Return m_PriceMin
        End Get
        Set
            m_PriceMin = Value
        End Set
    End Property
    Private m_PriceMin As Double
    Public Property PriceMax() As Double
        Get
            Return m_PriceMax
        End Get
        Set
            m_PriceMax = Value
        End Set
    End Property
    Private m_PriceMax As Double
    Public Property VolumeMin() As Double
        Get
            Return m_VolumeMin
        End Get
        Set
            m_VolumeMin = Value
        End Set
    End Property
    Private m_VolumeMin As Double
    Public Property VolumeMax() As Double
        Get
            Return m_VolumeMax
        End Get
        Set
            m_VolumeMax = Value
        End Set
    End Property
    Private m_VolumeMax As Double
End Class