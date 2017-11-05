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
    public class ZSJM_LPXSPBLL : BaseBLL, IZSJM_LPXSPBLL
    {
        public object SaveZSJM_LPXSPJBXX(JCXX jcxx, ZSJM_LPXSPJBXX ZSJM_LPXSPJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ZSJM_LPXSPJBXX WHERE ZSJM_LPXSPJBXXID='{0}'", ZSJM_LPXSPJBXX.ZSJM_LPXSPJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ZSJM_LPXSPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ZSJM_LPXSPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_LPXSPJBXXID = ZSJM_LPXSPJBXX.ZSJM_LPXSPJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ZSJM_LPXSPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ZSJM_LPXSPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_LPXSPJBXXID = ZSJM_LPXSPJBXX.ZSJM_LPXSPJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ZSJM_LPXSPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadZSJM_LPXSPJBXX(string ZSJM_LPXSPJBXXID)
        {
            try
            {
                ZSJM_LPXSPJBXX ZSJM_LPXSPJBXX = DAO.GetObjectByID<ZSJM_LPXSPJBXX>(ZSJM_LPXSPJBXXID);
                if (ZSJM_LPXSPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ZSJM_LPXSPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ZSJM_LPXSPJBXX = ZSJM_LPXSPJBXX, BCMSString = BinaryHelper.BinaryToString(ZSJM_LPXSPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ZSJM_LPXSPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ZSJM_LPXSPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
