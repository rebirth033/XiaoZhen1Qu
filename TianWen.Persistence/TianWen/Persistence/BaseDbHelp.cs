namespace TianWen.Persistence
{
    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Data.Common;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using TianWen;
    using TianWen.Exceptions;
    using TianWen.Logger;

    public abstract class BaseDbHelp : IDbHelp
    {
        protected IDbConnection _Connection;
        protected ConnectionState _OldConnectionState;
        protected IDbTransaction _Transaction;
        [CompilerGenerated]
        private bool bool_0;
        [CompilerGenerated]
        private bool bool_1;
        [CompilerGenerated]
        private bool bool_2;
        [CompilerGenerated]
        private bool bool_3;
        private DataSource dataSource_0;
        [CompilerGenerated]
        private static System.Func<IDbCommand, IDataReader> func_0;
        [CompilerGenerated]
        private static System.Func<IDbCommand, object> func_1;

        protected event DataSourceChange DataSourceChangedHandle;

        protected BaseDbHelp()
        {
        }

        public virtual void BeginTransaction()
        {
            this.CheckOpenConnection();
            this._Transaction = this._Connection.BeginTransaction();
            ((BaseCommandHelp) this.CommandHelp).method_0(this._Transaction);
            //this.method_1(true);
            //this.method_3(false);
            //this.method_2(false);
        }

        public virtual void CheckCloseConnection()
        {
            if (!this.TranscationIsOpen && (this._OldConnectionState == ConnectionState.Closed))
            {
                this.CloseConnection();
            }
        }

        public virtual void CheckOpenConnection()
        {
            if (!this.TranscationIsOpen)
            {
                this._OldConnectionState = this._Connection.State;
                if (this._OldConnectionState == ConnectionState.Closed)
                {
                    this.OpenConnection();
                }
            }
        }

        public virtual void CloseConnection()
        {
            this._Connection.Close();
            //this.method_0(false);
        }

        public virtual void CommitTransaction()
        {
            if (this._Transaction != null)
            {
                try
                {
                    this._Transaction.Commit();
                    this._Transaction = null;
                    //this.method_3(true);
                    //this.method_1(false);
                }
                finally
                {
                    this.CheckCloseConnection();
                }
            }
        }

        public void Dispose()
        {
            if (this.TranscationIsOpen)
            {
                this._Transaction.Dispose();
            }
            this._Connection.Dispose();
            this._Connection = null;
        }

        public T Exec<T>(System.Func<IDbHelp, T> func, string errCode, bool closeConnection = true) where T: struct
        {
            IDbHelp arg = null;
            T local;
            try
            {
                arg = DbFactory.Instance.GetDbHelp("");
                local = func(arg);
            }
            catch (Exception exception)
            {
                if (arg.TranscationIsOpen)
                {
                    arg.RollbackTransaction();
                }
                throw ExceptionManager.Instance.CreateException(errCode, exception, new object[] { func.Method });
            }
            finally
            {
                if (closeConnection)
                {
                    this.CheckCloseConnection();
                }
            }
            return local;
        }

        public T Exec<T>(System.Func<IDbCommand, T> func, string string_0, string errorCode, bool closeConnection = true, params object[] cmdParams)
        {
            return this.Exec<T>(func, string_0, errorCode, CommandType.Text, closeConnection, cmdParams);
        }

        public T Exec<T>(System.Func<IDbCommand, T> func, string string_0, string errorCode, CommandType cmdType, bool closeConnection = true, params object[] cmdParams)
        {
            T local;
            this.CheckOpenConnection();
            using (IDbCommand command = this.CommandHelp.CreateDbCommand(string_0, cmdType, cmdParams))
            {
                try
                {
                    local = func(command);
                }
                catch (Exception exception)
                {
                    if (this.TranscationIsOpen)
                    {
                        this._Transaction.Rollback();
                    }
                    throw ExceptionManager.Instance.CreateException(errorCode, exception, new object[] { string_0 });
                }
                finally
                {
                    if (closeConnection)
                    {
                        this.CheckCloseConnection();
                    }
                    command.Parameters.Clear();
                }
            }
            return local;
        }

        public virtual int ExecuteNonQuery(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            Class1 class2 = new Class1 {
                idataParameter_0 = cmdParams,
                baseDbHelp_0 = this
            };
            return this.OldExec<int>(new System.Func<IDbCommand, int>(class2.method_0), commandText, cmdType, true, class2.idataParameter_0);
        }

        public int ExecuteNonQuery(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType)
        {
            return this.ExecuteNonQuery(commandText, cmdType, this.method_4(commandFunc));
        }

        public virtual object ExecuteScalar(string selectSql)
        {
            return this.ExecuteScalar(selectSql, CommandType.Text, new IDataParameter[0]);
        }

        public virtual object ExecuteScalar(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            if (func_1 == null)
            {
                func_1 = new System.Func<IDbCommand, object>(BaseDbHelp.smethod_1);
            }
            return this.OldExec<object>(func_1, commandText, cmdType, true, cmdParams);
        }

        public virtual T ExecuteScalar<T>(string commandText, CommandType cmdType, params IDataParameter[] cmdParams) where T: struct
        {
            object obj2 = this.ExecuteScalar(commandText, cmdType, cmdParams);
            if (obj2 == DBNull.Value)
            {
                return default(T);
            }
            return ((obj2 == null) ? default(T) : ((T) Convert.ChangeType(obj2, typeof(T))));
        }

        public object ExecuteScalar(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType)
        {
            return this.ExecuteScalar(commandText, cmdType, this.method_4(commandFunc));
        }

        public T ExecuteScalar<T>(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType) where T: struct
        {
            return this.ExecuteScalar<T>(commandText, cmdType, this.method_4(commandFunc));
        }

        protected abstract void FillReturnValue(IDataParameter[] oldParams, IDataParameterCollection resultParam);
        public IDataReader GetDataReader(string commandText, params IDataParameter[] cmdParams)
        {
            return this.GetDataReader(commandText, CommandType.Text, cmdParams);
        }

        public virtual IDataReader GetDataReader(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            if (func_0 == null)
            {
                func_0 = new System.Func<IDbCommand, IDataReader>(BaseDbHelp.smethod_0);
            }
            return this.OldExec<IDataReader>(func_0, commandText, cmdType, false, cmdParams);
        }

        public IDataReader GetDataReader(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType)
        {
            return this.GetDataReader(commandText, cmdType, this.method_4(commandFunc));
        }

        public DataSet GetDataSet(string commandText)
        {
            return this.GetDataSet(commandText, CommandType.Text, new IDataParameter[0]);
        }

        public virtual DataSet GetDataSet(string commandText, params IDataParameter[] cmdParams)
        {
            return this.GetDataSet(commandText, CommandType.Text, cmdParams);
        }

        public virtual DataSet GetDataSet(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            return this.GetDataSet(commandText, cmdType, null, cmdParams);
        }

        public DataSet GetDataSet(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType)
        {
            return this.GetDataSet(commandText, cmdType, this.method_4(commandFunc));
        }

        public virtual DataSet GetDataSet(string commandText, CommandType cmdType, DataTableMapping dataTableMapping = null, params IDataParameter[] cmdParams)
        {
            Class0 class2 = new Class0 {
                string_0 = commandText,
                commandType_0 = cmdType,
                idataParameter_0 = cmdParams,
                baseDbHelp_0 = this
            };
            return this.LoadDataSet(new System.Func<DbCommand>(class2.method_0), class2.string_0, dataTableMapping);
        }

        public virtual DataTable GetDataTable(string selectSql, string tableName)
        {
            DataTable table = new DataTable(tableName);
            return this.GetDataTable(selectSql, CommandType.Text, new IDataParameter[0]).Copy();
        }

        public virtual DataTable GetDataTable(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            return this.GetDataSet(commandText, cmdParams).Tables[0];
        }

        public DataTable GetDataTable(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType)
        {
            return this.GetDataTable(commandText, cmdType, this.method_4(commandFunc));
        }

        public virtual DataView GetDataView(string commandText, CommandType cmdType, params IDataParameter[] cmdParams)
        {
            return this.GetDataSet(commandText, cmdParams).Tables[0].DefaultView;
        }

        public DataView GetDataView(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType)
        {
            return this.GetDataView(commandText, cmdType, this.method_4(commandFunc));
        }

        public abstract string GetSeqNextValue(string seqName);
        public NameValueCollection GetSingleRow(string string_0, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType)
        {
            using (IDataReader reader = this.GetDataReader(string_0, cmdType, this.method_4(commandFunc)))
            {
                return reader.FillOne();
            }
        }

        public virtual string[] GetSqlParamName(params IDataParameter[] cmdParams)
        {
            string[] strArray = new string[cmdParams.Length];
            for (int i = 0; i < cmdParams.Length; i++)
            {
                strArray[i] = SqlBuilder.GetSqlParamName(cmdParams[i].ParameterName, this.CommandHelp.SqlParamPrefix);
            }
            return strArray;
        }

        protected DataSet LoadDataSet(System.Func<DbCommand> func, string string_0, DataTableMapping dataTableMapping = null)
        {
            DataSet set2;
            using (DbDataAdapter adapter = this.CommandHelp.CreateDbDataAdapter(null))
            {
                try
                {
                    adapter.SelectCommand = func();
                    DataSet dataSet = new DataSet();
                    if (dataTableMapping != null)
                    {
                        adapter.TableMappings.AddRange(new DataTableMapping[] { dataTableMapping });
                        adapter.Fill(dataSet, dataTableMapping.SourceTable);
                    }
                    else
                    {
                        adapter.Fill(dataSet, SqlBuilder.GetTableNameFromSQL(string_0));
                    }
                    set2 = dataSet;
                }
                catch (Exception exception)
                {
                    if (adapter.SelectCommand == null)
                    {
                        throw ExceptionManager.Instance.CreateException("0100200022", exception, new object[] { exception.Message, string_0 });
                    }
                    throw ExceptionManager.Instance.CreateException("0100200023", exception, new object[] { exception.Message, SqlBuilder.GetFormatedSql(adapter.SelectCommand, this.CommandHelp.SqlParamPrefix), "" });
                }
                finally
                {
                    adapter.TableMappings.Clear();
                    if (adapter.SelectCommand != null)
                    {
                        adapter.SelectCommand.Parameters.Clear();
                    }
                }
            }
            return set2;
        }

        private IDataParameter[] method_4(System.Func<IDbCommandHelp, IDataParameter[]> func_2)
        {
            IDataParameter[] parameterArray = null;
            if (func_2 != null)
            {
                parameterArray = func_2(this.CommandHelp);
            }
            return parameterArray;
        }

        protected T OldExec<T>(System.Func<IDbCommand, T> func, string commandText, CommandType cmdType, bool closeConnection, params IDataParameter[] cmdParams)
        {
            T local;
            this.CheckOpenConnection();
            using (IDbCommand command = this.CommandHelp.CreateDbCommand(commandText, cmdType, cmdParams))
            {
                try
                {
                    local = func(command);
                }
                catch (Exception exception)
                {
                    string message = string.Format("执行SQL错误！sql={0},错误信息={1}", SqlBuilder.GetFormatedSql(command, this.CommandHelp.SqlParamPrefix), exception.Message);
                    LoggerManager.Error(message + exception.StackTrace);
                    throw new Exception(message);
                }
                finally
                {
                    if (closeConnection)
                    {
                        this.CheckCloseConnection();
                    }
                    command.Parameters.Clear();
                }
            }
            return local;
        }

        public virtual void OpenConnection()
        {
            try
            {
                this._Connection.Open();
                if (this._Connection.State != ConnectionState.Open)
                {
                    this._Connection.Close();
                    this._Connection.Open();
                }
                //this.method_0(true);
            }
            catch (Exception exception)
            {
                //this.method_0(false);
                if (exception.Message.StartsWith("池式连接请求超时"))
                {
                    OracleConnection.ClearAllPools();
                }
                if (this._Connection == null)
                {
                    throw ExceptionManager.Instance.CreateException("0100200021", exception);
                }
                if (this.DataSourceInfo != null)
                {
                    LoggerManager.Error(string.Format("数据库连接错误({0})，请检查{1}数据源的配置是否正确！", exception.StackTrace, this.DataSourceInfo.Name));
                }
                throw new Exception("打开数据库连接错误，请确认数据库已打开并且连接串参数设置正确！" + exception.Message);
            }
        }

        public virtual void RollbackTransaction()
        {
            if (this._Transaction != null)
            {
                try
                {
                    this._Transaction.Rollback();
                    this._Transaction = null;
                    //this.method_1(true);
                    //this.method_1(false);
                }
                finally
                {
                    this.CheckCloseConnection();
                }
            }
        }

        [CompilerGenerated]
        private static IDataReader smethod_0(IDbCommand idbCommand_0)
        {
            return idbCommand_0.ExecuteReader(CommandBehavior.CloseConnection);
        }

        [CompilerGenerated]
        private static object smethod_1(IDbCommand idbCommand_0)
        {
            return idbCommand_0.ExecuteScalar();
        }

        public abstract IDbCommandHelp CommandHelp { get; }

        public bool ConnectionIsOpen
        {
            [CompilerGenerated]
            get
            {
                return this.bool_0;
            }
            [CompilerGenerated]
            private set
            {
                this.bool_0 = value;
            }
        }

        public virtual DataSource DataSourceInfo
        {
            get
            {
                return this.dataSource_0;
            }
            internal set
            {
                this.dataSource_0 = value;
                if (this.DataSourceChangedHandle != null)
                {
                    this.DataSourceChangedHandle(value);
                }
            }
        }

        public bool TranscationIsCommitted
        {
            [CompilerGenerated]
            get
            {
                return this.bool_3;
            }
            [CompilerGenerated]
            private set
            {
                this.bool_3 = value;
            }
        }

        public bool TranscationIsOpen
        {
            [CompilerGenerated]
            get
            {
                return this.bool_1;
            }
            [CompilerGenerated]
            private set
            {
                this.bool_1 = value;
            }
        }

        public bool TranscationIsRolledBack
        {
            [CompilerGenerated]
            get
            {
                return this.bool_2;
            }
            [CompilerGenerated]
            private set
            {
                this.bool_2 = value;
            }
        }

        [CompilerGenerated]
        private sealed class Class0
        {
            public BaseDbHelp baseDbHelp_0;
            public CommandType commandType_0;
            public IDataParameter[] idataParameter_0;
            public string string_0;

            public DbCommand method_0()
            {
                return (this.baseDbHelp_0.CommandHelp.CreateDbCommand(this.string_0, this.commandType_0, this.idataParameter_0) as DbCommand);
            }
        }

        [CompilerGenerated]
        private sealed class Class1
        {
            public BaseDbHelp baseDbHelp_0;
            public IDataParameter[] idataParameter_0;

            public int method_0(IDbCommand idbCommand_0)
            {
                int num = idbCommand_0.ExecuteNonQuery();
                this.baseDbHelp_0.FillReturnValue(this.idataParameter_0, idbCommand_0.Parameters);
                return num;
            }
        }

        protected delegate void DataSourceChange(DataSource dataSource);
    }
}

