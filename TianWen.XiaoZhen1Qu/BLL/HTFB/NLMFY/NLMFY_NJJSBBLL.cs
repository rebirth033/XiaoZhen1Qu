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
    public class NLMFY_NJJSBBLL : BaseBLL, INLMFY_NJJSBBLL
    {
        public object SaveNLMFY_NJJSBJBXX(JCXX jcxx, NLMFY_NJJSBJBXX NLMFY_NJJSBJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM NLMFY_NJJSBJBXX WHERE NLMFY_NJJSBJBXXID='{0}'", NLMFY_NJJSBJBXX.NLMFY_NJJSBJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        NLMFY_NJJSBJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(NLMFY_NJJSBJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_NJJSBJBXXID = NLMFY_NJJSBJBXX.NLMFY_NJJSBJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        NLMFY_NJJSBJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(NLMFY_NJJSBJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_NJJSBJBXXID = NLMFY_NJJSBJBXX.NLMFY_NJJSBJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("NLMFY_NJJSBJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadNLMFY_NJJSBJBXX(string NLMFY_NJJSBJBXXID)
        {
            try
            {
                NLMFY_NJJSBJBXX NLMFY_NJJSBJBXX = DAO.GetObjectByID<NLMFY_NJJSBJBXX>(NLMFY_NJJSBJBXXID);
                if (NLMFY_NJJSBJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(NLMFY_NJJSBJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { NLMFY_NJJSBJBXX = NLMFY_NJJSBJBXX, BCMSString = BinaryHelper.BinaryToString(NLMFY_NJJSBJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(NLMFY_NJJSBJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("NLMFY_NJJSBJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
