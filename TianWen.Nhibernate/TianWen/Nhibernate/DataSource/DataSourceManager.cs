namespace TianWen.Nhibernate.TianWen.Nhibernate.DataSource
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using TianWen.Nhibernate;

    public class DataSourceManager
    {
        private static List<TianWen.Nhibernate.DataSource.DataSource> DataSourceList = new List<TianWen.Nhibernate.DataSource.DataSource>();

        public DataSourceManager()
        {
            if (File.Exists(Config.DataSourceFile))
            {
                DataSourceList = (List<TianWen.Nhibernate.DataSource.DataSource>) Serializer.LoadObjectFromFile(typeof(List<TianWen.Nhibernate.DataSource.DataSource>), Config.DataSourceFile);
            }
        }

        public TianWen.Nhibernate.DataSource.DataSource Find(string sourceName)
        {
            foreach (TianWen.Nhibernate.DataSource.DataSource source in DataSourceList)
            {
                if (source.SourceName == sourceName)
                {
                    return source;
                }
            }
            return null;
        }

        public static List<TianWen.Nhibernate.DataSource.DataSource> getDataSourceList()
        {
            return DataSourceList;
        }

        public IEnumerable<TianWen.Nhibernate.DataSource.DataSource> DataSources
        {
            get
            {
                return DataSourceList;
            }
        }
    }
}

