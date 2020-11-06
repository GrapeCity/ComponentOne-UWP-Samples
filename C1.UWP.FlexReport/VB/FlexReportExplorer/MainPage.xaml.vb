Imports C1.Xaml.FlexReport
Imports C1.Xaml.FlexViewer

Imports Windows.Storage
Imports Windows.UI.Popups
Imports System.Reflection

Partial Public NotInheritable Class MainPage
    Inherits Page

    Private _report As C1FlexReport
    Private _categories As List(Of Category)
    Private _defCategoryName As String
    Private _defReportName As String

    Public Sub New()
        Me.InitializeComponent()

        _report = New C1FlexReport()
        AddHandler flexViewer.PrepareToolMenu, AddressOf FlexViewer_PrepareToolMenu
        AddHandler flexViewer.NavigateToCustomTool, AddressOf FlexViewer_NavigateToCustomTool
        AddHandler Me.Loaded, AddressOf MainPage_Loaded
    End Sub

    Public ReadOnly Property Categories() As List(Of Category)
        Get
            Return _categories
        End Get
    End Property

    Friend ReadOnly Property DefaultCategoryName() As String
        Get
            Return _defCategoryName
        End Get
    End Property

    Friend ReadOnly Property DefaultReportName() As String
        Get
            Return _defReportName
        End Get
    End Property

    Friend Sub App_Suspending()
        flexViewer.Pane.HandleSuspending()
    End Sub

    Friend Function HandleBackRequest() As Boolean
        If flexViewer.ActiveTool <> FlexViewerTool.CustomTool1 Then
            flexViewer.ShowToolPanel(FlexViewerTool.CustomTool1)
            Return True
        End If
        Return False
    End Function

    Public Async Function LoadReport(categoryName As String, reportFileName As String, reportName As String) As Task
        Dim commonEx As Exception = Nothing

        ' load report
        Try
            Using fs As Stream = File.OpenRead("Assets/Reports/" + categoryName.Trim() + "/" + reportFileName.Trim())
                _report.Load(fs, reportName)
            End Using
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.ErrorFormat, reportName, commonEx.Message), Strings.ErrorTitle)
            Await md.ShowAsync()
            Return
        End If

        ' 
        flexViewer.DocumentSource = Nothing

        ' render report
        progressRing.IsActive = True
        Try
            Await _report.RenderAsync()
        Catch ex As Exception
            commonEx = ex
        Finally
            progressRing.IsActive = False
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format(Strings.ErrorFormat, reportName, commonEx.Message), Strings.ErrorTitle)
            Await md.ShowAsync()
            Return
        End If

        ' assign rendered report to the viewer
        flexViewer.DocumentSource = _report
    End Function

    Friend Sub ClearDefaults()
        _defCategoryName = Nothing
        _defReportName = Nothing
    End Sub

    Private Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
        ' load the report catalog
        Dim xdoc As New XDocument()
        Using fs As Stream = File.OpenRead("Assets/ReportsCatalog.xml")
            xdoc = XDocument.Load(fs)
        End Using

        ' prepare the list of reports for the TreeView
        Dim xelems As IEnumerable(Of XElement) = xdoc.Descendants("Category")
        _categories = New List(Of Category)()
        For Each xelem As XElement In xelems
            Dim category As New Category()
            category.Name = xelem.Attribute("Name").Value
            category.Text = xelem.Attribute("Text").Value
            category.ImageUri = "Assets/Reports/MenuIcons/" + xelem.Attribute("Image").Value + ".png"
            Dim reports As New List(Of Report)()
            For Each childReports As XElement In xelem.Descendants("Report")
                Dim rpt As New Report()
                rpt.CategoryName = category.Name
                rpt.ReportName = childReports.Descendants("ReportName").First().Value
                rpt.FileName = childReports.Descendants("FileName").First().Value
                rpt.ReportTitle = childReports.Descendants("ReportTitle").First().Value
                rpt.ImageUri = "Assets/Reports/" + category.Name.Trim() + "/Images/" + childReports.Descendants("ImageName").First().Value.Trim()
                reports.Add(rpt)
            Next
            category.Reports = reports
            _categories.Add(category)
        Next

        ' copy SQLite database from resources to the local folder
        Dim asm As Assembly = GetType(MainPage).GetTypeInfo().Assembly
        Using stream As Stream = asm.GetManifestResourceStream("FlexReportExplorer.C1NWind.db")
            Dim sf As StorageFile = Await ApplicationData.Current.LocalFolder.CreateFileAsync("C1NWind.db", CreationCollisionOption.ReplaceExisting)
            Using dst As Stream = Await sf.OpenStreamForWriteAsync()
                Await stream.CopyToAsync(dst)
                Await dst.FlushAsync()
            End Using
        End Using

        ' open the default report
        Dim xelemDef As XElement = xdoc.Descendants("SelectedReport").First()
        If xelemDef IsNot Nothing Then
            _defCategoryName = xelemDef.Descendants("CategoryName").FirstOrDefault().Value
            _defReportName = xelemDef.Descendants("ReportName").FirstOrDefault().Value
            Dim defFileName As String = xelemDef.Descendants("FileName").FirstOrDefault().Value
            Await LoadReport(_defCategoryName, defFileName, _defReportName)
        End If

        flexViewer.ShowToolPanel(FlexViewerTool.CustomTool1)
    End Sub

    Private Sub FlexViewer_PrepareToolMenu(sender As Object, e As EventArgs)
        Dim tmi = New ToolMenuItem(ChrW(&HE773), FlexViewerTool.CustomTool1, Strings.CatalogToolLabel)
        flexViewer.ToolMenuItems.Insert(0, tmi)
    End Sub

    Private Sub FlexViewer_NavigateToCustomTool(sender As Object, e As CustomToolEventArgs)
        If e.Tool = FlexViewerTool.CustomTool1 Then
            e.ToolFrame.Navigate(GetType(CatalogView), Nothing)
            e.NavigatedTo = True
        End If
    End Sub
End Class
