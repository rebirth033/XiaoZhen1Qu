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
    public class HQSY_HSLFBLL : BaseBLL, IHQSY_HSLFBLL
    {
        public object SaveHQSY_HSLFJBXX(JCXX jcxx, HQSY_HSLFJBXX HQSY_HSLFJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM HQSY_HSLFJBXX WHERE ID='{0}'", HQSY_HSLFJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        HQSY_HSLFJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(HQSY_HSLFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = HQSY_HSLFJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        HQSY_HSLFJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(HQSY_HSLFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = HQSY_HSLFJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("HQSY_HSLFJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadHQSY_HSLFJBXX(string ID)
        {
            try
            {
                HQSY_HSLFJBXX HQSY_HSLFJBXX = DAO.GetObjectByID<HQSY_HSLFJBXX>(ID);
                if (HQSY_HSLFJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(HQSY_HSLFJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { HQSY_HSLFJBXX = HQSY_HSLFJBXX, BCMSString = BinaryHelper.BinaryToString(HQSY_HSLFJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(HQSY_HSLFJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("HQSY_HSLFJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
