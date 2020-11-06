Imports Windows.UI.Core
Imports Windows.UI.Popups

Imports C1.Xaml
Imports C1.Xaml.FlexViewer

Partial Public NotInheritable Class CatalogView
    Inherits Page
    Implements IFlexViewerToolPanel

    Shared _lastY As Double

    Private _fv As C1FlexViewer
    Private _mainPage As MainPage
    Private _sv As ScrollViewer

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub IFlexViewerToolPanel_SetViewer(fv As C1FlexViewer) Implements IFlexViewerToolPanel.SetViewer
        _fv = fv
        _mainPage = Nothing
        Dim el As DependencyObject = fv
        Do
            el = VisualTreeHelper.GetParent(el)
            _mainPage = TryCast(el, MainPage)
        Loop While _mainPage Is Nothing AndAlso el IsNot Nothing
        If _mainPage Is Nothing Then
            Return
        End If
        treeView.ItemsSource = _mainPage.Categories

        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed

        Dim obj As DependencyObject = treeView
        While _sv Is Nothing AndAlso VisualTreeHelper.GetChildrenCount(obj) > 0
            obj = VisualTreeHelper.GetChild(obj, 0)
            _sv = TryCast(obj, ScrollViewer)
        End While
        If (_lastY > 0 AndAlso _sv IsNot Nothing) OrElse _mainPage.DefaultReportName IsNot Nothing Then
            AddHandler treeView.LayoutUpdated, AddressOf TreeView_LayoutUpdated
        End If
    End Sub

    Private Sub TreeView_LayoutUpdated(sender As Object, e As Object)
        RemoveHandler treeView.LayoutUpdated, AddressOf TreeView_LayoutUpdated
        If _mainPage.DefaultReportName Is Nothing Then
            _sv.ChangeView(Nothing, _lastY, Nothing, True)
        Else
            Dim catName As String = _mainPage.DefaultCategoryName
            Dim rptName As String = _mainPage.DefaultReportName
            For Each cat As FlexReportExplorer.Category In treeView.Items
                If cat IsNot Nothing AndAlso cat.Name = catName Then
                    Dim catItem = TryCast(treeView.ContainerFromItem(cat), C1TreeViewItem)
                    If catItem IsNot Nothing Then
                        If Not catItem.IsExpanded Then
                            catItem.EnsureVisible()
                            AddHandler treeView.LayoutUpdated, AddressOf TreeView_LayoutUpdated
                            catItem.Expand()
                        Else
                            For Each rpt As FlexReportExplorer.Report In catItem.Items
                                If rpt IsNot Nothing AndAlso rpt.ReportName = rptName Then
                                    _mainPage.ClearDefaults()
                                    Dim tvi = TryCast(catItem.ContainerFromItem(rpt), C1TreeViewItem)
                                    If tvi IsNot Nothing Then
                                        tvi.EnsureVisible()
                                        tvi.IsSelected = True
                                    End If
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub IFlexViewerToolPanel_OnHiding() Implements IFlexViewerToolPanel.OnHiding
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible
        If _sv IsNot Nothing Then
            _lastY = _sv.VerticalOffset
        End If
        treeView.ItemsSource = Nothing
    End Sub

    Private Function IFlexViewerToolPanel_GetViewHeader() As ViewHeader Implements IFlexViewerToolPanel.GetViewHeader
        Return ViewHeader
    End Function

    Private Sub Close_Tapped(sender As Object, e As TappedRoutedEventArgs)
        _fv.HideToolPanel()
    End Sub

    Private Async Sub TreeView_ItemClick(sender As Object, e As C1.Xaml.SourcedEventArgs)
        Dim reportName As String = String.Empty
        Dim commonEx As Exception = Nothing
        Try
            Dim selectedItem = treeView.SelectedItem
            Dim rpt = TryCast(selectedItem.DataContext, FlexReportExplorer.Report)
            If rpt IsNot Nothing Then
                reportName = rpt.ReportName
                If Not String.IsNullOrEmpty(reportName) Then
                    ' load report
                    Await _mainPage.LoadReport(rpt.CategoryName.Trim(), rpt.FileName, reportName)

                    If Not _fv.IsExpandedContent Then
                        _fv.HideToolPanel()
                        Return
                    End If
                End If
            End If
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.ReportErrorFormat, reportName, commonEx.Message))
            Await md.ShowAsync()
        End If
    End Sub
End Class
