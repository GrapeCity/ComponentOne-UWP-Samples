Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Data
Imports Windows.UI
Imports Windows.Foundation
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps

Public Class City
    Public Property Name() As String
    Public Property GeoPoint() As Point
    Public Property Country() As String
    Public Property Population() As Integer

    Public Overrides Function ToString() As String
        Return String.Format("{0}" & vbTab & "{1}" & vbTab & "{2}" & vbTab & "{3}", Name, GeoPoint, Population, Country)
    End Function

    Public Shared Function FromString(s As String) As City
        Dim city As City = Nothing
        If Not String.IsNullOrEmpty(s) Then
            Dim ss As String() = s.Split(vbTab.ToCharArray())
            If ss.Length = 4 Then
                city = New City() With {
                    .Name = ss(0),
                    .GeoPoint = PointFromString(ss(1)),
                    .Population = Integer.Parse(ss(2)),
                    .Country = ss(3)
                }
            End If
        End If

        Return city
    End Function

    Shared Function PointFromString(s As String) As Point
        Dim ss As String() = s.Split(","c)
        Return New Point(Double.Parse(ss(1)), Double.Parse(ss(0)))
    End Function

    Public Shared Function Read(stream As Stream) As List(Of City)
        Dim cities As New List(Of City)()

        Using sr As New StreamReader(stream)
            While Not sr.EndOfStream
                Dim city As City = FromString(sr.ReadLine())
                If city IsNot Nothing Then
                    cities.Add(city)
                End If
            End While
        End Using

        Return cities
    End Function
End Class

Public Class GeometryConverter
    Implements IValueConverter
    Shared stroke As Brush = New SolidColorBrush(Colors.Black)
    Shared fill As Brush = New SolidColorBrush(Colors.White)

    Public Function Convert(value As Object, targetType As System.Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim population As Integer = CType(value, Integer)

        Dim ell As New EllipseGeometry()

        If population >= 2000000 Then
            ell.RadiusY = 6
            ell.RadiusX = ell.RadiusY
        ElseIf population >= 1000000 Then
            ell.RadiusY = 5
            ell.RadiusX = ell.RadiusY
        ElseIf population >= 7500000 Then
            ell.RadiusY = 4
            ell.RadiusX = ell.RadiusY
        ElseIf population >= 500000 Then
            ell.RadiusY = 3
            ell.RadiusX = ell.RadiusY
        ElseIf population >= 250000 Then
            ell.RadiusY = 2
            ell.RadiusX = ell.RadiusY
        Else
            ell.RadiusY = 1
            ell.RadiusX = ell.RadiusY
        End If

        Return ell
    End Function

    Public Function ConvertBack(value As Object, targetType As System.Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

Public Class LODConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As System.Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim population As Integer = CType(value, Integer)

        If population >= 2000000 Then
            Return New LOD(0, 0, 0, 20)
        End If

        If population >= 1000000 Then
            Return New LOD(0, 0, 1, 20)
        End If

        If population >= 7500000 Then
            Return New LOD(0, 0, 2, 20)
        End If

        If population >= 500000 Then
            Return New LOD(0, 0, 3, 20)
        End If

        If population >= 250000 Then
            Return New LOD(0, 0, 4, 20)
        End If

        Return New LOD(0, 0, 5, 20)
    End Function

    Public Function ConvertBack(value As Object, targetType As System.Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class