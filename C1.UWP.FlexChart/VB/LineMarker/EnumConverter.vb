Imports C1.Xaml.Chart.Interaction
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml
Imports System.Linq
Imports System

Public Class EnumConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Dim t As Type = value.[GetType]()
        If t Is GetType(LineMarkerAlignment) Then
            Dim model As LineMarkerViewModel = TryCast(parameter, LineMarkerViewModel)
            Dim alignments As Dictionary(Of String, LineMarkerAlignment) = model.LineMarkerAlignments
            Dim alignment As LineMarkerAlignment = CType([Enum].Parse(GetType(LineMarkerAlignment), value.ToString()), LineMarkerAlignment)
            Return alignments.Values.ToList().IndexOf(alignment)
        End If

        Return value.ToString()
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        If targetType Is GetType(Boolean) Then
            Return Boolean.Parse(value.ToString())
        Else
            If targetType Is GetType(LineMarkerAlignment) Then
                Dim model As LineMarkerViewModel = TryCast(parameter, LineMarkerViewModel)
                Dim alignments As Dictionary(Of String, LineMarkerAlignment) = model.LineMarkerAlignments
                Return alignments.Values.ElementAt(Integer.Parse(value.ToString()))
            Else
                Return [Enum].Parse(targetType, value.ToString())
            End If
        End If
    End Function
End Class

Public Class VisibilityConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.Convert
        Dim val As LineMarkerInteraction = CType([Enum].Parse(GetType(LineMarkerInteraction), value.ToString()), LineMarkerInteraction)
        Return If(val = LineMarkerInteraction.Drag, Visibility.Visible, Visibility.Collapsed)
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As String) As Object Implements IValueConverter.ConvertBack
        Throw New NotImplementedException()
    End Function
End Class