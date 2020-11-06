Imports System.Reflection
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Maps

Partial Public NotInheritable Class Cities
    Inherits Page

    Private vl As C1VectorLayer
    Public Sub New()
        InitializeComponent()

    End Sub

    Sub Cities_Unloaded(sender As Object, e As RoutedEventArgs) Handles Me.Unloaded
        Me.maps.Zoom = 2
        Me.maps.Center = New Point()

        'Release memory
        If vl IsNot Nothing Then
            For Each child As Object In vl.Children
                Dim place As C1VectorPlacemark = TryCast(child, C1VectorPlacemark)
                If place IsNot Nothing Then
                    RemoveHandler place.Loaded, AddressOf C1VectorPlacemark_Loaded
                End If
            Next
        End If

        vl = Nothing
        Me.maps.Layers.Clear()
    End Sub

    Sub Cities_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        Dim fc As Color = Color.FromArgb(&HFF, &HC0, &H50, &H4D)
        'maps.Foreground = new SolidColorBrush(fc);

        vl = New C1VectorLayer()

        Dim stream As Stream = GetType(Cities).GetTypeInfo().Assembly.GetManifestResourceStream("MapsSamples.Cities100K.txt")
        If stream IsNot Nothing Then
            Dim cities As List(Of City) = City.Read(stream)
            vl.ItemTemplate = CType(Resources("templCity"), DataTemplate)
            Dim source As IEnumerable(Of City) = From city In cities Order By city.Population Descending Select city
            vl.ItemsSource = source.Take(500)
        End If
        stream.Dispose()
        stream = Nothing

        maps.Layers.Add(vl)
    End Sub

    Private Sub C1VectorPlacemark_Loaded(sender As Object, e As RoutedEventArgs)
        Dim pl As C1VectorPlacemark = CType(sender, C1VectorPlacemark)
        Dim city As City = CType(pl.DataContext, City)
        ToolTipService.SetToolTip(pl, city.Name + ":" & vbLf + city.Population.ToString())
    End Sub
End Class