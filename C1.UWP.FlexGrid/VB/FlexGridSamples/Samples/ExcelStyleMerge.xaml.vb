Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports C1.Xaml.FlexGrid

Partial Public Class ExcelStyleMerge
    Inherits Page
    Private _xlMergeManager As ExcelStyleMergeManager

    Public Sub New()
        InitializeComponent()
        _xlMergeManager = New ExcelStyleMergeManager(_flex)
        _flex.MergeManager = _xlMergeManager
        _flex.AllowMerging = AllowMerging.Cells
        AddHandler Loaded, AddressOf ExcelStyleMerge_Loaded
    End Sub

    Private Async Sub ExcelStyleMerge_Loaded(sender As Object, e As RoutedEventArgs)
        Dim data As List(Of NorthwindData) = Await NorthwindStorage.Load()
        _flex.ItemsSource = data
    End Sub

    Sub _btnMerge_Click(sender As Object, e As RoutedEventArgs)
        _xlMergeManager.AddMergedRange(_flex.Selection)
    End Sub
    Sub _btnSplit_Click(sender As Object, e As RoutedEventArgs)
        _xlMergeManager.RemoveMergedRange(_flex.Selection)
    End Sub
End Class