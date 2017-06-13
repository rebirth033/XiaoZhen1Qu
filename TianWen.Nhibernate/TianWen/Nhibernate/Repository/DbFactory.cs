namespace TianWen.Nhibernate.Repository
{
    using System;
    using System.Web;
    using TianWen.Nhibernate.Core.SessionFactory;

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

