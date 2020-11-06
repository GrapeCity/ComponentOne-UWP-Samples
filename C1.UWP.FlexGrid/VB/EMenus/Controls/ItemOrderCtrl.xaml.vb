Imports Windows.UI
Imports Windows.UI.Xaml.Shapes

' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
#Region "ClassItemOrderCtrl"
Partial Public NotInheritable Class ItemOrderCtrl
    Inherits UserControl
#Region "Contructor"
    Public Sub New(imageuri As String, itemText As String, description As String, Rating As Integer, iconVeg As Boolean, iconSpecial As Boolean,
            prizeRegular As Double, prizeMedium As Double, prizeLarge As Double)
        Me.InitializeComponent()
        If System.IO.File.Exists(imageuri) Then
            Me.imgItem.Source = New BitmapImage(New Uri("ms-appx:///" + imageuri))
        Else
            Me.imgItem.Source = New BitmapImage(New Uri("ms-appx:///Assets/Images/ImageNotFound.png"))
        End If
        Me.txtName.Text = itemText
        Me.txtDescription.Text = description
        Me.txtRPrize.Text += ": " + prizeRegular.ToString()
        Me.txtMPrize.Text += ": " + prizeMedium.ToString()
        Me.txtLPrize.Text += ": " + prizeLarge.ToString()
        Me.txtQtyTextBox.Text = "1"
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

#Region "properties"
    Public ReadOnly Property BtnAddToCart() As Button
        Get
            Return btnAddToCartButton
        End Get
    End Property
    Public ReadOnly Property BtnMinus() As Button
        Get
            Return btnMinusButton
        End Get
    End Property
    Public ReadOnly Property BtnPlus() As Button
        Get
            Return btnPlusButton
        End Get
    End Property
    Public ReadOnly Property TextQty() As TextBox
        Get
            Return txtQtyTextBox
        End Get
    End Property
    Public ReadOnly Property TglBtnRegular() As ToggleButton
        Get
            Return tglBtnRegularButton
        End Get
    End Property
    Public ReadOnly Property TglBtnMedium() As ToggleButton
        Get
            Return tglBtnMediumButton
        End Get
    End Property
    Public ReadOnly Property TglBtnLarge() As ToggleButton
        Get
            Return tglBtnLargeButton
        End Get
    End Property
#End Region
End Class
#End Region