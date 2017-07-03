using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class FWCZJBXXBLL : BaseBLL, IFWCZJBXXBLL
    {
        public object SaveFWCZJBXX(FWCZJBXX fwczjbxx)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM FWCZJBXX WHERE FWCZID='{0}'", fwczjbxx.FWCZID));

            if (o1 != null && int.Parse(o1.ToString()) > 0)
            {
                return new { Result = EnResultType.Success, Message = "已存在!", Value = new { FWCZID = fwczjbxx.FWCZID } };
            }
            else
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        DAO.Save(fwczjbxx);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "保存成功!", Value = new { FWCZID = fwczjbxx.FWCZID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("YHJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                        return new
                        {
                            Result = EnResultType.Failed,
                            Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                            Type = 3
                        };
                    }
                }
            }
        }
        
    }
}
