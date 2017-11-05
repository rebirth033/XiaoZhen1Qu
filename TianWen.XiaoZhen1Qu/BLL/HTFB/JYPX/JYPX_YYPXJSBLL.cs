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
    public class JYPX_YYPXJSBLL : BaseBLL, IJYPX_YYPXJSBLL
    {
        public object SaveJYPX_YYPXJSJBXX(JCXX jcxx, JYPX_YYPXJSJBXX JYPX_YYPXJSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM JYPX_YYPXJSJBXX WHERE JYPX_YYPXJSJBXXID='{0}'", JYPX_YYPXJSJBXX.JYPX_YYPXJSJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        JYPX_YYPXJSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(JYPX_YYPXJSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_YYPXJSJBXXID = JYPX_YYPXJSJBXX.JYPX_YYPXJSJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        JYPX_YYPXJSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(JYPX_YYPXJSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, JYPX_YYPXJSJBXXID = JYPX_YYPXJSJBXX.JYPX_YYPXJSJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("JYPX_YYPXJSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadJYPX_YYPXJSJBXX(string JYPX_YYPXJSJBXXID)
        {
            try
            {
                JYPX_YYPXJSJBXX JYPX_YYPXJSJBXX = DAO.GetObjectByID<JYPX_YYPXJSJBXX>(JYPX_YYPXJSJBXXID);
                if (JYPX_YYPXJSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(JYPX_YYPXJSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { JYPX_YYPXJSJBXX = JYPX_YYPXJSJBXX, BCMSString = BinaryHelper.BinaryToString(JYPX_YYPXJSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(JYPX_YYPXJSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("JYPX_YYPXJSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
