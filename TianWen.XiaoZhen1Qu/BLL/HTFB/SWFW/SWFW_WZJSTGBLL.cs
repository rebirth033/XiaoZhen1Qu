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
    public class SWFW_WZJSTGBLL : BaseBLL, ISWFW_WZJSTGBLL
    {
        public object SaveSWFW_WZJSTGJBXX(JCXX jcxx, SWFW_WZJSTGJBXX SWFW_WZJSTGJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_WZJSTGJBXX WHERE SWFW_WZJSTGJBXXID='{0}'", SWFW_WZJSTGJBXX.SWFW_WZJSTGJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_WZJSTGJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_WZJSTGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_WZJSTGJBXXID = SWFW_WZJSTGJBXX.SWFW_WZJSTGJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_WZJSTGJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_WZJSTGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_WZJSTGJBXXID = SWFW_WZJSTGJBXX.SWFW_WZJSTGJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_WZJSTGJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_WZJSTGJBXX(string SWFW_WZJSTGJBXXID)
        {
            try
            {
                SWFW_WZJSTGJBXX SWFW_WZJSTGJBXX = DAO.GetObjectByID<SWFW_WZJSTGJBXX>(SWFW_WZJSTGJBXXID);
                if (SWFW_WZJSTGJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_WZJSTGJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_WZJSTGJBXX = SWFW_WZJSTGJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_WZJSTGJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_WZJSTGJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_WZJSTGJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
