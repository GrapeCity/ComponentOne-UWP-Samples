Imports C1.Chart.Finance
Imports C1.Chart
Imports MovingAverageType = C1.Chart.MovingAverageType
Imports C1.Xaml.Chart.Interaction

Public Class EnumConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return value.ToString()
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        If targetType Is GetType(FitType) Then
            Return CType([Enum].Parse(GetType(FitType), value.ToString()), FitType)
        ElseIf targetType Is GetType(MovingAverageType) Then
            Return CType([Enum].Parse(GetType(MovingAverageType), value.ToString()), MovingAverageType)
        ElseIf targetType Is GetType(RangeMode) Then
            Return CType([Enum].Parse(GetType(RangeMode), value.ToString()), RangeMode)
        ElseIf targetType Is GetType(DataFields) Then
            Return CType([Enum].Parse(GetType(DataFields), value.ToString()), DataFields)
        ElseIf targetType Is GetType(LabelPosition) Then
            Return CType([Enum].Parse(GetType(LabelPosition), value.ToString()), LabelPosition)
        ElseIf targetType Is GetType(LineMarkerAlignment) Then
            Return CType([Enum].Parse(GetType(LineMarkerAlignment), value.ToString()), LineMarkerAlignment)
        ElseIf targetType Is GetType(LineMarkerInteraction) Then
            Return CType([Enum].Parse(GetType(LineMarkerInteraction), value.ToString()), LineMarkerInteraction)
        ElseIf targetType Is GetType(LineMarkerLines) Then
            Return CType([Enum].Parse(GetType(LineMarkerLines), value.ToString()), LineMarkerLines)
        ElseIf targetType Is GetType(Boolean) Then
            Return Boolean.Parse(value.ToString())
        End If
        Return value
    End Function
End Class

Public Class IntToVisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim index As Integer = Integer.Parse(value.ToString())
        Dim para As Integer = Integer.Parse(parameter.ToString())
        If index = para Then
            Return Visibility.Visible
        Else
            Return Visibility.Collapsed
        End If
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class

Public Class ReversedConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim val As Boolean = Boolean.Parse(value.ToString())
        Return Not val
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class