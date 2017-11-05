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
    public class NLMFY_SLSYBLL : BaseBLL, INLMFY_SLSYBLL
    {
        public object SaveNLMFY_SLSYJBXX(JCXX jcxx, NLMFY_SLSYJBXX NLMFY_SLSYJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM NLMFY_SLSYJBXX WHERE NLMFY_SLSYJBXXID='{0}'", NLMFY_SLSYJBXX.NLMFY_SLSYJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        NLMFY_SLSYJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(NLMFY_SLSYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_SLSYJBXXID = NLMFY_SLSYJBXX.NLMFY_SLSYJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        NLMFY_SLSYJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(NLMFY_SLSYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_SLSYJBXXID = NLMFY_SLSYJBXX.NLMFY_SLSYJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("NLMFY_SLSYJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadNLMFY_SLSYJBXX(string NLMFY_SLSYJBXXID)
        {
            try
            {
                NLMFY_SLSYJBXX NLMFY_SLSYJBXX = DAO.GetObjectByID<NLMFY_SLSYJBXX>(NLMFY_SLSYJBXXID);
                if (NLMFY_SLSYJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(NLMFY_SLSYJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { NLMFY_SLSYJBXX = NLMFY_SLSYJBXX, BCMSString = BinaryHelper.BinaryToString(NLMFY_SLSYJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(NLMFY_SLSYJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("NLMFY_SLSYJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
