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
    public class ES_JDJJBG_JJRYBLL : BaseBLL, IES_JDJJBG_JJRYBLL
    {
        public object SaveES_JDJJBG_JJRYJBXX(JCXX jcxx, ES_JDJJBG_JJRYJBXX ES_JDJJBG_JJRYJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_JDJJBG_JJRYJBXX WHERE ES_JDJJBG_JJRYJBXXID='{0}'", ES_JDJJBG_JJRYJBXX.ES_JDJJBG_JJRYJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_JDJJBG_JJRYJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_JDJJBG_JJRYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ES_JDJJBG_JJRYJBXXID = ES_JDJJBG_JJRYJBXX.ES_JDJJBG_JJRYJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_JDJJBG_JJRYJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_JDJJBG_JJRYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ES_JDJJBG_JJRYJBXXID = ES_JDJJBG_JJRYJBXX.ES_JDJJBG_JJRYJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_JDJJBG_JJRYJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_JDJJBG_JJRYJBXX(string ES_JDJJBG_JJRYJBXXID)
        {
            try
            {
                ES_JDJJBG_JJRYJBXX ES_JDJJBG_JJRYJBXX = DAO.GetObjectByID<ES_JDJJBG_JJRYJBXX>(ES_JDJJBG_JJRYJBXXID);
                if (ES_JDJJBG_JJRYJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_JDJJBG_JJRYJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_JDJJBG_JJRYJBXX = ES_JDJJBG_JJRYJBXX, BCMSString = BinaryHelper.BinaryToString(ES_JDJJBG_JJRYJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_JDJJBG_JJRYJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_JDJJBG_JJRYJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
