using System.Web.Mvc;
using TianWen.Nhibernate.TianWen.Nhibernate.DataSource;
using TianWen.Nhibernate.TianWen.Nhibernate.Repository;

namespace TianWen.Framework.Common.Attributes
{
    public class TransactionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (this.IsOpen)
            {
                if (string.IsNullOrEmpty(this.DbName))
                {
                    foreach (DataSource source in DataSourceManager.getDataSourceList())
                    {
                        DbFactory.Instance.GetRepository(source.SourceName).Commit();
                    }
                }
                else
                {
                    DbFactory.Instance.GetRepository(this.DbName).Commit();
                }
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (this.IsOpen)
            {
                if (string.IsNullOrEmpty(this.DbName))
                {
                    foreach (DataSource source in DataSourceManager.getDataSourceList())
                    {
                        DbFactory.Instance.GetRepository(source.SourceName).BeginTransaction();
                    }
                }
                else
                {
                    DbFactory.Instance.GetRepository(this.DbName).BeginTransaction();
                }
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        public string DbName { get; set; }

        public bool IsOpen { get; set; }
    }
}

