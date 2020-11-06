Imports System.Reflection
Imports System.Text
Imports Windows.Storage
Imports C1.Xaml.FlexReport
Imports SQLite

Public Class SQLiteLink
    Inherits DataLinkBase

    Private Shared NegativePointer As New IntPtr(-1)

#Region "Public"

    Private Shared Function IsNull(ByVal value As Object) As Boolean
        Return value Is Nothing OrElse TypeOf value Is DBNull
    End Function

    Private Function CheckQuery(ByVal command As DbCommand) As Boolean
        Dim stmt As SQLitePCL.sqlite3_stmt = Nothing
        Try
            stmt = SQLite3.Prepare2(command.Connection.Handle, command.CommandText)
            Return True
        Catch
            Return False
        Finally
            If stmt IsNot Nothing Then
                SQLite3.Finalize(stmt)
            End If
        End Try
    End Function

    Private Function CreateParameter(ByVal rp As ReportParameter, ByVal value As Object) As DbParameter
        Dim res As New DbParameter()
        res.Name = rp.Name
        res.Value = value
        Return res
    End Function

    Private Sub PrepareDbCommandProcessParameter(command As DbCommand, dlp As DataLinkParams, rp As ReportParameter, sb As StringBuilder, s As String, lastIdent As String, lastIdentEnd As Integer, curIndex As Integer)
        Dim addMultiValueBrackets As Boolean = False
        If String.Compare(lastIdent, "in", True) = 0 Then
            ' from lastIdentEnd to curIndex ( should be
            addMultiValueBrackets = s.IndexOf("("c, lastIdentEnd, curIndex - lastIdentEnd) = -1
            If addMultiValueBrackets Then
                ' need to add brackets
                If dlp.ParameterPassingMode = ParameterPassingMode.Literal AndAlso dlp.EncloseParameterValues Then
                    addMultiValueBrackets = False
                End If
            End If
        End If
        If addMultiValueBrackets Then
            sb.Append("("c)
        End If

        Select Case dlp.ParameterPassingMode
            Case ParameterPassingMode.Default
                If (IsNull(rp.Value)) Then
                    sb.Append("?")
                    command.Parameters.Add(CreateParameter(rp, System.DBNull.Value))
                Else
                    Dim arr As Array = TryCast(rp.Value, Array)
                    If arr Is Nothing Then
                        sb.Append("?")
                        command.Parameters.Add(CreateParameter(rp, rp.Value))
                    Else
                        If arr.Length = 0 Then
                            sb.Append("?")
                            command.Parameters.Add(CreateParameter(rp, System.DBNull.Value))
                        Else
                            For i As Int32 = 0 To arr.GetLength(0) - 1
                                Dim v As Object = arr.GetValue(i)
                                sb.Append("?")
                                If IsNull(v) Then
                                    command.Parameters.Add(CreateParameter(rp, System.DBNull.Value))
                                Else
                                    command.Parameters.Add(CreateParameter(rp, v))
                                End If
                                If i < arr.GetLength(0) - 1 Then
                                    sb.Append(c_MultiValueParamValueDelimiter)
                                End If
                            Next
                        End If
                    End If
                End If

            Case ParameterPassingMode.Literal
                Dim paramValue As String = ParameterValueToString(dlp, rp)
                sb.Append(paramValue)

            Case Else
                ' should never be here
                Throw New NotImplementedException()
        End Select

        If addMultiValueBrackets Then
            sb.Append(")"c)
        End If
    End Sub

    Private Sub PrepareDbCommand(command As DbCommand, dlp As DataLinkParams, recordSource As String)
        command.Parameters.Clear()
        If String.IsNullOrEmpty(recordSource) OrElse dlp.Parameters Is Nothing OrElse dlp.Parameters.Count <= 0 Then
            command.CommandText = recordSource
            Return
        End If

        Dim lastIdentEnd As Int32 = -1
        Dim lastIdent As String = String.Empty
        Dim s As String = recordSource
        Dim sb As New StringBuilder(s.Length)
        Dim i As Int32 = 0

        While (i < s.Length)
            If s(i) = c_IdentOpenBracket Then
                Dim j As Int32 = i
                While i < s.Length AndAlso s(i) <> c_IdentCloseBracket
                    i += 1
                End While
                If i >= s.Length Then
                    sb.Append(s, j, i - j)
                Else
                    Dim rp As ReportParameter = CType(dlp.Parameters.FindByName(s.Substring(j + 1, i - j - 1)), ReportParameter)
                    If rp Is Nothing Then
                        sb.Append(s, j, i - j + 1)
                    Else
                        PrepareDbCommandProcessParameter(command, dlp, rp, sb, s, lastIdent, lastIdentEnd, j)
                    End If
                    i += 1
                End If
            ElseIf StringParser.IsIdentStartChar(s(i)) Then
                Dim j As Int32 = i
                While i < s.Length AndAlso StringParser.IsIdentChar(s(i))
                    i += 1
                End While
                Dim rp As ReportParameter = CType(dlp.Parameters.FindByName(s.Substring(j, i - j)), ReportParameter)
                If rp Is Nothing Then

                    lastIdent = s.Substring(j, i - j)
                    lastIdentEnd = i
                    sb.Append(s, j, i - j)
                Else
                    PrepareDbCommandProcessParameter(command, dlp, rp, sb, s, lastIdent, lastIdentEnd, j)
                End If
            Else
                sb.Append(s(i))
                i += 1
            End If
        End While

        command.CommandText = sb.ToString()
    End Sub

    Private Function CreateConnection(dlp As DataLinkParams) As SQLiteConnection
        Dim csp As ConnectionStringParser = ConnectionStringParser.Parse(dlp.ConnectionString)
        If csp Is Nothing Then
            Return Nothing
        End If
        Dim dataBasePath As String = csp.GetDataLocation()
        If String.IsNullOrEmpty(dataBasePath) Then
            Return Nothing
        End If
        Dim basePath As StorageFolder = C1FlexReport.GetActualBasePath(dlp.Report)
        Dim dataBaseFile As StorageFile = FileNameParser.ReplaceSpecialFolderTags(dataBasePath, basePath)
        If dataBaseFile Is Nothing Then
            Return Nothing
        End If
        Try
            Return New SQLiteConnection(dataBaseFile.Path, SQLiteOpenFlags.ReadOnly)
        Catch
            Return Nothing
        End Try
    End Function

    Private Function CreateCommand(dlp As DataLinkParams) As DbCommand
        Dim connection As SQLiteConnection = CreateConnection(dlp)
        If connection Is Nothing Then
            Return Nothing
        End If
        Try
            ' initialize SQLiteCommand
            Dim command As DbCommand
            Select Case dlp.RecordSourceType
                Case RecordSourceType.TableDirect
                    command = New DbCommand(connection)
                    command.CommandText = "select * from " + dlp.RecordSource
                    Return command
                Case RecordSourceType.Text
                    command = New DbCommand(connection)
                    PrepareDbCommand(command, dlp, dlp.RecordSource)
                    Return command
            End Select

            ' auto command type
            command = New DbCommand(connection)
            PrepareDbCommand(command, dlp, dlp.RecordSource)
            If CheckQuery(command) Then
                Return command
            End If

            PrepareDbCommand(command, dlp, "select * from " + dlp.RecordSource)
            Return command
        Catch
            If connection IsNot Nothing Then
                connection.Dispose()
            End If
            Return Nothing
        End Try
    End Function

    Private Function SQLiteColumnTypeToType(colType As SQLite3.ColType) As Type
        Select Case colType
            Case SQLite3.ColType.Blob
                Return GetType(Byte())
            Case SQLite3.ColType.Float
                Return GetType(Double)
            Case SQLite3.ColType.Integer
                Return GetType(Int32)
            Case SQLite3.ColType.Null
                Return GetType(String)
        End Select
        Return GetType(String)
    End Function

    Private Function CheckName(names As String(), len As Int32, name As String) As String
        Dim i As Int32 = 0
        Dim suffix As Int32 = 0
        Dim res As String = name
        While i < len
            If String.Compare(names(i), res, StringComparison.OrdinalIgnoreCase) = 0 Then
                suffix += 1
                res = name + suffix.ToString()
                i = 0
            Else
                i += 1
            End If
        End While
        Return res
    End Function

    Private Sub GetColumns(stmt As SQLitePCL.sqlite3_stmt, ByRef names As String(), ByRef types As Type())
        Dim columnCount As Int32 = SQLite3.ColumnCount(stmt)
        types = New Type(columnCount - 1) {}
        names = New String(columnCount - 1) {}
        For i As Int32 = 0 To columnCount - 1
            names(i) = CheckName(names, i, SQLite3.ColumnName(stmt, i))
            types(i) = SQLiteColumnTypeToType(SQLite3.ColumnType(stmt, i))
        Next
    End Sub

