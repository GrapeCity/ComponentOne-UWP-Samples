Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.Collections
Imports System

''' <summary>
''' Our hierarchical data item: A Person has Subordinates of type Person.
''' </summary>
Public Class Person
    Private _list As New ObservableCollection(Of Person)()

#Region "** object model"

    Public Property Name() As String
    Public Property Position() As String
    Public Property Notes() As String
    Public ReadOnly Property Subordinates() As IList(Of Person)
        Get
            Return _list
        End Get
    End Property
    Public ReadOnly Property TotalCount() As Integer
        Get
            Dim count As Integer = 1
            For Each p As Person In Subordinates
                count += p.TotalCount
            Next
            Return count
        End Get
    End Property
    Public Overrides Function ToString() As String
        Return String.Format("{0}:" & vbCr & vbLf & vbTab & "{1}", Name, Position)
    End Function

#End Region

#Region "** Person factory"

    Shared _rnd As New Random()
    Shared _positions As String() = (Strings.Director + "|" + Strings.Manager + "|" + Strings.Designer + "|" + Strings.StringPositions).Split("|"c)
    Shared _areas As String() = Strings.StringAreas.Split("|"c)
    Shared _first As String() = Strings.StringFirstName.Split("|"c)
    Shared _last As String() = Strings.StringLastName.Split("|"c)
    Shared _verb As String() = Strings.StringVerb.Split("|"c)
    Shared _adjective As String() = Strings.StringAdjective.Split("|"c)
    Shared _noun As String() = Strings.StringNoun.Split("|"c)

    Public Shared Function CreatePerson(level As Integer) As Person
        Dim p As Person = CreatePerson()
        If level > 0 Then
            level -= 1
            If Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
                Dim i As Integer = 0
                While i < _rnd.Next(3, 3)
                    Dim halfLevel As Double = level / 2
                    p.Subordinates.Add(CreatePerson(_rnd.Next(CInt(level / 2), level)))
                    i += 1
                End While
            Else
                Dim i As Integer = 0
                While i < _rnd.Next(1, 4)
                    p.Subordinates.Add(CreatePerson(_rnd.Next(CInt(level / 2), level)))
                    i += 1
                End While

            End If
        End If
        Return p
    End Function
    Public Shared Function CreatePerson() As Person
        Dim p As Person = New Person()
        If Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons") Then
            p.Position = String.Format("{0}", GetItem(_positions))
        Else
            p.Position = String.Format(Strings.StringFormatTwoArg, GetItem(_positions), GetItem(_areas))
        End If
        p.Name = String.Format("{0} {1}", GetItem(_first), GetItem(_last))
        p.Notes = String.Format("{0} {1} {2} {3}", p.Name, GetItem(_verb), GetItem(_adjective), GetItem(_noun))
        While _rnd.NextDouble() < 0.5
            p.Notes += String.Format(Strings.StringFormatThreeArg, GetItem(_verb), GetItem(_adjective), GetItem(_noun))
        End While
        p.Notes += "."
        Return p
    End Function
    Shared Function GetItem(list As String()) As String
        Return list(_rnd.[Next](0, list.Length))
    End Function

#End Region
End Class