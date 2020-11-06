Imports C1.Chart
Imports System.Collections.Generic
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml
Imports System.Linq
Imports System

Public Class EnumConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return value.ToString()
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim str As String = value.ToString()
        Select Case parameter.ToString()
            Case "Palette"
                Return CType([Enum].Parse(GetType(Palette), str), Palette)
            Case "Stacking"
                Return CType([Enum].Parse(GetType(Stacking), str), Stacking)
            Case "PieLabelPosition"
                Return CType([Enum].Parse(GetType(PieLabelPosition), str), PieLabelPosition)
            Case "LabelPosition"
                Return CType([Enum].Parse(GetType(LabelPosition), str), LabelPosition)
            Case "ChartSelectionMode"
                Return CType([Enum].Parse(GetType(ChartSelectionMode), str), ChartSelectionMode)
            Case "Position"
                Return CType([Enum].Parse(GetType(Position), str), Position)
            Case "FunnelChartType"
                Return CType([Enum].Parse(GetType(FunnelChartType), str), FunnelChartType)
        End Select
        Return Nothing
    End Function
End Class

Public Class ChartTypeConverter
    Inherits DependencyObject
    Implements IValueConverter
    Public Property ChartTypes() As Dictionary(Of ChartType, String)
        Get
            Return CType(GetValue(ChartTypesProperty), Dictionary(Of ChartType, String))
        End Get
        Set
            SetValue(ChartTypesProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly ChartTypesProperty As DependencyProperty = DependencyProperty.Register("ChartTypes", GetType(Dictionary(Of ChartType, String)), GetType(ChartTypeConverter), New PropertyMetadata(Nothing))

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim key As ChartType = CType(value, ChartType)
        Dim index As Integer = 0
        For Each chartType As KeyValuePair(Of ChartType, String) In ChartTypes
            If chartType.Key.Equals(key) Then
                Return index
            End If
            index += 1
        Next

        Return index
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim index As Integer = CType(value, Integer)
        Return ChartTypes.ElementAt(index).Key
    End Function
End Class

Public Class VisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim visibility As SeriesVisibility = CType([Enum].Parse(GetType(SeriesVisibility), value.ToString()), SeriesVisibility)
        Return visibility = SeriesVisibility.Visible
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Return If(CType(value, Boolean), SeriesVisibility.Visible, SeriesVisibility.Legend)
    End Function
End Class

Public Class FormatConverter
    Implements IValueConverter

    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return value
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Return Double.Parse(value.ToString())
    End Function
End Class