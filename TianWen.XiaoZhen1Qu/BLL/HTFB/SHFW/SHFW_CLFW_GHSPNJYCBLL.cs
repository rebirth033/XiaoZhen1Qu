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
    public class SHFW_CLFW_GHSPNJYCBLL : BaseBLL, ISHFW_CLFW_GHSPNJYCBLL
    {
        public object SaveSHFW_CLFW_GHSPNJYCJBXX(JCXX jcxx, SHFW_CLFW_GHSPNJYCJBXX SHFW_CLFW_GHSPNJYCJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_GHSPNJYCJBXX WHERE ID='{0}'", SHFW_CLFW_GHSPNJYCJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_GHSPNJYCJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_GHSPNJYCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_GHSPNJYCJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_GHSPNJYCJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_GHSPNJYCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_GHSPNJYCJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_GHSPNJYCJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_GHSPNJYCJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_GHSPNJYCJBXX SHFW_CLFW_GHSPNJYCJBXX = DAO.GetObjectByID<SHFW_CLFW_GHSPNJYCJBXX>(ID);
                if (SHFW_CLFW_GHSPNJYCJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_GHSPNJYCJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_GHSPNJYCJBXX = SHFW_CLFW_GHSPNJYCJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_GHSPNJYCJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_GHSPNJYCJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_GHSPNJYCJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
