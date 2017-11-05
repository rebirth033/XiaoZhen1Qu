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
    public class ZSJM_SHFWBLL : BaseBLL, IZSJM_SHFWBLL
    {
        public object SaveZSJM_SHFWJBXX(JCXX jcxx, ZSJM_SHFWJBXX ZSJM_SHFWJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ZSJM_SHFWJBXX WHERE ZSJM_SHFWJBXXID='{0}'", ZSJM_SHFWJBXX.ZSJM_SHFWJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ZSJM_SHFWJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ZSJM_SHFWJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_SHFWJBXXID = ZSJM_SHFWJBXX.ZSJM_SHFWJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ZSJM_SHFWJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ZSJM_SHFWJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_SHFWJBXXID = ZSJM_SHFWJBXX.ZSJM_SHFWJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ZSJM_SHFWJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadZSJM_SHFWJBXX(string ZSJM_SHFWJBXXID)
        {
            try
            {
                ZSJM_SHFWJBXX ZSJM_SHFWJBXX = DAO.GetObjectByID<ZSJM_SHFWJBXX>(ZSJM_SHFWJBXXID);
                if (ZSJM_SHFWJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ZSJM_SHFWJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ZSJM_SHFWJBXX = ZSJM_SHFWJBXX, BCMSString = BinaryHelper.BinaryToString(ZSJM_SHFWJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ZSJM_SHFWJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ZSJM_SHFWJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
