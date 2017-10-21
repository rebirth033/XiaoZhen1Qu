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
    public class SWFW_BGSBWXBLL : BaseBLL, ISWFW_BGSBWXBLL
    {
        public object SaveSWFW_BGSBWXJBXX(JCXX jcxx, SWFW_BGSBWXJBXX SWFW_BGSBWXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_BGSBWXJBXX WHERE SWFW_BGSBWXJBXXID='{0}'", SWFW_BGSBWXJBXX.SWFW_BGSBWXJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_BGSBWXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_BGSBWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_BGSBWXJBXXID = SWFW_BGSBWXJBXX.SWFW_BGSBWXJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_BGSBWXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_BGSBWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_BGSBWXJBXXID = SWFW_BGSBWXJBXX.SWFW_BGSBWXJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_BGSBWXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_BGSBWXJBXX(string SWFW_BGSBWXJBXXID)
        {
            try
            {
                SWFW_BGSBWXJBXX SWFW_BGSBWXJBXX = DAO.GetObjectByID<SWFW_BGSBWXJBXX>(SWFW_BGSBWXJBXXID);
                if (SWFW_BGSBWXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_BGSBWXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_BGSBWXJBXX = SWFW_BGSBWXJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_BGSBWXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_BGSBWXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_BGSBWXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
