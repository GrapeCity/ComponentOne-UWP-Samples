Imports Windows.UI.Xaml.Media
Imports Windows.UI
Imports System.Threading.Tasks
Imports System.Text
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System

Public Interface IValueToBrush
    Function ValueToBrush(value As Double) As Brush
End Interface

Public Class Country
		Private _fill As Brush = Nothing
		Private _value As Double
		Friend Parent As Countries

		Public Property Name() As String

		Public Property Value() As Double
			Get
				Return _value
			End Get
			Set
				_value = value
				_fill = Nothing
			End Set
		End Property

		Public ReadOnly Property Fill() As Brush
			Get
				If _fill Is Nothing Then
					If Parent IsNot Nothing Then
						_fill = Parent.ValueToBrush(Value)
					End If
				End If
				Return _fill
			End Get
		End Property
	End Class

Public Class Countries
    Inherits Collection(Of Country)
    Implements IValueToBrush
    Private _dict As New Dictionary(Of String, Country)()

    Public Property Converter() As IValueToBrush

    Public Function ValueToBrush(value As Double) As Brush Implements IValueToBrush.ValueToBrush
        If Converter IsNot Nothing Then
            Return Converter.ValueToBrush(value)
        End If

        Return Nothing
    End Function

    Default Public ReadOnly Property Item(name As String) As Country
        Get
            If _dict.ContainsKey(name) Then
                Return _dict(name)
            End If
            Return Nothing
        End Get
    End Property

    Public Function GetMin() As Double
        Dim min As Double = Double.NaN

        For Each country As Country In Me
            If Double.IsNaN(min) OrElse country.Value < min Then
                min = country.Value
            End If
        Next

        Return min
    End Function

    Public Function GetMax() As Double
        Dim max As Double = Double.NaN

        For Each country As Country In Me
            If Double.IsNaN(max) OrElse country.Value > max Then
                max = country.Value
            End If
        Next

        Return max
    End Function

    Protected Overrides Sub InsertItem(index As Integer, item As Country)
        MyBase.InsertItem(index, item)
        item.Parent = Me
        _dict.Add(item.Name, item)
    End Sub

    Protected Overrides Sub ClearItems()
        For Each item As Country In Me
            item.Parent = Nothing
        Next

        MyBase.ClearItems()
        _dict.Clear()
    End Sub

    Protected Overrides Sub RemoveItem(index As Integer)
        Dim item As Country = Me(index)
        MyBase.RemoveItem(index)

        _dict.Remove(item.Name)
        item.Parent = Nothing
    End Sub

    Public Shared Function CreateTestCollection() As Countries
        Dim countries As New Countries()
        Using stream As Stream = GetType(Countries).GetTypeInfo().Assembly.GetManifestResourceStream("MapsSamples.gdp-ppp.txt")
            Using sr As New StreamReader(stream)
                While Not sr.EndOfStream
                    Dim s As String = sr.ReadLine()

                    Dim ss As String() = s.Split(vbTab.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

                    countries.Add(New Country() With {
                        .Name = ss(1).Trim(),
                        .Value = Double.Parse(ss(2))
                    })
                End While
            End Using
        End Using

        Dim cvals As New ColorValues()
        cvals.Add(New ColorValue() With {
            .Color = Colors.Red,
            .Value = 0
        })

        cvals.Add(New ColorValue() With {
            .Color = Colors.Green,
            .Value = 2000000
        })
        cvals.Add(New ColorValue() With {
            .Color = Colors.Blue,
            .Value = 1.001 * countries.GetMax()
        })

        countries.Converter = cvals

        Return countries
    End Function
End Class

Public Class ColorValue
    Public Property Color() As Color
    Public Property Value() As Double
End Class

Public Class ColorValues
    Inherits Collection(Of ColorValue)
    Implements IValueToBrush
    Public Function ValueToBrush(value As Double) As Brush Implements IValueToBrush.ValueToBrush
        Dim brush As SolidColorBrush = Nothing

        Dim greater As ColorValue = Nothing
        Dim less As ColorValue = Nothing

        For Each cval As ColorValue In Me
            If cval.Value < value Then
                If less Is Nothing OrElse (value - cval.Value < value - less.Value) Then
                    less = cval
                End If
            End If
            If cval.Value > value Then
                If greater Is Nothing OrElse (value - cval.Value > value - greater.Value) Then
                    greater = cval
                End If
            End If
        Next

        If less IsNot Nothing AndAlso greater IsNot Nothing Then
            Dim clr1 As Color = less.Color
            Dim clr2 As Color = greater.Color

            Dim rval As Double = (value - less.Value) / (greater.Value - less.Value)
            Dim clr As Color = Color.FromArgb(CType((CType(clr1.A, Integer) + rval * (CType(clr2.A, Integer) - CType(clr1.A, Integer))), Byte),
                                              CType((CType(clr1.R, Integer) + rval * (CType(clr2.R, Integer) - CType(clr1.R, Integer))), Byte),
                                              CType((CType(clr1.G, Integer) + rval * (CType(clr2.G, Integer) - CType(clr1.G, Integer))), Byte),
                                              CType((CType(clr1.B, Integer) + rval * (CType(clr2.B, Integer) - CType(clr1.B, Integer))), Byte))
            brush = New SolidColorBrush(clr)
        End If

        Return brush
    End Function
End Class

Public Class ColorRange
    Implements IValueToBrush
    Public Property Min() As Double
    Public Property Max() As Double

    Public Property ColorMin() As Color
    Public Property ColorMax() As Color

    Public Function ValueToBrush(value As Double) As Brush Implements IValueToBrush.ValueToBrush
        Dim brush As SolidColorBrush = Nothing

        value = (value - Min) / (Max - Min)

        value = Math.Log(value + 1, 2)

        If value >= 0.0 AndAlso value <= 1.0 Then
            Dim clr As Color = Color.FromArgb(CType((ColorMin.A + value * (ColorMax.A - ColorMin.A)), Byte), CType((ColorMin.R + value * (ColorMax.R - ColorMin.R)), Byte), CType((ColorMin.G + value * (ColorMax.G - ColorMin.G)), Byte), CType((ColorMin.B + value * (ColorMax.B - ColorMin.B)), Byte))

            brush = New SolidColorBrush(clr)
        End If

        Return brush
    End Function
End Class