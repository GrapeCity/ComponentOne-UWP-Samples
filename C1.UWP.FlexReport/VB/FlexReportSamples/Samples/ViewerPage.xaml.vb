Imports System.Reflection

Imports Windows.Storage
Imports Windows.UI.Popups

Imports C1.Xaml.FlexReport
Imports C1.Xaml.Document

Partial Public NotInheritable Class ViewerPage
    Inherits Page

    Private _report As C1FlexReport
    Private _pdfDocSource As C1PdfDocumentSource
    Private _asm As Assembly

    Private _pdfs As String() = New String() {"C1XapOptimizer.pdf", "ComparisonOfFormats.pdf", "TEST_ECG.pdf"}

    Public Sub New()
        Me.InitializeComponent()
        AddHandler Me.Unloaded, AddressOf ViewerPage_Unloaded
        AddHandler Me.Loaded, AddressOf ViewerPage_Loaded

        _report = New C1FlexReport()
    End Sub

    Private Sub ViewerPage_Unloaded(sender As Object, e As RoutedEventArgs)
        RemoveHandler cbReport.SelectionChanged, AddressOf CbReport_SelectionChanged

        flexViewer.DocumentSource = Nothing
        If _pdfDocSource IsNot Nothing Then
            _pdfDocSource.Dispose()
            _pdfDocSource = Nothing
        End If
        _report.Dispose()
        _report = Nothing
    End Sub

    Private Async Sub ViewerPage_Loaded(sender As Object, e As RoutedEventArgs)
        _asm = GetType(ViewerPage).GetTypeInfo().Assembly
        Await ExportPage.CopyC1NWind()

        Dim reports As String() = Nothing

        ' get list of reports from resource using stream
        Using stream As Stream = _asm.GetManifestResourceStream("FlexReportSamples.FlexCommonTasks_UWP.flxr")
            reports = C1FlexReport.GetReportList(stream)
        End Using

        cbReport.Items.Clear()
        AddHandler cbReport.SelectionChanged, AddressOf CbReport_SelectionChanged

        If reports IsNot Nothing AndAlso reports.Length > 0 Then
            For Each s As String In reports
                cbReport.Items.Add(s)
            Next
        End If

        For Each s As String In _pdfs
            cbReport.Items.Add(s)
        Next

        cbReport.SelectedIndex = 0
    End Sub

    Private Async Sub CbReport_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim itemName As String = TryCast(cbReport.SelectedItem, String)
        If Not String.IsNullOrEmpty(itemName) Then
            flexViewer.DocumentSource = Nothing
            If Not _pdfs.Contains(itemName) Then
                Await LoadReport(itemName)
            Else
                Await LoadPdf(itemName)
            End If
        End If
    End Sub

    Private Async Function LoadReport(reportName As String) As Task
        Dim commonEx As Exception = Nothing

        ' load report
        Try
            Using stream As Stream = _asm.GetManifestResourceStream("FlexReportSamples.FlexCommonTasks_UWP.flxr")
                _report.Load(stream, reportName)
            End Using
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.FailedToLoadFmt, reportName, commonEx.Message), "Error")
            Await md.ShowAsync()
            Return
        End If
        flexViewer.DocumentSource = _report
    End Function

    Private Async Function LoadPdf(pdfName As String) As Task
        If _pdfDocSource Is Nothing Then
            _pdfDocSource = New C1PdfDocumentSource()
        End If
        Dim commonEx As Exception = Nothing

        ' load pdf
        Try
            ' load from resource stream
            Dim memStream = New MemoryStream()
            Using stream As Stream = _asm.GetManifestResourceStream(Convert.ToString("FlexReportSamples.") & pdfName)
                Await stream.CopyToAsync(memStream)
                memStream.Position = 0
            End Using
            Await _pdfDocSource.LoadFromStreamAsync(memStream.AsRandomAccessStream())
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.FailedToLoadFmt, pdfName, commonEx.Message), "Error")
            Await md.ShowAsync()
            Return
        End If
        flexViewer.DocumentSource = _pdfDocSource
    End Function
End Class
