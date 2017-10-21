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
    public class NLMFY_CQYZBLL : BaseBLL, INLMFY_CQYZBLL
    {
        public object SaveNLMFY_CQYZJBXX(JCXX jcxx, NLMFY_CQYZJBXX NLMFY_CQYZJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM NLMFY_CQYZJBXX WHERE NLMFY_CQYZJBXXID='{0}'", NLMFY_CQYZJBXX.NLMFY_CQYZJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        NLMFY_CQYZJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(NLMFY_CQYZJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_CQYZJBXXID = NLMFY_CQYZJBXX.NLMFY_CQYZJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        NLMFY_CQYZJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(NLMFY_CQYZJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, NLMFY_CQYZJBXXID = NLMFY_CQYZJBXX.NLMFY_CQYZJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("NLMFY_CQYZJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadNLMFY_CQYZJBXX(string NLMFY_CQYZJBXXID)
        {
            try
            {
                NLMFY_CQYZJBXX NLMFY_CQYZJBXX = DAO.GetObjectByID<NLMFY_CQYZJBXX>(NLMFY_CQYZJBXXID);
                if (NLMFY_CQYZJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(NLMFY_CQYZJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { NLMFY_CQYZJBXX = NLMFY_CQYZJBXX, BCMSString = BinaryHelper.BinaryToString(NLMFY_CQYZJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(NLMFY_CQYZJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("NLMFY_CQYZJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
