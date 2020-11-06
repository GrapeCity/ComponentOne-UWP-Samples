Imports Windows.Foundation
Imports Windows.UI.Xaml.Media

Friend Class Utils
    Public Shared Function CreateBaloon() As Geometry
        Dim pg As PathGeometry = New PathGeometry()
        pg.Transform = New TranslateTransform() With {
            .X = -10,
            .Y = -27.14
        }
        Dim pf As PathFigure = New PathFigure() With {
            .StartPoint = New Point(10, 27.14),
            .IsFilled = True,
            .IsClosed = True
        }
        pf.Segments.Add(New ArcSegment() With {
            .SweepDirection = SweepDirection.Counterclockwise,
            .Point = New Point(5, 19.14),
            .RotationAngle = 45,
            .Size = New Size(10, 10)
        })
        pf.Segments.Add(New ArcSegment() With {
            .SweepDirection = SweepDirection.Clockwise,
            .Point = New Point(15, 19.14),
            .RotationAngle = 270,
            .Size = New Size(10, 10),
            .IsLargeArc = True
        })
        pf.Segments.Add(New ArcSegment() With {
            .SweepDirection = SweepDirection.Counterclockwise,
            .Point = New Point(10, 27.14),
            .RotationAngle = 45,
            .Size = New Size(10, 10)
        })
        pg.Figures.Add(pf)
        Return pg
    End Function
End Class
