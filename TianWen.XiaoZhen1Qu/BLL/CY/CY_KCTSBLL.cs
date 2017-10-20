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
    public class CY_KCTSBLL : BaseBLL, ICY_KCTSBLL
    {
        public object SaveCY_KCTSJBXX(JCXX jcxx, CY_KCTSJBXX CY_KCTSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM CY_KCTSJBXX WHERE CY_KCTSJBXXID='{0}'", CY_KCTSJBXX.CY_KCTSJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        CY_KCTSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(CY_KCTSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, CY_KCTSJBXXID = CY_KCTSJBXX.CY_KCTSJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        CY_KCTSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(CY_KCTSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, CY_KCTSJBXXID = CY_KCTSJBXX.CY_KCTSJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("CY_KCTSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadCY_KCTSJBXX(string CY_KCTSJBXXID)
        {
            try
            {
                CY_KCTSJBXX CY_KCTSJBXX = DAO.GetObjectByID<CY_KCTSJBXX>(CY_KCTSJBXXID);
                if (CY_KCTSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(CY_KCTSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { CY_KCTSJBXX = CY_KCTSJBXX, BCMSString = BinaryHelper.BinaryToString(CY_KCTSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(CY_KCTSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CY_KCTSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
