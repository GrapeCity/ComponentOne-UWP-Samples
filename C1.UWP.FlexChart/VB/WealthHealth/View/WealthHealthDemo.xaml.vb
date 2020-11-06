Imports Windows.UI.Xaml.Markup
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports C1.Xaml.Chart
Imports C1.Chart

''' <summary>
''' Interaction logic for WealthHealthDemo.xaml
''' </summary>
Partial Public Class WealthHealthDemo
    Inherits UserControl
    Public Sub New()
        InitializeComponent()
    End Sub

    Sub Series_SymbolRendering(sender As Object, e As RenderSymbolEventArgs)
        Dim country As Country = TryCast(e.Item, Country)
        If country IsNot Nothing Then
            Dim selectedIndex As Integer = flexChart.SelectedIndex
            Dim fill As New SolidColorBrush(GetColorByRegion(country.Region))
            Dim engine As IRenderEngine = e.Engine
            engine.SetStroke(Nothing)
            If selectedIndex = -1 Then
                fill = TryCast(engine.SetOpacity(fill, 0.5), SolidColorBrush)
                engine.SetFill(fill)
            Else
                Dim dataContext As WealthHealthViewModel = TryCast(Root.DataContext, WealthHealthViewModel)
                If dataContext.Countries(selectedIndex) Is country Then
                    Dim strokeClr As Color = ConvertFromString("#b6ff00")
                    engine.SetStroke(New SolidColorBrush(strokeClr))
                    engine.SetStrokeThickness(6.0)
                    engine.SetFill(fill)
                Else
                    fill = TryCast(engine.SetOpacity(fill, 0.2), SolidColorBrush)
                    engine.SetFill(fill)
                End If
            End If
        End If
    End Sub

    Function GetColorByRegion(region As String) As Color
        Dim clr As String = String.Empty

        Select Case region
            Case "Sub-Saharan Africa"
                clr = "#FF1F77B4"
                Exit Select
            Case "South Asia"
                clr = "#FFFF7F0E"
                Exit Select
            Case "Middle East & North Africa"
                clr = "#FF2CA02C"
                Exit Select
            Case "America"
                clr = "#FFD62728"
                Exit Select
            Case "Europe & Central Asia"
                clr = "#FF9467BD"
                Exit Select
            Case "East Asia & Pacific"
                clr = "#FF8C564B"
                Exit Select
        End Select
        If String.IsNullOrEmpty(clr) Then
            Return Colors.Black
        End If

        Return ConvertFromString(clr)
    End Function

    Private Function ConvertFromString(clr As String) As Color
        Dim color As Color = CType(XamlBindingHelper.ConvertValue(GetType(Color), clr), Color)
        Return color
    End Function

    Private Sub flexChart_PointerPressed(sender As Object, e As PointerRoutedEventArgs)
        Dim hitInfo As HitTestInfo = flexChart.HitTest(e.GetCurrentPoint(flexChart).Position)
        Dim selectedCountry As Country = TryCast(hitInfo.Item, Country)
        Dim dataContext As WealthHealthViewModel = TryCast(Root.DataContext, WealthHealthViewModel)
        If selectedCountry IsNot Nothing AndAlso hitInfo.Distance < 3 Then
            If dataContext IsNot Nothing Then
                tbTip.Visibility = Visibility.Collapsed
                tbTrack.Visibility = Visibility.Visible
                dataContext.TrackContent = selectedCountry.Name
            End If
        Else
            tbTip.Visibility = Visibility.Visible
            tbTrack.Visibility = Visibility.Collapsed
        End If
        dataContext.StopAnimation()
    End Sub
End Class