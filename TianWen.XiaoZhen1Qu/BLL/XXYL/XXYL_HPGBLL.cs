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
    public class XXYL_HPGBLL : BaseBLL, IXXYL_HPGBLL
    {
        public object SaveXXYL_HPGJBXX(JCXX jcxx, XXYL_HPGJBXX XXYL_HPGJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM XXYL_HPGJBXX WHERE XXYL_HPGJBXXID='{0}'", XXYL_HPGJBXX.XXYL_HPGJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        XXYL_HPGJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(XXYL_HPGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, XXYL_HPGJBXXID = XXYL_HPGJBXX.XXYL_HPGJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        XXYL_HPGJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(XXYL_HPGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, XXYL_HPGJBXXID = XXYL_HPGJBXX.XXYL_HPGJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("XXYL_HPGJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadXXYL_HPGJBXX(string XXYL_HPGJBXXID)
        {
            try
            {
                XXYL_HPGJBXX XXYL_HPGJBXX = DAO.GetObjectByID<XXYL_HPGJBXX>(XXYL_HPGJBXXID);
                if (XXYL_HPGJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(XXYL_HPGJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { XXYL_HPGJBXX = XXYL_HPGJBXX, BCMSString = BinaryHelper.BinaryToString(XXYL_HPGJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(XXYL_HPGJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("XXYL_HPGJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
