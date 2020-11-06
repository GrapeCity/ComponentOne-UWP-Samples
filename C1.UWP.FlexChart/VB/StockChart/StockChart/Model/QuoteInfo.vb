Imports Windows.UI

Public Class QuoteInfo
    Public Property Code() As String
        Get
            Return m_Code
        End Get
        Set
            m_Code = Value
        End Set
    End Property
    Private m_Code As String
    Public Property Color() As Color
        Get
            Return m_Color
        End Get
        Set
            m_Color = Value
        End Set
    End Property
    Private m_Color As Color
    Public Property Value() As Double
        Get
            Return m_Value
        End Get
        Set
            m_Value = Value
        End Set
    End Property
    Private m_Value As Double
    Public Property Volume() As Integer
        Get
            Return m_Volume
        End Get
        Set
            m_Volume = Value
        End Set
    End Property
    Private m_Volume As Integer
    Public Property [Date]() As DateTime
        Get
            Return m_Date
        End Get
        Set
            m_Date = Value
        End Set
    End Property
    Private m_Date As DateTime
End Class