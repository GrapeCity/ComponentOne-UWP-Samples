Imports Windows.Storage.Streams
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports docs = C1.Xaml.RichTextBox.Documents
Imports System.Collections.Generic
Imports RichTextBoxSamples.Tools
Imports C1.Xaml.RichTextBox.Documents
Imports C1.Xaml.RichTextBox
Imports C1.Xaml
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI.Text
Imports Windows.UI.Popups
Imports System.Reflection
Imports System.Linq
Imports System.IO
Imports System

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class AppBarDemo
    Inherits Page
    Private newElement As C1InlineUIContainer

    Public Sub New()
        Me.InitializeComponent()

        btnBold.RichTextBox = rtb
        btnItalic.RichTextBox = rtb
        btnUnderline.RichTextBox = rtb
        If Not Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            btnIncreaseFontSize.RichTextBox = rtb
            btnDecreaseFontSize.RichTextBox = rtb
            btnLeft.RichTextBox = rtb
            btnCenter.RichTextBox = rtb
            btnRight.RichTextBox = rtb
            btnUndo.RichTextBox = rtb
            btnRedo.RichTextBox = rtb
        End If

        Dim asm As Assembly = GetType(DemoRichTextBox).GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream("RichTextBoxSamples.simple.htm")
        Dim sr As StreamReader = New StreamReader(stream)
        Dim html As String = sr.ReadToEnd()
        rtb.Html = html
    End Sub

    Private Async Sub rtb_RequestNavigate(sender As Object, e As RequestNavigateEventArgs)
        Dim md As New MessageDialog(String.Concat(Strings.NavigateMessage, e.Hyperlink.NavigateUri), Strings.Navigate)

        md.Commands.Add(New UICommand(Strings.Ok, Function(UICommandInvokedHandler)
                                                      Windows.System.Launcher.LaunchUriAsync(e.Hyperlink.NavigateUri)

                                                  End Function))

        md.Commands.Add(New UICommand(Strings.Cancel, Function(UICommandInvokedHandler)
                                                          rtb.[Select](e.Hyperlink.ContentStart.TextOffset, e.Hyperlink.ContentRange.Text.Length)

                                                      End Function))

        Await md.ShowAsync()
    End Sub

#Region "Lists"
    Sub btnList_Click(sender As Object, e As RoutedEventArgs)
        Using New DocumentHistoryGroup(rtb.DocumentHistory)
            Dim range As C1TextRange = rtb.Selection
            ' check if selection is already a list
            Dim isChecked As Boolean = range.EditRanges.All(Function(r) docs.TextMarkerStyle.Disc.Equals(GetMarkerStyle(r)))
            range.TrimRuns()
            rtb.Selection = range
            For Each r As C1TextRange In range.EditRanges
                If isChecked Then
                    ' undo list
                    range.UndoList()
                Else
                    ' make bullet list
                    range.MakeList(docs.TextMarkerStyle.Disc)
                End If
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Get the MarkerStyle of the selection.
    ''' </summary>
    ''' <param name="range"></param>
    ''' <returns></returns>
    Function GetMarkerStyle(range As C1TextRange) As System.Nullable(Of docs.TextMarkerStyle)
        Dim lists As List(Of C1List) = range.Lists.ToList()
        Dim marker As System.Nullable(Of docs.TextMarkerStyle) = If(lists.Any(), New System.Nullable(Of docs.TextMarkerStyle)(lists.First().MarkerStyle), Nothing)
        For Each list As C1List In lists
            If marker <> list.MarkerStyle Then
                Return Nothing
            End If
        Next
        Return marker
    End Function
#End Region

#Region "Font Colors"

    Private Sub btnFontColor_Click(sender As Object, e As RoutedEventArgs)
        Dim fontColorPicker As New FontColorTool()
        fontColorPicker.RichTextBox = rtb
        fontColorPicker.ColorMode = FontColorMode.Foreground
        fontColorPicker.Popup.Placement = FlyoutPlacementMode.Top
        fontColorPicker.Show(btnBold)
    End Sub

    Private Sub btnHighlight_Click(sender As Object, e As RoutedEventArgs)
        Dim fontColorPicker As New FontColorTool()
        fontColorPicker.RichTextBox = rtb
        fontColorPicker.ColorMode = FontColorMode.Background
        fontColorPicker.Popup.Placement = FlyoutPlacementMode.Top
        fontColorPicker.Show(btnBold)
    End Sub

#End Region

#Region "Insert Objects"

    Private Sub btnInsertTable_Click(sender As Object, e As RoutedEventArgs)
        Dim tableTool As New InsertTableTool()
        tableTool.RichTextBox = rtb
        tableTool.Popup.Placement = FlyoutPlacementMode.Top
        tableTool.Show(TryCast(sender, FrameworkElement))
    End Sub

    Private Sub btnInsertHyperlink_Click(sender As Object, e As RoutedEventArgs)
        Dim hyperlinkTool As New InsertHyperlinkTool()
        hyperlinkTool.RichTextBox = rtb
        hyperlinkTool.Popup.Placement = FlyoutPlacementMode.Top
        hyperlinkTool.Show(TryCast(sender, FrameworkElement))
    End Sub

    Private Sub btnInsertPicture_Click(sender As Object, e As RoutedEventArgs)
        Dim imageTool As New InsertImageTool()
        imageTool.RichTextBox = rtb
        imageTool.Popup.Placement = FlyoutPlacementMode.Top
        imageTool.Show(TryCast(sender, FrameworkElement))
    End Sub

    Private Async Sub btnPicture_Click(sender As Object, e As RoutedEventArgs)
        Dim openPicker As New FileOpenPicker()
        openPicker.ViewMode = PickerViewMode.Thumbnail
        openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary
        openPicker.FileTypeFilter.Add(".jpg")
        openPicker.FileTypeFilter.Add(".jpeg")
        openPicker.FileTypeFilter.Add(".png")
        Dim file As StorageFile = Await openPicker.PickSingleFileAsync()
        If file IsNot Nothing Then
            Dim source As New BitmapImage()
            Dim newElement As New C1InlineUIContainer() With {
                .Content = source,
                .ContentTemplate = ImageAttach.ImageTemplate
            }
            AddHandler source.ImageFailed, AddressOf OnImageFailed


            Dim stream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.Read)
            source.SetSource(stream)

            Using dataReader As New DataReader(stream)
                stream.Seek(0)
                Dim bytes As Byte() = New Byte(stream.Size) {}
                Await dataReader.LoadAsync(CType(stream.Size, UInteger))
                dataReader.ReadBytes(bytes)
                ImageAttach.SetStream(source, bytes)
            End Using
            Using New DocumentHistoryGroup(rtb.DocumentHistory)
                rtb.Selection.Delete()
                rtb.Selection.Start.InsertInline(newElement)
            End Using
            rtb.Focus(FocusState.Programmatic)
        End If
    End Sub

    Private Sub OnImageFailed(sender As Object, e As ExceptionRoutedEventArgs)
        newElement.Remove()
    End Sub
#End Region

End Class