Imports Windows.ApplicationModel.Resources
Imports System.Threading.Tasks
Imports System.Text
Imports System.Linq
Imports System.Collections.Generic
Imports System

Public Class Strings
    Private Shared _loader As ResourceLoader = ResourceLoader.GetForCurrentView("MapsSamplesLib/Resources")

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

    Public Shared ReadOnly Property DemoName() As String
        Get
            Return _loader.GetString("DemoName")
        End Get
    End Property

    Public Shared ReadOnly Property DemoTitle() As String
        Get
            Return _loader.GetString("DemoTitle")
        End Get
    End Property

    Public Shared ReadOnly Property DemoDescription() As String
        Get
            Return _loader.GetString("DemoDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CustomName() As String
        Get
            Return _loader.GetString("CustomName")
        End Get
    End Property

    Public Shared ReadOnly Property CustomTitle() As String
        Get
            Return _loader.GetString("CustomTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CustomDescription() As String
        Get
            Return _loader.GetString("CustomDescription")
        End Get
    End Property

    Public Shared ReadOnly Property CitiesName() As String
        Get
            Return _loader.GetString("CitiesName")
        End Get
    End Property

    Public Shared ReadOnly Property CitiesTitle() As String
        Get
            Return _loader.GetString("CitiesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property CitiesDescription() As String
        Get
            Return _loader.GetString("CitiesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property EarthQuakeName() As String
        Get
            Return _loader.GetString("EarthQuakeName")
        End Get
    End Property

    Public Shared ReadOnly Property EarthQuakeTitle() As String
        Get
            Return _loader.GetString("EarthQuakeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property EarthQuakeDescription() As String
        Get
            Return _loader.GetString("EarthQuakeDescription")
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

    Public Shared ReadOnly Property FlickrDescription() As String
        Get
            Return _loader.GetString("FlickrDescription")
        End Get
    End Property

    Public Shared ReadOnly Property GridName() As String
        Get
            Return _loader.GetString("GridName")
        End Get
    End Property

    Public Shared ReadOnly Property GridTitle() As String
        Get
            Return _loader.GetString("GridTitle")
        End Get
    End Property

    Public Shared ReadOnly Property GridDescription() As String
        Get
            Return _loader.GetString("GridDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ChartName() As String
        Get
            Return _loader.GetString("ChartName")
        End Get
    End Property

    Public Shared ReadOnly Property ChartTitle() As String
        Get
            Return _loader.GetString("ChartTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ChartDescription() As String
        Get
            Return _loader.GetString("ChartDescription")
        End Get
    End Property

    Public Shared ReadOnly Property MarksName() As String
        Get
            Return _loader.GetString("MarksName")
        End Get
    End Property

    Public Shared ReadOnly Property MarksTitle() As String
        Get
            Return _loader.GetString("MarksTitle")
        End Get
    End Property

    Public Shared ReadOnly Property MarksDescription() As String
        Get
            Return _loader.GetString("MarksDescription")
        End Get
    End Property

    Public Shared ReadOnly Property FactoriesName() As String
        Get
            Return _loader.GetString("FactoriesName")
        End Get
    End Property

    Public Shared ReadOnly Property FactoriesTitle() As String
        Get
            Return _loader.GetString("FactoriesTitle")
        End Get
    End Property

    Public Shared ReadOnly Property FactoriesDescription() As String
        Get
            Return _loader.GetString("FactoriesDescription")
        End Get
    End Property

    Public Shared ReadOnly Property ShapeName() As String
        Get
            Return _loader.GetString("ShapeName")
        End Get
    End Property

    Public Shared ReadOnly Property ShapeTitle() As String
        Get
            Return _loader.GetString("ShapeTitle")
        End Get
    End Property

    Public Shared ReadOnly Property ShapeDescription() As String
        Get
            Return _loader.GetString("ShapeDescription")
        End Get
    End Property

    Public Shared ReadOnly Property Load() As String
        Get
            Return _loader.GetString("Load")
        End Get
    End Property

    Public Shared ReadOnly Property Loading() As String
        Get
            Return _loader.GetString("Loading")
        End Get
    End Property

    Public Shared ReadOnly Property Loading1() As String
        Get
            Return _loader.GetString("Loading1")
        End Get
    End Property

    Public Shared ReadOnly Property CannotLoadMessage() As String
        Get
            Return _loader.GetString("CannotLoadMessage")
        End Get
    End Property

    Public Shared ReadOnly Property Degree() As String
        Get
            Return _loader.GetString("Degree")
        End Get
    End Property

    Public Shared ReadOnly Property West() As String
        Get
            Return _loader.GetString("West")
        End Get
    End Property

    Public Shared ReadOnly Property East() As String
        Get
            Return _loader.GetString("East")
        End Get
    End Property

    Public Shared ReadOnly Property North() As String
        Get
            Return _loader.GetString("North")
        End Get
    End Property

    Public Shared ReadOnly Property South() As String
        Get
            Return _loader.GetString("South")
        End Get
    End Property

    Public Shared ReadOnly Property USA() As String
        Get
            Return _loader.GetString("USA")
        End Get
    End Property

    Public Shared ReadOnly Property Japan() As String
        Get
            Return _loader.GetString("Japan")
        End Get
    End Property

    Public Shared ReadOnly Property Space() As String
        Get
            Return _loader.GetString("Space")
        End Get
    End Property

    Public Shared ReadOnly Property FRMeasurementLargeUnit() As String
        Get
            Return _loader.GetString("FRMeasurementLargeUnit")
        End Get
    End Property

    Public Shared ReadOnly Property FRMeasurementUnit() As String
        Get
            Return _loader.GetString("FRMeasurementUnit")
        End Get
    End Property

    Public Shared ReadOnly Property USMeasurementLargeUnit() As String
        Get
            Return _loader.GetString("USMeasurementLargeUnit")
        End Get
    End Property

    Public Shared ReadOnly Property USMeasurementUnit() As String
        Get
            Return _loader.GetString("USMeasurementUnit")
        End Get
    End Property

    Public Shared ReadOnly Property AppName_Text() As String
        Get
            Return _loader.GetString("AppName_Text")
        End Get
    End Property

    Public Shared ReadOnly Property C1Label_Text() As String
        Get
            Return _loader.GetString("C1Label_Text")
        End Get
    End Property

    Public Shared ReadOnly Property ComponentOne_Text() As String
        Get
            Return _loader.GetString("ComponentOne_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Country_Text() As String
        Get
            Return _loader.GetString("Country_Text")
        End Get
    End Property

    Public Shared ReadOnly Property EnterPlace_Text() As String
        Get
            Return _loader.GetString("EnterPlace_Text")
        End Get
    End Property

    Public Shared ReadOnly Property GrossDomainProduct_Text() As String
        Get
            Return _loader.GetString("GrossDomainProduct_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LoadingData_Text() As String
        Get
            Return _loader.GetString("LoadingData_Text")
        End Get
    End Property

    Public Shared ReadOnly Property MapSource_Text() As String
        Get
            Return _loader.GetString("MapSource_Text")
        End Get
    End Property

    Public Shared ReadOnly Property Uruguay_Text() As String
        Get
            Return _loader.GetString("Uruguay_Text")
        End Get
    End Property

    Public Shared ReadOnly Property USUnit_Text() As String
        Get
            Return _loader.GetString("USUnit_Text")
        End Get
    End Property

    Public Shared ReadOnly Property LoadData_Content() As String
        Get
            Return _loader.GetString("LoadData_Content")
        End Get
    End Property

    Public Shared ReadOnly Property OpenStreetMapLink_Content() As String
        Get
            Return _loader.GetString("OpenStreetMapLink_Content")
        End Get
    End Property

    Public Shared ReadOnly Property Angle_Text() As String
        Get
            Return _loader.GetString("Angle_Text")
        End Get
    End Property
End Class