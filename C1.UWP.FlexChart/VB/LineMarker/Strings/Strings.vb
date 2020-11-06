Imports Windows.ApplicationModel.Resources

Public Class Strings
    Public Shared _loader As ResourceLoader = ResourceLoader.GetForViewIndependentUse("Resources")

    Public Shared ReadOnly Property Description() As String
        Get
            Return _loader.GetString("Description")
        End Get
    End Property

    Public Shared ReadOnly Property LineType() As String
        Get
            Return _loader.GetString("LineType")
        End Get
    End Property

    Public Shared ReadOnly Property Alignment() As String
        Get
            Return _loader.GetString("Alignment")
        End Get
    End Property

    Public Shared ReadOnly Property Interaction() As String
        Get
            Return _loader.GetString("Interaction")
        End Get
    End Property

    Public Shared ReadOnly Property DragContent() As String
        Get
            Return _loader.GetString("DragContent")
        End Get
    End Property

    Public Shared ReadOnly Property DragLines() As String
        Get
            Return _loader.GetString("DragLines")
        End Get
    End Property

    Public Shared ReadOnly Property Auto() As String
        Get
            Return _loader.GetString("Auto")
        End Get
    End Property

    Public Shared ReadOnly Property Right() As String
        Get
            Return _loader.GetString("Right")
        End Get
    End Property

    Public Shared ReadOnly Property Left() As String
        Get
            Return _loader.GetString("Left")
        End Get
    End Property

    Public Shared ReadOnly Property Bottom() As String
        Get
            Return _loader.GetString("Bottom")
        End Get
    End Property

    Public Shared ReadOnly Property Top() As String
        Get
            Return _loader.GetString("Top")
        End Get
    End Property

    Public Shared ReadOnly Property LeftBottom() As String
        Get
            Return _loader.GetString("LeftBottom")
        End Get
    End Property

    Public Shared ReadOnly Property LeftTop() As String
        Get
            Return _loader.GetString("LeftTop")
        End Get
    End Property

    Public Shared ReadOnly Property [True]() As String
        Get
            Return _loader.GetString("True")
        End Get
    End Property

    Public Shared ReadOnly Property [False]() As String
        Get
            Return _loader.GetString("False")
        End Get
    End Property
End Class