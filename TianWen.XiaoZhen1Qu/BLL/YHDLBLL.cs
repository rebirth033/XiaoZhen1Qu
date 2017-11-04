using System;
using NHibernate;
using System.Collections.Generic;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class YHDLBLL : BaseBLL, IYHDLBLL
    {
        public object CheckLogin(string YHM, string MM, string SessionID)
        {
            object o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}'", YHM));
            if (int.Parse(o1.ToString()) == 0)
            {
                return new { Result = EnResultType.Failed, Message = "用户名不存在，请重新输入", Type = 1 };
            }
            o1 = DAO.Repository.ExecuteScalar(string.Format("SELECT COUNT(1) FROM YHJBXX WHERE YHM='{0}' and MM='{1}'", YHM, EncryptionHelper.MD5Encrypt64(MM)));
            if (int.Parse(o1.ToString()) == 0)
            {
                return new { Result = EnResultType.Failed, Message = "密码错误，请重新输入", Type = 2 };
            }
            else
            {
                using (ITransaction transaction = DAO.BeginTransaction())
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(SessionID))
                        {
                            ZDDLXX zddlxx = new ZDDLXX();
                            zddlxx.YHM = YHM;
                            zddlxx.SESSIONID = SessionID;
                            DAO.Save(zddlxx);
                            DAO.Repository.Session.Flush();
                            transaction.Commit();
                            return new { Result = EnResultType.Success, Message = "登录成功" };
                        }
                        else
                        {
                            return new { Result = EnResultType.Success, Message = "登录成功" };
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new { Result = EnResultType.Failed, Message = "登录失败" };
                    }
                }

            }
        }

        public object AutoLogin(string YHM, string SessionID)
        {
            try
            {
                object o1 =
                    DAO.Repository.ExecuteScalar(
                        string.Format("SELECT COUNT(1) FROM ZDDLXX WHERE YHM='{0}' AND SESSIONID='{1}'", YHM, SessionID));
                if (int.Parse(o1.ToString()) == 0)
                {
                    return new {Result = EnResultType.Failed, Message = "登录失败"};
                }
                else
                {
                    return new {Result = EnResultType.Success, Message = "登录成功"};
                }
            }
            catch (Exception ex)
            {
                return new { Result = EnResultType.Failed, Message = "登录失败" };
            }
        }

        public YHJBXX AddUserBySJ(string SJ)
        {
            try
            {
                IList<YHJBXX> YHJBXXs = DAO.GetObjectList<YHJBXX>(string.Format("FROM YHJBXX WHERE SJ='{0}'", SJ));
                if (YHJBXXs.Count>0)
                {
                    return YHJBXXs[0];
                }
                else
                {
                    YHJBXX newobj = new YHJBXX();
                    newobj.MM = EncryptionHelper.MD5Encrypt64("111111a");
                    newobj.SJ = SJ;
                    newobj.SQRQ = DateTime.Now;
                    newobj.YHM = "new_user";
                    DAO.Save(newobj);
                    return newobj;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
