Imports System.Runtime.Serialization
Imports System.ComponentModel
Imports System.Collections.Generic

<DataContract>
Public Class Country
    Private _yearIncome As Double
    Private _yearLifeExpectancy As Double
    Private _yearPopulation As Double

    <DataMember(Name:="name")>
    Public Property Name() As String
    <DataMember(Name:="region")>
    Public Property Region() As String
    <DataMember(Name:="income")>
    Public Property Income() As List(Of Object)
    <DataMember(Name:="population")>
    Public Property Population() As List(Of Object)
    <DataMember(Name:="lifeExpectancy")>
    Public Property LifeExpectancy() As List(Of Object)

    Public Property YearIncome() As Double
        Get
            Return _yearIncome
        End Get
        Set
            If _yearIncome <> Value Then
                _yearIncome = Value
            End If
        End Set
    End Property
    Public Property YearLifeExpectancy() As Double
        Get
            Return _yearLifeExpectancy
        End Get
        Set
            If _yearLifeExpectancy <> Value Then
                _yearLifeExpectancy = Value
            End If
        End Set
    End Property

    Public Property YearPopulation() As Double
        Get
            Return _yearPopulation
        End Get
        Set
            If _yearPopulation <> Value Then
                _yearPopulation = Value
            End If
        End Set
    End Property
End Class

Public Class DataItem
    Public Property Year() As Double
    Public Property Value() As Double
End Class