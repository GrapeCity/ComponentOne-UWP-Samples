Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports CustomLocalization.Data

''' <summary>
''' A page that displays details for a single item within a group.
''' </summary>
Partial Public NotInheritable Class ItemDetailPage
    Inherits Common.LayoutAwarePage
    'private NavigationHelper navigationHelper;
    'private ObservableDictionary defaultViewModel = new ObservableDictionary();

    '''// <summary>
    '''// NavigationHelper is used on each page to aid in navigation and 
    '''// process lifetime management
    '''// </summary>
    'public NavigationHelper NavigationHelper
    '{
    '    get { return this.navigationHelper; }
    '}

    '''// <summary>
    '''// This can be changed to a strongly typed view model.
    '''// </summary>
    'public ObservableDictionary DefaultViewModel
    '{
    '    get { return this.defaultViewModel; }
    '}

    Public Sub New()
        Me.InitializeComponent()
        'this.navigationHelper = new NavigationHelper(this);
        'this.navigationHelper.LoadState += navigationHelper_LoadState;
        Me.flipView.ItemsSource = SampleDataSource.GetItems("AllItems")
    End Sub

    '''// <summary>
    '''// Populates the page with content passed during navigation.  Any saved state is also
    '''// provided when recreating a page from a prior session.
    '''// </summary>
    '''// <param name="sender">
    '''// The source of the event; typically <see cref="NavigationHelper"/>
    '''// </param>
    '''// <param name="e">Event data that provides both the navigation parameter passed to
    '''// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
    '''// a dictionary of state preserved by this page during an earlier
    '''// session.  The state will be null the first time a page is visited.</param>
    'private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
    '{
    '    // TODO: Create an appropriate data model for your problem domain to replace the sample data
    '    var item = SampleDataSource.GetItem((String)e.NavigationParameter);
    '    this.DefaultViewModel["Item"] = item;
    '    contentFrame.Navigate(item.PageType);
    '}

    ''' <summary>
    ''' Populates the page with content passed during navigation.  Any saved state is also
    ''' provided when recreating a page from a prior session.
    ''' </summary>
    ''' <param name="navigationParameter">The parameter value passed to
    ''' <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
    ''' </param>
    ''' <param name="pageState">A dictionary of state preserved by this page during an earlier
    ''' session.  This will be null the first time a page is visited.</param>
    Protected Overrides Sub LoadState(navigationParameter As [Object], pageState As Dictionary(Of [String], [Object]))
        ' Allow saved page state to override the initial item to display
        If pageState IsNot Nothing AndAlso pageState.ContainsKey("SelectedItem") Then
            navigationParameter = pageState("SelectedItem")
        End If
        Dim item As Object = SampleDataSource.GetItem(CType(navigationParameter, [String]))
        Me.flipView.SelectedItem = item
        Me.pageLogoAndTitle.Visibility = Visibility.Visible
    End Sub

    ''' <summary>
    ''' Preserves state associated with this page in case the application is suspended or the
    ''' page is discarded from the navigation cache.  Values must conform to the serialization
    ''' requirements of <see cref="SuspensionManager.SessionState"/>.
    ''' </summary>
    ''' <param name="pageState">An empty dictionary to be populated with serializable state.</param>
    Protected Overrides Sub SaveState(pageState As Dictionary(Of [String], [Object]))
        Dim selectedItem As SampleDataItem = CType(Me.flipView.SelectedItem, SampleDataItem)
        pageState("SelectedItem") = selectedItem.UniqueId
    End Sub

    Sub flipView_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        If Me.flipView.SelectedItem IsNot Nothing Then
            ' keep frame content in sync with the selected item
            Dim result As Boolean = frame.Navigate((CType(Me.flipView.SelectedItem, SampleDataItem)).PageType)
        End If
    End Sub

#Region "NavigationHelper registration"

    ''' The methods provided in this section are simply used to allow
    ''' NavigationHelper to respond to the page's navigation methods.
    ''' 
    ''' Page specific logic should be placed in event handlers for the  
    ''' <see cref="GridCS.Common.NavigationHelper.LoadState"/>
    ''' and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
    ''' The navigation parameter is available in the LoadState method 
    ''' in addition to page state preserved during an earlier session.


    'protected override void OnNavigatedTo(NavigationEventArgs e)
    '{
    '    navigationHelper.OnNavigatedTo(e);
    '}

    'protected override void OnNavigatedFrom(NavigationEventArgs e)
    '{
    '    navigationHelper.OnNavigatedFrom(e);
    '}

#End Region
End Class