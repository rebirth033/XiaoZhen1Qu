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
    public class SWFW_ZXFWBLL : BaseBLL, ISWFW_ZXFWBLL
    {
        public object SaveSWFW_ZXFWJBXX(JCXX jcxx, SWFW_ZXFWJBXX SWFW_ZXFWJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_ZXFWJBXX WHERE SWFW_ZXFWJBXXID='{0}'", SWFW_ZXFWJBXX.SWFW_ZXFWJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_ZXFWJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_ZXFWJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_ZXFWJBXXID = SWFW_ZXFWJBXX.SWFW_ZXFWJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_ZXFWJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_ZXFWJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_ZXFWJBXXID = SWFW_ZXFWJBXX.SWFW_ZXFWJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_ZXFWJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_ZXFWJBXX(string SWFW_ZXFWJBXXID)
        {
            try
            {
                SWFW_ZXFWJBXX SWFW_ZXFWJBXX = DAO.GetObjectByID<SWFW_ZXFWJBXX>(SWFW_ZXFWJBXXID);
                if (SWFW_ZXFWJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_ZXFWJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_ZXFWJBXX = SWFW_ZXFWJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_ZXFWJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_ZXFWJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_ZXFWJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
