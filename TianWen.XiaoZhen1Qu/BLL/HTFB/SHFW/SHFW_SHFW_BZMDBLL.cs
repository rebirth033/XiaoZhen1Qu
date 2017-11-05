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
    public class SHFW_SHFW_BZMDBLL : BaseBLL, ISHFW_SHFW_BZMDBLL
    {
        public object SaveSHFW_SHFW_BZMDJBXX(JCXX jcxx, SHFW_SHFW_BZMDJBXX SHFW_SHFW_BZMDJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_BZMDJBXX WHERE SHFW_SHFW_BZMDJBXXID='{0}'", SHFW_SHFW_BZMDJBXX.SHFW_SHFW_BZMDJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_BZMDJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_BZMDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_BZMDJBXXID = SHFW_SHFW_BZMDJBXX.SHFW_SHFW_BZMDJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_BZMDJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_BZMDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_BZMDJBXXID = SHFW_SHFW_BZMDJBXX.SHFW_SHFW_BZMDJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_BZMDJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_BZMDJBXX(string SHFW_SHFW_BZMDJBXXID)
        {
            try
            {
                SHFW_SHFW_BZMDJBXX SHFW_SHFW_BZMDJBXX = DAO.GetObjectByID<SHFW_SHFW_BZMDJBXX>(SHFW_SHFW_BZMDJBXXID);
                if (SHFW_SHFW_BZMDJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_BZMDJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_BZMDJBXX = SHFW_SHFW_BZMDJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_BZMDJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_BZMDJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_BZMDJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
