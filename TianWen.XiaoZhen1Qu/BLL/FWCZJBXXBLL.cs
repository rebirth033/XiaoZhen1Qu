using System;
using System.Collections.Generic;
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
        public object SaveFWCZJBXX(FWCZJBXX fwczjbxx)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM FWCZJBXX WHERE FWCZID='{0}'", fwczjbxx.FWCZID));

            if (o1 != null && int.Parse(o1.ToString()) > 0)
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        DAO.Update(fwczjbxx);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "修改成功!", Value = new { FWCZID = fwczjbxx.FWCZID } };
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
            else
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        DAO.Save(fwczjbxx);
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "新增成功!", Value = new { FWCZID = fwczjbxx.FWCZID } };
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
        }


        public object LoadFWCZXX(string FWCZID)
        {
            try
            {
                FWCZJBXX yhjbxx = GetObjByID(FWCZID);
                if (yhjbxx != null)
                {

                    return new { Result = EnResultType.Success, Message = "载入成功", Value = new { FWCZXX = yhjbxx } };
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
    }
}
