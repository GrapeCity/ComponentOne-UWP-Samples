Imports C1.Xaml.Chart
Imports C1.Chart
Imports System.Linq
Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class Introduction
    Inherits Page
    Private _chartTypes As Dictionary(Of ChartType, String)
    Private _fruits As List(Of FruitDataItem)
    Private _palettes As List(Of String)
    Private _stackings As List(Of String)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property ChartTypes() As Dictionary(Of ChartType, String)
        Get
            If _chartTypes Is Nothing Then
                _chartTypes = DataCreator.CreateSimpleChartTypes()
            End If

            Return _chartTypes
        End Get
    End Property

    Public ReadOnly Property Palettes() As List(Of String)
        Get
            If _palettes Is Nothing Then
                _palettes = [Enum].GetNames(GetType(Palette)).ToList()
            End If

            Return _palettes
        End Get
    End Property

    Public ReadOnly Property Stackings() As List(Of String)
        Get
            If _stackings Is Nothing Then
                _stackings = [Enum].GetNames(GetType(Stacking)).ToList()
            End If

            Return _stackings
        End Get
    End Property

    Public ReadOnly Property Data() As List(Of FruitDataItem)
        Get
            If _fruits Is Nothing Then
                _fruits = DataCreator.CreateFruit()
            End If

            Return _fruits
        End Get
    End Property

    Public ReadOnly Property FlexChartInstance() As C1FlexChart
        Get
            Return flexChart
        End Get
    End Property

    Private Sub cbStackedGroup_CheckChanged(sender As Object, e As RoutedEventArgs)
        Dim group1() As Integer = {0}
        Dim group2() As Integer = {1, 2}

        If (cbStackedGroup.IsChecked IsNot Nothing And cbStackedGroup.IsChecked.Value) Then
            flexChart.Series(0).StackingGroup = 0
            flexChart.Series(1).StackingGroup = 0
            flexChart.Series(2).StackingGroup = 1
        Else
            For Each ser As Series In flexChart.Series
                ser.StackingGroup = -1
            Next ser
        End If

    End Sub

    Private Sub chart_ParamChanged(sender As Object, e As SelectionChangedEventArgs)
        If ((flexChart.ChartType.Equals(ChartType.Column) Or flexChart.ChartType.Equals(ChartType.Bar)) And flexChart.Stacking <> Stacking.None) Then
            Me.cbStackedGroup.Visibility = Visibility.Visible
        Else
            Me.cbStackedGroup.Visibility = Visibility.Collapsed
        End If

    End Sub
End Class