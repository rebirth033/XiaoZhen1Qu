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
    public class JYPX_ZXXYDYBLL : BaseBLL, IJYPX_ZXXYDYBLL
    {
        public object SaveJYPX_ZXXYDYJBXX(JCXX jcxx, JYPX_ZXXYDYJBXX JYPX_ZXXYDYJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM JYPX_ZXXYDYJBXX WHERE JYPX_ZXXYDYJBXXID='{0}'", JYPX_ZXXYDYJBXX.JYPX_ZXXYDYJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        JYPX_ZXXYDYJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(JYPX_ZXXYDYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_ZXXYDYJBXXID = JYPX_ZXXYDYJBXX.JYPX_ZXXYDYJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        JYPX_ZXXYDYJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(JYPX_ZXXYDYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_ZXXYDYJBXXID = JYPX_ZXXYDYJBXX.JYPX_ZXXYDYJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("JYPX_ZXXYDYJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadJYPX_ZXXYDYJBXX(string JYPX_ZXXYDYJBXXID)
        {
            try
            {
                JYPX_ZXXYDYJBXX JYPX_ZXXYDYJBXX = DAO.GetObjectByID<JYPX_ZXXYDYJBXX>(JYPX_ZXXYDYJBXXID);
                if (JYPX_ZXXYDYJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(JYPX_ZXXYDYJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { JYPX_ZXXYDYJBXX = JYPX_ZXXYDYJBXX, BCMSString = BinaryHelper.BinaryToString(JYPX_ZXXYDYJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(JYPX_ZXXYDYJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("JYPX_ZXXYDYJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
