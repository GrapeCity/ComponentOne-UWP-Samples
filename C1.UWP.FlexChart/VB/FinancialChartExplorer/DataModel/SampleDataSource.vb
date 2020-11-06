Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Linq
Imports System

' The data model defined by this file serves as a representative example of a strongly-typed
' model that supports notification when members are added, removed, or modified.  The property
' names chosen coincide with data bindings in the standard item templates.
'
' Applications may use this model as a starting point and build on it, or discard it entirely and
' replace it with something appropriate to their needs.

Namespace Data
    ''' <summary>
    ''' Base class for <see cref="SampleDataItem"/> that defines common properties.
    ''' </summary>
    <Windows.Foundation.Metadata.WebHostHidden>
    Public MustInherit Class SampleDataCommon
        Inherits Common.BindableBase
        Private Shared _baseUri As New Uri("ms-appx:///")

        Public Sub New(uniqueId As [String], title As [String], description As [String], imagePath As [String], name As [String])
            Me._uniqueId = uniqueId
            Me._title = title
            Me._description = description
            Me._imagePath = imagePath
            Me.Name = name
        End Sub

        Private _uniqueId As String = String.Empty
        Public Property UniqueId() As String
            Get
                Return Me._uniqueId
            End Get
            Set
                Me.SetProperty(Me._uniqueId, Value)
            End Set
        End Property

        Private _title As String = String.Empty
        Public Property Title() As String
            Get
                Return Me._title
            End Get
            Set
                Me.SetProperty(Me._title, Value)
            End Set
        End Property

        Private _description As String = String.Empty
        Public Property Description() As String
            Get
                Return Me._description
            End Get
            Set
                Me.SetProperty(Me._description, Value)
            End Set
        End Property

        Public Property Name() As String

        Public ReadOnly Property Icon() As DataTemplate
            Get
                Try
                    Return CType(App.Current.Resources("IconC1" + UniqueId.Replace(" ", "")), DataTemplate)
                Catch
                    Return CType(App.Current.Resources("IconC1Gray"), DataTemplate)
                End Try
            End Get
        End Property

        Private _image As ImageSource = Nothing
        Private _imagePath As [String] = Nothing
        Public Property Image() As ImageSource
            Get
                If Me._image Is Nothing AndAlso Me._imagePath IsNot Nothing Then
                    Me._image = New BitmapImage(New Uri(SampleDataCommon._baseUri, Me._imagePath))
                End If
                Return Me._image
            End Get

            Set
                Me._imagePath = Nothing
                Me.SetProperty(Me._image, Value)
            End Set
        End Property

        Public Sub SetImage(path As [String])
            Me._image = Nothing
            Me._imagePath = path
            Me.OnPropertyChanged("Image")
        End Sub

        Public Overrides Function ToString() As String
            Return Me.Title
        End Function
    End Class

    ''' <summary>
    ''' Generic item data model.
    ''' </summary>
    Public Class SampleDataItem
        Inherits SampleDataCommon
        Public Sub New(uniqueId As [String], title As [String], description As [String], imagePath As [String], pageType As Type, name As String)
            MyBase.New(uniqueId, title, description, imagePath, name)
            _pageType = pageType
        End Sub

        Private _pageType As Type
        Public Property PageType() As Type
            Get
                Return Me._pageType
            End Get
            Set
                Me.SetProperty(Me._pageType, Value)
            End Set
        End Property
    End Class

    ''' <summary>
    ''' Creates a collection of groups and items with hard-coded content.
    ''' 
    ''' SampleDataSource initializes with placeholder data rather than live production
    ''' data so that sample data is provided at both design-time and run-time.
    ''' </summary>
    Public NotInheritable Class SampleDataSource
        Private Shared _sampleDataSource As New SampleDataSource()

        Private _allItems As New ObservableCollection(Of SampleDataItem)()
        Public ReadOnly Property AllItems() As ObservableCollection(Of SampleDataItem)
            Get
                Return Me._allItems
            End Get
        End Property

        Public Shared Function GetItems(uniqueId As String) As IEnumerable(Of SampleDataItem)
            If Not uniqueId.Equals("AllItems") Then
                Throw New ArgumentException(Strings.UniqueIdItemsArgumentException)
            End If

            Return _sampleDataSource.AllItems
        End Function

        Public Shared Function GetItem(uniqueId As String) As SampleDataItem
            ' Simple linear search is acceptable for small data sets
            Dim matches As IEnumerable(Of SampleDataItem) = _sampleDataSource.AllItems.Where(Function(item) item.UniqueId.Equals(uniqueId))
            If matches.Count() = 1 Then
                Return matches.First()
            End If
            Return Nothing
        End Function

        Public Sub New()
            _allItems.Add(New SampleDataItem("HeikinAshi", Strings.HeikinAshiTitle, Strings.HeikinAshiDescription, "", GetType(HeikinAshi), Strings.HeikinAshiName))
            _allItems.Add(New SampleDataItem("LineBreak", Strings.LineBreakTitle, Strings.LineBreakDescription, "", GetType(LineBreak), Strings.LineBreakName))
            _allItems.Add(New SampleDataItem("Renko", Strings.RenkoTitle, Strings.RenkoDescription, "", GetType(Renko), Strings.RenkoName))
            _allItems.Add(New SampleDataItem("Kagi", Strings.KagiTitle, Strings.KagiDescription, "", GetType(Kagi), Strings.KagiName))
            _allItems.Add(New SampleDataItem("ColumnVolume", Strings.ColumnVolumeTitle, Strings.ColumnVolumeDescription, "", GetType(ColumnVolume), Strings.ColumnVolumeName))
            _allItems.Add(New SampleDataItem("EquiVolume", Strings.EquiVolumeTitle, Strings.EquiVolumeDescription, "", GetType(EquiVolume), Strings.EquiVolumeName))
            _allItems.Add(New SampleDataItem("CandleVolume", Strings.CandleVolumeTitle, Strings.CandleVolumeDescription, "", GetType(CandleVolume), Strings.CandleVolumeName))
            _allItems.Add(New SampleDataItem("ArmsCandleVolume", Strings.ArmsCandleVolumeTitle, Strings.ArmsCandleVolumeDescription, "", GetType(ArmsCandleVolume), Strings.ArmsCandleVolumeName))
            _allItems.Add(New SampleDataItem("Markers", Strings.MarkersTitle, Strings.MarkersDescription, "", GetType(Markers), Strings.MarkersName))
            _allItems.Add(New SampleDataItem("RangeSelector", Strings.RangeSelectorTitle, Strings.RangeSelectorDescription, "", GetType(RangeSelector), Strings.RangeSelectorName))
            _allItems.Add(New SampleDataItem("TrendLines", Strings.TrendLinesTitle, Strings.TrendLinesDescription, "", GetType(TrendLines), Strings.TrendLinesName))
            _allItems.Add(New SampleDataItem("MovingAverages", Strings.MovingAveragesTitle, Strings.MovingAveragesDescription, "", GetType(MovingAverages), Strings.MovingAveragesName))
            _allItems.Add(New SampleDataItem("Overlays", Strings.OverlaysTitle, Strings.OverlaysDescription, "", GetType(Overlays), Strings.OverlaysName))
            _allItems.Add(New SampleDataItem("Indicators", Strings.IndicatorsTitle, Strings.IndicatorsDescription, "", GetType(Indicators), Strings.IndicatorsName))
            _allItems.Add(New SampleDataItem("EventAnnotations", Strings.EventAnnotationsTitle, Strings.EventAnnotationsDescription, "", GetType(EventAnnotations), Strings.EventAnnotationsName))
            _allItems.Add(New SampleDataItem("FibonacciTool", Strings.FibonacciToolTitle, Strings.FibonacciToolDescription, "", GetType(FibonacciTool), Strings.FibonacciToolName))
        End Sub
    End Class
End Namespace