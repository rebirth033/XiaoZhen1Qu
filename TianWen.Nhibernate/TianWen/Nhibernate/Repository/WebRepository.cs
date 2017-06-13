
using TianWen.Nhibernate.TianWen.Nhibernate.Core.SessionFactory;
using TianWen.Nhibernate.TianWen.Nhibernate.Threading;

namespace TianWen.Nhibernate.TianWen.Nhibernate.Repository
{
    using NHibernate;

    public class WebRepository : AbstractRepository
    {
        private readonly string _dbName;

        public WebRepository() : this("Default")
        {
        }

        public WebRepository(string dbName)
        {
            this._dbName = "Default";
            this._dbName = dbName;
            base.setDataBaseType(dbName);
        }

        public override ISession Session
        {
            get
            {
                return (ISession) LogicalThreadContext.GetData("NHSession" + this._dbName);
            }
        }

        public override IStatelessSession StatelessSession
        {
            get
            {
                MultiSessionFactoryProvider provider = new MultiSessionFactoryProvider();
                return provider.GetFactory(this._dbName).OpenStatelessSession();
            }
        }

        public override ITransaction Transaction
        {
            get
            {
                return (ITransaction) LogicalThreadContext.GetData("Transaction" + this._dbName);
            }
            set
            {
                LogicalThreadContext.SetData("Transaction" + this._dbName, value);
            }
        }
    }
}

