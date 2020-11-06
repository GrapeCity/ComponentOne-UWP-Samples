Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Linq

Public Class DataService
    Private _companies As New List(Of Company)()
    Private _cache As New Dictionary(Of String, List(Of Quote))()

    Private Sub New()
        _companies.Add(New Company() With {
            .Symbol = "box",
            .Name = "Box Inc"
        })
        _companies.Add(New Company() With {
            .Symbol = "fb",
            .Name = "Facebook"
        })
    End Sub

    Public Function GetCompanies() As List(Of Company)
        Return _companies
    End Function

    Public Function GetData(Of T)(symbol As String) As List(Of T)
        Dim path As String = String.Format("FinancialChartExplorer.{0}.json", symbol)
        Dim asm As Assembly = Me.[GetType]().GetTypeInfo().Assembly
        Dim stream As Stream = asm.GetManifestResourceStream(path)
        Dim ser As New DataContractJsonSerializer(GetType(T()))
        Dim data As T() = CType(ser.ReadObject(stream), T())
        Return data.ToList()
    End Function


    Public Function GetSymbolData(symbol As String, Optional count As Integer = 20) As List(Of Quote)
        If Not _cache.Keys.Contains(symbol) Then
            Dim dataList As List(Of Quote) = GetData(Of Quote)(symbol)
            _cache.Add(symbol, dataList)
        End If
        If IsWindowsPhoneDevice() Then
            Dim dataList As List(Of Quote） = CType(_cache(symbol), List(Of Quote))
            Return dataList.Take(count).ToList()
        End If
        Return _cache(symbol)
    End Function

    Function IsWindowsPhoneDevice() As Boolean
        If Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            Return True
        End If
        Return False
    End Function

    Public Function FindRenderedYRange(data As List(Of Quote), xmin As Double, xmax As Double) As Range
        Dim item As Quote
        Dim ymin As Double = Double.NaN
        Dim ymax As Double = Double.NaN

        Dim i As Integer = 0
        While i < data.Count
            item = data(i)
            If xmin > i OrElse i > xmax Then
                i += 1
                Continue While
            End If
            If Double.IsNaN(ymax) OrElse item.High > ymax Then
                ymax = item.High
            End If
            If Double.IsNaN(ymin) OrElse item.Low < ymin Then
                ymin = item.Low
            End If
            i += 1
        End While

        Return New Range() With {
        .Min = ymin,
        .Max = ymax
    }
    End Function

    Public Function FindApproxRange(min As Double, max As Double, percent As Double) As Range
        Dim range As Range = New Range()
        range.Max = max
        range.Min = (max - min) * (1 - percent) + min
        Return range
    End Function

    Shared _ds As DataService
    Public Shared Function GetService() As DataService
        If _ds Is Nothing Then
            _ds = New DataService()
        End If
        Return _ds
    End Function
End Class

<DataContract>
Public Class Quote
    <DataMember(Name:="date")>
    Public Property [Date]() As String

    <DataMember(Name:="high")>
    Public Property High() As Double

    <DataMember(Name:="low")>
    Public Property Low() As Double

    <DataMember(Name:="open")>
    Public Property Open() As Double

    <DataMember(Name:="close")>
    Public Property Close() As Double

    <DataMember(Name:="volume")>
    Public Property Volume() As Double

    Public ReadOnly Property [Date2] As DateTime
        Get
            Return System.DateTime.ParseExact([Date].ToString, "MM/dd/yy", System.Globalization.CultureInfo.InvariantCulture)
        End Get
    End Property

End Class

<DataContract>
Public Class Annotation
    <DataMember(Name:="title")>
    Public Property Title() As String

    <DataMember(Name:="description")>
    Public Property Description() As String

    <DataMember(Name:="publicationDate")>
    Public Property PublicationDate() As String

    <DataMember(Name:="dataIndex")>
    Public Property DataIndex() As Integer
End Class

Public Class Range
    Public Property Min() As Double
    Public Property Max() As Double
End Class

Public Class Company
    Public Property Symbol() As String
    Public Property Name() As String
End Class