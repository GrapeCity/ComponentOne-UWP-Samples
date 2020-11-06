Imports C1.Xaml.Excel
Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.UI
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Diagnostics
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports Windows.Storage

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class DemoPage
    Inherits Page
    Private _book As C1XLBook
    Private _cvs As New CollectionViewSource()

    Public Sub New()
        Me.InitializeComponent()

        ' create a pdf file to work with
        _book = New C1XLBook()
    End Sub

    ' refresh view when collection is modified
    Sub RefreshView()
    End Sub

    Async Sub _btnSave_Click(sender As Object, e As RoutedEventArgs)
        Debug.Assert(_book IsNot Nothing)
        Dim picker As New Windows.Storage.Pickers.FileSavePicker()
        picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary
        picker.FileTypeChoices.Add(Strings.Typexlsx, New List(Of String)() From {".xlsx"})
        picker.FileTypeChoices.Add(Strings.Typecsv, New List(Of String)() From {".csv"})
        picker.SuggestedFileName = Strings.DefaultFileName
        Dim file As StorageFile = Await picker.PickSaveFileAsync()
        If file IsNot Nothing Then
            Try
                ' step 1: save file
                Dim fileFormat As FileFormat = If(Path.GetExtension(file.Path).Equals(".csv"), FileFormat.Csv, FileFormat.OpenXml)
                Await _book.SaveAsync(file, fileFormat)

                ' step 2: user feedback
                _tbContent.Text = String.Format(Strings.SaveLocationTip, file.Path)

                RefreshView()
            Catch x As Exception
                _tbContent.Text = String.Format(Strings.SaveAndOpenException, x.Message)
            End Try
        End If
    End Sub

    Private Sub _btnHello_Click(sender As Object, e As RoutedEventArgs)
        ' step 1: create a new workbook
        _book = New C1XLBook()

        ' step 2: get the sheet that was created by default, give it a name
        Dim sheet As XLSheet = _book.Sheets(0)
        sheet.Name = Strings.SheetName

        ' step 3: create styles for odd and even values
        Dim styleOdd As New XLStyle(_book)
        styleOdd.Font = New XLFont("Tahoma", 9, False, True)
        styleOdd.ForeColor = Color.FromArgb(255, 0, 0, 255)
        Dim styleEven As New XLStyle(_book)
        styleEven.Font = New XLFont("Tahoma", 9, True, False)
        styleEven.ForeColor = Color.FromArgb(255, 255, 0, 0)

        ' step 4: write content and format into some cells
        Dim i As Integer = 0
        While i < 100
            Dim cell As XLCell = sheet(i, 0)
            cell.Value = i + 1
            cell.Style = If(((i + 1) Mod 2 = 0), styleEven, styleOdd)
            i += 1
        End While

        ' step 5: allow user to save the file
        _tbContent.Text = Strings.DataCreatedTip
        RefreshView()
    End Sub

    ' open an existing zip file
    Async Sub _btnOpen_Click(sender As Object, e As RoutedEventArgs)
        Try
            Dim picker As New Pickers.FileOpenPicker()
            picker.SuggestedStartLocation = Pickers.PickerLocationId.DocumentsLibrary
            picker.FileTypeFilter.Add(".xlsx")
            picker.FileTypeFilter.Add(".xls")

            Dim file As StorageFile = Await picker.PickSingleFileAsync()
            If file IsNot Nothing Then
                ' step 1: create a new workbook
                _book = New C1XLBook()

                ' step 2: load existing file
                Dim fileFormat As FileFormat = FileFormat.OpenXml
                Await _book.LoadAsync(file, fileFormat)

                ' step 3: allow user to save the file
                _tbContent.Text = String.Format(Strings.OpenTip, _book.Sheets(0).Name)
                RefreshView()
            End If
        Catch x As Exception
            _tbContent.Text = String.Format(Strings.SaveAndOpenException, x.Message)
        End Try
    End Sub
End Class