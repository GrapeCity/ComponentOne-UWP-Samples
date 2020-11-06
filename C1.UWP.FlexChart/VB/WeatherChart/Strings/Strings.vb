Imports Windows.ApplicationModel.Resources

Public Class Strings
    Public Shared _loader As ResourceLoader = ResourceLoader.GetForViewIndependentUse("Resources")

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
End Class