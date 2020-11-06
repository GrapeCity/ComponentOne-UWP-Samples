Imports Windows.ApplicationModel.Resources

Public Class Strings
    Public Shared _loader As ResourceLoader = ResourceLoader.GetForViewIndependentUse("Resources")

    Public Shared ReadOnly Property ZoomMode() As String
        Get
            Return _loader.GetString("ZoomMode")
        End Get
    End Property

    Public Shared ReadOnly Property TranslationMode() As String
        Get
            Return _loader.GetString("TranslationMode")
        End Get
    End Property

    Public Shared ReadOnly Property ResetBtn() As String
        Get
            Return _loader.GetString("ResetBtn")
        End Get
    End Property

    Public Shared ReadOnly Property Description() As String
        Get
            Return _loader.GetString("Description")
        End Get
    End Property

    Public Shared ReadOnly Property Header() As String
        Get
            Return _loader.GetString("Header")
        End Get
    End Property

    Public Shared ReadOnly Property Title() As String
        Get
            Return _loader.GetString("Title")
        End Get
    End Property
End Class