Imports Windows.Foundation
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps
Imports C1.C1Zip

Public Delegate Function ProcessVectorItem(vector As C1VectorItemBase) As Boolean

Public Module Extension
    <Extension()>
    Public Sub LoadKML(vl As C1VectorLayer, stream As Stream, centerAndZoom As Boolean, processVector As ProcessVectorItem)
        Using sr As New StreamReader(stream)
            Dim s As String = sr.ReadToEnd()
            Dim vects As List(Of C1VectorItemBase) = KmlReader.Read(s)

            vl.BeginUpdate()
            For Each vect As C1VectorItemBase In vects
                If processVector IsNot Nothing Then
                    If Not processVector(vect) Then
                        Continue For
                    End If
                End If

                vl.Children.Add(vect)
            Next
            vl.EndUpdate()

            If centerAndZoom Then
                Dim bnds As Rect = vects.GetBounds()
                Dim maps As C1Maps = (CType(vl, IMapLayer)).ParentMaps

                If maps IsNot Nothing Then
                    maps.Center = New Point(bnds.Left + 0.5 * bnds.Width, bnds.Top + 0.5 * bnds.Height)
                    Dim scale As Double = Math.Max(bnds.Width / 360 * maps.ActualWidth, bnds.Height / 180 * maps.ActualHeight)


                    Dim zoom As Double = Math.Log(512 / scale, 2.0)
                    maps.Zoom = If(zoom > 0, zoom, 0)
                    maps.TargetZoom = maps.Zoom
                End If
            End If

            sr.Dispose()
        End Using
    End Sub

    <Extension()>
    Public Sub LoadKMZ(vl As C1VectorLayer, stream As Stream, centerAndZoom As Boolean, processVector As ProcessVectorItem)
        Using zip As New C1ZipFile(stream)
            For Each entry As C1ZipEntry In zip.Entries
                If entry.FileName.EndsWith(".kml") Then
                    Using docStream As Stream = entry.OpenReader()
                        If docStream IsNot Nothing Then
                            LoadKML(vl, docStream, centerAndZoom, processVector)
                        End If
                    End Using
                End If
            Next
        End Using
    End Sub

    <Extension()>
    Public Function GetBounds(items As IEnumerable(Of C1VectorItemBase)) As Rect
        Dim bounds As Rect = Rect.Empty
        For Each item As C1VectorItemBase In items
            bounds.Union(item.Bounds)
        Next
        Return bounds
    End Function
End Module