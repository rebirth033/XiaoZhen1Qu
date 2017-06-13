namespace TianWen.Nhibernate.Core.SessionFactory
{
    using NHibernate;
    using System;
    using System.Runtime.CompilerServices;
    using TianWen.Nhibernate.Repository;

    public class TlwSessionFactory
    {
        public TianWen.Nhibernate.Repository.DataBaseType DataBaseType { get; set; }

        public string DbName { get; set; }

        public ISessionFactory SessionFactory { get; set; }
    }
}

