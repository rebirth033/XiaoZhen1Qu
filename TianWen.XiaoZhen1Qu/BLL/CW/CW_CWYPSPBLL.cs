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
    public class CW_CWYPSPBLL : BaseBLL, ICW_CWYPSPBLL
    {
        public object SaveCW_CWYPSPJBXX(JCXX jcxx, CW_CWYPSPJBXX CW_CWYPSPJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM CW_CWYPSPJBXX WHERE CW_CWYPSPJBXXID='{0}'", CW_CWYPSPJBXX.CW_CWYPSPJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        CW_CWYPSPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(CW_CWYPSPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, CW_CWYPSPJBXXID = CW_CWYPSPJBXX.CW_CWYPSPJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        CW_CWYPSPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(CW_CWYPSPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, CW_CWYPSPJBXXID = CW_CWYPSPJBXX.CW_CWYPSPJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("CW_CWYPSPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadCW_CWYPSPJBXX(string CW_CWYPSPJBXXID)
        {
            try
            {
                CW_CWYPSPJBXX CW_CWYPSPJBXX = DAO.GetObjectByID<CW_CWYPSPJBXX>(CW_CWYPSPJBXXID);
                if (CW_CWYPSPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(CW_CWYPSPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { CW_CWYPSPJBXX = CW_CWYPSPJBXX, BCMSString = BinaryHelper.BinaryToString(CW_CWYPSPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(CW_CWYPSPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("CW_CWYPSPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
