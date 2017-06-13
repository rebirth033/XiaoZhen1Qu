namespace TianWen.Persistence
{
    using System;
    using System.Data;
    using System.Data.Common;

    public interface IDbCommandHelp
    {
        IDataParameter CreateBlobParameter(string name, object object_0);
        IDataParameter CreateClobParameter(string name, object object_0);
        IDataParameter CreateCursorParameter(string name);
        IDbCommand CreateDbCommand(string commandText, CommandType cmdType, params IDataParameter[] cmdParams);
        IDbCommand CreateDbCommand(string commandText, CommandType cmdType, params object[] cmdParams);
        DbDataAdapter CreateDbDataAdapter(DataTableMapping tableMap);
        DbDataAdapter CreateDbDataAdapter(DataTableMapping tableMap, IDataParameter[] whereParams, params IDataParameter[] valueParams);
        DbDataAdapter CreateDbDataAdapter(string tableName, IDataParameter[] whereParams, params IDataParameter[] valueParams);
        IDbCommand CreateDeleteCommand(string sourceTableName, params IDataParameter[] whereParams);
        IDbCommand CreateInsertCommand(string sourceTableName, params IDataParameter[] cmdParams);
        IDataParameter CreateParameter();
        IDataParameter CreateParameter(string name, object object_0);
        IDataParameter CreateParameter(string name, Type dataType);
        IDataParameter CreateParameter(string name, ColumnType dbType);
        IDataParameter CreateParameter(string name, object object_0, ColumnType dbType);
        IDataParameter CreateParameter(string name, ColumnType dbType, int size);
        IDataParameter CreateParameter(string name, object object_0, ColumnType dbType, int size);
        IDataParameter CreateParameter(string name, ColumnType dbType, int size, string srcColumn);
        IDataParameter CreateParameter(string name, ColumnType dbType, int size, ParameterDirection direction, bool isNullable, int precision, int scale, string srcColumn, DataRowVersion srcVersion, object value);
        IDataParameter[] CreateParameters(int length);
        IDbCommand CreateUpdateCommand(string sourceTableName, string where, params IDataParameter[] cmdParams);
        IDbCommand CreateUpdateCommand(string sourceTableName, IDataParameter[] whereParams, params IDataParameter[] cmdParams);
        string[] GetSqlParamName(params IDataParameter[] cmdParams);

        string SqlParamPrefix { get; }
    }
}

