' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.UI.Popups
Imports Windows.UI.ViewManagement

Imports C1.Xaml.Document
Imports C1.Xaml.FlexViewer

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Const c_CheckedGlyph As String = ChrW(&HE0A2)
    Const c_UncheckedGlyph As String = ChrW(&HE003)

    Dim _pdfDocSource = New C1PdfDocumentSource() With {.UseSystemRendering = False}
    Dim _closeToolItem As ToolMenuItem
    Dim _useSystemRenderingToolItem As ToolMenuItem
    Dim _appView As ApplicationView

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Application.Current.Suspending, AddressOf App_Suspending
        AddHandler Me.Unloaded, AddressOf MainPage_Unloaded
        AddHandler Me.Loaded, AddressOf MainPage_Loaded

        AddHandler flexViewer.PrepareToolMenu, AddressOf FlexViewer_PrepareToolMenu
        AddHandler flexViewer.NavigateToCustomTool, AddressOf FlexViewer_NavigateToCustomTool
        _appView = ApplicationView.GetForCurrentView()
    End Sub

    Sub App_Suspending()
        flexViewer.Pane.HandleSuspending()
    End Sub

    Sub FlexViewer_PrepareToolMenu(sender As Object, e As EventArgs)
        Dim items = CType(sender, C1FlexViewer).ToolMenuItems
        For i = items.Count - 1 To 0 Step -1
            Select Case items(i).Tool
                Case FlexViewerTool.PageSettings
                Case FlexViewerTool.Parameters
                    items.RemoveAt(i)
            End Select
        Next

        items.Insert(0, New ToolMenuItem(ChrW(&HE155), FlexViewerTool.CustomTool1, Strings.OpenToolLabel))
        _useSystemRenderingToolItem = New ToolMenuItem(If(_pdfDocSource.UseSystemRendering, c_CheckedGlyph, c_UncheckedGlyph), FlexViewerTool.CustomTool3, Strings.UseSystemRenderingToolLabel)
        items.Add(_useSystemRenderingToolItem)
        _closeToolItem = New ToolMenuItem(ChrW(&HE10A), FlexViewerTool.CustomTool2, Strings.CloseToolLabel)
        items.Add(_closeToolItem)
    End Sub

    Async Sub FlexViewer_NavigateToCustomTool(sender As Object, e As CustomToolEventArgs)
        If (e.Tool = FlexViewerTool.CustomTool1) Then
            Await OpenPdf()
        ElseIf (e.Tool = FlexViewerTool.CustomTool2) Then
            _pdfDocSource.ClearContent()
        ElseIf (e.Tool = FlexViewerTool.CustomTool3) Then
            Await ChangeUseSystemRendering()
        End If
    End Sub

    Sub MainPage_Unloaded(sender As Object, e As RoutedEventArgs)
        _pdfDocSource.ClearContent()
    End Sub

    Async Sub MainPage_Loaded(sender As Object, e As RoutedEventArgs)
        Dim f = Await StorageFile.GetFileFromApplicationUriAsync(New Uri("ms-appx:///Assets/DefaultDocument.pdf"))
        Await LoadPdf(f)
        flexViewer.DocumentSource = _pdfDocSource
    End Sub

    Sub CheckBox_Changed(sender As Object, e As RoutedEventArgs)
        If revealModeCheckBox.IsChecked Then
            passwordBox.PasswordRevealMode = PasswordRevealMode.Visible
        Else
            passwordBox.PasswordRevealMode = PasswordRevealMode.Hidden
        End If
    End Sub

    Async Function ChangeUseSystemRendering() As Task
        _closeToolItem.IsEnabled = False
        _useSystemRenderingToolItem.IsEnabled = False
        Try
            _pdfDocSource.UseSystemRendering = Not _pdfDocSource.UseSystemRendering
            _useSystemRenderingToolItem.Glyph = If(_pdfDocSource.UseSystemRendering, c_CheckedGlyph, c_UncheckedGlyph)
            Await _pdfDocSource.GenerateAsync()
        Finally
            _closeToolItem.IsEnabled = True
            _useSystemRenderingToolItem.IsEnabled = True
        End Try
    End Function

    Async Function LoadPdf(file As StorageFile) As Task
        _closeToolItem.IsEnabled = False
        _useSystemRenderingToolItem.IsEnabled = False

        Try
            While (True)
                Dim exception As Exception = Nothing
                Try
                    Await _pdfDocSource.LoadFromFileAsync(file)
                    Exit While
                Catch ex As Exception
                    exception = ex
                End Try

                If TypeOf exception Is PdfPasswordException Then
                    fileNameBlock.Text = file.Name
                    passwordBox.Password = String.Empty
                    If (Await passwordDialog.ShowAsync() <> ContentDialogResult.Primary) Then
                        Exit While
                    End If
                    _pdfDocSource.Credential = New System.Net.NetworkCredential(Nothing, passwordBox.Password)
                Else
                    Dim md As MessageDialog = New MessageDialog(String.Format(Strings.PdfErrorFormat, file.Name, exception.Message), Strings.ErrorTitle)
                    Await md.ShowAsync()
                    Exit While
                End If
            End While
        Finally
            _closeToolItem.IsEnabled = True
            _useSystemRenderingToolItem.IsEnabled = True
        End Try

    End Function

    Async Function OpenPdf() As Task
        Dim fop = New FileOpenPicker()
        fop.SuggestedStartLocation = PickerLocationId.DocumentsLibrary
        fop.ViewMode = PickerViewMode.List
        fop.FileTypeFilter.Clear()
        fop.FileTypeFilter.Add(".pdf")
        Dim file = Await fop.PickSingleFileAsync()
        If Not (file Is Nothing) Then
            Await LoadPdf(file)
        End If
    End Function

End Class
