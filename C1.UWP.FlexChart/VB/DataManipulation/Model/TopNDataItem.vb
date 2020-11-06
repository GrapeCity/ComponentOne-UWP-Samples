Public Class SmartPhoneVendor
    Public Property Name() As String
        Get
            Return m_Name
        End Get
        Set
            m_Name = Value
        End Set
    End Property
    Private m_Name As String
    Public Property Shipments() As Double
        Get
            Return m_Shipments
        End Get
        Set
            m_Shipments = Value
        End Set
    End Property
    Private m_Shipments As Double
End Class
