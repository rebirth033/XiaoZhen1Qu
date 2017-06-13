namespace TianWen.Nhibernate.TianWen.Nhibernate.NhEventArgs
{
    using NHibernate.Cfg;
    using System;
    using System.Runtime.CompilerServices;

    public class ConfigurationEventArgs : EventArgs
    {
        public ConfigurationEventArgs(NHibernate.Cfg.Configuration configuration)
        {
            this.Configuration = configuration;
            this.Configured = false;
        }

        public NHibernate.Cfg.Configuration Configuration { get; private set; }

        public bool Configured { get; set; }
    }
}

