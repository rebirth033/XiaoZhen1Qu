using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Enum;
using TianWen.XiaoZhen1Qu.Entities.Models;
using TianWen.XiaoZhen1Qu.Interface;

namespace TianWen.XiaoZhen1Qu.BLL
{
    public class XXGLBLL : BaseBLL, IXXGLBLL
    {
        public object LoadYHXX(string YHID, string TYPE, string PageIndex, string PageSize)
        {
            try
            {
                IList<YHXX> list = new List<YHXX>();
                if (TYPE == "divXTTZLB")//消息类别为系统通知
                {
                    list = DAO.Repository.GetObjectList<YHXX>(String.Format("FROM YHXX WHERE YHID='{0}' AND XXLB=0 ORDER BY XXSJ DESC", YHID));
                }

                int PageCount = (list.Count + int.Parse(PageSize) - 1) / int.Parse(PageSize);

                var listnew = from p in list
                    .Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize))
                    .Take(int.Parse(PageSize))
                              select p;

                foreach (var obj in listnew)
                {
                    obj.XXLBMC = Enum.GetName(typeof(XXLBMJ), obj.XXLB);
                }
                return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object DeleteYHXX(string YHXXID)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    YHXX yhxx = DAO.GetObjectByID<YHXX>(YHXXID);
                    if (yhxx != null)
                    {
                        DAO.Remove(yhxx);
                        DAO.Repository.Session.Flush();
                        transaction.Commit();
                        return new { Result = EnResultType.Success, Message = "删除成功" };
                    }
                    else
                    {
                        return new { Result = EnResultType.Failed, Message = "消息不存在" };
                    }

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    LoggerManager.Error("YHJBXXBLL", "删除失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!");
                    return new
                    {
                        Result = EnResultType.Failed,
                        Message = "删除失败【" + ex.Message + "\r\n" + ex.StackTrace + "】!"
                    };
                }
            }
        }
    }
}
