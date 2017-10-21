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
    public class JYPX_PBPKBLL : BaseBLL, IJYPX_PBPKBLL
    {
        public object SaveJYPX_PBPKJBXX(JCXX jcxx, JYPX_PBPKJBXX JYPX_PBPKJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM JYPX_PBPKJBXX WHERE JYPX_PBPKJBXXID='{0}'", JYPX_PBPKJBXX.JYPX_PBPKJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        JYPX_PBPKJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(JYPX_PBPKJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_PBPKJBXXID = JYPX_PBPKJBXX.JYPX_PBPKJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        JYPX_PBPKJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(JYPX_PBPKJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_PBPKJBXXID = JYPX_PBPKJBXX.JYPX_PBPKJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("JYPX_PBPKJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadJYPX_PBPKJBXX(string JYPX_PBPKJBXXID)
        {
            try
            {
                JYPX_PBPKJBXX JYPX_PBPKJBXX = DAO.GetObjectByID<JYPX_PBPKJBXX>(JYPX_PBPKJBXXID);
                if (JYPX_PBPKJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(JYPX_PBPKJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { JYPX_PBPKJBXX = JYPX_PBPKJBXX, BCMSString = BinaryHelper.BinaryToString(JYPX_PBPKJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(JYPX_PBPKJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("JYPX_PBPKJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
