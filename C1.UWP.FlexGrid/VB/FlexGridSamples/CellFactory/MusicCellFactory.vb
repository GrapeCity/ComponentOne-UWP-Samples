Imports C1.Xaml.FlexGrid
Imports Windows.UI.Xaml.Media.Animation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Linq
Imports System.Collections.Generic
Imports System.Windows
Imports System.Net
Imports System

' cell factory used to create media cells
Public Class MusicCellFactory
    Inherits CellFactory
    Shared _emptyThickness As New Thickness(0)
    Public _ratings As New List(Of RatingCell)()

    ' bind a cell to a range
    Public Overrides Sub CreateCellContent(grid As C1FlexGrid, bdr As Border, range As CellRange)
        ' get row/col
        Dim row As Row = grid.Rows(range.Row)
        Dim col As Column = grid.Columns(range.Column)
        Dim gr As GroupRow = TryCast(row, GroupRow)

        ' no border for group rows
        If gr IsNot Nothing Then
            bdr.BorderThickness = _emptyThickness
        End If

        ' bind first cell in each group row to collapse/expand
        If gr IsNot Nothing AndAlso range.Column = 0 Then
            BindGroupRowCell(grid, bdr, range)
            Return
        End If

        ' bind regular data cells
        Select Case col.ColumnName
                ' show names with images
            Case "Name"
                bdr.Child = New SongCell(row)
                Return

                ' show ratings with stars
            Case "Rating"
                Dim song As Song = TryCast(row.DataItem, Song)
                If song IsNot Nothing AndAlso gr Is Nothing Then
                    Dim cell As New RatingCell()
                    cell.SetBinding(RatingCell.RatingProperty, col.Binding)
                    bdr.Child = cell
                End If
                Return
        End Select

        ' default binding
        MyBase.CreateCellContent(grid, bdr, range)
    End Sub

    ' bind a cell to a group row
    Sub BindGroupRowCell(grid As C1FlexGrid, bdr As Border, range As CellRange)
        ' get row, group row
        Dim row As Row = grid.Rows(range.Row)
        Dim gr As GroupRow = TryCast(row, GroupRow)

        ' show group caption/image on first column
        If range.Column = 0 Then
            ' build a custom data item if necessary
            If gr.DataItem Is Nothing Then
                gr.DataItem = BuildGroupDataItem(gr)
            End If

            ' get type of cell we need
            Dim cellType As Type = If(gr.Level = 0, GetType(ArtistCell), GetType(AlbumCell))

            ' create the cell
            bdr.Child = If(gr.Level = 0, CType(New ArtistCell(row), UIElement), CType(New AlbumCell(row), UIElement))
        End If
    End Sub

    ' build a song to represent a group
    ' the GetChildDataItems method returns all songs that belong
    ' to this node, and the LINQ statement below calculates the total 
    ' size, length, and average rating for the album/artist.
    Function BuildGroupDataItem(gr As GroupRow) As Song
        Dim gs As IEnumerable(Of Song) = gr.GetDataItems().OfType(Of Song)()
        Return New Song() With {
            .Name = gr.Group.Group.ToString(),
            .Size = CType(gs.Sum(Function(s) s.Size), Long),
            .Duration = CType(gs.Sum(Function(s) s.Duration), Long),
            .Rating = CType((gs.Average(Function(s) s.Rating) + 0.5), Integer)
        }
    End Function
End Class