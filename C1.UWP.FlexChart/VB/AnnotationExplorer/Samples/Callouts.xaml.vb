Imports C1.Chart

''' <summary>
''' Interaction logic for Callouts.xaml
''' </summary>
Partial Public Class Callouts
    Inherits Page

    Dim _engine As IRenderEngine
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub SetupAttotations()
        Dim arrowCalloutContentCenter As Point = New Point(25, -50)
        arrowCallout.ContentCenter = arrowCalloutContentCenter
        arrowCallout.Points = GetPointsForArrowCallout(arrowCalloutContentCenter.X, arrowCalloutContentCenter.Y, "Low")
        lineCallouts.ContentCenter = New Point(-50, 75)
        Dim lineCalloutsPoints As PointCollection = New PointCollection()
        lineCalloutsPoints.Add(New Point(0, 0))
        lineCalloutsPoints.Add(New Point(-50, 50))
        lineCalloutsPoints.Add(New Point(-100, 50))
        lineCalloutsPoints.Add(New Point(-100, 100))
        lineCalloutsPoints.Add(New Point(0, 100))
        lineCalloutsPoints.Add(New Point(0, 50))
        lineCalloutsPoints.Add(New Point(-50, 50))
        lineCallouts.Points = lineCalloutsPoints

        flexChart.Invalidate()
    End Sub

    Private Sub flexChart_Rendering(sender As Object, e As C1.Xaml.Chart.RenderEventArgs)
        If (_engine Is Nothing) Then
            _engine = e.Engine
            SetupAttotations()
        End If
    End Sub

    ''' <summary>
    ''' This is used to automatically generate the collection of endpoints of an annotation with an arrow callouts. 
    ''' </summary>
    ''' <param name="centerX">The center x of the content rectangle.</param>
    ''' <param name="centerY">The center y of the content rectangle.</param>
    ''' <param name="rectWidth">The width of the content rectangle.</param>
    ''' <param name="rectHeight">The height of the content rectangle.</param>
    ''' <returns>The endpoints of an arrow callout.</returns>
    Private Function GetPointsForArrowCallout(centerX As Double, centerY As Double, content As String) As PointCollection
        Dim size As _Size = _engine.MeasureString(content)
        Return GetPointsForArrowCallout(centerX, centerY, size.Width + 10, size.Height + 10)
    End Function

    ''' <summary>
    ''' This is used to automatically generate the collection of endpoints of an annotation with an arrow callouts. 
    ''' </summary>
    ''' <param name="centerX">The center x of the content rectangle.</param>
    ''' <param name="centerY">The center y of the content rectangle.</param>
    ''' <param name="rectWidth">The width of the content rectangle.</param>
    ''' <param name="rectHeight">The height of the content rectangle.</param>
    ''' <returns>The endpoints of an arrow callout.</returns>
    Private Function GetPointsForArrowCallout(centerX As Double, centerY As Double, rectWidth As Double, rectHeight As Double) As PointCollection
        Dim points As PointCollection = New PointCollection()

        Dim rectLeft As Double = centerX - rectWidth / 2
        Dim rectRight As Double = centerX + rectWidth / 2
        Dim rectTop As Double = centerY - rectHeight / 2
        Dim rectBottom As Double = centerY + rectHeight / 2

        Dim angle As Double = Math.Atan2(-centerY, centerX)
        Dim angleOffset1 As Double = 0.4
        Dim angleOffset2 As Double = 0.04
        Dim arrowHeight As Double = 0.4 * rectHeight
        Dim hypotenuse As Double = arrowHeight / Math.Cos(angleOffset1)
        Dim subHypotenuse As Double = arrowHeight / Math.Cos(angleOffset2)
        Dim isNearBottom As Boolean = Math.Abs(rectTop) > Math.Abs(rectBottom)

        Dim nearHorizontalEdge As Double
        If (isNearBottom) Then
            nearHorizontalEdge = rectBottom
        Else
            nearHorizontalEdge = rectTop
        End If

        Dim isNearRight As Boolean = Math.Abs(rectLeft) > Math.Abs(rectRight)

        Dim nearVerticalEdge As Double
        If (isNearRight) Then
            nearVerticalEdge = rectRight
        Else
            nearVerticalEdge = rectLeft
        End If

        Dim isHorizontalCrossed As Boolean = Math.Abs(nearHorizontalEdge) > Math.Abs(nearVerticalEdge)
        Dim nearEdge As Double
        If (isHorizontalCrossed) Then
            nearEdge = nearHorizontalEdge
        Else
            nearEdge = nearVerticalEdge
        End If

        Dim factor As Int16
        If (nearEdge > 0) Then
            factor = -1
        Else
            factor = 1
        End If

        Dim crossedPointOffsetToCenter As Double
        If (isHorizontalCrossed) Then
            crossedPointOffsetToCenter = rectHeight / (2 * Math.Tan(angle)) * factor
        Else
            crossedPointOffsetToCenter = rectWidth * Math.Tan(angle) * factor / 2
        End If

        'Arrow points
        points.Add(New Point(0, 0))
        points.Add(New Point(Math.Cos(angle + angleOffset1) * hypotenuse, -Math.Sin(angle + angleOffset1) * hypotenuse))
        points.Add(New Point(Math.Cos(angle + angleOffset2) * subHypotenuse, -Math.Sin(angle + angleOffset2) * subHypotenuse))

        'Rectangle points
        If (isHorizontalCrossed) Then
            points.Add(New Point(-nearEdge / Math.Tan(angle + angleOffset2), nearEdge))
            If (isNearBottom) Then
                points.Add(New Point(rectLeft, rectBottom))
                points.Add(New Point(rectLeft, rectTop))
                points.Add(New Point(rectRight, rectTop))
                points.Add(New Point(rectRight, rectBottom))
            Else
                points.Add(New Point(rectRight, rectTop))
                points.Add(New Point(rectRight, rectBottom))
                points.Add(New Point(rectLeft, rectBottom))
                points.Add(New Point(rectLeft, rectTop))
            End If

            points.Add(New Point(-nearEdge / Math.Tan(angle - angleOffset2), nearEdge))
        Else
            points.Add(New Point(nearEdge, -nearEdge * Math.Tan(angle + angleOffset2)))
            If (isNearRight) Then
                points.Add(New Point(rectRight, rectBottom))
                points.Add(New Point(rectLeft, rectBottom))
                points.Add(New Point(rectLeft, rectTop))
                points.Add(New Point(rectRight, rectTop))
            Else
                points.Add(New Point(rectLeft, rectTop))
                points.Add(New Point(rectRight, rectTop))
                points.Add(New Point(rectRight, rectBottom))
                points.Add(New Point(rectLeft, rectBottom))
            End If

            points.Add(New Point(nearEdge, -nearEdge * Math.Tan(angle - angleOffset2)))
        End If

        'Arrow points
        points.Add(New Point(Math.Cos(angle - angleOffset2) * subHypotenuse, -Math.Sin(angle - angleOffset2) * subHypotenuse))
        points.Add(New Point(Math.Cos(angle - angleOffset1) * hypotenuse, -Math.Sin(angle - angleOffset1) * hypotenuse))
        Return points
    End Function

End Class