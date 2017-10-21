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
    public class SWFW_LPDZBLL : BaseBLL, ISWFW_LPDZBLL
    {
        public object SaveSWFW_LPDZJBXX(JCXX jcxx, SWFW_LPDZJBXX SWFW_LPDZJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_LPDZJBXX WHERE SWFW_LPDZJBXXID='{0}'", SWFW_LPDZJBXX.SWFW_LPDZJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_LPDZJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_LPDZJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_LPDZJBXXID = SWFW_LPDZJBXX.SWFW_LPDZJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_LPDZJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_LPDZJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_LPDZJBXXID = SWFW_LPDZJBXX.SWFW_LPDZJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_LPDZJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_LPDZJBXX(string SWFW_LPDZJBXXID)
        {
            try
            {
                SWFW_LPDZJBXX SWFW_LPDZJBXX = DAO.GetObjectByID<SWFW_LPDZJBXX>(SWFW_LPDZJBXXID);
                if (SWFW_LPDZJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_LPDZJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_LPDZJBXX = SWFW_LPDZJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_LPDZJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_LPDZJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_LPDZJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
