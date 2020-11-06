Imports FlexChart101.Common
Imports C1.C1Zip
Imports System.IO
Imports System.Reflection
Imports FlexChart101.Data
Imports Windows.UI.Xaml.Controls
Imports System.Collections.Generic
Imports System.Linq
Imports System

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
        Dim sampleItems As IEnumerable(Of SampleDataItem) = SampleDataSource.GetItems(CType(navigationParameter, [String]))
        Try
            Dim asm As Assembly = GetType(MainPage).GetTypeInfo().Assembly
            Using stream As Stream = asm.GetManifestResourceStream("FlexChart101.SamplesCodes.zip")
                Using zip As New C1ZipFile(stream)
                    Dim isMobileDevice As Boolean = LayoutAwarePage.IsWindowsPhoneDevice()
                    sampleItems.ToList().ForEach(Sub(sampleItem)
                                                     Dim ets As IEnumerable(Of C1ZipEntry) = zip.Entries.Where(Function(entry) entry.FileName.Equals(sampleItem.SourceCodes.XamlFileName) OrElse entry.FileName.Equals(sampleItem.SourceCodes.CodeFileName) OrElse (entry.FileName.Contains("DeviceFamily-Mobile/")) AndAlso entry.FileName.Contains(sampleItem.SourceCodes.XamlFileName))
                                                     ets.ToList().ForEach(Sub(entry)
                                                                              If entry.FileName.Contains("xaml.vb") Then
                                                                                  sampleItem.SourceCodes.Code = GetContent(entry)
                                                                              ElseIf ets.Count() = 2 OrElse (isMobileDevice AndAlso entry.FileName.Contains("DeviceFamily-Mobile/") OrElse Not isMobileDevice AndAlso Not entry.FileName.Contains("DeviceFamily-Mobile/")) Then
                                                                                  sampleItem.SourceCodes.Xaml = GetContent(entry)
                                                                              End If
                                                                          End Sub)
                                                 End Sub)
                End Using
            End Using

        Catch
        End Try
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

    Function GetContent(entry As C1ZipEntry) As String
        Using entryStream As Stream = entry.OpenReader()
            Using streamReader As New StreamReader(entryStream)
                Return streamReader.ReadToEnd()
            End Using
        End Using
    End Function
End Class