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
    public class FC_XZLBLL : BaseBLL, IFC_XZLBLL
    {
        public object SaveXZLJBXX(JCXX jcxx, FC_XZLJBXX FC_XZLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM FC_XZLJBXX WHERE FC_XZLJBXXID='{0}'", FC_XZLJBXX.FC_XZLJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        FC_XZLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(FC_XZLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, FC_XZLJBXXID = FC_XZLJBXX.FC_XZLJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        FC_XZLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(FC_XZLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, FC_XZLJBXXID = FC_XZLJBXX.FC_XZLJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("FC_XZLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadFC_XZLJBXX(string FC_XZLJBXXID)
        {
            try
            {
                FC_XZLJBXX FC_XZLJBXX = DAO.GetObjectByID<FC_XZLJBXX>(FC_XZLJBXXID);
                if (FC_XZLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(FC_XZLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { FC_XZLJBXX = FC_XZLJBXX, BCMSString = BinaryHelper.BinaryToString(FC_XZLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(FC_XZLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }

            }
            catch (Exception ex)
            {
                LoggerManager.Error("FC_XZLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
