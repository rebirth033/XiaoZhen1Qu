using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class FC_DZFBLL : BaseBLL, IFC_DZFBLL
    {
        //保存房屋出租基本信息
        public object SaveDZFJBXX(JCXX jcxx, FC_DZFJBXX FC_DZFJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM FC_DZFJBXX WHERE FC_DZFJBXXID='{0}'", FC_DZFJBXX.FC_DZFJBXXID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        FC_DZFJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(FC_DZFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, FC_DZFJBXXID = FC_DZFJBXX.FC_DZFJBXXID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        FC_DZFJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(FC_DZFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, FC_DZFJBXXID = FC_DZFJBXX.FC_DZFJBXXID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("FC_DZFJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }
        //加载短租房基本信息
        public object LoadFC_DZFJBXX(string FC_DZFJBXXID)
        {
            try
            {
                FC_DZFJBXX FC_DZFJBXX = DAO.GetObjectByID<FC_DZFJBXX>(FC_DZFJBXXID);
                if (FC_DZFJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(FC_DZFJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { FC_DZFJBXX = FC_DZFJBXX, BCMSString = BinaryHelper.BinaryToString(FC_DZFJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(FC_DZFJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }

            }
            catch (Exception ex)
            {
                LoggerManager.Error("FC_ZZFJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
