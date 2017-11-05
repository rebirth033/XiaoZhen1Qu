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
    public class SWFW_CWKJPGBLL : BaseBLL, ISWFW_CWKJPGBLL
    {
        public object SaveSWFW_CWKJPGJBXX(JCXX jcxx, SWFW_CWKJPGJBXX SWFW_CWKJPGJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_CWKJPGJBXX WHERE SWFW_CWKJPGJBXXID='{0}'", SWFW_CWKJPGJBXX.SWFW_CWKJPGJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_CWKJPGJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_CWKJPGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_CWKJPGJBXXID = SWFW_CWKJPGJBXX.SWFW_CWKJPGJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_CWKJPGJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_CWKJPGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_CWKJPGJBXXID = SWFW_CWKJPGJBXX.SWFW_CWKJPGJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_CWKJPGJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_CWKJPGJBXX(string SWFW_CWKJPGJBXXID)
        {
            try
            {
                SWFW_CWKJPGJBXX SWFW_CWKJPGJBXX = DAO.GetObjectByID<SWFW_CWKJPGJBXX>(SWFW_CWKJPGJBXXID);
                if (SWFW_CWKJPGJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_CWKJPGJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_CWKJPGJBXX = SWFW_CWKJPGJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_CWKJPGJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_CWKJPGJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_CWKJPGJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
