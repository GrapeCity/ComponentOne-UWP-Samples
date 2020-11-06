Imports C1.Xaml.Chart
Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class ChartTypes
    Inherits Page
    Private _chartTypes As Dictionary(Of ChartType, String)
    Private _fruits As List(Of FruitDataItem)
    Private _palettes As List(Of String)
    Private _stackings As List(Of String)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Types() As Dictionary(Of ChartType, String)
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
End Class