Imports C1.Xaml.Maps
Imports System.Collections.Generic
Imports Windows.UI.Xaml.Controls
Imports System.Xml.Serialization
Imports Windows.Foundation
Imports System.Reflection
Imports Windows.UI.Xaml
Imports System.IO
Imports System

Partial Public NotInheritable Class Factories
    Inherits Page
    Const minStoreZoom As Double = 10.5
    Private dataBase As DataBase

    Public Sub New()
        Me.InitializeComponent()
        LoadDataBase()
        InitializeMapLayers()
    End Sub

    Sub LoadDataBase()
        Using stream As Stream = GetType(Factories).GetTypeInfo().Assembly.GetManifestResourceStream("MapsSamples.database.xml")
            If stream IsNot Nothing Then
                Dim serializer As New XmlSerializer(GetType(DataBase))
                dataBase = CType(serializer.Deserialize(stream), DataBase)
            Else
                dataBase = New DataBase()
            End If
        End Using
    End Sub

    Sub InitializeMapLayers()
        Maps.Layers.Add(New C1MapItemsLayer() With {
            .ItemsSource = dataBase.Factories,
            .ItemTemplate = CType(Resources("factoryTemplate"), DataTemplate)
        })

        Maps.Layers.Add(New C1MapItemsLayer() With {
            .ItemsSource = dataBase.Offices,
            .ItemTemplate = CType(Resources("officeTemplate"), DataTemplate)
        })

        Dim storeSlices As Integer = CType(Math.Pow(2, minStoreZoom), Integer)
        Dim virtualLayer As C1MapVirtualLayer = New C1MapVirtualLayer() With {
            .MapItemsSource = New LocalStroeSource(dataBase),
            .ItemTemplate = CType(Resources("storeTemplate"), DataTemplate)
            }
        virtualLayer.Slices.Add(New MapSlice(1, 1, 0))
        virtualLayer.Slices.Add(New MapSlice(storeSlices, storeSlices, minStoreZoom))
        maps.Layers.Add(virtualLayer)
    End Sub

    Public Class LocalStroeSource
        Implements IMapVirtualSource
        Private _dataBase As DataBase

        Public Sub New(localDataBase As DataBase)
            _dataBase = localDataBase
        End Sub


        Public Sub Request(minZoom As Double, maxZoom As Double, lowerLeft As Point, upperRight As Point, callback As Action(Of ICollection)) Implements IMapVirtualSource.Request
            If minZoom < minStoreZoom Then
                Return
            End If

            Dim stores As New List(Of Store)()

            For Each store As Store In _dataBase.Stores
                If store.Latitude > lowerLeft.Y AndAlso store.Longitude > lowerLeft.X AndAlso store.Latitude <= upperRight.Y AndAlso store.Longitude <= upperRight.X Then
                    stores.Add(store)
                End If
            Next

            callback(stores)
        End Sub
    End Class
End Class

Public Class Entity
    Public Property Name() As String
    Public Property Latitude() As Double
    Public Property Longitude() As Double
    Public ReadOnly Property Position() As Point
        Get
            Return New Point(Longitude, Latitude)
        End Get
    End Property
End Class

Public Class Office
    Inherits Entity
    Public Property Manager() As String
    Public Property Stores() As Integer
End Class

Public Class Factory
    Inherits Entity
    Public Property Capacity() As Double
End Class

Public Class Product
    Public Property Name() As String
End Class
Public Class ProductSale
    Public Property Product() As Product
    Public Property Sales() As Integer
End Class
Public Class Store
    Inherits Entity
    Public Property Sales() As List(Of ProductSale)
End Class

Public Class DataBase
    Public Property Factories() As List(Of Factory)
    Public Property Offices() As List(Of Office)
    Public Property Stores() As List(Of Store)
    Public Property OfficeStoreDistance() As Double

    Public Sub New()
        Factories = New List(Of Factory)()
        Offices = New List(Of Office)()
        Stores = New List(Of Store)()
        OfficeStoreDistance = 100000
    End Sub

End Class