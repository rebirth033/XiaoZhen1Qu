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
    public class PFCG_FSXMBLL : BaseBLL, IPFCG_FSXMBLL
    {
        public object SavePFCG_FSXMJBXX(JCXX jcxx, PFCG_FSXMJBXX PFCG_FSXMJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PFCG_FSXMJBXX WHERE PFCG_FSXMJBXXID='{0}'", PFCG_FSXMJBXX.PFCG_FSXMJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        PFCG_FSXMJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PFCG_FSXMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, PFCG_FSXMJBXXID = PFCG_FSXMJBXX.PFCG_FSXMJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        PFCG_FSXMJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PFCG_FSXMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, PFCG_FSXMJBXXID = PFCG_FSXMJBXX.PFCG_FSXMJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PFCG_FSXMJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPFCG_FSXMJBXX(string PFCG_FSXMJBXXID)
        {
            try
            {
                PFCG_FSXMJBXX PFCG_FSXMJBXX = DAO.GetObjectByID<PFCG_FSXMJBXX>(PFCG_FSXMJBXXID);
                if (PFCG_FSXMJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PFCG_FSXMJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PFCG_FSXMJBXX = PFCG_FSXMJBXX, BCMSString = BinaryHelper.BinaryToString(PFCG_FSXMJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PFCG_FSXMJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PFCG_FSXMJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
