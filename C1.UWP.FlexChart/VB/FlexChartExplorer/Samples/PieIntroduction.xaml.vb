Imports C1.Chart
Imports Windows.UI.Xaml.Controls
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class PieIntroduction
    Inherits Page
    Private _data As List(Of FruitDataItem)
    Private _palettes As List(Of String)
    Private _labelPositions As List(Of String)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of FruitDataItem)
        Get
            If _data Is Nothing Then
                _data = DataCreator.CreateFruit()
            End If
            Return _data
        End Get
    End Property

    Public ReadOnly Property Radius() As List(Of Double)
        Get
            Return New List(Of Double)() From {0, 0.25, 0.5, 0.75}
        End Get
    End Property

    Public ReadOnly Property Offsets() As List(Of Double)
        Get
            Return New List(Of Double)() From {0, 0.1, 0.2, 0.3, 0.4, 0.5}
        End Get
    End Property

    Public ReadOnly Property StartAngles() As List(Of Double)
        Get
            Return New List(Of Double)() From {0, 90, 180, -90}
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

    Public ReadOnly Property LabelPositions() As List(Of String)
        Get
            If _labelPositions Is Nothing Then
                _labelPositions = [Enum].GetNames(GetType(PieLabelPosition)).ToList()
            End If
            Return _labelPositions
        End Get
    End Property

    Public ReadOnly Property LabelsBorders() As List(Of Boolean)
        Get
            Return New List(Of Boolean)() From {False, True}
        End Get
    End Property

End Class