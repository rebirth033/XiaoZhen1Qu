namespace TianWen.Persistence
{
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using System.Text.RegularExpressions;
    using TianWen.Exceptions;

    public class CommandHelp4Oracle : BaseCommandHelp
    {
        public CommandHelp4Oracle(IDbHelp dbhelp, IDbConnection conn, IDbTransaction trans) : base(dbhelp, conn, trans)
        {
        }

        protected DataTableMapping CopyDataTableMapping(DataTableMapping dataTableMapping)
        {
            DataTableMapping mapping = new DataTableMapping(dataTableMapping.SourceTable, dataTableMapping.DataSetTable);
            foreach (DataColumnMapping mapping3 in dataTableMapping.ColumnMappings)
            {
                mapping.ColumnMappings.Add(mapping3.SourceColumn, mapping3.DataSetColumn);
            }
            return mapping;
        }

        public override IDataParameter CreateBlobParameter(string name, object object_0)
        {
            return new OracleParameter(name, object_0) { OracleDbType = OracleDbType.Blob };
        }

        public override IDataParameter CreateClobParameter(string name, object object_0)
        {
            return new OracleParameter(name, OracleDbType.Clob) { Value = object_0 };
        }

        public override IDataParameter CreateCursorParameter(string name)
        {
            return new OracleParameter { ParameterName = name, OracleDbType = OracleDbType.RefCursor, Direction = ParameterDirection.Output };
        }

        public override IDbCommand CreateDbCommand(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            IDbCommand command = base.CreateDbCommand(commandText, cmdType, cmdParams);
            if (cmdParams != null)
            {
                for (int i = 0; i < cmdParams.Length; i++)
                {
                    if (cmdParams[i].ParameterName == "?")
                    {
                        cmdParams[i].ParameterName = string.Format("P{0}", i);
                    }
                    cmdParams[i].Value = cmdParams[i].Value ?? DBNull.Value;
                    command.Parameters.Add(this.method_6(cmdParams[i]));
                    if (command.CommandType == CommandType.Text)
                    {
                        cmdParams[i].Direction = ParameterDirection.InputOutput;
                    }
                }
                if (commandText.IndexOf("{0}") > 0)
                {
                    foreach (IDataParameter parameter in cmdParams)
                    {
                        parameter.ParameterName = SqlBuilder.GetSqlParamName(parameter.ParameterName, this.SqlParamPrefix);
                    }
                    command.CommandText = string.Format(command.CommandText, (object[]) cmdParams);
                }
                else if (commandText.IndexOf("?") > 0)
                {
                    Regex regex = new Regex(@"\?");
                    if (regex.Matches(commandText).Count > cmdParams.Length)
                    {
                        throw ExceptionManager.Instance.CreateException("TianWen0100200034", new object[] { commandText });
                    }
                    foreach (IDataParameter parameter in command.Parameters)
                    {
                        command.CommandText = regex.Replace(command.CommandText, SqlBuilder.GetSqlParamName(parameter.ParameterName, this.SqlParamPrefix), 1);
                    }
                }
            }
            if (command is OracleCommand)
            {
                if (cmdType != CommandType.StoredProcedure)
                {
                    (command as OracleCommand).BindByName = true;
                }
                if (command.CommandText.IndexOf("'--'", StringComparison.Ordinal) > 0)
                {
                    command.CommandText = command.CommandText.Replace("'--'", ":sysdotdot");
                    command.Parameters.Add(new OracleParameter("sysdotdot", "--"));
                }
            }
            return command;
        }

        public override IDbCommand CreateDbCommand(string commandText, CommandType cmdType, params object[] cmdParams)
        {
            DbCommand command = base.CreateDbCommand(commandText, cmdType, cmdParams) as DbCommand;
            base.AssignParameterValues(command, cmdParams);
            return command;
        }

        public override DbDataAdapter CreateDbDataAdapter(DataTableMapping tableMap)
        {
            DbDataAdapter adapter = new OracleDataAdapter();
            try
            {
                if (tableMap != null)
                {
                    adapter.TableMappings.AddRange(new DataTableMapping[] { this.CopyDataTableMapping(tableMap) });
                }
            }
            catch (Exception exception)
            {
                if (tableMap != null)
                {
                    throw ExceptionManager.Instance.CreateException("0100200028", exception, new object[] { tableMap.SourceTable, exception.Message });
                }
                throw ExceptionManager.Instance.CreateException("0100200029", exception);
            }
            return adapter;
        }

        public override DbDataAdapter CreateDbDataAdapter(DataTableMapping tableMap, IDataParameter[] whereParams, params IDataParameter[] valueParams)
        {
            DbDataAdapter adapter = this.CreateDbDataAdapter(tableMap.SourceTable, whereParams, valueParams);
            adapter.TableMappings.AddRange(new DataTableMapping[] { this.CopyDataTableMapping(tableMap) });
            return adapter;
        }

        public override DbDataAdapter CreateDbDataAdapter(string tableName, IDataParameter[] whereParams, params IDataParameter[] valueParams)
        {
            DbDataAdapter adapter2;
            DbDataAdapter adapter = new OracleDataAdapter();
            try
            {
                adapter.UpdateCommand = (DbCommand) this.CreateUpdateCommand(tableName, whereParams, valueParams);
                adapter.InsertCommand = (DbCommand) this.CreateInsertCommand(tableName, this.method_5(valueParams));
                adapter.DeleteCommand = (DbCommand) this.CreateDeleteCommand(tableName, this.method_5(whereParams));
                adapter2 = adapter;
            }
            catch (Exception exception)
            {
                throw ExceptionManager.Instance.CreateException("0100200030", exception, new object[] { tableName, exception.Message });
            }
            return adapter2;
        }

        public override IDataParameter CreateParameter()
        {
            return new OracleParameter();
        }

        public override IDataParameter CreateParameter(string name, object object_0)
        {
            return new OracleParameter(name, object_0);
        }

        public override IDataParameter CreateParameter(string name, Type dataType)
        {
            return new OracleParameter(name, this.method_2(dataType));
        }

        public override IDataParameter CreateParameter(string name, ColumnType dataType)
        {
            return new OracleParameter(name, this.method_3(dataType));
        }

        public override IDataParameter CreateParameter(string name, object object_0, ColumnType dataType)
        {
            IDataParameter parameter = this.CreateParameter(name, dataType);
            parameter.Value = object_0;
            return parameter;
        }

        public override IDataParameter CreateParameter(string name, ColumnType dataType, int size)
        {
            return new OracleParameter(name, this.method_3(dataType), size);
        }

        public override IDataParameter CreateParameter(string name, object object_0, ColumnType dataType, int size)
        {
            IDataParameter parameter = this.CreateParameter(name, dataType, size);
            parameter.Value = object_0;
            return parameter;
        }

        public override IDataParameter CreateParameter(string name, ColumnType dbType, int size, string srcColumn)
        {
            return new OracleParameter(name, this.method_3(dbType), size, srcColumn);
        }

        public override IDataParameter CreateParameter(string name, ColumnType dbType, int size, ParameterDirection direction, bool isNullable, int precision, int scale, string srcColumn, DataRowVersion srcVersion, object value)
        {
            return new OracleParameter(name, this.method_3(dbType), size, ParameterDirection.Input, isNullable, (byte) precision, (byte) scale, srcColumn, srcVersion, value);
        }

        public override IDataParameter[] CreateParameters(int length)
        {
            return new OracleParameter[length];
        }

        protected override void DeriveParameters(IDbCommand discoveryCommand)
        {
            OracleCommandBuilder.DeriveParameters((OracleCommand) discoveryCommand);
        }

        private OracleDbType method_2(Type type_0)
        {
            string str = type_0.ToString();
            switch (str)
            {
                case null:
                    break;

                case "System.String":
                    return OracleDbType.Varchar2;

                case "System.Decimal":
                    return OracleDbType.Decimal;

                default:
                    if (!(str == "System.DateTime"))
                    {
                        if (str == "System.Byte[]")
                        {
                            return OracleDbType.Blob;
                        }
                    }
                    else
                    {
                        return OracleDbType.Date;
                    }
                    break;
            }
            return OracleDbType.Varchar2;
        }

        private OracleDbType method_3(ColumnType columnType_0)
        {
            switch (columnType_0)
            {
                case ColumnType.VarNumeric:
                    return OracleDbType.Decimal;

                case ColumnType.Binary:
                    return OracleDbType.LongRaw;

                case ColumnType.LongVarBinary:
                    return OracleDbType.LongRaw;

                case ColumnType.Date:
                case ColumnType.DateTime:
                    return OracleDbType.Date;

                case ColumnType.Char:
                    return OracleDbType.Char;

                case ColumnType.VarChar:
                    return OracleDbType.Varchar2;

                case ColumnType.Text:
                    return OracleDbType.Clob;

                case ColumnType.LongVarChar:
                    return OracleDbType.Varchar2;

                case ColumnType.Blob:
                    return OracleDbType.Blob;
            }
            return OracleDbType.Varchar2;
        }

        private OracleDbType method_4(DbType dbType_0)
        {
            switch (dbType_0)
            {
                case DbType.AnsiString:
                    return OracleDbType.Varchar2;

                case DbType.Binary:
                    return OracleDbType.LongRaw;

                case DbType.Date:
                case DbType.DateTime:
                    return OracleDbType.Date;

                case DbType.Object:
                    return OracleDbType.Raw;

                case DbType.VarNumeric:
                    return OracleDbType.Decimal;

                case DbType.AnsiStringFixedLength:
                    return OracleDbType.Char;

                case DbType.StringFixedLength:
                    return OracleDbType.Char;

                case DbType.String:
                    return OracleDbType.Varchar2;
            }
            return OracleDbType.Varchar2;
        }

        private IDataParameter[] method_5(IDataParameter[] idataParameter_0)
        {
            IDataParameter[] parameterArray = new OracleParameter[idataParameter_0.Length];
            for (int i = 0; i < idataParameter_0.Length; i++)
            {
                OracleParameter parameter = (OracleParameter) idataParameter_0[i];
                parameterArray[i] = new OracleParameter(parameter.ParameterName, this.method_4(parameter.DbType), parameter.Size, parameter.Direction, parameter.IsNullable, 0, 0, parameter.SourceColumn, parameter.SourceVersion, parameter.Value);
            }
            return parameterArray;
        }

        private OracleParameter method_6(IDataParameter idataParameter_0)
        {
            OracleParameter parameter = idataParameter_0 as OracleParameter;
            if (parameter != null)
            {
                return parameter;
            }
            OracleParameter parameter3 = new OracleParameter(idataParameter_0.ParameterName, idataParameter_0.Value) {
                Direction = idataParameter_0.Direction
            };
            if (idataParameter_0.GetType().GetProperty("OracleType").GetValue(idataParameter_0, null).ToString() == "Cursor")
            {
                parameter3.OracleDbType = OracleDbType.RefCursor;
            }
            else if (parameter3.Direction != ParameterDirection.Input)
            {
                parameter3.OracleDbType = this.method_4(idataParameter_0.DbType);
            }
            if (idataParameter_0 is OleDbParameter)
            {
                parameter3.Size = (idataParameter_0 as OleDbParameter).Size;
            }
            return parameter3;
        }

        public override string SqlParamPrefix
        {
            get
            {
                return ":";
            }
        }
    }
}

