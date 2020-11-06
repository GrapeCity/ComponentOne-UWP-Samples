Imports System.ComponentModel.DataAnnotations
Imports System.Threading.Tasks
Imports Windows.Storage
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Reflection
Imports System.IO
Imports System
Imports Windows.Storage.Streams

Public Class NorthwindData
    <Display(Name:="CustomerID")>
    Public Property CustomerID() As String

    <Display(Name:="CompanyName")>
    Public Property CompanyName() As String

    <Display(Name:="ContactName")>
    Public Property ContactName() As String

    <Display(Name:="ContactTitle")>
    Public Property ContactTitle() As String

    <Display(Name:="Address")>
    Public Property Address() As String

    <Display(Name:="City")>
    Public Property City() As String

    <Display(Name:="PostalCode")>
    Public Property PostalCode() As String

    <Display(Name:="Country")>
    Public Property Country() As String

    <Display(Name:="Phone")>
    Public Property Phone() As String

    <Display(Name:="Fax")>
    Public Property Fax() As String
End Class

Public Class NorthwindStorage
    Public Shared Async Function Load() As Task(Of List(Of NorthwindData))
        Try
            Dim resourceUri As Uri
            If GetType(NorthwindStorage).GetTypeInfo().[Module].Name.EndsWith("exe") OrElse Windows.ApplicationModel.DesignMode.DesignModeEnabled Then
                resourceUri = New Uri("ms-appx:///Resources/Northwind.xml")
            Else
                resourceUri = New Uri("ms-appx:///FlexGridSamplesLib/Resources/Northwind.xml")
            End If
            Dim file As StorageFile = Await StorageFile.GetFileFromApplicationUriAsync(resourceUri)
            Dim fileStream As IRandomAccessStream = Await file.OpenAsync(FileAccessMode.Read)
            Dim xmls As New XmlSerializer(GetType(List(Of NorthwindData)))
            Return CType(xmls.Deserialize(fileStream.AsStream()), List(Of NorthwindData))
        Catch e As Exception
            Throw New Exception(Strings.FileNotFoundException)
        End Try
    End Function
End Class