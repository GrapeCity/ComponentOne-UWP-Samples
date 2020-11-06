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
Imports C1.Xaml.ExpressionEditor
Imports C1.Xaml.FlexGrid

' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class SupportGrouping
    Inherits Page
    Private testeditor As New C1ExpressionEditor()
    Public View As C1CollectionView

    Public Sub New()
        Me.InitializeComponent()

        View = New C1CollectionView(Product.GetData())

        flexGrid.ItemsSource = View

        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            InitalizeDesktop()
        End If

        AddHandler flexGrid.Loaded, AddressOf FlexGrid_Loaded
    End Sub

    Sub InitalizeDesktop()
        AddHandler editor.OkClick, AddressOf Editor_OkClick
        AddHandler editor.CancelClick, AddressOf Editor_CancelClick
        editor.DataSource = flexGrid.CollectionView.FirstOrDefault()
        editor.Expression = Expressions.GetExpression()
    End Sub

    Private Sub FlexGrid_Loaded(sender As Object, e As RoutedEventArgs)
        For Each column As Column In flexGrid.Columns
            If column.ColumnName.Equals("CustomField1") OrElse column.ColumnName.Equals("CustomField2") Then
                column.Visible = False
            End If
        Next

        Dim expression As Object = PageCache.GetCacheExpression()
        If expression <> "" Then
            PageCache.SetCacheExpression("")
            testeditor.Expression = expression
            testeditor.DataSource = flexGrid.CollectionView.FirstOrDefault()
            If testeditor.IsValid Then
                Dim group As New ExpressionGroupDescription()
                group.Expression = testeditor.Expression
                View.GroupDescriptions.Add(group)
            End If
        End If
    End Sub

    Private Sub Editor_CancelClick(sender As Object, e As RoutedEventArgs)
        View.GroupDescriptions.Clear()
    End Sub

    Private Sub Editor_OkClick(sender As Object, e As RoutedEventArgs)
        If editor.IsValid Then
            Dim expression As New ExpressionGroupDescription()
            expression.Expression = editor.Expression
            View.GroupDescriptions.Add(expression)
        End If
    End Sub

    Private Sub group_Click(sender As Object, e As RoutedEventArgs)
        Dim obj As Object = flexGrid.CollectionView.FirstOrDefault()
        If obj IsNot Nothing Then
            testeditor.DataSource = obj
        End If
        testeditor.Expression = Expressions.GetExpression()
        NavigateToExpressionEditor()
    End Sub

    Private Sub NavigateToExpressionEditor()
        If testeditor IsNot Nothing Then
            testeditor.Tag = GetType(SupportGrouping)
            Me.Frame.Navigate(GetType(ExpressionEditorPage), testeditor)
        End If
    End Sub
End Class
