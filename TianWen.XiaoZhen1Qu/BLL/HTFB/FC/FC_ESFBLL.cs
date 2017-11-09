using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Entities.Models.FC;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.XiaoZhen1Qu.Interface.HTFB.FC;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class FC_ESFBLL : BaseBLL, IFC_ESFBLL
    {
        //保存房屋出租基本信息
        public object SaveFC_ESFJBXX(JCXX jcxx, FC_ESFJBXX FC_ZZFJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM FC_ZZFJBXX WHERE ID='{0}'", FC_ZZFJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        FC_ZZFJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(FC_ZZFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = FC_ZZFJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        FC_ZZFJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(FC_ZZFJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = FC_ZZFJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("FC_ZZFJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }
        //加载二手房基本信息
        public object LoadFC_ESFJBXX(string ID)
        {
            try
            {
                FC_ESFJBXX FC_ESFJBXX = DAO.GetObjectByID<FC_ESFJBXX>(ID);
                if (FC_ESFJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(FC_ESFJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { FC_ESFJBXX = FC_ESFJBXX, BCMSString = BinaryHelper.BinaryToString(FC_ESFJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(FC_ESFJBXX.JCXXID) } };
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
        //根据汉子获取小区基本信息
        public object LoadXQJBXXSByHZ(string XQMC)
        {
            try
            {
                IList<CODES_FUZHOU_XQJBXX> list = DAO.Repository.GetObjectList<CODES_FUZHOU_XQJBXX>(String.Format("FROM CODES_FUZHOU_XQJBXX WHERE XQMC like '%{0}%' and ROWNUM <= 10 ORDER BY XQMC", XQMC));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
        //根据拼音获取小区基本信息
        public object LoadXQJBXXSByPY(string XQMC)
        {
            try
            {
                IList<CODES_FUZHOU_XQJBXX> list = DAO.Repository.GetObjectList<CODES_FUZHOU_XQJBXX>(String.Format("FROM CODES_FUZHOU_XQJBXX WHERE (XQMCPYQKG like '%{0}%' or XQMCPYSZM like '%{0}%') and ROWNUM <= 10 ORDER BY XQMC", XQMC));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }
    }
}