#End Region

#Region "Protected"

    Protected Overrides Sub GetDataSourceInfo(dlp As DataLinkParams, dsi As DataSourceInfo)
        Dim command As DbCommand = CreateCommand(dlp)
        If command Is Nothing Then
            Return
        End If
        Using command
            Try
                Using stmt As SQLitePCL.sqlite3_stmt = SQLite3.Prepare2(command.Connection.Handle, command.CommandText)
                    Dim names As String() = Nothing
                    Dim types As Type() = Nothing
                    GetColumns(stmt, names, types)
                    For i As Int32 = 0 To names.Length - 1
                        Dim fi As C1.Xaml.FlexReport.FieldInfo = New C1.Xaml.FlexReport.FieldInfo(names(i), types(i))
                        dsi.Fields.Add(fi)
                        If IsImageField(fi.DataType) Then
                            dsi.ImageFields.Add(fi)
                        Else
                            dsi.TextFields.Add(fi)
                        End If
                    Next
                End Using
            Catch
            End Try
        End Using
    End Sub

    Friend Shared Sub BindParameter(stmt As SQLitePCL.sqlite3_stmt, index As Int32, value As Object, storeDateTimeAsTicks As Boolean)
        If value Is Nothing Then
            SQLite3.BindNull(stmt, index)
        Else
            If TypeOf value Is Int32 Then
                SQLite3.BindInt(stmt, index, CType(value, Int32))
            ElseIf TypeOf value Is String Then
                SQLite3.BindText(stmt, index, CType(value, String), -1, NegativePointer)
            ElseIf TypeOf value Is Byte OrElse TypeOf value Is UInt16 OrElse TypeOf value Is SByte OrElse TypeOf value Is Int16 Then
                SQLite3.BindInt(stmt, index, Convert.ToInt32(value))
            ElseIf TypeOf value Is Boolean Then
                SQLite3.BindInt(stmt, index, If(CType(value, Boolean), 1, 0))
            ElseIf TypeOf value Is UInt32 OrElse TypeOf value Is Int64 Then
                SQLite3.BindInt64(stmt, index, Convert.ToInt64(value))
            ElseIf TypeOf value Is Single OrElse TypeOf value Is Double OrElse TypeOf value Is Decimal Then
                SQLite3.BindDouble(stmt, index, Convert.ToDouble(value))
            ElseIf TypeOf value Is TimeSpan Then
                SQLite3.BindInt64(stmt, index, (CType(value, TimeSpan)).Ticks)
            ElseIf TypeOf value Is DateTime Then
                If storeDateTimeAsTicks Then
                    SQLite3.BindInt64(stmt, index, (CType(value, DateTime)).Ticks)
                Else
                    SQLite3.BindText(stmt, index, (CType(value, DateTime)).ToString("yyyy-MM-dd HH:mm:ss"), -1, NegativePointer)
                End If
            ElseIf TypeOf value Is DateTimeOffset Then
                SQLite3.BindInt64(stmt, index, (CType(value, DateTimeOffset)).UtcTicks)
            ElseIf value.GetType().GetTypeInfo().IsEnum Then
                SQLite3.BindInt(stmt, index, Convert.ToInt32(value))
            ElseIf TypeOf value Is Byte() Then
                SQLite3.BindBlob(stmt, index, CType(value, Byte()), (CType(value, Byte())).Length, NegativePointer)
            ElseIf TypeOf value Is Guid Then
                SQLite3.BindText(stmt, index, (CType(value, Guid)).ToString(), 72, NegativePointer)
            Else
                Throw New NotSupportedException("Cannot store type: " + value.GetType().ToString())
            End If
        End If
    End Sub

    Private Function ReadCol(stmt As SQLitePCL.sqlite3_stmt, index As Int32, type As SQLite3.ColType) As Object
        Select Case type
            Case SQLite3.ColType.Blob
                Return SQLite3.ColumnByteArray(stmt, index)
            Case SQLite3.ColType.Float
                Return SQLite3.ColumnDouble(stmt, index)
            Case SQLite3.ColType.Integer
                Return SQLite3.ColumnInt64(stmt, index)
            Case SQLite3.ColType.Null
                Return Nothing
            Case SQLite3.ColType.Text
                Return SQLite3.ColumnString(stmt, index)
        End Select
        Return Nothing
    End Function

    Private Sub BindParameters(stmt As SQLitePCL.sqlite3_stmt, command As DbCommand)
        For i As Int32 = 0 To command.Parameters.Count - 1
            BindParameter(stmt, i + 1, command.Parameters(0).Value, command.Connection.StoreDateTimeAsTicks)
        Next
    End Sub

