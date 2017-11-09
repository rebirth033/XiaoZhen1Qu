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
    public class SHFW_CLFW_QCGZFHBLL : BaseBLL, ISHFW_CLFW_QCGZFHBLL
    {
        public object SaveSHFW_CLFW_QCGZFHJBXX(JCXX jcxx, SHFW_CLFW_QCGZFHJBXX SHFW_CLFW_QCGZFHJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_QCGZFHJBXX WHERE ID='{0}'", SHFW_CLFW_QCGZFHJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_QCGZFHJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_QCGZFHJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCGZFHJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_QCGZFHJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_QCGZFHJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCGZFHJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_QCGZFHJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_QCGZFHJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_QCGZFHJBXX SHFW_CLFW_QCGZFHJBXX = DAO.GetObjectByID<SHFW_CLFW_QCGZFHJBXX>(ID);
                if (SHFW_CLFW_QCGZFHJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_QCGZFHJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_QCGZFHJBXX = SHFW_CLFW_QCGZFHJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_QCGZFHJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_QCGZFHJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_QCGZFHJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
