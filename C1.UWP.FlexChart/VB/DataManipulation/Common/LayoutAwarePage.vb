Imports Windows.UI.Core
Imports Windows.Phone.UI.Input
Imports Windows.System
Imports Windows.UI.Input

''' <summary>
''' Typical implementation of Page that provides several important conveniences:
''' <list type="bullet">
''' <item>
''' <description>GoBack, GoForward, and GoHome event handlers</description>
''' </item>
''' <item>
''' <description>Mouse and keyboard shortcuts for navigation</description>
''' </item>
''' <item>
''' <description>State management for navigation and process lifetime management</description>
''' </item>
''' <item>
''' <description>A default view model</description>
''' </item>
''' </list>
''' </summary>
<Windows.Foundation.Metadata.WebHostHidden>
Public Class LayoutAwarePage
    Inherits Page
#Region "static device-aware"
    Public Shared Function IsWindowsPhoneDevice() As Boolean
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            Return True
        End If
        Return False
    End Function
#End Region

    ''' <summary>
    ''' Identifies the <see cref="DefaultViewModel"/> dependency property.
    ''' </summary>
    Public Shared ReadOnly DefaultViewModelProperty As DependencyProperty = DependencyProperty.Register("DefaultViewModel", GetType(IObservableMap(Of [String], [Object])), GetType(LayoutAwarePage), Nothing)

    ''' <summary>
    ''' Initializes a new instance of the <see cref="LayoutAwarePage"/> class.
    ''' </summary>
    Public Sub New()
        If Windows.ApplicationModel.DesignMode.DesignModeEnabled Then
            Return
        End If

        ' Create an empty default view model
        Me.DefaultViewModel = New ObservableDictionary(Of [String], [Object])()

        ' When this page is part of the visual tree handle keyboard and mouse navigation requests.
        AddHandler Me.Loaded, AddressOf LayoutAwarePage_Loaded

        ' Undo the same changes when the page is no longer visible
        AddHandler Me.Unloaded, AddressOf LayoutAwarePage_Unloaded
    End Sub

    Private Sub LayoutAwarePage_Unloaded(sender As Object, e As RoutedEventArgs)
        RemoveHandler Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated, AddressOf CoreDispatcher_AcceleratorKeyActivated
        RemoveHandler Window.Current.CoreWindow.PointerPressed, AddressOf Me.CoreWindow_PointerPressed
    End Sub

    Private Sub LayoutAwarePage_Loaded(sender As Object, e As RoutedEventArgs)
        ' Keyboard and mouse navigation only apply when occupying the entire window
        If Me.ActualHeight = Window.Current.Bounds.Height AndAlso Me.ActualWidth = Window.Current.Bounds.Width Then
            ' Listen to the window directly so focus isn't required
            AddHandler Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated, AddressOf CoreDispatcher_AcceleratorKeyActivated
            AddHandler Window.Current.CoreWindow.PointerPressed, AddressOf Me.CoreWindow_PointerPressed
        End If
    End Sub

    ''' <summary>
    ''' An implementation of <see cref="IObservableMap&lt;String, Object&gt;"/> designed to be
    ''' used as a trivial view model.
    ''' </summary>
    Protected Property DefaultViewModel() As IObservableMap(Of [String], [Object])
        Get
            Return TryCast(Me.GetValue(DefaultViewModelProperty), IObservableMap(Of [String], [Object]))
        End Get

        Set
            Me.SetValue(DefaultViewModelProperty, Value)
        End Set
    End Property

#Region "Navigation support"

    ''' <summary>
    ''' Invoked as an event handler to navigate backward in the page's associated
    ''' <see cref="Frame"/> until it reaches the top of the navigation stack.
    ''' </summary>
    ''' <param name="sender">Instance that triggered the event.</param>
    ''' <param name="e">Event data describing the conditions that led to the event.</param>
    Protected Overridable Sub GoHome(sender As Object, e As RoutedEventArgs)
        ' Use the navigation frame to return to the topmost page
        If Me.Frame IsNot Nothing Then
            While Me.Frame.CanGoBack
                Me.Frame.GoBack()
            End While
        End If
    End Sub

    ''' <summary>
    ''' Invoked as an event handler to navigate backward in the navigation stack
    ''' associated with this page's <see cref="Frame"/>.
    ''' </summary>
    ''' <param name="sender">Instance that triggered the event.</param>
    ''' <param name="e">Event data describing the conditions that led to the
    ''' event.</param>
    Protected Overridable Sub GoBack(sender As Object, e As RoutedEventArgs)
        ' Use the navigation frame to return to the previous page
        If Me.Frame IsNot Nothing AndAlso Me.Frame.CanGoBack Then
            Me.Frame.GoBack()
        End If
    End Sub

    ''' <summary>
    ''' Invoked as an event handler to navigate forward in the navigation stack
    ''' associated with this page's <see cref="Frame"/>.
    ''' </summary>
    ''' <param name="sender">Instance that triggered the event.</param>
    ''' <param name="e">Event data describing the conditions that led to the
    ''' event.</param>
    Protected Overridable Sub GoForward(sender As Object, e As RoutedEventArgs)
        ' Use the navigation frame to move to the next page
        If Me.Frame IsNot Nothing AndAlso Me.Frame.CanGoForward Then
            Me.Frame.GoForward()
        End If
    End Sub

    ''' <summary>
    ''' Invoked on every keystroke, including system keys such as Alt key combinations, when
    ''' this page is active and occupies the entire window.  Used to detect keyboard navigation
    ''' between pages even when the page itself doesn't have focus.
    ''' </summary>
    ''' <param name="sender">Instance that triggered the event.</param>
    ''' <param name="args">Event data describing the conditions that led to the event.</param>
    Private Sub CoreDispatcher_AcceleratorKeyActivated(sender As CoreDispatcher, args As AcceleratorKeyEventArgs)
        Dim virtualKey As VirtualKey = args.VirtualKey

        ' Only investigate further when Left, Right, or the dedicated Previous or Next keys
        ' are pressed
        If (args.EventType = CoreAcceleratorKeyEventType.SystemKeyDown OrElse args.EventType = CoreAcceleratorKeyEventType.KeyDown) AndAlso (virtualKey = VirtualKey.Left OrElse virtualKey = VirtualKey.Right OrElse CType(virtualKey, Integer) = 166 OrElse CType(virtualKey, Integer) = 167) Then
            Dim coreWindow As CoreWindow = Window.Current.CoreWindow
            Dim downState As CoreVirtualKeyStates = CoreVirtualKeyStates.Down
            Dim menuKey As Boolean = (coreWindow.GetKeyState(VirtualKey.Menu) And downState) = downState
            Dim controlKey As Boolean = (coreWindow.GetKeyState(VirtualKey.Control) And downState) = downState
            Dim shiftKey As Boolean = (coreWindow.GetKeyState(VirtualKey.Shift) And downState) = downState
            Dim noModifiers As Boolean = Not menuKey AndAlso Not controlKey AndAlso Not shiftKey
            Dim onlyAlt As Boolean = menuKey AndAlso Not controlKey AndAlso Not shiftKey

            If (CType(virtualKey, Integer) = 166 AndAlso noModifiers) OrElse (virtualKey = VirtualKey.Left AndAlso onlyAlt) Then
                ' When the previous key or Alt+Left are pressed navigate back
                args.Handled = True
                Me.GoBack(Me, New RoutedEventArgs())
            ElseIf (CType(virtualKey, Integer) = 167 AndAlso noModifiers) OrElse (virtualKey = VirtualKey.Right AndAlso onlyAlt) Then
                ' When the next key or Alt+Right are pressed navigate forward
                args.Handled = True
                Me.GoForward(Me, New RoutedEventArgs())
            End If
        End If
    End Sub

    ''' <summary>
    ''' Invoked on every mouse click, touch screen tap, or equivalent interaction when this
    ''' page is active and occupies the entire window.  Used to detect browser-style next and
    ''' previous mouse button clicks to navigate between pages.
    ''' </summary>
    ''' <param name="sender">Instance that triggered the event.</param>
    ''' <param name="args">Event data describing the conditions that led to the event.</param>
    Private Sub CoreWindow_PointerPressed(sender As CoreWindow, args As PointerEventArgs)
        Dim properties As PointerPointProperties = args.CurrentPoint.Properties

        ' Ignore button chords with the left, right, and middle buttons
        If properties.IsLeftButtonPressed OrElse properties.IsRightButtonPressed OrElse properties.IsMiddleButtonPressed Then
            Return
        End If

        ' If back or foward are pressed (but not both) navigate appropriately
        Dim backPressed As Boolean = properties.IsXButton1Pressed
        Dim forwardPressed As Boolean = properties.IsXButton2Pressed
        If backPressed Xor forwardPressed Then
            args.Handled = True
            If backPressed Then
                Me.GoBack(Me, New RoutedEventArgs())
            End If
            If forwardPressed Then
                Me.GoForward(Me, New RoutedEventArgs())
            End If
        End If
    End Sub

#End Region

#Region "Process lifetime management"

    Private _pageKey As [String]

    ''' <summary>
    ''' Invoked when this page is about to be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property provides the group to be displayed.</param>
    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        If IsWindowsPhoneDevice() Then
            ' use hardware button
            AddHandler Windows.Phone.UI.Input.HardwareButtons.BackPressed, AddressOf HardwareButtons_BackPressed
        Else
            ' use window back button
            Dim currentView As SystemNavigationManager = SystemNavigationManager.GetForCurrentView()
            currentView.AppViewBackButtonVisibility = If(Me.Frame IsNot Nothing AndAlso Me.Frame.CanGoBack, AppViewBackButtonVisibility.Visible, AppViewBackButtonVisibility.Collapsed)
            AddHandler currentView.BackRequested, AddressOf backButton_Tapped
        End If

        ' Returning to a cached page through navigation shouldn't trigger state loading
        If Me._pageKey IsNot Nothing Then
            Return
        End If

        Dim frameState As Dictionary(Of [String], [Object]) = SuspensionManager.SessionStateForFrame(Me.Frame)
        Me._pageKey = "Page-" + Me.Frame.BackStackDepth.ToString

        If e.NavigationMode = NavigationMode.[New] Then
            ' Clear existing state for forward navigation when adding a new page to the
            ' navigation stack
            Dim nextPageKey As [String] = Me._pageKey
            Dim nextPageIndex As Integer = Me.Frame.BackStackDepth
            While frameState.Remove(nextPageKey)
                nextPageIndex += 1
                nextPageKey = "Page-" + nextPageIndex.ToString
            End While

            ' Pass the navigation parameter to the new page
            Me.LoadState(e.Parameter, Nothing)
        Else
            ' Pass the navigation parameter and preserved page state to the page, using
            ' the same strategy for loading suspended state and recreating pages discarded
            ' from cache
            Me.LoadState(e.Parameter, CType(frameState(Me._pageKey), Dictionary(Of [String], [Object])))
        End If
    End Sub

    Private Sub HardwareButtons_BackPressed(sender As Object, e As BackPressedEventArgs)
        If Me.Frame IsNot Nothing AndAlso Me.Frame.CanGoBack Then
            e.Handled = True
            Me.Frame.GoBack()
        End If
    End Sub

    Private Sub backButton_Tapped(sender As Object, e As BackRequestedEventArgs)
        Me.GoBack(Me, New RoutedEventArgs())
    End Sub

    ''' <summary>
    ''' Invoked when this page will no longer be displayed in a Frame.
    ''' </summary>
    ''' <param name="e">Event data that describes how this page was reached.  The Parameter
    ''' property provides the group to be displayed.</param>
    Protected Overrides Sub OnNavigatedFrom(e As NavigationEventArgs)
        If IsWindowsPhoneDevice() Then
            RemoveHandler Windows.Phone.UI.Input.HardwareButtons.BackPressed, AddressOf HardwareButtons_BackPressed
        Else
            ' unsubscribe from window back button
            Dim currentView As SystemNavigationManager = SystemNavigationManager.GetForCurrentView()
            RemoveHandler currentView.BackRequested, AddressOf backButton_Tapped
        End If
        Dim frameState As Dictionary(Of [String], [Object]) = SuspensionManager.SessionStateForFrame(Me.Frame)
        Dim pageState As New Dictionary(Of [String], [Object])()
        Me.SaveState(pageState)
        frameState(_pageKey) = pageState
    End Sub

    ''' <summary>
    ''' Populates the page with content passed during navigation.  Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="navigationParameter">The parameter value passed to
    ''' <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
    ''' </param>
    ''' <param name="pageState">A dictionary of state preserved by this page during an earlier
    ''' session.  This will be null the first time a page is visited.</param>
    Protected Overridable Sub LoadState(navigationParameter As [Object], pageState As Dictionary(Of [String], [Object]))
    End Sub

    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    Protected Overridable Sub SaveState(pageState As Dictionary(Of [String], [Object]))
    End Sub

