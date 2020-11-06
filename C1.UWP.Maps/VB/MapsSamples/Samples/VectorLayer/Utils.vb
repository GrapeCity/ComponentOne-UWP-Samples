Imports System.Reflection
Imports Windows.UI.Xaml.Media
Imports Windows.UI
Imports Windows.Foundation
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps

Public Class Utils
    Public Shared Function CreateBaloon() As Geometry
        Dim pg As New PathGeometry()
        pg.Transform = New TranslateTransform() With {
            .X = -20,
            .Y = -54.28
        }
        Dim pf As New PathFigure() With {
            .StartPoint = New Point(20, 54.28),
            .IsFilled = True,
            .IsClosed = True
        }
        pf.Segments.Add(New ArcSegment() With {
            .SweepDirection = SweepDirection.Counterclockwise,
            .Point = New Point(10, 38.28),
            .RotationAngle = 45,
            .Size = New Size(20, 20)
        })
        pf.Segments.Add(New ArcSegment() With {
            .SweepDirection = SweepDirection.Clockwise,
            .Point = New Point(30, 38.28),
            .RotationAngle = 270,
            .Size = New Size(20, 20),
            .IsLargeArc = True
        })
        pf.Segments.Add(New ArcSegment() With {
            .SweepDirection = SweepDirection.Counterclockwise,
            .Point = New Point(20, 54.28),
            .RotationAngle = 45,
            .Size = New Size(20, 20)
        })
        pg.Figures.Add(pf)
        Return pg
    End Function

    Public Shared Sub LoadShapeFromResource(vl As C1VectorLayer, resname As String, dbfname As String, location As Location, clear As Boolean, pv As ProcessShapeItem)
        Using shapeStream As Stream = GetType(Utils).GetTypeInfo().Assembly.GetManifestResourceStream(resname)
            Using dbfStream As Stream = GetType(Utils).GetTypeInfo().Assembly.GetManifestResourceStream(dbfname)
                If shapeStream IsNot Nothing Then
                    If clear Then
                        vl.Children.Clear()
                    End If

                    vl.LoadShape(shapeStream, dbfStream, location, True, pv)
                End If
            End Using
        End Using
    End Sub

    Public Shared Sub LoadKMZFromResources(vl As C1VectorLayer, resname As String, clear As Boolean, pv As ProcessVectorItem)
        Using zipStream As Stream = GetType(Utils).GetTypeInfo().Assembly.GetManifestResourceStream(resname)
            If zipStream IsNot Nothing Then
                If clear Then
                    vl.Children.Clear()
                End If

                vl.LoadKMZ(zipStream, True, pv)
            End If
        End Using
    End Sub

    Public Shared Sub LoadKMLFromResources(vl As C1VectorLayer, resname As String, clear As Boolean, pv As ProcessVectorItem)
        Using stream As Stream = GetType(Utils).GetTypeInfo().Assembly.GetManifestResourceStream(resname)
            If stream IsNot Nothing Then
                If clear Then
                    vl.Children.Clear()
                End If

                vl.LoadKML(stream, False, pv)
            End If
        End Using
    End Sub

    Shared rnd As New Random()

    Public Shared Function GetRandomColor(a As Byte) As Color
        Return Color.FromArgb(a, CType(rnd.[Next](255), Byte), CType(rnd.[Next](255), Byte), CType(rnd.[Next](255), Byte))
    End Function

    Public Shared Function GetRandomColor(min As Byte, a As Byte) As Color
        Return Color.FromArgb(a, CType((min + rnd.[Next](255 - min)), Byte), CType((min + rnd.[Next](255 - min)), Byte), CType((min + rnd.[Next](255 - min)), Byte))
    End Function
End Class