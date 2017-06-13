using TianWen.Security;

namespace TianWen.Persistence
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Xml;
    using TianWen.Exceptions;
    using TianWen.Interface;
    using TianWen.Utility;

    [Serializable]
    public class DataSource
    {
        private StringCollection _Attribures;
        private string _ConnectionString;
        private DbHelpClassTypes _DbHelpType;
        private string _Name;
        private DataSourceTypes _SourceType;

        public DataSource()
        {
        }

        public DataSource(string name, DataSourceTypes sourceType, DbHelpClassTypes dbHelpType, string connectionString)
        {
            this._Name = name;
            this._SourceType = sourceType;
            this._DbHelpType = dbHelpType;
            this._ConnectionString = connectionString;
            this._Attribures = new StringCollection();
        }

        public void Add(string item)
        {
        }

        public static DataSource[] GetAllDataSources()
        {
            return GetAllDataSources(AppSettingCache.Get<string>("DataSourceConfigFile", "DataSources.config"));
        }

        public static DataSource[] GetAllDataSources(string configFile)
        {
            List<DataSource> list = null;
            try
            {
                list = Serializer.Deserialize4Xml<List<DataSource>>(configFile);
            }
            catch (InvalidOperationException exception)
            {
                if (exception.InnerException is XmlException)
                {
                    throw ExceptionManager.Instance.CreateException("TianWen0100200135", exception, new object[] { exception.Message });
                }
                ExceptionManager.Instance.CreateException(exception, "加载DataSources.Config时,遇到意外.");
                throw;
            }
            foreach (DataSource source in list)
            {
                if ((source.ConnectionString.IndexOf("User ID", StringComparison.CurrentCultureIgnoreCase) == -1) && (source.ConnectionString.IndexOf("Provider", StringComparison.CurrentCultureIgnoreCase) == -1))
                {
                    source.ConnectionString = ComponentFactory.Get<ICryptography>().Decrypt(source.ConnectionString);
                }
                if ((source.DbHelpType == DbHelpClassTypes.OracleDbHelp) && source.ConnectionString.StartsWith("Provider"))
                {
                    source.ConnectionString = source.ConnectionString.Substring(source.ConnectionString.IndexOf(';') + 1);
                }
            }
            return list.ToArray();
        }

        public Type GetDbHelpClasseType()
        {
            return Type.GetType("TianWen.Persistence." + this.DbHelpType.ToString());
        }

        public StringCollection Attribures
        {
            get
            {
                return this._Attribures;
            }
            set
            {
                this._Attribures = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this._ConnectionString;
            }
            set
            {
                this._ConnectionString = value;
            }
        }

        public DbHelpClassTypes DbHelpType
        {
            get
            {
                return this._DbHelpType;
            }
            set
            {
                this._DbHelpType = value;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public DataSourceTypes SourceType
        {
            get
            {
                return this._SourceType;
            }
            set
            {
                this._SourceType = value;
            }
        }
    }
}