#End Region

#Region "Public"

    Public Overrides Function Validate(dlp As DataLinkParams) As Boolean
        Dim connection As SQLiteConnection = CreateConnection(dlp)
        If connection Is Nothing Then
            Return False
        End If
        connection.Dispose()
        Return True
    End Function

    Public Overrides Function GetDataObject(dlp As DataLinkParams) As Object
        Dim command As DbCommand = CreateCommand(dlp)
        If command Is Nothing Then
            Return Nothing
        End If
        Using command
            Try
                Dim stmt = SQLite3.Prepare2(command.Connection.Handle, command.CommandText)
                Using stmt
                    ' setup parameters
                    BindParameters(stmt, command)

                    ' build Recordset object
                    Dim res As New Recordset()

                    ' create columns
                    GetColumns(stmt, res.Names, res.Types)
                    For i As Int32 = 0 To res.Names.Length - 1
                        res.AddColumn()
                    Next

                    ' fill recordset
                    Dim values As Object() = New Object(res.Names.Length - 1) {}
                    While SQLite3.Step(stmt) = SQLite3.Result.Row
                        For i As Int32 = 0 To res.Names.Length - 1
                            values(i) = ReadCol(stmt, i, SQLite3.ColumnType(stmt, i))
                        Next
                        res.Add(values)
                    End While

                    Return res
                End Using
            Catch
                Return Nothing
            End Try
        End Using
    End Function

