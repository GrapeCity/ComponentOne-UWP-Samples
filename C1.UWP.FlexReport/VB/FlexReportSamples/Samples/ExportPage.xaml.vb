Imports System.Text
Imports System.Reflection

Imports Windows.System
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.UI.Popups

Imports C1.Xaml.Document.Export
Imports C1.Xaml.FlexReport

Partial Public NotInheritable Class ExportPage
    Inherits Page
    Private Const c_Builtin As String = "Built-in FlexReportCommonTasks_UWP.flxr"
    Private Const c_Browse As String = "Browse..."

    Private _report As C1FlexReport
    Private _previousItem As ReportItem

    Public Sub New()
        Me.InitializeComponent()

        _report = New C1FlexReport()

        _previousItem = DirectCast(tbReportFile.Items(0), ReportItem)
        tbReportFile.Items.Add(New ReportItem() With {
            .Caption = c_Builtin
        })
        tbReportFile.Items.Add(New ReportItem() With {
            .Caption = c_Browse
        })
        tbReportFile.SelectedIndex = 0

        ' build list of supported export filters
        For Each e In _report.SupportedExportProviders
            cbExportFilter.Items.Add(e.FormatName)
        Next
        cbExportFilter.SelectedIndex = 0
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

        '' avoid duplicate entries:
        For Each tri As ReportItem In tbReportFile.Items
            If tri.SameAs(ri) Then
                tbReportFile.SelectedItem = tri
                UpdateReportsList()
                Return True
            End If
        Next
        tbReportFile.Items.Add(ri)  '' NOTE: as of Aug 2016, tbReportFile.Items.Insert(0, ri) crashes with error 0xC000027B
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
            btnExport.IsEnabled = Not _report.IsBusy
        Else
            btnExport.IsEnabled = False
        End If
    End Sub

    Private Async Function DoExport(pickDestination As Boolean) As Task
        If _report.IsBusy Then
            Return
        End If

        Dim selectedReport As String = TryCast(cbReport.SelectedItem, String)
        If String.IsNullOrEmpty(selectedReport) Then
            Return
        End If
        If cbExportFilter.SelectedIndex < 0 OrElse cbExportFilter.SelectedIndex >= _report.SupportedExportProviders.Length Then
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
                Await _report.LoadAsync(ri.File, selectedReport)
            End If
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.FailedToLoadFmt, selectedReport, commonEx.Message), "Error")
            Await md.ShowAsync()
            Return
        End If

        ' prepare ExportFilter object
        Dim ep As ExportProvider = _report.SupportedExportProviders(cbExportFilter.SelectedIndex)
        Dim ef As ExportFilter = TryCast(ep.NewExporter(), ExportFilter)
        ef.UseZipForMultipleFiles = cbUseZipForMultipleFiles.IsChecked.Value

        '
        If (TypeOf ef Is BmpFilter OrElse TypeOf ef Is JpegFilter OrElse TypeOf ef Is PngFilter OrElse TypeOf ef Is GifFilter) Then
            ' these export filters produce more than one file during export
            ' ask for directory in this case
            Dim defFileName As String = (selectedReport & Convert.ToString(".")) + ep.DefaultExtension + ".zip"
            If cbUseZipForMultipleFiles.IsChecked = True Then
                If pickDestination Then
                    ' ask for zip file
                    Dim fsp As New FileSavePicker()
                    fsp.DefaultFileExtension = ".zip"
                    fsp.FileTypeChoices.Add(Strings.ZipFiles, New String() {".zip"})
                    fsp.SuggestedFileName = defFileName
                    ef.StorageFile = Await fsp.PickSaveFileAsync()
                    If ef.StorageFile Is Nothing Then
                        Return
                    End If
                Else
                    ' use file in temp folder
                    ef.StorageFile = Await ApplicationData.Current.TemporaryFolder.CreateFileAsync(defFileName, CreationCollisionOption.ReplaceExisting)
                End If
            Else
                If pickDestination Then
                    Dim fp As New FolderPicker()
                    fp.FileTypeFilter.Add("." + ep.DefaultExtension)
                    fp.FileTypeFilter.Add(".zip")
                    ef.StorageFolder = Await fp.PickSingleFolderAsync()
                    If ef.StorageFolder Is Nothing Then
                        ' user cancels an export
                        Return
                    End If
                Else
                    ef.StorageFolder = Await ApplicationData.Current.TemporaryFolder.CreateFolderAsync(selectedReport, CreationCollisionOption.OpenIfExists)
                End If
            End If
        Else
            Dim defFileName As String = (selectedReport & Convert.ToString(".")) + ep.DefaultExtension
            If pickDestination Then
                ' ask for file
                Dim fsp As New FileSavePicker()
                fsp.DefaultFileExtension = "." + ep.DefaultExtension
                fsp.FileTypeChoices.Add(ep.FormatName + " (." + ep.DefaultExtension + ")", New String() {"." + ep.DefaultExtension})
                fsp.FileTypeChoices.Add(Strings.ZipFiles, New String() {".zip"})
                fsp.SuggestedFileName = defFileName
                ef.StorageFile = Await fsp.PickSaveFileAsync()
                If ef.StorageFile Is Nothing Then
                    Return
                End If
            Else
                ' use file in temp folder
                ef.StorageFile = Await ApplicationData.Current.TemporaryFolder.CreateFileAsync(defFileName, CreationCollisionOption.ReplaceExisting)
            End If
        End If

        Try
            Await _report.RenderToFilterAsync(ef)
            '_report.RenderToFilter(ef);
            Await ShowPreview(ef)
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.FailedToExportFmt, selectedReport, commonEx.Message), "Error")
            Await md.ShowAsync()
        End If
    End Function

    Private Async Sub btnExport_Click(sender As Object, e As RoutedEventArgs)
        btnExportTo.IsEnabled = False
        btnExport.IsEnabled = False
        Try
            Await DoExport(False)
        Finally
            btnExportTo.IsEnabled = cbReport.SelectedItem IsNot Nothing
            btnExport.IsEnabled = cbReport.SelectedItem IsNot Nothing
        End Try
    End Sub

    Private Async Sub btnExportTo_Click(sender As Object, e As RoutedEventArgs)
        btnExportTo.IsEnabled = False
        btnExport.IsEnabled = False
        Try
            Await DoExport(True)
        Finally
            btnExportTo.IsEnabled = cbReport.SelectedItem IsNot Nothing
            btnExport.IsEnabled = cbReport.SelectedItem IsNot Nothing
        End Try
    End Sub

    Private Function GetExportResultDesc(ef As ExportFilter) As String
        If ef.StorageFolder IsNot Nothing Then
            Dim files As New StringBuilder()
            For Each file In ef.OutputFiles
                files.AppendLine(Path.GetFileName(file))
            Next
            Return String.Format(Strings.ExportToFolderFmt, ef.StorageFolder.Path, ef.OutputFiles.Count, files.ToString())
        Else
            Return String.Format(Strings.ExportToFileFmt, ef.PreviewFile.Path) + vbCr & vbLf
        End If
    End Function

    Private Async Function ShowPreview(ef As ExportFilter) As Task
        If Not cbOpenDocument.IsChecked.Value Then
            Dim md As New MessageDialog(GetExportResultDesc(ef), Strings.ExportComplete)
            Await md.ShowAsync()
            Return
        End If
        Dim commonEx As Exception = Nothing
        Try
            If ef.StorageFolder Is Nothing Then
                If Not Await Launcher.LaunchFileAsync(ef.PreviewFile) Then
                    Throw New Exception("Launcher.LaunchFileAsync() returns false.")
                End If
            Else
                If Not Await Launcher.LaunchFolderAsync(ef.StorageFolder) Then
                    Throw New Exception("Launcher.LaunchFolderAsync() returns false.")
                End If
            End If
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(GetExportResultDesc(ef) & String.Format(Strings.PreviewErrorFmt, commonEx.Message), Strings.ExportComplete)
            Await md.ShowAsync()
        End If
    End Function

    Public Shared Async Function CopyC1NWind() As Task
        Dim asm As Assembly = GetType(ExportPage).GetTypeInfo().Assembly
        Dim f As StorageFile = Await ApplicationData.Current.LocalFolder.TryGetItemAsync("C1NWind.db")
        Using stream As Stream = asm.GetManifestResourceStream("FlexReportSamples.C1NWind.db")
            If f Is Nothing OrElse (Await f.GetBasicPropertiesAsync()).Size <> stream.Length Then
                If f Is Nothing Then
                    f = Await ApplicationData.Current.LocalFolder.CreateFileAsync("C1NWind.db", CreationCollisionOption.ReplaceExisting)
                End If
                Using dst As Stream = Await f.OpenStreamForWriteAsync()
                    Await stream.CopyToAsync(dst)
                    Await dst.FlushAsync()
                End Using
            End If
        End Using
    End Function

    Private Async Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        Await CopyC1NWind()

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

        Public Function SameAs(ByRef other As ReportItem) As Boolean
            If Me.Caption <> other.Caption Then
                Return False
            End If
            If Me.File Is Nothing Then
                Return other.File Is Nothing
            End If
            Return Me.File.Path = other.File.Path
        End Function
    End Class
End Class
