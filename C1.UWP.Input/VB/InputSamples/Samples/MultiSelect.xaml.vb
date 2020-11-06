Imports C1.Chart
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Graphics.Display
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.Input
Imports C1.Xaml

' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class MultiSelect
    Inherits Page
    Private _toggleSwitchCommand As PaneToggleSwitchCommand

    Private installing As Boolean

    Public Sub New()
        Me.InitializeComponent()

        If AppHelper.IsWindowsPhoneDevice() Then
            RootView.OpenPaneLength = Window.Current.Bounds.Width
            FontSize = 12
        End If
    End Sub

    Public ReadOnly Property ToggleSwitchCommand() As PaneToggleSwitchCommand
        Get
            If _toggleSwitchCommand Is Nothing Then
                _toggleSwitchCommand = New PaneToggleSwitchCommand()
            End If
            Return _toggleSwitchCommand
        End Get
    End Property

    Public ReadOnly Property AccountTypes() As Dictionary(Of String, AccountType)
        Get
            Return DataProvider.GetProvider().AccountTypes
        End Get
    End Property
    Public ReadOnly Property IncomeTypes() As Dictionary(Of String, IncomeType)
        Get
            Return DataProvider.GetProvider().IncomeTypes
        End Get
    End Property
    Public ReadOnly Property ExpenseTypes() As Dictionary(Of String, ExpenseType)
        Get
            Return DataProvider.GetProvider().ExpenseTypes
        End Get
    End Property

    Public ReadOnly Property FamilyMembers() As List(Of String)
        Get
            Return DataProvider.GetProvider().FamilyMembers
        End Get
    End Property

    Public ReadOnly Property Incomes() As C1CollectionView
        Get
            Return DataProvider.GetProvider().Incomes
        End Get
    End Property
    Public ReadOnly Property Expenses() As C1CollectionView
        Get
            Return DataProvider.GetProvider().Expenses
        End Get
    End Property

    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        installing = True
        AddHandler DisplayInformation.GetForCurrentView().OrientationChanged, AddressOf MultiSelect_OrientationChanged
        FamilyMemberSelect.SelectAll()
        AccountSelect.SelectAll()
        IncomeDetailsSelect.SelectAll()
        ExpenseDetailsSelect.SelectAll()
        FamilyMemberSelect.[AddHandler](PointerPressedEvent, New PointerEventHandler(AddressOf OnMultiPointerPressed), True)
        AccountSelect.[AddHandler](PointerPressedEvent, New PointerEventHandler(AddressOf OnMultiPointerPressed), True)
        IncomeDetailsSelect.[AddHandler](PointerPressedEvent, New PointerEventHandler(AddressOf OnMultiPointerPressed), True)
        ExpenseDetailsSelect.[AddHandler](PointerPressedEvent, New PointerEventHandler(AddressOf OnMultiPointerPressed), True)
        installing = False
    End Sub

    Private Sub MultiSelect_OrientationChanged(sender As DisplayInformation, args As Object)
        If AppHelper.IsWindowsPhoneDevice() Then
            Select Case sender.CurrentOrientation
                Case DisplayOrientations.Landscape, DisplayOrientations.LandscapeFlipped
                    IncomeChart.LegendPosition = Position.Left
                    ExpenseChart.LegendPosition = Position.Left
                    Exit Select
                Case DisplayOrientations.Portrait, DisplayOrientations.PortraitFlipped
                    IncomeChart.LegendPosition = Position.Bottom
                    ExpenseChart.LegendPosition = Position.Bottom
                    Exit Select
            End Select
        End If
    End Sub

    Private Sub OnFamilyMemberSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If AppHelper.IsWindowsPhoneDevice() AndAlso Not installing Then
            RootView.IsPaneOpen = False
        End If
        Dim addItems As List(Of String) = New List(Of String)()
        Dim removeItems As List(Of String) = New List(Of String)()
        CreateAddAndRemoveItems(True, e, addItems, removeItems)
        DataProvider.GetProvider().UpdateData(addItems, removeItems, DataProvider.GetProvider().FilterFamilyMembers, DataFilterType.Name)
    End Sub

    Private Sub OnAccountSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If AppHelper.IsWindowsPhoneDevice() AndAlso Not installing Then
            RootView.IsPaneOpen = False
        End If
        Dim addItems As List(Of AccountType) = New List(Of AccountType)()
        Dim removeItems As List(Of AccountType) = New List(Of AccountType)()
        CreateAddAndRemoveItems(False, e, addItems, removeItems)
        DataProvider.GetProvider().UpdateData(addItems, removeItems, DataProvider.GetProvider().FilterAccountTypes, DataFilterType.Account)
    End Sub

    Private Sub OnIncomeDetailsSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If AppHelper.IsWindowsPhoneDevice() AndAlso Not installing Then
            RootView.IsPaneOpen = False
        End If
        Dim addItems As List(Of IncomeType) = New List(Of IncomeType)()
        Dim removeItems As List(Of IncomeType) = New List(Of IncomeType)()
        CreateAddAndRemoveItems(False, e, addItems, removeItems)
        DataProvider.GetProvider().UpdateData(addItems, removeItems, DataProvider.GetProvider().FilterIncomeTypes, DataFilterType.Income)
    End Sub

    Private Sub OnExpenseDetailsSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If AppHelper.IsWindowsPhoneDevice() AndAlso Not installing Then
            RootView.IsPaneOpen = False
        End If
        Dim addItems As List(Of ExpenseType) = New List(Of ExpenseType)()
        Dim removeItems As List(Of ExpenseType) = New List(Of ExpenseType)()
        CreateAddAndRemoveItems(False, e, addItems, removeItems)
        DataProvider.GetProvider().UpdateData(addItems, removeItems, DataProvider.GetProvider().FilterExpenseTypes, DataFilterType.Expense)
    End Sub

    Private Sub CreateAddAndRemoveItems(Of T)(isString As Boolean, e As SelectionChangedEventArgs, addItems As List(Of T), removeItems As List(Of T))
        For Each item As Object In e.AddedItems
            Dim member As T = If(isString, CType(item, T), (CType(item, KeyValuePair(Of String, T))).Value)
            addItems.Add(member)
        Next
        For Each item As Object In e.RemovedItems
            Dim member As T = If(isString, CType(item, T), (CType(item, KeyValuePair(Of String, T))).Value)
            removeItems.Add(member)
        Next
    End Sub

    Private Function IsClickToggleButton(element As DependencyObject) As Boolean
        Dim parent As DependencyObject = VisualTreeHelper.GetParent(element)
        If parent Is Nothing Then
            Return False
        ElseIf TypeOf parent Is ToggleButton Then
            Return True
        Else
            Return IsClickToggleButton(parent)
        End If
    End Function

    Private Sub OnMultiPointerPressed(sender As Object, e As PointerRoutedEventArgs)
        Dim element As FrameworkElement = TryCast(e.OriginalSource, FrameworkElement)
        Dim result As Boolean = IsClickToggleButton(element)
        If result Then
            TryCast(sender, C1MultiSelect).Focus(FocusState.Keyboard)
        End If
    End Sub
End Class