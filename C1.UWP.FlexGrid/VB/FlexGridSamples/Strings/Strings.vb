Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("FlexGridSamplesLib/Resources")

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property FinancialName() As String
        Get
            Return _loader.GetString("FinancialName")
        End Get
    End Property

    Public Shared ReadOnly Property FinancialTitle() As String
        Get
            Return _loader.GetString("FinancialTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FinancialDescription() As String
        Get
            Return _loader.GetString("FinancialDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewName() As String
        Get
            Return _loader.GetString("CollectionViewName")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewTitle() As String
        Get
            Return _loader.GetString("CollectionViewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CollectionViewDescription() As String
        Get
            Return _loader.GetString("CollectionViewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MediaLibraryName() As String
        Get
            Return _loader.GetString("MediaLibraryName")
        End Get
    End Property

    Public Shared ReadOnly Property MediaLibraryTitle() As String
        Get
            Return _loader.GetString("MediaLibraryTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MediaLibraryDescription() As String
        Get
            Return _loader.GetString("MediaLibraryDescription")
        End Get
    End Property

    Public Shared ReadOnly Property EditingName() As String
        Get
            Return _loader.GetString("EditingName")
        End Get
    End Property

    Public Shared ReadOnly Property EditingTitle() As String
        Get
            Return _loader.GetString("EditingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property EditingDescription() As String
        Get
            Return _loader.GetString("EditingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property UnboundName() As String
        Get
            Return _loader.GetString("UnboundName")
        End Get
    End Property

    Public Shared ReadOnly Property UnboundTitle() As String
        Get
            Return _loader.GetString("UnboundTitle")
        End Get
    End Property

    Public Shared ReadOnly Property UnboundDescription() As String
        Get
            Return _loader.GetString("UnboundDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CustomColumnsName() As String
        Get
            Return _loader.GetString("CustomColumnsName")
        End Get
    End Property

    Public Shared ReadOnly Property CustomColumnsTitle() As String
        Get
            Return _loader.GetString("CustomColumnsTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CustomColumnsDescription() As String
        Get
            Return _loader.GetString("CustomColumnsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CellMergingName() As String
        Get
            Return _loader.GetString("CellMergingName")
        End Get
    End Property

    Public Shared ReadOnly Property CellMergingTitle() As String
        Get
            Return _loader.GetString("CellMergingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CellMergingDescription() As String
        Get
            Return _loader.GetString("CellMergingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property PrintingName() As String
        Get
            Return _loader.GetString("PrintingName")
        End Get
    End Property

    Public Shared ReadOnly Property PrintingTitle() As String
        Get
            Return _loader.GetString("PrintingTitle")
        End Get
    End Property

    Public Shared ReadOnly Property PrintingDescription() As String
        Get
            Return _loader.GetString("PrintingDescription")
        End Get
    End Property

    Public Shared ReadOnly Property YouTubeName() As String
        Get
            Return _loader.GetString("YouTubeName")
        End Get
    End Property

    Public Shared ReadOnly Property YouTubeTitle() As String
        Get
            Return _loader.GetString("YouTubeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property YouTubeDescription() As String
        Get
            Return _loader.GetString("YouTubeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropName() As String
        Get
            Return _loader.GetString("DragDropName")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropTitle() As String
        Get
            Return _loader.GetString("DragDropTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DragDropDescription() As String
        Get
            Return _loader.GetString("DragDropDescription")
        End Get
    End Property

    Public Shared ReadOnly Property Lines() As String
        Get
            Return _loader.GetString("Lines")
        End Get
    End Property

    Public Shared ReadOnly Property Colors() As String
        Get
            Return _loader.GetString("Colors")
        End Get
    End Property

    Public Shared ReadOnly Property FileNotFoundException() As String
        Get
            Return _loader.GetString("FileNotFoundException")
        End Get
    End Property

    Public Shared ReadOnly Property FirstNames() As String
        Get
            Return _loader.GetString("FirstNames")
        End Get
    End Property

    Public Shared ReadOnly Property LastNames() As String
        Get
            Return _loader.GetString("LastNames")
        End Get
    End Property

    Public Shared ReadOnly Property CountryList() As String
        Get
            Return _loader.GetString("CountryList")
        End Get
    End Property

    Public Shared ReadOnly Property EditingTag() As String
        Get
            Return _loader.GetString("EditingTag")
        End Get
    End Property

    Public Shared ReadOnly Property CompaniesInfo() As String
        Get
            Return _loader.GetString("CompaniesInfo")
        End Get
    End Property

    Public Shared ReadOnly Property SongInfo() As String
        Get
            Return _loader.GetString("SongInfo")
        End Get
    End Property

    Public Shared ReadOnly Property MMSS() As String
        Get
            Return _loader.GetString("MMSS")
        End Get
    End Property

    Public Shared ReadOnly Property HHMMSS() As String
        Get
            Return _loader.GetString("HHMMSS")
        End Get
    End Property

    Public Shared ReadOnly Property Size() As String
        Get
            Return _loader.GetString("Size")
        End Get
    End Property

    Public Shared ReadOnly Property Change() As String
        Get
            Return _loader.GetString("Change")
        End Get
    End Property

    Public Shared ReadOnly Property UnboundTag() As String
        Get
            Return _loader.GetString("UnboundTag")
        End Get
    End Property

    Public Shared ReadOnly Property CellInfo() As String
        Get
            Return _loader.GetString("CellInfo")
        End Get
    End Property

    Public Shared ReadOnly Property LevelInfo() As String
        Get
            Return _loader.GetString("LevelInfo")
        End Get
    End Property

    Public Shared ReadOnly Property QuarterInfo() As String
        Get
            Return _loader.GetString("QuarterInfo")
        End Get
    End Property

    Public Shared ReadOnly Property HdrInfo() As String
        Get
            Return _loader.GetString("HdrInfo")
        End Get
    End Property

    Public Shared ReadOnly Property SamplePDF() As String
        Get
            Return _loader.GetString("SamplePDF")
        End Get
    End Property

    Public Shared ReadOnly Property SamplePrint() As String
        Get
            Return _loader.GetString("SamplePrint")
        End Get
    End Property

    Public Shared ReadOnly Property Zoom() As String
        Get
            Return _loader.GetString("Zoom")
        End Get
    End Property

    Public Shared ReadOnly Property ActualSize() As String
        Get
            Return _loader.GetString("ActualSize")
        End Get
    End Property

    Public Shared ReadOnly Property PageWidth() As String
        Get
            Return _loader.GetString("PageWidth")
        End Get
    End Property

    Public Shared ReadOnly Property SinglePage() As String
        Get
            Return _loader.GetString("SinglePage")
        End Get
    End Property

    Public Shared ReadOnly Property Margin() As String
        Get
            Return _loader.GetString("Margin")
        End Get
    End Property

    Public Shared ReadOnly Property None() As String
        Get
            Return _loader.GetString("None")
        End Get
    End Property

    Public Shared ReadOnly Property HalfInch() As String
        Get
            Return _loader.GetString("HalfInch")
        End Get
    End Property

    Public Shared ReadOnly Property OneInch() As String
        Get
            Return _loader.GetString("OneInch")
        End Get
    End Property

    Public Shared ReadOnly Property PrintException() As String
        Get
            Return _loader.GetString("PrintException")
        End Get
    End Property

    Public Shared ReadOnly Property FiledLine() As String
        Get
            Return _loader.GetString("FiledLine")
        End Get
    End Property

    Public Shared ReadOnly Property FiledColor() As String
        Get
            Return _loader.GetString("FiledColor")
        End Get
    End Property

    Public Shared ReadOnly Property FiledPrice() As String
        Get
            Return _loader.GetString("FiledPrice")
        End Get
    End Property

    Public Shared ReadOnly Property FiledWeight() As String
        Get
            Return _loader.GetString("FiledWeight")
        End Get
    End Property

    Public Shared ReadOnly Property FiledCost() As String
        Get
            Return _loader.GetString("FiledCost")
        End Get
    End Property

    Public Shared ReadOnly Property FiledVolume() As String
        Get
            Return _loader.GetString("FiledVolume")
        End Get
    End Property

    Public Shared ReadOnly Property FiledDiscontinued() As String
        Get
            Return _loader.GetString("FiledDiscontinued")
        End Get
    End Property

    Public Shared ReadOnly Property FiledRating() As String
        Get
            Return _loader.GetString("FiledRating")
        End Get
    End Property

    Public Shared ReadOnly Property ItemsCount() As String
        Get
            Return _loader.GetString("ItemsCount")
        End Get
    End Property

    Public Shared ReadOnly Property ItemCount() As String
        Get
            Return _loader.GetString("ItemCount")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property BatchSize_Text() As String
        Get
            Return _loader.GetString("BatchSize_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Companies_Text() As String
        Get
            Return _loader.GetString("Companies_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FilterOn_Text() As String
        Get
            Return _loader.GetString("FilterOn_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FinancialInfo_Text() As String
        Get
            Return _loader.GetString("FinancialInfo_Text")
        End Get
    End Property

    Public Shared ReadOnly Property GroupOn_Text() As String
        Get
            Return _loader.GetString("GroupOn_Text")
        End Get
    End Property

    Public Shared ReadOnly Property HeadersVisibility_Text() As String
        Get
            Return _loader.GetString("HeadersVisibility_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Media_Text() As String
        Get
            Return _loader.GetString("Media_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RetrievingData_Text() As String
        Get
            Return _loader.GetString("RetrievingData_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Search_Text() As String
        Get
            Return _loader.GetString("Search_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Songs_Text() As String
        Get
            Return _loader.GetString("Songs_Text")
        End Get
    End Property

    Public Shared ReadOnly Property UpdateInterval_Text() As String
        Get
            Return _loader.GetString("UpdateInterval_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ZeroPercent_Text() As String
        Get
            Return _loader.GetString("ZeroPercent_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ZeroValue_Text() As String
        Get
            Return _loader.GetString("ZeroValue_Text")
        End Get
    End Property

    Public Shared ReadOnly Property AutoUpdate_Content() As String
        Get
            Return _loader.GetString("AutoUpdate_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Color_Content() As String
        Get
            Return _loader.GetString("Color_Content")
        End Get
    End Property

    Public Shared ReadOnly Property CustomCells_Content() As String
        Get
            Return _loader.GetString("CustomCells_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Interval1_Content() As String
        Get
            Return _loader.GetString("Interval1_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Interval2_Content() As String
        Get
            Return _loader.GetString("Interval2_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Interval3_Content() As String
        Get
            Return _loader.GetString("Interval3_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Line_Content() As String
        Get
            Return _loader.GetString("Line_Content")
        End Get
    End Property

    Public Shared ReadOnly Property MergeCells_Content() As String
        Get
            Return _loader.GetString("MergeCells_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Printing_Content() As String
        Get
            Return _loader.GetString("Printing_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Rating_Content() As String
        Get
            Return _loader.GetString("Rating_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Retry_Content() As String
        Get
            Return _loader.GetString("Retry_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SplitCells_Content() As String
        Get
            Return _loader.GetString("SplitCells_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Watch_Content() As String
        Get
            Return _loader.GetString("Watch_Content")
        End Get
    End Property

    Public Shared ReadOnly Property ProductName() As String
        Get
            Return _loader.GetString("ProductName")
        End Get
    End Property

    Public Shared ReadOnly Property NorthwindData() As String
        Get
            Return _loader.GetString("NorthwindData")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderCustomerID() As String
        Get
            Return _loader.GetString("ColumnHeaderCustomerID")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderCompanyName() As String
        Get
            Return _loader.GetString("ColumnHeaderCompanyName")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderContactName() As String
        Get
            Return _loader.GetString("ColumnHeaderContactName")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderContactTitle() As String
        Get
            Return _loader.GetString("ColumnHeaderContactTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderAddress() As String
        Get
            Return _loader.GetString("ColumnHeaderAddress")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderCity() As String
        Get
            Return _loader.GetString("ColumnHeaderCity")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderPostalCode() As String
        Get
            Return _loader.GetString("ColumnHeaderPostalCode")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderCountry() As String
        Get
            Return _loader.GetString("ColumnHeaderCountry")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderPhone() As String
        Get
            Return _loader.GetString("ColumnHeaderPhone")
        End Get
    End Property

    Public Shared ReadOnly Property ColumnHeaderFax() As String
        Get
            Return _loader.GetString("ColumnHeaderFax")
        End Get
    End Property

    Public Shared ReadOnly Property Level() As String
        Get
            Return _loader.GetString("Level")
        End Get
    End Property

    Public Shared ReadOnly Property ID() As String
        Get
            Return _loader.GetString("ID")
        End Get
    End Property

    Public Shared ReadOnly Property MergeCells_Text() As String
        Get
            Return _loader.GetString("MergeCells_Text")
        End Get
    End Property

    Public Shared ReadOnly Property RowDetailsDescription() As String
        Get
            Return _loader.GetString("RowDetailsDescription")
        End Get
    End Property

    Public Shared ReadOnly Property RowDetailsName() As String
        Get
            Return _loader.GetString("RowDetailsName")
        End Get
    End Property

    Public Shared ReadOnly Property RowDetailsTitle() As String
        Get
            Return _loader.GetString("RowDetailsTitle")
        End Get
    End Property
End Class