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
    public class ZSJM_JXBLL : BaseBLL, IZSJM_JXBLL
    {
        public object SaveZSJM_JXJBXX(JCXX jcxx, ZSJM_JXJBXX ZSJM_JXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ZSJM_JXJBXX WHERE ZSJM_JXJBXXID='{0}'", ZSJM_JXJBXX.ZSJM_JXJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ZSJM_JXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ZSJM_JXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_JXJBXXID = ZSJM_JXJBXX.ZSJM_JXJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ZSJM_JXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ZSJM_JXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_JXJBXXID = ZSJM_JXJBXX.ZSJM_JXJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ZSJM_JXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadZSJM_JXJBXX(string ZSJM_JXJBXXID)
        {
            try
            {
                ZSJM_JXJBXX ZSJM_JXJBXX = DAO.GetObjectByID<ZSJM_JXJBXX>(ZSJM_JXJBXXID);
                if (ZSJM_JXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ZSJM_JXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ZSJM_JXJBXX = ZSJM_JXJBXX, BCMSString = BinaryHelper.BinaryToString(ZSJM_JXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ZSJM_JXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ZSJM_JXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
