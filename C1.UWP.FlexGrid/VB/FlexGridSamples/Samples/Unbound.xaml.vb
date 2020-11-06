Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports C1.Xaml.FlexGrid

Partial Public Class Unbound
    Inherits Page
    Public Sub New()
        InitializeComponent()

        ' populate unbound grid
        Dispatcher.RunAsync(CoreDispatcherPriority.Normal, New DispatchedHandler(AddressOf PopulateUnboundGrid))

        ' store sample description in Tag property
        Tag = Strings.UnboundTag
    End Sub

    ' fill unbound grid with data
    Private Async Sub PopulateUnboundGrid()
        ' allow merging
        Dim fg As C1FlexGrid = _flexUnbound
        fg.AllowMerging = AllowMerging.All
        Dim data As List(Of NorthwindData) = Await NorthwindStorage.Load()

        'add rows/ columns to the unbound grid
        Dim i As Integer = 0
        While i < 10
            ' three years, four quarters per year
            fg.Columns.Add(New Column())
            i += 1
        End While
        Dim ir As Integer = 0
        While ir < 91
            fg.Rows.Add(New Row())
            ir += 1
        End While

        ' populate the unbound grid with some stuff
        Dim r As Integer = 0
        While r < fg.Rows.Count
            Dim cols As Integer = 0
            While cols < fg.Columns.Count
                fg(r, cols) = data(r).CustomerID
                fg(r, cols + 1) = data(r).CompanyName
                fg(r, cols + 2) = data(r).ContactName
                fg(r, cols + 3) = data(r).ContactTitle
                fg(r, cols + 4) = data(r).Address
                fg(r, cols + 5) = data(r).City
                fg(r, cols + 6) = data(r).PostalCode
                fg(r, cols + 7) = data(r).Country
                fg(r, cols + 8) = data(r).Phone
                fg(r, cols + 9) = data(r).Fax
                cols += 10
            End While
            r += 1
        End While

        ' add some group rows above the data
        Dim offset As Integer = 0
        While offset < fg.Rows.Count
            Dim ioff As Integer = 0
            While ioff < 3
                fg.Rows.Insert(offset + ioff, New GroupRow() With {
                    .Level = ioff
                })
                fg(offset + ioff, 0) = String.Format(Strings.LevelInfo, ioff)
                ioff += 1
            End While
            offset += 10
        End While

        ' set unbound column headers
        Dim ch As GridPanel = fg.ColumnHeaders
        ch.Rows.Add(New Row())
        Dim c As Integer = 0
        While c < ch.Columns.Count
            ch(0, c) = Strings.NorthwindData
            ch(1, c) = Strings.ColumnHeaderCustomerID
            ch(1, c + 1) = Strings.ColumnHeaderCompanyName
            ch(1, c + 2) = Strings.ColumnHeaderContactName
            ch(1, c + 3) = Strings.ColumnHeaderContactTitle
            ch(1, c + 4) = Strings.ColumnHeaderAddress
            ch(1, c + 5) = Strings.ColumnHeaderCity
            ch(1, c + 6) = Strings.ColumnHeaderPostalCode
            ch(1, c + 7) = Strings.ColumnHeaderCountry
            ch(1, c + 8) = Strings.ColumnHeaderPhone
            ch(1, c + 9) = Strings.ColumnHeaderFax
            c += 10
        End While

        ' allow merging the first fixed row
        ch.Rows(0).AllowMerging = True

        ' set unbound row headers
        Dim rh As GridPanel = fg.RowHeaders
        rh.Columns.Add(New Column())
        Dim id As Integer = 1
        Dim col As Integer = 0
        While col < rh.Columns.Count
            rh.Columns(col).Width = New GridLength(60)
            Dim row As Integer = 0
            While row < rh.Rows.Count
                If col.Equals(0) Then
                    If row Mod 10 < 3 Then
                        rh(row, col) = Strings.Level + (row Mod 10).ToString()
                    Else
                        rh(row, col) = Strings.ID
                    End If
                Else
                    If row Mod 10 >= 3 Then
                        rh(row, col) = id.ToString()
                        id += 1
                    End If
                End If
                row += 1
            End While
            col += 1
        End While

        ' allow merging the first fixed column
        rh.Columns(0).AllowMerging = True

        ' listen to column resized event
        AddHandler _flexUnbound.ResizedColumn, AddressOf _flexUnbound_ResizedColumn
    End Sub


    ' make all unbound grid columns the same width after they are resized
    Private Sub _flexUnbound_ResizedColumn(sender As Object, e As CellRangeEventArgs)
        Dim col As Column = _flexUnbound.Columns(e.Column)
        If col.ActualWidth > 0 Then
            _flexUnbound.Columns.DefaultSize = col.ActualWidth
        End If
        col.Width = New GridLength(0, GridUnitType.Auto)
    End Sub
End Class