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
    public class ES_WHYL_WTHWYQBLL : BaseBLL, IES_WHYL_WTHWYQBLL
    {
        public object SaveES_WHYL_WTHWYQJBXX(JCXX jcxx, ES_WHYL_WTHWYQJBXX ES_WHYL_WTHWYQJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_WHYL_WTHWYQJBXX WHERE ES_WHYL_WTHWYQJBXXID='{0}'", ES_WHYL_WTHWYQJBXX.ES_WHYL_WTHWYQJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_WHYL_WTHWYQJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_WHYL_WTHWYQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ES_WHYL_WTHWYQJBXXID = ES_WHYL_WTHWYQJBXX.ES_WHYL_WTHWYQJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_WHYL_WTHWYQJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_WHYL_WTHWYQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ES_WHYL_WTHWYQJBXXID = ES_WHYL_WTHWYQJBXX.ES_WHYL_WTHWYQJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_WHYL_WTHWYQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_WHYL_WTHWYQJBXX(string ES_WHYL_WTHWYQJBXXID)
        {
            try
            {
                ES_WHYL_WTHWYQJBXX ES_WHYL_WTHWYQJBXX = DAO.GetObjectByID<ES_WHYL_WTHWYQJBXX>(ES_WHYL_WTHWYQJBXXID);
                if (ES_WHYL_WTHWYQJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_WHYL_WTHWYQJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_WHYL_WTHWYQJBXX = ES_WHYL_WTHWYQJBXX, BCMSString = BinaryHelper.BinaryToString(ES_WHYL_WTHWYQJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_WHYL_WTHWYQJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_WHYL_WTHWYQJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
