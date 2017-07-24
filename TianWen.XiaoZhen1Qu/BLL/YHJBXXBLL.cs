using System;
using System.Data;
using NHibernate;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;
using TianWen.Framework.Log;
using System.Collections.Generic;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class YHJBXXBLL : BaseBLL, IYHJBXXBLL
    {
        public DataTable GetYHJBXXListByPage()
        {
            string sql = "select * from YHJBXX";
            return DAO.GetDataTable(sql);
        }

        public object CreateBasic(YHJBXX yhjbxx)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}'", yhjbxx.YHM));

            if (o1 != null && int.Parse(o1.ToString()) > 0)
            {
                return new { Result = EnResultType.Failed, Message = "用户名已存在!", Type = 2 };
            }
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    yhjbxx.MM = EncryptionHelper.MD5Encrypt64(yhjbxx.MM);
                    yhjbxx.SQRQ = DateTime.Now;
                    DAO.Save(yhjbxx);
                    DAO.Repository.Session.Flush();
                    transaction.Commit();
                    return new { Result = EnResultType.Success, Message = "保存成功!", Value = new { YHID = yhjbxx.YHID } };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "保存失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!",
                        Type = 3
                    };
                }
            }
        }

        //修改密码
        public object UpdatePassword(string MM, string SJ)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX yhjbxx = GetObjBySJ(SJ);
                    if (yhjbxx != null)
                    {
                        yhjbxx.MM = EncryptionHelper.MD5Encrypt64(MM);
                        DAO.Update(yhjbxx);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功", Value = new { YHID = yhjbxx.YHID } };
                    }
                    else
                    {
                        return new { Result = EnResultType.Failed, Message = "手机号为空或不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        //修改头像
        public object UpdateTX(string YHID, string TX)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHJBXX yhjbxx = DAO.GetObjectByID<YHJBXX>(YHID);
                    if (yhjbxx != null)
                    {
                        yhjbxx.TX = TX == string.Empty ? TX : TX.Substring(TX.LastIndexOf('/') + 1,  TX.Length-TX.LastIndexOf('/')-1);
                        DAO.Update(yhjbxx);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "上传头像成功", Value = new { YHID = yhjbxx.YHID } };
                    }
                    else
                    {
                        return new { Result = EnResultType.Failed, Message = "用户不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }

        public string GetObjByYHM(string YHM)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}'", YHM));
            if (o1 != null && int.Parse(o1.ToString()) > 0)
                return o1.ToString();
            else
                return string.Empty;
        }

        public YHJBXX GetObjBySJ(string SJ)
        {
            IList<YHJBXX> list = DAO.Repository.GetObjectList<YHJBXX>(String.Format("FROM YHJBXX WHERE SJ='{0}'", SJ));
            if (list.Count > 0)
                return list[0];
            else
                return null;
        }

        public string GetObjByYHMOrSJ(string YHM)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}' or SJ='{0}'", YHM));
            if (o1 != null && int.Parse(o1.ToString()) > 0)
                return o1.ToString();
            else
                return string.Empty;
        }

        public object GetObjByID(string YHID)
        {
            try
            {
                YHJBXX obj = DAO.GetObjectByID<YHJBXX>(YHID);
                return new
                {
                    Result = EnResultType.Success,
                    YHJBXX = obj
                };

            }
            catch (Exception ex)
            {
                LoggerManager.Error("YHJBXXBLL", "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                return new
                {
                    Result = EnResultType.Failed,
                    Message = "修改失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                };
            }
        }
    }
}
