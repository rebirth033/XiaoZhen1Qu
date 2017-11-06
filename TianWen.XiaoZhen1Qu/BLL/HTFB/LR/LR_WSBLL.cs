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
    public class LR_WSBLL : BaseBLL, ILR_WSBLL
    {
        public object SaveLR_WSJBXX(JCXX jcxx, LR_WSJBXX LR_WSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM LR_WSJBXX WHERE LR_WSJBXXID='{0}'", LR_WSJBXX.LR_WSJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        LR_WSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(LR_WSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, LR_WSJBXXID = LR_WSJBXX.LR_WSJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        LR_WSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(LR_WSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, LR_WSJBXXID = LR_WSJBXX.LR_WSJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("LR_WSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadLR_WSJBXX(string LR_WSJBXXID)
        {
            try
            {
                LR_WSJBXX LR_WSJBXX = DAO.GetObjectByID<LR_WSJBXX>(LR_WSJBXXID);
                if (LR_WSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(LR_WSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { LR_WSJBXX = LR_WSJBXX, BCMSString = BinaryHelper.BinaryToString(LR_WSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(LR_WSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("LR_WSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}