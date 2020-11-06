Imports Windows.UI
Imports Windows.UI.Xaml.Shapes

' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
#Region "ClassItemImageCtrl"
Partial Public NotInheritable Class ItemImageCtrl
    Inherits UserControl
#Region "Constructor"
    Public Sub New(imgUri As String, itemText As String, Rating As Integer, isEnabled As Boolean, iconVeg As Boolean, iconSpecial As Boolean)
        Me.InitializeComponent()
        If System.IO.File.Exists(imgUri) Then
            Me.imgItem.Source = New BitmapImage(New Uri("ms-appx:///" + imgUri))
        Else
            Me.imgItem.Source = New BitmapImage(New Uri("ms-appx:///Assets/Images/ImageNotFound.png"))
        End If
        Me.txtName.Text = itemText
        Me.imgBtn.IsEnabled = isEnabled
        Dim i As Integer = 0
        While i < VisualTreeHelper.GetChildrenCount(stackPanelStar)
            Dim child As Object = VisualTreeHelper.GetChild(stackPanelStar, i)
            Dim path As Path = (TryCast(child, Path))
            path.Fill = New SolidColorBrush(Color.FromArgb(255, 236, 157, 9))
            If i = Rating - 1 Then
                Exit While
            End If
            i += 1
        End While
        If Not iconSpecial Then
            gridIconSpecial.Visibility = Visibility.Collapsed
        End If
        If Not iconVeg Then
            gridIconVeg.Visibility = Visibility.Collapsed
        Else
            gridIconNonVeg.Visibility = Visibility.Collapsed
        End If
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