Public Class AggregateItem
    Public Property Year() As Integer
        Get
            Return m_Year
        End Get
        Set
            m_Year = Value
        End Set
    End Property
    Private m_Year As Integer
    Public Property Q() As Integer
        Get
            Return m_Q
        End Get
        Set
            m_Q = Value
        End Set
    End Property
    Private m_Q As Integer
    Public Property M() As String
        Get
            Return m_M
        End Get
        Set
            m_M = Value
        End Set
    End Property
    Private m_M As String
    Public Property Value() As Double
        Get
            Return m_Value
        End Get
        Set
            m_Value = Value
        End Set
    End Property
    Private m_Value As Double
End Class
