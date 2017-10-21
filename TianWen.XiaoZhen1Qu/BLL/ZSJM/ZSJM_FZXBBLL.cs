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
    public class ZSJM_FZXBBLL : BaseBLL, IZSJM_FZXBBLL
    {
        public object SaveZSJM_FZXBJBXX(JCXX jcxx, ZSJM_FZXBJBXX ZSJM_FZXBJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ZSJM_FZXBJBXX WHERE ZSJM_FZXBJBXXID='{0}'", ZSJM_FZXBJBXX.ZSJM_FZXBJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ZSJM_FZXBJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ZSJM_FZXBJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_FZXBJBXXID = ZSJM_FZXBJBXX.ZSJM_FZXBJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ZSJM_FZXBJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ZSJM_FZXBJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_FZXBJBXXID = ZSJM_FZXBJBXX.ZSJM_FZXBJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ZSJM_FZXBJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadZSJM_FZXBJBXX(string ZSJM_FZXBJBXXID)
        {
            try
            {
                ZSJM_FZXBJBXX ZSJM_FZXBJBXX = DAO.GetObjectByID<ZSJM_FZXBJBXX>(ZSJM_FZXBJBXXID);
                if (ZSJM_FZXBJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ZSJM_FZXBJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ZSJM_FZXBJBXX = ZSJM_FZXBJBXX, BCMSString = BinaryHelper.BinaryToString(ZSJM_FZXBJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ZSJM_FZXBJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ZSJM_FZXBJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
