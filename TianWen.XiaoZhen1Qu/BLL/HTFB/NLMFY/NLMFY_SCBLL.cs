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
    public class NLMFY_SCBLL : BaseBLL, INLMFY_SCBLL
    {
        public object SaveNLMFY_SCJBXX(JCXX jcxx, NLMFY_SCJBXX NLMFY_SCJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM NLMFY_SCJBXX WHERE ID='{0}'", NLMFY_SCJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        NLMFY_SCJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(NLMFY_SCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = NLMFY_SCJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        NLMFY_SCJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(NLMFY_SCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = NLMFY_SCJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("NLMFY_SCJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadNLMFY_SCJBXX(string ID)
        {
            try
            {
                NLMFY_SCJBXX NLMFY_SCJBXX = DAO.GetObjectByID<NLMFY_SCJBXX>(ID);
                if (NLMFY_SCJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(NLMFY_SCJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { NLMFY_SCJBXX = NLMFY_SCJBXX, BCMSString = BinaryHelper.BinaryToString(NLMFY_SCJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(NLMFY_SCJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("NLMFY_SCJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
