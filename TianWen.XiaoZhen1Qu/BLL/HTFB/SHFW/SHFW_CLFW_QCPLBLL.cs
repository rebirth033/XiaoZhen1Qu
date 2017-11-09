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
    public class SHFW_CLFW_QCPLBLL : BaseBLL, ISHFW_CLFW_QCPLBLL
    {
        public object SaveSHFW_CLFW_QCPLJBXX(JCXX jcxx, SHFW_CLFW_QCPLJBXX SHFW_CLFW_QCPLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_QCPLJBXX WHERE ID='{0}'", SHFW_CLFW_QCPLJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_QCPLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_QCPLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCPLJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_QCPLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_QCPLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCPLJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_QCPLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_QCPLJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_QCPLJBXX SHFW_CLFW_QCPLJBXX = DAO.GetObjectByID<SHFW_CLFW_QCPLJBXX>(ID);
                if (SHFW_CLFW_QCPLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_QCPLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_QCPLJBXX = SHFW_CLFW_QCPLJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_QCPLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_QCPLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_QCPLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
