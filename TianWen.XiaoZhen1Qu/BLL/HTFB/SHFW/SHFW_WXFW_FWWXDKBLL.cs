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
    public class SHFW_WXFW_FWWXDKBLL : BaseBLL, ISHFW_WXFW_FWWXDKBLL
    {
        public object SaveSHFW_WXFW_FWWXDKJBXX(JCXX jcxx, SHFW_WXFW_FWWXDKJBXX SHFW_WXFW_FWWXDKJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_WXFW_FWWXDKJBXX WHERE SHFW_WXFW_FWWXDKJBXXID='{0}'", SHFW_WXFW_FWWXDKJBXX.SHFW_WXFW_FWWXDKJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_WXFW_FWWXDKJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_WXFW_FWWXDKJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_WXFW_FWWXDKJBXXID = SHFW_WXFW_FWWXDKJBXX.SHFW_WXFW_FWWXDKJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_WXFW_FWWXDKJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_WXFW_FWWXDKJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_WXFW_FWWXDKJBXXID = SHFW_WXFW_FWWXDKJBXX.SHFW_WXFW_FWWXDKJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_WXFW_FWWXDKJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_WXFW_FWWXDKJBXX(string SHFW_WXFW_FWWXDKJBXXID)
        {
            try
            {
                SHFW_WXFW_FWWXDKJBXX SHFW_WXFW_FWWXDKJBXX = DAO.GetObjectByID<SHFW_WXFW_FWWXDKJBXX>(SHFW_WXFW_FWWXDKJBXXID);
                if (SHFW_WXFW_FWWXDKJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_WXFW_FWWXDKJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_WXFW_FWWXDKJBXX = SHFW_WXFW_FWWXDKJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_WXFW_FWWXDKJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_WXFW_FWWXDKJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_WXFW_FWWXDKJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}