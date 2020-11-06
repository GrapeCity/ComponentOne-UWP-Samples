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
Imports C1.Xaml
Imports C1.Xaml.FlexGrid

' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class SupportFilter
    Inherits Page
    Private testeditor As New C1ExpressionEditor()
    Public View As C1CollectionView

    Public Sub New()
        Me.InitializeComponent()

        View = New C1CollectionView(Product.GetData())

        flexGrid.ItemsSource = View

        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            InitalizeDesktop()
        Else
            InitalizeMobile()
        End If
        AddHandler flexGrid.Loaded, AddressOf FlexGrid_Loaded
    End Sub

    Sub InitalizeDesktop()
        editor.DataSource = flexGrid.CollectionView.FirstOrDefault()
        editor.Expression = "[Price] > 1000"
        AddHandler Me.editor.ExpressionChanged, AddressOf ExpressionEditor_ExpressionChanged
    End Sub

    Sub InitalizeMobile()
        Dim expression As Object = PageCache.GetCacheExpression()
        If expression <> "" Then
            c1editor.Expression = expression
        Else
            c1editor.Expression = "[Price] > 1000"
        End If
        c1editor.DataSource = flexGrid.CollectionView.FirstOrDefault()
    End Sub

    Private Sub FlexGrid_Loaded(sender As Object, e As RoutedEventArgs)
        For Each column As Column In flexGrid.Columns
            If column.ColumnName.Equals("CustomField1") OrElse column.ColumnName.Equals("CustomField2") Then
                column.Visible = False
            End If
        Next

        Dim expression As Object = PageCache.GetCacheExpression()
        If expression <> testeditor.Expression Then
            PageCache.SetCacheExpression("")
            testeditor.Expression = expression
            testeditor.DataSource = flexGrid.CollectionView.FirstOrDefault()
            If testeditor.IsValid Then
                View.Filter = New Predicate(Of Object)(AddressOf Contains)
                View.Refresh()
            End If
        End If
    End Sub

    Private Sub ExpressionEditor_ExpressionChanged(sender As Object, e As EventArgs)
        testeditor.Expression = editor.Expression
        testeditor.DataSource = editor.DataSource
        If testeditor.IsValid Then
            View.Filter = New Predicate(Of Object)(AddressOf Contains)
            View.Refresh()
        End If
    End Sub

    Private Function Contains(obj As Object) As Boolean
        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            testeditor.Expression = editor.Expression
        Else
            testeditor.Expression = c1editor.Expression
        End If
        testeditor.DataSource = TryCast(obj, Product)
        Dim value As Object = testeditor.Evaluate()
        Dim ret As Object = True
        If value IsNot Nothing Then
            [Boolean].TryParse(value.ToString(), ret)
        End If
        Return ret
    End Function

    Private Sub filter_Click(sender As Object, e As RoutedEventArgs)
        Dim obj As Object = flexGrid.CollectionView.FirstOrDefault()
        If obj IsNot Nothing Then
            testeditor.DataSource = obj
        End If
        testeditor.Expression = c1editor.Expression
        NavigateToExpressionEditor()
    End Sub

    Private Sub NavigateToExpressionEditor()
        If testeditor IsNot Nothing Then
            testeditor.Tag = GetType(SupportFilter)
            Me.Frame.Navigate(GetType(ExpressionEditorPage), testeditor)
        End If
    End Sub
End Class