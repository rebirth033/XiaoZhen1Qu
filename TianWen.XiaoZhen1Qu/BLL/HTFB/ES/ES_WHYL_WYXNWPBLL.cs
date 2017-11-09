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
    public class ES_WHYL_WYXNWPBLL : BaseBLL, IES_WHYL_WYXNWPBLL
    {
        public object SaveES_WHYL_WYXNWPJBXX(JCXX jcxx, ES_WHYL_WYXNWPJBXX ES_WHYL_WYXNWPJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_WHYL_WYXNWPJBXX WHERE ID='{0}'", ES_WHYL_WYXNWPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_WHYL_WYXNWPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_WHYL_WYXNWPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_WHYL_WYXNWPJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_WHYL_WYXNWPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_WHYL_WYXNWPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_WHYL_WYXNWPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_WHYL_WYXNWPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_WHYL_WYXNWPJBXX(string ID)
        {
            try
            {
                ES_WHYL_WYXNWPJBXX ES_WHYL_WYXNWPJBXX = DAO.GetObjectByID<ES_WHYL_WYXNWPJBXX>(ID);
                if (ES_WHYL_WYXNWPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_WHYL_WYXNWPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_WHYL_WYXNWPJBXX = ES_WHYL_WYXNWPJBXX, BCMSString = BinaryHelper.BinaryToString(ES_WHYL_WYXNWPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_WHYL_WYXNWPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_WHYL_WYXNWPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
