Imports C1.Xaml.Chart
Imports System.Collections.Generic
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml
Imports Windows.Storage.Pickers
Imports Windows.Storage
Imports System.Linq
Imports System.IO
Imports System

Partial Public NotInheritable Class ImageExport
    Inherits Page
    Private cnt As Integer = 100
    Private rnd As New Random()
    Private coef As String() = New String() {"AMTMNQQXUYGA", "CVQKGHQTPHTE", "FIRCDERRPVLD", "GIIETPIQRRUL", "GLXOESFTTPSV", "GXQSNSKEECTX"}

    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub ImageExport_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        CreateData()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        CreateData()
    End Sub

    Sub CreateData()
        flexChart.BeginUpdate()
        flexChart.ItemsSource = DataCreator.Create(coef, cnt)
        flexChart.EndUpdate()
    End Sub

    Private Async Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim picker As New FileSavePicker()
        [Enum].GetNames(GetType(ImageFormat)).ToList().ForEach(Sub(fmt)
                                                                   picker.FileTypeChoices.Add(fmt.ToString().ToUpper(), New List(Of String)() From {
                                                                       "." + fmt.ToString().ToLower()
                                                                   })
                                                               End Sub)
        Dim file As StorageFile = Await picker.PickSaveFileAsync()
        If file IsNot Nothing Then
            Dim stream As Stream = New MemoryStream()
            Dim extension As String = file.FileType.Substring(1, file.FileType.Length - 1)
            Dim fmt As ImageFormat = CType([Enum].Parse(GetType(ImageFormat), extension, True), ImageFormat)
            flexChart.SaveImage(stream, fmt)
            Using saveStream As Stream = Await file.OpenStreamForWriteAsync()
                stream.CopyTo(saveStream)
                stream.Seek(0, SeekOrigin.Begin)
                saveStream.Seek(0, SeekOrigin.Begin)
                saveStream.Flush()
                saveStream.Dispose()
            End Using
        End If
    End Sub
End Class