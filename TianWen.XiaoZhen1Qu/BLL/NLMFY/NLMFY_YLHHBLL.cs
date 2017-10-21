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
    public class NLMFY_YLHHBLL : BaseBLL, INLMFY_YLHHBLL
    {
        public object SaveNLMFY_YLHHJBXX(JCXX jcxx, NLMFY_YLHHJBXX NLMFY_YLHHJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM NLMFY_YLHHJBXX WHERE NLMFY_YLHHJBXXID='{0}'", NLMFY_YLHHJBXX.NLMFY_YLHHJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        NLMFY_YLHHJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(NLMFY_YLHHJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_YLHHJBXXID = NLMFY_YLHHJBXX.NLMFY_YLHHJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        NLMFY_YLHHJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(NLMFY_YLHHJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_YLHHJBXXID = NLMFY_YLHHJBXX.NLMFY_YLHHJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("NLMFY_YLHHJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadNLMFY_YLHHJBXX(string NLMFY_YLHHJBXXID)
        {
            try
            {
                NLMFY_YLHHJBXX NLMFY_YLHHJBXX = DAO.GetObjectByID<NLMFY_YLHHJBXX>(NLMFY_YLHHJBXXID);
                if (NLMFY_YLHHJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(NLMFY_YLHHJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { NLMFY_YLHHJBXX = NLMFY_YLHHJBXX, BCMSString = BinaryHelper.BinaryToString(NLMFY_YLHHJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(NLMFY_YLHHJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("NLMFY_YLHHJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
