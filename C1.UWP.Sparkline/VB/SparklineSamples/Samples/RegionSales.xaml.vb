Imports System.Collections.ObjectModel
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

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Partial Class RegionSales
		Inherits Page
		Public Sub New()
			Me.InitializeComponent()

			Dim rnd As New Random()
			Dim state As String = Strings.StatesColumnValue
			Dim states As String() = state.Split("|"C)
			Me.Sales = New ObservableCollection(Of RegionSalesData)()
			Dim i As Integer = 0
			While i < states.Length
				Dim rsd As New RegionSalesData()
				rsd.State = states(i)
				rsd.Data = New ObservableCollection(Of Double)()
				Dim j As Integer = 0
				While j < 12
					Dim d As Double = rnd.[Next](-50, 50)
					rsd.Data.Add(d)
					rsd.NetSales += d
					rsd.TotalSales += Math.Abs(d)
					j += 1
				End While
				Me.Sales.Add(rsd)
				i += 1
			End While

			Me.DataContext = Me
		End Sub

		Public Property Sales() As ObservableCollection(Of RegionSalesData)

    Private Sub Page_SizeChanged(sender As System.Object, e As SizeChangedEventArgs)
        If e.NewSize.Width > 540 Then
            region.Width = 60
            totalSale.Width = 100
            profitTrend.Width = 200
            salesTrend.Width = 200
            winLoss.Width = 200
            RegionSalesListBox.ItemTemplate = CType(Root.Resources("largeListBox"), DataTemplate)
            ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled
        Else
            region.Width = 25
            totalSale.Width = 45
            salesTrend.Width = 75
            winLoss.Width = 75
            profitTrend.Width = 75
            RegionSalesListBox.ItemTemplate = CType(Root.Resources("smallListBox"), DataTemplate)
            ScrollViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto
        End If
    End Sub
End Class

	Public Class RegionSalesData
		Public Property Data() As ObservableCollection(Of Double)
		Public Property State() As String
		Public Property TotalSales() As Double
		Public ReadOnly Property TotalSalesFormatted() As String
			Get
				Return [String].Format("{0:c2}", Me.TotalSales)
			End Get
		End Property
		Public Property NetSales() As Double
	End Class
