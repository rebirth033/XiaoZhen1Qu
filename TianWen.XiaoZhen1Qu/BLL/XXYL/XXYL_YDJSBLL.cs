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
    public class XXYL_YDJSBLL : BaseBLL, IXXYL_YDJSBLL
    {
        public object SaveXXYL_YDJSJBXX(JCXX jcxx, XXYL_YDJSJBXX XXYL_YDJSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM XXYL_YDJSJBXX WHERE XXYL_YDJSJBXXID='{0}'", XXYL_YDJSJBXX.XXYL_YDJSJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        XXYL_YDJSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(XXYL_YDJSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, XXYL_YDJSJBXXID = XXYL_YDJSJBXX.XXYL_YDJSJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        XXYL_YDJSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(XXYL_YDJSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, XXYL_YDJSJBXXID = XXYL_YDJSJBXX.XXYL_YDJSJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("XXYL_YDJSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadXXYL_YDJSJBXX(string XXYL_YDJSJBXXID)
        {
            try
            {
                XXYL_YDJSJBXX XXYL_YDJSJBXX = DAO.GetObjectByID<XXYL_YDJSJBXX>(XXYL_YDJSJBXXID);
                if (XXYL_YDJSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(XXYL_YDJSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { XXYL_YDJSJBXX = XXYL_YDJSJBXX, BCMSString = BinaryHelper.BinaryToString(XXYL_YDJSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(XXYL_YDJSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("XXYL_YDJSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
