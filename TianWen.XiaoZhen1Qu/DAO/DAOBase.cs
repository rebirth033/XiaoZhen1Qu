using NHibernate;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TianWen.Nhibernate.TianWen.Nhibernate.Repository;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.DAO
{
    public class DAOBase : IDAO
    {
        public string DbName { get; set; }
        public IRepository Repository
        {
            get;
            set;
        }
        public void Save(object obj)
        {
            Repository.Save(obj);
        }

        public void Update(object obj)
        {
            Repository.Update(obj);
        }

        public DataTable GetDataTable(string sql)
        {
            ////提取sql
            StringBuilder db = new StringBuilder();
            db.Append(@"" + sql);
            return Repository.GetDataTable(sql);
        }

        public T GetObjectByID<T>(object obj)
        {
            return Repository.GetObjectById<T>(obj);
        }

        public T GetObjectByIDForUpdate<T>(string id)
        {
            return Repository.Session.Load<T>(id, NHibernate.LockMode.Upgrade);
        }

        public void SaveOrUpdate(object obj)
        {
            Repository.SaveOrUpdate(obj);
        }

        public IList<T> GetObjectList<T>(string sql)
        {
            return Repository.GetObjectList<T>(sql);
        }
        public void Remove(object obj)
        {
            Repository.Delete(obj);
        }
        public void Remove<T>(string objSec)
        {
            Repository.Delete<T>(objSec);
        }

        public ITransaction BeginTransaction()
        {
            return Repository.Session.BeginTransaction();
        }

        public DataTable DoPageList(string sql, int pageSize, int currentPageIndex, string orderField, string orderDirection, out int recordCount)
        {
            //提取sql
            StringBuilder db = new StringBuilder();
            db.Append(@"" + sql);
            string sqlTotal = "SELECT COUNT(1) AS TotalRows FROM (" + sql + ") ";
            int.TryParse(Repository.ExecuteScalar(sqlTotal).ToString(), out recordCount);
            if (recordCount > 0)
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append(" SELECT  T.* FROM " +
                                       "(SELECT ROW_NUMBER() OVER (ORDER BY " + orderField + " " + orderDirection + ")  AS RowNo,COUNT(1) OVER (PARTITION BY 1) AS TotalCount,a.* FROM ");
                sbSql.Append("(" + sql + ")  a )T ");

                int startRowIndex = pageSize * (currentPageIndex - 1) + 1;
                int endRowIndex = startRowIndex + pageSize - 1;

                if (startRowIndex > 0)
                {
                    sbSql.Append(" WHERE T.RowNo >=" + startRowIndex.ToString() + " AND T.RowNo<=" + endRowIndex.ToString());
                }
                return Repository.GetDataTable(sbSql.ToString());
            }
            else
            {
                return new DataTable();
            }
        }

        public string GetPageSql(string sql, string orderField, string orderDirection, int pageIndex, int pageSize)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.AppendFormat(" SELECT  T.* FROM (SELECT ROW_NUMBER() OVER (ORDER BY {0} {1})  AS RowNo,COUNT(1) OVER (PARTITION BY 1) AS TotalCount,a.* FROM ({2})  a )T", orderField, orderDirection, sql);


            int startRowIndex = pageSize * (pageIndex - 1);
            int endRowIndex = startRowIndex + pageSize;

            sbSql.AppendFormat(" WHERE T.RowNo>{0} AND T.RowNo<={1}", startRowIndex, endRowIndex);

            return sbSql.ToString();
        }
    }
}
