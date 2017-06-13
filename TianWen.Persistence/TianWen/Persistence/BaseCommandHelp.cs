namespace TianWen.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Linq;
    using TianWen.Exceptions;

    public abstract class BaseCommandHelp : IDbCommandHelp
    {
        protected IDbConnection _conn;
        protected IDbHelp _dbHelp;
        protected IDbTransaction _trans;

        public BaseCommandHelp(IDbHelp dbhelp, IDbConnection conn, IDbTransaction trans)
        {
            this._conn = conn;
            this._trans = trans;
            this._dbHelp = dbhelp;
        }

        protected void AssignParameterValues(DbCommand command, object[] values)
        {
            int num = this.UserParametersStartIndex();
            for (int i = 0; i < values.Length; i++)
            {
                IDataParameter parameter = command.Parameters[i + num];
                this.SetParameterValue(command, parameter.ParameterName, values[i]);
            }
        }

        protected virtual string BuildParameterName(string name)
        {
            return name;
        }

        public virtual IDataParameter CreateBlobParameter(string name, object object_0)
        {
            throw ExceptionManager.Instance.CreateException("TianWen0100200036");
        }

        public virtual IDataParameter CreateClobParameter(string name, object object_0)
        {
            throw ExceptionManager.Instance.CreateException("TianWen0100200036");
        }

        public virtual IDataParameter CreateCursorParameter(string name)
        {
            throw ExceptionManager.Instance.CreateException("TianWen0100200036");
        }

        public virtual IDbCommand CreateDbCommand(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            return this.method_1(commandText, cmdType);
        }

        public virtual IDbCommand CreateDbCommand(string commandText, CommandType cmdType, params object[] cmdParams)
        {
            return this.method_1(commandText, cmdType);
        }

        public abstract DbDataAdapter CreateDbDataAdapter(DataTableMapping tableMap);
        public abstract DbDataAdapter CreateDbDataAdapter(DataTableMapping tableMap, IDataParameter[] whereParams, params IDataParameter[] valueParams);
        public abstract DbDataAdapter CreateDbDataAdapter(string tableName, IDataParameter[] whereParams, params IDataParameter[] valueParams);
        public virtual IDbCommand CreateDeleteCommand(string sourceTableName, params IDataParameter[] whereParams)
        {
            string where = SqlBuilder.CreateWhereClause(whereParams, this.SqlParamPrefix);
            string commandText = SqlBuilder.CreateDeleteSql(sourceTableName, where);
            return this.CreateDbCommand(commandText, CommandType.Text, whereParams);
        }

        public virtual IDbCommand CreateInsertCommand(string sourceTableName, params IDataParameter[] cmdParams)
        {
            string commandText = SqlBuilder.CreateInsertSql(sourceTableName, GetColumns(cmdParams), this.SqlParamPrefix);
            return this.CreateDbCommand(commandText, CommandType.Text, cmdParams);
        }

        public abstract IDataParameter CreateParameter();
        public abstract IDataParameter CreateParameter(string name, object object_0);
        public abstract IDataParameter CreateParameter(string name, Type dataType);
        public abstract IDataParameter CreateParameter(string name, ColumnType dbType);
        public abstract IDataParameter CreateParameter(string name, object object_0, ColumnType dbType);
        public abstract IDataParameter CreateParameter(string name, ColumnType dbType, int size);
        public abstract IDataParameter CreateParameter(string name, object object_0, ColumnType dbType, int size);
        public abstract IDataParameter CreateParameter(string name, ColumnType dbType, int size, string srcColumn);
        public abstract IDataParameter CreateParameter(string name, ColumnType dbType, int size, ParameterDirection direction, bool isNullable, int precision, int scale, string srcColumn, DataRowVersion srcVersion, object value);
        public abstract IDataParameter[] CreateParameters(int length);
        public virtual IDbCommand CreateUpdateCommand(string sourceTableName, string where, IDataParameter[] cmdParams)
        {
            string commandText = SqlBuilder.CreateUpdateSql(sourceTableName, GetColumns(cmdParams), where, this.SqlParamPrefix);
            return this.CreateDbCommand(commandText, CommandType.Text, cmdParams);
        }

        public virtual IDbCommand CreateUpdateCommand(string sourceTableName, IDataParameter[] whereParams, params IDataParameter[] cmdParams)
        {
            string where = SqlBuilder.CreateWhereClause(whereParams, this.SqlParamPrefix);
            IDbCommand command = this.CreateUpdateCommand(sourceTableName, where, cmdParams);
            foreach (IDataParameter parameter in whereParams)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        protected abstract void DeriveParameters(IDbCommand discoveryCommand);
        protected void DiscoverParameters(DbCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            using (IDbCommand command2 = this.CreateDbCommand(command.CommandText, command.CommandType, new object[1]))
            {
                command2.Connection = this._conn;
                this.DeriveParameters(command2);
                foreach (IDataParameter parameter in command2.Parameters)
                {
                    IDataParameter parameter2 = (IDataParameter) ((ICloneable) parameter).Clone();
                    command.Parameters.Add(parameter2);
                }
            }
        }

        public static string[] GetColumns(params IDataParameter[] cmdParams)
        {
            IList<string> source = new List<string>(cmdParams.Length);
            foreach (IDataParameter parameter in cmdParams)
            {
                source.Add(parameter.ParameterName);
            }
            return source.ToArray<string>();
        }

        internal void method_0(IDbTransaction idbTransaction_0)
        {
            this._trans = idbTransaction_0;
        }

        private IDbCommand method_1(string string_0, CommandType commandType_0)
        {
            IDbCommand command = this._conn.CreateCommand();
            command.CommandType = commandType_0;
            command.CommandText = string_0;
            command.Transaction = this._trans;
            return command;
        }

        protected virtual void SetParameterValue(DbCommand command, string parameterName, object value)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            command.Parameters[this.BuildParameterName(parameterName)].Value = value ?? DBNull.Value;
        }

        string[] IDbCommandHelp.GetSqlParamName(params IDataParameter[] cmdParams)
        {
            string[] strArray = new string[cmdParams.Length];
            for (int i = 0; i < cmdParams.Length; i++)
            {
                strArray[i] = SqlBuilder.GetSqlParamName(cmdParams[i].ParameterName, this.SqlParamPrefix);
            }
            return strArray;
        }

        protected virtual int UserParametersStartIndex()
        {
            return 0;
        }

        public abstract string SqlParamPrefix { get; }
    }
}

