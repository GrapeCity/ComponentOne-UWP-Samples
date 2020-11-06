Imports C1.Xaml
Imports C1.Xaml.Input

' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class CheckList
    Inherits Page
    Private _toggleSwitchCommand As PaneToggleSwitchCommand

    Private _factoryItems As ObservableCollection(Of Factory)
    Private _officeItems As ObservableCollection(Of Office)

    Public Sub New()
        Me.InitializeComponent()
        If AppHelper.IsWindowsPhoneDevice() Then
            RootView.OpenPaneLength = Window.Current.Bounds.Width
            FontSize = 12
        End If
        _officeItems = New ObservableCollection(Of Office)()
        _factoryItems = New ObservableCollection(Of Factory)()
    End Sub

    Public ReadOnly Property ToggleSwitchCommand() As PaneToggleSwitchCommand
        Get
            If _toggleSwitchCommand Is Nothing Then
                _toggleSwitchCommand = New PaneToggleSwitchCommand()
            End If
            Return _toggleSwitchCommand
        End Get
    End Property

    Public ReadOnly Property Offices() As List(Of Office)
        Get
            Return DataProvider.GetProvider().DistributionData.Offices
        End Get
    End Property
    Public ReadOnly Property Factories() As List(Of Factory)
        Get
            Return DataProvider.GetProvider().DistributionData.Factories
        End Get
    End Property

    Public ReadOnly Property OfficeItems() As ObservableCollection(Of Office)
        Get
            Return _officeItems
        End Get
    End Property
    Public ReadOnly Property FactoryItems() As ObservableCollection(Of Factory)
        Get
            Return _factoryItems
        End Get
    End Property

    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        FactorySelector.SelectAll()
        OfficeSelector.SelectAll()
    End Sub

    Private Sub OnFactorySelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If AppHelper.IsWindowsPhoneDevice() Then
            RootView.IsPaneOpen = False
        End If
        Update((TryCast(sender, C1CheckList)), FactoryItems, e)
    End Sub

    Private Sub OnOfficeSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If AppHelper.IsWindowsPhoneDevice() Then
            RootView.IsPaneOpen = False
        End If
        Update((TryCast(sender, C1CheckList)), OfficeItems, e)
    End Sub

    Private Sub Update(Of T)(checkList As C1CheckList, source As ObservableCollection(Of T), e As SelectionChangedEventArgs)
        For Each addItem As T In e.AddedItems
            If Not source.Contains(addItem) Then
                source.Add(addItem)
            End If
        Next
        For Each removeItem As T In e.RemovedItems
            If source.Contains(removeItem) Then
                source.Remove(removeItem)
            End If
        Next
    End Sub
End Class