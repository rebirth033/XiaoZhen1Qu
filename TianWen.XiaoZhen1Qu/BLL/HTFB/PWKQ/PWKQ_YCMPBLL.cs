using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class PWKQ_YCMPBLL : BaseBLL, IPWKQ_YCMPBLL
    {
        public object SavePWKQ_YCMPJBXX(JCXX jcxx, PWKQ_YCMPJBXX PWKQ_YCMPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_YCMPJBXX WHERE PWKQ_YCMPJBXXID='{0}'", PWKQ_YCMPJBXX.PWKQ_YCMPJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        PWKQ_YCMPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_YCMPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, PWKQ_YCMPJBXXID = PWKQ_YCMPJBXX.PWKQ_YCMPJBXXID } };
                    }
                    else
                    {
                        PWKQ_YCMPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_YCMPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, PWKQ_YCMPJBXXID = PWKQ_YCMPJBXX.PWKQ_YCMPJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PWKQ_YCMPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPWKQ_YCMPJBXX(string PWKQ_YCMPJBXXID)
        {
            try
            {
                PWKQ_YCMPJBXX PWKQ_YCMPJBXX = DAO.GetObjectByID<PWKQ_YCMPJBXX>(PWKQ_YCMPJBXXID);
                if (PWKQ_YCMPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_YCMPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_YCMPJBXX = PWKQ_YCMPJBXX, BCMSString = BinaryHelper.BinaryToString(PWKQ_YCMPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_YCMPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PWKQ_YCMPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
