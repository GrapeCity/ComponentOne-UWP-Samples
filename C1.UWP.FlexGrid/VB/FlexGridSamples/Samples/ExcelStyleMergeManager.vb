Imports System.Collections.Generic
Imports C1.Xaml.FlexGrid

Public Class ExcelStyleMergeManager
    Implements IMergeManager
    ' ** fields
    Private _grid As C1FlexGrid
    Private _mergedRanges As New List(Of CellRange)()

    ' ** ctor
    Public Sub New(grid As C1FlexGrid)
        _grid = grid
    End Sub

    ' ** IMergeManager
    Public Function GetMergedRange(grid As C1FlexGrid, cellType As CellType, range As CellRange) As CellRange Implements IMergeManager.GetMergedRange
        ' look for merged ranges that contain the given cell
        For Each mergedRange As CellRange In _mergedRanges
            If mergedRange.Contains(range) Then
                Return mergedRange
            End If
        Next

        ' not found, not merged
        Return range
    End Function

    ' ** object model
    Public Sub AddMergedRange(rng As CellRange)
        If Not rng.IsSingleCell Then
            RemoveMergedRange(rng)
            _mergedRanges.Add(New CellRange(rng.TopRow, rng.LeftColumn, rng.BottomRow, rng.RightColumn))
            _grid.Invalidate()
        End If
    End Sub
    Public Sub RemoveMergedRange(rng As CellRange)
        Dim i As Integer = 0
        While i < _mergedRanges.Count
            If rng.Intersects(_mergedRanges(i)) Then
                _mergedRanges.RemoveAt(i)
                i -= 1
            End If
            i += 1
        End While
        _grid.Invalidate()
    End Sub
End Class