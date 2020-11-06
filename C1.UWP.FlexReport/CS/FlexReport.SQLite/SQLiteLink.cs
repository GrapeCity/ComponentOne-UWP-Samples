using System;
using System.Reflection;
using System.Text;
using System.IO;
using Windows.Storage;
using System.Collections.Generic;
using C1.Xaml.FlexReport;
using C1.Xaml.FlexReport.Util;
using SQLite;

namespace FlexReport.SQLite
{
    public class SQLiteLink : DataLinkBase
    {
        private static IntPtr NegativePointer = new IntPtr(-1);

        #region Private
        private static bool IsNull(object value)
        {
            return value == null || value is System.DBNull;
        }

        private bool CheckQuery(DbCommand command)
        {
            SQLitePCL.sqlite3_stmt stmt = null;
            try
            {
                stmt = SQLite3.Prepare2(command.Connection.Handle, command.CommandText);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (stmt != null)
                    SQLite3.Finalize(stmt);
            }
        }

        private DbParameter CreateParameter(ReportParameter rp, object value)
        {
            DbParameter result = new DbParameter();
            result.Name = rp.Name;
            result.Value = value;
            return result;
        }

        private void PrepareDbCommandProcessParameter(DbCommand command, DataLinkParams dlp, ReportParameter rp, StringBuilder sb, string s, string lastIdent, int lastIdentEnd, int curIndex)
        {
            bool addMultiValueBrackets = false;
            if (string.Compare(lastIdent, "in", true) == 0)
            {
                // from lastIdentEnd to curIndex ( should be
                addMultiValueBrackets = s.IndexOf('(', lastIdentEnd, curIndex - lastIdentEnd) == -1;
                if (addMultiValueBrackets)
                {
                    // need to add brackets
                    if (dlp.ParameterPassingMode == ParameterPassingMode.Literal && dlp.EncloseParameterValues)
                        addMultiValueBrackets = false;
                }
            }
            if (addMultiValueBrackets)
                sb.Append("(");

            switch (dlp.ParameterPassingMode)
            {
                case ParameterPassingMode.Default:
                    if (IsNull(rp.Value))
                    {
                        sb.Append("?");
                        command.Parameters.Add(CreateParameter(rp, System.DBNull.Value));
                    }
                    else
                    {
                        Array array = rp.Value as Array;
                        if (array == null)
                        {
                            sb.Append("?");
                            command.Parameters.Add(CreateParameter(rp, rp.Value));
                        }
                        else
                        {
                            if (array.Length == 0)
                            {
                                sb.Append("?");
                                command.Parameters.Add(CreateParameter(rp, System.DBNull.Value));
                            }
                            else
                            {
                                for (int i = 0; i < array.GetLength(0); i++)
                                {
                                    object v = array.GetValue(i);
                                    sb.Append("?");
                                    if (IsNull(v))
                                        command.Parameters.Add(CreateParameter(rp, System.DBNull.Value));
                                    else
                                        command.Parameters.Add(CreateParameter(rp, v));
                                    if (i < array.GetLength(0) - 1)
                                        sb.Append(c_MultiValueParamValueDelimiter);
                                }
                            }
                        }
                    }
                    break;
                case ParameterPassingMode.Literal:
                    string paramValue = ParameterValueToString(dlp, rp);
                    sb.Append(paramValue);
                    break;
                default:
                    // should never be here
                    throw new NotImplementedException();
            }
            if (addMultiValueBrackets)
                sb.Append(")");
        }

