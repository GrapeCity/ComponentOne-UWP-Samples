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
Imports C1.Xaml.FlexGrid
Imports C1.Xaml.ExpressionEditor

' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class ColumnCalculation
    Inherits Page
    Private testeditor As C1ExpressionEditor

    Public Sub New()
        Me.InitializeComponent()

        Dim items As List(Of Product) = Product.GetData()
        flexGrid.ItemsSource = items

        Dim c1ExpressionEditor1 As New C1ExpressionEditor()
        Dim c1ExpressionEditor2 As New C1ExpressionEditor()
        c1ExpressionEditor1.Expression = "[Price]*0.95"
        c1ExpressionEditor2.Expression = "[Price]*0.8"
        flexGrid.ExpressionEditors.Add("CustomField1", c1ExpressionEditor1)
        flexGrid.ExpressionEditors.Add("CustomField2", c1ExpressionEditor2)

        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            InitalizeDesktop()
            comboBox.SelectedIndex = 0
        Else
            comboBox.SelectedIndex = -1
        End If

        AddHandler flexGrid.Loaded, AddressOf FlexGrid_Loaded
    End Sub

    Sub InitalizeDesktop()
        AddHandler Me.editor.OkClick, AddressOf Editor_OkClick
        AddHandler Me.editor.CancelClick, AddressOf Editor_CancelClick
    End Sub

    Private Sub FlexGrid_Loaded(sender As Object, e As RoutedEventArgs)
        flexGrid.AutoSizeColumns(0, 1, 2)

        Dim field As Object = PageCache.GetCacheField()
        If flexGrid IsNot Nothing AndAlso flexGrid.ExpressionEditors.Contains(field) Then
            flexGrid.ExpressionEditors(field).Expression = PageCache.GetCacheExpression()
            PageCache.SetCacheField("")
            PageCache.SetCacheExpression("")
        End If
    End Sub

    Private Sub Editor_CancelClick(sender As Object, e As RoutedEventArgs)
        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            Dim field As Object = TryCast((TryCast(ComboBox.SelectedValue, ComboBoxItem)).Tag, String)
            If flexGrid IsNot Nothing AndAlso flexGrid.ExpressionEditors.Contains(field) Then
                editor.Expression = flexGrid.ExpressionEditors(field).Expression
            End If
        End If
    End Sub

    Private Sub Editor_OkClick(sender As Object, e As RoutedEventArgs)
        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            Dim field As Object = TryCast((TryCast(ComboBox.SelectedValue, ComboBoxItem)).Tag, String)
            If flexGrid IsNot Nothing AndAlso flexGrid.ExpressionEditors.Contains(field) Then
                flexGrid.ExpressionEditors(field).Expression = editor.Expression
            End If
        End If
    End Sub

    ' Change ExpressionEditor settings to allow edit expression for selected C1FlexGrid column.
    Private Sub combobox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim field As Object = TryCast((TryCast(e.AddedItems(0), ComboBoxItem)).Tag, String)
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            If flexGrid IsNot Nothing AndAlso flexGrid.ExpressionEditors.Contains(field) Then
                If testeditor Is Nothing Then
                    testeditor = New C1ExpressionEditor()
                End If
                testeditor.DataSource = flexGrid.ExpressionEditors(field).DataSource
                testeditor.Expression = flexGrid.ExpressionEditors(field).Expression
                PageCache.SetCacheField(field)
                NavigateToExpressionEditor()
            End If
        Else
            If flexGrid IsNot Nothing AndAlso flexGrid.ExpressionEditors.Contains(field) Then
                editor.DataSource = flexGrid.ExpressionEditors(field).DataSource
                editor.Expression = flexGrid.ExpressionEditors(field).Expression
            End If
        End If
    End Sub

    Private Sub NavigateToExpressionEditor()
        If testeditor IsNot Nothing Then
            testeditor.Tag = GetType(ColumnCalculation)
            Me.Frame.Navigate(GetType(ExpressionEditorPage), testeditor)
        End If
    End Sub

End Class