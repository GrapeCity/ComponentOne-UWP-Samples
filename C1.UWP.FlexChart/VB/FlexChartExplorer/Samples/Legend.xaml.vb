Imports C1.Xaml.Chart
Imports C1.Chart
Imports System.Linq
Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Legend
    Inherits Page
    Private _fruits As List(Of FruitsDataItem)
    Private _legendPostion As List(Of String)
    Private _legendOrientation As List(Of String)
    Private _legendTextWrapping As List(Of String)
    Private _legendMaxWidth As List(Of LegendMaxWidthItem)

    Public Sub New()
        Me.InitializeComponent()
    End Sub
    Private Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        Me.cbMaxWidth.SelectedIndex = 0
    End Sub

    Public ReadOnly Property Data() As List(Of FruitsDataItem)
        Get
            If _fruits Is Nothing Then
                _fruits = DataCreator.CreateFruits()
            End If

            Return _fruits
        End Get
    End Property

    Public ReadOnly Property LegendPosition() As List(Of String)
        Get

            If _legendPostion Is Nothing Then

                _legendPostion = [Enum].GetNames(GetType(Position)).ToList()
            End If
            Return _legendPostion
        End Get
    End Property

    Public ReadOnly Property LegendOrientation() As List(Of String)
        Get
            If _legendOrientation Is Nothing Then
                _legendOrientation = [Enum].GetNames(GetType(C1.Chart.Orientation)).ToList()
            End If

            Return _legendOrientation
        End Get
    End Property

    Public ReadOnly Property LegendTextWrapping() As List(Of String)
        Get
            If _legendTextWrapping Is Nothing Then
                _legendTextWrapping = [Enum].GetNames(GetType(C1.Chart.TextWrapping)).ToList()
            End If

            Return _legendTextWrapping
        End Get
    End Property

    Public ReadOnly Property LegendMaxWidth() As List(Of LegendMaxWidthItem)
        Get
            If _legendMaxWidth Is Nothing Then
                _legendMaxWidth = New List(Of LegendMaxWidthItem)()

                _legendMaxWidth.Add(New LegendMaxWidthItem("Narrow", 80))
                _legendMaxWidth.Add(New LegendMaxWidthItem("Middle", 180))
                _legendMaxWidth.Add(New LegendMaxWidthItem("Wide", 360))
            End If

            Return _legendMaxWidth
        End Get
    End Property

    Private Sub cbCheckBox_Checked(sender As Object, e As RoutedEventArgs)
        If cbCheckBox.IsChecked.HasValue And flexChart IsNot Nothing Then
            For Each ser As ISeries In flexChart.Series
                Dim start As Integer = ser.Name.IndexOf("The quick ") + "The quick ".Length
                Dim endchr As Integer = ser.Name.IndexOf(" jumps over")
                Dim groupName As String = ser.Name.Substring(start, endchr - start)
                If cbCheckBox.IsChecked Then
                    ser.LegendGroup = groupName
                Else
                    ser.LegendGroup = Nothing
                End If
            Next
        End If
    End Sub
End Class
Public Class LegendMaxWidthItem

    Public Sub New(name As String, value As Integer)
        _name = name
        _value = value
    End Sub

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _value As Integer
    Public Property Value() As Integer
        Get
            Return _value
        End Get
        Set(ByVal value As Integer)
            _value = value
        End Set
    End Property

End Class
Public NotInheritable Class MaxWidthConverter
    Implements IValueConverter
    Public Function Convert(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.Convert
        Return Nothing
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, language As String) As Object Implements IValueConverter.ConvertBack
        Dim item As LegendMaxWidthItem = CType(value, LegendMaxWidthItem)

        If item Is Nothing Then
            Return 0
        Else
            Return item.Value
        End If
    End Function
End Class