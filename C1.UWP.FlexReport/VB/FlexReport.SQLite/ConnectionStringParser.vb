Imports System.Text

Public Class ConnectionStringParser

    Private _keys As New List(Of String)
    Private _values As New List(Of String)

#Region "Public Static"

    Public Shared Function Parse(ByVal connectionString As String) As ConnectionStringParser

        If String.IsNullOrWhiteSpace(connectionString) Then
            Return Nothing
        End If

        Dim subStrings As String() = connectionString.Split(";"c)

        Dim res As New ConnectionStringParser
        For Each s In subStrings
            If s.Trim().Length = 0 Then
                Continue For
            End If

            Dim i As Int32 = s.IndexOf("="c)
            If i <= 0 Then
                Return Nothing
            End If

            res._keys.Add(s.Substring(0, i).Trim())
            res._values.Add(s.Substring(i + 1))
        Next

        Return res
    End Function


#End Region

#Region "Public"

    ''' <summary>
    ''' Returns location of data used by connection string. For example, for string Like
    ''' Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AdventureWorks2008R2;Data Source=localhost
    ''' This method returns
    ''' localhost\\AdventureWorks2008R2
    ''' </summary>
    Public Function GetDataLocation() As String

        Dim dataSource As String = Me("data source")
        If String.IsNullOrEmpty(dataSource) Then
            dataSource = Me("dsn")
        End If
        Dim path As String = Me("Initial Catalog")
        If String.IsNullOrEmpty(path) Then
            path = Me("Initial File Name")
        End If
        If String.IsNullOrEmpty(path) Then
            path = Me("dbq")
        End If
        If String.IsNullOrEmpty(dataSource) Then
            Return path
        ElseIf String.IsNullOrEmpty(path) Then
            Return dataSource
        Else
            Return dataSource + "\\" + path
        End If

    End Function

    Public Overrides Function ToString() As String
        Dim res As New StringBuilder()
        For i As Int32 = 0 To _keys.Count - 1
            If Not String.IsNullOrEmpty(_values(i)) Then
                res.Append(String.Format("{0}={1};", _keys(i), _values(i)))
            End If
        Next
        If res.Length > 0 Then
            res.Remove(res.Length - 1, 1)
        End If
        Return res.ToString()
    End Function

#End Region

#Region "Public properties"

    Public ReadOnly Property Count As Int32
        Get
            Return _keys.Count
        End Get
    End Property

    Public ReadOnly Property Key As List(Of String)
        Get
            Return _keys
        End Get
    End Property

    Public ReadOnly Property Values As List(Of String)
        Get
            Return _values
        End Get
    End Property

    Default Public Property Item(ByVal key As String) As String
        Get
            For i As Int32 = 0 To _keys.Count - 1
                If String.Compare(_keys(i), key, True) = 0 Then
                    Return _values(i)
                End If
            Next
            Return Nothing
        End Get
        Set(ByVal value As String)
            For i As Int32 = 0 To _keys.Count - 1
                If String.Compare(_keys(i), key, True) = 0 Then
                    If value Is Nothing Then
                        _keys.RemoveAt(i)
                        _values.RemoveAt(i)
                    Else
                        _values(i) = value
                    End If
                    Return
                End If
            Next
            _keys.Add(key)
            _values.Add(value)
        End Set
    End Property

#End Region

End Class
