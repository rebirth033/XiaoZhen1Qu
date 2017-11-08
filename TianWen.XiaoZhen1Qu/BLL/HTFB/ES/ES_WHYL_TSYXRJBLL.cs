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
    public class ES_WHYL_TSYXRJBLL : BaseBLL, IES_WHYL_TSYXRJBLL
    {
        public object SaveES_WHYL_TSYXRJJBXX(JCXX jcxx, ES_WHYL_TSYXRJJBXX ES_WHYL_TSYXRJJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_WHYL_TSYXRJJBXX WHERE ID='{0}'", ES_WHYL_TSYXRJJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_WHYL_TSYXRJJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_WHYL_TSYXRJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_WHYL_TSYXRJJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_WHYL_TSYXRJJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_WHYL_TSYXRJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_WHYL_TSYXRJJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_WHYL_TSYXRJJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_WHYL_TSYXRJJBXX(string ID)
        {
            try
            {
                ES_WHYL_TSYXRJJBXX ES_WHYL_TSYXRJJBXX = DAO.GetObjectByID<ES_WHYL_TSYXRJJBXX>(ID);
                if (ES_WHYL_TSYXRJJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_WHYL_TSYXRJJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_WHYL_TSYXRJJBXX = ES_WHYL_TSYXRJJBXX, BCMSString = BinaryHelper.BinaryToString(ES_WHYL_TSYXRJJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_WHYL_TSYXRJJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_WHYL_TSYXRJJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
