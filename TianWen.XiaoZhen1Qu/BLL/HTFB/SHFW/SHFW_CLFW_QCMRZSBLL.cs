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
    public class SHFW_CLFW_QCMRZSBLL : BaseBLL, ISHFW_CLFW_QCMRZSBLL
    {
        public object SaveSHFW_CLFW_QCMRZSJBXX(JCXX jcxx, SHFW_CLFW_QCMRZSJBXX SHFW_CLFW_QCMRZSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_QCMRZSJBXX WHERE SHFW_CLFW_QCMRZSJBXXID='{0}'", SHFW_CLFW_QCMRZSJBXX.SHFW_CLFW_QCMRZSJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_QCMRZSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_QCMRZSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_CLFW_QCMRZSJBXXID = SHFW_CLFW_QCMRZSJBXX.SHFW_CLFW_QCMRZSJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_QCMRZSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_QCMRZSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_CLFW_QCMRZSJBXXID = SHFW_CLFW_QCMRZSJBXX.SHFW_CLFW_QCMRZSJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_QCMRZSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_QCMRZSJBXX(string SHFW_CLFW_QCMRZSJBXXID)
        {
            try
            {
                SHFW_CLFW_QCMRZSJBXX SHFW_CLFW_QCMRZSJBXX = DAO.GetObjectByID<SHFW_CLFW_QCMRZSJBXX>(SHFW_CLFW_QCMRZSJBXXID);
                if (SHFW_CLFW_QCMRZSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_QCMRZSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_QCMRZSJBXX = SHFW_CLFW_QCMRZSJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_QCMRZSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_QCMRZSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_QCMRZSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
