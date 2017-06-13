namespace TianWen.SystemManager.Interface
{
    using System;
    using System.Data;
    using TianWen.Plus4MEF;

    public interface IDatatableDao : ITianWenComponent
    {
        DataTable GetNotImportTable(string type, string qKey, string dbName);
        void ImportAddFields(string dbName, string tableName);
        void ImportTableConfig(string dbName, string tableName, string tableNameCn);
    }
}

