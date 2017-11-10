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

        public object SavePWKQ_QTKQJBXX(JCXX jcxx, PWKQ_QTKQJBXX PWKQ_QTKQJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_QTKQJBXX WHERE ID='{0}'", PWKQ_QTKQJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        PWKQ_QTKQJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_QTKQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_QTKQJBXX.ID } };
                    }
                    else
                    {
                        PWKQ_QTKQJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_QTKQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_QTKQJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PWKQ_QTKQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPWKQ_QTKQJBXX(string ID)
        {
            try
            {
                PWKQ_QTKQJBXX PWKQ_QTKQJBXX = DAO.GetObjectByID<PWKQ_QTKQJBXX>(ID);
                if (PWKQ_QTKQJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_QTKQJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_QTKQJBXX = PWKQ_QTKQJBXX, BCMSString = BinaryHelper.BinaryToString(PWKQ_QTKQJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_QTKQJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PWKQ_QTKQJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SavePWKQ_XFKGWQJBXX(JCXX jcxx, PWKQ_XFKGWQJBXX PWKQ_XFKGWQJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_XFKGWQJBXX WHERE ID='{0}'", PWKQ_XFKGWQJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        PWKQ_XFKGWQJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_XFKGWQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_XFKGWQJBXX.ID } };
                    }
                    else
                    {
                        PWKQ_XFKGWQJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_XFKGWQJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_XFKGWQJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PWKQ_XFKGWQJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPWKQ_XFKGWQJBXX(string ID)
        {
            try
            {
                PWKQ_XFKGWQJBXX PWKQ_XFKGWQJBXX = DAO.GetObjectByID<PWKQ_XFKGWQJBXX>(ID);
                if (PWKQ_XFKGWQJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_XFKGWQJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_XFKGWQJBXX = PWKQ_XFKGWQJBXX, BCMSString = BinaryHelper.BinaryToString(PWKQ_XFKGWQJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_XFKGWQJBXX.JCXXID) } };
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

        public object SavePWKQ_YCMPJBXX(JCXX jcxx, PWKQ_YCMPJBXX PWKQ_YCMPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_YCMPJBXX WHERE ID='{0}'", PWKQ_YCMPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        PWKQ_YCMPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_YCMPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_YCMPJBXX.ID } };
                    }
                    else
                    {
                        PWKQ_YCMPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_YCMPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_YCMPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PWKQ_YCMPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPWKQ_YCMPJBXX(string ID)
        {
            try
            {
                PWKQ_YCMPJBXX PWKQ_YCMPJBXX = DAO.GetObjectByID<PWKQ_YCMPJBXX>(ID);
                if (PWKQ_YCMPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_YCMPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_YCMPJBXX = PWKQ_YCMPJBXX, BCMSString = BinaryHelper.BinaryToString(PWKQ_YCMPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_YCMPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PWKQ_YCMPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SavePWKQ_YLYJDPJBXX(JCXX jcxx, PWKQ_YLYJDPJBXX PWKQ_YLYJDPJBXX)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM PWKQ_YLYJDPJBXX WHERE ID='{0}'", PWKQ_YLYJDPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        PWKQ_YLYJDPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(PWKQ_YLYJDPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_YLYJDPJBXX.ID } };
                    }
                    else
                    {
                        PWKQ_YLYJDPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(PWKQ_YLYJDPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = PWKQ_YLYJDPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("PWKQ_YLYJDPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadPWKQ_YLYJDPJBXX(string ID)
        {
            try
            {
                PWKQ_YLYJDPJBXX PWKQ_YLYJDPJBXX = DAO.GetObjectByID<PWKQ_YLYJDPJBXX>(ID);
                if (PWKQ_YLYJDPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(PWKQ_YLYJDPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { PWKQ_YLYJDPJBXX = PWKQ_YLYJDPJBXX, BCMSString = BinaryHelper.BinaryToString(PWKQ_YLYJDPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(PWKQ_YLYJDPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("PWKQ_YLYJDPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
