Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Chart
Imports C1.Xaml
Imports C1.Chart

' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Partial Public NotInheritable Class TrendLine
    Inherits Page
    Private _dragHelper As C1DragHelper
    Private clickedItem As DataItem
    Private rnd As New Random()
    Private _data As ObservableCollection(Of DataItem)
    Private _fitTypes As List(Of String)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As ObservableCollection(Of DataItem)
        Get
            If _data Is Nothing Then
                _data = New ObservableCollection(Of DataItem)()
                Dim i As Integer = 1
                While i < 11
                    _data.Add(New DataItem() With {
                        .X = i,
                        .Y = rnd.[Next](100)
                    })
                    i += 1
                End While
            End If

            Return _data
        End Get
    End Property

    Public ReadOnly Property FitTypes() As List(Of String)
        Get
            If _fitTypes Is Nothing Then
                _fitTypes = [Enum].GetNames(GetType(FitType)).ToList()
            End If

            Return _fitTypes
        End Get
    End Property

    Public ReadOnly Property TrendLineSeries() As C1.Xaml.Chart.TrendLine
        Get
            Return trendLine
        End Get
    End Property

    Function GetEquationString(trendLine As C1.Xaml.Chart.TrendLine) As String
        Dim result As String = [String].Empty
        Dim X As Integer = 1, Y0 As Integer = 0
        Dim order As Object = trendLine.Order

        Select Case trendLine.FitType
            Case FitType.Linear
                result = [String].Format("y={1:0.0000}x{0:+0.0000;-0.0000;+0}", trendLine.Coefficients(0), trendLine.Coefficients(1))
                Exit Select
            Case FitType.Exponent
                result = [String].Format("y={0:0.0000}e<sup>{1:0.0000}x</sup>", trendLine.Coefficients(0), trendLine.Coefficients(1))
                Exit Select
            Case FitType.Logarithmic
                result = [String].Format("y={1:0.0000}ln(x){0:+0.0000;-0.0000;+0}", trendLine.Coefficients(0), trendLine.Coefficients(1))
                Exit Select
            Case FitType.Power
                result = [String].Format("y={0:0.0000}x<sup>{1:0.0000}</sup>", trendLine.Coefficients(0), trendLine.Coefficients(1))
                Exit Select
            Case FitType.Polynom
                result = [String].Format("{1:+0.0000;-0.0000;+0}x{0:+0.0000;-0.0000;+0}", trendLine.Coefficients(0), trendLine.Coefficients(1))
                Dim i As Integer = 2
                While i <= CType(order, Integer)
                    result = result.Insert(0, [String].Format("{0:+0.000;-0.0000;+0}x<sup>{1}</sup>", trendLine.Coefficients(i), i))
                    i += 1
                End While
                result = result.Remove(0, 1).Insert(0, "y=")
                Exit Select
            Case FitType.Fourier
                result = [String].Format("{0:+0.0000;-0.0000;+0}", trendLine.Coefficients(0))
                Dim i As Integer = 2, a As Integer = 1
                While i <= CType(order, Integer)
                    result += [String].Format("{0:+0.000;-0.0000;+0}{2}({1}x)", trendLine.Coefficients(i - 1), If(a = 1, "", a.ToString()), If((i) Mod 2 = 0, "cos", "sin"))
                    i += 1
                    a = If(i Mod 2 = 0, a + 1, a)
                End While
                result = result.Remove(0, 1).Insert(0, "y=")
                Exit Select
            Case FitType.MaxX
                result = "x=" + trendLine.GetValues(X).Max().ToString()
                Exit Select
            Case FitType.MinX
                result = "x=" + trendLine.GetValues(X).Min().ToString()
                Exit Select
            Case FitType.MaxY
                result = "y=" + trendLine.GetValues(Y0).Max().ToString()
                Exit Select
            Case FitType.MinY
                result = "y=" + trendLine.GetValues(Y0).Min().ToString()
                Exit Select
            Case FitType.AverageX
                result = "x=" + trendLine.GetValues(X).Average().ToString()
                Exit Select
            Case FitType.AverageY
                result = "y=" + trendLine.GetValues(Y0).Average().ToString()
                Exit Select
        End Select
        Return result
    End Function

#Region "Event Handler"

    Sub HandleLoaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        _dragHelper = New C1DragHelper(flexChart, C1DragHelperMode.TranslateXY, captureElementOnPointerPressed:=True, useManipulationEvents:=True)
        AddHandler _dragHelper.DragStarted, AddressOf HandleDragStarted
        AddHandler _dragHelper.DragDelta, AddressOf HandleDragDelta
        AddHandler _dragHelper.DragCompleted, AddressOf HandleDragCompleted
        Window.Current.CoreWindow.PointerCursor = New CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0)
    End Sub

    Sub HandlePointerPressed(sender As Object, e As PointerRoutedEventArgs)
        Dim ht As HitTestInfo = flexChart.HitTest(e.GetCurrentPoint(flexChart).Position)
        If ht.Distance < 3 AndAlso ht.X IsNot Nothing AndAlso ht.Y IsNot Nothing Then
            clickedItem = TryCast(ht.Item, DataItem)
        End If
    End Sub

    Sub HandleDragStarted(sender As Object, e As C1DragStartedEventArgs)
        Dim ht As Object = flexChart.HitTest(e.GetPosition(flexChart))
        If ht.Distance < 3 AndAlso ht.X IsNot Nothing AndAlso ht.Y IsNot Nothing Then
            clickedItem = TryCast(ht.Item, DataItem)
        End If
    End Sub

    Sub HandleDragDelta(sender As Object, e As C1DragDeltaEventArgs)
        If clickedItem IsNot Nothing Then
            Dim newY As Integer = CType(flexChart.PointToData(e.GetPosition(flexChart)).Y, Integer)
            If newY >= 0 AndAlso newY <= 100 Then
                clickedItem.Y = newY
            End If
        End If
    End Sub

    Sub HandleDragCompleted(sender As Object, e As C1DragCompletedEventArgs)
        clickedItem = Nothing
    End Sub

    Sub HandleRendered(sender As Object, e As RenderEventArgs)
        rich.Html = GetEquationString(trendLine)
    End Sub

#End Region

#Region "DataItem"

    Public Class DataItem
        Implements INotifyPropertyChanged
        Private _y As Integer
        Public Property X() As Integer

        Public Property Y() As Integer
            Get
                Return _y
            End Get
            Set
                If Value = _y Then
                    Return
                End If
                _y = Value

                OnPropertyChanged("Y")
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Protected Overridable Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class

#End Region
End Class