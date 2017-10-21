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
    public class NLMFY_NCPJGBLL : BaseBLL, INLMFY_NCPJGBLL
    {
        public object SaveNLMFY_NCPJGJBXX(JCXX jcxx, NLMFY_NCPJGJBXX NLMFY_NCPJGJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM NLMFY_NCPJGJBXX WHERE NLMFY_NCPJGJBXXID='{0}'", NLMFY_NCPJGJBXX.NLMFY_NCPJGJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        NLMFY_NCPJGJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(NLMFY_NCPJGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_NCPJGJBXXID = NLMFY_NCPJGJBXX.NLMFY_NCPJGJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        NLMFY_NCPJGJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(NLMFY_NCPJGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_NCPJGJBXXID = NLMFY_NCPJGJBXX.NLMFY_NCPJGJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("NLMFY_NCPJGJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadNLMFY_NCPJGJBXX(string NLMFY_NCPJGJBXXID)
        {
            try
            {
                NLMFY_NCPJGJBXX NLMFY_NCPJGJBXX = DAO.GetObjectByID<NLMFY_NCPJGJBXX>(NLMFY_NCPJGJBXXID);
                if (NLMFY_NCPJGJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(NLMFY_NCPJGJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { NLMFY_NCPJGJBXX = NLMFY_NCPJGJBXX, BCMSString = BinaryHelper.BinaryToString(NLMFY_NCPJGJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(NLMFY_NCPJGJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("NLMFY_NCPJGJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
