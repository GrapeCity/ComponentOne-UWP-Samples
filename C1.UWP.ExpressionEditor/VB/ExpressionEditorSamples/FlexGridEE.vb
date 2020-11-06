Imports C1.Xaml.FlexGrid
Imports C1.Xaml.ExpressionEditor

Public Class FlexGridEE
    Inherits C1FlexGrid
    Implements ISupportExpressions
#Region "Ctor"
    Public Sub New()
        MyBase.New()
        ExpressionEditors = New ExpressionEditorCollection(Me)
    End Sub
#End Region

#Region "ISupportExpressions"

    Public Sub SetCellValue(row As Integer, colName As String, value As Object) Implements ISupportExpressions.SetCellValue
        Me(row, colName) = value
    End Sub

    Public Overloads ReadOnly Property ExpressionEditors() As ExpressionEditorCollection Implements ISupportExpressions.ExpressionEditors

    Private Property ISupportExpressions_ItemsSource As IEnumerable Implements ISupportExpressions.ItemsSource
        Get
            Return Me.ItemsSource
        End Get
        Set(value As IEnumerable)
            Me.ItemsSource = value
        End Set
    End Property
#End Region
End Class
