Imports Windows.UI
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Sparkline

Class SampleData
    Private _defaultColors As Dictionary(Of String, Color)
    Private _types As Dictionary(Of String, SparklineType)

    Public ReadOnly Property DefaultData() As List(Of Double)
        Get
            Dim data As New List(Of Double)() From {
            1.0,
            -2.0,
            -1.0,
            6.0,
            4.0,
            -4.0,
            3.0,
            8.0
        }
            Return data
        End Get
    End Property

    Public ReadOnly Property DefaultDateAxisData() As List(Of DateTime)
        Get
            Dim dates As New List(Of DateTime)()
            dates.Add(New DateTime(2011, 1, 5))
            dates.Add(New DateTime(2011, 1, 1))
            dates.Add(New DateTime(2011, 2, 11))
            dates.Add(New DateTime(2011, 3, 1))
            dates.Add(New DateTime(2011, 2, 1))
            dates.Add(New DateTime(2011, 2, 3))
            dates.Add(New DateTime(2011, 3, 6))
            dates.Add(New DateTime(2011, 2, 19))
            Return dates
        End Get
    End Property

    Public ReadOnly Property DefaultColors() As Dictionary(Of String, Color)
        Get
            If _defaultColors Is Nothing Then
                _defaultColors = New Dictionary(Of String, Color)()
                _defaultColors.Add(Strings.SkyBlueColor, Color.FromArgb(&HFF, &H88, &HBD, &HE6))
                _defaultColors.Add(Strings.SandyBrownColor, Color.FromArgb(&HFF, &HFB, &HB2, &H58))
                _defaultColors.Add(Strings.LightGreenColor, Color.FromArgb(&HFF, &H90, &HCD, &H97))
                _defaultColors.Add(Strings.LightPinkColor, Color.FromArgb(&HFF, &HF6, &HAA, &HC9))
                _defaultColors.Add(Strings.DarkKhakiColor, Color.FromArgb(&HFF, &HBF, &HA5, &H54))
                _defaultColors.Add(Strings.MediumOrchidColor, Color.FromArgb(&HFF, &HBC, &H99, &HC7))
                _defaultColors.Add(Strings.GoldColor, Color.FromArgb(&HFF, &HED, &HDD, &H46))
                _defaultColors.Add(Strings.LightCoralColor, Color.FromArgb(&HFF, &HF0, &H7E, &H6E))
                _defaultColors.Add(Strings.GrayColor, Color.FromArgb(&HFF, &H8C, &H8C, &H8C))
            End If

            Return _defaultColors
        End Get
    End Property

    Public ReadOnly Property SparklineTypes() As Dictionary(Of String, SparklineType)
        Get
            If _types Is Nothing Then
                _types = New Dictionary(Of String, SparklineType)()
                _types.Add(Strings.LineType, SparklineType.Line)
                _types.Add(Strings.ColumnType, SparklineType.Column)
                _types.Add(Strings.WinlossType, SparklineType.Winloss)
            End If

            Return _types
        End Get
    End Property
End Class
