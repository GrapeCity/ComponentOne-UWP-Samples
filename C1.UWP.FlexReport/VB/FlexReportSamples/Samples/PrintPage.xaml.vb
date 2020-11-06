Imports System.Reflection

Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.UI.Popups

Imports C1.Xaml.FlexReport

Partial Public NotInheritable Class PrintPage
    Inherits Page
    Private Const c_Builtin As String = "Built-in FlexReportCommonTasks_UWP.flxr"
    Private Const c_Browse As String = "Browse..."

    Private _report As C1FlexReport
    Private _previousItem As ReportItem

    Public Sub New()
        Me.InitializeComponent()

        _report = New C1FlexReport()

        '
        _previousItem = DirectCast(tbReportFile.Items(0), ReportItem)
        tbReportFile.Items.Add(New ReportItem() With {
            .Caption = c_Builtin
        })
        tbReportFile.Items.Add(New ReportItem() With {
            .Caption = c_Browse
        })
        tbReportFile.SelectedIndex = 0
    End Sub

    Public Property FilePickerVisible() As Boolean
        Get
            Return gReportFile.Visibility = Visibility.Visible
        End Get
        Set
            gReportFile.Visibility = If(Value, Visibility.Visible, Visibility.Collapsed)
            lblReportFile.Visibility = If(Value, Visibility.Visible, Visibility.Collapsed)
        End Set
    End Property

    Private Async Function SelectFile() As Task(Of Boolean)
        Dim fsp As New FileOpenPicker()
        fsp.FileTypeFilter.Add(".flxr")
        Dim file = Await fsp.PickSingleFileAsync()
        If file Is Nothing Then
            Return False
        End If

        Dim ri As New ReportItem() With {
            .Caption = file.DisplayName,
            .File = file
        }
        tbReportFile.Items.Insert(tbReportFile.Items.Count - 1, ri)
        tbReportFile.SelectedItem = ri
        UpdateReportsList()
        Return True
    End Function

    Private Async Sub UpdateReportsList()
        Dim reports As String() = Nothing
        Dim ri As ReportItem = TryCast(tbReportFile.SelectedItem, ReportItem)
        If ri.File Is Nothing AndAlso ri.Caption = c_Builtin Then
            ' get list of reports from resource using stream
            Dim asm As Assembly = GetType(ExportPage).GetTypeInfo().Assembly
            Using stream As Stream = asm.GetManifestResourceStream("FlexReportSamples.FlexCommonTasks_UWP.flxr")
                reports = C1FlexReport.GetReportList(stream)
            End Using
        Else
            ' get list of reports from a file
            If ri.File IsNot Nothing Then
                Try
                    reports = Await C1FlexReport.GetReportListAsync(ri.File)
                Catch
                End Try
            End If
        End If

        ' 
        cbReport.Items.Clear()
        If reports IsNot Nothing AndAlso reports.Length > 0 Then
            For Each s As String In reports
                cbReport.Items.Add(s)
            Next
            cbReport.SelectedIndex = 0
            btnPrint.IsEnabled = Not _report.IsBusy
        Else
            btnPrint.IsEnabled = False
        End If
    End Sub

    Private Async Function DoPrint() As Task
        If _report.IsBusy Then
            Return
        End If

        Dim selectedReport As String = TryCast(cbReport.SelectedItem, String)
        If String.IsNullOrEmpty(selectedReport) Then
            Return
        End If
        Dim ri As ReportItem = TryCast(tbReportFile.SelectedItem, ReportItem)
        If ri Is Nothing OrElse (ri.File Is Nothing AndAlso ri.Caption = c_Browse) Then
            Return
        End If
        Dim commonEx As Exception = Nothing

        ' load report
        Try
            If ri.File Is Nothing AndAlso ri.Caption = c_Builtin Then
                ' load from resource stream
                Dim asm As Assembly = GetType(ExportPage).GetTypeInfo().Assembly
                Using stream As Stream = asm.GetManifestResourceStream("FlexReportSamples.FlexCommonTasks_UWP.flxr")
                    _report.Load(stream, selectedReport)
                End Using
            Else
                ' load from selected file
                Await _report.LoadAsync(ri.File, selectedReport)
            End If

            ' render a report
            Await _report.RenderAsync()

            ' show print UI
            Await _report.ShowPrintUIAsync()
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.FailedToPrintFmt, selectedReport, commonEx.Message), "Error")
            Await md.ShowAsync()
        End If
    End Function

    Private Async Sub btnPrint_Click(sender As Object, e As RoutedEventArgs)
        btnPrint.IsEnabled = False
        Try
            Await DoPrint()
        Finally
            btnPrint.IsEnabled = cbReport.SelectedItem IsNot Nothing
        End Try
    End Sub

    Private Async Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        '
        Await ExportPage.CopyC1NWind()

        '
        UpdateReportsList()
    End Sub

    Private Async Sub btnReportFile_Click(sender As Object, e As RoutedEventArgs)
        Await SelectFile()
    End Sub

    Private Async Sub tbReportFile_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Dim ri As ReportItem = TryCast(tbReportFile.SelectedItem, ReportItem)
        If ri Is Nothing Then
            Return
        End If

        If ri.File Is Nothing AndAlso ri.Caption = c_Browse Then
            If Not Await SelectFile() Then
                tbReportFile.SelectedItem = _previousItem
            End If
        Else
            UpdateReportsList()
        End If
        _previousItem = DirectCast(tbReportFile.SelectedItem, ReportItem)
    End Sub

    Private Class ReportItem
        Private m_Caption As String
        Private m_File As StorageFile

        Public Property Caption() As String
            Get
                Return m_Caption
            End Get
            Set
                m_Caption = Value
            End Set
        End Property

        Public Property File() As StorageFile
            Get
                Return m_File
            End Get
            Set
                m_File = Value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Caption
        End Function
    End Class
End Class
