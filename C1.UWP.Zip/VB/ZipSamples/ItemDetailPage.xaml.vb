Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System
Imports ZipSamples.Data

''' <summary>
''' A page that displays details for a single item within a group while allowing gestures to
''' flip through other items belonging to the same group.
''' </summary>
Partial Public NotInheritable Class ItemDetailPage
    Inherits Common.LayoutAwarePage
    Public Sub New()
        Me.InitializeComponent()
        Me.flipView.ItemsSource = SampleDataSource.GetItems("AllItems")
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
        ' Allow saved page state to override the initial item to display
        If pageState IsNot Nothing AndAlso pageState.ContainsKey("SelectedItem") Then
            navigationParameter = pageState("SelectedItem")
        End If
        Dim item As Object = SampleDataSource.GetItem(CType(navigationParameter, [String]))
        Me.flipView.SelectedItem = item
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
End Class
