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
    public class ES_SJSM_BJBDNBLL : BaseBLL, IES_SJSM_BJBDNBLL
    {
        public object SaveES_SJSM_BJBDNJBXX(JCXX jcxx, ES_SJSM_BJBDNJBXX ES_SJSM_BJBDNJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_SJSM_BJBDNJBXX WHERE ES_SJSM_BJBDNJBXXID='{0}'", ES_SJSM_BJBDNJBXX.ES_SJSM_BJBDNJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_SJSM_BJBDNJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_SJSM_BJBDNJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ES_SJSM_BJBDNJBXXID = ES_SJSM_BJBDNJBXX.ES_SJSM_BJBDNJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_SJSM_BJBDNJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_SJSM_BJBDNJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ES_SJSM_BJBDNJBXXID = ES_SJSM_BJBDNJBXX.ES_SJSM_BJBDNJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_SJSM_BJBDNJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_SJSM_BJBDNJBXX(string ES_SJSM_BJBDNJBXXID)
        {
            try
            {
                ES_SJSM_BJBDNJBXX ES_SJSM_BJBDNJBXX = DAO.GetObjectByID<ES_SJSM_BJBDNJBXX>(ES_SJSM_BJBDNJBXXID);
                if (ES_SJSM_BJBDNJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_SJSM_BJBDNJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_SJSM_BJBDNJBXX = ES_SJSM_BJBDNJBXX, BCMSString = BinaryHelper.BinaryToString(ES_SJSM_BJBDNJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_SJSM_BJBDNJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }

            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_SJSM_BJBDNJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
