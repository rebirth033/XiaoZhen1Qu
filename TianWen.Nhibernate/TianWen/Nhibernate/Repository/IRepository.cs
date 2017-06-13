using System.Collections.Generic;
using System.Data;
using NHibernate;

namespace TianWen.Nhibernate.TianWen.Nhibernate.Repository{

    public interface IRepository
    {
        void BeginDbTransaction();
        void BeginTransaction();
        void Commit();
        void DbCommit();
        void DbRollback();
        void Delete(object o);
        void Delete<T>(object id);
        IList<T> DoPageList<T>(string condition, int currentPageIndex, int pageSize, out int recordCount);
        IList<T> DoPageList<T>(string cols, string condition, int currentPageIndex, int pageSize, out int recordCount);
        int ExecuteNonQuery(string sql);
        int ExecuteNonQuery(string sql, CommandType commandType, IDataParameter[] commandParameters);
        object ExecuteScalar(string sql);
        object ExecuteScalar(string sql, CommandType commandType, IDataParameter[] commandParameters);
        DataSet GetDataSet(string sql);
        DataSet GetDataSet(string sql, CommandType commandType, IDataParameter[] commandParameters);
        DataTable GetDataTable(string sql);
        DataTable GetDataTable(string sql, CommandType commandType, IDataParameter[] commandParameters);
        T GetObjectById<T>(object id);
        IList<T> GetObjectList<T>(string strWhere);
        IList<T> GetObjectList<T>(string hql, int max);
        IList<T> GetObjectList<T>(string hql, object arg);
        IList<T> GetObjectList<T>(string hql, params object[] arg);
        IList<T> GetObjectList<T>(string hql, int max, object arg);
        IList<T> GetObjectList<T>(string hql, int max, params object[] arg);
        IList<T> GetObjList<T>();
        IList<T> GetObjListByFk<T>(string key, object value);
        void Rollback();
        void Save(object o);
        void SaveForTransaction(object o);
        void SaveOrUpdate(object o);
        void SaveOrUpdateForTransaction(object o);
        void StatelessInsert<T>(IList<T> objs);
        void StatelessUpdate<T>(IList<T> objs);
        void Update(object o);
        void UpdateForTransaction(object o);

        TianWen.Nhibernate.Repository.DataBaseType DataBaseType { get; set; }

        ISession Session { get; }

        IStatelessSession StatelessSession { get; }
    }
}

