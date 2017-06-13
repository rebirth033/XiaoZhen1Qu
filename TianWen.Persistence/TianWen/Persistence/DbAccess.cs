namespace TianWen.Persistence
{
    using System;
    using System.ComponentModel.Composition;
    using System.Data;
    using TianWen.Interface;
    using TianWen.Plus4MEF;

    [TianWenComponent("DbAccess"), PartCreationPolicy(CreationPolicy.NonShared)]
    public class DbAccess : IDbAccessSave
    {
        private readonly IDbAccessSave idbAccessSave_0;

        public DbAccess() : this(null)
        {
        }

        public DbAccess(string dataSourceName) : this(dataSourceName, null)
        {
        }

        public DbAccess(string dataSourceName, IDbAccessSave saveInstance)
        {
            this.idbAccessSave_0 = ComponentFactory.Get<IDbAccessSave>();
            this.idbAccessSave_0.Init(dataSourceName, saveInstance);
        }

        public int Save(DataTable table)
        {
            return this.idbAccessSave_0.Save(table);
        }

        public int Save(DataTable[] tables)
        {
            return this.idbAccessSave_0.Save(tables);
        }

        void IDbAccessSave.Init(string dataSourceName, IDbAccessSave component)
        {
            component.Init(dataSourceName, component);
        }

        public IDbCommandHelp DbCommandHelp
        {
            get
            {
                return this.idbAccessSave_0.DbCommandHelp;
            }
        }

        public IDbHelp DbHelp
        {
            get
            {
                return this.idbAccessSave_0.DbHelp;
            }
        }
    }
}

