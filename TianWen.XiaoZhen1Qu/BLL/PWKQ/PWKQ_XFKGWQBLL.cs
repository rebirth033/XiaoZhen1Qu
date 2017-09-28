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
    public class PWKQ_XFKGWQBLL : BaseBLL, IPWKQ_XFKGWQBLL
    {
        public object SavePWKQ_XFKGWQJBXX(JCXX jcxx, PWKQ_XFKGWQJBXX PWKQ_XFKGWQJBXX)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "/Areas/Business/Photos/");
            FileInfo[] fileinfos = TheFolder.GetFiles();
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_XFKGWQJBXX WHERE PWKQ_XFKGWQJBXXID='{0}'", PWKQ_XFKGWQJBXX.PWKQ_XFKGWQJBXXID));

            if (dt.Rows.Count > 0)
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        PWKQ_XFKGWQJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_XFKGWQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, PWKQ_XFKGWQJBXXID = PWKQ_XFKGWQJBXX.PWKQ_XFKGWQJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("PWKQ_XFKGWQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                        return new
                        {
                            Result = EnResultType.Failed,
                            Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                            Type = 3
                        };
                    }
                }
            }
            else
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        PWKQ_XFKGWQJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_XFKGWQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, PWKQ_XFKGWQJBXXID = PWKQ_XFKGWQJBXX.PWKQ_XFKGWQJBXXID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("PWKQ_XFKGWQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                        return new
                        {
                            Result = EnResultType.Failed,
                            Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                            Type = 3
                        };
                    }
                }
            }
        }

        public object LoadPWKQ_XFKGWQJBXX(string PWKQ_XFKGWQJBXXID)
        {
            try
            {
                PWKQ_XFKGWQJBXX PWKQ_XFKGWQJBXX = DAO.GetObjectByID<PWKQ_XFKGWQJBXX>(PWKQ_XFKGWQJBXXID);
                if (PWKQ_XFKGWQJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_XFKGWQJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_XFKGWQJBXX = PWKQ_XFKGWQJBXX, JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_XFKGWQJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PWKQ_XFKGWQJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}