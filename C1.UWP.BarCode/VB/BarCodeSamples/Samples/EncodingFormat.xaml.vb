Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml
Imports C1.BarCode

''' <summary>
''' Class defined to store the properties of a category
''' </summary>
Class Category
    Public Property Key() As String
        Get
            Return m_Key
        End Get
        Set
            m_Key = Value
        End Set
    End Property
    Private m_Key As String
    Public Property Value() As String
        Get
            Return m_Value
        End Get
        Set
            m_Value = Value
        End Set
    End Property
    Private m_Value As String
    Public Property Format() As Format
        Get
            Return m_Format
        End Get
        Set
            m_Format = Value
        End Set
    End Property
    Private m_Format As Format
    Public Sub New(key1 As String, value1 As String, format1 As Format)
        Key = key1
        Value = value1
        Format = format1
    End Sub
End Class

Partial Public NotInheritable Class EncodingFormat
    Inherits Page
    Private CategoriesData As New List(Of Category)()
    Private CodeTypes As New Dictionary(Of String, CodeType)()
    Public Sub New()
        Me.InitializeComponent()

        AddHandler Loaded, AddressOf OnLoaded
    End Sub

    Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        CreateCodeTypes()
        CreateCategories()
        Me.barCodeTypes.DataContext = CodeTypes
        Me.categories.DataContext = CategoriesData
        Me.barCodeTypes.SelectedItem = CodeTypes.ElementAt(0)
        Me.categories.SelectedItem = CategoriesData.ElementAt(3)
    End Sub

    Private Sub CreateCodeTypes()
        If CodeTypes.Count = 0 Then
            CodeTypes.Add("../Assets/QRCode.png", CodeType.QRCode)
            CodeTypes.Add("../Assets/DataMatrix.png", CodeType.DataMatrix)
            CodeTypes.Add("../Assets/PDF417.png", CodeType.Pdf417)
            CodeTypes.Add("../Assets/Code39X.png", CodeType.Code39x)
        End If
    End Sub

    Private Sub CreateCategories()
        If CategoriesData.Count = 0 Then
            CategoriesData.Add(New Category("../Assets/Email.png", Strings.EmailMark, Format.Email))
            CategoriesData.Add(New Category("../Assets/Text.png", Strings.TextMark, Format.Text))
            CategoriesData.Add(New Category("../Assets/Url.png", Strings.UrlMark, Format.Url))
            CategoriesData.Add(New Category("../Assets/VCard.png", Strings.VCardMark, Format.VCard))
        End If
    End Sub

    Private Sub barCodeTypes_SelectionChanged(sender As Object, e As EventArgs)
        Dim listBox As C1ListBox = TryCast(sender, C1ListBox)
        Dim selectedItem As Object = listBox.SelectedItem
        If selectedItem IsNot Nothing Then
            Dim item As KeyValuePair(Of String, CodeType) = CType(selectedItem, KeyValuePair(Of String, CodeType))
            CurrentCodeType = CType(item.Value, CodeType)
        End If
    End Sub

    Private Sub encodingTypes_SelectionChanged(sender As Object, e As EventArgs)
        Dim listBox As C1ListBox = TryCast(sender, C1ListBox)
        Dim selectedItem As Object = listBox.SelectedItem
        If selectedItem IsNot Nothing Then
            Dim item As Category = CType(selectedItem, Category)
            CurrentCategory = item.Format
        End If
    End Sub

    Public Property ShowStatus() As Visibility
        Get
            Return CType(GetValue(ShowStatusProperty), Visibility)
        End Get
        Set
            SetValue(ShowStatusProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly ShowStatusProperty As DependencyProperty = DependencyProperty.Register("ShowStatus", GetType(Visibility), GetType(EncodingFormat), New PropertyMetadata(Visibility.Collapsed))

    Public Property CurrentCodeType() As CodeType
        Get
            Return CType(GetValue(CurrentCodeTypeProperty), CodeType)
        End Get
        Set
            SetValue(CurrentCodeTypeProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly CurrentCodeTypeProperty As DependencyProperty = DependencyProperty.Register("CurrentCodeType", GetType(CodeType), GetType(EncodingFormat), New PropertyMetadata(CodeType.QRCode, AddressOf OnCurrentCodeTypePropertyChanged))

    Private Shared Sub OnCurrentCodeTypePropertyChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim encodingFormat As EncodingFormat = TryCast(d, EncodingFormat)
        If encodingFormat.CurrentCodeType = CodeType.QRCode AndAlso encodingFormat.CurrentCategory = Format.Url Then
            encodingFormat.ShowStatus = Visibility.Visible
        Else
            encodingFormat.ShowStatus = Visibility.Collapsed
        End If
    End Sub

    Public Property CurrentCategory() As Format
        Get
            Return CType(GetValue(CurrentCategoryProperty), Format)
        End Get
        Set
            SetValue(CurrentCategoryProperty, Value)
        End Set
    End Property


    Public Shared ReadOnly CurrentCategoryProperty As DependencyProperty = DependencyProperty.Register("CurrentCategory", GetType(Format), GetType(EncodingFormat), New PropertyMetadata(Format.Url, AddressOf OnCurrentCategoryPropertyChanged))

    Private Shared Sub OnCurrentCategoryPropertyChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim category As EncodingFormat = TryCast(d, EncodingFormat)

        If category.CurrentCodeType = CodeType.QRCode AndAlso category.CurrentCategory = Format.Url Then
            category.ShowStatus = Visibility.Visible
        Else
            category.ShowStatus = Visibility.Collapsed
        End If
    End Sub
End Class