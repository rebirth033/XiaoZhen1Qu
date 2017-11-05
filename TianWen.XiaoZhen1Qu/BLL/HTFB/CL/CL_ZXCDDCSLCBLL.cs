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
    public class CL_ZXCDDCSLCBLL : BaseBLL, ICL_ZXCDDCSLCBLL
    {
        public object SaveCL_ZXCDDCSLCJBXX(JCXX jcxx, CL_ZXCDDCSLCJBXX CL_ZXCDDCSLCJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM CL_ZXCDDCSLCJBXX WHERE CL_ZXCDDCSLCJBXXID='{0}'", CL_ZXCDDCSLCJBXX.CL_ZXCDDCSLCJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        CL_ZXCDDCSLCJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(CL_ZXCDDCSLCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, CL_ZXCDDCSLCJBXXID = CL_ZXCDDCSLCJBXX.CL_ZXCDDCSLCJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        CL_ZXCDDCSLCJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(CL_ZXCDDCSLCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, CL_ZXCDDCSLCJBXXID = CL_ZXCDDCSLCJBXX.CL_ZXCDDCSLCJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("CL_ZXCDDCSLCJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadCL_ZXCDDCSLCJBXX(string CL_ZXCDDCSLCJBXXID)
        {
            try
            {
                CL_ZXCDDCSLCJBXX CL_ZXCDDCSLCJBXX = DAO.GetObjectByID<CL_ZXCDDCSLCJBXX>(CL_ZXCDDCSLCJBXXID);
                if (CL_ZXCDDCSLCJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(CL_ZXCDDCSLCJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { CL_ZXCDDCSLCJBXX = CL_ZXCDDCSLCJBXX, BCMSString = BinaryHelper.BinaryToString(CL_ZXCDDCSLCJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(CL_ZXCDDCSLCJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CL_ZXCDDCSLCJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
