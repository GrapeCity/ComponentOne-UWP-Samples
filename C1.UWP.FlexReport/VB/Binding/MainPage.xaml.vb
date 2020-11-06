Imports System.Reflection
Imports Windows.UI.Popups
Imports Simple.OData.Client

Imports C1.Xaml.FlexReport

Partial Public NotInheritable Class MainPage
    Inherits Page

    Private Shared ReadOnly ODataUri As New Uri("http://services.odata.org/V3/OData/OData.svc/")
    Private _report As C1FlexReport

    Public Sub New()
        Me.InitializeComponent()

        _report = New C1FlexReport()
        AddHandler _report.BusyStateChanged, AddressOf _report_BusyStateChanged
    End Sub

    Private Async Sub _report_BusyStateChanged(sender As Object, e As EventArgs)
        Await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
            Sub()
                cbReport.IsEnabled = Not DirectCast(sender, C1FlexReport).IsBusy
            End Sub
            )
    End Sub

    Private Async Function ShowReport(reportName As String) As Task
        Dim commonEx As Exception = Nothing
        Try
            ' build report
            prMain.IsActive = True
            Select Case reportName
                Case "Categories"
                    Await BuildCategoriesReport()
                    Exit Select
                Case "Products"
                    Await BuildProductsReport()
                    Exit Select
            End Select
            prMain.IsActive = False

            ' assign report to the preview pane
            flexViewerPane.DocumentSource = Nothing
            flexViewerPane.DocumentSource = _report
        Catch ex As Exception
            commonEx = ex
        End Try
        If commonEx IsNot Nothing Then
            Dim md As New MessageDialog(String.Format("Failed to show ""{0}"" report, error:" & vbCr & vbLf & "{1}", reportName, commonEx.Message))
            Await md.ShowAsync()
        End If
    End Function

    Private Async Function BuildCategoriesReport() As Task
        ' request data from OData service
        Dim client = New ODataClient(ODataUri)
        ' select all categories

        Dim categories = (Await (client.For(Of Category)()).FindEntriesAsync()).ToList()

        ' load report definition from resources
        Dim asm As Assembly = GetType(MainPage).GetTypeInfo().Assembly
        Using stream As Stream = asm.GetManifestResourceStream("Binding.Reports.flxr")
            _report.Load(stream, "Categories")
        End Using

        ' assign dataset to the report
        _report.DataSource.Recordset = categories
    End Function

    Private Async Function BuildProductsReport() As Task
        ' request data from OData service
        Dim client = New ODataClient(ODataUri)
        ' select all categries and products of each category

        Dim ff = client.For(Of Category)()
        Dim fe = ff.Expand(Function(x) New With {x.Products})
        Dim categories = (Await fe.FindEntriesAsync()).ToList()

        Dim products = (From c In categories From p In c.Products Select New With {
            .CategoryID = c.ID,
            .CategoryName = c.Name,
            .ID = p.ID,
            .Name = p.Name,
            .Description = p.Description,
            .ReleaseDate = p.ReleaseDate,
            .DiscontinuedDate = p.DiscontinuedDate,
            .Rating = p.Rating,
            .Price = p.Price
        }).ToList()

        ' load report definition from resources
        Dim asm As Assembly = GetType(MainPage).GetTypeInfo().Assembly
        Using stream As Stream = asm.GetManifestResourceStream("Binding.Reports.flxr")
            _report.Load(stream, "Products")
        End Using

        ' assign dataset to the report
        _report.DataSource.Recordset = products
    End Function

    Private Async Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        Await ShowReport(TryCast(DirectCast(cbReport.SelectedItem, ComboBoxItem).Content, String))

        AddHandler cbReport.SelectionChanged, AddressOf cbReport_SelectionChanged
    End Sub

    Private Async Sub cbReport_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        Await ShowReport(TryCast(DirectCast(cbReport.SelectedItem, ComboBoxItem).Content, String))
    End Sub

    Public Class Category

        Private m_ID As Integer
        Private m_Name As String
        Private m_Products As List(Of Product)

        Public Property ID() As Integer
            Get
                Return m_ID
            End Get
            Set
                m_ID = Value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set
                m_Name = Value
            End Set
        End Property
        Public Property Products() As List(Of Product)
            Get
                Return m_Products
            End Get
            Set
                m_Products = Value
            End Set
        End Property
    End Class

    Public Class Product

        Private m_ID As Integer
        Private m_Name As String
        Private m_Description As String
        Private m_ReleaseDate As DateTime
        Private m_DiscontinuedDate As DateTime
        Private m_Rating As Integer
        Private m_Price As Double

        Public Property ID() As Integer
            Get
                Return m_ID
            End Get
            Set
                m_ID = Value
            End Set
        End Property
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set
                m_Name = Value
            End Set
        End Property
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set
                m_Description = Value
            End Set
        End Property
        Public Property ReleaseDate() As DateTime
            Get
                Return m_ReleaseDate
            End Get
            Set
                m_ReleaseDate = Value
            End Set
        End Property
        Public Property DiscontinuedDate() As DateTime
            Get
                Return m_DiscontinuedDate
            End Get
            Set
                m_DiscontinuedDate = Value
            End Set
        End Property
        Public Property Rating() As Integer
            Get
                Return m_Rating
            End Get
            Set
                m_Rating = Value
            End Set
        End Property
        Public Property Price() As Double
            Get
                Return m_Price
            End Get
            Set
                m_Price = Value
            End Set
        End Property
    End Class
End Class