        private void PrepareDbCommand(
            DbCommand command,
            DataLinkParams dlp,
            string recordSource)
        {
            command.Parameters.Clear();
            if (string.IsNullOrEmpty(recordSource) || dlp.Parameters == null || dlp.Parameters.Count <= 0)
            {
                command.CommandText = recordSource;
                return;
            }

            int lastIdentEnd = -1;
            string lastIdent = string.Empty;
            string s = recordSource;
            StringBuilder sb = new StringBuilder(s.Length);
            int i = 0;
            while (i < s.Length)
            {
                if (s[i] == c_IdentOpenBracket)
                {
                    int j = i;
                    while (i < s.Length && s[i] != c_IdentCloseBracket)
                        i++;
                    if (i >= s.Length)
                        sb.Append(s, j, i - j);
                    else
                    {
                        ReportParameter rp = (ReportParameter)dlp.Parameters.FindByName(s.Substring(j + 1, i - j - 1));
                        if (rp == null)
                            sb.Append(s, j, i - j + 1);
                        else
                            PrepareDbCommandProcessParameter(command, dlp, rp, sb, s, lastIdent, lastIdentEnd, j);
                        i++;
                    }
                }
                else if (StringParser.IsIdentStartChar(s[i]))
                {
                    int j = i;
                    while (i < s.Length && StringParser.IsIdentChar(s[i]))
                        i++;
                    ReportParameter rp = (ReportParameter)dlp.Parameters.FindByName(s.Substring(j, i - j));
                    if (rp == null)
                    {
                        lastIdent = s.Substring(j, i - j);
                        lastIdentEnd = i;
                        sb.Append(s, j, i - j);
                    }
                    else
                        PrepareDbCommandProcessParameter(command, dlp, rp, sb, s, lastIdent, lastIdentEnd, j);
                }
                else
                {
                    sb.Append(s[i]);
                    i++;
                }
            }

            command.CommandText = sb.ToString();
        }

        private SQLiteConnection CreateConnection(DataLinkParams dlp)
        {
            ConnectionStringParser csp = ConnectionStringParser.Parse(dlp.ConnectionString);
            if (csp == null)
                return null;
            string dataBasePath = csp.GetDataLocation();
            if (string.IsNullOrEmpty(dataBasePath))
                return null;
            StorageFolder basePath = C1FlexReport.GetActualBasePath(dlp.Report);
            StorageFile dataBaseFile = FileNameParser.ReplaceSpecialFolderTags(dataBasePath, basePath);
            if (dataBaseFile == null)
                return null;

            try
            {
                return new SQLiteConnection(dataBaseFile.Path, SQLiteOpenFlags.ReadOnly);
            }
            catch
            {
                return null;
            }
        }

        private DbCommand CreateCommand(DataLinkParams dlp)
        {
            SQLiteConnection connection = CreateConnection(dlp);
            if (connection == null)
                return null;

            try
            {
                // initialize SQLiteCommand
                DbCommand command;
                switch (dlp.RecordSourceType)
                {
                    case RecordSourceType.TableDirect:
                        command = new DbCommand(connection)
                        {
                            CommandText = "select * from " + dlp.RecordSource,
                        };
                        return command;
                    case RecordSourceType.Text:
                        command = new DbCommand(connection);
                        PrepareDbCommand(command, dlp, dlp.RecordSource);
                        return command;
                }

                // auto command type
                command = new DbCommand(connection);
                PrepareDbCommand(command, dlp, dlp.RecordSource);
                if (CheckQuery(command))
                    return command;

                PrepareDbCommand(command, dlp, "select * from " + dlp.RecordSource);
                return command;
            }
            catch
            {
                if (connection != null)
                    connection.Dispose();
                return null;
            }
        }

        private Type SQLiteColumnTypeToType(SQLite3.ColType colType)
        {
            switch (colType)
            {
                case SQLite3.ColType.Blob:
                    return typeof(byte[]);
                case SQLite3.ColType.Float:
                    return typeof(double);
                case SQLite3.ColType.Integer:
                    return typeof(Int32);
                case SQLite3.ColType.Null:
                    return typeof(string);
            }
            return typeof(string);
        }

