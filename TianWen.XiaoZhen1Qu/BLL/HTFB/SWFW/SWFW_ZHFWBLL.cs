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
    public class SWFW_ZHFWBLL : BaseBLL, ISWFW_ZHFWBLL
    {
        public object SaveSWFW_ZHFWJBXX(JCXX jcxx, SWFW_ZHFWJBXX SWFW_ZHFWJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_ZHFWJBXX WHERE SWFW_ZHFWJBXXID='{0}'", SWFW_ZHFWJBXX.SWFW_ZHFWJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_ZHFWJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_ZHFWJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_ZHFWJBXXID = SWFW_ZHFWJBXX.SWFW_ZHFWJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_ZHFWJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_ZHFWJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_ZHFWJBXXID = SWFW_ZHFWJBXX.SWFW_ZHFWJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_ZHFWJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_ZHFWJBXX(string SWFW_ZHFWJBXXID)
        {
            try
            {
                SWFW_ZHFWJBXX SWFW_ZHFWJBXX = DAO.GetObjectByID<SWFW_ZHFWJBXX>(SWFW_ZHFWJBXXID);
                if (SWFW_ZHFWJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_ZHFWJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_ZHFWJBXX = SWFW_ZHFWJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_ZHFWJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_ZHFWJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_ZHFWJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
