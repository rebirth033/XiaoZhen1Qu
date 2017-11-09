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
    public class LR_MRHFBLL : BaseBLL, ILR_MRHFBLL
    {
        public object SaveLR_MRHFJBXX(JCXX jcxx, LR_MRHFJBXX LR_MRHFJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM LR_MRHFJBXX WHERE ID='{0}'", LR_MRHFJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        LR_MRHFJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(LR_MRHFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = LR_MRHFJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        LR_MRHFJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(LR_MRHFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = LR_MRHFJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("LR_MRHFJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadLR_MRHFJBXX(string ID)
        {
            try
            {
                LR_MRHFJBXX LR_MRHFJBXX = DAO.GetObjectByID<LR_MRHFJBXX>(ID);
                if (LR_MRHFJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(LR_MRHFJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { LR_MRHFJBXX = LR_MRHFJBXX, BCMSString = BinaryHelper.BinaryToString(LR_MRHFJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(LR_MRHFJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("LR_MRHFJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
