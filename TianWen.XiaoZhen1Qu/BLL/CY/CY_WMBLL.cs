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
    public class CY_WMBLL : BaseBLL, ICY_WMBLL
    {
        public object SaveCY_WMJBXX(JCXX jcxx, CY_WMJBXX CY_WMJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM CY_WMJBXX WHERE CY_WMJBXXID='{0}'", CY_WMJBXX.CY_WMJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        CY_WMJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(CY_WMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, CY_WMJBXXID = CY_WMJBXX.CY_WMJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        CY_WMJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(CY_WMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, CY_WMJBXXID = CY_WMJBXX.CY_WMJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("CY_WMJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadCY_WMJBXX(string CY_WMJBXXID)
        {
            try
            {
                CY_WMJBXX CY_WMJBXX = DAO.GetObjectByID<CY_WMJBXX>(CY_WMJBXXID);
                if (CY_WMJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(CY_WMJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { CY_WMJBXX = CY_WMJBXX, BCMSString = BinaryHelper.BinaryToString(CY_WMJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(CY_WMJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CY_WMJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
