namespace TianWen.Persistence
{
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Data;
    using System.Data.Common;
    using System.Data.OleDb;
    using TianWen.Exceptions;

    public class CommandHelp4Ole : BaseCommandHelp
    {
        public CommandHelp4Ole(IDbHelp dbhelp, IDbConnection conn, IDbTransaction trans) : base(dbhelp, conn, trans)
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

        public override IDbCommand CreateDbCommand(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            IDbCommand command = base.CreateDbCommand(commandText, cmdType, cmdParams);
            if (cmdParams != null)
            {
                foreach (IDataParameter parameter in cmdParams)
                {
                    parameter.Value = parameter.Value ?? DBNull.Value;
                    command.Parameters.Add(this.method_6(parameter));
                }
                if (commandText.IndexOf("{0}") > 0)
                {
                    foreach (IDataParameter parameter in cmdParams)
                    {
                        parameter.ParameterName = SqlBuilder.GetSqlParamName(parameter.ParameterName, this.SqlParamPrefix);
                    }
                    command.CommandText = string.Format(command.CommandText, (object[]) cmdParams);
                }
            }
            if (base._dbHelp.DataSourceInfo.SourceType != DataSourceTypes.ORACLE)
            {
                if (commandText.IndexOf(" from dual") != -1)
                {
                    command.CommandText = command.CommandText.Replace(" from dual", " ");
                }
                if (commandText.IndexOf("''") != -1)
                {
                    command.CommandText = command.CommandText.Replace("=''", "=null").Replace("= ''", "=null");
                }
            }
            if (base._dbHelp.DataSourceInfo.SourceType == DataSourceTypes.SQLSERVER)
            {
                if (commandText.IndexOf("decode(") != -1)
                {
                    command.CommandText = command.CommandText.Replace("decode(", "dbo.decode(");
                }
                if (commandText.IndexOf("substr(") != -1)
                {
                    command.CommandText = command.CommandText.Replace("substr(", "dbo.substr(");
                }
                if (commandText.IndexOf("||") != -1)
                {
                    command.CommandText = command.CommandText.Replace("||", "+");
                }
                if (commandText.IndexOf("sysdate ") != -1)
                {
                    command.CommandText = command.CommandText.Replace("sysdate ", "GETDATE() ");
                }
                if (commandText.IndexOf("to_char(") != -1)
                {
                    command.CommandText = command.CommandText.Replace("to_char(", "str(");
                }
                if (commandText.IndexOf("nvl(") != -1)
                {
                    command.CommandText = command.CommandText.Replace("nvl(", "ISNULL(");
                }
            }
            return command;
        }

