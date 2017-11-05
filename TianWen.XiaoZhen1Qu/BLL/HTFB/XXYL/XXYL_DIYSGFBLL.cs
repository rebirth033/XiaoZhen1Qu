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
    public class XXYL_DIYSGFBLL : BaseBLL, IXXYL_DIYSGFBLL
    {
        public object SaveXXYL_DIYSGFJBXX(JCXX jcxx, XXYL_DIYSGFJBXX XXYL_DIYSGFJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM XXYL_DIYSGFJBXX WHERE XXYL_DIYSGFJBXXID='{0}'", XXYL_DIYSGFJBXX.XXYL_DIYSGFJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        XXYL_DIYSGFJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(XXYL_DIYSGFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, XXYL_DIYSGFJBXXID = XXYL_DIYSGFJBXX.XXYL_DIYSGFJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        XXYL_DIYSGFJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(XXYL_DIYSGFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, XXYL_DIYSGFJBXXID = XXYL_DIYSGFJBXX.XXYL_DIYSGFJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("XXYL_DIYSGFJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadXXYL_DIYSGFJBXX(string XXYL_DIYSGFJBXXID)
        {
            try
            {
                XXYL_DIYSGFJBXX XXYL_DIYSGFJBXX = DAO.GetObjectByID<XXYL_DIYSGFJBXX>(XXYL_DIYSGFJBXXID);
                if (XXYL_DIYSGFJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(XXYL_DIYSGFJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { XXYL_DIYSGFJBXX = XXYL_DIYSGFJBXX, BCMSString = BinaryHelper.BinaryToString(XXYL_DIYSGFJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(XXYL_DIYSGFJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("XXYL_DIYSGFJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
