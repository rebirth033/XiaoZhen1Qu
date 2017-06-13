namespace TianWen.Nhibernate.Core.SessionFactory
{
    using NHibernate;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface ISessionFactoryProvider : IEnumerable<ISessionFactory>, IEnumerable, IDisposable
    {
        event EventHandler<EventArgs> BeforeCloseSessionFactory;

        ISessionFactory GetFactory(string factoryId);
    }
}

