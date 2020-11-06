Imports C1.Xaml.Chart
Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class SelectionModes
    Inherits Page
    Private _chartTypes As Dictionary(Of ChartType, String)
    Private _fruits As List(Of FruitDataItem)
    Private _selectionMode As List(Of String)
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

    Public ReadOnly Property Modes() As List(Of String)
        Get
            If _selectionMode Is Nothing Then
                _selectionMode = [Enum].GetNames(GetType(ChartSelectionMode)).ToList()
            End If

            Return _selectionMode
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