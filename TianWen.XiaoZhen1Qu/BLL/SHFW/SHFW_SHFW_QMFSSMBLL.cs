﻿using System;
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
    public class SHFW_SHFW_QMFSSMBLL : BaseBLL, ISHFW_SHFW_QMFSSMBLL
    {
        public object SaveSHFW_SHFW_QMFSSMJBXX(JCXX jcxx, SHFW_SHFW_QMFSSMJBXX SHFW_SHFW_QMFSSMJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_QMFSSMJBXX WHERE SHFW_SHFW_QMFSSMJBXXID='{0}'", SHFW_SHFW_QMFSSMJBXX.SHFW_SHFW_QMFSSMJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_QMFSSMJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_QMFSSMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_QMFSSMJBXXID = SHFW_SHFW_QMFSSMJBXX.SHFW_SHFW_QMFSSMJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_QMFSSMJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_QMFSSMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_QMFSSMJBXXID = SHFW_SHFW_QMFSSMJBXX.SHFW_SHFW_QMFSSMJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_QMFSSMJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_QMFSSMJBXX(string SHFW_SHFW_QMFSSMJBXXID)
        {
            try
            {
                SHFW_SHFW_QMFSSMJBXX SHFW_SHFW_QMFSSMJBXX = DAO.GetObjectByID<SHFW_SHFW_QMFSSMJBXX>(SHFW_SHFW_QMFSSMJBXXID);
                if (SHFW_SHFW_QMFSSMJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_QMFSSMJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_QMFSSMJBXX = SHFW_SHFW_QMFSSMJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_QMFSSMJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_QMFSSMJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_QMFSSMJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
