Imports C1.Xaml.Chart
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Shapes
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
' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Partial Public NotInheritable Class SalesByPartner
    Inherits UserControl
    Private DataList As List(Of String)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub UserControl_Loaded(sender As Object, e As RoutedEventArgs)
        Me.DataList = New List(Of String)()
        Me.flexChart.BeginUpdate()
        Me.flexChart.ItemsSource = (TryCast(Me.DataContext, DataModel.SampleDataSource)).SalesByPartner
        Me.flexChart.EndUpdate()
        For Each data As DataModel.PartnersData In (TryCast(Me.DataContext, DataModel.SampleDataSource)).SalesByPartner
            Dim sale As String = Strings.SignDollar + data.TotalSale.ToString
            Me.DataList.Add(sale)
        Next
    End Sub

    Private Sub flexChart_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        ChangeMyDataLabel(e)
    End Sub

    Private Sub flexChart_Tapped(sender As Object, e As TappedRoutedEventArgs)
        ChangeMyDataLabel(e)
    End Sub

    Private Sub ChangeMyDataLabel(e As RoutedEventArgs)
        If Me.flexChart.SelectedIndex < 0 Then
            Me.MyDataLabel.Visibility = Visibility.Collapsed
            Me.MyDataLabel.Text = ""
        Else
            Me.MyDataLabel.Visibility = Visibility.Visible
            Me.MyDataLabel.Text = Me.DataList(Me.flexChart.SelectedIndex)
            Dim selectedItem As Object = e.OriginalSource
            Dim left As Double = RenderCanvas.GetLeft(TryCast(selectedItem, UIElement))
            Dim top As Double = RenderCanvas.GetTop(TryCast(selectedItem, UIElement))
            Dim width As Double = (TryCast(selectedItem, FrameworkElement)).Width
            Canvas.SetLeft(Me.MyDataLabel, left + width + 5)
            Canvas.SetTop(Me.MyDataLabel, top)
        End If
    End Sub
End Class