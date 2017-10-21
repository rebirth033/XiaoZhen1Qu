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
    public class HQSY_ZBSSBLL : BaseBLL, IHQSY_ZBSSBLL
    {
        public object SaveHQSY_ZBSSJBXX(JCXX jcxx, HQSY_ZBSSJBXX HQSY_ZBSSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM HQSY_ZBSSJBXX WHERE HQSY_ZBSSJBXXID='{0}'", HQSY_ZBSSJBXX.HQSY_ZBSSJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        HQSY_ZBSSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(HQSY_ZBSSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, HQSY_ZBSSJBXXID = HQSY_ZBSSJBXX.HQSY_ZBSSJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        HQSY_ZBSSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(HQSY_ZBSSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, HQSY_ZBSSJBXXID = HQSY_ZBSSJBXX.HQSY_ZBSSJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("HQSY_ZBSSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadHQSY_ZBSSJBXX(string HQSY_ZBSSJBXXID)
        {
            try
            {
                HQSY_ZBSSJBXX HQSY_ZBSSJBXX = DAO.GetObjectByID<HQSY_ZBSSJBXX>(HQSY_ZBSSJBXXID);
                if (HQSY_ZBSSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(HQSY_ZBSSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { HQSY_ZBSSJBXX = HQSY_ZBSSJBXX, BCMSString = BinaryHelper.BinaryToString(HQSY_ZBSSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(HQSY_ZBSSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("HQSY_ZBSSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
