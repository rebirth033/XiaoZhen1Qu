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
    public class ZSJM_TSBLL : BaseBLL, IZSJM_TSBLL
    {
        public object SaveZSJM_TSJBXX(JCXX jcxx, ZSJM_TSJBXX ZSJM_TSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ZSJM_TSJBXX WHERE ZSJM_TSJBXXID='{0}'", ZSJM_TSJBXX.ZSJM_TSJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ZSJM_TSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ZSJM_TSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_TSJBXXID = ZSJM_TSJBXX.ZSJM_TSJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ZSJM_TSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ZSJM_TSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_TSJBXXID = ZSJM_TSJBXX.ZSJM_TSJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ZSJM_TSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadZSJM_TSJBXX(string ZSJM_TSJBXXID)
        {
            try
            {
                ZSJM_TSJBXX ZSJM_TSJBXX = DAO.GetObjectByID<ZSJM_TSJBXX>(ZSJM_TSJBXXID);
                if (ZSJM_TSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ZSJM_TSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ZSJM_TSJBXX = ZSJM_TSJBXX, BCMSString = BinaryHelper.BinaryToString(ZSJM_TSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ZSJM_TSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ZSJM_TSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
