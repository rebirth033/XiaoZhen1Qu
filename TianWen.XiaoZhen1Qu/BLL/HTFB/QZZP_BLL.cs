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
    public class QZZP_BLL : BaseBLL, IQZZP_BLL
    {
        public object SaveQZZP_JZZPJBXX(JCXX jcxx, QZZP_JZZPJBXX QZZP_JZZPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM QZZP_JZZPJBXX WHERE ID='{0}'", QZZP_JZZPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        QZZP_JZZPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(QZZP_JZZPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = QZZP_JZZPJBXX.ID } };
                    }
                    else
                    {
                        QZZP_JZZPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(QZZP_JZZPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = QZZP_JZZPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("QZZP_JZZPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadQZZP_JZZPJBXX(string ID)
        {
            try
            {
                QZZP_JZZPJBXX QZZP_JZZPJBXX = DAO.GetObjectByID<QZZP_JZZPJBXX>(ID);
                if (QZZP_JZZPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(QZZP_JZZPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { QZZP_JZZPJBXX = QZZP_JZZPJBXX, BCMSString = BinaryHelper.BinaryToString(QZZP_JZZPJBXX.BCMS), JCXX = jcxx} };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("QZZP_JZZPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveQZZP_QZZPJBXX(JCXX jcxx, QZZP_QZZPJBXX QZZP_QZZPJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM QZZP_QZZPJBXX WHERE ID='{0}'", QZZP_QZZPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        QZZP_QZZPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(QZZP_QZZPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = QZZP_QZZPJBXX.ID } };
                    }
                    else
                    {
                        QZZP_QZZPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(QZZP_QZZPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = QZZP_QZZPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("QZZP_QZZPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadQZZP_QZZPJBXX(string ID)
        {
            try
            {
                QZZP_QZZPJBXX QZZP_QZZPJBXX = DAO.GetObjectByID<QZZP_QZZPJBXX>(ID);
                if (QZZP_QZZPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(QZZP_QZZPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { QZZP_QZZPJBXX = QZZP_QZZPJBXX, BCMSString = BinaryHelper.BinaryToString(QZZP_QZZPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(QZZP_QZZPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("QZZP_QZZPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
