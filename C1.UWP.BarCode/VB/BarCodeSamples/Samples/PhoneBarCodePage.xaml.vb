Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports Windows.Phone.UI.Input
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.BarCode
Imports C1.BarCode

''' <summary>
''' An empty page that can be used on its own or navigated to within a Frame.
''' </summary>
Partial Public NotInheritable Class PhoneBarCodePage
    Inherits Page
    Private _type As List(Of String)

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Public ReadOnly Property Types As List(Of String)
        Get
            If _type Is Nothing Then
                _type = New List(Of String)(New String() {"QRCode", "DataMatrix", "Pdf417", "Code39x", "Ansi39x", "Code93x"})
            End If
            Return _type
        End Get
    End Property

    Protected Overrides Sub OnNavigatedTo(e As NavigationEventArgs)
        MyBase.OnNavigatedTo(e)
        Dim encodingText As String = CType(e.Parameter, String)
        Me.barCode.DataContext = encodingText
    End Sub

    Private Sub OnSaveImageBtnClick(sender As Object, e As RoutedEventArgs)
        ExportToImage()
    End Sub

    Private Async Sub ExportToImage()
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