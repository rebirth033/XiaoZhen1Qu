using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Mapping.ByCode.Impl.CustomizersImpl;
using TianWen.Framework.Log;
using TianWen.XiaoZhen1Qu.Entities.Common;
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
                int TotalCount = list.Count;
                var WDCountlist = from p in list.Where(p => p.STATUS == 0) select p;
                int WCCount = WDCountlist.Count();

                var listnew = from p in list
                    .Skip((int.Parse(PageIndex) - 1) * int.Parse(PageSize))
                    .Take(int.Parse(PageSize))
                              select p;

                foreach (var obj in listnew)
                {
                    obj.XXLBMC = Enum.GetName(typeof(XXLBMJ), obj.XXLB);
                }
                return new { Result = EnResultType.Success, list = listnew, PageCount = PageCount, TotalCount = TotalCount, WCCount = WCCount };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadYHXXMX(string YHID, string YHXXID)
        {
            try
            {
                IList<YHXX> list = new List<YHXX>();
                list = DAO.Repository.GetObjectList<YHXX>(String.Format("FROM YHXX WHERE YHID='{0}' ORDER BY XXSJ ASC", YHID));

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].YHXXID == YHXXID)
                    {
                        YHXX obj = DAO.GetObjectByID<YHXX>(YHXXID);
                        obj.STATUS = 1;
                        DAO.Update(obj);
                        DAO.Repository.Session.Flush();
                        list[i].XXXXSTR = Common.ToString(list[i].XXXX);
                        return new { Result = EnResultType.Success, YHXX = list[i], HasUp = i == 0 ? 0 : 1, HasDown = i == list.Count - 1 ? 0 : 1 };
                    }
                    
                }

                if (list.Count > 0)
                {
                    return new { Result = EnResultType.Success, YHXX = list.FirstOrDefault() };
                }
                else
                {
                    return new { Result = EnResultType.Failed, Message = "用户消息不存在" };
                }
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadUpYHXXMX(string YHID, string YHXXID)
        {
            try
            {
                IList<YHXX> list = new List<YHXX>();
                list = DAO.Repository.GetObjectList<YHXX>(String.Format("FROM YHXX WHERE YHID='{0}' ORDER BY XXSJ ASC", YHID));

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].YHXXID == YHXXID)
                    {
                        YHXX obj = DAO.GetObjectByID<YHXX>(list[i - 1].YHXXID);
                        obj.STATUS = 1;
                        DAO.Update(obj);
                        DAO.Repository.Session.Flush();
                        list[i - 1].XXXXSTR = Common.ToString(list[i-1].XXXX);
                        return new { Result = EnResultType.Success, YHXX = list[i - 1], HasUp = (i - 1) == 0 ? 0 : 1, HasDown = 1 };
                    }
                }
                return new { Result = EnResultType.Failed, Message = "不存在" };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object LoadDownYHXXMX(string YHID, string YHXXID)
        {
            try
            {
                IList<YHXX> list = new List<YHXX>();
                list = DAO.Repository.GetObjectList<YHXX>(String.Format("FROM YHXX WHERE YHID='{0}' ORDER BY XXSJ ASC", YHID));

                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].YHXXID == YHXXID)
                    {
                        YHXX obj = DAO.GetObjectByID<YHXX>(list[i + 1].YHXXID);
                        obj.STATUS = 1;
                        DAO.Update(obj);
                        DAO.Repository.Session.Flush();
                        list[i + 1].XXXXSTR = Common.ToString(list[i + 1].XXXX);
                        return new { Result = EnResultType.Success, YHXX = list[i + 1], HasUp = 1, HasDown = (i + 1) == list.Count - 1 ? 0 : 1 };
                    }
                }
                return new { Result = EnResultType.Failed, Message = "不存在" };
            }
            catch (Exception ex)
            {
                LoggerManager.Error("error", ex.Message);
                return new { Result = EnResultType.Failed, Message = "加载失败" };
            }
        }

        public object DeleteYHXX(string[] YHXXIDs)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    foreach (var YHXXID in YHXXIDs)
                    {
                        YHXX yhxx = DAO.GetObjectByID<YHXX>(YHXXID);
                        if (yhxx != null)
                        {
                            DAO.Remove(yhxx);
                        }
                    }
                    DAO.Repository.Session.Flush();
                    transaction.Commit();
                    return new { Result = EnResultType.Success, Message = "删除成功" };
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

        public object YDYHXX(string[] YHXXIDs)
        {
            using (ITransaction transaction = DAO.BeginTransaction())
            {
                try
                {
                    foreach (var YHXXID in YHXXIDs)
                    {
                        YHXX yhxx = DAO.GetObjectByID<YHXX>(YHXXID);
                        if (yhxx != null)
                        {
                            yhxx.STATUS = 1;
                            DAO.Update(yhxx);
                        }
                    }
                    DAO.Repository.Session.Flush();
                    transaction.Commit();
                    return new { Result = EnResultType.Success, Message = "修改成功" };
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
    }
}
