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
Imports BasicLibrarySamples.Data

''' <summary>
''' A page that displays a collection of items.
''' </summary>
Partial Public NotInheritable Class MainPage
    Inherits Common.LayoutAwarePage
    Public Sub New()
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

    ''' <summary>
    ''' Invoked when an item is clicked.
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
End Class
