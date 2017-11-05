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
    public class ES_QTES_ESSBBLL : BaseBLL, IES_QTES_ESSBBLL
    {
        public object SaveES_QTES_ESSBJBXX(JCXX jcxx, ES_QTES_ESSBJBXX ES_QTES_ESSBJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_QTES_ESSBJBXX WHERE ES_QTES_ESSBJBXXID='{0}'", ES_QTES_ESSBJBXX.ES_QTES_ESSBJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_QTES_ESSBJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_QTES_ESSBJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ES_QTES_ESSBJBXXID = ES_QTES_ESSBJBXX.ES_QTES_ESSBJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_QTES_ESSBJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_QTES_ESSBJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ES_QTES_ESSBJBXXID = ES_QTES_ESSBJBXX.ES_QTES_ESSBJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_QTES_ESSBJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_QTES_ESSBJBXX(string ES_QTES_ESSBJBXXID)
        {
            try
            {
                ES_QTES_ESSBJBXX ES_QTES_ESSBJBXX = DAO.GetObjectByID<ES_QTES_ESSBJBXX>(ES_QTES_ESSBJBXXID);
                if (ES_QTES_ESSBJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_QTES_ESSBJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_QTES_ESSBJBXX = ES_QTES_ESSBJBXX, BCMSString = BinaryHelper.BinaryToString(ES_QTES_ESSBJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_QTES_ESSBJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_QTES_ESSBJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
