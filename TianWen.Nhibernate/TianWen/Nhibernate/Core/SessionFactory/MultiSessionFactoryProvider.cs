namespace TianWen.Nhibernate.TianWen.Nhibernate.Core.SessionFactory
{
    using FluentNHibernate.Cfg;
    using NHibernate;
    using NHibernate.Cfg;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using TianWen.Nhibernate.DataSource;

    public class MultiSessionFactoryProvider : ISessionFactoryProvider, IEnumerable<ISessionFactory>, IEnumerable, IDisposable
    {
        private readonly string _defaultSessionFactoryName;
        private bool _disposed;
        private static Dictionary<string, ISessionFactory> _sessionFactorys = new Dictionary<string, ISessionFactory>();
        private static readonly DataSourceManager dm = new DataSourceManager();
        public static Dictionary<string, IDictionary<string, string>> properties = new Dictionary<string, IDictionary<string, string>>();

        public event EventHandler<EventArgs> BeforeCloseSessionFactory;

        public MultiSessionFactoryProvider() : this("Default")
        {
        }

        public MultiSessionFactoryProvider(string defaultSessionFactoryName)
        {
            this._defaultSessionFactoryName = defaultSessionFactoryName;
            this.Initialize();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    foreach (ISessionFactory factory in _sessionFactorys.Values)
                    {
                        if (factory != null)
                        {
                            this.DoBeforeCloseSessionFactory();
                            factory.Close();
                        }
                    }
                    _sessionFactorys = new Dictionary<string, ISessionFactory>(4);
                }
                this._disposed = true;
            }
        }

        private void DoBeforeCloseSessionFactory()
        {
            if (this.BeforeCloseSessionFactory != null)
            {
                this.BeforeCloseSessionFactory(this, new EventArgs());
            }
        }

        ~MultiSessionFactoryProvider()
        {
            this.Dispose(false);
        }

        public IEnumerator<ISessionFactory> GetEnumerator()
        {
            this.Initialize();
            return _sessionFactorys.Values.GetEnumerator();
        }

        public ISessionFactory GetFactory(string factoryId)
        {
            this.Initialize();
            return (string.IsNullOrEmpty(factoryId) ? this.InternalGetFactory(this._defaultSessionFactoryName) : this.InternalGetFactory(factoryId));
        }

        private void Initialize()
        {
            if (_sessionFactorys.Count == 0)
            {
                using (IEnumerator<TianWen.Nhibernate.DataSource.DataSource> enumerator = dm.DataSources.GetEnumerator())
                {
                    TianWen.Nhibernate.DataSource.DataSource ds;
                    while (enumerator.MoveNext())
                    {
                        ds = enumerator.Current;
                        string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\" + ds.SourceFile;
                        Configuration cfg = new Configuration().Configure(fileName);
                        this.Properties.Add(ds.SourceName, cfg.Properties);
                        FluentConfiguration configuration2 = Fluently.Configure(cfg);
                        string[] strArray = ds.AssemblyName.Split(new char[] { ',' });
                        foreach (string str2 in strArray)
                        {
                            string name = str2;
                            configuration2.Mappings(delegate (MappingConfiguration m) {
                                m.HbmMappings.AddFromAssembly(Assembly.Load(name));
                                if (ds.IsExportTo.ToLower().Equals("true"))
                                {
                                    m.FluentMappings.AddFromAssembly(Assembly.Load(name)).ExportTo(ds.ExportPath);
                                }
                                else
                                {
                                    m.FluentMappings.AddFromAssembly(Assembly.Load(name));
                                }
                            });
                        }
                        ISessionFactory factory = configuration2.BuildSessionFactory();
                        _sessionFactorys.Add(ds.SourceName, factory);
                    }
                }
            }
        }

        private ISessionFactory InternalGetFactory(string factoryId)
        {
            ISessionFactory factory;
            try
            {
                factory = _sessionFactorys[factoryId];
            }
            catch (KeyNotFoundException)
            {
                throw new ArgumentException("The session-factory-id was not register", "factoryId");
            }
            return factory;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public Dictionary<string, IDictionary<string, string>> Properties
        {
            get
            {
                return properties;
            }
            set
            {
                properties = value;
            }
        }

        public Dictionary<string, ISessionFactory> SessionFactorys
        {
            get
            {
                return _sessionFactorys;
            }
        }
    }
}

