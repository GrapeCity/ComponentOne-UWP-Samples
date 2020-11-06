Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("TileSamplesLib/Resources")

    Public Shared ReadOnly Property Animals_Header() As String
        Get
            Return _loader.GetString("Animals_Header")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Arch_Header() As String
        Get
            Return _loader.GetString("Arch_Header")
        End Get
    End Property

    Public Shared ReadOnly Property BackContent_Text() As String
        Get
            Return _loader.GetString("BackContent_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Cars_Header() As String
        Get
            Return _loader.GetString("Cars_Header")
        End Get
    End Property

    Public Shared ReadOnly Property ContentSourceDescription() As String
        Get
            Return _loader.GetString("ContentSourceDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ContentSourceName() As String
        Get
            Return _loader.GetString("ContentSourceName")
        End Get
    End Property

    Public Shared ReadOnly Property ContentSourceTitle() As String
        Get
            Return _loader.GetString("ContentSourceTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DownloadFlickrErrorMessage() As String
        Get
            Return _loader.GetString("DownloadFlickrErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property Family_Header() As String
        Get
            Return _loader.GetString("Family_Header")
        End Get
    End Property

    Public Shared ReadOnly Property FlickrData_Text() As String
        Get
            Return _loader.GetString("FlickrData_Text")
        End Get
    End Property

    Public Shared ReadOnly Property FlickrDescription() As String
        Get
            Return _loader.GetString("FlickrDescription")
        End Get
    End Property

    Public Shared ReadOnly Property FlickrName() As String
        Get
            Return _loader.GetString("FlickrName")
        End Get
    End Property

    Public Shared ReadOnly Property FlickrTitle() As String
        Get
            Return _loader.GetString("FlickrTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FlipTile6_Content() As String
        Get
            Return _loader.GetString("FlipTile6_Content")
        End Get
    End Property

    Public Shared ReadOnly Property FlipTile6_Header() As String
        Get
            Return _loader.GetString("FlipTile6_Header")
        End Get
    End Property

    Public Shared ReadOnly Property FlipTile7_Content() As String
        Get
            Return _loader.GetString("FlipTile7_Content")
        End Get
    End Property

    Public Shared ReadOnly Property FlipTile7_Header() As String
        Get
            Return _loader.GetString("FlipTile7_Header")
        End Get
    End Property

    Public Shared ReadOnly Property GridViewDescription() As String
        Get
            Return _loader.GetString("GridViewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property GridViewName() As String
        Get
            Return _loader.GetString("GridViewName")
        End Get
    End Property

    Public Shared ReadOnly Property GridViewTitle() As String
        Get
            Return _loader.GetString("GridViewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property InitializationException() As String
        Get
            Return _loader.GetString("InitializationException")
        End Get
    End Property

    Public Shared ReadOnly Property Nature_Header() As String
        Get
            Return _loader.GetString("Nature_Header")
        End Get
    End Property

    Public Shared ReadOnly Property Night_Header() As String
        Get
            Return _loader.GetString("Night_Header")
        End Get
    End Property

    Public Shared ReadOnly Property OverviewDescription() As String
        Get
            Return _loader.GetString("OverviewDescription")
        End Get
    End Property

    Public Shared ReadOnly Property OverviewName() As String
        Get
            Return _loader.GetString("OverviewName")
        End Get
    End Property

    Public Shared ReadOnly Property OverviewTitle() As String
        Get
            Return _loader.GetString("OverviewTitle")
        End Get
    End Property

    Public Shared ReadOnly Property People_Header() As String
        Get
            Return _loader.GetString("People_Header")
        End Get
    End Property

    Public Shared ReadOnly Property Retry_Content() As String
        Get
            Return _loader.GetString("Retry_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SampleDataHeader() As String
        Get
            Return _loader.GetString("SampleDataHeader")
        End Get
    End Property

    Public Shared ReadOnly Property SampleDataTitle() As String
        Get
            Return _loader.GetString("SampleDataTitle")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SessionStateKeyErrorMessage() As String
        Get
            Return _loader.GetString("SessionStateKeyErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile2_Content() As String
        Get
            Return _loader.GetString("SlideTile2_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile2_Header() As String
        Get
            Return _loader.GetString("SlideTile2_Header")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile3_BackContent() As String
        Get
            Return _loader.GetString("SlideTile3_BackContent")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile3_Content() As String
        Get
            Return _loader.GetString("SlideTile3_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile3_Header() As String
        Get
            Return _loader.GetString("SlideTile3_Header")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile4_Content() As String
        Get
            Return _loader.GetString("SlideTile4_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile4_Header() As String
        Get
            Return _loader.GetString("SlideTile4_Header")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile5_Content() As String
        Get
            Return _loader.GetString("SlideTile5_Content")
        End Get
    End Property

    Public Shared ReadOnly Property SlideTile5_Header() As String
        Get
            Return _loader.GetString("SlideTile5_Header")
        End Get
    End Property

    Public Shared ReadOnly Property Summer_Header() As String
        Get
            Return _loader.GetString("Summer_Header")
        End Get
    End Property

    Public Shared ReadOnly Property SuspensionManagerErrorMessage() As String
        Get
            Return _loader.GetString("SuspensionManagerErrorMessage")
        End Get
    End Property

    Public Shared ReadOnly Property Tile1_Content() As String
        Get
            Return _loader.GetString("Tile1_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Tile1_Header() As String
        Get
            Return _loader.GetString("Tile1_Header")
        End Get
    End Property

    Public Shared ReadOnly Property Traffic_Header() As String
        Get
            Return _loader.GetString("Traffic_Header")
        End Get
    End Property

    Public Shared ReadOnly Property Travel_Header() As String
        Get
            Return _loader.GetString("Travel_Header")
        End Get
    End Property

    Public Shared ReadOnly Property UniqueIdItemsArgumentException() As String
        Get
            Return _loader.GetString("UniqueIdItemsArgumentException")
        End Get
    End Property
End Class