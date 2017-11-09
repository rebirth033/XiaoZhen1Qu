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
    public class ES_MYFZMR_FZXMXBBLL : BaseBLL, IES_MYFZMR_FZXMXBBLL
    {
        public object SaveES_MYFZMR_FZXMXBJBXX(JCXX jcxx, ES_MYFZMR_FZXMXBJBXX ES_MYFZMR_FZXMXBJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_MYFZMR_FZXMXBJBXX WHERE ID='{0}'", ES_MYFZMR_FZXMXBJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ES_MYFZMR_FZXMXBJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_MYFZMR_FZXMXBJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_MYFZMR_FZXMXBJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ES_MYFZMR_FZXMXBJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_MYFZMR_FZXMXBJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_MYFZMR_FZXMXBJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_MYFZMR_FZXMXBJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_MYFZMR_FZXMXBJBXX(string ID)
        {
            try
            {
                ES_MYFZMR_FZXMXBJBXX ES_MYFZMR_FZXMXBJBXX = DAO.GetObjectByID<ES_MYFZMR_FZXMXBJBXX>(ID);
                if (ES_MYFZMR_FZXMXBJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_MYFZMR_FZXMXBJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_MYFZMR_FZXMXBJBXX = ES_MYFZMR_FZXMXBJBXX, BCMSString = BinaryHelper.BinaryToString(ES_MYFZMR_FZXMXBJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_MYFZMR_FZXMXBJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_MYFZMR_FZXMXBJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
