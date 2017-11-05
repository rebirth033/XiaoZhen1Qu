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
    public class SWFW_HYWLBLL : BaseBLL, ISWFW_HYWLBLL
    {
        public object SaveSWFW_HYWLJBXX(JCXX jcxx, SWFW_HYWLJBXX SWFW_HYWLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_HYWLJBXX WHERE SWFW_HYWLJBXXID='{0}'", SWFW_HYWLJBXX.SWFW_HYWLJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_HYWLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_HYWLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_HYWLJBXXID = SWFW_HYWLJBXX.SWFW_HYWLJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_HYWLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_HYWLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_HYWLJBXXID = SWFW_HYWLJBXX.SWFW_HYWLJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_HYWLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_HYWLJBXX(string SWFW_HYWLJBXXID)
        {
            try
            {
                SWFW_HYWLJBXX SWFW_HYWLJBXX = DAO.GetObjectByID<SWFW_HYWLJBXX>(SWFW_HYWLJBXXID);
                if (SWFW_HYWLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_HYWLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_HYWLJBXX = SWFW_HYWLJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_HYWLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_HYWLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_HYWLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
