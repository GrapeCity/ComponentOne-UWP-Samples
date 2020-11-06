' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
#Region "ClassCategoryCtrl"
Partial Public NotInheritable Class CategoryCtrl
    Inherits UserControl
#Region "Constructor"
    Public Sub New(imageUri As String, name As String)
        Me.InitializeComponent()
        Me.imgCategory.Source = New BitmapImage(New Uri(imageUri))
        Me.Name = name
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property ImgButton() As Button
        Get
            Return imgBtn
        End Get
    End Property
#End Region
End Class
#End Region