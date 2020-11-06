Imports Windows.UI.Xaml
Imports AnnotationExplorer.Data
Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System

''' <summary>
''' A page that displays details for a single item within a group while allowing gestures to
''' flip through other items belonging to the same group.
''' </summary>
Partial Public NotInheritable Class ItemDetailPage
    Inherits Common.LayoutAwarePage
    Private storedHeights As New Dictionary(Of SampleDataItem, Double)()

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
        Dim selectedItem As SampleDataItem = TryCast(Me.flipView.SelectedItem, SampleDataItem)
        If selectedItem IsNot Nothing Then
            If storedHeights.ContainsKey(selectedItem) Then
                row1.Height = New GridLength(storedHeights(selectedItem))
            Else
                AdjustRowHeight(selectedItem)
            End If
            Dim result As Boolean = frame.Navigate((selectedItem).PageType)
        End If
    End Sub

    Private Sub FlipView_SizeChanged(sender As Object, e As Windows.UI.Xaml.SizeChangedEventArgs)
        Dim selectedItem As SampleDataItem = TryCast(Me.flipView.SelectedItem, SampleDataItem)
        If selectedItem IsNot Nothing Then
            AdjustRowHeight(selectedItem)
        End If
    End Sub

    Sub AdjustRowHeight(selectedItem As SampleDataItem)
        Dim container As FlipViewItem = TryCast(Me.flipView.ContainerFromIndex(Me.flipView.SelectedIndex), FlipViewItem)
        If container IsNot Nothing Then
            Dim panel As StackPanel = TryCast(container.ContentTemplateRoot, StackPanel)
            If panel IsNot Nothing Then
                Dim desiredHeight As Double = panel.DesiredSize.Height
                row1.Height = New GridLength(desiredHeight)
                storedHeights(selectedItem) = desiredHeight
            End If
        Else
            Dim dataTemplate As DataTemplate = flipView.ItemTemplate
            Dim panel As StackPanel = TryCast(dataTemplate.LoadContent(), StackPanel)
            If panel IsNot Nothing Then
                panel.DataContext = selectedItem
                panel.Measure(New Windows.Foundation.Size(Me.ActualWidth, Double.PositiveInfinity))
                row1.Height = New GridLength(panel.DesiredSize.Height)
                storedHeights(selectedItem) = panel.DesiredSize.Height
            End If
        End If
    End Sub
End Class