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
    public class ZSJM_WTMYETBLL : BaseBLL, IZSJM_WTMYETBLL
    {
        public object SaveZSJM_WTMYETJBXX(JCXX jcxx, ZSJM_WTMYETJBXX ZSJM_WTMYETJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ZSJM_WTMYETJBXX WHERE ZSJM_WTMYETJBXXID='{0}'", ZSJM_WTMYETJBXX.ZSJM_WTMYETJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        ZSJM_WTMYETJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ZSJM_WTMYETJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_WTMYETJBXXID = ZSJM_WTMYETJBXX.ZSJM_WTMYETJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        ZSJM_WTMYETJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ZSJM_WTMYETJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ZSJM_WTMYETJBXXID = ZSJM_WTMYETJBXX.ZSJM_WTMYETJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ZSJM_WTMYETJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadZSJM_WTMYETJBXX(string ZSJM_WTMYETJBXXID)
        {
            try
            {
                ZSJM_WTMYETJBXX ZSJM_WTMYETJBXX = DAO.GetObjectByID<ZSJM_WTMYETJBXX>(ZSJM_WTMYETJBXXID);
                if (ZSJM_WTMYETJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ZSJM_WTMYETJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ZSJM_WTMYETJBXX = ZSJM_WTMYETJBXX, BCMSString = BinaryHelper.BinaryToString(ZSJM_WTMYETJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ZSJM_WTMYETJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ZSJM_WTMYETJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}