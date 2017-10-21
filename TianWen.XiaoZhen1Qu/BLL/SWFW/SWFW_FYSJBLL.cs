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
    public class SWFW_FYSJBLL : BaseBLL, ISWFW_FYSJBLL
    {
        public object SaveSWFW_FYSJJBXX(JCXX jcxx, SWFW_FYSJJBXX SWFW_FYSJJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_FYSJJBXX WHERE SWFW_FYSJJBXXID='{0}'", SWFW_FYSJJBXX.SWFW_FYSJJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_FYSJJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_FYSJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_FYSJJBXXID = SWFW_FYSJJBXX.SWFW_FYSJJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_FYSJJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_FYSJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_FYSJJBXXID = SWFW_FYSJJBXX.SWFW_FYSJJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_FYSJJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_FYSJJBXX(string SWFW_FYSJJBXXID)
        {
            try
            {
                SWFW_FYSJJBXX SWFW_FYSJJBXX = DAO.GetObjectByID<SWFW_FYSJJBXX>(SWFW_FYSJJBXXID);
                if (SWFW_FYSJJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_FYSJJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_FYSJJBXX = SWFW_FYSJJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_FYSJJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_FYSJJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_FYSJJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
