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
    public class SWFW_SBZLBLL : BaseBLL, ISWFW_SBZLBLL
    {
        public object SaveSWFW_SBZLJBXX(JCXX jcxx, SWFW_SBZLJBXX SWFW_SBZLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_SBZLJBXX WHERE SWFW_SBZLJBXXID='{0}'", SWFW_SBZLJBXX.SWFW_SBZLJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_SBZLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_SBZLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_SBZLJBXXID = SWFW_SBZLJBXX.SWFW_SBZLJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_SBZLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_SBZLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_SBZLJBXXID = SWFW_SBZLJBXX.SWFW_SBZLJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_SBZLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_SBZLJBXX(string SWFW_SBZLJBXXID)
        {
            try
            {
                SWFW_SBZLJBXX SWFW_SBZLJBXX = DAO.GetObjectByID<SWFW_SBZLJBXX>(SWFW_SBZLJBXXID);
                if (SWFW_SBZLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_SBZLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_SBZLJBXX = SWFW_SBZLJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_SBZLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_SBZLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_SBZLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
