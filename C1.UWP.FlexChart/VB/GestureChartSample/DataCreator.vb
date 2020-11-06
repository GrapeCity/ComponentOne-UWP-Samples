Imports System.Collections.Generic
Imports System

Public Class DataCreator
    Shared rnd As New Random()
    Shared coef As String() = New String() {"AMTMNQQXUYGA", "CVQKGHQTPHTE", "FIRCDERRPVLD", "GIIETPIQRRUL", "GLXOESFTTPSV", "GXQSNSKEECTX"}

    Public Shared Function Create(ptsCount As Integer) As List(Of DataPoint)
        Dim result As New List(Of DataPoint)()

        Dim x As Double() = New Double(ptsCount) {}
        Dim y As Double() = New Double(ptsCount) {}
        Dim rnd As New Random()
        Dim c As Double() = StringToCoeff(coef(rnd.[Next](coef.Length)))

        Dim i As Integer = 1
        While i < ptsCount
            Dim pt As DataPoint = Iterate(x(i - 1), y(i - 1), c)
            result.Add(pt)
            x(i) = pt.XVals
            y(i) = pt.YVals
            i += 1
        End While

        Return result
    End Function

    Shared Function Iterate(x As Double, y As Double, c As Double()) As DataPoint
        Dim x1 As Double = c(0) + c(1) * x + c(2) * x * x + c(3) * x * y + c(4) * y + c(5) * y * y
        Dim y1 As Double = c(6) + c(7) * x + c(8) * x * x + c(9) * x * y + c(10) * y + c(11) * y * y

        Return New DataPoint() With {
            .XVals = x1,
            .YVals = y1
        }
    End Function

    Shared Function StringToCoeff(s As String) As Double()
        Dim len As Integer = s.Length
        Dim c As Double() = New Double(len) {}

        Dim i As Integer = 0
        While i < len
            c(i) = -1.2 + 0.1 * (AscW(s(i)) - AscW("A"))
            i += 1
        End While

        Return c
    End Function
End Class