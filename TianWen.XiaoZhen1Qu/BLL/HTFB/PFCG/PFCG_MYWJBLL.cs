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
    public class PFCG_MYWJBLL : BaseBLL, IPFCG_MYWJBLL
    {
        public object SavePFCG_MYWJJBXX(JCXX jcxx, PFCG_MYWJJBXX PFCG_MYWJJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PFCG_MYWJJBXX WHERE PFCG_MYWJJBXXID='{0}'", PFCG_MYWJJBXX.PFCG_MYWJJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        PFCG_MYWJJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PFCG_MYWJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, PFCG_MYWJJBXXID = PFCG_MYWJJBXX.PFCG_MYWJJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        PFCG_MYWJJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PFCG_MYWJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, PFCG_MYWJJBXXID = PFCG_MYWJJBXX.PFCG_MYWJJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PFCG_MYWJJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPFCG_MYWJJBXX(string PFCG_MYWJJBXXID)
        {
            try
            {
                PFCG_MYWJJBXX PFCG_MYWJJBXX = DAO.GetObjectByID<PFCG_MYWJJBXX>(PFCG_MYWJJBXXID);
                if (PFCG_MYWJJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PFCG_MYWJJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PFCG_MYWJJBXX = PFCG_MYWJJBXX, BCMSString = BinaryHelper.BinaryToString(PFCG_MYWJJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PFCG_MYWJJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PFCG_MYWJJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