        private string CheckName(string[] names, int len, string name)
        {
            int i = 0;
            int suffix = 0;
            string result = name;
            while (i < len)
            {
                if (string.Compare(names[i], result, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    suffix++;
                    result = name + suffix.ToString();
                    i = 0;
                }
                else
                    i++;
            }
            return result;
        }

        private void GetColumns(SQLitePCL.sqlite3_stmt stmt, out string[] names, out Type[] types)
        {
            int columnCount = SQLite3.ColumnCount(stmt);
            types = new Type[columnCount];
            names = new string[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                names[i] = CheckName(names, i, SQLite3.ColumnName(stmt, i));
                types[i] = SQLiteColumnTypeToType(SQLite3.ColumnType(stmt, i));
            }
        }
        #endregion

        #region Protected
        protected override void GetDataSourceInfo(DataLinkParams dlp, DataSourceInfo dsi)
        {
            DbCommand command = CreateCommand(dlp);
            if (command == null)
                return;

            using (command)
            {
                try
                {
                    using (var stmt = SQLite3.Prepare2(command.Connection.Handle, command.CommandText))
                    {
                        //
                        string[] names;
                        Type[] types;
                        GetColumns(stmt, out names, out types);
                        for (int i = 0; i < names.Length; i++)
                        {
                            C1.Xaml.FlexReport.FieldInfo fi = new C1.Xaml.FlexReport.FieldInfo(names[i], types[i]);
                            dsi.Fields.Add(fi);
                            if (IsImageField(fi.DataType))
                            {
                                dsi.ImageFields.Add(fi);
                            }
                            else
                            {
                                dsi.TextFields.Add(fi);
                            }
                        }
                    }
                }
                catch
                {
                }
            }
        }

        internal static void BindParameter(SQLitePCL.sqlite3_stmt stmt, int index, object value, bool storeDateTimeAsTicks)
        {
            if (value == null)
            {
                SQLite3.BindNull(stmt, index);
            }
            else
            {
                if (value is Int32)
                {
                    SQLite3.BindInt(stmt, index, (int)value);
                }
                else if (value is String)
                {
                    SQLite3.BindText(stmt, index, (string)value, -1, NegativePointer);
                }
                else if (value is Byte || value is UInt16 || value is SByte || value is Int16)
                {
                    SQLite3.BindInt(stmt, index, Convert.ToInt32(value));
                }
                else if (value is Boolean)
                {
                    SQLite3.BindInt(stmt, index, (bool)value ? 1 : 0);
                }
                else if (value is UInt32 || value is Int64)
                {
                    SQLite3.BindInt64(stmt, index, Convert.ToInt64(value));
                }
                else if (value is Single || value is Double || value is Decimal)
                {
                    SQLite3.BindDouble(stmt, index, Convert.ToDouble(value));
                }
                else if (value is TimeSpan)
                {
                    SQLite3.BindInt64(stmt, index, ((TimeSpan)value).Ticks);
                }
                else if (value is DateTime)
                {
                    if (storeDateTimeAsTicks)
                    {
                        SQLite3.BindInt64(stmt, index, ((DateTime)value).Ticks);
                    }
                    else
                    {
                        SQLite3.BindText(stmt, index, ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"), -1, NegativePointer);
                    }
                }
                else if (value is DateTimeOffset)
                {
                    SQLite3.BindInt64(stmt, index, ((DateTimeOffset)value).UtcTicks);

                } else if (value.GetType().GetTypeInfo().IsEnum)
                {
                    SQLite3.BindInt(stmt, index, Convert.ToInt32(value));
                }
                else if (value is byte[])
                {
                    SQLite3.BindBlob(stmt, index, (byte[])value, ((byte[])value).Length, NegativePointer);
                }
                else if (value is Guid)
                {
                    SQLite3.BindText(stmt, index, ((Guid)value).ToString(), 72, NegativePointer);
                }
                else
                {
                    throw new NotSupportedException("Cannot store type: " + value.GetType());
                }
            }
        }

        private object ReadCol(SQLitePCL.sqlite3_stmt stmt, int index, SQLite3.ColType type)
        {
            switch (type)
            {
                case SQLite3.ColType.Blob:
                    return SQLite3.ColumnByteArray(stmt, index);
                case SQLite3.ColType.Float:
                    return SQLite3.ColumnDouble(stmt, index);
                case SQLite3.ColType.Integer:
                    return SQLite3.ColumnInt64(stmt, index);
                case SQLite3.ColType.Null:
                    return null;
                case SQLite3.ColType.Text:
                    return SQLite3.ColumnString(stmt, index);
            }
            return null;
        }

        private void BindParameters(SQLitePCL.sqlite3_stmt stmt, DbCommand command)
        {
            for (int i = 0; i < command.Parameters.Count; i++)
            {
                BindParameter(stmt, i + 1, command.Parameters[0].Value, command.Connection.StoreDateTimeAsTicks);
            }
        }
        #endregion

        #region Public
        public override bool Validate(DataLinkParams dlp)
        {
            SQLiteConnection connection = CreateConnection(dlp);
            if (connection == null)
                return false;
            connection.Dispose();
            return true;
        }

        public override object GetDataObject(DataLinkParams dlp)
        {
            DbCommand command = CreateCommand(dlp);
            if (command == null)
                return null;

            using (command)
            {
                try
                {
                    var stmt = SQLite3.Prepare2(command.Connection.Handle, command.CommandText);
                    using (stmt)
                    {
                        // setup parameters
                        BindParameters(stmt, command);

                        // build Recordset object
                        Recordset result = new Recordset();
                        // create columns
                        GetColumns(stmt, out result.Names, out result.Types);
                        for (int i = 0; i < result.Names.Length; i++)
                            result.AddColumn();
                        // fill recordset
                        object[] values = new object[result.Names.Length];
                        while (SQLite3.Step(stmt) == SQLite3.Result.Row && (dlp.MaxRecords <= 0 || result.Count < dlp.MaxRecords))
                        {
                            for (int i = 0; i < result.Names.Length; i++)
                            {
                                values[i] = ReadCol(stmt, i, SQLite3.ColumnType(stmt, i));
                            }
                            result.Add(values);
                        }

                        return result;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        #endregion

        #region Public properties
        public override bool Available
        {
            get { return true; }
        }
        #endregion

        #region Nested types
        private class Recordset : IC1FlexReportRecordset
        {
            private readonly List<List<object>> _data = new List<List<object>>();
            public Type[] Types;
            public string[] Names;
            private int _count;
            private int _position;

            public void AddColumn()
            {
                _data.Add(new List<object>());
            }

            public void Add(object[] values)
            {
                for (int i = 0; i < values.Length; i++)
                    _data[i].Add(values[i]);
                _count++;
            }

            public int Count
            {
                get { return _count; }
            }

            public string[] GetFieldNames()
            {
                return Names;
            }

            public Type[] GetFieldTypes()
            {
                return Types;
            }

            public object GetFieldValue(int fieldIndex)
            {
                if (_position >= 0 && _position < _count)
                    return _data[fieldIndex][_position];
                return null;
            }

            public bool BOF()
            {
                return _position == 0;
            }

            public bool EOF()
            {
                return _position >= Count;
            }

            public void MoveFirst()
            {
                _position = 0;
            }

            public void MoveLast()
            {
                _position = Count - 1;
            }

            public void MoveNext()
            {
                if (_position < Count)
                    _position++;
            }

            public void MovePrevious()
            {
                if (_position > 0)
                    _position--;
            }

            public int GetBookmark()
            {
                return _position;
            }

            public void SetBookmark(int bookmark)
            {
                _position = bookmark;
            }
        }

        private class DbParameter
        {
            public string Name;
            public object Value;
        }

        private class DbCommand : IDisposable
        {
            private SQLiteConnection _connection;
            public string CommandText;
            public readonly List<DbParameter> Parameters = new List<DbParameter>();

            #region Constructors
            public DbCommand(SQLiteConnection connection)
            {
                _connection = connection;
            }
            #endregion

            #region Public
            public void Dispose()
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            }
            #endregion

            #region Public properties
            public SQLiteConnection Connection
            {
                get { return _connection; }
            }
            #endregion
        }
        #endregion
    }
}
