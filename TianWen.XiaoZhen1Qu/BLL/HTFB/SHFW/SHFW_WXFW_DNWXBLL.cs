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
    public class SHFW_WXFW_DNWXBLL : BaseBLL, ISHFW_WXFW_DNWXBLL
    {
        public object SaveSHFW_WXFW_DNWXJBXX(JCXX jcxx, SHFW_WXFW_DNWXJBXX SHFW_WXFW_DNWXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_WXFW_DNWXJBXX WHERE ID='{0}'", SHFW_WXFW_DNWXJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_WXFW_DNWXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_WXFW_DNWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_DNWXJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_WXFW_DNWXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_WXFW_DNWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_DNWXJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_WXFW_DNWXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_WXFW_DNWXJBXX(string ID)
        {
            try
            {
                SHFW_WXFW_DNWXJBXX SHFW_WXFW_DNWXJBXX = DAO.GetObjectByID<SHFW_WXFW_DNWXJBXX>(ID);
                if (SHFW_WXFW_DNWXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_WXFW_DNWXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_WXFW_DNWXJBXX = SHFW_WXFW_DNWXJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_WXFW_DNWXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_WXFW_DNWXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_WXFW_DNWXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
