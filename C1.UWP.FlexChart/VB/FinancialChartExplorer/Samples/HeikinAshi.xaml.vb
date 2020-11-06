Imports Windows.UI.Xaml.Controls
Imports System.Windows
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports Windows.UI.Xaml
Imports System

''' <summary>
''' Interaction logic for HeikinAshi.xaml
''' </summary>
Partial Public Class HeikinAshi
        Inherits Page
        Private dataService As DataService = DataService.GetService()

        Public Sub New()
            InitializeComponent()
        End Sub

        Sub HeikinAshi_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
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

        Public ReadOnly Property Companies() As List(Of Company)
            Get
                Return dataService.GetCompanies()
            End Get
        End Property
End Class