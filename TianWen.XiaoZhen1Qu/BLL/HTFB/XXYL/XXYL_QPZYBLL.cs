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
    public class XXYL_QPZYBLL : BaseBLL, IXXYL_QPZYBLL
    {
        public object SaveXXYL_QPZYJBXX(JCXX jcxx, XXYL_QPZYJBXX XXYL_QPZYJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM XXYL_QPZYJBXX WHERE ID='{0}'", XXYL_QPZYJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        XXYL_QPZYJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(XXYL_QPZYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = XXYL_QPZYJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        XXYL_QPZYJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(XXYL_QPZYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = XXYL_QPZYJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("XXYL_QPZYJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadXXYL_QPZYJBXX(string ID)
        {
            try
            {
                XXYL_QPZYJBXX XXYL_QPZYJBXX = DAO.GetObjectByID<XXYL_QPZYJBXX>(ID);
                if (XXYL_QPZYJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(XXYL_QPZYJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { XXYL_QPZYJBXX = XXYL_QPZYJBXX, BCMSString = BinaryHelper.BinaryToString(XXYL_QPZYJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(XXYL_QPZYJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("XXYL_QPZYJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
