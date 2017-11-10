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
    public class SHFW_BLL : BaseBLL, ISHFW_BLL
    {
        public object SaveSHFW_CLFW_DJSJWPJBXX(JCXX jcxx, SHFW_CLFW_DJSJWPJBXX SHFW_CLFW_DJSJWPJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_DJSJWPJBXX WHERE ID='{0}'", SHFW_CLFW_DJSJWPJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_DJSJWPJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_DJSJWPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_DJSJWPJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_DJSJWPJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_DJSJWPJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_DJSJWPJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_DJSJWPJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_DJSJWPJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_DJSJWPJBXX SHFW_CLFW_DJSJWPJBXX = DAO.GetObjectByID<SHFW_CLFW_DJSJWPJBXX>(ID);
                if (SHFW_CLFW_DJSJWPJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_DJSJWPJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_DJSJWPJBXX = SHFW_CLFW_DJSJWPJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_DJSJWPJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_DJSJWPJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_DJSJWPJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_CLFW_GHSPNJYCJBXX(JCXX jcxx, SHFW_CLFW_GHSPNJYCJBXX SHFW_CLFW_GHSPNJYCJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_GHSPNJYCJBXX WHERE ID='{0}'", SHFW_CLFW_GHSPNJYCJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_GHSPNJYCJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_GHSPNJYCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_GHSPNJYCJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_GHSPNJYCJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_GHSPNJYCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_GHSPNJYCJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_GHSPNJYCJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_GHSPNJYCJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_GHSPNJYCJBXX SHFW_CLFW_GHSPNJYCJBXX = DAO.GetObjectByID<SHFW_CLFW_GHSPNJYCJBXX>(ID);
                if (SHFW_CLFW_GHSPNJYCJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_GHSPNJYCJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_GHSPNJYCJBXX = SHFW_CLFW_GHSPNJYCJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_GHSPNJYCJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_GHSPNJYCJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_GHSPNJYCJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_CLFW_JXJBXX(JCXX jcxx, SHFW_CLFW_JXJBXX SHFW_CLFW_JXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_JXJBXX WHERE ID='{0}'", SHFW_CLFW_JXJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_JXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_JXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_JXJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_JXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_JXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_JXJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_JXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_JXJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_JXJBXX SHFW_CLFW_JXJBXX = DAO.GetObjectByID<SHFW_CLFW_JXJBXX>(ID);
                if (SHFW_CLFW_JXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_JXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_JXJBXX = SHFW_CLFW_JXJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_JXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_JXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_JXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_CLFW_QCGZFHJBXX(JCXX jcxx, SHFW_CLFW_QCGZFHJBXX SHFW_CLFW_QCGZFHJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_QCGZFHJBXX WHERE ID='{0}'", SHFW_CLFW_QCGZFHJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_QCGZFHJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_QCGZFHJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCGZFHJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_QCGZFHJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_QCGZFHJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCGZFHJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_QCGZFHJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_QCGZFHJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_QCGZFHJBXX SHFW_CLFW_QCGZFHJBXX = DAO.GetObjectByID<SHFW_CLFW_QCGZFHJBXX>(ID);
                if (SHFW_CLFW_QCGZFHJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_QCGZFHJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_QCGZFHJBXX = SHFW_CLFW_QCGZFHJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_QCGZFHJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_QCGZFHJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_QCGZFHJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_CLFW_QCMRZSJBXX(JCXX jcxx, SHFW_CLFW_QCMRZSJBXX SHFW_CLFW_QCMRZSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_QCMRZSJBXX WHERE ID='{0}'", SHFW_CLFW_QCMRZSJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_QCMRZSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_QCMRZSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCMRZSJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_QCMRZSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_QCMRZSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCMRZSJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_QCMRZSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_QCMRZSJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_QCMRZSJBXX SHFW_CLFW_QCMRZSJBXX = DAO.GetObjectByID<SHFW_CLFW_QCMRZSJBXX>(ID);
                if (SHFW_CLFW_QCMRZSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_QCMRZSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_QCMRZSJBXX = SHFW_CLFW_QCMRZSJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_QCMRZSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_QCMRZSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_QCMRZSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_CLFW_QCPLJBXX(JCXX jcxx, SHFW_CLFW_QCPLJBXX SHFW_CLFW_QCPLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_QCPLJBXX WHERE ID='{0}'", SHFW_CLFW_QCPLJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_QCPLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_QCPLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCPLJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_QCPLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_QCPLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCPLJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_QCPLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_QCPLJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_QCPLJBXX SHFW_CLFW_QCPLJBXX = DAO.GetObjectByID<SHFW_CLFW_QCPLJBXX>(ID);
                if (SHFW_CLFW_QCPLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_QCPLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_QCPLJBXX = SHFW_CLFW_QCPLJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_QCPLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_QCPLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_QCPLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_CLFW_QCWXBYJBXX(JCXX jcxx, SHFW_CLFW_QCWXBYJBXX SHFW_CLFW_QCWXBYJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_QCWXBYJBXX WHERE ID='{0}'", SHFW_CLFW_QCWXBYJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_QCWXBYJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_QCWXBYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCWXBYJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_QCWXBYJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_QCWXBYJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_QCWXBYJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_QCWXBYJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_QCWXBYJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_QCWXBYJBXX SHFW_CLFW_QCWXBYJBXX = DAO.GetObjectByID<SHFW_CLFW_QCWXBYJBXX>(ID);
                if (SHFW_CLFW_QCWXBYJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_QCWXBYJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_QCWXBYJBXX = SHFW_CLFW_QCWXBYJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_QCWXBYJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_QCWXBYJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_QCWXBYJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_CLFW_ZCJBXX(JCXX jcxx, SHFW_CLFW_ZCJBXX SHFW_CLFW_ZCJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_CLFW_ZCJBXX WHERE ID='{0}'", SHFW_CLFW_ZCJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_CLFW_ZCJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_CLFW_ZCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_ZCJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_CLFW_ZCJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_CLFW_ZCJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_CLFW_ZCJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_CLFW_ZCJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_CLFW_ZCJBXX(string ID)
        {
            try
            {
                SHFW_CLFW_ZCJBXX SHFW_CLFW_ZCJBXX = DAO.GetObjectByID<SHFW_CLFW_ZCJBXX>(ID);
                if (SHFW_CLFW_ZCJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_CLFW_ZCJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_CLFW_ZCJBXX = SHFW_CLFW_ZCJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_CLFW_ZCJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_CLFW_ZCJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_CLFW_ZCJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_SHFW_BJJBXX(JCXX jcxx, SHFW_SHFW_BJJBXX SHFW_SHFW_BJJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_BJJBXX WHERE ID='{0}'", SHFW_SHFW_BJJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_BJJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_BJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_BJJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_BJJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_BJJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_BJJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_BJJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_BJJBXX(string ID)
        {
            try
            {
                SHFW_SHFW_BJJBXX SHFW_SHFW_BJJBXX = DAO.GetObjectByID<SHFW_SHFW_BJJBXX>(ID);
                if (SHFW_SHFW_BJJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_BJJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_BJJBXX = SHFW_SHFW_BJJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_BJJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_BJJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_BJJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_SHFW_BJQXJBXX(JCXX jcxx, SHFW_SHFW_BJQXJBXX SHFW_SHFW_BJQXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_BJQXJBXX WHERE ID='{0}'", SHFW_SHFW_BJQXJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_BJQXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_BJQXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_BJQXJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_BJQXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_BJQXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_BJQXJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_BJQXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_BJQXJBXX(string ID)
        {
            try
            {
                SHFW_SHFW_BJQXJBXX SHFW_SHFW_BJQXJBXX = DAO.GetObjectByID<SHFW_SHFW_BJQXJBXX>(ID);
                if (SHFW_SHFW_BJQXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_BJQXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_BJQXJBXX = SHFW_SHFW_BJQXJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_BJQXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_BJQXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_BJQXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_SHFW_BMYSJBXX(JCXX jcxx, SHFW_SHFW_BMYSJBXX SHFW_SHFW_BMYSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_BMYSJBXX WHERE ID='{0}'", SHFW_SHFW_BMYSJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_BMYSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_BMYSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_BMYSJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_BMYSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_BMYSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_BMYSJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_BMYSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_BMYSJBXX(string ID)
        {
            try
            {
                SHFW_SHFW_BMYSJBXX SHFW_SHFW_BMYSJBXX = DAO.GetObjectByID<SHFW_SHFW_BMYSJBXX>(ID);
                if (SHFW_SHFW_BMYSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_BMYSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_BMYSJBXX = SHFW_SHFW_BMYSJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_BMYSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_BMYSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_BMYSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_SHFW_BZMDJBXX(JCXX jcxx, SHFW_SHFW_BZMDJBXX SHFW_SHFW_BZMDJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_BZMDJBXX WHERE ID='{0}'", SHFW_SHFW_BZMDJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_BZMDJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_BZMDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_BZMDJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_BZMDJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_BZMDJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_BZMDJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_BZMDJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_BZMDJBXX(string ID)
        {
            try
            {
                SHFW_SHFW_BZMDJBXX SHFW_SHFW_BZMDJBXX = DAO.GetObjectByID<SHFW_SHFW_BZMDJBXX>(ID);
                if (SHFW_SHFW_BZMDJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_BZMDJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_BZMDJBXX = SHFW_SHFW_BZMDJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_BZMDJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_BZMDJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_BZMDJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_SHFW_GDSTQLJBXX(JCXX jcxx, SHFW_SHFW_GDSTQLJBXX SHFW_SHFW_GDSTQLJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_GDSTQLJBXX WHERE ID='{0}'", SHFW_SHFW_GDSTQLJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_GDSTQLJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_GDSTQLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_GDSTQLJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_GDSTQLJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_GDSTQLJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_GDSTQLJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_GDSTQLJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_GDSTQLJBXX(string ID)
        {
            try
            {
                SHFW_SHFW_GDSTQLJBXX SHFW_SHFW_GDSTQLJBXX = DAO.GetObjectByID<SHFW_SHFW_GDSTQLJBXX>(ID);
                if (SHFW_SHFW_GDSTQLJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_GDSTQLJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_GDSTQLJBXX = SHFW_SHFW_GDSTQLJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_GDSTQLJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_GDSTQLJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_GDSTQLJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_SHFW_KSHSXSJBXX(JCXX jcxx, SHFW_SHFW_KSHSXSJBXX SHFW_SHFW_KSHSXSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_KSHSXSJBXX WHERE ID='{0}'", SHFW_SHFW_KSHSXSJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_KSHSXSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_KSHSXSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_KSHSXSJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_KSHSXSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_KSHSXSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_KSHSXSJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_KSHSXSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_KSHSXSJBXX(string ID)
        {
            try
            {
                SHFW_SHFW_KSHSXSJBXX SHFW_SHFW_KSHSXSJBXX = DAO.GetObjectByID<SHFW_SHFW_KSHSXSJBXX>(ID);
                if (SHFW_SHFW_KSHSXSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_KSHSXSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_KSHSXSJBXX = SHFW_SHFW_KSHSXSJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_KSHSXSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_KSHSXSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_KSHSXSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_SHFW_QMFSSMJBXX(JCXX jcxx, SHFW_SHFW_QMFSSMJBXX SHFW_SHFW_QMFSSMJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_QMFSSMJBXX WHERE ID='{0}'", SHFW_SHFW_QMFSSMJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_QMFSSMJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_QMFSSMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_QMFSSMJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_QMFSSMJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_QMFSSMJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_QMFSSMJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_QMFSSMJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_QMFSSMJBXX(string ID)
        {
            try
            {
                SHFW_SHFW_QMFSSMJBXX SHFW_SHFW_QMFSSMJBXX = DAO.GetObjectByID<SHFW_SHFW_QMFSSMJBXX>(ID);
                if (SHFW_SHFW_QMFSSMJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_QMFSSMJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_QMFSSMJBXX = SHFW_SHFW_QMFSSMJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_QMFSSMJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_QMFSSMJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_QMFSSMJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_SHFW_SHPSJBXX(JCXX jcxx, SHFW_SHFW_SHPSJBXX SHFW_SHFW_SHPSJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_SHFW_SHPSJBXX WHERE ID='{0}'", SHFW_SHFW_SHPSJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_SHFW_SHPSJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_SHFW_SHPSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_SHPSJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_SHFW_SHPSJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_SHFW_SHPSJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_SHFW_SHPSJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_SHFW_SHPSJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_SHFW_SHPSJBXX(string ID)
        {
            try
            {
                SHFW_SHFW_SHPSJBXX SHFW_SHFW_SHPSJBXX = DAO.GetObjectByID<SHFW_SHFW_SHPSJBXX>(ID);
                if (SHFW_SHFW_SHPSJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_SHFW_SHPSJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_SHFW_SHPSJBXX = SHFW_SHFW_SHPSJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_SHFW_SHPSJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_SHFW_SHPSJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_SHFW_SHPSJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_WXFW_DNWXJBXX(JCXX jcxx, SHFW_WXFW_DNWXJBXX SHFW_WXFW_DNWXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_WXFW_DNWXJBXX WHERE ID='{0}'", SHFW_WXFW_DNWXJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_WXFW_DNWXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_WXFW_DNWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_DNWXJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_WXFW_DNWXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_WXFW_DNWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_DNWXJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_WXFW_DNWXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_WXFW_DNWXJBXX(string ID)
        {
            try
            {
                SHFW_WXFW_DNWXJBXX SHFW_WXFW_DNWXJBXX = DAO.GetObjectByID<SHFW_WXFW_DNWXJBXX>(ID);
                if (SHFW_WXFW_DNWXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_WXFW_DNWXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_WXFW_DNWXJBXX = SHFW_WXFW_DNWXJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_WXFW_DNWXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_WXFW_DNWXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_WXFW_DNWXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_WXFW_FWWXDKJBXX(JCXX jcxx, SHFW_WXFW_FWWXDKJBXX SHFW_WXFW_FWWXDKJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_WXFW_FWWXDKJBXX WHERE ID='{0}'", SHFW_WXFW_FWWXDKJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_WXFW_FWWXDKJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_WXFW_FWWXDKJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_FWWXDKJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_WXFW_FWWXDKJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_WXFW_FWWXDKJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_FWWXDKJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_WXFW_FWWXDKJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_WXFW_FWWXDKJBXX(string ID)
        {
            try
            {
                SHFW_WXFW_FWWXDKJBXX SHFW_WXFW_FWWXDKJBXX = DAO.GetObjectByID<SHFW_WXFW_FWWXDKJBXX>(ID);
                if (SHFW_WXFW_FWWXDKJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_WXFW_FWWXDKJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_WXFW_FWWXDKJBXX = SHFW_WXFW_FWWXDKJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_WXFW_FWWXDKJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_WXFW_FWWXDKJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_WXFW_FWWXDKJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_WXFW_JDWXJBXX(JCXX jcxx, SHFW_WXFW_JDWXJBXX SHFW_WXFW_JDWXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_WXFW_JDWXJBXX WHERE ID='{0}'", SHFW_WXFW_JDWXJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_WXFW_JDWXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_WXFW_JDWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_JDWXJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_WXFW_JDWXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_WXFW_JDWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_JDWXJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_WXFW_JDWXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_WXFW_JDWXJBXX(string ID)
        {
            try
            {
                SHFW_WXFW_JDWXJBXX SHFW_WXFW_JDWXJBXX = DAO.GetObjectByID<SHFW_WXFW_JDWXJBXX>(ID);
                if (SHFW_WXFW_JDWXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_WXFW_JDWXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_WXFW_JDWXJBXX = SHFW_WXFW_JDWXJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_WXFW_JDWXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_WXFW_JDWXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_WXFW_JDWXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_WXFW_JJWXJBXX(JCXX jcxx, SHFW_WXFW_JJWXJBXX SHFW_WXFW_JJWXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_WXFW_JJWXJBXX WHERE ID='{0}'", SHFW_WXFW_JJWXJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_WXFW_JJWXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_WXFW_JJWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_JJWXJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_WXFW_JJWXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_WXFW_JJWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_JJWXJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_WXFW_JJWXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_WXFW_JJWXJBXX(string ID)
        {
            try
            {
                SHFW_WXFW_JJWXJBXX SHFW_WXFW_JJWXJBXX = DAO.GetObjectByID<SHFW_WXFW_JJWXJBXX>(ID);
                if (SHFW_WXFW_JJWXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_WXFW_JJWXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_WXFW_JJWXJBXX = SHFW_WXFW_JJWXJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_WXFW_JJWXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_WXFW_JJWXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_WXFW_JJWXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }

        public object SaveSHFW_WXFW_SJSMWXJBXX(JCXX jcxx, SHFW_WXFW_SJSMWXJBXX SHFW_WXFW_SJSMWXJBXX, List<PHOTOS> photos)
        {
            DataTable dt = DAO.Repository.GetDataTable(string.Format("SELECT * FROM SHFW_WXFW_SJSMWXJBXX WHERE ID='{0}'", SHFW_WXFW_SJSMWXJBXX.ID));
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        SavePhotos(photos, dt.Rows[0]["JCXXID"].ToString());
                        SHFW_WXFW_SJSMWXJBXX.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        jcxx.JCXXID = dt.Rows[0]["JCXXID"].ToString();
                        DAO.Update(jcxx);
                        DAO.Update(SHFW_WXFW_SJSMWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_SJSMWXJBXX.ID } };
                    }
                    else
                    {
                        SavePhotos(photos, jcxx.JCXXID);
                        SHFW_WXFW_SJSMWXJBXX.JCXXID = jcxx.JCXXID;
                        DAO.Save(jcxx);
                        DAO.Save(SHFW_WXFW_SJSMWXJBXX);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { JCXXID = jcxx.JCXXID, ID = SHFW_WXFW_SJSMWXJBXX.ID } };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("SHFW_WXFW_SJSMWXJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new { Result = EnResultType.Failed, Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!", Type = 3 };
                }
            }
        }

        public object LoadSHFW_WXFW_SJSMWXJBXX(string ID)
        {
            try
            {
                SHFW_WXFW_SJSMWXJBXX SHFW_WXFW_SJSMWXJBXX = DAO.GetObjectByID<SHFW_WXFW_SJSMWXJBXX>(ID);
                if (SHFW_WXFW_SJSMWXJBXX != null)
                {
                    JCXX jcxx = GetJCXXByID(SHFW_WXFW_SJSMWXJBXX.JCXXID);
                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { SHFW_WXFW_SJSMWXJBXX = SHFW_WXFW_SJSMWXJBXX, BCMSString = BinaryHelper.BinaryToString(SHFW_WXFW_SJSMWXJBXX.BCMS), JCXX = jcxx, Photos = GetPhtosByJCXXID(SHFW_WXFW_SJSMWXJBXX.JCXXID) } };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("SHFW_WXFW_SJSMWXJBXXBLL", "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "载入失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
