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
Imports C1.Xaml.ExpressionEditor

' The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

Partial Public NotInheritable Class ExpressionEditorEE
    Inherits UserControl
#Region "** events"

    Public Event OkClick As EventHandler(Of RoutedEventArgs)
    Public Event CancelClick As EventHandler(Of RoutedEventArgs)

    ''' <summary>
    ''' Occurs when expression string changed.
    ''' </summary>
    Public Event ExpressionChanged As EventHandler
    ''' <summary>
    ''' Rises the <see cref="ExpressionChanged"/> event.
    ''' </summary>
    Protected Sub OnExpressionChanged(e As EventArgs)
        RaiseEvent ExpressionChanged(Me, e)
    End Sub

    Private Sub Cancel_Click(sender As Object, e As RoutedEventArgs)
        RaiseEvent CancelClick(sender, e)
    End Sub

    Private Sub Ok_Click(sender As Object, e As RoutedEventArgs)
        RaiseEvent OkClick(sender, e)
    End Sub
#End Region

    '---------------------
#Region "** dependency properties"

    Public Property OKContent() As String
        Get
            Return CType(GetValue(OKContentProperty), String)
        End Get
        Set
            SetValue(OKContentProperty, value)
        End Set
    End Property
    Public Shared ReadOnly OKContentProperty As DependencyProperty = DependencyProperty.Register("OKContent", GetType(String), GetType(ExpressionEditorEE), New PropertyMetadata(CType("OK", String)))

    Public Property CancelContent() As String
        Get
            Return CType(GetValue(CancelContentProperty), String)
        End Get
        Set
            SetValue(CancelContentProperty, value)
        End Set
    End Property
    Public Shared ReadOnly CancelContentProperty As DependencyProperty = DependencyProperty.Register("CancelContent", GetType(String), GetType(ExpressionEditorEE), New PropertyMetadata(CType("Cancel", String)))

    Public Property OperateVisibility() As Visibility
        Get
            Return CType(GetValue(OperateVisibilityProperty), Visibility)
        End Get
        Set
            SetValue(OperateVisibilityProperty, value)
        End Set
    End Property
    Public Shared ReadOnly OperateVisibilityProperty As DependencyProperty = DependencyProperty.Register("OperateVisibility", GetType(Visibility), GetType(ExpressionEditorEE), New PropertyMetadata(Visibility.Visible))

#End Region

    '---------------------
#Region "** ctor"

    Public Sub New()
        InitializeComponent()
    End Sub
#End Region

    '---------------------
#Region "** public interface"
    ''' <summary>
    ''' Gets or sets the object used as the data source.
    ''' </summary>
    Public Property DataSource() As Object
        Get
            Return Me.expressionEditor.DataSource
        End Get
        Set
            Me.expressionEditor.DataSource = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets expression string.
    ''' </summary>
    Public Property Expression() As String
        Get
            Return Me.expressionEditor.Expression
        End Get
        Set
            Me.expressionEditor.Expression = value
        End Set
    End Property

    ''' <summary>
    ''' Gets value that indicates whether the expression is valid.
    ''' </summary>
    Public ReadOnly Property IsValid() As Boolean
        Get
            Return Me.expressionEditor.IsValid
        End Get
    End Property
#End Region

    '---------------------
#Region "** implementation"
    Private Sub ExpressionEditor_ExpressionChanged(sender As Object, e As EventArgs)
        errors.Text = ""
        If Not IsValid Then
            result.Text = ""
            Me.btn_Ok.IsEnabled = False
            Dim editError = Me.expressionEditor.GetErrors().FirstOrDefault()
            If editError IsNot Nothing Then
                errors.Text = editError.FullMessage
            End If
        Else
            Dim value = Me.expressionEditor.Evaluate()
            If value IsNot Nothing Then
                result.Text = value.ToString()
            End If
            Me.btn_Ok.IsEnabled = True
            OnExpressionChanged(e)
        End If
    End Sub
#End Region
End Class

