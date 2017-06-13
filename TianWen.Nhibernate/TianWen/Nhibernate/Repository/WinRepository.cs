
using TianWen.Nhibernate.TianWen.Nhibernate.Core.SessionFactory;
using TianWen.Nhibernate.TianWen.Nhibernate.Threading;

namespace TianWen.Nhibernate.TianWen.Nhibernate.Repository
{
    using NHibernate;

    public class WinRepository : AbstractRepository
    {
        private static IThreadStorage _ThreadStorage;
        private ITransaction _Transaction;
        private static MultiSessionFactoryProvider mfp = DbFactory.Instance.mfp;

        public WinRepository() : this("Default")
        {
        }

        public WinRepository(ISession session)
        {
            if (session.IsConnected)
            {
                session.Disconnect();
            }
            ThreadStorage.SetData("NHSession" + this.DbName, session);
        }

        public WinRepository(string dbName)
        {
            this.DbName = dbName;
            base.setDataBaseType(dbName);
            ISession session = mfp.GetFactory(this.DbName).OpenSession();
            if (session.IsConnected)
            {
                session.Disconnect();
            }
            ThreadStorage.SetData("NHSession" + this.DbName, session);
        }

        private string DbName { get; set; }

        public override ISession Session
        {
            get
            {
                ISession data = ThreadStorage.GetData("NHSession" + this.DbName) as ISession;
                if (data == null)
                {
                    data = mfp.GetFactory(this.DbName).OpenSession();
                    ThreadStorage.SetData("NHSession" + this.DbName, data);
                }
                if (!data.IsConnected)
                {
                    data.Reconnect();
                }
                return data;
            }
        }

        public override IStatelessSession StatelessSession
        {
            get
            {
                return mfp.GetFactory(this.DbName).OpenStatelessSession();
            }
        }

        private static IThreadStorage ThreadStorage
        {
            get
            {
                if (_ThreadStorage == null)
                {
                    _ThreadStorage = new ThreadStaticStorage();
                }
                return _ThreadStorage;
            }
        }

        public override ITransaction Transaction
        {
            get
            {
                return this._Transaction;
            }
            set
            {
                this._Transaction = value;
            }
        }
    }
}

