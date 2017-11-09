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
    public class PFCG_FZBLBLL : BaseBLL, IPFCG_FZBLBLL
    {
        public object SavePFCG_FZBLJBXX(JCXX jcxx, PFCG_FZBLJBXX PFCG_FZBLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PFCG_FZBLJBXX WHERE ID='{0}'", PFCG_FZBLJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        PFCG_FZBLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PFCG_FZBLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PFCG_FZBLJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        PFCG_FZBLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PFCG_FZBLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PFCG_FZBLJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PFCG_FZBLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPFCG_FZBLJBXX(string ID)
        {
            try
            {
                PFCG_FZBLJBXX PFCG_FZBLJBXX = DAO.GetObjectByID<PFCG_FZBLJBXX>(ID);
                if (PFCG_FZBLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PFCG_FZBLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PFCG_FZBLJBXX = PFCG_FZBLJBXX, BCMSString = BinaryHelper.BinaryToString(PFCG_FZBLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PFCG_FZBLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PFCG_FZBLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
