Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Core
Imports System.Reflection
Imports System.Linq
Imports System
Imports C1.Xaml.FlexGrid

''' <summary>
''' Interaction logic for Financial.xaml
''' </summary>
Partial Public Class Financial
    Inherits Page
    Private _financialData As FinancialDataList
    Private _loaded As Boolean = False

    Public Sub New()
        InitializeComponent()
        Dim t As IAsyncAction = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, AddressOf PopulateFinancialGrid)
        AddHandler _flexFinancial.Loaded, AddressOf _flexFinancial_Loaded
        AddHandler _flexFinancial.Unloaded, AddressOf _flexFinancial_Unloaded
    End Sub

    Private Sub _flexFinancial_Unloaded(sender As Object, e As RoutedEventArgs)
        _loaded = False
        RemoveHandler _flexFinancial.ScrollPositionChanging, AddressOf _flexFinancial_ScrollPositionChanging
        RemoveHandler _flexFinancial.ScrollPositionChanged, AddressOf _flexFinancial_ScrollPositionChanged

        If (_financialData IsNot Nothing) Then
            _financialData.AutoUpdate = False
        End If
    End Sub



    Private Sub _flexFinancial_Loaded(sender As Object, e As RoutedEventArgs)
        If Util.IsWindowsPhoneDevice Then
            SymbolColumn.Width = New GridLength(50)
            NameColumn.Visible = False
        End If

        If (_financialData IsNot Nothing) Then
            _financialData.AutoUpdate = _chkAutoUpdate.IsChecked.Value
        End If

        AddHandler _flexFinancial.ScrollPositionChanging, AddressOf _flexFinancial_ScrollPositionChanging
        AddHandler _flexFinancial.ScrollPositionChanged, AddressOf _flexFinancial_ScrollPositionChanged
        _loaded = True
    End Sub

    Async Sub PopulateFinancialGrid()
        ' populate the grid
        _financialData = Await FinancialData.GetFinancialData()
        Dim view As New C1.Xaml.C1CollectionView(_financialData)

        If (Not _loaded) Then
            _financialData.AutoUpdate = False
        End If

        _flexFinancial.ItemsSource = view
        AddHandler _flexFinancial.ScrollPositionChanging, AddressOf _flexFinancial_ScrollPositionChanging
        AddHandler _flexFinancial.ScrollPositionChanged, AddressOf _flexFinancial_ScrollPositionChanged
        AddHandler view.VectorChanged, AddressOf View_VectorChanged

        ' configure search box
        _srchCompanies.View = view
        Dim props As List(Of PropertyInfo) = _srchCompanies.FilterProperties
        props.Add(GetType(FinancialData).GetRuntimeProperty("Name"))
        props.Add(GetType(FinancialData).GetRuntimeProperty("Symbol"))

        ' show company info
        UpdateCompanyStatus()
        UpdateCellFactory()
    End Sub

    Sub _flexFinancial_ScrollPositionChanged(sender As Object, e As EventArgs)
        _financialData.AutoUpdate = _chkAutoUpdate.IsChecked.Value
    End Sub

    Sub _flexFinancial_ScrollPositionChanging(sender As Object, e As EventArgs)
        ' suspend data updates during scrolling
        _financialData.AutoUpdate = False
    End Sub

    Sub View_VectorChanged(sender As Windows.Foundation.Collections.IObservableVector(Of Object), [event] As Windows.Foundation.Collections.IVectorChangedEventArgs)
        UpdateCompanyStatus()
    End Sub

    ' update song status
    Sub UpdateCompanyStatus()
        Dim view As ICollectionView = TryCast(_flexFinancial.ItemsSource, ICollectionView)
        Dim companies As IEnumerable(Of FinancialData) = view.OfType(Of FinancialData)()
        _txtCompanies.Text = String.Format(Strings.CompaniesInfo, (From c In companies Select c.Symbol).Distinct().Count())
    End Sub

    ' control update frequency
    Sub _chkAutoUpdate_Click(sender As Object, e As RoutedEventArgs)
        _financialData.AutoUpdate = (CType(sender, CheckBox)).IsChecked.Value
    End Sub
    Sub _cmbUpdateInterval_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If _financialData IsNot Nothing Then
            Dim cmb As ComboBox = TryCast(sender, ComboBox)
            Dim index As Integer = cmb.SelectedIndex
            Dim ms As Integer = 10000
            Select Case index
                Case 1
                    ms = 1000
                    Exit Select
                Case 2
                    ms = 500
                    Exit Select
            End Select
            _financialData.UpdateInterval = ms
        End If
    End Sub
    Sub _cmbBatchSize_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If _financialData IsNot Nothing Then
            Dim cmb As ComboBox = TryCast(sender, ComboBox)
            Dim val As String = TryCast((CType(cmb.SelectedItem, ComboBoxItem)).Content, String)
            _financialData.BatchSize = Integer.Parse(val)
        End If
    End Sub
    Sub _chkOwnerDrawFinancial_Click(sender As Object, e As RoutedEventArgs)
        UpdateCellFactory()
    End Sub

    Private Sub UpdateCellFactory()
        _flexFinancial.CellFactory = If(_chkOwnerDrawFinancial.IsChecked.Value, New FinancialCellFactory(), Nothing)
    End Sub

    Private Sub _cmbHeadersVisibility_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If _cmbHeadersVisibility IsNot Nothing AndAlso _flexFinancial IsNot Nothing Then
            _flexFinancial.HeadersVisibility = CType([Enum].Parse(GetType(HeadersVisibility), TryCast((CType(_cmbHeadersVisibility.SelectedItem, ComboBoxItem)).Content, String)), HeadersVisibility)
        End If
    End Sub

    Private Sub _flexFinancial_CellContentChanging(sender As C1FlexGrid, args As CellContentChangingEventArgs)
        If args.Phase = 0 Then
            args.RegisterUpdateCallback(AddressOf _flexFinancial_CellContentChanging)
        ElseIf args.Phase = 1 Then
            Dim factory As FinancialCellFactory = TryCast(_flexFinancial.CellFactory, FinancialCellFactory)
            If factory IsNot Nothing Then
                factory.ShowLiveData(_flexFinancial, args.Range, args.Cell)
            End If
        End If
    End Sub
End Class