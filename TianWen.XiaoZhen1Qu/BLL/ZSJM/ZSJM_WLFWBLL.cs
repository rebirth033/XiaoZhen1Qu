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
    public class ZSJM_WLFWBLL : BaseBLL, IZSJM_WLFWBLL
    {
        public object SaveZSJM_WLFWJBXX(JCXX jcxx, ZSJM_WLFWJBXX ZSJM_WLFWJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ZSJM_WLFWJBXX WHERE ZSJM_WLFWJBXXID='{0}'", ZSJM_WLFWJBXX.ZSJM_WLFWJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ZSJM_WLFWJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ZSJM_WLFWJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_WLFWJBXXID = ZSJM_WLFWJBXX.ZSJM_WLFWJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ZSJM_WLFWJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ZSJM_WLFWJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_WLFWJBXXID = ZSJM_WLFWJBXX.ZSJM_WLFWJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ZSJM_WLFWJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadZSJM_WLFWJBXX(string ZSJM_WLFWJBXXID)
        {
            try
            {
                ZSJM_WLFWJBXX ZSJM_WLFWJBXX = DAO.GetObjectByID<ZSJM_WLFWJBXX>(ZSJM_WLFWJBXXID);
                if (ZSJM_WLFWJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ZSJM_WLFWJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ZSJM_WLFWJBXX = ZSJM_WLFWJBXX, BCMSString = BinaryHelper.BinaryToString(ZSJM_WLFWJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ZSJM_WLFWJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ZSJM_WLFWJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
