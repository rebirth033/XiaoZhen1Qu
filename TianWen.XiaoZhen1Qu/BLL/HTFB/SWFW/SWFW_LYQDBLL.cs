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
    public class SWFW_LYQDBLL : BaseBLL, ISWFW_LYQDBLL
    {
        public object SaveSWFW_LYQDJBXX(JCXX jcxx, SWFW_LYQDJBXX SWFW_LYQDJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_LYQDJBXX WHERE SWFW_LYQDJBXXID='{0}'", SWFW_LYQDJBXX.SWFW_LYQDJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_LYQDJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_LYQDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_LYQDJBXXID = SWFW_LYQDJBXX.SWFW_LYQDJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_LYQDJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_LYQDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_LYQDJBXXID = SWFW_LYQDJBXX.SWFW_LYQDJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_LYQDJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_LYQDJBXX(string SWFW_LYQDJBXXID)
        {
            try
            {
                SWFW_LYQDJBXX SWFW_LYQDJBXX = DAO.GetObjectByID<SWFW_LYQDJBXX>(SWFW_LYQDJBXXID);
                if (SWFW_LYQDJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_LYQDJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_LYQDJBXX = SWFW_LYQDJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_LYQDJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_LYQDJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_LYQDJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
