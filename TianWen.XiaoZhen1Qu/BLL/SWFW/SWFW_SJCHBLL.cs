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
    public class SWFW_SJCHBLL : BaseBLL, ISWFW_SJCHBLL
    {
        public object SaveSWFW_SJCHJBXX(JCXX jcxx, SWFW_SJCHJBXX SWFW_SJCHJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SWFW_SJCHJBXX WHERE SWFW_SJCHJBXXID='{0}'", SWFW_SJCHJBXX.SWFW_SJCHJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SWFW_SJCHJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SWFW_SJCHJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_SJCHJBXXID = SWFW_SJCHJBXX.SWFW_SJCHJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SWFW_SJCHJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SWFW_SJCHJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SWFW_SJCHJBXXID = SWFW_SJCHJBXX.SWFW_SJCHJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SWFW_SJCHJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSWFW_SJCHJBXX(string SWFW_SJCHJBXXID)
        {
            try
            {
                SWFW_SJCHJBXX SWFW_SJCHJBXX = DAO.GetObjectByID<SWFW_SJCHJBXX>(SWFW_SJCHJBXXID);
                if (SWFW_SJCHJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SWFW_SJCHJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SWFW_SJCHJBXX = SWFW_SJCHJBXX, BCMSString = BinaryHelper.BinaryToString(SWFW_SJCHJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SWFW_SJCHJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SWFW_SJCHJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
