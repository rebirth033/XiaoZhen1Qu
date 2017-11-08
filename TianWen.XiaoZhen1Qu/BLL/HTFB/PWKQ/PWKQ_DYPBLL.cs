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
    public class PWKQ_DYPBLL : BaseBLL, IPWKQ_DYPBLL
    {
        public object SavePWKQ_DYPJBXX(JCXX jcxx, PWKQ_DYPJBXX PWKQ_DYPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_DYPJBXX WHERE ID='{0}'", PWKQ_DYPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        PWKQ_DYPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_DYPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_DYPJBXX.ID } };
                    }
                    else
                    {
                        PWKQ_DYPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_DYPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_DYPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PWKQ_DYPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPWKQ_DYPJBXX(string ID)
        {
            try
            {
                PWKQ_DYPJBXX PWKQ_DYPJBXX = DAO.GetObjectByID<PWKQ_DYPJBXX>(ID);
                if (PWKQ_DYPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_DYPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_DYPJBXX = PWKQ_DYPJBXX, BCMSString = BinaryHelper.BinaryToString(PWKQ_DYPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_DYPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PWKQ_DYPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
