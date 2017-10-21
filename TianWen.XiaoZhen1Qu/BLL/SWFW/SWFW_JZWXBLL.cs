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
    public class SWFW_JZWXBLL : BaseBLL, ISWFW_JZWXBLL
    {
        public object SaveSWFW_JZWXJBXX(JCXX jcxx, SWFW_JZWXJBXX SWFW_JZWXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_JZWXJBXX WHERE SWFW_JZWXJBXXID='{0}'", SWFW_JZWXJBXX.SWFW_JZWXJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_JZWXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_JZWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_JZWXJBXXID = SWFW_JZWXJBXX.SWFW_JZWXJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_JZWXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_JZWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_JZWXJBXXID = SWFW_JZWXJBXX.SWFW_JZWXJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_JZWXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_JZWXJBXX(string SWFW_JZWXJBXXID)
        {
            try
            {
                SWFW_JZWXJBXX SWFW_JZWXJBXX = DAO.GetObjectByID<SWFW_JZWXJBXX>(SWFW_JZWXJBXXID);
                if (SWFW_JZWXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_JZWXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_JZWXJBXX = SWFW_JZWXJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_JZWXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_JZWXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_JZWXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
