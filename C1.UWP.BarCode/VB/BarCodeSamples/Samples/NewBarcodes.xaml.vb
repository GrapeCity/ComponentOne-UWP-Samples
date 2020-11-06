' The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238



Imports C1.BarCode
Imports C1.Xaml.BarCode
Imports Windows.Storage
Imports Windows.Storage.Pickers
Imports Windows.UI.Popups
''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Public NotInheritable Class NewBarcodes
    Inherits Page

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Me.Loaded, AddressOf OnLoaded

    End Sub

    Private Sub OnLoaded(sender As Object, e As RoutedEventArgs)
        Dim _barcodes As List(Of CodeType) = New List(Of CodeType) From {
    CodeType.Bc412,
    CodeType.Code11,
    CodeType.HIBCCode128,
    CodeType.HIBCCode39,
    CodeType.Iata25,
    CodeType.IntelligentMailPackage,
    CodeType.ISBN,
    CodeType.ISMN,
    CodeType.ISSN,
    CodeType.ITF14,
    CodeType.MicroQRCode,
    CodeType.Pharmacode,
    CodeType.Plessey,
    CodeType.PZN,
    CodeType.SSCC18,
    CodeType.Telepen
}

        BarcodeType.ItemsSource = _barcodes
        BarcodeType.SelectedIndex = 0
    End Sub

    Private Sub BarcodeType_SelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        barCode.Text = ""
        Dim codetype As CodeType = CType(BarcodeType.SelectedItem, CodeType)
        barCode.CodeType = codetype

        Select Case codetype
            Case CodeType.HIBCCode128, CodeType.HIBCCode39
                BarcodeText.Text = "A123PROD78905/0123456789DATA"
            Case CodeType.IntelligentMailPackage
                BarcodeText.Text = "9212391234567812345671"
            Case CodeType.PZN
                BarcodeText.Text = "01234562"
            Case CodeType.Pharmacode
                BarcodeText.Text = "131070"
            Case CodeType.SSCC18
                BarcodeText.Text = "1234t5+678912345678"
            Case CodeType.Bc412
                BarcodeText.Text = "AQ1557"
            Case CodeType.MicroQRCode
                BarcodeText.Text = "12345"
            Case CodeType.Iata25
                BarcodeText.Text = "0123456789"
            Case CodeType.ITF14
                BarcodeText.Text = "1234567891011"
            Case Else
                BarcodeText.Text = "9790123456785"
        End Select

        barCode.Text = BarcodeText.Text
    End Sub

    Private Sub Generate_Click(sender As Object, e As RoutedEventArgs)
        If String.IsNullOrWhiteSpace(BarcodeText.Text) Then
            Dim msg = New MessageDialog(Strings.EmptyDataError)
            msg.ShowAsync()
            Return
        End If

        barCode.Text = BarcodeText.Text
    End Sub

    Private Async Sub Save_Click(sender As Object, e As RoutedEventArgs)
        Dim picker As New FileSavePicker() With {
            .DefaultFileExtension = ".jpeg"
        }
        picker.FileTypeChoices.Add("Jpeg files", New List(Of String)() From {
            ".jpeg"
        })
        picker.FileTypeChoices.Add("Bmp Files", New List(Of String)() From {
            ".bmp"
        })
        picker.FileTypeChoices.Add("PNG Files", New List(Of String)() From {
            ".png"
        })
        Dim file As StorageFile = Await picker.PickSaveFileAsync()
        If file IsNot Nothing Then
            Dim fileExtension As String = file.FileType.Remove(0, 1)
            Using stream As Stream = New MemoryStream()
                Await barCode.SaveAsync(stream, CType([Enum].Parse(GetType(ImageFormat), fileExtension, True), ImageFormat))
                Using saveSteam As Stream = Await file.OpenStreamForWriteAsync()
                    stream.CopyTo(saveSteam)
                    stream.Seek(0, SeekOrigin.Begin)
                    saveSteam.Seek(0, SeekOrigin.Begin)
                    saveSteam.Flush()
                End Using
            End Using
        End If
    End Sub
End Class