#End Region

    ''' <summary>
    ''' Implementation of IObservableMap that supports reentrancy for use as a default view
    ''' model.
    ''' </summary>
    Private Class ObservableDictionary(Of K, V)
        Implements IObservableMap(Of K, V)
        Private Class ObservableDictionaryChangedEventArgs
            Implements IMapChangedEventArgs(Of K)
            Public Sub New(change As CollectionChange, key As K)
                Me.CollectionChange = change
                Me.Key = key
            End Sub

            Public ReadOnly Property CollectionChange() As CollectionChange Implements IMapChangedEventArgs(Of K).CollectionChange
            Public ReadOnly Property Key() As K Implements IMapChangedEventArgs(Of K).Key
        End Class

        Private _dictionary As New Dictionary(Of K, V)()
        Public Event MapChanged As MapChangedEventHandler(Of K, V) Implements IObservableMap(Of K, V).MapChanged

        Private Sub InvokeMapChanged(change As CollectionChange, key As K)
            RaiseEvent MapChanged(Me, New ObservableDictionaryChangedEventArgs(change, key))
        End Sub

        Public Sub Add(key As K, value As V) Implements IObservableMap(Of K, V).Add
            Me._dictionary.Add(key, value)
            Me.InvokeMapChanged(CollectionChange.ItemInserted, key)
        End Sub

        Public Sub Add(item As KeyValuePair(Of K, V)) Implements IObservableMap(Of K, V).Add
            Me.Add(item.Key, item.Value)
        End Sub

        Public Function Remove(key As K) As Boolean Implements IObservableMap(Of K, V).Remove
            If Me._dictionary.Remove(key) Then
                Me.InvokeMapChanged(CollectionChange.ItemRemoved, key)
                Return True
            End If
            Return False
        End Function

        Public Function Remove(item As KeyValuePair(Of K, V)) As Boolean Implements IObservableMap(Of K, V).Remove
            Dim currentValue As V
            If Me._dictionary.TryGetValue(item.Key, currentValue) AndAlso [Object].Equals(item.Value, currentValue) AndAlso Me._dictionary.Remove(item.Key) Then
                Me.InvokeMapChanged(CollectionChange.ItemRemoved, item.Key)
                Return True
            End If
            Return False
        End Function

        Default Public Property Item(key As K) As V Implements IObservableMap(Of K, V).Item
            Get
                Return Me._dictionary(key)
            End Get
            Set
                Me._dictionary(key) = Value
                Me.InvokeMapChanged(CollectionChange.ItemChanged, key)
            End Set
        End Property

        Public Sub Clear() Implements IObservableMap(Of K, V).Clear
            Dim priorKeys As IEnumerable = Me._dictionary.Keys.ToArray()
            Me._dictionary.Clear()
            For Each key As K In priorKeys
                Me.InvokeMapChanged(CollectionChange.ItemRemoved, key)
            Next
        End Sub

        Public ReadOnly Property Keys() As ICollection(Of K) Implements IObservableMap(Of K, V).Keys
            Get
                Return Me._dictionary.Keys
            End Get
        End Property

        Public Function ContainsKey(key As K) As Boolean Implements IObservableMap(Of K, V).ContainsKey
            Return Me._dictionary.ContainsKey(key)
        End Function

        Public Function TryGetValue(key As K, ByRef value As V) As Boolean Implements IObservableMap(Of K, V).TryGetValue
            Return Me._dictionary.TryGetValue(key, value)
        End Function

        Public ReadOnly Property Values() As ICollection(Of V) Implements IObservableMap(Of K, V).Values
            Get
                Return Me._dictionary.Values
            End Get
        End Property

        Public Function Contains(item As KeyValuePair(Of K, V)) As Boolean Implements IObservableMap(Of K, V).Contains
            Return Me._dictionary.Contains(item)
        End Function

        Public ReadOnly Property Count() As Integer Implements IObservableMap(Of K, V).Count
            Get
                Return Me._dictionary.Count
            End Get
        End Property

        Public ReadOnly Property IsReadOnly() As Boolean Implements IObservableMap(Of K, V).IsReadOnly
            Get
                Return False
            End Get
        End Property

        Private Function IEnumerable_GetEnumerator() As IEnumerator(Of KeyValuePair(Of K, V)) Implements IEnumerable(Of KeyValuePair(Of K, V)).GetEnumerator
            Return Me._dictionary.GetEnumerator()
        End Function

        Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return Me._dictionary.GetEnumerator()
        End Function

        Public Sub CopyTo(array As KeyValuePair(Of K, V)(), arrayIndex As Integer) Implements IObservableMap(Of K, V).CopyTo
            Dim arraySize As Integer = array.Length
            For Each pair As KeyValuePair(Of K, V) In Me._dictionary
                If arrayIndex >= arraySize Then
                    Exit For
                End If
                array(System.Math.Max(System.Threading.Interlocked.Increment(arrayIndex), arrayIndex - 1)) = pair
            Next
        End Sub
    End Class
End Class