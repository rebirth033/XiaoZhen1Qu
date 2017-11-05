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
    public class SWFW_GGCMBLL : BaseBLL, ISWFW_GGCMBLL
    {
        public object SaveSWFW_GGCMJBXX(JCXX jcxx, SWFW_GGCMJBXX SWFW_GGCMJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_GGCMJBXX WHERE SWFW_GGCMJBXXID='{0}'", SWFW_GGCMJBXX.SWFW_GGCMJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_GGCMJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_GGCMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_GGCMJBXXID = SWFW_GGCMJBXX.SWFW_GGCMJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_GGCMJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_GGCMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_GGCMJBXXID = SWFW_GGCMJBXX.SWFW_GGCMJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_GGCMJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_GGCMJBXX(string SWFW_GGCMJBXXID)
        {
            try
            {
                SWFW_GGCMJBXX SWFW_GGCMJBXX = DAO.GetObjectByID<SWFW_GGCMJBXX>(SWFW_GGCMJBXXID);
                if (SWFW_GGCMJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_GGCMJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_GGCMJBXX = SWFW_GGCMJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_GGCMJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_GGCMJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_GGCMJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
