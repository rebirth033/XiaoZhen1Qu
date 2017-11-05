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
    public class NLMFY_DZWZMBLL : BaseBLL, INLMFY_DZWZMBLL
    {
        public object SaveNLMFY_DZWZMJBXX(JCXX jcxx, NLMFY_DZWZMJBXX NLMFY_DZWZMJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM NLMFY_DZWZMJBXX WHERE NLMFY_DZWZMJBXXID='{0}'", NLMFY_DZWZMJBXX.NLMFY_DZWZMJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        NLMFY_DZWZMJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(NLMFY_DZWZMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_DZWZMJBXXID = NLMFY_DZWZMJBXX.NLMFY_DZWZMJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        NLMFY_DZWZMJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(NLMFY_DZWZMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_DZWZMJBXXID = NLMFY_DZWZMJBXX.NLMFY_DZWZMJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("NLMFY_DZWZMJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadNLMFY_DZWZMJBXX(string NLMFY_DZWZMJBXXID)
        {
            try
            {
                NLMFY_DZWZMJBXX NLMFY_DZWZMJBXX = DAO.GetObjectByID<NLMFY_DZWZMJBXX>(NLMFY_DZWZMJBXXID);
                if (NLMFY_DZWZMJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(NLMFY_DZWZMJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { NLMFY_DZWZMJBXX = NLMFY_DZWZMJBXX, BCMSString = BinaryHelper.BinaryToString(NLMFY_DZWZMJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(NLMFY_DZWZMJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("NLMFY_DZWZMJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
