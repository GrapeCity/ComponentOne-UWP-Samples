Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System
Imports C1.Chart

''' <summary>
''' Interaction logic for BoxWhisker.xaml
''' </summary>
Partial Public Class ErrorBar
    Inherits Page
    Private _chartTypes As Dictionary(Of ChartType, String)
    Private _errorAmounts As List(Of String)

    Private _data As Sale() = Nothing
    Private _directions As List(Of String)
    Private _endStyles As List(Of String)


    Public Sub New()
        InitializeComponent()
    End Sub

    Public ReadOnly Property ChartTypes() As Dictionary(Of ChartType, String)
        Get
            If _chartTypes Is Nothing Then
                _chartTypes = DataCreator.CreateChartTypesForErrorBar()
            End If

            Return _chartTypes
        End Get
    End Property

    Public ReadOnly Property ErrorAmounts() As List(Of String)
        Get
            If _errorAmounts Is Nothing Then
                _errorAmounts = [Enum].GetNames(GetType(ErrorAmount)).ToList()
            End If
            Return _errorAmounts
        End Get
    End Property

    Public ReadOnly Property Directions() As List(Of String)
        Get
            If _directions Is Nothing Then
                _directions = [Enum].GetNames(GetType(ErrorBarDirection)).ToList()
            End If

            Return _directions
        End Get
    End Property

    Public ReadOnly Property EndStyles() As List(Of String)
        Get
            If _endStyles Is Nothing Then
                _endStyles = [Enum].GetNames(GetType(ErrorBarEndStyle)).ToList()
            End If

            Return _endStyles
        End Get
    End Property


    Public ReadOnly Property Data() As Sale()
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateSales()
            End If

            Return _data
        End Get
    End Property

    Private Sub cboErrorAmounts_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim comboBox As Object = TryCast(sender, ComboBox)
        If comboBox.SelectedValue IsNot Nothing AndAlso errorBarSeries IsNot Nothing Then
            Dim value As ErrorAmount = CType([Enum].Parse(GetType(ErrorAmount), comboBox.SelectedValue.ToString()), ErrorAmount)
            Select Case value
                Case ErrorAmount.FixedValue
                    errorBarSeries.ErrorValue = 5
                    Exit Select
                Case ErrorAmount.Percentage
                    errorBarSeries.ErrorValue = 0.1
                    Exit Select
                Case ErrorAmount.StandardDeviation
                    errorBarSeries.ErrorValue = 1
                    Exit Select
                Case ErrorAmount.[Custom]
                    errorBarSeries.CustomMinusErrorValue = 3
                    errorBarSeries.CustomPlusErrorValue = 5
                    Exit Select
            End Select
        End If
    End Sub
End Class