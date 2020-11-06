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
''' A page that displays a grouped collection of items.
''' </summary>
Partial Public NotInheritable Class MainPage
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
        'this.navigationHelper = new NavigationHelper(this);
        'this.navigationHelper.LoadState += navigationHelper_LoadState;
        Me.InitializeComponent()
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
    Protected Overrides Sub LoadState(navigationParameter As [Object], pageState As Dictionary(Of [String], [Object]))
        ' TODO: Create an appropriate data model for your problem domain to replace the sample data
        Dim sampleItems As Object = SampleDataSource.GetItems(CType(navigationParameter, [String]))
        Me.DefaultViewModel("AllItems") = sampleItems
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
    '    var sampleDataItems = SampleDataSource.GetItems("AllItems");
    '    this.DefaultViewModel["Items"] = sampleDataItems;
    '}

    ''' <summary>
    ''' Invoked when an item within a group is clicked.
    ''' </summary>
    ''' <param name="sender">The GridView (or ListView when the application is snapped)
    ''' displaying the item clicked.</param>
    ''' <param name="e">Event data that describes the item clicked.</param>
    Sub ItemView_ItemClick(sender As Object, e As ItemClickEventArgs)
        ' Navigate to the appropriate destination page, configuring the new page
        ' by passing required information as a navigation parameter
        Dim itemId As Object = (CType(e.ClickedItem, SampleDataItem)).UniqueId
        Me.Frame.Navigate(GetType(ItemDetailPage), itemId)
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
    '    if (e.NavigationMode != NavigationMode.Back && !string.IsNullOrEmpty((string)e.Parameter))
    '    {
    '        // apparently application had been launched by toast notification, so navigate to Save Local Data sample which creates such notifications
    '        this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, (()=>this.Frame.Navigate(typeof(ItemDetailPage), "Save Local Data")));
    '    }
    '}

    'protected override void OnNavigatedFrom(NavigationEventArgs e)
    '{
    '    navigationHelper.OnNavigatedFrom(e);
    '}

#End Region
End Class