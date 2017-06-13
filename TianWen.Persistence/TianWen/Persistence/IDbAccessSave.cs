namespace TianWen.Persistence
{
    using System;
    using System.Data;
    using TianWen.Plus4MEF;

    public interface IDbAccessSave : ITianWenComponent
    {
        void Init(string dataSourceName, IDbAccessSave component);
        int Save(DataTable table);
        int Save(DataTable[] tables);

        IDbCommandHelp DbCommandHelp { get; }

        IDbHelp DbHelp { get; }
    }
}

