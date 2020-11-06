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

    Public Shared ReadOnly Property CatalogToolLabel() As String
        Get
            Return _loader.GetString("CatalogToolLabel")
        End Get
    End Property

    Public Shared ReadOnly Property CloseButtonToolTip() As String
        Get
            Return _loader.GetString("CloseButtonToolTip")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorFormat() As String
        Get
            Return _loader.GetString("ErrorFormat")
        End Get
    End Property

    Public Shared ReadOnly Property ReportErrorFormat() As String
        Get
            Return _loader.GetString("ReportErrorFormat")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorTitle() As String
        Get
            Return _loader.GetString("ErrorTitle")
        End Get
    End Property
End Class