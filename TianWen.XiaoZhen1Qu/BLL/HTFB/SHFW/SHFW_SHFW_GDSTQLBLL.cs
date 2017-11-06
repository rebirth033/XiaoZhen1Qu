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
    public class SHFW_SHFW_GDSTQLBLL : BaseBLL, ISHFW_SHFW_GDSTQLBLL
    {
        public object SaveSHFW_SHFW_GDSTQLJBXX(JCXX jcxx, SHFW_SHFW_GDSTQLJBXX SHFW_SHFW_GDSTQLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_GDSTQLJBXX WHERE SHFW_SHFW_GDSTQLJBXXID='{0}'", SHFW_SHFW_GDSTQLJBXX.SHFW_SHFW_GDSTQLJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_GDSTQLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_GDSTQLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_GDSTQLJBXXID = SHFW_SHFW_GDSTQLJBXX.SHFW_SHFW_GDSTQLJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_GDSTQLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_GDSTQLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, SHFW_SHFW_GDSTQLJBXXID = SHFW_SHFW_GDSTQLJBXX.SHFW_SHFW_GDSTQLJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_GDSTQLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_GDSTQLJBXX(string SHFW_SHFW_GDSTQLJBXXID)
        {
            try
            {
                SHFW_SHFW_GDSTQLJBXX SHFW_SHFW_GDSTQLJBXX = DAO.GetObjectByID<SHFW_SHFW_GDSTQLJBXX>(SHFW_SHFW_GDSTQLJBXXID);
                if (SHFW_SHFW_GDSTQLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_GDSTQLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_GDSTQLJBXX = SHFW_SHFW_GDSTQLJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_GDSTQLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_GDSTQLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_GDSTQLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}