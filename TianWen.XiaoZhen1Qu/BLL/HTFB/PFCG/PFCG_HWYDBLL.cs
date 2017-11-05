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
    public class PFCG_HWYDBLL : BaseBLL, IPFCG_HWYDBLL
    {
        public object SavePFCG_HWYDJBXX(JCXX jcxx, PFCG_HWYDJBXX PFCG_HWYDJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PFCG_HWYDJBXX WHERE PFCG_HWYDJBXXID='{0}'", PFCG_HWYDJBXX.PFCG_HWYDJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        PFCG_HWYDJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PFCG_HWYDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, PFCG_HWYDJBXXID = PFCG_HWYDJBXX.PFCG_HWYDJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        PFCG_HWYDJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PFCG_HWYDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, PFCG_HWYDJBXXID = PFCG_HWYDJBXX.PFCG_HWYDJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PFCG_HWYDJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPFCG_HWYDJBXX(string PFCG_HWYDJBXXID)
        {
            try
            {
                PFCG_HWYDJBXX PFCG_HWYDJBXX = DAO.GetObjectByID<PFCG_HWYDJBXX>(PFCG_HWYDJBXXID);
                if (PFCG_HWYDJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PFCG_HWYDJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PFCG_HWYDJBXX = PFCG_HWYDJBXX, BCMSString = BinaryHelper.BinaryToString(PFCG_HWYDJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PFCG_HWYDJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PFCG_HWYDJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
