using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class CL_HCBLL : BaseBLL, ICL_HCBLL
    {
        public object SaveCL_HCJBXX(JCXX jcxx, CL_HCJBXX CL_HCJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM CL_HCJBXX WHERE CL_HCJBXXID='{0}'", CL_HCJBXX.CL_HCJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        CL_HCJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(CL_HCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, CL_HCJBXXID = CL_HCJBXX.CL_HCJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        CL_HCJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(CL_HCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, CL_HCJBXXID = CL_HCJBXX.CL_HCJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("CL_HCJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadCL_HCJBXX(string CL_HCJBXXID)
        {
            try
            {
                CL_HCJBXX CL_HCJBXX = DAO.GetObjectByID<CL_HCJBXX>(CL_HCJBXXID);
                if (CL_HCJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(CL_HCJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { CL_HCJBXX = CL_HCJBXX, BCMSString = BinaryHelper.BinaryToString(CL_HCJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(CL_HCJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CL_HCJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
