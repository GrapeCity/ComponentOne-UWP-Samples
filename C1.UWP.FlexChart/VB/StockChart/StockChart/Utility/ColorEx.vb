#Region "Structs"
' An HSB color
Imports Windows.UI

Public Structure HsbColor
    Public A As Double
    Public H As Double
    Public S As Double
    Public B As Double
End Structure
#End Region
Public Class ColorEx
    Public Shared Function RgbToHsb(rgbColor As Color) As HsbColor
        ' Hue values range between 0 and 360. All 
        '             * other values range between 0 and 1. 


        ' Create HSB color object
        Dim hsbColor = New HsbColor()

        ' Get RGB color component values
        Dim r = CInt(rgbColor.R)
        Dim g = CInt(rgbColor.G)
        Dim b = CInt(rgbColor.B)
        Dim a = CInt(rgbColor.A)

        ' Get min, max, and delta values
        Dim min As Double = Math.Min(Math.Min(r, g), b)
        Dim max As Double = Math.Max(Math.Max(r, g), b)
        Dim delta As Double = max - min

        ' Black (max = 0) is a special case. We 
        '             * simply set HSB values to zero and exit. 


        ' Black: Set HSB and return
        If max = 0.0 Then
            hsbColor.H = 0.0
            hsbColor.S = 0.0
            hsbColor.B = 0.0
            hsbColor.A = a / 255
            Return hsbColor
        End If

        ' Now we process the normal case. 


        ' Set HSB Alpha value
        Dim alpha = CDbl(a)
        hsbColor.A = alpha / 255

        ' Set HSB Hue value
        If r = max Then
            hsbColor.H = (g - b) / delta
        ElseIf g = max Then
            hsbColor.H = 2 + (b - r) / delta
        ElseIf b = max Then
            hsbColor.H = 4 + (r - g) / delta
        End If
        hsbColor.H *= 60
        If hsbColor.H < 0.0 Then
            hsbColor.H += 360
        End If

        ' Set other HSB values
        hsbColor.S = delta / max
        hsbColor.B = max / 255

        ' Set return value
        Return hsbColor
    End Function

    Public Shared Function HsbToRgb(hsbColor As HsbColor) As Color
        ' Gray (zero saturation) is a special case.We simply
        '             * set RGB values to HSB Brightness value and exit. 


        ' Gray: Set RGB and return
        If hsbColor.S = 0.0 Then
            Return Color.FromArgb(CByte(hsbColor.A * 255), CByte(hsbColor.B * 255), CByte(hsbColor.B * 255), CByte(hsbColor.B * 255))
        End If

        ' Now we process the normal case. 

        Dim h = If((hsbColor.H = 360), 0, hsbColor.H / 60)
        'var i = (int)(Math.Truncate(h));

        'var i = (int)(Math.Round(h));
        If Double.IsNaN(h) Then
            Return Color.FromArgb(CByte(hsbColor.A * 255), CByte(hsbColor.B * 255), CByte(hsbColor.B * 255), CByte(hsbColor.B * 255))
        End If


        Dim i As Integer = Convert.ToInt32(Math.Floor(h))
        Dim f = h - i

        Dim p = hsbColor.B * (1.0 - hsbColor.S)
        Dim q = hsbColor.B * (1.0 - (hsbColor.S * f))
        Dim t = hsbColor.B * (1.0 - (hsbColor.S * (1.0 - f)))

        Dim r As Double, g As Double, b As Double
        Select Case i
            Case 0
                r = hsbColor.B
                g = t
                b = p
                Exit Select

            Case 1
                r = q
                g = hsbColor.B
                b = p
                Exit Select

            Case 2
                r = p
                g = hsbColor.B
                b = t
                Exit Select

            Case 3
                r = p
                g = q
                b = hsbColor.B
                Exit Select

            Case 4
                r = t
                g = p
                b = hsbColor.B
                Exit Select
            Case Else

                r = hsbColor.B
                g = p
                b = q
                Exit Select
        End Select


        ' Set return value
        Return Color.FromArgb(CByte(hsbColor.A * 255), CByte(r * 255), CByte(g * 255), CByte(b * 255))
    End Function
End Class