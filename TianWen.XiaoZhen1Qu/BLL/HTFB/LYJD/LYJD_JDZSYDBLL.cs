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
    public class LYJD_JDZSYDBLL : BaseBLL, ILYJD_JDZSYDBLL
    {
        public object SaveLYJD_JDZSYDJBXX(JCXX jcxx, LYJD_JDZSYDJBXX LYJD_JDZSYDJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM LYJD_JDZSYDJBXX WHERE LYJD_JDZSYDJBXXID='{0}'", LYJD_JDZSYDJBXX.LYJD_JDZSYDJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        LYJD_JDZSYDJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(LYJD_JDZSYDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, LYJD_JDZSYDJBXXID = LYJD_JDZSYDJBXX.LYJD_JDZSYDJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        LYJD_JDZSYDJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(LYJD_JDZSYDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, LYJD_JDZSYDJBXXID = LYJD_JDZSYDJBXX.LYJD_JDZSYDJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("LYJD_JDZSYDJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadLYJD_JDZSYDJBXX(string LYJD_JDZSYDJBXXID)
        {
            try
            {
                LYJD_JDZSYDJBXX LYJD_JDZSYDJBXX = DAO.GetObjectByID<LYJD_JDZSYDJBXX>(LYJD_JDZSYDJBXXID);
                if (LYJD_JDZSYDJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(LYJD_JDZSYDJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { LYJD_JDZSYDJBXX = LYJD_JDZSYDJBXX, BCMSString = BinaryHelper.BinaryToString(LYJD_JDZSYDJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(LYJD_JDZSYDJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("LYJD_JDZSYDJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
