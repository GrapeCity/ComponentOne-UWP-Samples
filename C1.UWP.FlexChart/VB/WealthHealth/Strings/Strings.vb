Imports Windows.ApplicationModel.Resources

Public Class Strings
    Public Shared _loader As ResourceLoader = ResourceLoader.GetForViewIndependentUse("Resources")

    Public Shared ReadOnly Property TxtTip() As String
        Get
            Return _loader.GetString("TxtTip")
        End Get
    End Property

    Public Shared ReadOnly Property TxtTrack() As String
        Get
            Return _loader.GetString("TxtTrack")
        End Get
    End Property

    Public Shared ReadOnly Property SubTitle() As String
        Get
            Return _loader.GetString("SubTitle")
        End Get
    End Property

    Public Shared ReadOnly Property Description() As String
        Get
            Return _loader.GetString("Description")
        End Get
    End Property

    Public Shared ReadOnly Property Title() As String
        Get
            Return _loader.GetString("Title")
        End Get
    End Property

    Public Shared ReadOnly Property AxisXTitle() As String
        Get
            Return _loader.GetString("AxisXTitle")
        End Get
    End Property

    Public Shared ReadOnly Property AxisYTitle() As String
        Get
            Return _loader.GetString("AxisYTitle")
        End Get
    End Property
End Class
