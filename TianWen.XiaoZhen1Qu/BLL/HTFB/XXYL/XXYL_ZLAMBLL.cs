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
    public class XXYL_ZLAMBLL : BaseBLL, IXXYL_ZLAMBLL
    {
        public object SaveXXYL_ZLAMJBXX(JCXX jcxx, XXYL_ZLAMJBXX XXYL_ZLAMJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM XXYL_ZLAMJBXX WHERE XXYL_ZLAMJBXXID='{0}'", XXYL_ZLAMJBXX.XXYL_ZLAMJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        XXYL_ZLAMJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(XXYL_ZLAMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, XXYL_ZLAMJBXXID = XXYL_ZLAMJBXX.XXYL_ZLAMJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        XXYL_ZLAMJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(XXYL_ZLAMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, XXYL_ZLAMJBXXID = XXYL_ZLAMJBXX.XXYL_ZLAMJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("XXYL_ZLAMJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadXXYL_ZLAMJBXX(string XXYL_ZLAMJBXXID)
        {
            try
            {
                XXYL_ZLAMJBXX XXYL_ZLAMJBXX = DAO.GetObjectByID<XXYL_ZLAMJBXX>(XXYL_ZLAMJBXXID);
                if (XXYL_ZLAMJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(XXYL_ZLAMJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { XXYL_ZLAMJBXX = XXYL_ZLAMJBXX, BCMSString = BinaryHelper.BinaryToString(XXYL_ZLAMJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(XXYL_ZLAMJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("XXYL_ZLAMJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
