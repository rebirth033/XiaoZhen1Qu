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
    public class XXYL_TQTBLL : BaseBLL, IXXYL_TQTBLL
    {
        public object SaveXXYL_TQTJBXX(JCXX jcxx, XXYL_TQTJBXX XXYL_TQTJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM XXYL_TQTJBXX WHERE ID='{0}'", XXYL_TQTJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        XXYL_TQTJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(XXYL_TQTJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = XXYL_TQTJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        XXYL_TQTJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(XXYL_TQTJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = XXYL_TQTJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("XXYL_TQTJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadXXYL_TQTJBXX(string ID)
        {
            try
            {
                XXYL_TQTJBXX XXYL_TQTJBXX = DAO.GetObjectByID<XXYL_TQTJBXX>(ID);
                if (XXYL_TQTJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(XXYL_TQTJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { XXYL_TQTJBXX = XXYL_TQTJBXX, BCMSString = BinaryHelper.BinaryToString(XXYL_TQTJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(XXYL_TQTJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("XXYL_TQTJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
