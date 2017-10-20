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
    public class ES_SJSM_SMCPBLL : BaseBLL, IES_SJSM_SMCPBLL
    {
        public object SaveES_SJSM_SMCPJBXX(JCXX jcxx, ES_SJSM_SMCPJBXX ES_SJSM_SMCPJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_SJSM_SMCPJBXX WHERE ES_SJSM_SMCPJBXXID='{0}'", ES_SJSM_SMCPJBXX.ES_SJSM_SMCPJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_SJSM_SMCPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_SJSM_SMCPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ES_SJSM_SMCPJBXXID = ES_SJSM_SMCPJBXX.ES_SJSM_SMCPJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_SJSM_SMCPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_SJSM_SMCPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ES_SJSM_SMCPJBXXID = ES_SJSM_SMCPJBXX.ES_SJSM_SMCPJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_SJSM_SMCPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_SJSM_SMCPJBXX(string ES_SJSM_SMCPJBXXID)
        {
            try
            {
                ES_SJSM_SMCPJBXX ES_SJSM_SMCPJBXX = DAO.GetObjectByID<ES_SJSM_SMCPJBXX>(ES_SJSM_SMCPJBXXID);
                if (ES_SJSM_SMCPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_SJSM_SMCPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_SJSM_SMCPJBXX = ES_SJSM_SMCPJBXX, BCMSString = BinaryHelper.BinaryToString(ES_SJSM_SMCPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_SJSM_SMCPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_SJSM_SMCPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
