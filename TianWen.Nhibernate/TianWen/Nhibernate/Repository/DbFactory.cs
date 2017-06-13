using TianWen.Nhibernate.TianWen.Nhibernate.Core.SessionFactory;

namespace TianWen.Nhibernate.TianWen.Nhibernate.Repository
{
    using System;
    using System.Web;

    public class DbFactory
    {
        private static DbFactory _DbFactory = new DbFactory();
        public MultiSessionFactoryProvider mfp = new MultiSessionFactoryProvider();

        private DbFactory()
        {
        }

        public IRepository GetRepository()
        {
            return this.GetRepository("Default");
        }

        public IRepository GetRepository(string dbName)
        {
            if (HttpContext.Current != null)
            {
                return new WebRepository(dbName);
            }
            return new WinRepository(dbName);
        }

        public static DbFactory Instance
        {
            get
            {
                return _DbFactory;
            }
        }
    }
}

