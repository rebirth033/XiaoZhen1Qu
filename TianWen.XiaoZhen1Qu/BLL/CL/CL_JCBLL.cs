using System;
using System.Collections.Generic;
using System.Data;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class CL_JCBLL : BaseBLL, ICL_JCBLL
    {
        public object SaveCL_JCJBXX(JCXX jcxx, CL_JCJBXX CL_JCJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM CL_JCJBXX WHERE CL_JCJBXXID='{0}'", CL_JCJBXX.CL_JCJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        CL_JCJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(CL_JCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, CL_JCJBXXID = CL_JCJBXX.CL_JCJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        CL_JCJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(CL_JCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, CL_JCJBXXID = CL_JCJBXX.CL_JCJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("CL_JCJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadCL_JCJBXX(string CL_JCJBXXID)
        {
            try
            {
                CL_JCJBXX CL_JCJBXX = DAO.GetObjectByID<CL_JCJBXX>(CL_JCJBXXID);
                if (CL_JCJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(CL_JCJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { CL_JCJBXX = CL_JCJBXX, BCMSString = BinaryHelper.BinaryToString(CL_JCJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(CL_JCJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CL_JCJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