        public override DbDataAdapter CreateDbDataAdapter(DataTableMapping tableMap)
        {
            DbDataAdapter adapter = new OleDbDataAdapter();
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
            DbDataAdapter adapter = new OleDbDataAdapter();
            try
            {
                adapter.UpdateCommand = (OleDbCommand) this.CreateUpdateCommand(tableName, whereParams, valueParams);
                adapter.InsertCommand = (OleDbCommand) this.CreateInsertCommand(tableName, this.method_5(valueParams));
                adapter.DeleteCommand = (OleDbCommand) this.CreateDeleteCommand(tableName, this.method_5(whereParams));
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
            return new OleDbParameter();
        }

        public override IDataParameter CreateParameter(string name, object object_0)
        {
            return new OleDbParameter(name, object_0);
        }

        public override IDataParameter CreateParameter(string name, Type dataType)
        {
            return new OleDbParameter(name, this.method_3(dataType));
        }

        public override IDataParameter CreateParameter(string name, ColumnType dataType)
        {
            return new OleDbParameter(name, this.method_4(dataType));
        }

        public override IDataParameter CreateParameter(string name, object object_0, ColumnType dataType)
        {
            IDataParameter parameter = this.CreateParameter(name, dataType);
            parameter.Value = object_0;
            return parameter;
        }

        public override IDataParameter CreateParameter(string name, ColumnType dataType, int size)
        {
            return new OleDbParameter(name, this.method_4(dataType), size);
        }

        public override IDataParameter CreateParameter(string name, object object_0, ColumnType dataType, int size)
        {
            IDataParameter parameter = this.CreateParameter(name, dataType, size);
            parameter.Value = object_0;
            return parameter;
        }

        public override IDataParameter CreateParameter(string name, ColumnType dbType, int size, string srcColumn)
        {
            return new OleDbParameter(name, this.method_4(dbType), size, srcColumn);
        }

        public override IDataParameter CreateParameter(string name, ColumnType dbType, int size, ParameterDirection direction, bool isNullable, int precision, int scale, string srcColumn, DataRowVersion srcVersion, object value)
        {
            return new OleDbParameter(name, this.method_4(dbType), size, ParameterDirection.Input, isNullable, (byte) precision, (byte) scale, srcColumn, srcVersion, value);
        }

        public override IDataParameter[] CreateParameters(int length)
        {
            return new OleDbParameter[length];
        }

        protected override void DeriveParameters(IDbCommand discoveryCommand)
        {
            OleDbCommandBuilder.DeriveParameters((OleDbCommand) discoveryCommand);
        }

        private OleDbType method_2(DbType dbType_0)
        {
            switch (dbType_0)
            {
                case DbType.AnsiString:
                    return OleDbType.VarChar;

                case DbType.Binary:
                    return OleDbType.LongVarBinary;

                case DbType.Date:
                    return OleDbType.Date;

                case DbType.DateTime:
                    return OleDbType.DBTimeStamp;

                case DbType.String:
                    return OleDbType.VarWChar;

                case DbType.VarNumeric:
                    return OleDbType.VarNumeric;

                case DbType.AnsiStringFixedLength:
                    return OleDbType.Char;

                case DbType.StringFixedLength:
                    return OleDbType.WChar;
            }
            return OleDbType.VarChar;
        }

        private OleDbType method_3(Type type_0)
        {
            string str = type_0.ToString();
            switch (str)
            {
                case null:
                    break;

                case "System.String":
                    return OleDbType.VarChar;

                case "System.Decimal":
                    return OleDbType.VarNumeric;

                default:
                    if (!(str == "System.DateTime"))
                    {
                        if (str == "System.Byte[]")
                        {
                            return OleDbType.LongVarBinary;
                        }
                    }
                    else
                    {
                        return OleDbType.DBTimeStamp;
                    }
                    break;
            }
            return OleDbType.VarChar;
        }

        private OleDbType method_4(ColumnType columnType_0)
        {
            switch (columnType_0)
            {
                case ColumnType.VarNumeric:
                    return OleDbType.VarNumeric;

                case ColumnType.Binary:
                    return OleDbType.Binary;

                case ColumnType.LongVarBinary:
                    return OleDbType.LongVarBinary;

                case ColumnType.Date:
                    return OleDbType.Date;

                case ColumnType.DateTime:
                    return OleDbType.DBTimeStamp;

                case ColumnType.Char:
                    return OleDbType.Char;

                case ColumnType.VarChar:
                    return OleDbType.VarChar;

                case ColumnType.Text:
                    return OleDbType.LongVarChar;

                case ColumnType.LongVarChar:
                    return OleDbType.LongVarChar;

                case ColumnType.Blob:
                    return OleDbType.LongVarBinary;
            }
            return OleDbType.VarChar;
        }

        private IDataParameter[] method_5(IDataParameter[] idataParameter_0)
        {
            IDataParameter[] parameterArray = new OleDbParameter[idataParameter_0.Length];
            for (int i = 0; i < idataParameter_0.Length; i++)
            {
                OleDbParameter parameter = (OleDbParameter) idataParameter_0[i];
                parameterArray[i] = new OleDbParameter(parameter.ParameterName, this.method_2(parameter.DbType), parameter.Size, parameter.Direction, parameter.IsNullable, 0, 0, parameter.SourceColumn, parameter.SourceVersion, parameter.Value);
            }
            return parameterArray;
        }

        private OleDbParameter method_6(IDataParameter idataParameter_0)
        {
            OleDbParameter parameter = idataParameter_0 as OleDbParameter;
            if (parameter != null)
            {
                return parameter;
            }
            OleDbParameter parameter3 = new OleDbParameter(idataParameter_0.ParameterName, idataParameter_0.Value) {
                Direction = idataParameter_0.Direction
            };
            if (parameter3.Direction != ParameterDirection.Input)
            {
                parameter3.OleDbType = this.method_2(idataParameter_0.DbType);
            }
            if (idataParameter_0 is OracleParameter)
            {
                parameter3.Size = (idataParameter_0 as OracleParameter).Size;
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

