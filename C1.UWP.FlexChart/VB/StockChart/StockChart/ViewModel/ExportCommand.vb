Imports Windows.Storage
Imports Windows.Storage.Pickers

Public Class ExportCommand
    Inherits DependencyObject
    Implements ICommand
    Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

    Public Sub RaiseCanExecuteChanged()
        RaiseEvent CanExecuteChanged(Me, New EventArgs())
    End Sub

    Private _viewModel As ChartViewModel
    Public Sub New(viewModel As ChartViewModel)
        _viewModel = viewModel
    End Sub

    Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
        Return parameter IsNot Nothing
    End Function

    Public Async Sub Execute(parameter As Object) Implements ICommand.Execute
        Dim type As String = parameter.ToString()


        Dim fmt As String = String.Empty
        Dim format As C1.Xaml.Chart.ImageFormat = C1.Xaml.Chart.ImageFormat.Png
        Select Case type
            Case "PNG"
                fmt = "png"
                format = C1.Xaml.Chart.ImageFormat.Png
                Exit Select
            Case "JPG"
                fmt = "jpg"
                format = C1.Xaml.Chart.ImageFormat.Jpeg
                Exit Select
            Case "SVG"
                fmt = "svg"
                format = C1.Xaml.Chart.ImageFormat.Svg
                Exit Select
            Case Else
                fmt = "png"
                format = C1.Xaml.Chart.ImageFormat.Png
                Exit Select
        End Select
        Dim picker = New FileSavePicker()

        picker.FileTypeChoices.Add(fmt.ToString().ToUpper(), New List(Of String)() From {
        "." + fmt.ToString().ToLower()
    })

        Dim file As StorageFile = Await picker.PickSaveFileAsync()
        If file IsNot Nothing Then
            Dim stream As Stream = New MemoryStream()
            Dim extension = file.FileType.Substring(1, file.FileType.Length - 1)
            _viewModel.MainChart.SaveImage(stream, format)
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