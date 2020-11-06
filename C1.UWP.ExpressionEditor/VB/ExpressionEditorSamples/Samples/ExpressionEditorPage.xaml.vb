Imports C1.Xaml.ExpressionEditor
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Diagnostics
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class ExpressionEditorPage
    Inherits Page
    Private _backPageType As Type = Nothing

    Public Sub New()
        Me.InitializeComponent()
        AddHandler expressionEditor.OkClick, AddressOf Editor_OkClick
        AddHandler expressionEditor.CancelClick, AddressOf Editor_CancelClick
    End Sub

    Private Sub Editor_CancelClick(sender As Object, e As RoutedEventArgs)
        If Me._backPageType IsNot Nothing Then
            Me.Frame.Navigate(_backPageType)
        End If
    End Sub

    Private Sub Editor_OkClick(sender As Object, e As RoutedEventArgs)
        If Me._backPageType IsNot Nothing Then
            PageCache.SetCacheExpression(expressionEditor.Expression)
            Me.Frame.Navigate(Me._backPageType)
        End If
    End Sub

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        Dim parameter As Object = e.Parameter
        If parameter IsNot Nothing Then
            Dim editor As Object = TryCast(parameter, C1ExpressionEditor)
            If editor IsNot Nothing Then
                _backPageType = TryCast(editor.Tag, Type)
                expressionEditor.DataSource = editor.DataSource
                expressionEditor.Expression = editor.Expression
            End If
        End If
    End Sub
End Class
