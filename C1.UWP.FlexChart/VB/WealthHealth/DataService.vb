Imports System.Runtime.Serialization.Json
Imports System.Collections.Generic
Imports System.Reflection
Imports System

Public Class DataService
    Private _countries As List(Of Country)
    Private _compare As New CountryCompare()

    Public Function CreateData() As List(Of Country)
        If _countries Is Nothing Then
            Dim path As String = String.Format("WealthHealth.{0}.json", "nations")
            Dim asm As Assembly = Me.[GetType]().GetTypeInfo().Assembly
            Using stream As Object = asm.GetManifestResourceStream(path)
                Dim ser As New DataContractJsonSerializer(GetType(List(Of Country)))
                _countries = CType(ser.ReadObject(stream), List(Of Country))
            End Using
        End If
        Dim i As Object = _countries.Count - 1
        While i >= 0
            Dim country As Object = _countries(i)
            If country.Population.Count <= 1 OrElse country.Income.Count <= 1 OrElse country.LifeExpectancy.Count <= 1 Then
                _countries.Remove(country)
            End If
            i -= 1
        End While
        _countries.Sort(0, _countries.Count, _compare)
        Return _countries
    End Function

    Public Function UpdateData(year As Double) As List(Of Country)
        Dim newCountries As New List(Of Country)()
        _countries.ForEach(Function(country)
                               country.YearIncome = Interpolate(country.Income, year)
                               country.YearLifeExpectancy = Interpolate(country.LifeExpectancy, year)
                               Dim pop As Object = Interpolate(country.Population, year)
                               If pop > 1000000 Then
                                   pop = Math.Round(pop / 1000000) * 1000000
                               End If
                               country.YearPopulation = pop
                               newCountries.Add(country)

                           End Function)
        newCountries.Sort(0, newCountries.Count, _compare)
        _countries = newCountries

        Return newCountries
    End Function

    Public Function Interpolate(list As List(Of Object), year As Double) As Double
        Dim min As Integer = 0, max As Integer = list.Count - 1, cur As Integer
        While min <= max
            cur = (min + max) >> 1
            Dim item As Object() = CType(list(cur), Object())
            If ToDouble(item(0)) > year Then
                max = cur - 1
            ElseIf ToDouble(item(0)) < year Then
                min = cur + 1
            Else
                Return ToDouble(item(1))
            End If
        End While

        If min = 0 Then
            Return ToDouble((CType(list(min), Object()))(1))
        End If
        If min = list.Count Then
            Return ToDouble((CType(list(max), Object()))(1))
        End If

        Dim pct As Object = (year - ToDouble((CType(list(max), Object()))(0))) / (ToDouble((CType(list(min), Object()))(0)) - ToDouble((CType(list(max), Object()))(0)))
        Return ToDouble((CType(list(max), Object()))(1)) + pct * (ToDouble((CType(list(min), Object()))(1)) - ToDouble((CType(list(max), Object()))(1)))
    End Function

    Private Function ToDouble(obj As Object) As Double
        Return Double.Parse(obj.ToString())
    End Function
End Class

Public Class CountryCompare
    Implements IComparer(Of Country)
    Public Function Compare(x As Country, y As Country) As Integer Implements IComparer(Of Country).Compare
        If x.YearPopulation > y.YearPopulation Then
            Return -1
        ElseIf x.YearPopulation = y.YearPopulation Then
            Return 0
        Else
            Return 1
        End If
    End Function
End Class