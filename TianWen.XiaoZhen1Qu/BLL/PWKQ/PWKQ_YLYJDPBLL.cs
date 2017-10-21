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
    public class PWKQ_YLYJDPBLL : BaseBLL, IPWKQ_YLYJDPBLL
    {
        public object SavePWKQ_YLYJDPJBXX(JCXX jcxx, PWKQ_YLYJDPJBXX PWKQ_YLYJDPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_YLYJDPJBXX WHERE PWKQ_YLYJDPJBXXID='{0}'", PWKQ_YLYJDPJBXX.PWKQ_YLYJDPJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        PWKQ_YLYJDPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_YLYJDPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, PWKQ_YLYJDPJBXXID = PWKQ_YLYJDPJBXX.PWKQ_YLYJDPJBXXID } };
                    }
                    else
                    {
                        PWKQ_YLYJDPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_YLYJDPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, PWKQ_YLYJDPJBXXID = PWKQ_YLYJDPJBXX.PWKQ_YLYJDPJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PWKQ_YLYJDPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPWKQ_YLYJDPJBXX(string PWKQ_YLYJDPJBXXID)
        {
            try
            {
                PWKQ_YLYJDPJBXX PWKQ_YLYJDPJBXX = DAO.GetObjectByID<PWKQ_YLYJDPJBXX>(PWKQ_YLYJDPJBXXID);
                if (PWKQ_YLYJDPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_YLYJDPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_YLYJDPJBXX = PWKQ_YLYJDPJBXX, BCMSString = BinaryHelper.BinaryToString(PWKQ_YLYJDPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_YLYJDPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PWKQ_YLYJDPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
