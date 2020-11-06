Imports Windows.UI.Xaml.Navigation
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.UI.Xaml.Media
Imports Windows.UI.Xaml.Input
Imports Windows.UI.Xaml.Data
Imports Windows.UI.Xaml.Controls.Primitives
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Storage.Streams
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports Windows.Foundation.Collections
Imports Windows.Foundation
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Linq
Imports System.IO
Imports System.Collections.Generic
Imports System
Imports C1.Xaml.BarCode
Imports C1.BarCode

Partial Public NotInheritable Class Generator
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
        AddHandler editor.Loaded, AddressOf Editor_Loaded
    End Sub

    Private Sub Editor_Loaded(sender As Object, e As RoutedEventArgs)
        RefreshBarCode()
    End Sub

    Private Sub RefreshBarCode()
        Dim entity As Entity = TryCast(editor.DataContext, Entity)
        If entity IsNot Nothing Then
            barCode.Text = entity.EncodingText
        End If
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

    Private Sub GenerateBarCode(sender As Object, e As RoutedEventArgs)
        RefreshBarCode()
    End Sub

    Private Sub OnSaveImageBtnClick(sender As Object, e As RoutedEventArgs)
        ExportToImage()
    End Sub
End Class