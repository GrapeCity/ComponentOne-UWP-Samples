Imports Windows.UI.Xaml
Imports BasicLibrarySamples
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Data
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports Windows.ApplicationModel.Resources.Core
Imports System.Runtime.CompilerServices
Imports System.ComponentModel
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
    ''' Base class for <see cref="SampleDataItem"/> and <see cref="SampleDataGroup"/> that
    ''' defines properties common to both.
    ''' </summary>
    <Windows.Foundation.Metadata.WebHostHidden>
    Public MustInherit Class SampleDataCommon
        Inherits Common.BindableBase
        Private Shared _baseUri As New Uri("ms-appx:///")

        Public Sub New(uniqueId As [String], title As [String], description As [String], imagePath As [String], name As String)
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

            _allItems.Add(New SampleDataItem("MaskedTextBox", Strings.MaskedTextBoxTitle, Strings.MaskedTextBoxDescription, "Assets/LightGray.png", GetType(MaskedTextBoxSample), Strings.MaskedTextBoxName))
            _allItems.Add(New SampleDataItem("NumericBox", Strings.NumericBoxTitle, Strings.NumericBoxDescription, "Assets/DarkGray.png", GetType(NumericBoxSample), Strings.NumericBoxName))
            _allItems.Add(New SampleDataItem("DropDown", Strings.DropDownTitle, Strings.DropDownDescription, "Assets/LightGray.png", GetType(DropDownDemo), Strings.DropDownName))
            _allItems.Add(New SampleDataItem("Hierarchical Tree", Strings.HierarchicalDropDownTitle, Strings.HierarchicalDropDownDescription, "Assets/LightGray.png", GetType(HierarchicalDropDown), Strings.HierarchicalDropDownName))
            _allItems.Add(New SampleDataItem("AutoComplete", Strings.AutoCompleteDropDownTitle, Strings.AutoCompleteDropDownDescription, "Assets/LightGray.png", GetType(AutoCompleteDropDown), Strings.AutoCompleteDropDownName))
            _allItems.Add(New SampleDataItem("DockPanel", Strings.DockPanelSampleTitle, Strings.DockPanelSampleDescription, "Assets/LightGray.png", GetType(DockPanelSample), Strings.DockPanelSampleName))
            _allItems.Add(New SampleDataItem("UniformGrid", Strings.UniformGridSampleTitle, Strings.UniformGridSampleDescription, "Assets/LightGray.png", GetType(UniformGridSample), Strings.UniformGridSampleName))
            _allItems.Add(New SampleDataItem("WrapPanel", Strings.WrapPanelSampleTitle, Strings.WrapPanelSampleDescription, "Assets/DarkGray.png", GetType(WrapPanelSample), Strings.WrapPanelSampleName))
            _allItems.Add(New SampleDataItem("RadialPanel", Strings.RadialPanelSampleTitle, Strings.RadialPanelSampleDescription, "Assets/LightGray.png", GetType(RadialPanelSample), Strings.RadialPanelSampleName))
            _allItems.Add(New SampleDataItem("TabControl", Strings.EntranceTabTitle, Strings.EntranceTabDescription, "Assets/LightGray.png", GetType(EntranceTab), Strings.EntranceTabName))
            _allItems.Add(New SampleDataItem("Tab Placement", Strings.ClearStyleTabControlTitle, Strings.ClearStyleTabControlDescription, "Assets/LightGray.png", GetType(ClearStyleTabControl), Strings.ClearStyleTabControlName))
            _allItems.Add(New SampleDataItem("Close and Pin", Strings.TabControlSampleTitle, Strings.TabControlSampleDescription, "Assets/LightGray.png", GetType(TabControlSample), Strings.TabControlSampleName))
            _allItems.Add(New SampleDataItem("Conditions", Strings.CollectionViewConditionsTitle, Strings.CollectionViewConditionseDescription, "Assets/LightGray.png", GetType(CollectionViewConditions), Strings.CollectionViewConditionsName))
            _allItems.Add(New SampleDataItem("Grouping", Strings.BindingToC1CollectionViewTitle, Strings.BindingToC1CollectionViewDescription, "Assets/LightGray.png", GetType(BindingToC1CollectionView), Strings.BindingToC1CollectionViewName))
            _allItems.Add(New SampleDataItem("ListBox", Strings.ListBoxSampleTitle, Strings.ListBoxSampleDescription, "Assets/LightGray.png", GetType(ListBoxSample), Strings.ListBoxSampleName))
            '_allItems.Add(new SampleDataItem("TileListBox",
            '        "TileListBox",
            '        "The C1TileListBox control is a high performance list box that can arrange its items in both rows and columns to create tile displays. Both ComponentOne ListBox controls support incremental loading so you can infinitely load more items on demand as the user scrolls to the end of the list.",
            '        "Assets/DarkGray.png",
            '        typeof(TileListBoxSample)));
            _allItems.Add(New SampleDataItem("TreeView", Strings.TreeViewSampleTitle, Strings.TreeViewSampleDescription, "Assets/LightGray.png", GetType(TreeViewSample), Strings.TreeViewSampleName))
            _allItems.Add(New SampleDataItem("CheckBoxTreeView", Strings.CheckBoxTreeViewTitle, Strings.CheckBoxTreeViewDescription, "Assets/LightGray.png", GetType(CheckBox), Strings.CheckBoxTreeViewName))
            _allItems.Add(New SampleDataItem("DragDropTreeView", Strings.DragDropTreeViewTitle, Strings.DragDropTreeViewDescription, "Assets/LightGray.png", GetType(DragDrop), Strings.DragDropTreeViewName))
            _allItems.Add(New SampleDataItem("HierarchicalTreeView", Strings.HierarchicalTreeViewTitle, Strings.HierarchicalTreeViewDescription, "Assets/LightGray.png", GetType(HierarchicalTemplate), Strings.HierarchicalTreeViewName))
            If Not (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")) Then
                _allItems.Add(New SampleDataItem("EditTreeView", Strings.EditTreeViewTitle, Strings.EditTreeViewDescription, "Assets/LightGray.png", GetType(Edit), Strings.EditTreeViewName))
            End If
            _allItems.Add(New SampleDataItem("Menu", Strings.MenuSampleTitle, Strings.MenuSampleDescription, "Assets/LightGray.png", GetType(MenuSample), Strings.MenuSampleName))
            _allItems.Add(New SampleDataItem("ContextMenu", Strings.ContextMenuTitle, Strings.ContextMenuDescription, "Assets/LightGray.png", GetType(ContextMenu), Strings.ContextMenuName))
            _allItems.Add(New SampleDataItem("RadialMenu", Strings.RadialMenuTitle, Strings.RadialMenuDescription, "Assets/LightGray.png", GetType(RadialMenu), Strings.RadialMenuName))
            _allItems.Add(New SampleDataItem("Progress Indicator", Strings.ProgressIndicatorDemoTitle, Strings.ProgressIndicatorDemoDescription, "Assets/DarkGray.png", GetType(ProgressIndicatorDemo), Strings.ProgressIndicatorDemoName))
            _allItems.Add(New SampleDataItem("Input Handling", Strings.InputHandlingTitle, Strings.InputHandlingeDescription, "Assets/DarkGray.png", GetType(InputHandling), Strings.InputHandlingName))
            _allItems.Add(New SampleDataItem("RangeSlider", Strings.RangeSliderTitle, Strings.RangeSliderDescription, "Assets/DarkGray.png", GetType(RangeSlider), Strings.RangeSliderName))
            _allItems.Add(New SampleDataItem("GridSplitter", Strings.GridSplitterSampleTitle, Strings.GridSplitterSampleDescription, "Assets/LightGray.png", GetType(GridSplitterSample), Strings.GridSplitterSampleName))

            Dim orderby As IEnumerable(Of SampleDataItem) = From e In _allItems Order By e.Title Select e
            _allItems = New ObservableCollection(Of SampleDataItem)(orderby)
        End Sub
    End Class
End Namespace