#End Region

#Region "Public properties"

    Public Overrides ReadOnly Property Available As Boolean
        Get
            Return True
        End Get
    End Property

#End Region

#Region "Nested types"

    Private Class Recordset
        Implements IC1FlexReportRecordset

        Private ReadOnly _data As New List(Of List(Of Object))()
        Public Types As System.Type()
        Public Names As String()
        Private _count As Int32
        Private _position As Int32

        Public Sub AddColumn()
            _data.Add(New List(Of Object)())
        End Sub

        Public Sub Add(ByVal values As Object())
            For i As Int32 = 0 To values.Length - 1
                _data(i).Add(values(i))
            Next
            _count += 1
        End Sub

        Public ReadOnly Property Count As Integer Implements IC1FlexReportRecordset.Count
            Get
                Return _count
            End Get
        End Property

        Public Sub MoveFirst() Implements IC1FlexReportRecordset.MoveFirst
            _position = 0
        End Sub

        Public Sub MoveLast() Implements IC1FlexReportRecordset.MoveLast
            _position = Count - 1
        End Sub

        Public Sub MoveNext() Implements IC1FlexReportRecordset.MoveNext
            If _position < Count Then
                _position += 1
            End If
        End Sub

        Public Sub MovePrevious() Implements IC1FlexReportRecordset.MovePrevious
            If _position > 0 Then
                _position -= 1
            End If
        End Sub

        Public Sub SetBookmark(bookmark As Integer) Implements IC1FlexReportRecordset.SetBookmark
            _position = bookmark
        End Sub

        Public Function BOF() As Boolean Implements IC1FlexReportRecordset.BOF
            Return _position = 0
        End Function

        Public Function EOF() As Boolean Implements IC1FlexReportRecordset.EOF
            Return _position >= Count
        End Function

        Public Function GetBookmark() As Integer Implements IC1FlexReportRecordset.GetBookmark
            Return _position
        End Function

        Public Function GetFieldNames() As String() Implements IC1FlexReportRecordset.GetFieldNames
            Return Names
        End Function

        Public Function GetFieldTypes() As Type() Implements IC1FlexReportRecordset.GetFieldTypes
            Return Types
        End Function

        Public Function GetFieldValue(fieldIndex As Integer) As Object Implements IC1FlexReportRecordset.GetFieldValue
            If _position >= 0 AndAlso _position < _count Then
                Return _data(fieldIndex)(_position)
            End If
            Return Nothing
        End Function
    End Class

    Private Class DbParameter
        Public Name As String
        Public Value As Object
    End Class

    Private Class DbCommand
        Implements IDisposable

        Private _connection As SQLiteConnection
        Public CommandText As String
        Public ReadOnly Parameters As New List(Of DbParameter)()

        Public Sub New(ByVal connection As SQLiteConnection)
            _connection = connection
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            If _connection IsNot Nothing Then
                _connection.Dispose()
                _connection = Nothing
            End If
        End Sub

        Public ReadOnly Property Connection As SQLiteConnection
            Get
                Return _connection
            End Get
        End Property

    End Class

#End Region

End Class
