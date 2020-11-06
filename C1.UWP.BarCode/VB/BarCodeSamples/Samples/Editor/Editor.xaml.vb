Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Phone.UI.Input
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

Partial Public NotInheritable Class Editor
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public Property CurrentCategory() As Format
        Get
            Return CType(GetValue(CurrentCategoryProperty), Format)
        End Get
        Set
            SetValue(CurrentCategoryProperty, Value)
        End Set
    End Property


    Public Shared ReadOnly CurrentCategoryProperty As DependencyProperty = DependencyProperty.Register("CurrentCategory", GetType(Format), GetType(Editor), New PropertyMetadata(Format.Url, AddressOf OnCurrentCategoryPropertyChanged))

    Private Shared Sub OnCurrentCategoryPropertyChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim editor As Editor = TryCast(d, Editor)
        If e.NewValue IsNot Nothing Then
            Dim newValue As Format = CType(e.NewValue, Format)
            editor.CurrentEditorControl.Children.Clear()
            Dim control As UserControl = Nothing
            Select Case newValue
                Case Format.Url
                    control = New Url()
                    editor.DataContext = New UrlEntity() With {
                        .Url = Strings.UrlInitialValue
                    }
                    Exit Select
                Case Format.Text
                    control = New Text()
                    editor.DataContext = New TextEntity() With {
                        .Text = Strings.TextInitialValue
                    }
                    Exit Select
                Case Format.Email
                    control = New Email()
                    editor.DataContext = New EmailEntity() With {
                        .Address = Strings.EmailAddressInitialValue
                    }
                    Exit Select
                Case Format.VCard
                    control = New VCard()
                    editor.DataContext = New VCardEntity() With {
                        .Prefix = Strings.VCardPrefixInitialValue,
                        .FirstName = Strings.VCardFirstNameInitialValue,
                        .LastName = Strings.VCardLastNameInitialValue,
                        .HomeCountry = Strings.VCardHomeCountryInitialValue,
                        .Suffix = Strings.VCardSuffixInitialValue,
                        .FullName = Strings.VCardFullNameSuffixInitialValue,
                        .Title = Strings.VCardTitleInitialValue,
                        .Role = Strings.VCardRoleInitialValue
                    }
                    Exit Select
            End Select
            If control IsNot Nothing Then
                editor.CurrentEditorControl.Children.Add(control)
            End If
        End If
    End Sub

    'this is for Phone
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        Dim format As Format = CType(e.Parameter, Format)
        Dim formatvalue As String = format.ToString()

        Select Case format
            Case Format.Email
                editorContainer.Navigate(GetType(Email), New EmailEntity() With
                    {
                        .Address = Strings.EmailAddressInitialValue
                    })
                Exit Select
            Case Format.Text
                editorContainer.Navigate(GetType(Text), New TextEntity() With
                    {
                        .Text = Strings.TextInitialValue
                    })
                Exit Select
            Case Format.Url
                editorContainer.Navigate(GetType(Url), New UrlEntity() With
                    {
                        .Url = Strings.UrlInitialValue
                    })
                Exit Select
            Case Format.VCard
                editorContainer.Navigate(GetType(VCard), New VCardEntity() With
                    {
                        .Prefix = Strings.VCardPrefixInitialValue,
                        .FirstName = Strings.VCardFirstNameInitialValue,
                        .LastName = Strings.VCardLastNameInitialValue,
                        .HomeCountry = Strings.VCardHomeCountryInitialValue,
                        .Suffix = Strings.VCardSuffixInitialValue,
                        .FullName = Strings.VCardFullNameSuffixInitialValue,
                        .Title = Strings.VCardTitleInitialValue,
                        .Role = Strings.VCardRoleInitialValue,
                        .Nickname = Strings.VCardNicknameInitialValue
                    })
                Exit Select
        End Select
    End Sub

    Private Sub GenerateBarCode(sender As Object, e As RoutedEventArgs)
        Dim text As String = String.Empty
        Dim editor As UserControl = TryCast(editorContainer.Content, UserControl)
        If editor IsNot Nothing Then
            Dim entity As Entity = TryCast(editor.DataContext, Entity)
            If entity IsNot Nothing Then
                text = entity.EncodingText
            End If
            Frame.Navigate(GetType(PhoneBarCodePage), text)
        End If
    End Sub
End Class