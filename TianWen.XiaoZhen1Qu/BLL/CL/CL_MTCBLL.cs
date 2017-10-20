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
    public class CL_MTCBLL : BaseBLL, ICL_MTCBLL
    {
        public object SaveCL_MTCJBXX(JCXX jcxx, CL_MTCJBXX CL_MTCJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM CL_MTCJBXX WHERE CL_MTCJBXXID='{0}'", CL_MTCJBXX.CL_MTCJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        CL_MTCJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(CL_MTCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, CL_MTCJBXXID = CL_MTCJBXX.CL_MTCJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        CL_MTCJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(CL_MTCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, CL_MTCJBXXID = CL_MTCJBXX.CL_MTCJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("CL_MTCJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadCL_MTCJBXX(string CL_MTCJBXXID)
        {
            try
            {
                CL_MTCJBXX CL_MTCJBXX = DAO.GetObjectByID<CL_MTCJBXX>(CL_MTCJBXXID);
                if (CL_MTCJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(CL_MTCJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { CL_MTCJBXX = CL_MTCJBXX, BCMSString = BinaryHelper.BinaryToString(CL_MTCJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(CL_MTCJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CL_MTCJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
