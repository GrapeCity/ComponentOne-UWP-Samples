Imports System
Imports System.Collections.Generic
Imports Windows.UI.Popups
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports C1.Xaml.Pdf

' The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class MainPage
    Inherits Page

    Private _pdf As C1PdfDocument

    Public Sub New()
        Me.InitializeComponent()
        _pdf = New C1PdfDocument(C1.Xaml.Pdf.PaperKind.Letter)
    End Sub

    Private Async Sub btnSave_Click(sender As Object, e As RoutedEventArgs)
        Dim picker As New FileSavePicker()
        picker.FileTypeChoices.Add("Adobe PDF (*.pdf)", New List(Of String)() From {".pdf"})
        picker.DefaultFileExtension = ".pdf"
        picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary
        Dim file As StorageFile = Await picker.PickSaveFileAsync()
        If file IsNot Nothing Then
            Await _pdf.SaveAsync(file)

            Dim dlg As New MessageDialog("Saved to path: " + file.Path, "C1Pdf")
            Await dlg.ShowAsync()
        End If
    End Sub

    Private Async Sub Page_Loaded(sender As Object, e As RoutedEventArgs)
        progressRing.IsActive = True
        PdfUtil.CreateDocument(_pdf)
        Await c1PdfViewer1.LoadDocumentAsync(PdfUtil.SaveToStream(_pdf))
        'c1PdfViewer1.LoadDocument(PdfUtil.SaveToStream(_pdf))
        progressRing.IsActive = False
    End Sub
End Class
