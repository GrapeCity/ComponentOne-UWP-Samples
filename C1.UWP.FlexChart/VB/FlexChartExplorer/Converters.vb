Imports System.Linq
Imports System.Collections.Generic
Imports C1.Chart
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml
Imports System

Public Class BooleanConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return value.ToString()
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

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
            Case "FitType"
                Return CType([Enum].Parse(GetType(FitType), str), FitType)
            Case "ErrorAmount"
                Return CType([Enum].Parse(GetType(ErrorAmount), str), ErrorAmount)
            Case "Direction"
                Return CType([Enum].Parse(GetType(ErrorBarDirection), str), ErrorBarDirection)
            Case "EndStyle"
                Return CType([Enum].Parse(GetType(ErrorBarEndStyle), str), ErrorBarDirection)
            Case "Orientation"
                Return CType([Enum].Parse(GetType(Orientation), str), Orientation)
            Case "TextWrapping"
                Return CType([Enum].Parse(GetType(C1.Chart.TextWrapping), str), C1.Chart.TextWrapping)
            Case "HistogramBinning"
                Return CType([Enum].Parse(GetType(C1.Chart.HistogramBinning), str), C1.Chart.HistogramBinning)
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
        If value Is Nothing Then
            Return Visibility.Collapsed
        End If

        Dim position As PieLabelPosition = CType([Enum].Parse(GetType(PieLabelPosition), value.ToString()), PieLabelPosition)
        Return If(position = PieLabelPosition.None, Visibility.Collapsed, Visibility.Visible)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

Public Class OrderVisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim fitType As FitType = CType([Enum].Parse(GetType(FitType), value.ToString()), FitType)
        Return If(fitType = fitType.Fourier OrElse fitType = fitType.Polynom, Visibility.Visible, Visibility.Collapsed)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

Public Class BoolToVisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim isChecked As Boolean = CType(value, Boolean)
        Return If(isChecked, Visibility.Visible, Visibility.Collapsed)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class