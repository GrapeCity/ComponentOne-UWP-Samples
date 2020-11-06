Imports System
Imports Windows.ApplicationModel.Resources
Imports System.Diagnostics

Public Class Strings
    Shared _loader As ResourceLoader

    Shared Sub New()
        Try
            _loader = ResourceLoader.GetForCurrentView("Resources")
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Sub

    Public Shared ReadOnly Property OpenToolLabel As String
        Get
            Return _loader.GetString("OpenToolLabel")
        End Get
    End Property

    Public Shared ReadOnly Property CloseToolLabel As String
        Get
            Return _loader.GetString("CloseToolLabel")
        End Get
    End Property

    Public Shared ReadOnly Property UseSystemRenderingToolLabel As String
        Get
            Return _loader.GetString("UseSystemRendering")
        End Get
    End Property

    Public Shared ReadOnly Property ErrorTitle As String
        Get
            Return _loader.GetString("ErrorTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PdfErrorFormat As String
        Get
            Return _loader.GetString("PdfErrorFormat")
        End Get
    End Property

    Public Shared ReadOnly Property PasswordTitleLabel As String
        Get
            Return _loader.GetString("PasswordTitleLabel")
        End Get
    End Property

    Public Shared ReadOnly Property PasswordOpenLabel As String
        Get
            Return _loader.GetString("PasswordOpenLabel")
        End Get
    End Property

    Public Shared ReadOnly Property PasswordCancelLabel As String
        Get
            Return _loader.GetString("PasswordCancelLabel")
        End Get
    End Property

    Public Shared ReadOnly Property ShowPasswordCheck As String
        Get
            Return _loader.GetString("ShowPasswordCheck")
        End Get
    End Property

End Class
