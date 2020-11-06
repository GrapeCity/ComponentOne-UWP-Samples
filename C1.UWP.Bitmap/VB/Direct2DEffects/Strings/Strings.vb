Imports Windows.ApplicationModel.Resources

Public Class Strings
    Shared _loader As ResourceLoader

    Shared Sub New()
        Try
            _loader = ResourceLoader.GetForCurrentView("Resources")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Public Shared ReadOnly Property EffectsButtonText() As String
        Get
            Return _loader.GetString("EffectsButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property OriginalButtonText() As String
        Get
            Return _loader.GetString("OriginalButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property GaussianBlurButtonText() As String
        Get
            Return _loader.GetString("GaussianBlurButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property SharpenButtonText() As String
        Get
            Return _loader.GetString("SharpenButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property HorizontalSmearButtonText() As String
        Get
            Return _loader.GetString("HorizontalSmearButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property ShadowButtonText() As String
        Get
            Return _loader.GetString("ShadowButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property DisplacementMapButtonText() As String
        Get
            Return _loader.GetString("DisplacementMapButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property EmbossButtonText() As String
        Get
            Return _loader.GetString("EmbossButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property EdgeDetectButtonText() As String
        Get
            Return _loader.GetString("EdgeDetectButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property SepiaButtonText() As String
        Get
            Return _loader.GetString("SepiaButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property ExportButtonText() As String
        Get
            Return _loader.GetString("ExportButtonText")
        End Get
    End Property

    Public Shared ReadOnly Property StoneInscription() As String
        Get
            Return _loader.GetString("StoneInscription")
        End Get
    End Property

End Class
