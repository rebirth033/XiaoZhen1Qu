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
    public class ES_JDJJBG_ESJJBLL : BaseBLL, IES_JDJJBG_ESJJBLL
    {
        public object SaveES_JDJJBG_ESJJJBXX(JCXX jcxx, ES_JDJJBG_ESJJJBXX ES_JDJJBG_ESJJJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_JDJJBG_ESJJJBXX WHERE ID='{0}'", ES_JDJJBG_ESJJJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_JDJJBG_ESJJJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_JDJJBG_ESJJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_JDJJBG_ESJJJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_JDJJBG_ESJJJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_JDJJBG_ESJJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_JDJJBG_ESJJJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_JDJJBG_ESJJJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_JDJJBG_ESJJJBXX(string ID)
        {
            try
            {
                ES_JDJJBG_ESJJJBXX ES_JDJJBG_ESJJJBXX = DAO.GetObjectByID<ES_JDJJBG_ESJJJBXX>(ID);
                if (ES_JDJJBG_ESJJJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_JDJJBG_ESJJJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_JDJJBG_ESJJJBXX = ES_JDJJBG_ESJJJBXX, BCMSString = BinaryHelper.BinaryToString(ES_JDJJBG_ESJJJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_JDJJBG_ESJJJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_JDJJBG_ESJJJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
