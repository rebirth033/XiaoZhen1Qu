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
    public class XXYL_XYWQBLL : BaseBLL, IXXYL_XYWQBLL
    {
        public object SaveXXYL_XYWQJBXX(JCXX jcxx, XXYL_XYWQJBXX XXYL_XYWQJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM XXYL_XYWQJBXX WHERE ID='{0}'", XXYL_XYWQJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        XXYL_XYWQJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(XXYL_XYWQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = XXYL_XYWQJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        XXYL_XYWQJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(XXYL_XYWQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = XXYL_XYWQJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("XXYL_XYWQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadXXYL_XYWQJBXX(string ID)
        {
            try
            {
                XXYL_XYWQJBXX XXYL_XYWQJBXX = DAO.GetObjectByID<XXYL_XYWQJBXX>(ID);
                if (XXYL_XYWQJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(XXYL_XYWQJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { XXYL_XYWQJBXX = XXYL_XYWQJBXX, BCMSString = BinaryHelper.BinaryToString(XXYL_XYWQJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(XXYL_XYWQJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("XXYL_XYWQJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
