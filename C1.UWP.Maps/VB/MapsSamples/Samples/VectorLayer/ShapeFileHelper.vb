Imports System.IO
Imports System.Collections.Generic
Imports C1.Xaml.Maps

Public Delegate Sub ProcessShapeItem(vector As C1VectorItemBase, attributes As C1ShapeAttributes, location As Location)

Public Module ShapeFileHelper
    <Extension()>
    Public Sub LoadShape(vl As C1VectorLayer, stream As Stream, dbfStream As Stream, location As Location, centerAndZoom As Boolean, processShape As ProcessShapeItem)
        Dim vects As Dictionary(Of C1VectorItemBase, C1ShapeAttributes) = ShapeReader.Read(stream, dbfStream)

        vl.BeginUpdate()
        For Each vect As C1VectorItemBase In vects.Keys
            If processShape IsNot Nothing Then
                processShape(vect, vects(vect), location)
            End If

            vl.Children.Add(vect)
        Next
        vects.Clear()
        vl.EndUpdate()
    End Sub
End Module