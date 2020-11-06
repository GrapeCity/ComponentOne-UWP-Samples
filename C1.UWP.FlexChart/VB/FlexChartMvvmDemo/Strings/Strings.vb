Imports Windows.ApplicationModel.Resources

Public Class Strings
    Public Shared _loader As ResourceLoader = ResourceLoader.GetForViewIndependentUse("Resources")

    Public Shared ReadOnly Property Title() As String
        Get
            Return _loader.GetString("Title")
        End Get
    End Property

    Public Shared ReadOnly Property GroupBy() As String
        Get
            Return _loader.GetString("GroupBy")
        End Get
    End Property

    Public Shared ReadOnly Property Aggregate() As String
        Get
            Return _loader.GetString("Aggregate")
        End Get
    End Property

    Public Shared ReadOnly Property [Select]() As String
        Get
            Return _loader.GetString("Select")
        End Get
    End Property

End Class