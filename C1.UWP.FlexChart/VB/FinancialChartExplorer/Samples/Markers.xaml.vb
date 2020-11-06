Imports C1.Chart
Imports Windows.UI.Xaml.Input
Imports Windows.UI
Imports Windows.UI.Xaml.Media
Imports System.Collections.Generic
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Linq
Imports System
Imports C1.Xaml.Chart.Interaction
Imports C1.Xaml.Chart

''' <summary>
''' Interaction logic for Markers.xaml
''' </summary>
Partial Public Class Markers
    Inherits Page
    Private dataService As DataService = DataService.GetService()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public ReadOnly Property Data() As List(Of Quote)
        Get
            Return dataService.GetSymbolData("box").Take(20).ToList()
        End Get
    End Property

    Public ReadOnly Property Alignments() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(LineMarkerAlignment)).ToList()
        End Get
    End Property

    Public ReadOnly Property Interactions() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(LineMarkerInteraction)).ToList()
        End Get
    End Property

    Public ReadOnly Property MarkerLines() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(LineMarkerLines)).ToList()
        End Get
    End Property

    Private Function CreateContent(item As Quote) As Border
        Dim textblock As New TextBlock() With
            {
                .Text = "Date: " + item.[Date] + vbLf + "Open: " + item.Open.ToString() + vbLf + "High: " + item.High.ToString() + vbLf + "Low: " + item.Low.ToString() + vbLf + "Close: " + item.Close.ToString(),
                .FontSize = 12
            }
        Dim bd As New Border() With
            {
                .Background = New SolidColorBrush(Colors.LightGray)
            }
        bd.Child = textblock
        Return bd
    End Function

    Private Sub positionChanged(sender As Object, e As PositionChangedArgs)
        If Not cbSnpping.IsChecked.Value Then
            Dim pt As Point = e.Position
            Dim hti As HitTestInfo = financialChart.HitTest(pt)
            If hti IsNot Nothing AndAlso hti.Item IsNot Nothing Then
                Dim item As Quote = TryCast(hti.Item, Quote)
                Dim textblock As Object = CreateContent(item)
                marker.Content = textblock
            End If
        End If
    End Sub

    Private Sub cbSnpping_Checked(sender As Object, e As RoutedEventArgs)
        If marker IsNot Nothing Then
            marker.Interaction = LineMarkerInteraction.None
            marker.Lines = LineMarkerLines.Both
            marker.Alignment = LineMarkerAlignment.Auto
            AddHandler financialChart.PointerMoved, AddressOf FinancialChart_PointerMoved
        End If
    End Sub

    Private Sub cbSnpping_Unchecked(sender As Object, e As RoutedEventArgs)
        If marker IsNot Nothing Then
            marker.Interaction = LineMarkerInteraction.Move
            marker.Lines = LineMarkerLines.Both
            marker.Alignment = LineMarkerAlignment.Auto
            marker.VerticalPosition = Double.NaN
            marker.HorizontalPosition = Double.NaN
            RemoveHandler financialChart.PointerMoved, AddressOf FinancialChart_PointerMoved
        End If
    End Sub

    Private Sub FinancialChart_PointerMoved(sender As Object, e As PointerRoutedEventArgs)

        If marker IsNot Nothing Then
            Dim pt As Point = e.GetCurrentPoint(financialChart).Position
            Dim dp As Point = financialChart.PointToData(pt)
            Dim idx As Integer = Math.Min(Data.Count - 1, Math.Max(0, CType(Math.Round(dp.X), Integer)))
            Dim item As Quote = Data(idx)
            Dim ax As IAxis = TryCast(financialChart.AxisX, IAxis)
            Dim ay As IAxis = TryCast(financialChart.AxisY, IAxis)
            Dim xmin As Double = ax.GetMin()
            Dim xmax As Double = ax.GetMax()
            Dim ymin As Double = ay.GetMin()
            Dim ymax As Double = ay.GetMax()
            Dim x As Object = Math.Min(1, Math.Max(0, (idx - xmin) / (xmax - xmin)))
            Dim y As Object = Math.Min(1, Math.Max(0, (ymax - dp.Y) / (ymax - ymin)))
            marker.Content = CreateContent(item)
            marker.HorizontalPosition = x
            marker.VerticalPosition = y
        End If
    End Sub

    Private Sub OnSplitterButtonClick(sender As Object, e As RoutedEventArgs)
        splitter.IsPaneOpen = Not splitter.IsPaneOpen
    End Sub
End Class