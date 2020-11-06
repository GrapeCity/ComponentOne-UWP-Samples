Imports C1.Chart.Finance
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Linq
Imports System.Collections.Generic
Imports System

''' <summary>
''' Interaction logic for Renko.xaml
''' </summary>
Partial Public Class Renko
    Inherits Page
    Private dataService As DataService = dataService.GetService()

    Public Sub New()
        InitializeComponent()
    End Sub

    Public ReadOnly Property Companies() As List(Of Company)
        Get
            Return dataService.GetCompanies()
        End Get
    End Property

    Public ReadOnly Property RangeMode() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(RangeMode)).ToList()
        End Get
    End Property

    Public ReadOnly Property DataFields() As List(Of String)
        Get
            Return [Enum].GetNames(GetType(DataFields)).ToList()
        End Get
    End Property

    Sub Renko_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        cbSymbol.SelectedIndex = 0
    End Sub

    Sub OnSymbolSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If financialChart IsNot Nothing Then
            Dim c As Company = TryCast(cbSymbol.SelectedValue, Company)
            Dim data As Object = dataService.GetSymbolData(c.Symbol)
            financialChart.BeginUpdate()
            financialChart.ItemsSource = data
            financialChart.EndUpdate()
        End If
    End Sub
End Class