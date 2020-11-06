Imports C1.Xaml.Maps
Imports System.Collections.Generic
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation
Imports System.Windows
Imports System.Text
Imports System.Linq
Imports System

Public Enum Location
    USA
    Japan
End Enum

Partial Public Class MapShape
    Inherits Page
    Private Locations As New Dictionary(Of Location, String)()
    Public Sub New()
        InitializeComponent()
    End Sub

    Sub InitialLocations()
        If Locations.Count = 0 Then
            Locations.Add(Location.USA, Strings.USA)
            Locations.Add(Location.Japan, Strings.Japan)
        End If
    End Sub
    Sub MapShape_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        InitialLocations()
        Me.countriesCombo.ItemsSource = Locations
        countriesCombo.SelectedIndex = 0
        maps.Source = Nothing
        InitialMapsByLocaltion(maps, Location.USA)
    End Sub

    Sub ProcessMap(vector As C1VectorItemBase, attribute As C1ShapeAttributes, location As Location)
        InitialVectorItemBase(vector, attribute, location)
    End Sub

    Sub InitialMapsByLocaltion(maps As C1Maps, location As Location)
        Dim layer As New C1VectorLayer()
        Dim center As New Point()
        Dim zoom As Double = 0
        Select Case location
            Case Location.USA
                Utils.LoadShapeFromResource(layer, "MapsSamples.states.shp", "MapsSamples.states.dbf", location, True, AddressOf ProcessMap)
                center = New Point(-115, 50)
                zoom = 2
                Exit Select
            Case Location.Japan
                Utils.LoadShapeFromResource(layer, "MapsSamples.jp_toku_kuni_pgn.shp", "MapsSamples.jp_toku_kuni_pgn.dbf", location, True, AddressOf ProcessMap)
                center = New Point(135, 37)
                zoom = 4
                Exit Select
        End Select

        If maps.Layers IsNot Nothing AndAlso maps.Layers.Count <> 0 Then
            maps.Layers.Clear()
        End If
        maps.Layers.Add(layer)
        maps.MinZoom = zoom
        maps.Zoom = zoom
        maps.Center = center
    End Sub

    Sub InitialVectorItemBase(vector As C1VectorItemBase, attribute As C1ShapeAttributes, location As Location)
        Dim toolTip As String = String.Empty
        vector.Stroke = New SolidColorBrush(Colors.LightGray)
        Select Case location
            Case Location.USA
                vector.Fill = New SolidColorBrush(Colors.Purple)
                toolTip = CType(attribute("STATE_NAME"), String)
                Exit Select
            Case Location.Japan
                vector.Fill = New SolidColorBrush(Colors.Brown)
                toolTip = CType(attribute("NAME_UTF"), String)
                Exit Select
        End Select
        ToolTipService.SetToolTip(vector, toolTip)
    End Sub

    Private Sub countriesCombo_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim comboBox As ComboBox = TryCast(sender, ComboBox)
        If comboBox IsNot Nothing Then
            Dim lt As Location
            If (comboBox.SelectedItem Is Nothing) Then
                lt = Location.USA
            Else
                lt = CType((CType(countriesCombo.SelectedItem, KeyValuePair(Of Location, String))).Key, Location)
            End If
            InitialMapsByLocaltion(maps, lt)
        End If
    End Sub
End Class