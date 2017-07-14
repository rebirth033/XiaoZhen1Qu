using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class FWCZJBXXBLL : BaseBLL, IFWCZJBXXBLL
    {
        public object SaveFWCZJBXX(JCXX jcxx, FWCZJBXX fwczjbxx, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM FWCZJBXX WHERE FWCZID='{0}'", fwczjbxx.FWCZID));

            if (dt.Rows.Count > 0)
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", dt.Rows[0]["JCXXID"])).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                        foreach (var obj in photos)
                        {
                            obj.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                            DAO.Save(obj);
                        }

                        fwczjbxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(fwczjbxx);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, FWCZID = fwczjbxx.FWCZID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("FWCZJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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
                        fwczjbxx.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(fwczjbxx);
                        //照片全删全插
                        List<PHOTOS> old_photos = DAO.GetObjectList<PHOTOS>(string.Format("FROM PHOTOS WHERE JCXXID='{0}'", fwczjbxx.JCXXID)).ToList();
                        foreach (var obj in old_photos)
                        {
                            DAO.Remove(obj);
                        }
                        foreach (var obj in photos)
                        {
                            obj.JCXXID = fwczjbxx.JCXXID;
                            DAO.Save(obj);
                        }
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, FWCZID = fwczjbxx.FWCZID } };
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LoggerManager.Error("FWCZJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
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

        public object LoadFWCZXX(string FWCZID)
        {
            try
            {
                FWCZJBXX yhjbxx = GetObjByID(FWCZID);
                if (yhjbxx != null)
                {
                    JCXX jcxx = GetJCXXByID(yhjbxx.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { FWCZXX = yhjbxx, JCXX = jcxx, Photos = GetPhtosByJCXXID(yhjbxx.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }

            }
            catch (Exception ex)
            {
                LoggerManager.Error("FWCZJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public FWCZJBXX GetObjByID(string FWCZID)
        {
            IList<FWCZJBXX> list = DAO.Repository.GetObjectList<FWCZJBXX>(String.Format("FROM FWCZJBXX WHERE FWCZID='{0}'", FWCZID));
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        public JCXX GetJCXXByID(string JCXXID)
        {
            IList<JCXX> list = DAO.Repository.GetObjectList<JCXX>(String.Format("FROM JCXX WHERE JCXXID='{0}'", JCXXID));
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        public List<PHOTOS> GetPhtosByJCXXID(string JCXXID)
        {
            return DAO.Repository.GetObjectList<PHOTOS>(String.Format("FROM PHOTOS WHERE JCXXID='{0}'", JCXXID)).ToList();
        }

        public object LoadXQJBXXSByHZ(string XQMC)
        {
            try
            {
                IList<XQJBXX> list = DAO.Repository.GetObjectList<XQJBXX>(String.Format("FROM XQJBXX WHERE XQMC like '%{0}%' and ROWNUM <= 10 ORDER BY XQMC", XQMC));
                return new { Result = EnResultType.Success, list = list };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadXQJBXXSByPY(string XQMC)
        {
            try
            {
                IList<XQJBXX> list = DAO.Repository.GetObjectList<XQJBXX>(String.Format("FROM XQJBXX WHERE (XQMCPYQKG like '%{0}%' or XQMCPYSZM like '%{0}%') and ROWNUM <= 10 ORDER BY XQMC", XQMC));
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
