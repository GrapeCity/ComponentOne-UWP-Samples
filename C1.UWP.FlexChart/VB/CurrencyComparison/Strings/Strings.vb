Imports Windows.ApplicationModel.Resources

Public Class Strings
    Public Shared _loader As ResourceLoader = ResourceLoader.GetForViewIndependentUse("Resources")

    Public Shared ReadOnly Property BaseCurrency() As String
        Get
            Return _loader.GetString("BaseCurrency")
        End Get
    End Property

    Public Shared ReadOnly Property Currencies() As String
        Get
            Return _loader.GetString("Currencies")
        End Get
    End Property

    Public Shared ReadOnly Property Both() As String
        Get
            Return _loader.GetString("Both")
        End Get
    End Property

    Public Shared ReadOnly Property ExchangeRate() As String
        Get
            Return _loader.GetString("ExchangeRate")
        End Get
    End Property

    Public Shared ReadOnly Property PercentageChange() As String
        Get
            Return _loader.GetString("PercentageChange")
        End Get
    End Property

    Public Shared ReadOnly Property Y1Title() As String
        Get
            Return _loader.GetString("Y1Title")
        End Get
    End Property

    Public Shared ReadOnly Property Y2Title() As String
        Get
            Return _loader.GetString("Y2Title")
        End Get
    End Property

    Public Shared ReadOnly Property Measure() As String
        Get
            Return _loader.GetString("Measure")
        End Get
    End Property

    Public Shared ReadOnly Property FiveD() As String
        Get
            Return _loader.GetString("FiveD")
        End Get
    End Property

    Public Shared ReadOnly Property TenD() As String
        Get
            Return _loader.GetString("TenD")
        End Get
    End Property

    Public Shared ReadOnly Property OneM() As String
        Get
            Return _loader.GetString("OneM")
        End Get
    End Property

    Public Shared ReadOnly Property SixM() As String
        Get
            Return _loader.GetString("SixM")
        End Get
    End Property

    Public Shared ReadOnly Property OneY() As String
        Get
            Return _loader.GetString("OneY")
        End Get
    End Property

    Public Shared ReadOnly Property FiveY() As String
        Get
            Return _loader.GetString("FiveY")
        End Get
    End Property

    Public Shared ReadOnly Property TenY() As String
        Get
            Return _loader.GetString("TenY")
        End Get
    End Property
End Class