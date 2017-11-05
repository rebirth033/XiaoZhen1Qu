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
    public class JYPX_YYPXJGBLL : BaseBLL, IJYPX_YYPXJGBLL
    {
        public object SaveJYPX_YYPXJGJBXX(JCXX jcxx, JYPX_YYPXJGJBXX JYPX_YYPXJGJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM JYPX_YYPXJGJBXX WHERE JYPX_YYPXJGJBXXID='{0}'", JYPX_YYPXJGJBXX.JYPX_YYPXJGJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        JYPX_YYPXJGJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(JYPX_YYPXJGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_YYPXJGJBXXID = JYPX_YYPXJGJBXX.JYPX_YYPXJGJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        JYPX_YYPXJGJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(JYPX_YYPXJGJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_YYPXJGJBXXID = JYPX_YYPXJGJBXX.JYPX_YYPXJGJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("JYPX_YYPXJGJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadJYPX_YYPXJGJBXX(string JYPX_YYPXJGJBXXID)
        {
            try
            {
                JYPX_YYPXJGJBXX JYPX_YYPXJGJBXX = DAO.GetObjectByID<JYPX_YYPXJGJBXX>(JYPX_YYPXJGJBXXID);
                if (JYPX_YYPXJGJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(JYPX_YYPXJGJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { JYPX_YYPXJGJBXX = JYPX_YYPXJGJBXX, BCMSString = BinaryHelper.BinaryToString(JYPX_YYPXJGJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(JYPX_YYPXJGJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("JYPX_YYPXJGJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
