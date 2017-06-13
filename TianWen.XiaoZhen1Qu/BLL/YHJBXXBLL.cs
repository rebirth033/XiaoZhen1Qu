using System;
using System.Data;
using NHibernate;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.Framework.Log;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class YHJBXXBLL : BaseBLL, IYHJBXXBLL
    {
        public DataTable GetYHJBXXListByPage()
        {
            string sql = "select * from YHJBXX";
            return DAO.GetDataTable(sql);
        }

        public object CreateBasic(YHJBXX yhjbxx)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}'",yhjbxx.YHM));

            if (o1 != null && int.Parse(o1.ToString()) > 0)
            {
                return new { Result = EnResultType.Failed, Message = "用户名已存在!" };
            }

            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    DAO.Save(yhjbxx);
                    DAO.Repository.Session.Flush();
                    transaction.Commit();
                    return new { Result = EnResultType.Success, Message = "保存成功!", Value = new { YHID = yhjbxx.YHID } };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }
    }
}
