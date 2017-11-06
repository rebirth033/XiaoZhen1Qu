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
    public class LR_WDBLL : BaseBLL, ILR_WDBLL
    {
        public object SaveLR_WDJBXX(JCXX jcxx, LR_WDJBXX LR_WDJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM LR_WDJBXX WHERE LR_WDJBXXID='{0}'", LR_WDJBXX.LR_WDJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        LR_WDJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(LR_WDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, LR_WDJBXXID = LR_WDJBXX.LR_WDJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        LR_WDJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(LR_WDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, LR_WDJBXXID = LR_WDJBXX.LR_WDJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("LR_WDJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadLR_WDJBXX(string LR_WDJBXXID)
        {
            try
            {
                LR_WDJBXX LR_WDJBXX = DAO.GetObjectByID<LR_WDJBXX>(LR_WDJBXXID);
                if (LR_WDJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(LR_WDJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { LR_WDJBXX = LR_WDJBXX, BCMSString = BinaryHelper.BinaryToString(LR_WDJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(LR_WDJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("LR_WDJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}