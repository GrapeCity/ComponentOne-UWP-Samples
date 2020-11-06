Imports Windows.ApplicationModel.Resources

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForViewIndependentUse("Resources")

    Public Shared ReadOnly Property FailedToShowReport() As String
        Get
            Return _loader.GetString("FailedToShowReport")
        End Get
    End Property

    Public Shared ReadOnly Property lblReport_Text() As String
        Get
            Return _loader.GetString("lblReport_Text")
        End Get
    End Property
End Class
