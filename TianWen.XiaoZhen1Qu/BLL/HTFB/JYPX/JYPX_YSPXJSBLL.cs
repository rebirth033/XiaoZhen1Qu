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
    public class JYPX_YSPXJSBLL : BaseBLL, IJYPX_YSPXJSBLL
    {
        public object SaveJYPX_YSPXJSJBXX(JCXX jcxx, JYPX_YSPXJSJBXX JYPX_YSPXJSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM JYPX_YSPXJSJBXX WHERE JYPX_YSPXJSJBXXID='{0}'", JYPX_YSPXJSJBXX.JYPX_YSPXJSJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        JYPX_YSPXJSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(JYPX_YSPXJSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_YSPXJSJBXXID = JYPX_YSPXJSJBXX.JYPX_YSPXJSJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        JYPX_YSPXJSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(JYPX_YSPXJSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_YSPXJSJBXXID = JYPX_YSPXJSJBXX.JYPX_YSPXJSJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("JYPX_YSPXJSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadJYPX_YSPXJSJBXX(string JYPX_YSPXJSJBXXID)
        {
            try
            {
                JYPX_YSPXJSJBXX JYPX_YSPXJSJBXX = DAO.GetObjectByID<JYPX_YSPXJSJBXX>(JYPX_YSPXJSJBXXID);
                if (JYPX_YSPXJSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(JYPX_YSPXJSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { JYPX_YSPXJSJBXX = JYPX_YSPXJSJBXX, BCMSString = BinaryHelper.BinaryToString(JYPX_YSPXJSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(JYPX_YSPXJSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("JYPX_YSPXJSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
