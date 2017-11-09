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
    public class HQSY_HCZLBLL : BaseBLL, IHQSY_HCZLBLL
    {
        public object SaveHQSY_HCZLJBXX(JCXX jcxx, HQSY_HCZLJBXX HQSY_HCZLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM HQSY_HCZLJBXX WHERE ID='{0}'", HQSY_HCZLJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        HQSY_HCZLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(HQSY_HCZLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = HQSY_HCZLJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        HQSY_HCZLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(HQSY_HCZLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = HQSY_HCZLJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("HQSY_HCZLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadHQSY_HCZLJBXX(string ID)
        {
            try
            {
                HQSY_HCZLJBXX HQSY_HCZLJBXX = DAO.GetObjectByID<HQSY_HCZLJBXX>(ID);
                if (HQSY_HCZLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(HQSY_HCZLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { HQSY_HCZLJBXX = HQSY_HCZLJBXX, BCMSString = BinaryHelper.BinaryToString(HQSY_HCZLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(HQSY_HCZLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("HQSY_HCZLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
