using System.Collections.Generic;
using System.Data;
using NHibernate;
using TianWen.Nhibernate.Repository;

namespace TianWen.XiaoZhen1Qu.Interface
{
    public interface IDAO
    {
        IRepository Repository { get; }
        void Save(object obj);
        DataTable GetDataTable(string sql);
        void Update(object obj);
        void SaveOrUpdate(object obj);
        T GetObjectByID<T>(object obj);
        T GetObjectByIDForUpdate<T>(string id);
        IList<T> GetObjectList<T>(string condition);

        ITransaction BeginTransaction();
        void Remove(object obj);
        void Remove<T>(string objSec);
        DataTable DoPageList(string sql, int pageSize, int pageIndex, string orderField, string orderDirection, out int recordCount);
        string GetPageSql(string sql, string orderField, string orderDirection, int pageIndex, int pageSize);
    }
}
