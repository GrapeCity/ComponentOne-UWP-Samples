Imports C1.Chart.Finance
Imports System.Collections.Generic
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports System.Linq
Imports System

''' <summary>
''' Interaction logic for Kagi.xaml
''' </summary>
Partial Public Class Kagi
        Inherits Page
        Private dataService As DataService = DataService.GetService()

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

        Sub Kagi_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
            cbSymbol.SelectedIndex = 0
            cbRangeMode.SelectedIndex = 0
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

        Private Sub OnRangeModeChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim rmode As String = TryCast(cbRangeMode.SelectedValue, String)
        financialChart.BeginUpdate()
            If rmode = "Fixed" Then
                cbReversalAmount.Minimum = 1
                cbReversalAmount.Maximum = 14
                cbReversalAmount.Increment = 1
                cbReversalAmount.Format = "0"
                financialChart.Options.RangeMode = C1.Chart.Finance.RangeMode.Fixed
            ElseIf rmode = "ATR" Then
                cbReversalAmount.Minimum = 2
                cbReversalAmount.Maximum = 14
                cbReversalAmount.Increment = 1
                cbReversalAmount.Format = "0"
                If financialChart.Options.ReversalAmount < 2 Then
                    financialChart.Options.ReversalAmount = 2
                End If
                financialChart.Options.RangeMode = C1.Chart.Finance.RangeMode.ATR
            Else
                cbReversalAmount.Minimum = 0
                cbReversalAmount.Maximum = 1
                cbReversalAmount.Format = "0.00"
                cbReversalAmount.Increment = 0.05
                If cbReversalAmount.Value >= 1 Then
                    cbReversalAmount.Value = 0.05
                End If
                financialChart.Options.RangeMode = C1.Chart.Finance.RangeMode.Percentage
            End If
            financialChart.EndUpdate()
        End Sub
    End Class