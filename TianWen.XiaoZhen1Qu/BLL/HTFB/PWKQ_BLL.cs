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
    public class PWKQ_BLL : BaseBLL, IPWKQ_BLL
    {
        public object SaveES_PWKQ_DYPJBXX(JCXX jcxx, ES_PWKQ_DYPJBXX ES_PWKQ_DYPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_PWKQ_DYPJBXX WHERE ID='{0}'", ES_PWKQ_DYPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        ES_PWKQ_DYPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_PWKQ_DYPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_DYPJBXX.ID } };
                    }
                    else
                    {
                        ES_PWKQ_DYPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_PWKQ_DYPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_DYPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_PWKQ_DYPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_PWKQ_DYPJBXX(string ID)
        {
            try
            {
                ES_PWKQ_DYPJBXX ES_PWKQ_DYPJBXX = DAO.GetObjectByID<ES_PWKQ_DYPJBXX>(ID);
                if (ES_PWKQ_DYPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_PWKQ_DYPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_PWKQ_DYPJBXX = ES_PWKQ_DYPJBXX, BCMSString = BinaryHelper.BinaryToString(ES_PWKQ_DYPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_PWKQ_DYPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_PWKQ_DYPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveES_PWKQ_QTKQJBXX(JCXX jcxx, ES_PWKQ_QTKQJBXX ES_PWKQ_QTKQJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_PWKQ_QTKQJBXX WHERE ID='{0}'", ES_PWKQ_QTKQJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        ES_PWKQ_QTKQJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_PWKQ_QTKQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_QTKQJBXX.ID } };
                    }
                    else
                    {
                        ES_PWKQ_QTKQJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_PWKQ_QTKQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_QTKQJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_PWKQ_QTKQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_PWKQ_QTKQJBXX(string ID)
        {
            try
            {
                ES_PWKQ_QTKQJBXX ES_PWKQ_QTKQJBXX = DAO.GetObjectByID<ES_PWKQ_QTKQJBXX>(ID);
                if (ES_PWKQ_QTKQJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_PWKQ_QTKQJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_PWKQ_QTKQJBXX = ES_PWKQ_QTKQJBXX, BCMSString = BinaryHelper.BinaryToString(ES_PWKQ_QTKQJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_PWKQ_QTKQJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_PWKQ_QTKQJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveES_PWKQ_XFKGWQJBXX(JCXX jcxx, ES_PWKQ_XFKGWQJBXX ES_PWKQ_XFKGWQJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_PWKQ_XFKGWQJBXX WHERE ID='{0}'", ES_PWKQ_XFKGWQJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        ES_PWKQ_XFKGWQJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_PWKQ_XFKGWQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_XFKGWQJBXX.ID } };
                    }
                    else
                    {
                        ES_PWKQ_XFKGWQJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_PWKQ_XFKGWQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_XFKGWQJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_PWKQ_XFKGWQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_PWKQ_XFKGWQJBXX(string ID)
        {
            try
            {
                ES_PWKQ_XFKGWQJBXX ES_PWKQ_XFKGWQJBXX = DAO.GetObjectByID<ES_PWKQ_XFKGWQJBXX>(ID);
                if (ES_PWKQ_XFKGWQJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_PWKQ_XFKGWQJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_PWKQ_XFKGWQJBXX = ES_PWKQ_XFKGWQJBXX, BCMSString = BinaryHelper.BinaryToString(ES_PWKQ_XFKGWQJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_PWKQ_XFKGWQJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_PWKQ_XFKGWQJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveES_PWKQ_YCMPJBXX(JCXX jcxx, ES_PWKQ_YCMPJBXX ES_PWKQ_YCMPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_PWKQ_YCMPJBXX WHERE ID='{0}'", ES_PWKQ_YCMPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        ES_PWKQ_YCMPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_PWKQ_YCMPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_YCMPJBXX.ID } };
                    }
                    else
                    {
                        ES_PWKQ_YCMPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_PWKQ_YCMPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_YCMPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_PWKQ_YCMPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_PWKQ_YCMPJBXX(string ID)
        {
            try
            {
                ES_PWKQ_YCMPJBXX ES_PWKQ_YCMPJBXX = DAO.GetObjectByID<ES_PWKQ_YCMPJBXX>(ID);
                if (ES_PWKQ_YCMPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_PWKQ_YCMPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_PWKQ_YCMPJBXX = ES_PWKQ_YCMPJBXX, BCMSString = BinaryHelper.BinaryToString(ES_PWKQ_YCMPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_PWKQ_YCMPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_PWKQ_YCMPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveES_PWKQ_YLYJDPJBXX(JCXX jcxx, ES_PWKQ_YLYJDPJBXX ES_PWKQ_YLYJDPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM ES_PWKQ_YLYJDPJBXX WHERE ID='{0}'", ES_PWKQ_YLYJDPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        ES_PWKQ_YLYJDPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(ES_PWKQ_YLYJDPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_YLYJDPJBXX.ID } };
                    }
                    else
                    {
                        ES_PWKQ_YLYJDPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(ES_PWKQ_YLYJDPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = ES_PWKQ_YLYJDPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("ES_PWKQ_YLYJDPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadES_PWKQ_YLYJDPJBXX(string ID)
        {
            try
            {
                ES_PWKQ_YLYJDPJBXX ES_PWKQ_YLYJDPJBXX = DAO.GetObjectByID<ES_PWKQ_YLYJDPJBXX>(ID);
                if (ES_PWKQ_YLYJDPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(ES_PWKQ_YLYJDPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { ES_PWKQ_YLYJDPJBXX = ES_PWKQ_YLYJDPJBXX, BCMSString = BinaryHelper.BinaryToString(ES_PWKQ_YLYJDPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(ES_PWKQ_YLYJDPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("ES_PWKQ_YLYJDPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
