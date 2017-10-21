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
    public class SHFW_SHFW_BJBLL : BaseBLL, ISHFW_SHFW_BJBLL
    {
        public object SaveSHFW_SHFW_BJJBXX(JCXX jcxx, SHFW_SHFW_BJJBXX SHFW_SHFW_BJJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_BJJBXX WHERE SHFW_SHFW_BJJBXXID='{0}'", SHFW_SHFW_BJJBXX.SHFW_SHFW_BJJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_BJJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_BJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_BJJBXXID = SHFW_SHFW_BJJBXX.SHFW_SHFW_BJJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_BJJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_BJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_BJJBXXID = SHFW_SHFW_BJJBXX.SHFW_SHFW_BJJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_BJJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_BJJBXX(string SHFW_SHFW_BJJBXXID)
        {
            try
            {
                SHFW_SHFW_BJJBXX SHFW_SHFW_BJJBXX = DAO.GetObjectByID<SHFW_SHFW_BJJBXX>(SHFW_SHFW_BJJBXXID);
                if (SHFW_SHFW_BJJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_BJJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_BJJBXX = SHFW_SHFW_BJJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_BJJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_BJJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_BJJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
