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
    public class PWKQ_QTKQBLL : BaseBLL, IPWKQ_QTKQBLL
    {
        public object SavePWKQ_QTKQJBXX(JCXX jcxx, PWKQ_QTKQJBXX PWKQ_QTKQJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_QTKQJBXX WHERE PWKQ_QTKQJBXXID='{0}'", PWKQ_QTKQJBXX.PWKQ_QTKQJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        PWKQ_QTKQJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_QTKQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, PWKQ_QTKQJBXXID = PWKQ_QTKQJBXX.PWKQ_QTKQJBXXID } };
                    }
                    else
                    {
                        PWKQ_QTKQJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_QTKQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, PWKQ_QTKQJBXXID = PWKQ_QTKQJBXX.PWKQ_QTKQJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PWKQ_QTKQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPWKQ_QTKQJBXX(string PWKQ_QTKQJBXXID)
        {
            try
            {
                PWKQ_QTKQJBXX PWKQ_QTKQJBXX = DAO.GetObjectByID<PWKQ_QTKQJBXX>(PWKQ_QTKQJBXXID);
                if (PWKQ_QTKQJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_QTKQJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_QTKQJBXX = PWKQ_QTKQJBXX, BCMSString = BinaryHelper.BinaryToString(PWKQ_QTKQJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_QTKQJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PWKQ_QTKQJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
