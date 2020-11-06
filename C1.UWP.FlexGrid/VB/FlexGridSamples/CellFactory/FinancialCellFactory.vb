Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports C1.Xaml.FlexGrid
Imports System.Reflection

Public Class FinancialCellFactory
    Inherits CellFactory
    Shared _thicknessEmpty As New Thickness(0)

    ' bind cell to ticker
    Public Overrides Sub CreateCellContent(grid As C1FlexGrid, bdr As Border, range As CellRange)
        ' create visual element for this cell
        Dim dataItem As Object = grid.Rows(range.Row).DataItem
        Dim name As String = grid.Columns(range.Column).PropertyInfo.Name

        If TypeOf dataItem Is FinancialData AndAlso (name.Equals("LastSale") OrElse name.Equals("Bid") OrElse name.Equals("Ask")) Then
            ' create stock ticker cell
            Dim ticker As New StockTicker()
            bdr.Child = ticker
            bdr.Padding = _thicknessEmpty
        Else
            ' use default implementation
            MyBase.CreateCellContent(grid, bdr, range)
        End If
    End Sub

    Public Overrides Sub DisposeCell(grid As C1FlexGrid, cellType As CellType, cell As FrameworkElement)
        MyBase.DisposeCell(grid, cellType, cell)
    End Sub

    Public Sub ShowLiveData(grid As C1FlexGrid, range As CellRange, cell As FrameworkElement)
        'Sets the binding in the cell content so that is updated at runtime.
        Dim stockTicker As StockTicker = TryCast((TryCast(cell, Border)).Child, StockTicker)
        If stockTicker IsNot Nothing Then
            Dim c As Column = grid.Columns(range.Column)
            Dim r As Row = grid.Rows(range.Row)
            Dim pi As PropertyInfo = c.PropertyInfo

            ' to show sparklines
            stockTicker.Tag = r.DataItem
            stockTicker.BindingSource = pi.Name

            Dim binding As New Binding() With {
                .Path = New PropertyPath(pi.Name)
            }
            binding.Converter = New MyConverter()
            binding.Source = r.DataItem
            binding.Mode = BindingMode.OneWay
            stockTicker.SetBinding(stockTicker.ValueProperty, binding)
        End If
    End Sub
End Class

Public Class MyConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As System.Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return System.Convert.ToDouble(value)
    End Function

    Public Function ConvertBack(value As Object, targetType As System.Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Return value
    End Function
End Class