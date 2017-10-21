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
    public class SWFW_YSBZBLL : BaseBLL, ISWFW_YSBZBLL
    {
        public object SaveSWFW_YSBZJBXX(JCXX jcxx, SWFW_YSBZJBXX SWFW_YSBZJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_YSBZJBXX WHERE SWFW_YSBZJBXXID='{0}'", SWFW_YSBZJBXX.SWFW_YSBZJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_YSBZJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_YSBZJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_YSBZJBXXID = SWFW_YSBZJBXX.SWFW_YSBZJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_YSBZJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_YSBZJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_YSBZJBXXID = SWFW_YSBZJBXX.SWFW_YSBZJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_YSBZJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_YSBZJBXX(string SWFW_YSBZJBXXID)
        {
            try
            {
                SWFW_YSBZJBXX SWFW_YSBZJBXX = DAO.GetObjectByID<SWFW_YSBZJBXX>(SWFW_YSBZJBXXID);
                if (SWFW_YSBZJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_YSBZJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_YSBZJBXX = SWFW_YSBZJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_YSBZJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_YSBZJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_YSBZJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
