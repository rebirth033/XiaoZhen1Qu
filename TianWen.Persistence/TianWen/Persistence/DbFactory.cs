namespace TianWen.Persistence
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using TianWen.Exceptions;
    using TianWen.Interface;
    using TianWen.Utility;

    public class DbFactory
    {
        private DataSource[] dataSource_0;
        private static readonly DbFactory dbFactory_0 = new DbFactory();
        private static FileSystemWatcher fileSystemWatcher_0;

        private DbFactory()
        {
            this.LoadDataSource();
            FileSystemWatcher watcher = new FileSystemWatcher(EnvironmentVar.ApplicationPath) {
                Filter = AppSettingCache.Get<string>("DataSourceConfigFile", "DataSources.config")
            };
            fileSystemWatcher_0 = watcher;
            fileSystemWatcher_0.Changed += new FileSystemEventHandler(this.method_0);
            fileSystemWatcher_0.EnableRaisingEvents = true;
        }

        public IDbHelp CreateDbHelp(string dataSourceName)
        {
            DataSource dataSource = this.GetDataSource(dataSourceName);
            if (dataSource == null)
            {
                throw ExceptionManager.Instance.CreateException("0100200005", null, new object[] { dataSourceName });
            }
            return this.CreateDbHelp(dataSource);
        }

        public IDbHelp CreateDbHelp(DataSource dataSource)
        {
            if (dataSource.DbHelpType == DbHelpClassTypes.SqlDbHelp)
            {
                throw ExceptionManager.Instance.CreateException("0100200006", null, new object[] { dataSource.Name, dataSource.DbHelpType });
            }
            BaseDbHelp help = ComponentFactory.Get<IDbHelp>(dataSource.DbHelpType.ToString()) as BaseDbHelp;
            help.DataSourceInfo = dataSource;
            return help;
        }

        public DataSource GetDataSource(string dataSourceName)
        {
            Class4 class2 = new Class4 {
                string_0 = dataSourceName
            };
            if (string.IsNullOrEmpty(class2.string_0))
            {
                string defaultDataSourceName = ApplicationConfiguration.DefaultDataSourceName;
            }
            return Enumerable.FirstOrDefault<DataSource>(this.dataSource_0, new System.Func<DataSource, bool>(class2.method_0));
        }

        public IDbCommandHelp GetDbCommandHelp()
        {
            return this.GetDbHelp("").CommandHelp;
        }

        public IDbCommandHelp GetDbCommandHelp(string dataSourceName)
        {
            return this.GetDbHelp(dataSourceName).CommandHelp;
        }

        public IDbCommandHelp GetDbCommandHelp(Type tableType)
        {
            return this.GetDbHelp(tableType).CommandHelp;
        }

        public IDbHelp GetDbHelp(string dataSourceName = "")
        {
            if (string.IsNullOrEmpty(dataSourceName))
            {
                dataSourceName = ApplicationConfiguration.DefaultDataSourceName ?? "Default";
            }
            return this.CreateDbHelp(dataSourceName);
        }

        public IDbHelp GetDbHelp(Type tableType)
        {
            return this.GetDbHelp("");
        }

        public void LoadDataSource()
        {
            string str = AppSettingCache.Get<string>("DataSourceConfigFile", "DataSources.config");
            this.LoadDataSource(Path.Combine(EnvironmentVar.ApplicationPath, str));
        }

        public void LoadDataSource(string configFile)
        {
            if (!File.Exists(configFile))
            {
                throw ExceptionManager.Instance.CreateException("0100200004");
            }
            this.dataSource_0 = DataSource.GetAllDataSources(configFile);
        }

        public void LoadDbHelp()
        {
            this.LoadDataSource();
        }

        private void method_0(object sender, FileSystemEventArgs e)
        {
            lock (dbFactory_0)
            {
                this.LoadDataSource();
            }
        }

        public static DbFactory Instance
        {
            get
            {
                return dbFactory_0;
            }
        }

        [CompilerGenerated]
        private sealed class Class4
        {
            public string string_0;

            public bool method_0(DataSource dataSource_0)
            {
                return (dataSource_0.Name == this.string_0);
            }
        }
    }
}

