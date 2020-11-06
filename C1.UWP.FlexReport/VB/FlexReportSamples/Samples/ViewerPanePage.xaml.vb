Imports System.Reflection

Imports Windows.Storage
Imports Windows.UI.Popups

Imports C1.Xaml
Imports C1.Xaml.FlexReport
Imports C1.Xaml.FlexViewer

Partial Public NotInheritable Class ViewerPanePage
    Inherits Page
    Private _report As C1FlexReport

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Unloaded, AddressOf ViewerPage_Unloaded
        AddHandler Me.Loaded, AddressOf ViewerPage_Loaded

        _report = New C1FlexReport()
    End Sub

    Private Sub ViewerPage_Unloaded(sender As Object, e As RoutedEventArgs)
        RemoveHandler cbReport.SelectionChanged, AddressOf CbReport_SelectionChanged

        flexViewerPane.DocumentSource = Nothing
        _report.Dispose()
        _report = Nothing
    End Sub

    Private Async Sub ViewerPage_Loaded(sender As Object, e As RoutedEventArgs)
        Dim asm As Assembly = GetType(ExportPage).GetTypeInfo().Assembly
        Await ExportPage.CopyC1NWind()

        Dim reports As String() = Nothing

        ' get list of reports from resource using stream
        Using stream As Stream = asm.GetManifestResourceStream("FlexReportSamples.FlexCommonTasks_UWP.flxr")
            reports = C1FlexReport.GetReportList(stream)
        End Using

        cbReport.Items.Clear()
        AddHandler cbReport.SelectionChanged, AddressOf CbReport_SelectionChanged

        If reports IsNot Nothing AndAlso reports.Length > 0 Then
            For Each s As String In reports
                cbReport.Items.Add(s)
            Next
            cbReport.SelectedIndex = 0
        End If
    End Sub

    Private Async Sub CbReport_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim selectedReport As String = TryCast(cbReport.SelectedItem, String)
        If String.IsNullOrEmpty(selectedReport) Then
            Return
        End If
        Dim commonEx As Exception = Nothing

        ' load report
        Try
            ' load from resource stream
            Dim asm As Assembly = GetType(ExportPage).GetTypeInfo().Assembly
            Using stream As Stream = asm.GetManifestResourceStream("FlexReportSamples.FlexCommonTasks_UWP.flxr")
                _report.Load(stream, selectedReport)
            End Using
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.FailedToLoadFmt, selectedReport, commonEx.Message), "Error")
            Await md.ShowAsync()
            Return
        End If

        flexViewerPane.DocumentSource = Nothing
        flexViewerPane.DocumentSource = _report
    End Sub

    Private Sub MenuFlyout_Opening(sender As Object, e As Object)
        Dim mf As MenuFlyout = CType(sender, MenuFlyout)
        For Each mfib As MenuFlyoutItemBase In mf.Items
            Select Case mfib.Name
                Case "mfiActualSize"
                    CType(mfib, MenuFlyoutItem).Command = flexViewerPane.ActualSizeCommand
                Case "mfiPageWidth"
                    CType(mfib, MenuFlyoutItem).Command = flexViewerPane.PageWidthCommand
                Case "mfiWholePage"
                    CType(mfib, MenuFlyoutItem).Command = flexViewerPane.WholePageCommand
                Case "mfiOnePage"
                    CType(mfib, MenuFlyoutItem).Command = flexViewerPane.OnePageViewCommand
                Case "mfiFacingPages"
                    CType(mfib, MenuFlyoutItem).Command = flexViewerPane.FacingPagesCommand
                Case "mfiTwoPages"
                    CType(mfib, MenuFlyoutItem).Command = flexViewerPane.TwoPagesViewCommand
                Case "mfiFourPages"
                    CType(mfib, MenuFlyoutItem).Command = flexViewerPane.FourPagesViewCommand
            End Select
        Next
    End Sub
End Class
