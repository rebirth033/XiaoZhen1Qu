namespace TianWen.Persistence
{
    using System;
    using System.Collections.Specialized;
    using System.Data;
    using System.Data.Common;
    using System.Runtime.InteropServices;
    using TianWen.Plus4MEF;

    public interface IDbHelp : IDisposable, ITianWenComponent
    {
        void BeginTransaction();
        void CheckCloseConnection();
        void CheckOpenConnection();
        void CloseConnection();
        void CommitTransaction();
        T Exec<T>(System.Func<IDbHelp, T> func, string errCode, bool closeConnection = true) where T: struct;
        T Exec<T>(System.Func<IDbCommand, T> func, string string_0, string errorCode, bool closeConnection = true, params object[] cmdParams);
        T Exec<T>(System.Func<IDbCommand, T> func, string string_0, string errorCode, CommandType cmdType, bool closeConnection = true, params object[] cmdParams);
        int ExecuteNonQuery(string commandText, CommandType cmdType, params IDataParameter[] cmdParams);
        int ExecuteNonQuery(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType);
        object ExecuteScalar(string selectSql);
        object ExecuteScalar(string commandText, CommandType cmdType, params IDataParameter[] cmdParams);
        T ExecuteScalar<T>(string commandText, CommandType cmdType, params IDataParameter[] cmdParams) where T: struct;
        object ExecuteScalar(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType);
        T ExecuteScalar<T>(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType) where T: struct;
        [Obsolete("使用此方法, 一定要注意关闭返回的Reader, 防止数据库长连接")]
        IDataReader GetDataReader(string commandText, params IDataParameter[] cmdParams);
        [Obsolete("使用此方法, 一定要注意关闭返回的Reader, 防止数据库长连接")]
        IDataReader GetDataReader(string commandText, CommandType cmdType, params IDataParameter[] cmdParams);
        [Obsolete("使用此方法, 一定要注意关闭返回的Reader, 防止数据库长连接")]
        IDataReader GetDataReader(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType);
        DataSet GetDataSet(string commandText, params IDataParameter[] cmdParams);
        DataSet GetDataSet(string commandText, CommandType cmdType, params IDataParameter[] cmdParams);
        DataSet GetDataSet(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType);
        DataSet GetDataSet(string commandText, CommandType cmdType, DataTableMapping dataTableMapping = null, params IDataParameter[] cmdParams);
        DataTable GetDataTable(string selectSql, string tableName);
        DataTable GetDataTable(string commandText, CommandType cmdType, params IDataParameter[] cmdParams);
        DataTable GetDataTable(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType);
        DataView GetDataView(string commandText, CommandType cmdType, params IDataParameter[] cmdParams);
        DataView GetDataView(string commandText, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType);
        string GetSeqNextValue(string seqName);
        NameValueCollection GetSingleRow(string string_0, System.Func<IDbCommandHelp, IDataParameter[]> commandFunc, CommandType cmdType);
        void OpenConnection();
        void RollbackTransaction();

        IDbCommandHelp CommandHelp { get; }

        bool ConnectionIsOpen { get; }

        DataSource DataSourceInfo { get; }

        bool TranscationIsCommitted { get; }

        bool TranscationIsOpen { get; }

        bool TranscationIsRolledBack { get; }
    }
}

