Imports System.ComponentModel.DataAnnotations
Imports System.Threading.Tasks
Imports Windows.Storage
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Reflection
Imports System.IO
Imports System
Imports Windows.Storage.Streams

Public Class Song
    <Display(Name:="Name")>
    Public Property Name() As String

    <Display(Name:="Album")>
    Public Property Album() As String

    <Display(Name:="Artist")>
    Public Property Artist() As String

    <Display(Name:="Duration")>
    Public Property Duration() As Long
    ' in milliseconds
    <Display(Name:="Size")>
    Public Property Size() As Long
    ' in bytes
    <Display(Name:="Rating")>
    Public Property Rating() As Integer
    ' from 0 to 5
End Class

Public Class MediaLibraryStorage
    Public Shared Async Function Load() As Task(Of List(Of Song))
        Try
            Dim resourceUri As Uri
            If GetType(MediaLibraryStorage).GetTypeInfo().[Module].Name.EndsWith("exe") OrElse Windows.ApplicationModel.DesignMode.DesignModeEnabled Then
                resourceUri = New Uri("ms-appx:///Resources/songs.xml")
            Else
                resourceUri = New Uri("ms-appx:///FlexGridSamplesLib/Resources/songs.xml")
            End If
            Dim file As StorageFile = Await StorageFile.GetFileFromApplicationUriAsync(resourceUri)
            Dim fileStream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.Read)
            Dim xmls As New XmlSerializer(GetType(List(Of Song)))
            Return CType(xmls.Deserialize(fileStream.AsStream()), List(Of Song))
        Catch
            Throw New Exception(Strings.FileNotFoundException)
        End Try
    End Function
End Class