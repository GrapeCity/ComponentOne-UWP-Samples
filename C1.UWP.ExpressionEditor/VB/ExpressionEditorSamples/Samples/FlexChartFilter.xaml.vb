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
Imports C1.Xaml.Chart
Imports C1.Xaml
Imports C1.Xaml.ExpressionEditor

' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class FlexChartFilter
    Inherits Page
    Private testeditor As New C1ExpressionEditor()
    Public View As C1CollectionView

    Public Sub New()
        Me.InitializeComponent()

        View = New C1CollectionView(DataCreator.CreateData())

        flexChart.ItemsSource = View
        flexChart.BindingX = "Country"
        flexChart.Series.Add(New Series() With {
            .SeriesName = "Sales",
            .Binding = "Sales"
        })
        flexChart.Series.Add(New Series() With {
            .SeriesName = "Expenses",
            .Binding = "Expenses"
        })

        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            InitalizeDesktop()
        Else
            InitalizeMobile()
        End If

        AddHandler flexChart.Loaded, AddressOf FlexChart_Loaded
    End Sub

    Private Sub FlexChart_Loaded(sender As Object, e As RoutedEventArgs)
        Dim expression As Object = PageCache.GetCacheExpression()
        If expression <> testeditor.Expression Or testeditor.Expression Is Nothing Then
            PageCache.SetCacheExpression("")
            If expression = "" Then
                expression = "[Sales] < 10"
            End If
            testeditor.Expression = expression
            testeditor.DataSource = View.FirstOrDefault()
            If testeditor.IsValid Then
                View.Filter = New Predicate(Of Object)(AddressOf Contains)
                View.Refresh()
            End If
        End If
    End Sub

    Sub InitalizeDesktop()
        editor.DataSource = View.FirstOrDefault()
        editor.Expression = "[Sales] < 10"
    End Sub

    Sub InitalizeMobile()
        Dim expression As Object = PageCache.GetCacheExpression()
        If expression <> "" Then
            c1editor.Expression = expression
        Else
            c1editor.Expression = "[Sales] < 10"
        End If
        c1editor.DataSource = View.FirstOrDefault()
    End Sub

    Private Function Contains(obj As Object) As Boolean
        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            testeditor.Expression = editor.Expression
        Else
            testeditor.Expression = c1editor.Expression
        End If
        testeditor.DataSource = TryCast(obj, DataItem)
        Dim value As Object = testeditor.Evaluate()
        Dim ret As Object = True
        If value IsNot Nothing Then
            [Boolean].TryParse(value.ToString(), ret)
        End If
        Return ret
    End Function

    Private Sub Filter_Click(sender As Object, e As RoutedEventArgs)
        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            If editor.IsValid Then
                View.Filter = New Predicate(Of Object)(AddressOf Contains)
                View.Refresh()
            End If
        Else
            testeditor.DataSource = View.FirstOrDefault()
            testeditor.Expression = c1editor.Expression
            NavigateToExpressionEditor()
        End If
    End Sub

    Private Sub ClearFilter_Click(sender As Object, e As RoutedEventArgs)
        View.Filter = Nothing
        View.Refresh()
    End Sub

    Private Sub Check_Checked(sender As Object, e As RoutedEventArgs)
        AddHandler editor.ExpressionChanged, AddressOf Editor_ExpressionChanged
        If editor.IsValid Then
            View.Filter = New Predicate(Of Object)(AddressOf Contains)
            View.Refresh()
        End If
    End Sub

    Private Sub Check_Unchecked(sender As Object, e As RoutedEventArgs)
        RemoveHandler editor.ExpressionChanged, AddressOf Editor_ExpressionChanged
    End Sub

    Private Sub Editor_ExpressionChanged(sender As Object, e As EventArgs)
        If editor.IsValid Then
            View.Filter = New Predicate(Of Object)(AddressOf Contains)
            View.Refresh()
        End If
    End Sub

    Private Sub NavigateToExpressionEditor()
        If testeditor IsNot Nothing Then
            testeditor.Tag = GetType(FlexChartFilter)
            Me.Frame.Navigate(GetType(ExpressionEditorPage), testeditor)
        End If
    End Sub
End Class